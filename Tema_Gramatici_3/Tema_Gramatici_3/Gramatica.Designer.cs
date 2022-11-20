
namespace WindowsFormsApplication1
{
    partial class Gramatica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Collections.Generic.List<DataStruct> Productions = new System.Collections.Generic.List<DataStruct>();
        private System.Collections.Generic.List<Action> action_list = new System.Collections.Generic.List<Action>();
        private System.Collections.Generic.List<Jump> jump_list = new System.Collections.Generic.List<Jump>();

        private string result = "";
        private bool r = false;
        
        private int nr = 1;
        private int ct = 0;
        private string text = "";
        private static string path = InternalDefinitions.path;
        private string Terminals;
        private string Neterminals;
        private string S;
        System.Collections.Generic.List<Colection> f = new System.Collections.Generic.List<Colection>();
        System.Collections.Generic.List<System.Collections.Generic.List<DataStruct>> Collections = new System.Collections.Generic.List<System.Collections.Generic.List<DataStruct>>();

        private int count = 0;
        private string stiva = "0 ";
        private string input = "&";

        private System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
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
            this.lProductii = new System.Windows.Forms.Label();
            this.tProd = new System.Windows.Forms.TextBox();
            this.btnTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lProductii
            // 
            this.lProductii.AutoSize = true;
            this.lProductii.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProductii.Location = new System.Drawing.Point(114, 9);
            this.lProductii.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lProductii.Name = "lProductii";
            this.lProductii.Size = new System.Drawing.Size(114, 22);
            this.lProductii.TabIndex = 23;
            this.lProductii.Text = "Productions:";
            // 
            // tProd
            // 
            this.tProd.BackColor = System.Drawing.Color.GhostWhite;
            this.tProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tProd.Location = new System.Drawing.Point(15, 33);
            this.tProd.Margin = new System.Windows.Forms.Padding(2);
            this.tProd.Multiline = true;
            this.tProd.Name = "tProd";
            this.tProd.ReadOnly = true;
            this.tProd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tProd.Size = new System.Drawing.Size(317, 284);
            this.tProd.TabIndex = 24;
            this.tProd.TextChanged += new System.EventHandler(this.tProd_TextChanged);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.Lavender;
            this.btnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.Location = new System.Drawing.Point(95, 321);
            this.btnTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(133, 43);
            this.btnTable.TabIndex = 29;
            this.btnTable.Text = "Show Tables";
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // Gramatica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(370, 375);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.tProd);
            this.Controls.Add(this.lProductii);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Gramatica";
            this.Text = "Tema_Gramatici_3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lProductii;
        private System.Windows.Forms.TextBox tProd;
        private System.Windows.Forms.Button btnTable;
    }
}

