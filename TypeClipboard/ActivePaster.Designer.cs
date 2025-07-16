namespace TypeClipboard
{
    partial class ActivePaster
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
            textBox1 = new System.Windows.Forms.TextBox();
            Paste = new System.Windows.Forms.Button();
            chkHide = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(178, 23);
            textBox1.TabIndex = 0;
            // 
            // Paste
            // 
            Paste.Location = new System.Drawing.Point(196, 12);
            Paste.Name = "Paste";
            Paste.Size = new System.Drawing.Size(75, 23);
            Paste.TabIndex = 1;
            Paste.Text = "Paste";
            Paste.UseVisualStyleBackColor = true;
            Paste.Click += Paste_Click;
            // 
            // chkHide
            // 
            chkHide.AutoSize = true;
            chkHide.Location = new System.Drawing.Point(12, 41);
            chkHide.Name = "chkHide";
            chkHide.Size = new System.Drawing.Size(130, 19);
            chkHide.TabIndex = 12;
            chkHide.Text = "Hide Clipboard Text";
            chkHide.UseVisualStyleBackColor = true;
            chkHide.CheckedChanged += CBHide_CheckedChanged;
            // 
            // ActivePaster
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(278, 68);
            Controls.Add(chkHide);
            Controls.Add(Paste);
            Controls.Add(textBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Clip Typer";
            TopMost = true;
            Activated += Form1_Activated;
            Load += Form1_Load;
            Enter += Form1_Enter;
            MouseEnter += Form1_MouseEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Paste;
        private System.Windows.Forms.CheckBox chkHide;
    }
}