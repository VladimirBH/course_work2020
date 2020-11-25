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
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace CSB_program
{
    public partial class add_clients : MetroFramework.Forms.MetroForm
    {
        public add_clients()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (second_name != null && name_otch != null && dateTimePicker_birth != null && textBox_adress != null &&
                    textbox_tel_num != null)
                {

                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "add_clients";
                    cmd.Parameters.Add(new SqlParameter("@fam", SqlDbType.VarChar));
                    cmd.Parameters["@fam"].Value = second_name.Text;
                    cmd.Parameters.Add(new SqlParameter("@name_otch", SqlDbType.VarChar));
                    cmd.Parameters["@name_otch"].Value = name_otch.Text;
                    cmd.Parameters.Add(new SqlParameter("@date_rozhd", SqlDbType.Date));
                    cmd.Parameters["@date_rozhd"].Value = dateTimePicker_birth.Value;
                    cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
                    cmd.Parameters["@address"].Value = textBox_adress.Text;
                    cmd.Parameters.Add(new SqlParameter("@tel", SqlDbType.VarChar));
                    cmd.Parameters["@tel"].Value = textbox_tel_num.Text;
                    con.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MetroMessageBox.Show(this, "Данные успешно добавлены!!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        second_name.Text = "";
                        name_otch.Text = "";
                        dateTimePicker_birth.Value = DateTime.Now;
                        textBox_adress.Text = "";
                        textbox_tel_num.Text = "";
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Нет записей", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Введены не все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MetroMessageBox.Show(this, "Введены не все данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
