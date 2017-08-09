using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Apothiki {

    public enum ChangeDialogType {
        Kouti, Proion
    }

    public partial class ChangeDialog : Form {

        SQLiteConnection con;
        ChangeDialogType changeDialogType;

        String changeKoutiString, changeProionCmdString,
               koutiaCmdString, proiontaCmdString,
               koutiByIdString;
        SQLiteCommand changeKouti, changeProionCmd,
                   koutiaCmd, proiontaCmd,
                   koutiById;

        ApothikiDataSet.KoutiDataTable koutiTable1, koutiTable2;
        ApothikiDataSet.ProionDataTable proionTable;
        SQLiteDataReader dataReader;

        public ChangeDialog(ChangeDialogType changeDialogType, SQLiteConnection con) {
            InitializeComponent();
            this.changeDialogType = changeDialogType;
            this.con = con;

            if (changeDialogType == ChangeDialogType.Kouti) {
                this.Text = "Αλλαγή Κουτιού";
                this.labelKoutiOrProionOld.Text = "Αριθμός Κουτιού";
                this.labelLocOld.Visible = true;
                this.labelLocNew.Visible = true;
                this.textBoxLocOld.Visible = true;
                this.textBoxLocNew.Visible = true;

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SQLiteCommand(koutiaCmdString, con);

                koutiByIdString = "SELECT * FROM KOUTI WHERE (Id=@Id)";
                koutiById = new SQLiteCommand(koutiByIdString, con);
                koutiById.Parameters.AddWithValue("@Id", "DEFAULT");

                changeKoutiString = "UPDATE KOUTI SET Id=@NewId, Location=@NewLocation WHERE (Id=@OldId)";
                changeKouti = new SQLiteCommand(changeKoutiString, con);
                changeKouti.Parameters.AddWithValue("@NewLocation", "DEFAULT");
                changeKouti.Parameters.AddWithValue("@OldId", "DEFAULT");
                changeKouti.Parameters.AddWithValue("@NewId", "DEFAULT");

                koutiTable1 = new ApothikiDataSet.KoutiDataTable();
                koutiTable2 = new ApothikiDataSet.KoutiDataTable();
            }
            else if (changeDialogType == ChangeDialogType.Proion) {
                this.Text = "Αλλαγή Προϊόντος";
                this.labelKoutiOrProionOld.Text = "Όνομα προϊόντος";
                this.comboBoxKoutiOrProionOld.Size = new System.Drawing.Size(224, 21);
                this.textBoxKoutiOrProionNew.Size = new System.Drawing.Size(224, 20);

                proiontaCmdString = "SELECT * FROM PROION ORDER BY Name";
                proiontaCmd = new SQLiteCommand(proiontaCmdString, con);

                changeProionCmdString = "UPDATE PROION SET Name=@NewName WHERE (Name=@OldName)";
                changeProionCmd = new SQLiteCommand(changeProionCmdString, con);
                changeProionCmd.Parameters.AddWithValue("@NewName", "DEFAULT");
                changeProionCmd.Parameters.AddWithValue("@OldName", "DEFAULT");

                proionTable = new ApothikiDataSet.ProionDataTable();
            }
            fillComboboxKoutiOrProionOld();
        }

        private void ChangeDialog_Load(object sender, EventArgs e) {
            comboBoxKoutiOrProionOld_SelectedIndexChanged(null, null);
        }

        private void comboBoxKoutiOrProionOld_TextUpdate(object sender, EventArgs e) {
            toggleOKButton();
            if (comboBoxKoutiOrProionOld.Text == "") {
                textBoxKoutiOrProionNew.Text = "";
                if(changeDialogType == ChangeDialogType.Kouti) {
                    textBoxLocOld.Text = "";
                    textBoxLocNew.Text = "";
                }
            }
                
        }

        private void comboBoxKoutiOrProionOld_SelectedIndexChanged(object sender, EventArgs e) {
            updateTextBoxes();
            toggleOKButton();
        }

        private void comboBoxKoutiOrProionNew_TextChanged(object sender, EventArgs e) {
            toggleOKButton();
        }

        private void toggleOKButton() {
            if (comboBoxKoutiOrProionOld.Text == "" || textBoxKoutiOrProionNew.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
        }

        private void fillComboboxKoutiOrProionOld() {
            if (changeDialogType == ChangeDialogType.Kouti) {
                koutiTable1.Clear();
                try {
                    con.Open();
                    dataReader = koutiaCmd.ExecuteReader();
                    koutiTable1.Load(dataReader);
                    dataReader.Close();
                    //koutiaCmd.Dispose();

                    comboBoxKoutiOrProionOld.DataSource = koutiTable1;
                    comboBoxKoutiOrProionOld.DisplayMember = "Id";
                    comboBoxKoutiOrProionOld.BindingContext = this.BindingContext;
                    comboBoxKoutiOrProionOld.SelectedIndex = -1;
                }
                catch (SQLiteException sqlEx) {
                    MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //proiontaCmd.Dispose();

                    comboBoxKoutiOrProionOld.DataSource = proionTable;
                    comboBoxKoutiOrProionOld.DisplayMember = "Name";
                    comboBoxKoutiOrProionOld.BindingContext = this.BindingContext;
                    comboBoxKoutiOrProionOld.SelectedIndex = -1;
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

        private void updateTextBoxes() {
            if (comboBoxKoutiOrProionOld.Text != "") {
                if (changeDialogType == ChangeDialogType.Kouti) {
                    textBoxKoutiOrProionNew.Text = comboBoxKoutiOrProionOld.Text;

                    int id = Int32.Parse(comboBoxKoutiOrProionOld.Text);
                    koutiById.Parameters["@Id"].Value = id;
                    koutiTable2.Clear();
                    try {
                        con.Open();
                        dataReader = koutiById.ExecuteReader();
                        koutiTable2.Load(dataReader);
                        dataReader.Close();
                        //koutiById.Dispose();

                        if (koutiTable2.Rows.Count == 1)
                            textBoxLocOld.Text = koutiTable2.Rows[0]["Location"].ToString();
                        else
                            textBoxLocOld.Text = "";

                        textBoxLocNew.Text = textBoxLocOld.Text;
                    }
                    catch (SQLiteException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
                else if (changeDialogType == ChangeDialogType.Proion)
                    textBoxKoutiOrProionNew.Text = comboBoxKoutiOrProionOld.Text;
            }
            else
                textBoxKoutiOrProionNew.Text = "";
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (changeDialogType == ChangeDialogType.Kouti) {
                try {
                    int newid = Int32.Parse(textBoxKoutiOrProionNew.Text.Trim());
                    int oldid = Int32.Parse(comboBoxKoutiOrProionOld.Text.Trim());
                    String newLocation = textBoxLocNew.Text.Trim();
                    changeKouti.Parameters["@NewId"].Value = newid;
                    changeKouti.Parameters["@OldId"].Value = oldid;
                    changeKouti.Parameters["@NewLocation"].Value = newLocation;

                    if (newid != oldid || newLocation != textBoxLocOld.Text) {
                        try {
                            con.Open();
                            int rowsAffected = changeKouti.ExecuteNonQuery();
                            //trigger on table Kouti affects multiple rows
                            if (!(rowsAffected == 0)) {
                                if (oldid == newid)
                                    MessageBox.Show("Η τοποθεσία του κουτιού " + oldid + " άλλαξε σε \"" + newLocation + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (newLocation == textBoxLocOld.Text)
                                    MessageBox.Show("Το κουτί " + oldid + " άλλαξε σε κουτί " + newid, "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Το κουτί " + oldid + " άλλαξε σε κουτί " + newid + " με καινούρια τοποθεσία \"" + newLocation + "\"", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Η αλλαγή δεν ήταν επιτυχής. Βεβαιωθείτε ότι τα δεδομενα είναι σωστά.", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (SQLiteException sqlEx) {
                            if (sqlEx.ErrorCode == 19)
                                MessageBox.Show("Το κουτί " + newid + " υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                                MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally {
                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }

                        fillComboboxKoutiOrProionOld();
                        updateTextBoxes();
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
                String oldValue = comboBoxKoutiOrProionOld.Text.Trim();
                String newValue = textBoxKoutiOrProionNew.Text.Trim();

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
                    catch (SQLiteException sqlEx) {
                        if (sqlEx.ErrorCode == 19)
                            MessageBox.Show("Το προϊόν \"" + newValue + "\" υπάρχει ήδη", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Error " + sqlEx.ErrorCode + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }

                    fillComboboxKoutiOrProionOld();
                    updateTextBoxes();
                    toggleOKButton();
                }
                else
                    MessageBox.Show("Δεν πραγματοποιήθηκε καμία αλλαγή", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ((MainForm)this.Owner).updateDataGridViewBySxeseis();
        }
    }
}