namespace Kelompok_1__Program_Linear_
{
    partial class form_main
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
            this.txtbox_jumlahvariabel = new System.Windows.Forms.TextBox();
            this.txtbox_jumlahconstraint = new System.Windows.Forms.TextBox();
            this.btn_generatetable = new System.Windows.Forms.Button();
            this.datagrid_userinput = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.datagrid_useroutput = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_userinput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_useroutput)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbox_jumlahvariabel
            // 
            this.txtbox_jumlahvariabel.Location = new System.Drawing.Point(129, 45);
            this.txtbox_jumlahvariabel.Name = "txtbox_jumlahvariabel";
            this.txtbox_jumlahvariabel.Size = new System.Drawing.Size(42, 20);
            this.txtbox_jumlahvariabel.TabIndex = 0;
            // 
            // txtbox_jumlahconstraint
            // 
            this.txtbox_jumlahconstraint.Location = new System.Drawing.Point(129, 87);
            this.txtbox_jumlahconstraint.Name = "txtbox_jumlahconstraint";
            this.txtbox_jumlahconstraint.Size = new System.Drawing.Size(42, 20);
            this.txtbox_jumlahconstraint.TabIndex = 1;
            // 
            // btn_generatetable
            // 
            this.btn_generatetable.Location = new System.Drawing.Point(75, 134);
            this.btn_generatetable.Name = "btn_generatetable";
            this.btn_generatetable.Size = new System.Drawing.Size(96, 23);
            this.btn_generatetable.TabIndex = 2;
            this.btn_generatetable.Text = "Generate Table";
            this.btn_generatetable.UseVisualStyleBackColor = true;
            this.btn_generatetable.Click += new System.EventHandler(this.btn_generatetable_Click);
            // 
            // datagrid_userinput
            // 
            this.datagrid_userinput.AllowUserToAddRows = false;
            this.datagrid_userinput.AllowUserToDeleteRows = false;
            this.datagrid_userinput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_userinput.Location = new System.Drawing.Point(188, 12);
            this.datagrid_userinput.Name = "datagrid_userinput";
            this.datagrid_userinput.Size = new System.Drawing.Size(600, 226);
            this.datagrid_userinput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jumlah Variabel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jumlah Constraint";
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(713, 244);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate.TabIndex = 7;
            this.btn_calculate.Text = "Calculate";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // datagrid_useroutput
            // 
            this.datagrid_useroutput.AllowUserToAddRows = false;
            this.datagrid_useroutput.AllowUserToDeleteRows = false;
            this.datagrid_useroutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_useroutput.Location = new System.Drawing.Point(188, 273);
            this.datagrid_useroutput.Name = "datagrid_useroutput";
            this.datagrid_useroutput.Size = new System.Drawing.Size(600, 226);
            this.datagrid_useroutput.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 309);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.datagrid_useroutput);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagrid_userinput);
            this.Controls.Add(this.btn_generatetable);
            this.Controls.Add(this.txtbox_jumlahconstraint);
            this.Controls.Add(this.txtbox_jumlahvariabel);
            this.Name = "form_main";
            this.Text = "Kelompok 1";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_userinput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_useroutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox_jumlahvariabel;
        private System.Windows.Forms.TextBox txtbox_jumlahconstraint;
        private System.Windows.Forms.Button btn_generatetable;
        private System.Windows.Forms.DataGridView datagrid_userinput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.DataGridView datagrid_useroutput;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

