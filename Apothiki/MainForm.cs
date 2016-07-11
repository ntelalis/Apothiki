using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {
    public partial class MainForm : Form {
        NewDialog newDialog;
        DelDialog delDialog;
        SxesiDialog sxesidialog;
        String conString;   //DB Connection String
        List<String> productStrings = new List<string>();
        SqlConnection con;
        SqlDataReader dataReader;

        String delKoutiCmdString, changeKoutiCmdString,
               delProionCmdString, changeProionCmdString,   //SqlCommandStrings
               newSxesiCmdString, delSxesiCmdString,
               SxesiByProionCmdString, SxesiByKoutiCmdString,
               SxeseisCmdString, KoutiByIdCmdString,
               KoutiaCmdString, ProiontaCmdString;

        SqlCommand delKoutiCmd, changeKoutiCmd,
                   delProionCmd, changeProionCmd,         //SqlCommands
                   newSxesiCmd, delSxesiCmd,
                   KoutiaCmd, ProiontaCmd,
                   SxesiByProionCmd, SxesiProionByKoutiCmd,
                   SxeseisCmd, KoutiLocByIdCmd;
        private void αλλαγήToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;  //DataTables
        ApothikiDataSet.SxesiDataTable sxesiTable;

        private void importProionToKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog();

            koutiTable.Clear();
            proionTable.Clear();
            try {
                con.Open();

                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();

                dataReader = ProiontaCmd.ExecuteReader();
                proionTable.Load(dataReader);
                dataReader.Close();
                ProiontaCmd.Dispose();

                sxesidialog.setComboBox1(koutiTable);
                sxesidialog.setComboBox2(proionTable);
                if (sxesidialog.ShowDialog(this) == DialogResult.OK) {
                    try {
                        newSxesiCmd.Parameters["@KoutiId"].Value = sxesidialog.getComboBox1();
                        newSxesiCmd.Parameters["@ProionName"].Value = sxesidialog.getComboBox2();

                        KoutiLocByIdCmd.Parameters["@Id"].Value = newSxesiCmd.Parameters["@KoutiId"].Value;
                        dataReader = KoutiLocByIdCmd.ExecuteReader();
                        if (dataReader.HasRows) {
                            dataReader.Read();
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = dataReader.GetString(1);
                            dataReader.Close();
                            ProiontaCmd.Dispose();

                        }
                        else {
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = "";
                        }

                        int rowsAffected = newSxesiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1) {
                            MessageBox.Show("Η εισαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (rowsAffected == 0) {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx) {
                        if (sqlEx.Number == 2627) {
                            MessageBox.Show("Το προϊόν υπάρχει ήδη στο Κουτί", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else {
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void exportProionApoKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog(conString);

            koutiTable.Clear();

            try {
                con.Open();

                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();
                con.Close();

                sxesidialog.setComboBox1(koutiTable);

                if (sxesidialog.ShowDialog(this) == DialogResult.OK) {
                    try {
                        delSxesiCmd.Parameters["@KoutiId"].Value = sxesidialog.getComboBox1();
                        delSxesiCmd.Parameters["@ProionName"].Value = sxesidialog.getComboBox2();
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
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void newKouti_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Kouti, con);
            newDialog.ShowDialog(this);
        }

        private void newProion_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Proion, con);
            newDialog.ShowDialog(this);
            updateProductStrings();
        }
        private void changeKouti_Click(object sender, EventArgs e) {

        }

        private void changeProion_Click(object sender, EventArgs e) {

        }
        private void delKouti_Click(object sender, EventArgs e) {
            delDialog = new DelDialog(DelDialogType.Kouti, con);
            delDialog.ShowDialog(this);
            searchSxeseisTextBox_TextChanged(null, null);
        }
        private void delProion_Click(object sender, EventArgs e) {
            delDialog = new DelDialog(DelDialogType.Proion, con);
            delDialog.ShowDialog(this);
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }
        private void showKoutia_Click(object sender, EventArgs e) {

            koutiTable.Clear();
            try {
                con.Open();
                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();
                dataGridView.DataSource = koutiTable;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[0].HeaderText = "Αριθμός";
                dataGridView.Columns[1].HeaderText = "Τοποθεσία";

            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void showProionta_Click(object sender, EventArgs e) {
            proionTable.Clear();
            try {
                con.Open();
                dataReader = ProiontaCmd.ExecuteReader();
                proionTable.Load(dataReader);
                dataReader.Close();
                ProiontaCmd.Dispose();
                dataGridView.DataSource = proionTable;
                dataGridView.Columns[0].Width = 250;
                dataGridView.Columns[0].HeaderText = "Όνομα";

            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }
        private void showSxeseis_Click(object sender, EventArgs e) {
            sxesiTable.Clear();
            try {
                con.Open();
                dataReader = SxeseisCmd.ExecuteReader();
                sxesiTable.Load(dataReader);
                dataReader.Close();
                SxeseisCmd.Dispose();
                dataGridView.DataSource = sxesiTable;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 230;
                dataGridView.Columns[2].Width = 130;
                dataGridView.Columns[0].HeaderText = "Κουτί";
                dataGridView.Columns[1].HeaderText = "Προϊόν";
                dataGridView.Columns[2].HeaderText = "Τοποθεσία";

            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }



        private void searchSxeseisTextBox_TextChanged(object sender, EventArgs e) {
            sxesiTable.Clear();
            try {
                String name = searchSxeseisTextBox.Text;
                name = name.Trim();
                con.Open();
                foreach (String s in productStrings) {
                    if (s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {

                        SxesiByProionCmd.Parameters["@ProionName"].Value = s;
                        dataReader = SxesiByProionCmd.ExecuteReader();
                        sxesiTable.Load(dataReader);
                    }
                }
                dataReader.Close();
                SxesiByProionCmd.Dispose();
                dataGridView.DataSource = sxesiTable;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 230;
                dataGridView.Columns[2].Width = 130;

            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        ApothikiDataSet apothikidataset;

        public MainForm() {
            InitializeComponent();
            initStrings();
            con = new SqlConnection(conString);
            initCmds();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            updateProductStrings();
            showSxeseis_Click(null, null);

        }

        private void initStrings() {
            conString = Apothiki.Properties.Settings.Default.ApothikiConnectionString;

            changeKoutiCmdString = "UPDATE KOUTI SET (Location=@Location) WHERE (KoutiId=@KoutiId)";


            changeProionCmdString = "UPDATE PROION SET (Name=@NewName) WHERE (Name=@OldName)";

            newSxesiCmdString = "INSERT INTO SXESI (KoutiId,ProionName,KoutiLocation) VALUES (@KoutiId,@ProionName,@KoutiLocation)";
            delSxesiCmdString = "DELETE FROM SXESI WHERE (KoutiId=@KoutiId) AND (ProionName=@ProionName)";

            KoutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
            ProiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
            SxeseisCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";

            KoutiByIdCmdString = "SELECT * FROM KOUTI WHERE (Id=@Id)";
            SxesiByProionCmdString = "SELECT * FROM SXESI WHERE (ProionName=@ProionName) ORDER BY KoutiId";
            SxesiByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
        }

        private void initCmds() {



            changeKoutiCmd = new SqlCommand(changeKoutiCmdString, con);
            changeKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            changeKoutiCmd.Parameters.Add("@Location", SqlDbType.NVarChar);

            changeProionCmd = new SqlCommand(changeProionCmdString, con);
            changeProionCmd.Parameters.Add("@NewName", SqlDbType.NVarChar);
            changeProionCmd.Parameters.Add("@OldName", SqlDbType.NVarChar);

            newSxesiCmd = new SqlCommand(newSxesiCmdString, con);
            newSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            newSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);
            newSxesiCmd.Parameters.Add("@KoutiLocation", SqlDbType.NVarChar);

            delSxesiCmd = new SqlCommand(delSxesiCmdString, con);
            delSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            delSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            KoutiaCmd = new SqlCommand(KoutiaCmdString, con);

            ProiontaCmd = new SqlCommand(ProiontaCmdString, con);

            KoutiLocByIdCmd = new SqlCommand(KoutiByIdCmdString, con);
            KoutiLocByIdCmd.Parameters.Add("@Id", SqlDbType.Int);

            SxeseisCmd = new SqlCommand(SxeseisCmdString, con);

            SxesiByProionCmd = new SqlCommand(SxesiByProionCmdString, con);
            SxesiByProionCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            SxesiProionByKoutiCmd = new SqlCommand(SxesiByKoutiCmdString, con);
            SxesiProionByKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

            apothikidataset = new ApothikiDataSet();

            koutiTable = new ApothikiDataSet.KoutiDataTable();
            proionTable = new ApothikiDataSet.ProionDataTable();
            sxesiTable = new ApothikiDataSet.SxesiDataTable();
        }



        private void updateProductStrings() {

            productStrings = new List<string>();

            try {
                con.Open();
                dataReader = ProiontaCmd.ExecuteReader();

                if (dataReader.HasRows)
                    while (dataReader.Read())
                        productStrings.Add(dataReader.GetString(0));

                dataReader.Close();
                ProiontaCmd.Dispose();
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if(con.State != ConnectionState.Closed)
                    con.Close();
            }
        }
    }
}
