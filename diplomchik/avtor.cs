using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace diplomchik
{
    public partial class avtor : Form
    {
        public avtor()
        {
            InitializeComponent();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DB dataBases = new DB();

            var loginuser = guna2TextBox6.Text;
            var passUser = guna2TextBox5.Text;
            var schet = guna2TextBox3.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select  Login, Password, Schet from dbo.tbl_login where Login = '{loginuser}' and Password ='{passUser} 'and Schet = '{schet}' ";

            SqlCommand command = new SqlCommand(querystring, dataBases.GetSqlConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен");
                Glav frm1 = new Glav();
                frm1.ShowDialog();
                this.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Неверный логин или пароль");

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DB dataBases = new DB();

            var login = guna2TextBox1.Text;
            var password = guna2TextBox2.Text;
            var schet = guna2TextBox3.Text;



            string querystring = $"insert into dbo.tbl_login (Login, Password, Schet) values ('{login}', '{password}', '{schet}')";

            SqlCommand command = new SqlCommand(querystring, dataBases.GetSqlConnection());

            dataBases.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("accaunt succesful create!");
                Glav frmlgn = new Glav();
                this.Hide();
                frmlgn.ShowDialog();
            }
            else
            {
                MessageBox.Show("akkaunt ne sozdan");
            }
            dataBases.CloseConnection();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }
    }
}

