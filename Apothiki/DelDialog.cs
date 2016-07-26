using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki {

    public enum DelDialogType {
        Kouti, Proion
    }

    public partial class DelDialog : Form {

        String delKoutiCmdString, delProionCmdString;
        String koutiaCmdString, proiontaCmdString;
        SqlCommand delKoutiCmd, delProionCmd;
        SqlCommand koutiaCmd, proiontaCmd;
        SqlConnection con;
        SqlDataReader dataReader;
        DelDialogType delDialogType;
        DialogResult result;
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;

        public DelDialog(DelDialogType delDialogType, SqlConnection con) {

            this.con = con;
            this.delDialogType = delDialogType;

            if (delDialogType == DelDialogType.Kouti) {
                InitializeComponent();
                this.comboBox1.Size = new System.Drawing.Size(64, 21);
                this.Text = "Διαγραφή κουτιού";
                this.label1.Text = "Αριθμός Κουτιού";

                delKoutiCmdString = "DELETE FROM KOUTI WHERE (Id=@Id)";
                delKoutiCmd = new SqlCommand(delKoutiCmdString, con);
                delKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);

                koutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
                koutiaCmd = new SqlCommand(koutiaCmdString, con);
                koutiTable = new ApothikiDataSet.KoutiDataTable();

            }
            else if (delDialogType == DelDialogType.Proion) {
                InitializeComponent();
                this.comboBox1.Size = new System.Drawing.Size(224, 21);
                this.Text = "Διαγραφή προϊόντος";
                this.label1.Text = "Όνομα προϊόντος";

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

            result = MessageBox.Show("Είστε βέβαιοι ότι θέλετε να το διαγράψετε;", "Επιβεβαίωση", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (result.Equals(DialogResult.Yes)) {

                if (delDialogType == DelDialogType.Kouti) {
                    int id = Int32.Parse(comboBox1.Text);
                    delKoutiCmd.Parameters["@Id"].Value = id;

                    try {
                        con.Open();
                        int rowsAffected = delKoutiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Το κουτί " + id + " διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    String name = comboBox1.Text;
                    delProionCmd.Parameters["@Name"].Value = name;

                    try {
                        con.Open();
                        int rowsAffected = delProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                            MessageBox.Show("Το προϊόν \"" + name + "\" διαγράφηκε με επιτυχία", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException sqlEx) {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
                fillComboBox();
                ((MainForm)this.Owner).updateDataGridView();
            }

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
            if (comboBox1.Text == "")
                OKButton.Enabled = false;
            else
                OKButton.Enabled = true;
        }
    }
}
