using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Properties;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using MetroFramework;

namespace CSB_program
{
    public partial class form_for_supply : MetroFramework.Forms.MetroForm
    {
        public form_for_supply()
        {
            InitializeComponent();
        }

        //private DataTable filldatatable(string dtable)
        //{
        //    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = dtable;
        //    con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    cmd.Dispose();
        //    DataTable dt = new DataTable();
        //    for (int i = 0; i < rdr.FieldCount; i++)
        //    {
        //        dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));                // запись названий колонок в объект datatable
        //    }
        //    if (rdr.HasRows)
        //    {
        //        DataRow rec = dt.NewRow();
        //        while (rdr.Read())
        //        {
        //            for (int i = 0; i < rdr.FieldCount; i++)
        //            {
        //                rec[i] = rdr.GetValue(i);                                                   // запись данных в объект datatable
        //            }
        //            dt.Rows.Add(rec);

        //        }
        //        rdr.Close();                                                                        // закрытие и очистка памяти подлкючения, SQLCommand и SQLReader
        //        cmd.Dispose();
        //        con.Close();
        //        con.Dispose();
        //    }
        //    return dt;
        //}

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

        private void form_for_supply_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.cSB_INCDataSet.employees);
            string zapr = "SELECT name_org from provider";
            combobox_provider.DataSource = filldatatable(zapr);
            combobox_provider.ValueMember = "name_org";
            combobox_provider.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tov_name != null && tov_count != null && date_delivery != null && date_order != null && price_text != null && combobox_provider.SelectedItem != null)
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "add_goods";
                cmd.Parameters.Add(new SqlParameter("@name_tov", SqlDbType.VarChar));
                cmd.Parameters["@name_tov"].Value = tov_name.Text;
                cmd.Parameters.Add(new SqlParameter("@count_tov", SqlDbType.Int));
                cmd.Parameters["@count_tov"].Value = tov_count.Text;
                cmd.Parameters.Add(new SqlParameter("@date_del", SqlDbType.Date));
                cmd.Parameters["@date_del"].Value = date_delivery.Value;
                cmd.Parameters.Add(new SqlParameter("@date_or", SqlDbType.Date));
                cmd.Parameters["@date_or"].Value = date_order.Value;
                cmd.Parameters.Add(new SqlParameter("@cost", SqlDbType.Decimal));
                cmd.Parameters["@cost"].Value = price_text.Text;
                cmd.Parameters.Add(new SqlParameter("@name_org", SqlDbType.VarChar));
                cmd.Parameters["@name_org"].Value = combobox_provider.SelectedValue.ToString();
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MetroMessageBox.Show(this,"Данные успешно добавлены!!");
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

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
