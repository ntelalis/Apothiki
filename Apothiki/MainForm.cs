using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Apothiki
{
    public partial class MainForm : Form
    {
        Dialog dialog;
        SxesiDialog sxesidialog;
        String conString;   //DB Connection String
        List<String> productStrings = new List<string>();
        SqlConnection con;
        SqlDataReader dataReader;

        String newKoutiCmdString, delKoutiCmdString,
               newProionCmdString, delProionCmdString,   //SqlCommandStrings
               newSxesiCmdString, delSxesiCmdString,
               KoutiaCmdString, ProiontaCmdString,
               SxesiByProionCmdString, SxesiProionByKoutiCmdString,
               SxeseisCmdString, KoutiLocByIdCmdString;

        SqlCommand newKoutiCmd, delKoutiCmd,
                   newProionCmd, delProionCmd,          //SqlCommands
                   newSxesiCmd, delSxesiCmd,
                   KoutiaCmd, ProiontaCmd,
                   SxesiByProionCmd, SxesiProionByKoutiCmd,
                   SxeseisCmd, KoutiLocByIdCmd;

        private void σχέσειςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sxesiTable.Clear();
            try
            {
                con.Open();
                dataReader = SxeseisCmd.ExecuteReader();
                sxesiTable.Load(dataReader);
                dataReader.Close();
                SxeseisCmd.Dispose();
                dataGridView1.DataSource = sxesiTable;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 230;
                dataGridView1.Columns[2].Width = 130;

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void εξαγωγήΑπόΚουτίToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sxesidialog = new SxesiDialog(conString);

            koutiTable.Clear();

            try
            {
                con.Open();

                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();
                con.Close();

                sxesidialog.setComboBox1(koutiTable);

                if (sxesidialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        delSxesiCmd.Parameters["@KoutiId"].Value = sxesidialog.getComboBox1();
                        delSxesiCmd.Parameters["@ProionName"].Value = sxesidialog.getComboBox2();
                        con.Open();
                        int rowsAffected = delSxesiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Η εξαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (rowsAffected == 0)
                        {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            textBox1_TextChanged(null, null);
        }

        private void εισαγωγήΣεΚουτίToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sxesidialog = new SxesiDialog();

            koutiTable.Clear();
            proionTable.Clear();
            try
            {
                con.Open();

                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();

                dataReader = ProiontaCmd.ExecuteReader();
                proionTable.Load(dataReader);
                dataReader.Close();
                ProiontaCmd.Dispose();

                sxesidialog.setComboBox1(koutiTable);
                sxesidialog.setComboBox2(proionTable);
                if (sxesidialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        newSxesiCmd.Parameters["@KoutiId"].Value = sxesidialog.getComboBox1();
                        newSxesiCmd.Parameters["@ProionName"].Value = sxesidialog.getComboBox2();

                        KoutiLocByIdCmd.Parameters["@Id"].Value = newSxesiCmd.Parameters["@KoutiId"].Value;
                        dataReader = KoutiLocByIdCmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = dataReader.GetString(1);
                            dataReader.Close();
                            ProiontaCmd.Dispose();

                        }
                        else
                        {
                            newSxesiCmd.Parameters["@KoutiLocation"].Value = "";
                        }

                        int rowsAffected = newSxesiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Η εισαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (rowsAffected == 0)
                        {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Number == 2627)
                        {
                            MessageBox.Show("Το προϊόν υπάρχει ήδη στο Κουτί", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            textBox1_TextChanged(null, null);
        }

        private void προϊόνToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sxesidialog = new SxesiDialog(conString,false);
            if(sxesidialog.ShowDialog(this) == DialogResult.OK)
            {
                
                try
                {
                    String name = sxesidialog.getComboBox2();
                    delProionCmd.Parameters["@Name"].Value = name;
                    con.Open();
                    int rowsAffected = delProionCmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Δε βρέθηκε εγγραφή", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (rowsAffected == 1)
                    {
                        MessageBox.Show("Η διαγραφή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                catch(SqlException sqlEx)
                {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            con.Close();
            textBox1_TextChanged(null, null);
        }

        private void κουτίToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sxesidialog = new SxesiDialog(conString,true);

            if (sxesidialog.ShowDialog(this) == DialogResult.OK)
            {
                int id = sxesidialog.getComboBox1();
                delKoutiCmd.Parameters["@Id"].Value = id;

                try
                {
                    con.Open();
                    int rowsAffected = delKoutiCmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Δε βρέθηκε εγγραφή", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if(rowsAffected == 1)
                    {
                        MessageBox.Show("Η διαγραφή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();
            textBox1_TextChanged(null, null);
        }

        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;  //DataTables
        ApothikiDataSet.SxesiDataTable sxesiTable;

        private void προϊόνToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog = new Dialog("Όνομα προϊόντος");

            if (dialog.ShowDialog(this)== DialogResult.OK)
            {
                String name = dialog.getTextBox1();
                name = name.Trim();
                if (name != "")
                {
                    newProionCmd.Parameters["@Name"].Value = name;
                    try
                    {
                        con.Open();
                        int rowsAffected = newProionCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Η εισαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        if (sqlEx.Number == 2627)
                        {
                            MessageBox.Show("To Προϊόν υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    con.Close();
                }
                updateProductStrings();
            }
        }

        private void κουτίToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog = new Dialog("Αριθμός κουτιού","Τοποθεσία (Προαιρετικό)");

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                int id = -1;
                string location = null;
                try
                {
                    id = Int32.Parse(dialog.getTextBox1());
                }
                catch(FormatException)
                {
                    MessageBox.Show("Το πεδίο \"Αριθμός κουτιού\" δέχεται μόνο ακέραιους αριθμούς", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                location = dialog.getTextBox2();
                location = location.Trim();
                if(id!=-1)
                {
                    newKoutiCmd.Parameters["@Id"].Value = id;
                    newKoutiCmd.Parameters["@Location"].Value = location;

                    
                    try
                    {
                        con.Open();
                        int rowsAffected = newKoutiCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Η εισαγωγή ήταν επιτυχής", "Ειδοποίηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Σφάλμα", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Number == 2627)
                        {
                            MessageBox.Show("Το κουτί υπάρχει ήδη", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error "+sqlEx.Number+": "+sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    con.Close();
                }
            }
        }

        private void προϊόνταToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proionTable.Clear();
            try
            {
                con.Open();
                dataReader = ProiontaCmd.ExecuteReader();
                proionTable.Load(dataReader);
                dataReader.Close();
                ProiontaCmd.Dispose();
                dataGridView1.DataSource = proionTable;
                dataGridView1.Columns[0].Width = 250;

            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void κουτιάToolStripMenuItem_Click(object sender, EventArgs e)
        {

            koutiTable.Clear();
            try
            {
                con.Open();
                dataReader = KoutiaCmd.ExecuteReader();
                koutiTable.Load(dataReader);
                dataReader.Close();
                KoutiaCmd.Dispose();
                dataGridView1.DataSource = koutiTable;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 200;

            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sxesiTable.Clear();
            try
            {
                String name = textBox1.Text;
                name = name.Trim();
                con.Open();
                foreach (String s in productStrings)
                {
                    if(s.IndexOf(name,StringComparison.OrdinalIgnoreCase)>=0){
                        
                        SxesiByProionCmd.Parameters["@ProionName"].Value = s;
                        dataReader = SxesiByProionCmd.ExecuteReader();
                        sxesiTable.Load(dataReader);
                    }
                }
                dataReader.Close();
                SxesiByProionCmd.Dispose();
                dataGridView1.DataSource = sxesiTable;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 230;
                dataGridView1.Columns[2].Width = 130;

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        ApothikiDataSet apothikidataset;

        public MainForm()
        {
            InitializeComponent();
            initStrings();
            con = new SqlConnection(conString);
            initCmds();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            updateProductStrings();
            σχέσειςToolStripMenuItem_Click(null, null);

        }

        private void initStrings()
        {
            conString = Apothiki.Properties.Settings.Default.ApothikiConnectionString;
            newKoutiCmdString = "INSERT INTO KOUTI (Id,Location) VALUES (@Id,@Location)";
            delKoutiCmdString = "DELETE FROM KOUTI WHERE (Id=@Id)";
            newProionCmdString = "INSERT INTO PROION (Name) VALUES (@Name)";
            delProionCmdString = "DELETE FROM PROION WHERE (Name=@Name)";
            newSxesiCmdString = "INSERT INTO SXESI (KoutiId,ProionName,KoutiLocation) VALUES (@KoutiId,@ProionName,@KoutiLocation)";
            delSxesiCmdString = "DELETE FROM SXESI WHERE (KoutiId=@KoutiId) AND (ProionName=@ProionName)";
            KoutiaCmdString = "SELECT * FROM KOUTI ORDER BY Id";
            KoutiLocByIdCmdString = "SELECT * FROM KOUTI WHERE (Id=@Id)";
            ProiontaCmdString = "SELECT * FROM Proion ORDER BY Name";
            SxeseisCmdString = "SELECT * FROM SXESI ORDER BY KoutiId";
            SxesiByProionCmdString = "SELECT * FROM SXESI WHERE (ProionName=@ProionName) ORDER BY KoutiId";
            SxesiProionByKoutiCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId)";
        }

        private void initCmds()
        {
            newKoutiCmd = new SqlCommand(newKoutiCmdString, con);
            newKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);
            newKoutiCmd.Parameters.Add("@Location", SqlDbType.NVarChar);

            delKoutiCmd = new SqlCommand(delKoutiCmdString, con);
            delKoutiCmd.Parameters.Add("@Id", SqlDbType.Int);

            newProionCmd = new SqlCommand(newProionCmdString, con);
            newProionCmd.Parameters.Add("@Name", SqlDbType.NVarChar);

            delProionCmd = new SqlCommand(delProionCmdString, con);
            delProionCmd.Parameters.Add("@Name", SqlDbType.NVarChar);

            newSxesiCmd = new SqlCommand(newSxesiCmdString, con);
            newSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            newSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);
            newSxesiCmd.Parameters.Add("@KoutiLocation", SqlDbType.NVarChar);

            delSxesiCmd = new SqlCommand(delSxesiCmdString, con);
            delSxesiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            delSxesiCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            KoutiaCmd = new SqlCommand(KoutiaCmdString, con);

            ProiontaCmd = new SqlCommand(ProiontaCmdString, con);

            KoutiLocByIdCmd = new SqlCommand(KoutiLocByIdCmdString, con);
            KoutiLocByIdCmd.Parameters.Add("@Id", SqlDbType.Int);

            SxeseisCmd = new SqlCommand(SxeseisCmdString, con);

            SxesiByProionCmd = new SqlCommand(SxesiByProionCmdString, con);
            SxesiByProionCmd.Parameters.Add("@ProionName", SqlDbType.NVarChar);

            SxesiProionByKoutiCmd = new SqlCommand(SxesiProionByKoutiCmdString, con);
            SxesiProionByKoutiCmd.Parameters.Add("@KoutiId", SqlDbType.Int);

            apothikidataset = new ApothikiDataSet();

            koutiTable = new ApothikiDataSet.KoutiDataTable();
            proionTable = new ApothikiDataSet.ProionDataTable();
            sxesiTable = new ApothikiDataSet.SxesiDataTable();
        }

        

        private void updateProductStrings()
        {
            productStrings = new List<string>();

            try
            {
                con.Open();
                dataReader = ProiontaCmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        productStrings.Add(dataReader.GetString(0));
                    }
                }
                foreach (String s in productStrings)
                    Console.WriteLine(s);
                dataReader.Close();
                ProiontaCmd.Dispose();

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
