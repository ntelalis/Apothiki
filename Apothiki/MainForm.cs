using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public partial class MainForm : Form {

        //Window Forms
        NewDialog newDialog;
        DelDialog delDialog;
        SxesiDialog sxesidialog;
        ChangeDialog changeDialog;

        //Helper Lists for matching possible database values from incomplete strings
        List<String> productStrings;
        List<String> locationStrings;

        //DB related variables
        String conString;
        SqlConnection con;
        SqlDataReader dataReader;

        //SQL String queries 
        String koutiaCmdString, koutiaByIdCmdString, koutiaByLocationCmdString,
               proiontaCmdString, proiontaByNameCmdString,
               sxeseisCmdString, sxeseisByKoutiIdCmdString, sxeseisByProionNameCmdString, sxeseisByKoutiLocationCmdString,
               locationStringsCmdString;

        //SQL Command queries
        SqlCommand KoutiaCmd, KoutiaByIdCmd, KoutiaByLocationCmd,
                   ProiontaCmd, ProiontaByNameCmd,
                   SxeseisCmd, SxeseisByKoutiIdCmd, SxeseisByProionNameCmd, SxeseisByKoutiLocationCmd,
                   locationStringsCmd;

        //Datatables for storing select queries
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        ApothikiDataSet.SxesiDataTable sxesiTable;

        public MainForm() {
            InitializeComponent();
            initStrings();
            initCmds();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            updateProductStrings();
            updateLocationStrings();
            showSxeseis("");
        }

        private void importProionToKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog(SxesiDialogType.Import, con);
            sxesidialog.ShowDialog(this);
        }

        private void exportProionApoKouti_Click(object sender, EventArgs e) {
            sxesidialog = new SxesiDialog(SxesiDialogType.Export, con);
            sxesidialog.ShowDialog(this);
        }

        private void newKouti_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Kouti, con);
            newDialog.ShowDialog(this);
            updateLocationStrings();
        }

        private void newProion_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Proion, con);
            newDialog.ShowDialog(this);
            updateProductStrings();
        }

        private void changeKouti_Click(object sender, EventArgs e) {
            changeDialog = new ChangeDialog(ChangeDialogType.Kouti, con);
            changeDialog.ShowDialog(this);
            updateLocationStrings();
        }

        private void changeProion_Click(object sender, EventArgs e) {
            changeDialog = new ChangeDialog(ChangeDialogType.Proion, con);
            changeDialog.ShowDialog(this);
            updateProductStrings();
        }

        private void delKouti_Click(object sender, EventArgs e) {
            delDialog = new DelDialog(DelDialogType.Kouti, con);
            delDialog.ShowDialog(this);
            updateLocationStrings();
        }

        private void delProion_Click(object sender, EventArgs e) {
            delDialog = new DelDialog(DelDialogType.Proion, con);
            delDialog.ShowDialog(this);
            updateProductStrings();
        }

        private void radioSxeseis_CheckedChanged(object sender, EventArgs e) {
            showSxeseis(searchSxeseisTextBox.Text);
        }

        private void radioKoutia_CheckedChanged(object sender, EventArgs e) {
            showKoutia(searchSxeseisTextBox.Text);
        }

        private void radioProionta_CheckedChanged(object sender, EventArgs e) {
            showProionta(searchSxeseisTextBox.Text);
        }

        private void searchSxeseisTextBox_TextChanged(object sender, EventArgs e) {
            if (radioKoutia.Checked == true)
                showKoutia(searchSxeseisTextBox.Text);
            else if (radioProionta.Checked == true)
                showProionta(searchSxeseisTextBox.Text);
            else
                showSxeseis(searchSxeseisTextBox.Text);
        }

        public void updateDataGridViewByKoutia() {
            radioKoutia.Checked = true;
            searchSxeseisTextBox_TextChanged(null, null);
        }

        public void updateDataGridViewByProionta() {
            radioProionta.Checked = true;
            searchSxeseisTextBox_TextChanged(null, null);
        }

        public void updateDataGridViewBySxeseis() {
            radioSxeseis.Checked = true;
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void updateLocationStrings() {
            locationStrings.Clear();
            try {
                con.Open();
                dataReader = locationStringsCmd.ExecuteReader();
                if (dataReader.HasRows)
                    while (dataReader.Read())
                        locationStrings.Add(dataReader.GetString(1));

                dataReader.Close();
                locationStringsCmd.Dispose();
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void updateProductStrings() {
            productStrings.Clear();
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

        private void showKoutia(String text) {
            text = text.Trim();
            koutiTable.Clear();
            try {
                con.Open();
                //if there is text search by text or else return everything
                if (text != "") {
                    //if text is number search by id or else search by location
                    int num;
                    if (int.TryParse(text, out num)) {
                        KoutiaByIdCmd.Parameters["@Id"].Value = num;
                        dataReader = KoutiaByIdCmd.ExecuteReader();
                        koutiTable.Load(dataReader);
                        KoutiaByIdCmd.Dispose();
                    }
                    else {
                        foreach (String s in locationStrings) {
                            if (s.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) {
                                KoutiaByLocationCmd.Parameters["@Location"].Value = s;
                                dataReader = KoutiaByLocationCmd.ExecuteReader();
                                koutiTable.Load(dataReader);
                            }
                        }
                        KoutiaByLocationCmd.Dispose();
                    }
                }
                else {
                    dataReader = KoutiaCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    KoutiaCmd.Dispose();
                }
                dataReader.Close();
                dataGridView.DataSource = koutiTable;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 200;
                dataGridView.Columns[0].HeaderText = "Αριθμός";
                dataGridView.Columns[1].HeaderText = "Τοποθεσία";
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void showProionta(String text) {
            text = text.Trim();
            proionTable.Clear();
            try {
                con.Open();
                //if there is text search by text or else return everything
                if (text != "") {
                    String name = text.Trim();
                    foreach (String s in productStrings) {
                        if (s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {
                            ProiontaByNameCmd.Parameters["@Name"].Value = s;
                            dataReader = ProiontaByNameCmd.ExecuteReader();
                            proionTable.Load(dataReader);
                        }
                    }
                    ProiontaByNameCmd.Dispose();
                }
                else {
                    dataReader = ProiontaCmd.ExecuteReader();
                    proionTable.Load(dataReader);
                    ProiontaCmd.Dispose();
                }
                dataReader.Close();
                dataGridView.DataSource = proionTable;
                dataGridView.Columns[0].Width = 250;
                dataGridView.Columns[0].HeaderText = "Όνομα";
            }
            catch (SqlException sqlEx) {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void showSxeseis(String text) {
            text = text.Trim();
            sxesiTable.Clear();
            try {
                con.Open();
                //if there is text search by text or else return everything
                if (text != "") {
                    //if text is number search by id or else search by something else
                    int num;
                    if (int.TryParse(text, out num)) {
                        SxeseisByKoutiIdCmd.Parameters["@KoutiId"].Value = num;
                        dataReader = SxeseisByKoutiIdCmd.ExecuteReader();
                        sxesiTable.Load(dataReader);
                        SxeseisByKoutiIdCmd.Dispose();
                    }
                    else {
                        //first search by product name
                        foreach (String s in productStrings) {
                            if (s.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) {
                                SxeseisByProionNameCmd.Parameters["@ProionName"].Value = s;
                                dataReader = SxeseisByProionNameCmd.ExecuteReader();
                                sxesiTable.Load(dataReader);
                            }
                        }
                        SxeseisByProionNameCmd.Dispose();
                        //if no match is found try searching by location
                        if (sxesiTable.Rows.Count == 0) {
                            foreach (String s in locationStrings) {
                                if (s.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) {
                                    SxeseisByKoutiLocationCmd.Parameters["@KoutiLocation"].Value = s;
                                    dataReader = SxeseisByKoutiLocationCmd.ExecuteReader();
                                    sxesiTable.Load(dataReader);
                                }
                            }
                            SxeseisByKoutiLocationCmd.Dispose();
                        }
                    }
                }
                else {
                    dataReader = SxeseisCmd.ExecuteReader();
                    sxesiTable.Load(dataReader);
                    SxeseisCmd.Dispose();
                }
                dataReader.Close();
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
            finally {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void initStrings() {
            //Sql Connection String
            conString = Apothiki.Properties.Settings.Default.ApothikiConnectionString;

            //Koutia Cmd Strings
            koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
            koutiaByIdCmdString = "SELECT * FROM KOUTI WHERE (Id=@Id) ORDER BY Id";
            koutiaByLocationCmdString = "SELECT * FROM KOUTI WHERE (Location=@Location) ORDER BY Id";

            //Proionta Cmd Strings
            proiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
            proiontaByNameCmdString = "SELECT * FROM Proion WHERE (Name=@Name) ORDER BY Name";

            //Sxeseis Cmd Strings
            sxeseisCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";
            sxeseisByProionNameCmdString = "SELECT * FROM SXESI WHERE (ProionName=@ProionName) ORDER BY KoutiId";
            sxeseisByKoutiLocationCmdString = "SELECT * FROM SXESI WHERE (KoutiLocation=@KoutiLocation) ORDER BY KoutiId";
            sxeseisByKoutiIdCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";

            //Helper Cmd String for locationStrings list
            locationStringsCmdString = "SELECT COUNT(Id), Location FROM Kouti GROUP BY Location ORDER BY Location";
        }

        private void initCmds() {
            //Init SqlConnection
            con = new SqlConnection(conString);

            //Koutia Cmds
            KoutiaCmd = new SqlCommand(koutiaCmdString, con);

            KoutiaByIdCmd = new SqlCommand(koutiaByIdCmdString, con);
            KoutiaByIdCmd.Parameters.Add("@Id", SqlDbType.Int);

            KoutiaByLocationCmd = new SqlCommand(koutiaByLocationCmdString, con);
            KoutiaByLocationCmd.Parameters.Add("@Location", SqlDbType.NVarChar);

            //Proionta Cmds
            ProiontaCmd = new SqlCommand(proiontaCmdString, con);

            ProiontaByNameCmd = new SqlCommand(proiontaByNameCmdString, con);
            ProiontaByNameCmd.Parameters.Add("@Name", SqlDbType.NVarChar);

            //Sxeseis Cmds
            SxeseisCmd = new SqlCommand(sxeseisCmdString, con);

            SxeseisByKoutiIdCmd = new SqlCommand(sxeseisByKoutiIdCmdString, con);
            SxeseisByKoutiIdCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

            SxeseisByProionNameCmd = new SqlCommand(sxeseisByProionNameCmdString, con);
            SxeseisByProionNameCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            SxeseisByKoutiLocationCmd = new SqlCommand(sxeseisByKoutiLocationCmdString, con);
            SxeseisByKoutiLocationCmd.Parameters.Add("@KoutiLocation", SqlDbType.NVarChar);

            //Helper Cmd for locationStrings list
            locationStringsCmd = new SqlCommand(locationStringsCmdString, con);

            //Init tables
            koutiTable = new ApothikiDataSet.KoutiDataTable();
            proionTable = new ApothikiDataSet.ProionDataTable();
            sxesiTable = new ApothikiDataSet.SxesiDataTable();

            //Init Lists
            productStrings = new List<string>();
            locationStrings = new List<string>();
        }
    }
}