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
    public partial class watch_tables : MetroFramework.Forms.MetroForm
    {
        int acc_cat;
        string tb;
        Point point = new Point();
        public watch_tables(string table, int access_cat)
        {
            InitializeComponent();
            tb = table;
            acc_cat = access_cat;
        }
        private void watch_tables_Resize(object sender, EventArgs e)
        {
            metroGrid1.Height = this.Height - 150;
            metroGrid1.Width = this.Width - 68;
            button_submit.Location = new System.Drawing.Point(this.Width - 144 - 84 - 36 - 20, 28);
            quit.Location = new System.Drawing.Point(this.Width - 84 - 36, 28);
        }
        private void watch_tables_Load(object sender, EventArgs e)
        {
            metroGrid1.Height = this.Height - 150;
            metroGrid1.Width = this.Width - 68;
            button_submit.Location = new System.Drawing.Point(this.Width - 144 - 84 - 36 - 20, 28);
            quit.Location = new System.Drawing.Point(this.Width - 84 - 36, 28);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.cSB_INCDataSet.employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.sales_receipt". При необходимости она может быть перемещена или удалена.
            this.sales_receiptTableAdapter.Fill(this.cSB_INCDataSet.sales_receipt);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.sales". При необходимости она может быть перемещена или удалена.
            this.salesTableAdapter.Fill(this.cSB_INCDataSet.sales);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.provider". При необходимости она может быть перемещена или удалена.
            this.providerTableAdapter.Fill(this.cSB_INCDataSet.provider);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.cSB_INCDataSet.positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.goods". При необходимости она может быть перемещена или удалена.
            this.goodsTableAdapter.Fill(this.cSB_INCDataSet.goods);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.cSB_INCDataSet.employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.delivery". При необходимости она может быть перемещена или удалена.
            this.deliveryTableAdapter.Fill(this.cSB_INCDataSet.delivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cSB_INCDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.cSB_INCDataSet.clients);

            switch (tb)
            {
                case "delivery":
                    switch (acc_cat) 
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Поставки";
                    metroGrid1.DataSource = deliveryBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["name_pr"].HeaderText = "Наименование товара";
                    metroGrid1.Columns["count_pr"].HeaderText = "Количество товара";
                    metroGrid1.Columns["date_order"].HeaderText = "Дата заказа";
                    metroGrid1.Columns["date_delivery"].HeaderText = "Дата поставки";
                    metroGrid1.Columns["id_provider"].HeaderText = "Номер поставщика";
                    bindingNavigator1.BindingSource = deliveryBindingSource;
                    break;
                case "employees":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Сотрудники";
                    metroGrid1.DataSource = employeesBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["second_name"].HeaderText = "Фамилия";
                    metroGrid1.Columns["first_nm_dad_nm"].HeaderText = "Имя Отчество";
                    metroGrid1.Columns["date_birth"].HeaderText = "Дата рождения";
                    metroGrid1.Columns["tel_num"].HeaderText = "Номер телефона";
                    metroGrid1.Columns["adress"].HeaderText = "Адрес проживания";
                    metroGrid1.Columns["id_position"].HeaderText = "Номер должности";
                    metroGrid1.Columns["login"].HeaderText = "Логин";
                    metroGrid1.Columns["password"].HeaderText = "Пароль";
                    bindingNavigator1.BindingSource = employeesBindingSource;
                    addToolStripMenuItem.Visible = true;
                    metroGrid1.ReadOnly = true;
                    break;
                case "goods":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Товары";
                    metroGrid1.DataSource = goodsBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["name_pr"].HeaderText = "Наименование товара";
                    metroGrid1.Columns["loc_product"].HeaderText = "Расположение товара";
                    metroGrid1.Columns["discount"].HeaderText = "Скидка";
                    metroGrid1.Columns["discnt_reason"].HeaderText = "Причина скидки";
                    metroGrid1.Columns["price"].HeaderText = "Цена";
                    metroGrid1.Columns["id_delivery"].HeaderText = "Номер поставки";
                    bindingNavigator1.BindingSource = goodsBindingSource;
                    metroGrid1.MultiSelect = false;
                    break;
                case "provider":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Поставщики";
                    metroGrid1.DataSource = providerBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["legal_address"].HeaderText = "Юр. адрес";
                    metroGrid1.Columns["tel_num"].HeaderText = "Номер телефона";
                    metroGrid1.Columns["name_org"].HeaderText = "Наименование организации";
                    bindingNavigator1.BindingSource = providerBindingSource;
                    metroGrid1.AllowUserToAddRows = true;
                    break;
                case "sales":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Продажи";
                    metroGrid1.DataSource = salesBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["type_sale"].HeaderText = "Тип покупки";
                    metroGrid1.Columns["id_receipt"].HeaderText = "Номер чека";
                    metroGrid1.Columns["id_product"].HeaderText = "Номер товара";
                    bindingNavigator1.BindingSource = salesBindingSource;
                    break;
                case "sales_receipt":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Чеки";
                    metroGrid1.DataSource = sales_receiptBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["date_buy"].HeaderText = "Дата покупки";
                    metroGrid1.Columns["id_client"].HeaderText = "Номер клиента";
                    metroGrid1.Columns["id_emp"].HeaderText = "Номер продавца";
                    bindingNavigator1.BindingSource = sales_receiptBindingSource;
                    break;
                case "clients":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Клиенты";
                    metroGrid1.DataSource = clientsBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["second_name"].HeaderText = "Фамилия";
                    metroGrid1.Columns["first_dad_name"].HeaderText = "Имя Отчество";
                    metroGrid1.Columns["date_birth"].HeaderText = "Дата рождения";
                    metroGrid1.Columns["tel_num"].HeaderText = "Номер телефона";
                    metroGrid1.Columns["adress"].HeaderText = "Адрес проживания";
                    metroGrid1.Columns["point_num"].HeaderText = "Количество баллов";
                    bindingNavigator1.BindingSource = clientsBindingSource;
                    addToolStripMenuItem.Visible = true;
                    break;
                case "positions":
                    switch (acc_cat)
                    {
                        case 1:

                            break;
                        case 2:
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:

                            break;
                    }
                    table_name.Text += " Должности";
                    metroGrid1.DataSource = positionsBindingSource;
                    metroGrid1.Columns["id"].Visible = false;
                    metroGrid1.Columns["job_title"].HeaderText = "Наименование должности";
                    metroGrid1.Columns["access_category"].HeaderText = "Уровень доступа";
                    metroGrid1.Columns["salary"].HeaderText = "Оклад";
                    metroGrid1.Columns["class"].HeaderText = "Разряд";
                    bindingNavigator1.BindingSource = positionsBindingSource;
                    metroGrid1.AllowUserToAddRows = true;
                    break;
            }

        }

        private void deleting_check() 
        {
            
            try
            {
                switch (tb)
                {
                    case "delivery":
                        deliveryTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "employees":
                           employeesTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "goods":
                        goodsTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "provider":
                        providerTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "sales":
                        salesTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "sales_receipt":
                        sales_receiptTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "clients":
                        clientsTableAdapter.Update(cSB_INCDataSet);
                        break;
                    case "positions":
                        positionsTableAdapter.Update(cSB_INCDataSet);
                        break;
                }
                metroGrid1.Refresh();
                MetroMessageBox.Show(this, "Успех", "Данные успешно обновлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                switch (tb)
                {
                    case "delivery":
                        MetroMessageBox.Show(this, "Запись не может быть удалена, так как к ней привазаны записи таблицы Товары", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroGrid1.DataSource = deliveryBindingSource;
                        break;
                    case "employees":
                        MetroMessageBox.Show(this, "Вы уверены, что хотите удалить выбранные записи?\n Они будут безвозвратно удалены", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        metroGrid1.DataSource = employeesBindingSource;
                        if (DialogResult == DialogResult.Yes)
                        {

                            MetroMessageBox.Show(this, "Успех", "Данные успешно обновлены", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (DialogResult == DialogResult.No)
                        {
                            MetroMessageBox.Show(this, "", "Операция отменена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "goods":
                        MetroMessageBox.Show(this, "Вы уверены, что хотите удалить записи, так как к ним привязаны другие данные, которые тоже будут удалены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        metroGrid1.DataSource = goodsBindingSource;
                        if (DialogResult == DialogResult.Yes)
                        {
                            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "delete_goods";
                            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                            cmd.Parameters["@id"].Value = metroGrid1.CurrentRow.Cells[0].Value;
                            MetroMessageBox.Show(this, "Успех", "Данные успешно обновлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (DialogResult == DialogResult.No)
                        {
                            MetroMessageBox.Show(this, "", "Операция отменена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "provider":
                        MetroMessageBox.Show(this, "Записи не могут быть удалены, так как к ним привязаны данные из таблицы Поставки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroGrid1.DataSource = providerBindingSource;
                        break;
                    case "sales_receipt":
                        MetroMessageBox.Show(this, "Записи не могут быть удалены, так как к ним привязаны данные из таблицы Продажи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroGrid1.DataSource = sales_receiptBindingSource;
                        break;
                    case "clients":
                        MetroMessageBox.Show(this, "Вы уверены, что хотите удалить данные? \nВсе чеки, которые привязаны к данному пользователю, отвяжутся", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        metroGrid1.DataSource = clientsBindingSource;
                        if (DialogResult == DialogResult.Yes)
                        {
                            MetroMessageBox.Show(this, "Успех", "Данные успешно обновлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (DialogResult == DialogResult.No)
                        {
                            MetroMessageBox.Show(this, "", "Операция отменена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case "positions":
                        MetroMessageBox.Show(this, "Некоторые сотрудники до сих пор имеют текущую должность, измените ее", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroGrid1.DataSource = positionsBindingSource;
                        break;
                }
                metroGrid1.Refresh();
            }
        }
        private void add_tables() 
        {
            switch (tb)
            {
                case "employees":
                    add_employees add_emp = new add_employees();
                    add_emp.Show();
                    break;
                case "clients":
                    add_clients add_cli = new add_clients();
                    add_cli.Show();
                    break;
            }
        }
        private void watch_tables_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
        private void quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            deleting_check();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleting_check();
            metroGrid1.Rows.RemoveAt(metroGrid1.CurrentRow.Index);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            deleting_check();
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
                metroGrid1.CurrentCell = metroGrid1[e.ColumnIndex, e.RowIndex];
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_tables();
            metroGrid1.Refresh();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            add_tables();
            metroGrid1.Refresh();
        }
    }
}
