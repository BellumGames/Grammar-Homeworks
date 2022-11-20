namespace WindowsFormsApplication1
{
    partial class Tables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private string N;
        private string T;
        System.Collections.Generic.List<Colection> P1 = new System.Collections.Generic.List<Colection>();
        System.Collections.Generic.List<DataStruct> P = new System.Collections.Generic.List<DataStruct>();
        System.Collections.Generic.List<Colection> F = new System.Collections.Generic.List<Colection>();
        Parser form = new Parser();

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(48, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(736, 451);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(137, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(301, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Action Tabel : TA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(435, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(301, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Jump Tabel : TS";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(80, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Status Number";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 514);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tables";
            this.Text = "Tables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tables_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}