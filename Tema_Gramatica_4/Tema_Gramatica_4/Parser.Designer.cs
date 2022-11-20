
namespace WindowsFormsApplication1
{
    partial class Parser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Collections.Generic.List<DataStruct> list = new System.Collections.Generic.List<DataStruct>();
        private System.Collections.Generic.List<Actions> list_actiuni = new System.Collections.Generic.List<Actions>();
        private System.Collections.Generic.List<Jump> list_salt = new System.Collections.Generic.List<Jump>();

        private string result = "";
        private bool r = false;
        private bool d = false;
        private int nr = 1;
        private int counter = 0;
        private string text = "";
        private static string path = InternalDefines.initial_path;
        private string Terminals;
        private string Neterminals;
        private string S;
        System.Collections.Generic.List<Colection> Production = new System.Collections.Generic.List<Colection>();
        System.Collections.Generic.List<System.Collections.Generic.List<DataStruct>> c = new System.Collections.Generic.List<System.Collections.Generic.List<DataStruct>>();

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
            this.lStack = new System.Windows.Forms.Label();
            this.lInput_Word = new System.Windows.Forms.Label();
            this.lAction = new System.Windows.Forms.Label();
            this.tStack = new System.Windows.Forms.TextBox();
            this.tInput_Word = new System.Windows.Forms.TextBox();
            this.tAction = new System.Windows.Forms.TextBox();
            this.lProduction = new System.Windows.Forms.Label();
            this.tProduction = new System.Windows.Forms.TextBox();
            this.tInput = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.IInput = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.tBrowse = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnTabel = new System.Windows.Forms.Button();
            this.tThing = new System.Windows.Forms.TextBox();
            this.IThing = new System.Windows.Forms.Label();
            this.IPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lStack
            // 
            this.lStack.AutoSize = true;
            this.lStack.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStack.Location = new System.Drawing.Point(193, 17);
            this.lStack.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStack.Name = "lStack";
            this.lStack.Size = new System.Drawing.Size(54, 22);
            this.lStack.TabIndex = 14;
            this.lStack.Text = "Stack";
            this.lStack.Click += new System.EventHandler(this.lStack_Click);
            // 
            // lInput_Word
            // 
            this.lInput_Word.AutoSize = true;
            this.lInput_Word.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInput_Word.Location = new System.Drawing.Point(314, 17);
            this.lInput_Word.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInput_Word.Name = "lInput_Word";
            this.lInput_Word.Size = new System.Drawing.Size(104, 22);
            this.lInput_Word.TabIndex = 15;
            this.lInput_Word.Text = "Input Word";
            // 
            // lAction
            // 
            this.lAction.AutoSize = true;
            this.lAction.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAction.Location = new System.Drawing.Point(472, 17);
            this.lAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAction.Name = "lAction";
            this.lAction.Size = new System.Drawing.Size(63, 22);
            this.lAction.TabIndex = 16;
            this.lAction.Text = "Action";
            // 
            // tStack
            // 
            this.tStack.BackColor = System.Drawing.Color.GhostWhite;
            this.tStack.Location = new System.Drawing.Point(156, 41);
            this.tStack.Margin = new System.Windows.Forms.Padding(2);
            this.tStack.Multiline = true;
            this.tStack.Name = "tStack";
            this.tStack.ReadOnly = true;
            this.tStack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tStack.Size = new System.Drawing.Size(132, 350);
            this.tStack.TabIndex = 18;
            // 
            // tInput_Word
            // 
            this.tInput_Word.BackColor = System.Drawing.Color.GhostWhite;
            this.tInput_Word.Location = new System.Drawing.Point(297, 41);
            this.tInput_Word.Margin = new System.Windows.Forms.Padding(2);
            this.tInput_Word.Multiline = true;
            this.tInput_Word.Name = "tInput_Word";
            this.tInput_Word.ReadOnly = true;
            this.tInput_Word.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tInput_Word.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tInput_Word.Size = new System.Drawing.Size(132, 350);
            this.tInput_Word.TabIndex = 19;
            // 
            // tAction
            // 
            this.tAction.BackColor = System.Drawing.Color.GhostWhite;
            this.tAction.Location = new System.Drawing.Point(437, 41);
            this.tAction.Margin = new System.Windows.Forms.Padding(2);
            this.tAction.Multiline = true;
            this.tAction.Name = "tAction";
            this.tAction.ReadOnly = true;
            this.tAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tAction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tAction.Size = new System.Drawing.Size(132, 350);
            this.tAction.TabIndex = 20;
            // 
            // lProduction
            // 
            this.lProduction.AutoSize = true;
            this.lProduction.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProduction.Location = new System.Drawing.Point(24, 17);
            this.lProduction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lProduction.Name = "lProduction";
            this.lProduction.Size = new System.Drawing.Size(101, 22);
            this.lProduction.TabIndex = 23;
            this.lProduction.Text = "Production";
            // 
            // tProduction
            // 
            this.tProduction.BackColor = System.Drawing.Color.GhostWhite;
            this.tProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tProduction.Location = new System.Drawing.Point(11, 41);
            this.tProduction.Margin = new System.Windows.Forms.Padding(2);
            this.tProduction.Multiline = true;
            this.tProduction.Name = "tProduction";
            this.tProduction.ReadOnly = true;
            this.tProduction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tProduction.Size = new System.Drawing.Size(132, 350);
            this.tProduction.TabIndex = 24;
            this.tProduction.TextChanged += new System.EventHandler(this.tProduction_TextChanged);
            // 
            // tInput
            // 
            this.tInput.Location = new System.Drawing.Point(86, 408);
            this.tInput.Margin = new System.Windows.Forms.Padding(2);
            this.tInput.Name = "tInput";
            this.tInput.Size = new System.Drawing.Size(93, 20);
            this.tInput.TabIndex = 13;
            this.tInput.Text = "a+a*a";
            this.tInput.TextChanged += new System.EventHandler(this.tInput_TextChanged);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Lavender;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(196, 405);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(92, 25);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // IInput
            // 
            this.IInput.AutoSize = true;
            this.IInput.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IInput.Location = new System.Drawing.Point(24, 406);
            this.IInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IInput.Name = "IInput";
            this.IInput.Size = new System.Drawing.Size(58, 22);
            this.IInput.TabIndex = 21;
            this.IInput.Text = "Input:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Lavender;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(297, 440);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 25);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tBrowse
            // 
            this.tBrowse.Location = new System.Drawing.Point(86, 440);
            this.tBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.tBrowse.Name = "tBrowse";
            this.tBrowse.Size = new System.Drawing.Size(93, 20);
            this.tBrowse.TabIndex = 27;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Lavender;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(297, 404);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 25);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTabel
            // 
            this.btnTabel.BackColor = System.Drawing.Color.Lavender;
            this.btnTabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabel.Location = new System.Drawing.Point(197, 440);
            this.btnTabel.Margin = new System.Windows.Forms.Padding(2);
            this.btnTabel.Name = "btnTabel";
            this.btnTabel.Size = new System.Drawing.Size(92, 25);
            this.btnTabel.TabIndex = 29;
            this.btnTabel.Text = "Tabel";
            this.btnTabel.UseVisualStyleBackColor = false;
            this.btnTabel.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // tThing
            // 
            this.tThing.BackColor = System.Drawing.Color.GhostWhite;
            this.tThing.Location = new System.Drawing.Point(585, 41);
            this.tThing.Margin = new System.Windows.Forms.Padding(2);
            this.tThing.Multiline = true;
            this.tThing.Name = "tThing";
            this.tThing.ReadOnly = true;
            this.tThing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tThing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tThing.Size = new System.Drawing.Size(365, 350);
            this.tThing.TabIndex = 30;
            this.tThing.TextChanged += new System.EventHandler(this.stackText_TextChanged);
            // 
            // IThing
            // 
            this.IThing.AutoSize = true;
            this.IThing.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IThing.Location = new System.Drawing.Point(655, 17);
            this.IThing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IThing.Name = "IThing";
            this.IThing.Size = new System.Drawing.Size(230, 22);
            this.IThing.TabIndex = 31;
            this.IThing.Text = "Code Gen and Stack Action";
            this.IThing.Click += new System.EventHandler(this.label1_Click);
            // 
            // IPath
            // 
            this.IPath.AutoSize = true;
            this.IPath.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPath.Location = new System.Drawing.Point(30, 438);
            this.IPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IPath.Name = "IPath";
            this.IPath.Size = new System.Drawing.Size(52, 22);
            this.IPath.TabIndex = 32;
            this.IPath.Text = "Path:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(961, 488);
            this.Controls.Add(this.IPath);
            this.Controls.Add(this.IThing);
            this.Controls.Add(this.tThing);
            this.Controls.Add(this.btnTabel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tBrowse);
            this.Controls.Add(this.tProduction);
            this.Controls.Add(this.lProduction);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.IInput);
            this.Controls.Add(this.tAction);
            this.Controls.Add(this.tInput_Word);
            this.Controls.Add(this.tStack);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lAction);
            this.Controls.Add(this.lInput_Word);
            this.Controls.Add(this.lStack);
            this.Controls.Add(this.tInput);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(671, 349);
            this.Name = "Form1";
            this.Text = "Tema_Golomety_4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lStack;
        private System.Windows.Forms.Label lInput_Word;
        private System.Windows.Forms.Label lAction;
        private System.Windows.Forms.TextBox tStack;
        private System.Windows.Forms.TextBox tInput_Word;
        private System.Windows.Forms.TextBox tAction;
        private System.Windows.Forms.Label lProduction;
        private System.Windows.Forms.TextBox tProduction;
        private System.Windows.Forms.TextBox tInput;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label IInput;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tBrowse;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTabel;
        private System.Windows.Forms.TextBox tThing;
        private System.Windows.Forms.Label IThing;
        private System.Windows.Forms.Label IPath;
    }
}

