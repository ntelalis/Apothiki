using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum ChangeDialogType {
        Kouti, Proion
    }
    public partial class ChangeDialog : Form {

        String proiontaCmdString, changeProionCmdString, koutiaCmdString, changeKoutiString, koutiByIdString;

        SqlConnection con;
        SqlCommand proiontaCmd, changeProionCmd, koutiaCmd, changeKouti, koutiById;
        SqlDataReader dataReader;

        private void ChangeDialog_Load(object sender, EventArgs e) {
            comboBox1_SelectedIndexChanged(null, null);
        }

        ApothikiDataSet.ProionDataTable proionTable;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (changeDialogType == ChangeDialogType.Kouti) {
                updateOldValue();
            }
        }

        ApothikiDataSet.KoutiDataTable koutiTable1, koutiTable2;
        ChangeDialogType changeDialogType;
        public ChangeDialog(ChangeDialogType changeDialogType, SqlConnection con) {
            InitializeComponent();
            this.con = con;
            this.changeDialogType = changeDialogType;
            if (changeDialogType == ChangeDialogType.Kouti) {

                this.comboBox1.Size = new System.Drawing.Size(64, 21);
                this.textBox2.Location = new System.Drawing.Point(160, 86);
                this.textBox2.Size = new System.Drawing.Size(179, 20);
                this.label2.Location = new System.Drawing.Point(157, 66);
                label3.Visible = true;
                textBox1.Visible = true;
                this.Text = "Αλλαγή Κουτιού";
                this.label1.Text = "Κουτί";
                this.label2.Text = "Νέα τοποθεσία";

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);

                koutiByIdString = "SELECT * FROM KOUTI WHERE (Id=@Id)";
                koutiById = new SqlCommand(koutiByIdString, con);
                koutiById.Parameters.Add("@Id", SqlDbType.Int);

                changeKoutiString = "UPDATE KOUTI SET Location=@NewLocation WHERE (Id=@Id)";
                changeKouti = new SqlCommand(changeKoutiString, con);
                changeKouti.Parameters.Add("@NewLocation", SqlDbType.NVarChar);
                changeKouti.Parameters.Add("@Id", SqlDbType.Int);

                koutiTable1 = new ApothikiDataSet.KoutiDataTable();
                koutiTable2 = new ApothikiDataSet.KoutiDataTable();
                fillCombobox();

            }
            else if (changeDialogType == ChangeDialogType.Proion) {
                this.Text = "Αλλαγή Προϊόντος";
                this.label1.Text = "Παλιά τιμή";
                this.label2.Text = "Νέα τιμή";

                proiontaCmdString = "SELECT * FROM PROION ORDER BY Name";
                proiontaCmd = new SqlCommand(proiontaCmdString, con);
                proionTable = new ApothikiDataSet.ProionDataTable();

                changeProionCmdString = "UPDATE PROION SET Name=@NewName WHERE (Name=@OldName)";
                changeProionCmd = new SqlCommand(changeProionCmdString, con);
                changeProionCmd.Parameters.Add("@NewName", SqlDbType.NVarChar);
                changeProionCmd.Parameters.Add("@OldName", SqlDbType.NVarChar);
                fillCombobox();
            }
        }
        private void fillCombobox() {
            if (changeDialogType == ChangeDialogType.Kouti) {
                koutiTable1.Clear();
                try {
                    con.Open();
                    dataReader = koutiaCmd.ExecuteReader();
                    koutiTable1.Load(dataReader);
                    dataReader.Close();
                    koutiaCmd.Dispose();

                    comboBox1.DataSource = koutiTable1;
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
            else if (changeDialogType == ChangeDialogType.Proion) {
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
                    con.Close();

                }
                catch (SqlException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }
            }
            if (comboBox1.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
        }

        private void updateOldValue() {
            if (comboBox1.Text != "") {
                koutiTable2.Clear();
                int id = Int32.Parse(comboBox1.Text);
                koutiById.Parameters["@Id"].Value = id;
                try {
                    con.Open();
                    dataReader = koutiById.ExecuteReader();
                    koutiTable2.Load(dataReader);
                    dataReader.Close();
                    koutiById.Dispose();
                    if (koutiTable2.Rows.Count == 1) {
                        textBox1.Text = koutiTable2.Rows[0]["Location"].ToString();
                    }
                    else {
                        textBox1.Text = "";
                    }
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

        private void OKButton_Click(object sender, EventArgs e) {
            if (changeDialogType == ChangeDialogType.Kouti) {

                String newLocation = textBox2.Text;
                int id = Int32.Parse(comboBox1.Text);

                changeKouti.Parameters["@Id"].Value = id;
                changeKouti.Parameters["@NewLocation"].Value = newLocation;

                try {
                    con.Open();
                    int rowsAffected = changeKouti.ExecuteNonQuery();
                    MessageBox.Show("Η τοποθεσία του κουτιού " + id + " άλλαξε σε \"" + newLocation + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEx) {
                    if (sqlEx.Number == 2627) {
                        MessageBox.Show("Το κουτί " + id + " υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally {
                    if (con.State != ConnectionState.Closed) {
                        con.Close();
                    }
                }
                updateOldValue();
            }
            else if (changeDialogType == ChangeDialogType.Proion) {
                String oldValue = comboBox1.Text;
                String newValue = textBox2.Text;
                newValue = newValue.Trim();
                if (newValue != "") {
                    changeProionCmd.Parameters["@NewName"].Value = newValue;
                    changeProionCmd.Parameters["@OldName"].Value = oldValue;

                    try {
                        con.Open();
                        int rowsAffected = changeProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1) {
                            MessageBox.Show("Το προϊόν \"" + oldValue + "\" άλλαξε σε \"" + newValue + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            MessageBox.Show("Η εισαγωγή δεν ήταν επιτυχής. Παρακαλώ επικοινωνήστε με το διαχειριστή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx) {
                        if (sqlEx.Number == 2627) {
                            MessageBox.Show("Το κουτί " + newValue + " υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else {
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally {
                        if (con.State != ConnectionState.Closed) {
                            con.Close();
                        }
                    }
                    fillCombobox();
                    textBox2.Text = "";
                }
                else {
                    MessageBox.Show("Δεν επιτρέπεται κενή τιμή", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ((MainForm)this.Owner).updateDataGridView();
        }
    }
}
