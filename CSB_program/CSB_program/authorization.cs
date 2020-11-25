using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Properties;
using System.Data.SqlClient;
using System.Data.Common;
using System.Security.Cryptography;
namespace CSB_program
{
    public partial class auth : MetroFramework.Forms.MetroForm
    {
        MainWindow mform; // Главная форма
        public auth()
        {
            InitializeComponent();
            submit.FlatAppearance.BorderSize = 0;
            submit.FlatStyle = FlatStyle.Popup;
            cancel.FlatAppearance.BorderSize = 0;
            cancel.FlatStyle = FlatStyle.Popup;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logo.Image = Image.FromFile(Environment.CurrentDirectory + "\\logo.png");
            password.PasswordChar = '•';
        }
        private void submit_Click(object sender, EventArgs e)
        {
            MD5 md = MD5.Create();
            byte[] hash = md.ComputeHash(Encoding.ASCII.GetBytes(password.Text));
            string result = BitConverter.ToString(hash).Replace("-", String.Empty);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select login from employees where login='" + login.Text + "' AND password='" + result + "';";
            con.Open();
            string log;
            if (cmd.ExecuteScalar() != null)
            {
                var value = cmd.ExecuteScalar();
                con.Close();
                con.Dispose();
                log = value.ToString();              
                MetroMessageBox.Show(this, "Вход выполнен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                login.Text = "";
                password.Text = "";
                mform = new MainWindow(log);
                mform.Show();
                
            }
            else 
            {
                MetroMessageBox.Show(this, "Неверный логин/пароль!", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                con.Dispose();
            }
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
