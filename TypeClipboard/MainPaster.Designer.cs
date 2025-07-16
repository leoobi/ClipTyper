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
            chkHide = new CheckBox();
            toolTip1 = new ToolTip(components);
            pasteHKBtn = new Button();
            cancelHKBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(12, 30);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(230, 22);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(248, 30);
            button1.Name = "button1";
            button1.Size = new Size(85, 22);
            button1.TabIndex = 1;
            button1.Text = "Paste";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Paste_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 147);
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
            textBox2.Location = new Point(12, 147);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(230, 22);
            textBox2.TabIndex = 5;
            // 
            // button3
            // 
            button3.AccessibleName = "c2bHKBtn";
            button3.Location = new Point(12, 87);
            button3.Name = "button3";
            button3.Size = new Size(155, 22);
            button3.TabIndex = 6;
            button3.Text = "Copy clipboard to buffer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ToBuffer_Click;
            // 
            // chkEnter
            // 
            chkEnter.AutoSize = true;
            chkEnter.Location = new Point(248, 87);
            chkEnter.Name = "chkEnter";
            chkEnter.Size = new Size(85, 19);
            chkEnter.TabIndex = 7;
            chkEnter.Text = "Auto. Enter";
            toolTip1.SetToolTip(chkEnter, "If set, Type will type newline (\\n) as Enter, which is useful for large blobs of text.\r\n\r\nIf unset, Type will stop before the first newline, which is useful for passwords.");
            chkEnter.UseVisualStyleBackColor = true;
            chkEnter.CheckedChanged += CBEnter_CheckedChanged;

            // chkHide
            //
            chkHide.AutoSize = true;
            chkHide.Location = new Point(248, 112);
            chkHide.Name = "chkHide";
            chkHide.Size = new Size(88, 19);
            chkHide.TabIndex = 12;
            chkHide.Text = "Hide text";
            chkHide.UseVisualStyleBackColor = true;
            chkHide.CheckedChanged += CBHide_CheckedChanged;

            //
            // toolTip1
            // 
            toolTip1.ShowAlways = true;
            // 
            // pasteHKBtn
            // 
            pasteHKBtn.AccessibleName = "";
            pasteHKBtn.Location = new Point(12, 58);
            pasteHKBtn.Name = "pasteHKBtn";
            pasteHKBtn.Size = new Size(155, 23);
            pasteHKBtn.TabIndex = 8;
            pasteHKBtn.Text = "Paste Hotkey: F8";
            pasteHKBtn.UseVisualStyleBackColor = true;
            pasteHKBtn.Click += Paste_HK_Btn_Click;
            // 
            // cancelHKBtn
            // 
            cancelHKBtn.AccessibleName = "";
            cancelHKBtn.Location = new Point(178, 58);
            cancelHKBtn.Name = "cancelHKBtn";
            cancelHKBtn.Size = new Size(155, 23);
            cancelHKBtn.TabIndex = 9;
            cancelHKBtn.Text = "Cancel Hotkey: F7";
            cancelHKBtn.UseVisualStyleBackColor = true;
            cancelHKBtn.Click += Cancel_HK_Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 10;
            label1.Text = "Clipboard Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 129);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 11;
            label2.Text = "Buffer Text";
            // 
            // MainPaster
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(345, 183);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelHKBtn);
            Controls.Add(pasteHKBtn);
            Controls.Add(chkHide);
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
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.ToolTip toolTip1;
        private Button pasteHKBtn;
        private Button cancelHKBtn;
        private Label label1;
        private Label label2;
    }
}

