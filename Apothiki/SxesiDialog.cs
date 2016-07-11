using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apothiki
{
    public partial class SxesiDialog : Form
    {
        String sqlCmdString;
        SqlCommand sqlCmd;
        bool execcmd=true;
        SqlDataReader sqlDataReader;
        ApothikiDataSet.SxesiDataTable sxesiTable;
        ApothikiDataSet.KoutiDataTable koutiTable;
        ApothikiDataSet.ProionDataTable proionTable;
        SqlConnection con;
        private SqlDataReader dataReader;

        public SxesiDialog()
        {
            InitializeComponent();
            this.Text = "Εισαγωγή προϊόντος σε κουτί";
            execcmd = false;
        }

        public SxesiDialog(String conString)
        {
            InitializeComponent();
            this.Text = "Εξαγωγή προϊόντος από κουτί";
            con = new SqlConnection(conString);
            sqlCmdString = "SELECT * FROM SXESI WHERE (KoutiId=@KoutiId)";
            sqlCmd = new SqlCommand(sqlCmdString, con);
            sqlCmd.Parameters.Add("@KoutiId", SqlDbType.Int);
            sxesiTable = new ApothikiDataSet.SxesiDataTable();
        }

        public SxesiDialog(String conString,bool value)
        {
            execcmd = false;
            InitializeComponent();
            con = new SqlConnection(conString);
            if (value)
            {
                this.Text = "Διαγραφή κουτιού";
                label2.Visible = false;
                comboBox2.Visible = false;
                label1.Top += 20;
                comboBox1.Top += 20;
                sqlCmdString = "SELECT * FROM KOUTI";
                sqlCmd = new SqlCommand(sqlCmdString, con);
                try
                {
                    koutiTable = new ApothikiDataSet.KoutiDataTable();
                    con.Open();
                    dataReader = sqlCmd.ExecuteReader();
                    koutiTable.Load(dataReader);
                    dataReader.Close();
                    sqlCmd.Dispose();
                    con.Close();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlCmdString = null; // ELEOS
                setComboBox1(koutiTable);
            }
            else
            {
                this.Text = "Διαγραφή προϊόντος";
                label1.Visible = false;
                comboBox1.Visible = false;
                label2.Top -= 20;
                comboBox2.Top -= 20;
                sqlCmdString = "SELECT * FROM PROION";
                sqlCmd = new SqlCommand(sqlCmdString, con);
                proionTable = new ApothikiDataSet.ProionDataTable();
                try
                {
                    proionTable = new ApothikiDataSet.ProionDataTable();
                    con.Open();
                    dataReader = sqlCmd.ExecuteReader();
                    proionTable.Load(dataReader);
                    dataReader.Close();
                    sqlCmd.Dispose();
                    con.Close();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlCmdString = null; // ELEOS
                setComboBox2(proionTable);
            }
        }

        public void setComboBox1(ApothikiDataSet.KoutiDataTable koutiTable)
        {
            comboBox1.DataSource = koutiTable;
            comboBox1.DisplayMember = "Id";
            comboBox1.BindingContext = this.BindingContext;
            label3.Text = comboBox1.Text;
        }

        public void setComboBox2(ApothikiDataSet.ProionDataTable proionTable)
        {
            comboBox2.DataSource = proionTable;
            comboBox2.DisplayMember = "Name";
            comboBox2.BindingContext = this.BindingContext;
        }

        private void setComboBox2(ApothikiDataSet.SxesiDataTable sxesiTable)
        {
            comboBox2.DataSource = sxesiTable;
            comboBox2.DisplayMember = "ProionName";
            comboBox2.BindingContext = this.BindingContext;
        }

        public int getComboBox1()
        {
            return Int32.Parse(label3.Text);
        }

        public string getComboBox2()
        {
            return label4.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label3.Text = comboBox1.Text;
            label4.Text = comboBox2.Text;
        }

        private void SxesiDialog_Load(object sender, EventArgs e)
        {
            updateOKButton();
            if (sqlCmdString != null)
            {
                loadcmbox2();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbox2();
        }

        private void updateOKButton()
        {
            if (execcmd)
            {
                if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    button1.Enabled = false;
                }
                else if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                if (comboBox1.Text == "" && comboBox2.Text == "")
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
        }

        private void updateOKButtonForDelete()
        {
            button1.Enabled = true;
        }

        private void loadcmbox2()
        {
            if (execcmd)
            {
                if (comboBox1.Text!="")
                {
                    sqlCmd.Parameters["@KoutiId"].Value = Int32.Parse(comboBox1.Text);
                    try
                    {
                        sxesiTable.Clear();
                        con.Close();
                        con.Open();
                        sqlDataReader = sqlCmd.ExecuteReader();
                        sxesiTable.Load(sqlDataReader);
                        sqlDataReader.Close();
                        sqlCmd.Dispose();
                        con.Close();
                        setComboBox2(sxesiTable);
                        updateOKButton();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("Error " + sqlEx.Number + ": " + sqlEx.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }
    }
}
