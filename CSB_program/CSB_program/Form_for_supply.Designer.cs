namespace CSB_program
{
    partial class form_for_supply
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_for_supply));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tov_name = new System.Windows.Forms.TextBox();
            this.tov_count = new System.Windows.Forms.TextBox();
            this.price_text = new System.Windows.Forms.TextBox();
            this.combobox_provider = new MetroFramework.Controls.MetroComboBox();
            this.date_delivery = new MetroFramework.Controls.MetroDateTime();
            this.date_order = new MetroFramework.Controls.MetroDateTime();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.horline = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.cSB_INCDataSet = new CSB_program.CSB_INCDataSet();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeesTableAdapter = new CSB_program.CSB_INCDataSetTableAdapters.employeesTableAdapter();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.horline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование товара:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество товара:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Цена товара (руб.):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата поставки:";
            // 
            // tov_name
            // 
            this.tov_name.Location = new System.Drawing.Point(216, 105);
            this.tov_name.Name = "tov_name";
            this.tov_name.Size = new System.Drawing.Size(380, 27);
            this.tov_name.TabIndex = 4;
            // 
            // tov_count
            // 
            this.tov_count.Location = new System.Drawing.Point(216, 145);
            this.tov_count.Name = "tov_count";
            this.tov_count.Size = new System.Drawing.Size(146, 27);
            this.tov_count.TabIndex = 5;
            // 
            // price_text
            // 
            this.price_text.Location = new System.Drawing.Point(216, 185);
            this.price_text.Name = "price_text";
            this.price_text.Size = new System.Drawing.Size(189, 27);
            this.price_text.TabIndex = 6;
            // 
            // combobox_provider
            // 
            this.combobox_provider.FormattingEnabled = true;
            this.combobox_provider.ItemHeight = 23;
            this.combobox_provider.Location = new System.Drawing.Point(216, 315);
            this.combobox_provider.Name = "combobox_provider";
            this.combobox_provider.Size = new System.Drawing.Size(200, 29);
            this.combobox_provider.TabIndex = 7;
            this.combobox_provider.UseSelectable = true;
            // 
            // date_delivery
            // 
            this.date_delivery.Location = new System.Drawing.Point(216, 268);
            this.date_delivery.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_delivery.Name = "date_delivery";
            this.date_delivery.Size = new System.Drawing.Size(200, 29);
            this.date_delivery.TabIndex = 8;
            // 
            // date_order
            // 
            this.date_order.Location = new System.Drawing.Point(216, 223);
            this.date_order.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_order.Name = "date_order";
            this.date_order.Size = new System.Drawing.Size(200, 29);
            this.date_order.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата заказа:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Поставщик:";
            // 
            // horline
            // 
            this.horline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.horline.Location = new System.Drawing.Point(-11, 65);
            this.horline.Name = "horline";
            this.horline.Size = new System.Drawing.Size(631, 10);
            this.horline.TabIndex = 12;
            this.horline.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 24F);
            this.label7.Location = new System.Drawing.Point(5, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(431, 38);
            this.label7.TabIndex = 13;
            this.label7.Text = "Внесение товаров в базу";
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.submit.FlatAppearance.BorderSize = 2;
            this.submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit.Location = new System.Drawing.Point(107, 361);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(139, 39);
            this.submit.TabIndex = 14;
            this.submit.Text = "Записать";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // cSB_INCDataSet
            // 
            this.cSB_INCDataSet.DataSetName = "CSB_INCDataSet";
            this.cSB_INCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "employees";
            this.employeesBindingSource.DataSource = this.cSB_INCDataSet;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.cancel.FlatAppearance.BorderSize = 2;
            this.cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(277, 361);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(139, 39);
            this.cancel.TabIndex = 15;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // form_for_supply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 431);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horline);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.date_order);
            this.Controls.Add(this.date_delivery);
            this.Controls.Add(this.combobox_provider);
            this.Controls.Add(this.price_text);
            this.Controls.Add(this.tov_count);
            this.Controls.Add(this.tov_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "form_for_supply";
            this.Padding = new System.Windows.Forms.Padding(33, 83, 33, 28);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.form_for_supply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.horline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tov_name;
        private System.Windows.Forms.TextBox tov_count;
        private System.Windows.Forms.TextBox price_text;
        private MetroFramework.Controls.MetroComboBox combobox_provider;
        private MetroFramework.Controls.MetroDateTime date_delivery;
        private MetroFramework.Controls.MetroDateTime date_order;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox horline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button submit;
        private CSB_INCDataSet cSB_INCDataSet;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private CSB_INCDataSetTableAdapters.employeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.Button cancel;
    }
}