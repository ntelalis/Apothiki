using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Apothiki {

    public partial class MainForm : Form {

        NewDialog newDialog;
        DelDialog delDialog;
        SxesiDialog sxesidialog;
        ChangeDialog changeDialog;

        String conString;   //DB Connection String

        List<String> productStrings = new List<string>();
        List<String> koutiStrings = new List<string>();
        List<String> locationStrings = new List<string>();

        SqlConnection con;
        SqlDataReader dataReader;

        String KoutiaCmdString, KoutiaByIdCmdString, KoutiaByLocationCmdString,
               ProiontaCmdString, ProiontaByNameCmdString,
               SxeseisCmdString, SxeseisByKoutiIdCmdString, SxeseisByProionNameCmdString, SxeseisByKoutiLocationCmdString;

        SqlCommand KoutiaCmd, KoutiaByIdCmd, KoutiaByLocationCmd,
                   ProiontaCmd, ProiontaByNameCmd,
                   SxeseisCmd, SxeseisByKoutiIdCmd, SxeseisByProionNameCmd, SxeseisByKoutiLocationCmd,
                   locationStringsCmd;

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
            updateLocationStrings();
            showSxeseis_Click(null, null, "");

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

        private void radioSxeseis_CheckedChanged(object sender, EventArgs e) {
            showSxeseis_Click(null, null, searchSxeseisTextBox.Text);
        }

        private void radioKoutia_CheckedChanged(object sender, EventArgs e) {
            showKoutia_Click(null, null, searchSxeseisTextBox.Text);
        }

        private void radioProionta_CheckedChanged(object sender, EventArgs e) {
            showProionta_Click(null, null, searchSxeseisTextBox.Text);
        }

        private void newKouti_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Kouti, con);
            newDialog.ShowDialog(this);
            updateLocationStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void newProion_Click(object sender, EventArgs e) {
            newDialog = new NewDialog(NewDialogType.Proion, con);
            newDialog.ShowDialog(this);
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void changeKouti_Click(object sender, EventArgs e) {
            changeDialog = new ChangeDialog(ChangeDialogType.Kouti, con);
            changeDialog.ShowDialog(this);
            updateLocationStrings();
            searchSxeseisTextBox_TextChanged(null, null);
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
            updateLocationStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void delProion_Click(object sender, EventArgs e) {
            delDialog = new DelDialog(DelDialogType.Proion, con);
            delDialog.ShowDialog(this);
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void showKoutia_Click(object sender, EventArgs e, String text) {

            koutiTable.Clear();

            if (text != "") {
                int num;
                if (int.TryParse(text, out num)) {

                    try {
                        con.Open();
                        KoutiaByIdCmd.Parameters["@Id"].Value = num;
                        dataReader = KoutiaByIdCmd.ExecuteReader();
                        koutiTable.Load(dataReader);
                        dataReader.Close();
                        KoutiaByIdCmd.Dispose();
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
                else {
                    try {
                        con.Open();
                        foreach (String s in locationStrings) {
                            if (s.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0) {

                                KoutiaByLocationCmd.Parameters["@Location"].Value = s;
                                dataReader = KoutiaByLocationCmd.ExecuteReader();
                                koutiTable.Load(dataReader);
                            }
                        }
                        dataReader.Close();
                        KoutiaByIdCmd.Dispose();
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
            }
            else {
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
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }

            }
        }

        private void showProionta_Click(object sender, EventArgs e, String text) {
            proionTable.Clear();
            if (text != "") {
                try {
                    con.Open();
                    String name = text.Trim();
                    foreach (String s in productStrings) {
                        if (s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {

                            ProiontaByNameCmd.Parameters["@Name"].Value = s;
                            dataReader = ProiontaByNameCmd.ExecuteReader();
                            proionTable.Load(dataReader);
                        }
                    }
                    dataReader.Close();
                    ProiontaByNameCmd.Dispose();
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
            else {
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
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }

        }

        private void showSxeseis_Click(object sender, EventArgs e, String text) {
            sxesiTable.Clear();

            if (text != "") {
                int num;
                if (int.TryParse(text, out num)) {
                    try {
                        con.Open();
                        SxeseisByKoutiIdCmd.Parameters["@KoutiId"].Value = num;
                        dataReader = SxeseisByKoutiIdCmd.ExecuteReader();
                        sxesiTable.Load(dataReader);
                        dataReader.Close();
                        SxeseisByKoutiIdCmd.Dispose();
                        dataGridView.DataSource = sxesiTable;
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
                else {
                    try {
                        String name = text;
                        name = name.Trim();
                        con.Open();
                        foreach (String s in productStrings) {
                            if (s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {

                                SxeseisByProionNameCmd.Parameters["@ProionName"].Value = s;
                                dataReader = SxeseisByProionNameCmd.ExecuteReader();
                                sxesiTable.Load(dataReader);
                            }
                        }

                        dataReader.Close();
                        SxeseisByProionNameCmd.Dispose();
                        if (sxesiTable.Rows.Count == 0) {
                            foreach (String s in locationStrings) {
                                if (s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) {

                                    SxeseisByKoutiLocationCmd.Parameters["@KoutiLocation"].Value = s;
                                    dataReader = SxeseisByKoutiLocationCmd.ExecuteReader();
                                    sxesiTable.Load(dataReader);
                                }
                            }
                        }
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
            }
            else {
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
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
        }

        private void searchSxeseisTextBox_TextChanged(object sender, EventArgs e) {

            if (radioKoutia.Checked == true) {
                showKoutia_Click(null, null, searchSxeseisTextBox.Text);
            }
            else if (radioProionta.Checked == true) {
                showProionta_Click(null, null, searchSxeseisTextBox.Text);
            }
            else {
                showSxeseis_Click(null, null, searchSxeseisTextBox.Text);
            }


        }
        public void updateDataGridViewByKouti() {
            radioKoutia.Checked = true;
            updateLocationStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        public void updateDataGridViewByProion() {
            radioProionta.Checked = true;
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        public void updateDataGridView() {
            radioSxeseis.Checked = true;
            updateProductStrings();
            searchSxeseisTextBox_TextChanged(null, null);
        }

        private void updateLocationStrings() {
            locationStrings = new List<string>();
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
            KoutiaByIdCmdString = "SELECT * FROM KOUTI WHERE (Id=@Id) ORDER BY Id";
            KoutiaByLocationCmdString = "SELECT * FROM KOUTI WHERE (Location=@Location) ORDER BY Id";

            ProiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
            ProiontaByNameCmdString = "SELECT * FROM Proion WHERE (Name=@Name) ORDER BY Name";

            SxeseisCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";
            SxeseisByProionNameCmdString = "SELECT * FROM SXESI WHERE (ProionName=@ProionName) ORDER BY KoutiId";
            SxeseisByKoutiLocationCmdString = "SELECT * FROM SXESI WHERE (KoutiLocation=@KoutiLocation) ORDER BY KoutiId";
            SxeseisByKoutiIdCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId) ORDER BY KoutiId";
        }

        private void initCmds() {
            //Koutia
            KoutiaCmd = new SqlCommand(KoutiaCmdString, con);

            KoutiaByIdCmd = new SqlCommand(KoutiaByIdCmdString, con);
            KoutiaByIdCmd.Parameters.Add("@Id", SqlDbType.Int);

            KoutiaByLocationCmd = new SqlCommand(KoutiaByLocationCmdString, con);
            KoutiaByLocationCmd.Parameters.Add("@Location", SqlDbType.NVarChar);

            //Proionta
            ProiontaCmd = new SqlCommand(ProiontaCmdString, con);

            ProiontaByNameCmd = new SqlCommand(ProiontaByNameCmdString, con);
            ProiontaByNameCmd.Parameters.Add("@Name", SqlDbType.NVarChar);

            //Sxeseis
            SxeseisCmd = new SqlCommand(SxeseisCmdString, con);

            SxeseisByKoutiIdCmd = new SqlCommand(SxeseisByKoutiIdCmdString, con);
            SxeseisByKoutiIdCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

            SxeseisByProionNameCmd = new SqlCommand(SxeseisByProionNameCmdString, con);
            SxeseisByProionNameCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            SxeseisByKoutiLocationCmd = new SqlCommand(SxeseisByKoutiLocationCmdString, con);
            SxeseisByKoutiLocationCmd.Parameters.Add("@KoutiLocation", SqlDbType.NVarChar);

            // Helper for locationstrings
            locationStringsCmd = new SqlCommand("SELECT COUNT(Id), Location FROM Kouti GROUP BY Location ORDER BY Location", con);

            koutiTable = new ApothikiDataSet.KoutiDataTable();
            proionTable = new ApothikiDataSet.ProionDataTable();
            sxesiTable = new ApothikiDataSet.SxesiDataTable();
        }
    }
}
