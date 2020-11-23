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
    public partial class buy_goods : MetroFramework.Forms.MetroForm
    {
        string id_emp;
        public buy_goods(string id)
        {
            InitializeComponent();
            id_emp = id;
        }
        private DataTable filldatatable(string id)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id, name_pr, discount, discnt_reason, price from goods where id=" + id;
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

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tab = filldatatable(textBox_id_gds.Text);
                metroGrid1.Rows.Add(tab.Rows[0]["id"], tab.Rows[0]["name_pr"], tab.Rows[0]["discount"], tab.Rows[0]["discnt_reason"], tab.Rows[0]["price"]);
            }
            catch (IndexOutOfRangeException) 
            {
                MetroMessageBox.Show(this, "Данного товара нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox_id_gds.Text = "";
        }

        private void buy_goods_Load(object sender, EventArgs e)
        {
            metroGrid1.Columns.Add("id", "ID");
            metroGrid1.Columns.Add("name_pr", "Наименование товара");
            metroGrid1.Columns.Add("discount", "Скидка");
            metroGrid1.Columns.Add("discnt_reason", "Причина скидки");
            metroGrid1.Columns.Add("price", "Цена");
            metroGrid1.Columns[0].Width = 30;
            metroGrid1.Columns[1].Width = 600;
            metroGrid1.Columns[2].Width = 70;
            metroGrid1.Columns[3].Width = 250;
            metroGrid1.Columns[4].Width = 200;
        }
    }
}
