namespace StokTakipProgrami
{
    partial class HizliButonUrunEkle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.lbutonid = new System.Windows.Forms.Label();
            this.chtumu = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tUrunBul = new System.Windows.Forms.TextBox();
            this.gridhizliurun = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridhizliurun)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbutonid);
            this.splitContainer1.Panel1.Controls.Add(this.chtumu);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.tUrunBul);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridhizliurun);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 573);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buton numarası:";
            // 
            // lbutonid
            // 
            this.lbutonid.AutoSize = true;
            this.lbutonid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbutonid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbutonid.Location = new System.Drawing.Point(140, 47);
            this.lbutonid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbutonid.Name = "lbutonid";
            this.lbutonid.Size = new System.Drawing.Size(74, 20);
            this.lbutonid.TabIndex = 7;
            this.lbutonid.Text = "Buton no";
            // 
            // chtumu
            // 
            this.chtumu.AutoSize = true;
            this.chtumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chtumu.Location = new System.Drawing.Point(360, 8);
            this.chtumu.Name = "chtumu";
            this.chtumu.Size = new System.Drawing.Size(149, 24);
            this.chtumu.TabIndex = 6;
            this.chtumu.Text = "Tamamını Göster";
            this.chtumu.UseVisualStyleBackColor = true;
            this.chtumu.CheckedChanged += new System.EventHandler(this.chtumu_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(11, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ürün Bul";
            // 
            // tUrunBul
            // 
            this.tUrunBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tUrunBul.Location = new System.Drawing.Point(86, 6);
            this.tUrunBul.Margin = new System.Windows.Forms.Padding(2);
            this.tUrunBul.Name = "tUrunBul";
            this.tUrunBul.Size = new System.Drawing.Size(269, 26);
            this.tUrunBul.TabIndex = 4;
            this.tUrunBul.TextChanged += new System.EventHandler(this.tUrunBul_TextChanged);
            // 
            // gridhizliurun
            // 
            this.gridhizliurun.AllowUserToAddRows = false;
            this.gridhizliurun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridhizliurun.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridhizliurun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridhizliurun.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridhizliurun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridhizliurun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridhizliurun.EnableHeadersVisualStyles = false;
            this.gridhizliurun.Location = new System.Drawing.Point(0, 0);
            this.gridhizliurun.Margin = new System.Windows.Forms.Padding(0);
            this.gridhizliurun.Name = "gridhizliurun";
            this.gridhizliurun.RowHeadersVisible = false;
            this.gridhizliurun.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            this.gridhizliurun.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridhizliurun.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.gridhizliurun.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.gridhizliurun.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridhizliurun.RowTemplate.Height = 32;
            this.gridhizliurun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridhizliurun.Size = new System.Drawing.Size(1062, 458);
            this.gridhizliurun.TabIndex = 2;
            this.gridhizliurun.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridhizliurun_CellContentDoubleClick);
            // 
            // HizliButonUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1062, 573);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HizliButonUrunEkle";
            this.Text = "Hızlı Urun Ekleme";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridhizliurun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridhizliurun;
        private System.Windows.Forms.CheckBox chtumu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tUrunBul;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbutonid;
    }
}