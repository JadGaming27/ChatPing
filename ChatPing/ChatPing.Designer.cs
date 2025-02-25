namespace ChatPing
{
    partial class ChatPing
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            listBox1 = new ListBox();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 27);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(241, 162);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 196);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Type a message . . .";
            textBox2.Size = new Size(160, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyDown += textBox2_KeyDown;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(178, 196);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(276, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 79);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(276, 9);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 4;
            label1.Text = "Devices :";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(276, 112);
            button2.Name = "button2";
            button2.Size = new Size(120, 23);
            button2.TabIndex = 5;
            button2.Text = "Ping!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 6;
            label2.Text = "Chat Log :";
            // 
            // button3
            // 
            button3.Location = new Point(276, 196);
            button3.Name = "button3";
            button3.Size = new Size(120, 23);
            button3.TabIndex = 7;
            button3.Text = "Connect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(276, 138);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 8;
            label3.Text = "IP :";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(276, 156);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "IP Address";
            textBox3.Size = new Size(120, 23);
            textBox3.TabIndex = 9;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // ChatPing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 231);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MaximumSize = new Size(424, 270);
            MinimumSize = new Size(424, 270);
            Name = "ChatPing";
            Text = "Chat Ping";
            Load += ChatPing_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private Button button2;
        private Label label2;
        private Button button3;
        private Label label3;
        private TextBox textBox3;
    }
}
