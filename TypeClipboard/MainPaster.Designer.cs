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
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            textBox2 = new System.Windows.Forms.TextBox();
            button3 = new System.Windows.Forms.Button();
            chkEnter = new System.Windows.Forms.CheckBox();
            chkHide = new System.Windows.Forms.CheckBox();
            pasteHKBtn = new System.Windows.Forms.Button();
            cancelHKBtn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            textBox1.Location = new System.Drawing.Point(12, 30);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(230, 22);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(248, 30);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(85, 22);
            button1.TabIndex = 1;
            button1.Text = "Paste";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Paste_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(248, 110);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(85, 22);
            button2.TabIndex = 4;
            button2.Text = "Paste";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BufferType_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            textBox2.Location = new System.Drawing.Point(12, 110);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(230, 22);
            textBox2.TabIndex = 5;
            // 
            // button3
            // 
            button3.AccessibleName = "c2bHKBtn";
            button3.Location = new System.Drawing.Point(12, 58);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(155, 22);
            button3.TabIndex = 6;
            button3.Text = "Copy clipboard to buffer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ToBuffer_Click;
            // 
            // chkEnter
            // 
            chkEnter.AutoSize = true;
            chkEnter.Location = new System.Drawing.Point(12, 210);
            chkEnter.Name = "chkEnter";
            chkEnter.Size = new System.Drawing.Size(85, 19);
            chkEnter.TabIndex = 7;
            chkEnter.Text = "Auto. Enter";
            chkEnter.UseVisualStyleBackColor = true;
            chkEnter.CheckedChanged += CBEnter_CheckedChanged;
            // 
            // chkHide
            // 
            chkHide.AutoSize = true;
            chkHide.Location = new System.Drawing.Point(103, 210);
            chkHide.Name = "chkHide";
            chkHide.Size = new System.Drawing.Size(130, 19);
            chkHide.TabIndex = 12;
            chkHide.Text = "Hide Clipboard Text";
            chkHide.UseVisualStyleBackColor = true;
            chkHide.CheckedChanged += CBHide_CheckedChanged;
            // 
            // pasteHKBtn
            // 
            pasteHKBtn.AccessibleName = "";
            pasteHKBtn.Location = new System.Drawing.Point(12, 176);
            pasteHKBtn.Name = "pasteHKBtn";
            pasteHKBtn.Size = new System.Drawing.Size(155, 23);
            pasteHKBtn.TabIndex = 8;
            pasteHKBtn.Text = "Paste Hotkey: F8";
            pasteHKBtn.UseVisualStyleBackColor = true;
            pasteHKBtn.Click += Paste_HK_Btn_Click;
            // 
            // cancelHKBtn
            // 
            cancelHKBtn.AccessibleName = "";
            cancelHKBtn.Location = new System.Drawing.Point(178, 176);
            cancelHKBtn.Name = "cancelHKBtn";
            cancelHKBtn.Size = new System.Drawing.Size(155, 23);
            cancelHKBtn.TabIndex = 9;
            cancelHKBtn.Text = "Cancel Hotkey: F7";
            cancelHKBtn.UseVisualStyleBackColor = true;
            cancelHKBtn.Click += Cancel_HK_Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(87, 15);
            label1.TabIndex = 10;
            label1.Text = "Clipboard Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label2.Location = new System.Drawing.Point(12, 92);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 11;
            label2.Text = "Buffer Text";
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(12, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 23);
            label3.TabIndex = 13;
            label3.Text = "Options";
            // 
            // MainPaster
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(345, 241);
            Controls.Add(label3);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Text = "Clip Typer";
            TopMost = true;
            Activated += Form1_Activated;
            Load += Form1_Load;
            Enter += Form1_Enter;
            MouseEnter += Form1_MouseEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label3;

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chkEnter;
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.Button pasteHKBtn;
        private System.Windows.Forms.Button cancelHKBtn;
        private Label label1;
        private System.Windows.Forms.Label label2;
    }
}

