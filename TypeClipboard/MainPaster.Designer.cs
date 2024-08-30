namespace TypeClipboard
{
    partial class MainPaster
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            chkEnter = new CheckBox();
            toolTip1 = new ToolTip(components);
            hkBtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(230, 22);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(248, 12);
            button1.Name = "button1";
            button1.Size = new Size(85, 22);
            button1.TabIndex = 1;
            button1.Text = "Paste";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Paste_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 67);
            button2.Name = "button2";
            button2.Size = new Size(85, 22);
            button2.TabIndex = 4;
            button2.Text = "Paste";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BufferType_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(12, 67);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(230, 22);
            textBox2.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(12, 39);
            button3.Name = "button3";
            button3.Size = new Size(154, 22);
            button3.TabIndex = 6;
            button3.Text = "Copy clipboard to buffer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ToBuffer_Click;
            // 
            // chkEnter
            // 
            chkEnter.AutoSize = true;
            chkEnter.Location = new Point(248, 42);
            chkEnter.Name = "chkEnter";
            chkEnter.Size = new Size(85, 19);
            chkEnter.TabIndex = 7;
            chkEnter.Text = "Auto. Enter";
            toolTip1.SetToolTip(chkEnter, "If set, Type will type newline (\\n) as Enter, which is useful for large blobs of text.\r\n\r\nIf unset, Type will stop before the first newline, which is useful for passwords.");
            chkEnter.UseVisualStyleBackColor = true;
            chkEnter.CheckedChanged += CBEnter_CheckedChanged;
            // 
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            // 
            // hkBtn
            // 
            hkBtn.AccessibleName = "hkBtn";
            hkBtn.Location = new Point(167, 38);
            hkBtn.Name = "hkBtn";
            hkBtn.Size = new Size(75, 23);
            hkBtn.TabIndex = 8;
            hkBtn.Text = "Hotkey: F8";
            hkBtn.UseVisualStyleBackColor = true;
            hkBtn.Click += HotkeyBtn_Click;
            // 
            // MainPaster
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(345, 101);
            Controls.Add(hkBtn);
            Controls.Add(chkEnter);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainPaster";
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

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chkEnter;
        private System.Windows.Forms.ToolTip toolTip1;
        private Button hkBtn;
    }
}

