namespace Currency_Converter___Win_Forms_.Net8___Eng_Maged_Ali
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            flpCurrencies = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(529, 489);
            button1.Name = "button1";
            button1.Size = new Size(478, 156);
            button1.TabIndex = 4;
            button1.Text = "Get Exchange Rates For Selected Currencies";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(9, 489);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(478, 156);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // flpCurrencies
            // 
            flpCurrencies.AutoScroll = true;
            flpCurrencies.BorderStyle = BorderStyle.FixedSingle;
            flpCurrencies.Dock = DockStyle.Top;
            flpCurrencies.Location = new Point(0, 0);
            flpCurrencies.Name = "flpCurrencies";
            flpCurrencies.Size = new Size(1031, 451);
            flpCurrencies.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1031, 650);
            Controls.Add(flpCurrencies);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Currency Converter - Win Forms .Net8 - Eng Maged Ali";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private RichTextBox richTextBox1;
        private FlowLayoutPanel flpCurrencies;
    }
}
