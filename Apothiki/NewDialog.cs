using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Apothiki {

    public enum NewDialogType {
        Kouti, Proion
    }

    public partial class NewDialog : Form {

        SQLiteConnection con;
        NewDialogType newDialogType;

        String newKoutiCmdString, newProionCmdString;
        SQLiteCommand newKoutiCmd, newProionCmd;

        public NewDialog(NewDialogType newDialogType, SQLiteConnection con) {
            InitializeComponent();
            this.newDialogType = newDialogType;
            this.con = con;

            if (newDialogType == NewDialogType.Kouti) {
                this.Text = "Νέο Κουτί";
                this.labelProionOrLoc.Text = "Τοποθεσία(Προαιρετικό)";
                this.labelKouti.Visible = true;
                this.textBoxKouti.Visible = true;
                this.ActiveControl = textBoxKouti;

                newKoutiCmdString = "INSERT INTO KOUTI (Id,Location) VALUES (@Id,@Location)";
                newKoutiCmd = new SQLiteCommand(newKoutiCmdString, con);
                newKoutiCmd.Parameters.AddWithValue("@Id", "DEFAULT");
                newKoutiCmd.Parameters.AddWithValue("@Location", "DEFAULT");
            }
            else if (newDialogType == NewDialogType.Proion) {
                this.Text = "Νέο Προϊόν";
                this.labelProionOrLoc.Text = "Όνομα προϊόντος";
                this.textBoxProionOrLoc.Size = new System.Drawing.Size(224, 21);
                this.ActiveControl = textBoxProionOrLoc;

                newProionCmdString = "INSERT INTO PROION (Name) VALUES (@Name)";
                newProionCmd = new SQLiteCommand(newProionCmdString, con);
                newProionCmd.Parameters.AddWithValue("@Name", "DEFAULT");
            }
            toggleOKButton();
        }

        private void textBoxKouti_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void textBoxProionOrLoc_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (newDialogType == NewDialogType.Kouti) {
                if (textBoxKouti.Text == "")
                    OKButton.Enabled = false;
                else
                    OKButton.Enabled = true;
            }
            else {
                if (textBoxProionOrLoc.Text == "")
                    OKButton.Enabled = false;
                else
                    OKButton.Enabled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (this.newDialogType == NewDialogType.Kouti)
                newKouti();
            else
                newProion();
        }

        private void newKouti() {
            try {
                int id = Convert.ToInt32(this.textBoxKouti.Text.Trim());
                string location = this.textBoxProionOrLoc.Text.Trim();
                newKoutiCmd.Parameters["@Id"].Value = id;
                newKoutiCmd.Parameters["@Location"].Value = location;
                try {
                    con.Open();
                    int rowsAffected = newKoutiCmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected == 1) {
                        MessageBox.Show("Το κουτί " + id + " με τοποθεσία \"" + location + "\" δημιουργήθηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((MainForm)this.Owner).updateDataGridViewByKoutia();

                    }
                    else
                        MessageBox.Show("Η εισαγωγή δεν ήταν επιτυχής. Παρακαλώ επικοινωνήστε με το διαχειριστή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SQLiteException sqlEx) {
                    if (sqlEx.ErrorCode == 19)
                        MessageBox.Show("Το κουτί " + id + " υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException aa) {
                MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException) {
                MessageBox.Show("Ο αριθμός που πληκτρολογήσατε είναι πολύ μεγάλος", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            this.textBoxKouti.Text = "";
            this.textBoxProionOrLoc.Text = "";
            this.ActiveControl = textBoxKouti;
        }

        private void newProion() {
            String name = this.textBoxProionOrLoc.Text.Trim();
            if (name != "") {
                newProionCmd.Parameters["@Name"].Value = name;
                try {
                    con.Open();
                    int rowsAffected = newProionCmd.ExecuteNonQuery();
                    con.Close();
                    if (rowsAffected == 1) {
                        MessageBox.Show("Το προϊόν \"" + name + "\" δημιουργήθηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((MainForm)this.Owner).updateDataGridViewByProionta();
                    }
                    else
                        MessageBox.Show("Η εισαγωγή δεν ήταν επιτυχής. Παρακαλώ επικοινωνήστε με το διαχειριστή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SQLiteException sqlEx) {

                    if (sqlEx.ErrorCode == 19)
                        MessageBox.Show("To προϊόν \"" + name + "\" υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                this.textBoxProionOrLoc.Text = "";
                this.ActiveControl = textBoxProionOrLoc;
            }
            else
                MessageBox.Show("Παρακαλώ εισάγετε τιμή στο πεδίο Όνομα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}