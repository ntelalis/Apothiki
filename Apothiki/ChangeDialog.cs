using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum ChangeDialogType {
        Kouti, Proion
    }

    public partial class ChangeDialog : Form {

        SqlConnection con;
        ChangeDialogType changeDialogType;

        String changeKoutiString, changeProionCmdString,
               koutiaCmdString, proiontaCmdString,
               koutiByIdString;
        SqlCommand changeKouti, changeProionCmd,
                   koutiaCmd, proiontaCmd,
                   koutiById;

        ApothikiDataSet.KoutiDataTable koutiTable1, koutiTable2;
        ApothikiDataSet.ProionDataTable proionTable;
        SqlDataReader dataReader;

        public ChangeDialog(ChangeDialogType changeDialogType, SqlConnection con) {
            InitializeComponent();
            this.changeDialogType = changeDialogType;
            this.con = con;

            if (changeDialogType == ChangeDialogType.Kouti) {
                this.Text = "Αλλαγή Κουτιού";
                this.label1.Text = "Αριθμός Κουτιού";
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.textBox1.Visible = true;
                this.textBox3.Visible = true;

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);

                koutiByIdString = "SELECT * FROM KOUTI WHERE (Id=@Id)";
                koutiById = new SqlCommand(koutiByIdString, con);
                koutiById.Parameters.Add("@Id", SqlDbType.Int);

                changeKoutiString = "UPDATE KOUTI SET Id=@NewId, Location=@NewLocation WHERE (Id=@OldId)";
                changeKouti = new SqlCommand(changeKoutiString, con);
                changeKouti.Parameters.Add("@NewLocation", SqlDbType.NVarChar);
                changeKouti.Parameters.Add("@OldId", SqlDbType.Int);
                changeKouti.Parameters.Add("@NewId", SqlDbType.Int);

                koutiTable1 = new ApothikiDataSet.KoutiDataTable();
                koutiTable2 = new ApothikiDataSet.KoutiDataTable();
            }
            else if (changeDialogType == ChangeDialogType.Proion) {
                this.Text = "Αλλαγή Προϊόντος";
                this.label1.Text = "Παλιά τιμή";
                this.comboBox1.Size = new System.Drawing.Size(224, 21);
                this.textBox2.Size = new System.Drawing.Size(224, 20);

                proiontaCmdString = "SELECT * FROM PROION ORDER BY Name";
                proiontaCmd = new SqlCommand(proiontaCmdString, con);

                changeProionCmdString = "UPDATE PROION SET Name=@NewName WHERE (Name=@OldName)";
                changeProionCmd = new SqlCommand(changeProionCmdString, con);
                changeProionCmd.Parameters.Add("@NewName", SqlDbType.NVarChar);
                changeProionCmd.Parameters.Add("@OldName", SqlDbType.NVarChar);

                proionTable = new ApothikiDataSet.ProionDataTable();
            }
            fillCombobox();
        }

        private void ChangeDialog_Load(object sender, EventArgs e) {
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e) {
            toggleOKButton();
            if (comboBox1.Text == "") {
                textBox2.Text = "";
                if(changeDialogType == ChangeDialogType.Kouti) {
                    textBox1.Text = "";
                    textBox3.Text = "";
                }
            }
                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            updateOldValue();
            toggleOKButton();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (comboBox1.Text == "" || textBox2.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
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
                    comboBox1.SelectedIndex = -1;
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
                    comboBox1.SelectedIndex = -1;
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

        private void updateOldValue() {
            if (comboBox1.Text != "") {
                if (changeDialogType == ChangeDialogType.Kouti) {
                    textBox2.Text = comboBox1.Text;

                    int id = Int32.Parse(comboBox1.Text);
                    koutiById.Parameters["@Id"].Value = id;
                    koutiTable2.Clear();
                    try {
                        con.Open();
                        dataReader = koutiById.ExecuteReader();
                        koutiTable2.Load(dataReader);
                        dataReader.Close();
                        koutiById.Dispose();

                        if (koutiTable2.Rows.Count == 1)
                            textBox1.Text = koutiTable2.Rows[0]["Location"].ToString();
                        else
                            textBox1.Text = "";

                        textBox3.Text = textBox1.Text;
                    }
                    catch (SqlException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
                else if (changeDialogType == ChangeDialogType.Proion)
                    textBox2.Text = comboBox1.Text;
            }
            else
                textBox2.Text = "";
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (changeDialogType == ChangeDialogType.Kouti) {
                try {
                    int newid = Int32.Parse(textBox2.Text.Trim());
                    int oldid = Int32.Parse(comboBox1.Text.Trim());
                    String newLocation = textBox3.Text.Trim();
                    changeKouti.Parameters["@NewId"].Value = newid;
                    changeKouti.Parameters["@OldId"].Value = oldid;
                    changeKouti.Parameters["@NewLocation"].Value = newLocation;

                    if (newid != oldid || newLocation != textBox1.Text) {
                        try {
                            con.Open();
                            int rowsAffected = changeKouti.ExecuteNonQuery();
                            //trigger on table Kouti affects multiple rows
                            if (!(rowsAffected == 0)) {
                                if (oldid == newid)
                                    MessageBox.Show("Η τοποθεσία του κουτιού " + oldid + " άλλαξε σε \"" + newLocation + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (newLocation == textBox1.Text)
                                    MessageBox.Show("Το κουτί " + oldid + " άλλαξε σε κουτί " + newid, "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Το κουτί " + oldid + " άλλαξε σε κουτί " + newid + " με καινούρια τοποθεσία \"" + newLocation + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Η αλλαγή δεν ήταν επιτυχής. Βεβαιωθείτε ότι τα δεδομενα είναι σωστά.", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (SqlException sqlEx) {
                            if (sqlEx.Number == 2627)
                                MessageBox.Show("Το κουτί " + newid + " υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally {
                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }

                        fillCombobox();
                        updateOldValue();
                        toggleOKButton();
                    }
                    else
                        MessageBox.Show("Δεν πραγματοποιήθηκε καμία αλλαγή", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException) {
                    MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" και \"Νέα τιμή\" δέχονται μόνον ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException) {
                    MessageBox.Show("Ο αριθμός που πληκτρολογήσατε είναι πολύ μεγάλος", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (changeDialogType == ChangeDialogType.Proion) {
                String oldValue = comboBox1.Text.Trim();
                String newValue = textBox2.Text.Trim();

                if (oldValue != newValue) {
                    changeProionCmd.Parameters["@NewName"].Value = newValue;
                    changeProionCmd.Parameters["@OldName"].Value = oldValue;

                    try {
                        con.Open();
                        int rowsAffected = changeProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Το προϊόν \"" + oldValue + "\" άλλαξε σε \"" + newValue + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Η αλλαγή δεν ήταν επιτυχής. Βεβαιωθείτε ότι τα δεδομενα είναι σωστά.", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (SqlException sqlEx) {
                        if (sqlEx.Number == 2627)
                            MessageBox.Show("Το προϊόν \"" + newValue + "\" υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }

                    fillCombobox();
                    updateOldValue();
                    toggleOKButton();
                }
                else
                    MessageBox.Show("Δεν πραγματοποιήθηκε καμία αλλαγή", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }
    }
}