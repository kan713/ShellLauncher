namespace ShellLauncher_v3
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button19 = new Button();
            button14 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            label5 = new Label();
            label4 = new Label();
            button11 = new Button();
            button9 = new Button();
            button6 = new Button();
            button12 = new Button();
            monthCalendar1 = new MonthCalendar();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            button15 = new Button();
            SuspendLayout();
            // 
            // button19
            // 
            button19.Image = (Image)resources.GetObject("button19.Image");
            button19.Location = new Point(244, 214);
            button19.Name = "button19";
            button19.Size = new Size(138, 87);
            button19.TabIndex = 32;
            button19.Text = "Windowsに切り替え";
            button19.TextAlign = ContentAlignment.BottomCenter;
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button14
            // 
            button14.Image = (Image)resources.GetObject("button14.Image");
            button14.Location = new Point(72, 214);
            button14.Name = "button14";
            button14.Size = new Size(137, 87);
            button14.TabIndex = 31;
            button14.Text = "Recovery Mode";
            button14.TextAlign = ContentAlignment.BottomCenter;
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 11F);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(244, 87);
            button2.Name = "button2";
            button2.Size = new Size(138, 87);
            button2.TabIndex = 30;
            button2.Text = "再起動";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 11F);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(72, 87);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(137, 87);
            button1.TabIndex = 29;
            button1.Text = "シャットダウン";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 38);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 33;
            label1.Text = "電源管理";
            label1.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15F);
            label5.Location = new Point(1048, 13);
            label5.Name = "label5";
            label5.Size = new Size(72, 28);
            label5.TabIndex = 35;
            label5.Text = "現時刻";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 20F);
            label4.Location = new Point(1027, 41);
            label4.Name = "label4";
            label4.Size = new Size(119, 37);
            label4.TabIndex = 36;
            label4.Text = "00:00:00";
            // 
            // button11
            // 
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.Location = new Point(244, 368);
            button11.Name = "button11";
            button11.Size = new Size(138, 94);
            button11.TabIndex = 38;
            button11.Text = "別のアプリを選択";
            button11.TextAlign = ContentAlignment.BottomCenter;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button9
            // 
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(72, 368);
            button9.Name = "button9";
            button9.Size = new Size(137, 94);
            button9.TabIndex = 37;
            button9.Text = "アプリ起動";
            button9.TextAlign = ContentAlignment.BottomCenter;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(72, 494);
            button6.Name = "button6";
            button6.Size = new Size(137, 94);
            button6.TabIndex = 39;
            button6.Text = "ブラウザ";
            button6.TextAlign = ContentAlignment.BottomCenter;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button12
            // 
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.Location = new Point(244, 494);
            button12.Name = "button12";
            button12.Size = new Size(138, 94);
            button12.TabIndex = 40;
            button12.Text = "メモ帳";
            button12.TextAlign = ContentAlignment.BottomCenter;
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 1);
            monthCalendar1.Location = new Point(883, 87);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 41;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 332);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 42;
            label2.Text = "システム";
            // 
            // button15
            // 
            button15.Image = (Image)resources.GetObject("button15.Image");
            button15.Location = new Point(1147, 291);
            button15.Name = "button15";
            button15.Size = new Size(138, 87);
            button15.TabIndex = 43;
            button15.Text = "システム情報";
            button15.TextAlign = ContentAlignment.BottomCenter;
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1303, 662);
            Controls.Add(button15);
            Controls.Add(label2);
            Controls.Add(monthCalendar1);
            Controls.Add(button12);
            Controls.Add(button6);
            Controls.Add(button11);
            Controls.Add(button9);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(button19);
            Controls.Add(button14);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Main";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button19;
        private Button button14;
        private Button button2;
        private Button button1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Button button11;
        private Button button9;
        private Button button6;
        private Button button12;
        private MonthCalendar monthCalendar1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private Button button15;
    }
}
