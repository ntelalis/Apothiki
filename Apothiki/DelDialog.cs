using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Apothiki {

    public enum DelDialogType {
        Kouti, Proion
    }

    public partial class DelDialog : Form {

        SQLiteConnection con;
        DelDialogType delDialogType;

        String delKoutiCmdString, delProionCmdString,
               koutiaCmdString, proiontaCmdString;
        SQLiteCommand delKoutiCmd, delProionCmd,
                   koutiaCmd, proiontaCmd;

        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        SQLiteDataReader dataReader;

        public DelDialog(DelDialogType delDialogType, SQLiteConnection con) {
            InitializeComponent();
            this.delDialogType = delDialogType;
            this.con = con;

            if (delDialogType == DelDialogType.Kouti) {
                this.Text = "Διαγραφή κουτιού";
                this.labelKoutiOrProion.Text = "Αριθμός Κουτιού";

                delKoutiCmdString = "DELETE FROM KOUTI WHERE (Id=@Id)";
                delKoutiCmd = new SQLiteCommand(delKoutiCmdString, con);
                delKoutiCmd.Parameters.AddWithValue("@Id", "DEFAULT");

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SQLiteCommand(koutiaCmdString, con);
                koutiTable = new ApothikiDataSet.KoutiDataTable();
            }
            else if (delDialogType == DelDialogType.Proion) {
                this.Text = "Διαγραφή προϊόντος";
                this.labelKoutiOrProion.Text = "Όνομα προϊόντος";
                this.comboBoxKoutiOrProion.Size = new System.Drawing.Size(224, 21);

                delProionCmdString = "DELETE FROM PROION WHERE (Name=@Name)";
                delProionCmd = new SQLiteCommand(delProionCmdString, con);
                delProionCmd.Parameters.AddWithValue("@Name", "DEFAULT");

                proiontaCmdString = "SELECT * FROM PROION ORDER BY Name";
                proiontaCmd = new SQLiteCommand(proiontaCmdString, con);
                proionTable = new ApothikiDataSet.ProionDataTable();
            }
            fillComboBoxKoutiOrProion();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (delDialogType == DelDialogType.Kouti) {
                try {
                    int id = Int32.Parse(comboBoxKoutiOrProion.Text);
                    delKoutiCmd.Parameters["@Id"].Value = id;
                    DialogResult result = MessageBox.Show("Είστε βέβαιοι ότι θέλετε να διαγράψετε το κουτί " + comboBoxKoutiOrProion.Text + ";", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result.Equals(DialogResult.Yes)) {
                        try {
                            con.Open();
                            int rowsAffected = delKoutiCmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                                MessageBox.Show("Το κουτί " + id + " διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Το κουτί " + id + " δε βρέθηκε στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        catch (SQLiteException sqlEx) {
                            MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            else if (delDialogType == DelDialogType.Proion) {
                DialogResult result = MessageBox.Show("Είστε βέβαιοι ότι θέλετε να διαγράψετε το προϊόν \"" + comboBoxKoutiOrProion.Text + "\";", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result.Equals(DialogResult.Yes)) {
                    String name = comboBoxKoutiOrProion.Text;
                    delProionCmd.Parameters["@Name"].Value = name;
                    try {
                        con.Open();
                        int rowsAffected = delProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Το προϊόν \"" + name + "\" διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Το προϊόν \"" + name + "\" δε βρέθηκε στη βάση", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (SQLiteException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            fillComboBoxKoutiOrProion();
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }

        private void fillComboBoxKoutiOrProion() {
            if (delDialogType == DelDialogType.Kouti) {
                koutiTable.Clear();
                try {
                    con.Open();
                    dataReader = koutiaCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    dataReader.Close();
                    //koutiaCmd.Dispose();

                    comboBoxKoutiOrProion.DataSource = koutiTable;
                    comboBoxKoutiOrProion.DisplayMember = "Id";
                    comboBoxKoutiOrProion.BindingContext = this.BindingContext;
                    comboBoxKoutiOrProion.SelectedIndex = -1;
                }
                catch (SQLiteException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //proiontaCmd.Dispose();

                    comboBoxKoutiOrProion.DataSource = proionTable;
                    comboBoxKoutiOrProion.DisplayMember = "Name";
                    comboBoxKoutiOrProion.BindingContext = this.BindingContext;
                    comboBoxKoutiOrProion.SelectedIndex = -1;
                }
                catch (SQLiteException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
        }

        private void comboBoxKoutiOrProion_TextUpdate(object sender, EventArgs e) {
            if (comboBoxKoutiOrProion.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
        }

        private void comboBoxKoutiOrProion_SelectedIndexChanged(object sender, EventArgs e) {
            comboBoxKoutiOrProion_TextUpdate(null, null);
        }
    }
}