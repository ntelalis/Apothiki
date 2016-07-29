using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum DelDialogType {
        Kouti, Proion
    }

    public partial class DelDialog : Form {

        SqlConnection con;
        DelDialogType delDialogType;

        String delKoutiCmdString, delProionCmdString;
        String koutiaCmdString, proiontaCmdString;
        SqlCommand delKoutiCmd, delProionCmd;
        SqlCommand koutiaCmd, proiontaCmd;

        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        SqlDataReader dataReader;

        public DelDialog(DelDialogType delDialogType, SqlConnection con) {
            InitializeComponent();
            this.delDialogType = delDialogType;
            this.con = con;

            if (delDialogType == DelDialogType.Kouti) {
                this.Text = "Διαγραφή κουτιού";
                this.label1.Text = "Αριθμός Κουτιού";
                this.comboBox1.Size = new System.Drawing.Size(64, 21);

                delKoutiCmdString = "DELETE FROM KOUTI WHERE (Id=@Id)";
                delKoutiCmd = new SqlCommand(delKoutiCmdString, con);
                delKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);
                koutiTable = new ApothikiDataSet.KoutiDataTable();
            }
            else if (delDialogType == DelDialogType.Proion) {
                this.Text = "Διαγραφή προϊόντος";
                this.label1.Text = "Όνομα προϊόντος";
                this.comboBox1.Size = new System.Drawing.Size(224, 21);

                delProionCmdString = "DELETE FROM PROION WHERE (Name=@Name)";
                delProionCmd = new SqlCommand(delProionCmdString, con);
                delProionCmd.Parameters.Add("@Name", SqlDbType.NVarChar);

                proiontaCmdString = "SELECT * FROM PROION ORDER BY Name";
                proiontaCmd = new SqlCommand(proiontaCmdString, con);
                proionTable = new ApothikiDataSet.ProionDataTable();
            }
            fillComboBox();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (delDialogType == DelDialogType.Kouti) {
                DialogResult result = MessageBox.Show("Είστε βέβαιοι ότι θέλετε να διαγράψετε το κουτί " + comboBox1.Text + ";", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result.Equals(DialogResult.Yes)) {
                    try {
                        int id = Int32.Parse(comboBox1.Text);
                        delKoutiCmd.Parameters["@Id"].Value = id;
                        try {
                            con.Open();
                            int rowsAffected = delKoutiCmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                                MessageBox.Show("Το κουτί " + id + " διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Το κουτί " + id + " δε βρέθηκε στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (SqlException sqlEx) {
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException) {
                        MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            else if (delDialogType == DelDialogType.Proion) {
                DialogResult result = MessageBox.Show("Είστε βέβαιοι ότι θέλετε να διαγράψετε το προϊόν \"" + comboBox1.Text + "\";", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result.Equals(DialogResult.Yes)) {
                    String name = comboBox1.Text;
                    delProionCmd.Parameters["@Name"].Value = name;
                    try {
                        con.Open();
                        int rowsAffected = delProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Το προϊόν \"" + name + "\" διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Το προϊόν \"" + name + "\" δε βρέθηκε στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            fillComboBox();
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }

        private void fillComboBox() {
            if (delDialogType == DelDialogType.Kouti) {
                koutiTable.Clear();
                try {
                    con.Open();
                    dataReader = koutiaCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    dataReader.Close();
                    koutiaCmd.Dispose();

                    comboBox1.DataSource = koutiTable;
                    comboBox1.DisplayMember = "Id";
                    comboBox1.BindingContext = this.BindingContext;
                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            else if (delDialogType == DelDialogType.Proion) {
                proionTable.Clear();
                try {
                    con.Open();
                    dataReader = proiontaCmd.ExecuteReader();
                    proionTable.Load(dataReader);
                    dataReader.Close();
                    proiontaCmd.Dispose();

                    comboBox1.DataSource = proionTable;
                    comboBox1.DisplayMember = "Name";
                    comboBox1.BindingContext = this.BindingContext;
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

        private void comboBox1_TextUpdate(object sender, EventArgs e) {
            if (comboBox1.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            comboBox1_TextUpdate(null, null);
        }
    }
}