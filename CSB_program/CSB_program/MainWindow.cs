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

namespace CSB_program
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        string logon;
        string id_emp;
        public MainWindow(string log)
        {
            InitializeComponent();
            logon = log;
        }
        auth vhod;
        int acc_cat;
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void show_buttons_3_4_5() 
        {
            button_buy.Visible = true;
            button_check.Visible = true;
            button_client.Visible = true;
            button_delivery.Visible = true;
            button_goods.Visible = true;
            button_position.Visible = true;
            button_provider.Visible = true;
            button_sotrud.Visible = true;
            this.button_goods.Location = new System.Drawing.Point(715, 145);
            this.button_provider.Location = new System.Drawing.Point(495, 211);
            this.button_delivery.Location = new System.Drawing.Point(495, 145);
            this.button_check.Location = new System.Drawing.Point(715, 211);
            this.button_client.Location = new System.Drawing.Point(715, 342);
            this.button_sotrud.Location = new System.Drawing.Point(495, 278);
            this.button_position.Location = new System.Drawing.Point(495, 342);
            this.button_buy.Location = new System.Drawing.Point(715, 278);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.ConString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select employees.*,positions.access_category, positions.job_title " + // запрос к бд, чтобы вывести все данные о сотруднике
                "from employees " +
                "inner join positions " +
                "on employees.id_position=positions.id " +
                "where login='" + logon + "'";

            SqlDataReader rdr = cmd.ExecuteReader();
            cmd.Dispose();
            DataTable dt = new DataTable();
            for (int i = 0; i < rdr.FieldCount; i++)                        
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));                // запись названий колонок в объект datatable
            }
            if (rdr.HasRows)
            {

                DataRow rec = dt.NewRow();
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        rec[i] = rdr.GetValue(i);                                                   // запись данных в объект datatable
                    }
                    dt.Rows.Add(rec);
                    
                }
                rdr.Close();                                                                        // закрытие и очистка памяти подлкючения, SQLCommand и SQLReader
                cmd.Dispose();
                con.Close();
                con.Dispose();
                fio.Text = dt.Rows[0]["second_name"] + " " + dt.Rows[0]["first_nm_dad_nm"];         // вывод данных в форму
                lev_acc.Text = dt.Rows[0]["access_category"].ToString();
                id_emp = dt.Rows[0]["id"].ToString();
                pos.Text = dt.Rows[0]["job_title"].ToString();
                acc_cat = Convert.ToInt32(dt.Rows[0]["access_category"]);
                switch (Convert.ToInt32(lev_acc.Text)) 
                {
                    case 1:
                        button_delivery.Visible = true;
                        button_goods.Visible = true;
                        button_provider.Visible = true;
                        postavka_tov.Visible = true;
                        this.button_goods.Location = new System.Drawing.Point(715, 187);
                        this.button_provider.Location = new System.Drawing.Point(715, 248);
                        this.button_delivery.Location = new System.Drawing.Point(715, 126);
                        this.postavka_tov.Location = new System.Drawing.Point(715, 309);
                        break;
                    case 2:
                        button_buy.Visible = true;
                        button_check.Visible = true;
                        button_client.Visible = true;
                        button_goods.Visible = true;
                        buy_check.Visible = true;
                        this.button_goods.Location = new System.Drawing.Point(715, 197);
                        this.button_check.Location = new System.Drawing.Point(715, 248);
                        this.button_client.Location = new System.Drawing.Point(715, 350);
                        this.button_buy.Location = new System.Drawing.Point(715, 299);
                        this.buy_check.Location = new System.Drawing.Point(715, 133);
                        break;
                    case 3:
                        show_buttons_3_4_5();
                        break;
                    case 4:
                        show_buttons_3_4_5();
                        break;
                    case 5:
                        show_buttons_3_4_5();
                        break;
                }
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            
            vhod = new auth();
            vhod.Show();
            this.Dispose();
        }

        private void button_delivery_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("delivery", acc_cat);
            wt.Show();
        }

        private void button_provider_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("provider", acc_cat);
            wt.Show();
        }

        private void button_sotrud_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("employees", acc_cat);
            wt.Show();
        }

        private void button_position_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("positions", acc_cat);
            wt.Show();
        }

        private void button_client_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("clients", acc_cat);
            wt.Show();
        }

        private void button_buy_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("sales", acc_cat);
            wt.Show();
        }

        private void button_goods_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("goods", acc_cat);
            wt.Show();
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            watch_tables wt = new watch_tables("sales_receipt", acc_cat);
            wt.Show();
        }
        private void buy_check_Click(object sender, EventArgs e)
        {
            buy_goods bch = new buy_goods(id_emp);
            bch.Show();
        }
        private void postavka_tov_Click(object sender, EventArgs e)
        {
            form_for_supply supply = new form_for_supply();
            supply.Show();
        }
    }
}
