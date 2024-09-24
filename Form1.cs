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
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Login_Form_in_C_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            //this.CancelButton = button1;
        }

        

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static string constr = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=_sample;Data Source=DESKTOP-G771BT7\SQLEXPRESS";
        static SqlConnection conn = new SqlConnection(constr);
        public static string UserFullname = null;

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (txtUserName.Text == "akif.shixlarov" && txtpassword.Text == "Akif16062006")
            {
                //new Form2().Show();
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("The user name or password you entered is incorrect!");
                txtUserName.Clear();
                txtpassword.Clear();
                txtUserName.Focus();
            }*/

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "select u_fullname,u_password from Users where u_username = '" + txtUserName.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();

                    if (sdr["u_password"].Equals(txtpassword.Text))
                    {
                        UserFullname = sdr["u_fullname"].ToString();
                        MessageBox.Show("Login Successful..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username is incorrect..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
