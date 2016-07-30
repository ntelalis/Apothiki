using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum SxesiDialogType {
        Import, Export
    }
    public partial class SxesiDialog : Form {

        String newSxesiCmdString, delSxesiCmdString,
               koutiaCmdString, proiontaCmdString,
               sxesiCmdString, sxesiByKoutiCmdString,
               koutiByIdCmdString;

        SqlCommand newSxesiCmd, delSxesiCmd,
                   koutiaCmd, proiontaCmd,
                   sxesiCmd, sxesiByKoutiCmd,
                   koutiByIdCmd;

        SqlConnection con;
        SqlDataReader dataReader;
        SxesiDialogType sxesiDialogType;

        ApothikiDataSet.SxesiDataTable sxesiTableName;
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        DataTable dataTable;

        public SxesiDialog(SxesiDialogType sxesiDialogType, SqlConnection con) {

            InitializeComponent();
            this.con = con;
            this.sxesiDialogType = sxesiDialogType;

            if (sxesiDialogType == SxesiDialogType.Import) {

                this.Text = "Εισαγωγή προϊόντος σε κουτί";

                newSxesiCmdString = "INSERT INTO SXESI (KoutiId,ProionName,KoutiLocation) VALUES (@KoutiId,@ProionName,@KoutiLocation)";
                newSxesiCmd = new SqlCommand(newSxesiCmdString, con);
                newSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
                newSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);
                newSxesiCmd.Parameters.Add("@KoutiLocation", SqlDbType.NVarChar);

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);

                proiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
                proiontaCmd = new SqlCommand(proiontaCmdString, con);

                koutiByIdCmdString = "SELECT * FROM Kouti WHERE (Id=@Id)";
                koutiByIdCmd = new SqlCommand(koutiByIdCmdString, con);
                koutiByIdCmd.Parameters.Add("@Id", SqlDbType.Int);

                koutiTable = new ApothikiDataSet.KoutiDataTable();
                proionTable = new ApothikiDataSet.ProionDataTable();


            }
            else if (sxesiDialogType == SxesiDialogType.Export) {

                this.Text = "Εξαγωγή προϊόντος από κουτί";

                delSxesiCmdString = "DELETE FROM SXESI WHERE (KoutiId=@KoutiId) AND (ProionName=@ProionName)";
                delSxesiCmd = new SqlCommand(delSxesiCmdString, con);
                delSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
                delSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

                sxesiCmdString = "SELECT DISTINCT KoutiId FROM SXESI ORDER BY KoutiId";
                sxesiCmd = new SqlCommand(sxesiCmdString, con);

                sxesiByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
                sxesiByKoutiCmd = new SqlCommand(sxesiByKoutiCmdString, con);
                sxesiByKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

                dataTable = new DataTable();
                sxesiTableName = new ApothikiDataSet.SxesiDataTable();
            }
        }

        private void SxesiDialog_Load(object sender, EventArgs e) {
            fillComboBoxes();
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

                    comboBox2.DataSource = proionTable;
                    comboBox2.DisplayMember = "Name";
                    comboBox2.BindingContext = this.BindingContext;

                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                updateOKButton();
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {

                comboBox1.Items.Clear();
                dataTable.Clear();
                sxesiTableName.Clear();
                try {
                    con.Open();

                    dataReader = sxesiCmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataReader.Close();
                    sxesiCmd.Dispose();

                    if (dataTable.Rows.Count > 0) {
                        foreach (DataRow dataRow in dataTable.Rows)
                            comboBox1.Items.Add(dataRow["KoutiId"].ToString());
                    }
                    else {
                        comboBox1.Text = "";
                    }

                    updateOKButton();

                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Export) {
                updateComboBox2();
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Import) {
                try {
                    int koutiId = Int32.Parse(comboBox1.Text);
                    String proionName = comboBox2.Text;
                    newSxesiCmd.Parameters["@KoutiId"].Value = koutiId;
                    newSxesiCmd.Parameters["@ProionName"].Value = proionName;
                    koutiByIdCmd.Parameters["@Id"].Value = newSxesiCmd.Parameters["@KoutiId"].Value;
                    try {
                        con.Open();
                        dataReader = koutiByIdCmd.ExecuteReader();
                        koutiByIdCmd.Dispose();
                        if (dataReader.HasRows) {
                            dataReader.Read();
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = dataReader.GetString(1);
                        }
                        else {
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = "";
                        }
                        dataReader.Close();
                        int rowsAffected = newSxesiCmd.ExecuteNonQuery();
                        newSxesiCmd.Dispose();
                        if (rowsAffected == 1)
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
                        con.Close();
                        if (rowsAffected == 1) {
                            MessageBox.Show("Η εξαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (rowsAffected == 0) {
                            MessageBox.Show("Η εξαγωγή δεν ήταν επιτυχής. Το κουτί ή το προϊόν που πληκτρολογήσατε δεν υπάρχει στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        fillComboBoxes();
                        comboBox1_SelectedIndexChanged(null, null);
                        updateOKButton();

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
            }
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }

        private void updateOKButton() {
            if (comboBox1.Text != "" && comboBox2.Text != "")
                OKButton.Enabled = true;
            else
                OKButton.Enabled = false;
        }



        private void updateComboBox2() {
            if (comboBox1.Text != "") {

                sxesiTableName.Clear();
                sxesiByKoutiCmd.Parameters["@KoutiId"].Value = Int32.Parse(comboBox1.Text);

                try {
                    con.Open();
                    dataReader = sxesiByKoutiCmd.ExecuteReader();
                    sxesiTableName.Load(dataReader);
                    dataReader.Close();
                    sxesiByKoutiCmd.Dispose();
                    con.Close();
                    comboBox2.DataSource = sxesiTableName;
                    comboBox2.DisplayMember = "ProionName";
                    comboBox2.BindingContext = this.BindingContext;
                    updateOKButton();
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }

        }
    }
}
