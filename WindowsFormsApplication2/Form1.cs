using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            u2.Visible = false;
            b2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            u3.Visible = false;
            b3.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = u1.Text;
            string soyisim = b1.Text;
            u1.Enabled = false;
            b1.Enabled = false;
            u2.Visible = true;
            b2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            

            }

        private void button2_Click(object sender, EventArgs e)
        {
            u1.Enabled = true;
            b1.Enabled = true;
            button3.Visible = true;
            button4.Visible = true;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            u2.Enabled = false;
            b2.Enabled = false;
            u3.Visible = true;
            b3.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            u2.Enabled = true;
            b2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            u3.Enabled = false;
            b3.Enabled = false;
            label3.Text = "Daha fazla Ekleyemezsiniz..";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
                int Bay;
                int Bayan;
                if (radioButton1.Checked)
                {
                    Bay = 1;
                    Bayan = 0;
                }
                else
                {
                    Bay = 0;
                    Bayan = 1;
                }   
                String Name = textBox1.Text.ToString();
                String SurName = textBox2.Text.ToString();
                string theDate = dateTimePicker1.Value.ToShortDateString();
                Bitmap Image = new Bitmap(pictureBox1.Image);
            OleDbConnection myAccessConn = null;
            try
            {
                string accessConn = null;
                accessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ik.mdb;";
                   myAccessConn = new OleDbConnection(accessConn);
                   myAccessConn.Open();

                   string str = "INSERT INTO cv(Name,Surname,Bay,Bayan,theDate,Image)VALUES( ('" + Name + "'),('" + SurName + "'),('" + Bay + "'),('" + Bayan + "'),('" + theDate + "'),('" + Image + "'))";

                    OleDbCommand myAccessCommand = new OleDbCommand(str, myAccessConn);
                    myAccessCommand.ExecuteNonQuery();
                    }
         
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                myAccessConn.Close();
            }




        

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path
                lblDosya.Text = open.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Office Files|*.doc;*.xls;*.ppt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                label10.Text = open.FileName;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
