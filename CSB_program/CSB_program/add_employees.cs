using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using MetroFramework;

namespace CSB_program
{
    public partial class add_employees : MetroFramework.Forms.MetroForm
    {
        public add_employees()
        {
            InitializeComponent();
        }
        private DataTable filldatatable(string dtable)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = dtable;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            }
            while (rdr.Read())
            {
                DataRow r = dt.NewRow();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    r[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(r);
                dt.GetErrors();
            }
            con.Close();
            return dt;
        }

        private void add_employees_Load(object sender, EventArgs e)
        {
            if (checkBox_show.Checked)
            {
                textBox_pass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_pass.UseSystemPasswordChar = true;
            }
            string zapr = "SELECT DISTINCT job_title from positions";
            comboBox_pos.DataSource = filldatatable(zapr);
            comboBox_pos.ValueMember = "job_title";
            comboBox_pos.SelectedIndex = 1;
        }

        private void comboBox_pos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zapr = "SELECT class from positions where job_title = '" + comboBox_pos.SelectedValue.ToString() + "'";
            comboBox_pos_class.DataSource = filldatatable(zapr);
            comboBox_pos_class.ValueMember = "class";
            comboBox_pos_class.SelectedIndex = -1;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string result;
            MD5 md = MD5.Create();
            byte[] hash = md.ComputeHash(Encoding.ASCII.GetBytes(textBox_pass.Text));
            result = BitConverter.ToString(hash).Replace("-", String.Empty);
            try
            {
                if (second_name != null && name_otch != null && dateTimePicker_birth != null && textBox_adress != null &&
                    textBox_login != null && textBox_pass != null && tel_num != null)
                {
                    
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "add_employees";
                    cmd.Parameters.Add(new SqlParameter("@fam", SqlDbType.VarChar));
                    cmd.Parameters["@fam"].Value = second_name.Text;
                    cmd.Parameters.Add(new SqlParameter("@name_otch", SqlDbType.VarChar));
                    cmd.Parameters["@name_otch"].Value = name_otch.Text;
                    cmd.Parameters.Add(new SqlParameter("@date_rozhd", SqlDbType.Date));
                    cmd.Parameters["@date_rozhd"].Value = dateTimePicker_birth.Value;
                    cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
                    cmd.Parameters["@address"].Value = textBox_adress.Text;
                    cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar));
                    cmd.Parameters["@login"].Value = textBox_login.Text;
                    cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar));
                    cmd.Parameters["@pass"].Value = result;
                    cmd.Parameters.Add(new SqlParameter("@job_tit", SqlDbType.VarChar));
                    cmd.Parameters["@job_tit"].Value = comboBox_pos.SelectedValue.ToString();
                    cmd.Parameters.Add(new SqlParameter("@tel", SqlDbType.VarChar));
                    cmd.Parameters["@tel"].Value = tel_num.Text;
                    cmd.Parameters.Add(new SqlParameter("@job_class", SqlDbType.Int));
                    cmd.Parameters["@job_class"].Value = Convert.ToInt32(comboBox_pos_class.SelectedValue);
                    con.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MetroMessageBox.Show(this, "Данные успешно добавлены!!  "+ result, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Нет записей   "+ result, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Введены не все данные"   + result, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MetroMessageBox.Show(this, "Введены не все данные    " + result, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkBox_show_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_show.Checked)
            {
                textBox_pass.UseSystemPasswordChar = false;
            }
            else 
            {
                textBox_pass.UseSystemPasswordChar = true;
            }
        }
    }
}
