using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum NewDialogType {
        Kouti, Proion
    }

    public partial class NewDialog : Form {

        SqlConnection con;
        NewDialogType newDialogType;

        String newKoutiCmdString, newProionCmdString;
        SqlCommand newKoutiCmd, newProionCmd;

        public NewDialog(NewDialogType newDialogType, SqlConnection con) {
            InitializeComponent();
            this.newDialogType = newDialogType;
            this.con = con;

            if (newDialogType == NewDialogType.Kouti) {
                this.Text = "Νέο Κουτί";
                this.label1.Text = "Αριθμός κουτιού";
                this.label2.Text = "Τοποθεσία (Προαιρετικό)";
                this.label1.Visible = true;
                this.textBox1.Visible = true;
                this.ActiveControl = textBox1;

                newKoutiCmdString = "INSERT INTO KOUTI (Id,Location) VALUES (@Id,@Location)";
                newKoutiCmd = new SqlCommand(newKoutiCmdString, con);
                newKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);
                newKoutiCmd.Parameters.Add("@Location", SqlDbType.NVarChar);
            }
            else if (newDialogType == NewDialogType.Proion) {
                this.Text = "Νέο Προϊόν";
                this.label2.Text = "Όνομα προϊόντος";
                this.textBox2.Size = new System.Drawing.Size(224, 21);
                this.ActiveControl = textBox2;

                newProionCmdString = "INSERT INTO PROION (Name) VALUES (@Name)";
                newProionCmd = new SqlCommand(newProionCmdString, con);
                newProionCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            }
            toggleOKButton();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (newDialogType == NewDialogType.Kouti) {
                if (textBox1.Text == "")
                    OKButton.Enabled = false;
                else
                    OKButton.Enabled = true;
            }
            else {
                if (textBox2.Text == "")
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
                int id = Int32.Parse(this.textBox1.Text.Trim());
                string location = this.textBox2.Text.Trim();
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
                catch (SqlException sqlEx) {
                    if (sqlEx.Number == 2627)
                        MessageBox.Show("Το κουτί " + id + " υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.ActiveControl = textBox1;
        }

        private void newProion() {
            String name = this.textBox2.Text.Trim();
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
                catch (SqlException sqlEx) {

                    if (sqlEx.Number == 2627)
                        MessageBox.Show("To προϊόν \"" + name + "\" υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
                this.textBox2.Text = "";
                this.ActiveControl = textBox2;
            }
            else
                MessageBox.Show("Παρακαλώ εισάγετε τιμή στο πεδίο Όνομα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}