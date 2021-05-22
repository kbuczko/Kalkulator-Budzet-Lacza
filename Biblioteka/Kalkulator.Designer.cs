namespace Biblioteka
{
    partial class Kalkulator
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
            this.CountButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewFSL = new System.Windows.Forms.DataGridView();
            this.textBoxFSL = new System.Windows.Forms.TextBox();
            this.dataGridViewMoc = new System.Windows.Forms.DataGridView();
            this.textBoxMOC = new System.Windows.Forms.TextBox();
            this.textBoxZN = new System.Windows.Forms.TextBox();
            this.dataGridViewZN = new System.Windows.Forms.DataGridView();
            this.textBoxTN = new System.Windows.Forms.TextBox();
            this.dataGridViewTN = new System.Windows.Forms.DataGridView();
            this.textBoxZO = new System.Windows.Forms.TextBox();
            this.dataGridViewZO = new System.Windows.Forms.DataGridView();
            this.textBoxTO = new System.Windows.Forms.TextBox();
            this.dataGridViewTO = new System.Windows.Forms.DataGridView();
            this.ClearButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTO)).BeginInit();
            this.SuspendLayout();
            // 
            // CountButton
            // 
            this.CountButton.Location = new System.Drawing.Point(698, 431);
            this.CountButton.Name = "CountButton";
            this.CountButton.Size = new System.Drawing.Size(75, 23);
            this.CountButton.TabIndex = 0;
            this.CountButton.Text = "Oblicz";
            this.CountButton.UseVisualStyleBackColor = true;
            this.CountButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(468, 434);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Moc Nadajnika";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zysk Nadajnika";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tłumienność Nadajnika";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "FSL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Zysk Odbiornika";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tłumienność Odbiornika";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Typ Modelu";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(122, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "z przeszkodami";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Budżet Łącza";
            // 
            // dataGridViewFSL
            // 
            this.dataGridViewFSL.AllowUserToAddRows = false;
            this.dataGridViewFSL.AllowUserToDeleteRows = false;
            this.dataGridViewFSL.AllowUserToResizeColumns = false;
            this.dataGridViewFSL.AllowUserToResizeRows = false;
            this.dataGridViewFSL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFSL.Location = new System.Drawing.Point(752, 61);
            this.dataGridViewFSL.MultiSelect = false;
            this.dataGridViewFSL.Name = "dataGridViewFSL";
            this.dataGridViewFSL.ReadOnly = true;
            this.dataGridViewFSL.RowHeadersVisible = false;
            this.dataGridViewFSL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewFSL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewFSL.Size = new System.Drawing.Size(131, 89);
            this.dataGridViewFSL.TabIndex = 13;
            this.dataGridViewFSL.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFSL_CellDoubleClick);
            // 
            // textBoxFSL
            // 
            this.textBoxFSL.Location = new System.Drawing.Point(635, 61);
            this.textBoxFSL.Name = "textBoxFSL";
            this.textBoxFSL.Size = new System.Drawing.Size(100, 20);
            this.textBoxFSL.TabIndex = 12;
            this.textBoxFSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxFSL_KeyPress);
            // 
            // dataGridViewMoc
            // 
            this.dataGridViewMoc.AllowUserToAddRows = false;
            this.dataGridViewMoc.AllowUserToDeleteRows = false;
            this.dataGridViewMoc.AllowUserToResizeColumns = false;
            this.dataGridViewMoc.AllowUserToResizeRows = false;
            this.dataGridViewMoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMoc.Location = new System.Drawing.Point(310, 61);
            this.dataGridViewMoc.MultiSelect = false;
            this.dataGridViewMoc.Name = "dataGridViewMoc";
            this.dataGridViewMoc.ReadOnly = true;
            this.dataGridViewMoc.RowHeadersVisible = false;
            this.dataGridViewMoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewMoc.Size = new System.Drawing.Size(130, 89);
            this.dataGridViewMoc.TabIndex = 14;
            this.dataGridViewMoc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMoc_CellDoubleClick);
            // 
            // textBoxMOC
            // 
            this.textBoxMOC.Location = new System.Drawing.Point(193, 61);
            this.textBoxMOC.Name = "textBoxMOC";
            this.textBoxMOC.Size = new System.Drawing.Size(100, 20);
            this.textBoxMOC.TabIndex = 15;
            this.textBoxMOC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxMOC_KeyPress);
            // 
            // textBoxZN
            // 
            this.textBoxZN.Location = new System.Drawing.Point(193, 165);
            this.textBoxZN.Name = "textBoxZN";
            this.textBoxZN.Size = new System.Drawing.Size(100, 20);
            this.textBoxZN.TabIndex = 17;
            this.textBoxZN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxZN_KeyPress);
            // 
            // dataGridViewZN
            // 
            this.dataGridViewZN.AllowUserToAddRows = false;
            this.dataGridViewZN.AllowUserToDeleteRows = false;
            this.dataGridViewZN.AllowUserToResizeColumns = false;
            this.dataGridViewZN.AllowUserToResizeRows = false;
            this.dataGridViewZN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZN.Location = new System.Drawing.Point(310, 165);
            this.dataGridViewZN.MultiSelect = false;
            this.dataGridViewZN.Name = "dataGridViewZN";
            this.dataGridViewZN.ReadOnly = true;
            this.dataGridViewZN.RowHeadersVisible = false;
            this.dataGridViewZN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewZN.Size = new System.Drawing.Size(130, 89);
            this.dataGridViewZN.TabIndex = 16;
            this.dataGridViewZN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewZN_CellDoubleClick);
            // 
            // textBoxTN
            // 
            this.textBoxTN.Location = new System.Drawing.Point(193, 269);
            this.textBoxTN.Name = "textBoxTN";
            this.textBoxTN.Size = new System.Drawing.Size(100, 20);
            this.textBoxTN.TabIndex = 19;
            this.textBoxTN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxTN_KeyPress);
            // 
            // dataGridViewTN
            // 
            this.dataGridViewTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTN.Location = new System.Drawing.Point(310, 269);
            this.dataGridViewTN.Name = "dataGridViewTN";
            this.dataGridViewTN.Size = new System.Drawing.Size(130, 89);
            this.dataGridViewTN.TabIndex = 18;
            // 
            // textBoxZO
            // 
            this.textBoxZO.Location = new System.Drawing.Point(636, 165);
            this.textBoxZO.Name = "textBoxZO";
            this.textBoxZO.Size = new System.Drawing.Size(100, 20);
            this.textBoxZO.TabIndex = 21;
            this.textBoxZO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxZO_KeyPress);
            // 
            // dataGridViewZO
            // 
            this.dataGridViewZO.AllowUserToAddRows = false;
            this.dataGridViewZO.AllowUserToDeleteRows = false;
            this.dataGridViewZO.AllowUserToResizeColumns = false;
            this.dataGridViewZO.AllowUserToResizeRows = false;
            this.dataGridViewZO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZO.Location = new System.Drawing.Point(753, 165);
            this.dataGridViewZO.MultiSelect = false;
            this.dataGridViewZO.Name = "dataGridViewZO";
            this.dataGridViewZO.ReadOnly = true;
            this.dataGridViewZO.RowHeadersVisible = false;
            this.dataGridViewZO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewZO.Size = new System.Drawing.Size(130, 89);
            this.dataGridViewZO.TabIndex = 20;
            this.dataGridViewZO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewZO_CellDoubleClick);
            // 
            // textBoxTO
            // 
            this.textBoxTO.Location = new System.Drawing.Point(635, 269);
            this.textBoxTO.Name = "textBoxTO";
            this.textBoxTO.Size = new System.Drawing.Size(101, 20);
            this.textBoxTO.TabIndex = 23;
            this.textBoxTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxTO_KeyPress);
            // 
            // dataGridViewTO
            // 
            this.dataGridViewTO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTO.Location = new System.Drawing.Point(752, 269);
            this.dataGridViewTO.Name = "dataGridViewTO";
            this.dataGridViewTO.Size = new System.Drawing.Size(131, 89);
            this.dataGridViewTO.TabIndex = 22;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(799, 431);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 24;
            this.ClearButton.Text = "Wyczyść";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(881, 473);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 25;
            this.QuitButton.Text = "Wyjdź";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // Kalkulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 534);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.textBoxTO);
            this.Controls.Add(this.dataGridViewTO);
            this.Controls.Add(this.textBoxZO);
            this.Controls.Add(this.dataGridViewZO);
            this.Controls.Add(this.textBoxTN);
            this.Controls.Add(this.dataGridViewTN);
            this.Controls.Add(this.textBoxZN);
            this.Controls.Add(this.dataGridViewZN);
            this.Controls.Add(this.textBoxMOC);
            this.Controls.Add(this.dataGridViewMoc);
            this.Controls.Add(this.textBoxFSL);
            this.Controls.Add(this.dataGridViewFSL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CountButton);
            this.Name = "Kalkulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kalkulator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CountButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewFSL;
        private System.Windows.Forms.TextBox textBoxFSL;
        private System.Windows.Forms.DataGridView dataGridViewMoc;
        private System.Windows.Forms.TextBox textBoxMOC;
        private System.Windows.Forms.TextBox textBoxZN;
        private System.Windows.Forms.DataGridView dataGridViewZN;
        private System.Windows.Forms.TextBox textBoxTN;
        private System.Windows.Forms.DataGridView dataGridViewTN;
        private System.Windows.Forms.TextBox textBoxZO;
        private System.Windows.Forms.DataGridView dataGridViewZO;
        private System.Windows.Forms.TextBox textBoxTO;
        private System.Windows.Forms.DataGridView dataGridViewTO;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button QuitButton;
    }
}