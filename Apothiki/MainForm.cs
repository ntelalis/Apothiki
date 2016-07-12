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
        ChangeDialog changeDialog;

        String conString;   //DB Connection String
        List<String> productStrings = new List<string>();
        SqlConnection con;
        SqlDataReader dataReader;

        String changeKoutiCmdString,
               changeProionCmdString,   //SqlCommandStrings
               SxesiByProionCmdString, SxesiByKoutiCmdString,
               SxeseisCmdString, KoutiByIdCmdString,
               KoutiaCmdString, ProiontaCmdString;

        SqlCommand changeKoutiCmd,
                   changeProionCmd,         //SqlCommands
                   KoutiaCmd, ProiontaCmd,
                   SxesiByProionCmd, SxesiProionByKoutiCmd,
                   SxeseisCmd, KoutiLocByIdCmd;

        ApothikiDataSet apothikidataset;
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;  //DataTables
        ApothikiDataSet.SxesiDataTable sxesiTable;

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

        private void importProionToKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog(SxesiDialogType.Import, con);
            sxesidialog.ShowDialog(this);
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void exportProionApoKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog(SxesiDialogType.Export, con);
            sxesidialog.ShowDialog(this);
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
            changeDialog = new ChangeDialog(ChangeDialogType.Kouti, con);
            changeDialog.ShowDialog(this);
        }

        private void changeProion_Click(object sender, EventArgs e) {
            changeDialog = new ChangeDialog(ChangeDialogType.Proion, con);
            changeDialog.ShowDialog(this);
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
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
                sxesiTable.DefaultView.Sort = "KoutiId asc";
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

        public void updateDataGridView() {
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
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
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void initStrings() {

            conString = Apothiki.Properties.Settings.Default.ApothikiConnectionString;

            KoutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
            ProiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
            SxeseisCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";

            SxesiByProionCmdString = "SELECT * FROM SXESI WHERE (ProionName=@ProionName) ORDER BY KoutiId";
            SxesiByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
        }

        private void initCmds() {

            KoutiaCmd = new SqlCommand(KoutiaCmdString, con);

            ProiontaCmd = new SqlCommand(ProiontaCmdString, con);

            SxeseisCmd = new SqlCommand(SxeseisCmdString, con);

            SxesiByProionCmd = new SqlCommand(SxesiByProionCmdString, con);
            SxesiByProionCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            koutiTable = new ApothikiDataSet.KoutiDataTable();
            proionTable = new ApothikiDataSet.ProionDataTable();
            sxesiTable = new ApothikiDataSet.SxesiDataTable();
        }
    }
}
