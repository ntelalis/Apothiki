using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum SxesiDialogType {
        Import, Export
    }

    public partial class SxesiDialog : Form {

        SqlConnection con;
        SxesiDialogType sxesiDialogType;

        String newSxesiCmdString, delSxesiCmdString,
               koutiaCmdString, proiontaCmdString, sxeseisCmdString,
               sxeseisByKoutiCmdString;
        SqlCommand newSxesiCmd, delSxesiCmd,
                   koutiaCmd, proiontaCmd, sxeseisCmd,
                   sxeseisByKoutiCmd;

        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        ApothikiDataSet.SxesiDataTable sxesiTableProion;
        DataTable sxesiTableId;
        SqlDataReader dataReader;

        public SxesiDialog(SxesiDialogType sxesiDialogType, SqlConnection con) {
            InitializeComponent();
            this.sxesiDialogType = sxesiDialogType;
            this.con = con;

            if (sxesiDialogType == SxesiDialogType.Import) {
                this.Text = "Εισαγωγή προϊόντος σε κουτί";

                newSxesiCmdString = "INSERT INTO SXESI (KoutiId,ProionName) VALUES (@KoutiId,@ProionName)";
                newSxesiCmd = new SqlCommand(newSxesiCmdString, con);
                newSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
                newSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);

                proiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
                proiontaCmd = new SqlCommand(proiontaCmdString, con);

                koutiTable = new ApothikiDataSet.KoutiDataTable();
                proionTable = new ApothikiDataSet.ProionDataTable();
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {
                this.Text = "Εξαγωγή προϊόντος από κουτί";

                delSxesiCmdString = "DELETE FROM SXESI WHERE (KoutiId=@KoutiId) AND (ProionName=@ProionName)";
                delSxesiCmd = new SqlCommand(delSxesiCmdString, con);
                delSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
                delSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

                sxeseisCmdString = "SELECT DISTINCT KoutiId FROM SXESI ORDER BY KoutiId";
                sxeseisCmd = new SqlCommand(sxeseisCmdString, con);

                sxeseisByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
                sxeseisByKoutiCmd = new SqlCommand(sxeseisByKoutiCmdString, con);
                sxeseisByKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

                sxesiTableId = new DataTable();
                sxesiTableProion = new ApothikiDataSet.SxesiDataTable();
            }
            fillComboBoxes();
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (comboBox1.Text != "" && comboBox2.Text != "")
                OKButton.Enabled = true;
            else
                OKButton.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Export)
                updateComboBox2();
            toggleOKButton();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void fillComboBoxes() {
            if (sxesiDialogType == SxesiDialogType.Import) {
                koutiTable.Clear();
                proionTable.Clear();
                try {
                    con.Open();
                    dataReader = koutiaCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    dataReader.Close();
                    koutiaCmd.Dispose();

                    dataReader = proiontaCmd.ExecuteReader();
                    proionTable.Load(dataReader);
                    dataReader.Close();
                    proiontaCmd.Dispose();

                    comboBox1.DataSource = koutiTable;
                    comboBox1.DisplayMember = "Id";
                    comboBox1.BindingContext = this.BindingContext;
                    comboBox1.SelectedIndex = -1;

                    comboBox2.DataSource = proionTable;
                    comboBox2.DisplayMember = "Name";
                    comboBox2.BindingContext = this.BindingContext;
                    comboBox2.SelectedIndex = -1;
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {
                comboBox1.Items.Clear();
                sxesiTableId.Clear();
                sxesiTableProion.Clear();
                try {
                    con.Open();
                    dataReader = sxeseisCmd.ExecuteReader();
                    sxesiTableId.Load(dataReader);
                    dataReader.Close();
                    sxeseisCmd.Dispose();

                    if (sxesiTableId.Rows.Count > 0)
                        foreach (DataRow dataRow in sxesiTableId.Rows)
                            comboBox1.Items.Add(dataRow["KoutiId"].ToString());
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            toggleOKButton();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Import) {
                try {
                    int koutiId = Int32.Parse(comboBox1.Text);
                    String proionName = comboBox2.Text;
                    newSxesiCmd.Parameters["@KoutiId"].Value = koutiId;
                    newSxesiCmd.Parameters["@ProionName"].Value = proionName;

                    try {
                        con.Open();
                        int rowsAffected = newSxesiCmd.ExecuteNonQuery();
                        newSxesiCmd.Dispose();

                        if (rowsAffected == 2)
                            MessageBox.Show("Η εισαγωγή του προϊόντος \"" + proionName + "\" στο κουτί " + koutiId + " ολοκληρώθηκε με επιτυχία.", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SqlException sqlEx) {
                        if (sqlEx.Number == 2627)
                            MessageBox.Show("Το προϊόν \"" + proionName + "\" υπάρχει ήδη στο Κουτί " + koutiId, "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (sqlEx.Number == 547)
                            MessageBox.Show("Η εισαγωγή δεν ήταν επιτυχής. Το κουτί ή το προϊόν που πληκτρολογήσατε δεν υπάρχει στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException) {
                    MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException) {
                    MessageBox.Show("Ο αριθμός που πληκτρολογήσατε είναι πολύ μεγάλος", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {
                try {
                    int koutiId = Int32.Parse(comboBox1.Text);
                    string proionName = comboBox2.Text;
                    delSxesiCmd.Parameters["@KoutiId"].Value = koutiId;
                    delSxesiCmd.Parameters["@ProionName"].Value = proionName;

                    try {
                        con.Open();
                        int rowsAffected = delSxesiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Η εξαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (rowsAffected == 0)
                            MessageBox.Show("Η εξαγωγή δεν ήταν επιτυχής. Το κουτί ή το προϊόν που πληκτρολογήσατε δεν υπάρχει στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (SqlException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException) {
                    MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException) {
                    MessageBox.Show("Ο αριθμός που πληκτρολογήσατε είναι πολύ μεγάλος", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                fillComboBoxes();
                comboBox1_SelectedIndexChanged(null, null);
                toggleOKButton();
            }
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }

        private void updateComboBox2() {
            if (comboBox1.Text != "") {
                sxesiTableProion.Clear();
                sxeseisByKoutiCmd.Parameters["@KoutiId"].Value = Int32.Parse(comboBox1.Text);

                try {
                    con.Open();
                    dataReader = sxeseisByKoutiCmd.ExecuteReader();
                    sxesiTableProion.Load(dataReader);
                    dataReader.Close();
                    sxeseisByKoutiCmd.Dispose();

                    comboBox2.DataSource = sxesiTableProion;
                    comboBox2.DisplayMember = "ProionName";
                    comboBox2.BindingContext = this.BindingContext;
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                toggleOKButton();
            }
        }
    }
}
