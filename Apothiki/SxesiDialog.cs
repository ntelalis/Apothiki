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
        DataTable sxesiTableKoutiId;
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

                sxesiTableKoutiId = new DataTable();
                sxesiTableProion = new ApothikiDataSet.SxesiDataTable();
            }
            fillComboBoxes();
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (comboBoxKouti.Text != "" && comboBoxProion.Text != "")
                OKButton.Enabled = true;
            else
                OKButton.Enabled = false;
        }

        private void comboBoxKouti_SelectedIndexChanged(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Export)
                updateComboBoxProion();
            toggleOKButton();
        }

        private void comboBoxKouti_TextUpdate(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void comboBoxProion_SelectedIndexChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void comboBoxProion_TextUpdate(object sender, EventArgs e) {
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

                    comboBoxKouti.DataSource = koutiTable;
                    comboBoxKouti.DisplayMember = "Id";
                    comboBoxKouti.BindingContext = this.BindingContext;
                    comboBoxKouti.SelectedIndex = -1;

                    comboBoxProion.DataSource = proionTable;
                    comboBoxProion.DisplayMember = "Name";
                    comboBoxProion.BindingContext = this.BindingContext;
                    comboBoxProion.SelectedIndex = -1;
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
                comboBoxKouti.Items.Clear();
                sxesiTableKoutiId.Clear();
                sxesiTableProion.Clear();
                try {
                    con.Open();
                    dataReader = sxeseisCmd.ExecuteReader();
                    sxesiTableKoutiId.Load(dataReader);
                    dataReader.Close();
                    sxeseisCmd.Dispose();

                    if (sxesiTableKoutiId.Rows.Count > 0)
                        foreach (DataRow dataRow in sxesiTableKoutiId.Rows)
                            comboBoxKouti.Items.Add(dataRow["KoutiId"].ToString());
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
                    int koutiId = Int32.Parse(comboBoxKouti.Text);
                    String proionName = comboBoxProion.Text;
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
                    int koutiId = Int32.Parse(comboBoxKouti.Text);
                    string proionName = comboBoxProion.Text;
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
                comboBoxKouti_SelectedIndexChanged(null, null);
                toggleOKButton();
            }
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }

        private void updateComboBoxProion() {
            if (comboBoxKouti.Text != "") {
                sxesiTableProion.Clear();
                sxeseisByKoutiCmd.Parameters["@KoutiId"].Value = Int32.Parse(comboBoxKouti.Text);

                try {
                    con.Open();
                    dataReader = sxeseisByKoutiCmd.ExecuteReader();
                    sxesiTableProion.Load(dataReader);
                    dataReader.Close();
                    sxeseisByKoutiCmd.Dispose();

                    comboBoxProion.DataSource = sxesiTableProion;
                    comboBoxProion.DisplayMember = "ProionName";
                    comboBoxProion.BindingContext = this.BindingContext;
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
