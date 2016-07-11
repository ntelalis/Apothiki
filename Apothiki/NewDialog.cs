using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum NewDialogType {
        Kouti, Proion
    }

    public partial class NewDialog : Form {

        String newKoutiCmdString, newProionCmdString;
        SqlCommand newKoutiCmd, newProionCmd;
        SqlConnection con;

        public NewDialog(NewDialogType newDialogType, SqlConnection con) {

            InitializeComponent();
            this.con = con;

            if (newDialogType == NewDialogType.Kouti) {

                this.Text = "Νέο Κουτί";
                this.label1.Text = "Αριθμός κουτιού";
                this.label2.Text = "Τοποθεσία (Προαιρετικό)";
                this.label2.Visible = true;
                textBox2.Visible = true;

                this.ActiveControl = textBox1;

                newKoutiCmdString = "INSERT INTO KOUTI (Id,Location) VALUES (@Id,@Location)";
                newKoutiCmd = new SqlCommand(newKoutiCmdString, con);
                newKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);
                newKoutiCmd.Parameters.Add("@Location", SqlDbType.NVarChar);
            }
            else if (newDialogType == NewDialogType.Proion) {

                this.Text = "Νέο Προϊόν";
                this.label1.Text = "Όνομα προϊόντος";

                this.ActiveControl = textBox1;

                newProionCmdString = "INSERT INTO PROION (Name) VALUES (@Name)";
                newProionCmd = new SqlCommand(newProionCmdString, con);
                newProionCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            }
        }

        private void newKouti() {
            int id = -1;
            string location = null;
            try {
                id = Int32.Parse(this.textBox1.Text);
                location = this.textBox2.Text;
                location = location.Trim();
                newKoutiCmd.Parameters["@Id"].Value = id;
                newKoutiCmd.Parameters["@Location"].Value = location;
                try {
                    con.Open();
                    int rowsAffected = newKoutiCmd.ExecuteNonQuery();
                    if (rowsAffected == 1) {
                        MessageBox.Show("Η εισαγωγή του κουτιού " + id + " με τοποθεσία \"" + location + "\" ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("Η εισαγωγή δεν ήταν επιτυχής. Παρακαλώ επικοινωνήστε με το διαχειριστή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException sqlEx) {
                    if (sqlEx.Number == 2627) {
                        MessageBox.Show("Το κουτί " + id + " υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException) {
                MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (con.State != ConnectionState.Closed) {
                    con.Close();
                }
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.ActiveControl = textBox1;
            }
        }

        private void newProion() {

            String name = this.textBox1.Text.Trim();
            if (name != "") {
                newProionCmd.Parameters["@Name"].Value = name;
                try {
                    con.Open();
                    int rowsAffected = newProionCmd.ExecuteNonQuery();
                    if (rowsAffected == 1) {
                        MessageBox.Show("Η εισαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (SqlException sqlEx) {

                    if (sqlEx.Number == 2627) {
                        MessageBox.Show("To Προϊόν υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally {
                    if (con.State != ConnectionState.Closed) {
                        con.Close();
                    }
                    this.textBox1.Text = "";
                    this.ActiveControl = textBox1;
                }
            }
            else {
                MessageBox.Show("Παρακαλώ εισάγετε τιμή στο πεδίο Όνομα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {

            if (this.label2.Visible == true) {
                newKouti();
            }
            else {
                newProion();
            }
        }
    }
}
