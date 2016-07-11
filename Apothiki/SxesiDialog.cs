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

        ApothikiDataSet.SxesiDataTable sxesiTable;
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;

        private void OKButton_Click(object sender, EventArgs e) {
            if (sxesiDialogType == SxesiDialogType.Import) {

                int koutiId = Int32.Parse(comboBox1.Text);
                String proionName = comboBox2.Text;
                newSxesiCmd.Parameters["@KoutiId"].Value = koutiId;
                newSxesiCmd.Parameters["@ProionName"].Value = proionName;
                koutiByIdCmd.Parameters["@Id"].Value = newSxesiCmd.Parameters["@KoutiId"].Value;
                try {
                    con.Open();
                    dataReader = koutiByIdCmd.ExecuteReader();
                    if (dataReader.HasRows) {
                        dataReader.Read();
                        newSxesiCmd.Parameters["@KoutiLocation"].Value = dataReader.GetString(1);
                        dataReader.Close();
                        koutiByIdCmd.Dispose();
                    }
                    else {
                        newSxesiCmd.Parameters["@KoutiLocation"].Value = "";
                    }

                    int rowsAffected = newSxesiCmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                        MessageBox.Show("Η εισαγωγή του προϊόντος \"" + proionName + "\" στο κουτί " + koutiId + " ολοκληρώθηκε με επιτυχία.", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SqlException sqlEx) {
                    if (sqlEx.Number == 2627) {
                        MessageBox.Show("Το προϊόν \"" + proionName + "\" υπάρχει ήδη στο Κουτί " + koutiId, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {

            }
        }


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

                fillComboBoxes();
            }
            else if (sxesiDialogType == SxesiDialogType.Export) {

                this.Text = "Εξαγωγή προϊόντος από κουτί";

                delSxesiCmdString = "DELETE FROM SXESI WHERE (KoutiId=@KoutiId) AND (ProionName=@ProionName)";
                delSxesiCmd = new SqlCommand(delSxesiCmdString, con);
                delSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
                delSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

                sxesiCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";
                sxesiCmd = new SqlCommand(sxesiCmdString, con);

                sxesiByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
                sxesiByKoutiCmd = new SqlCommand(sxesiByKoutiCmdString, con);
                sxesiByKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

                sxesiTable = new ApothikiDataSet.SxesiDataTable();

                fillComboBoxes();
            }

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
                con.Close();

            }
            else if (sxesiDialogType == SxesiDialogType.Export) {


                koutiTable.Clear();

                try {
                    con.Open();

                    dataReader = sxesiCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    dataReader.Close();
                    sxesiCmd.Dispose();

                    dataReader = sxesiByKoutiCmd.ExecuteReader();
                    proionTable.Load(dataReader);
                    dataReader.Close();
                    sxesiByKoutiCmd.Dispose();

                    comboBox1.DataSource = koutiTable;
                    comboBox1.DisplayMember = "Id";
                    comboBox1.BindingContext = this.BindingContext;
                    comboBox2.DataSource = proionTable;
                    comboBox2.DisplayMember = "Name";
                    comboBox2.BindingContext = this.BindingContext;

                    try {
                        //delSxesiCmd.Parameters["@KoutiId"].Value = sxesidialog.getComboBox1();
                        //delSxesiCmd.Parameters["@ProionName"].Value = sxesidialog.getComboBox2();
                        con.Open();
                        int rowsAffected = delSxesiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1) {
                            MessageBox.Show("Η εξαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (rowsAffected == 0) {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                updateOKButton();

            }
        }

        private void updateOKButton() {
            if (comboBox1.Text != "" && comboBox2.Text != "")
                OKButton.Enabled = true;
            else
                OKButton.Enabled = false;
        }

        public void setComboBox1(ApothikiDataSet.KoutiDataTable koutiTable) {
            comboBox1.DataSource = koutiTable;
            comboBox1.DisplayMember = "Id";
            comboBox1.BindingContext = this.BindingContext;
        }

        public void setComboBox2(ApothikiDataSet.ProionDataTable proionTable) {
            comboBox2.DataSource = proionTable;
            comboBox2.DisplayMember = "Name";
            comboBox2.BindingContext = this.BindingContext;
        }

        private void setComboBox2(ApothikiDataSet.SxesiDataTable sxesiTable) {
            comboBox2.DataSource = sxesiTable;
            comboBox2.DisplayMember = "ProionName";
            comboBox2.BindingContext = this.BindingContext;
        }

        private void SxesiDialog_Load(object sender, EventArgs e) {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            loadcmbox2();
        }

        private void updateOKButtonForDelete() {
            if (comboBox1.Text != "" && comboBox2.Text != "")
                OKButton.Enabled = true;
            else
                OKButton.Enabled = false;
        }

        private void loadcmbox2() {

            if (comboBox1.Text != "") {
                sxesiByKoutiCmd.Parameters["@KoutiId"].Value = Int32.Parse(comboBox1.Text);
                try {
                    sxesiTable.Clear();
                    con.Close();
                    con.Open();
                    dataReader = sxesiByKoutiCmd.ExecuteReader();
                    sxesiTable.Load(dataReader);
                    dataReader.Close();
                    sxesiByKoutiCmd.Dispose();
                    con.Close();
                    setComboBox2(sxesiTable);
                    //updateOKButton();
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
