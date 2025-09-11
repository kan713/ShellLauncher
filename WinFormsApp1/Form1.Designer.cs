namespace WinFormsApp1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            monthCalendar1 = new MonthCalendar();
            label1 = new Label();
            button4 = new Button();
            label2 = new Label();
            label3 = new Label();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            label5 = new Label();
            button9 = new Button();
            button10 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button11 = new Button();
            label6 = new Label();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            label7 = new Label();
            button15 = new Button();
            button16 = new Button();
            button5 = new Button();
            button17 = new Button();
            button18 = new Button();
            label8 = new Label();
            button19 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 11F);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(59, 75);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(137, 77);
            button1.TabIndex = 0;
            button1.Text = "シャットダウン";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic UI", 11F);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(231, 75);
            button2.Name = "button2";
            button2.Size = new Size(138, 77);
            button2.TabIndex = 1;
            button2.Text = "再起動";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(58, 388);
            button3.Name = "button3";
            button3.Size = new Size(138, 94);
            button3.TabIndex = 2;
            button3.Text = "タスクマネージャーを起動";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 2);
            monthCalendar1.Font = new Font("Yu Gothic UI Light", 9F);
            monthCalendar1.Location = new Point(1081, 137);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 30);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 4;
            label1.Text = "電源管理";
            // 
            // button4
            // 
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(231, 388);
            button4.Name = "button4";
            button4.Size = new Size(141, 94);
            button4.TabIndex = 5;
            button4.Text = "コマンドプロンプト";
            button4.TextAlign = ContentAlignment.BottomCenter;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1251, 116);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 6;
            label2.Text = "簡易カレンダー";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 348);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 8;
            label3.Text = "システム";
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(412, 74);
            button6.Name = "button6";
            button6.Size = new Size(138, 77);
            button6.TabIndex = 9;
            button6.Text = "ブラウザ";
            button6.TextAlign = ContentAlignment.BottomCenter;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(231, 203);
            button7.Name = "button7";
            button7.Size = new Size(138, 77);
            button7.TabIndex = 10;
            button7.Text = "ログオフ";
            button7.TextAlign = ContentAlignment.BottomCenter;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(58, 528);
            button8.Name = "button8";
            button8.Size = new Size(138, 94);
            button8.TabIndex = 11;
            button8.Text = "音量パネル";
            button8.TextAlign = ContentAlignment.BottomCenter;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 20F);
            label4.Location = new Point(1223, 66);
            label4.Name = "label4";
            label4.Size = new Size(119, 37);
            label4.TabIndex = 12;
            label4.Text = "00:00:00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15F);
            label5.Location = new Point(1223, 38);
            label5.Name = "label5";
            label5.Size = new Size(72, 28);
            label5.TabIndex = 13;
            label5.Text = "現時刻";
            // 
            // button9
            // 
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(412, 528);
            button9.Name = "button9";
            button9.Size = new Size(141, 94);
            button9.TabIndex = 14;
            button9.Text = "サーバー起動";
            button9.TextAlign = ContentAlignment.BottomCenter;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(-2, 1049);
            button10.Name = "button10";
            button10.Size = new Size(10, 18);
            button10.TabIndex = 15;
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // button11
            // 
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.Location = new Point(593, 528);
            button11.Name = "button11";
            button11.Size = new Size(141, 94);
            button11.TabIndex = 16;
            button11.Text = "サーバーファイルを\r\nバックアップ\r\n";
            button11.TextAlign = ContentAlignment.BottomCenter;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15F);
            label6.Location = new Point(1608, 19);
            label6.Name = "label6";
            label6.Size = new Size(293, 84);
            label6.TabIndex = 17;
            label6.Text = "ベータ版です\r\n本システムを許可なく配布することは\r\n固く禁じております";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // button12
            // 
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.Location = new Point(593, 74);
            button12.Name = "button12";
            button12.Size = new Size(141, 77);
            button12.TabIndex = 18;
            button12.Text = "メモ帳";
            button12.TextAlign = ContentAlignment.BottomCenter;
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(1741, 212);
            button13.Name = "button13";
            button13.Size = new Size(160, 33);
            button13.TabIndex = 19;
            button13.Text = "ライフサイクル";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Image = (Image)resources.GetObject("button14.Image");
            button14.Location = new Point(59, 202);
            button14.Name = "button14";
            button14.Size = new Size(137, 77);
            button14.TabIndex = 20;
            button14.Text = "Recovery Mode";
            button14.TextAlign = ContentAlignment.BottomCenter;
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1806, 182);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 21;
            label7.Text = "ツール";
            // 
            // button15
            // 
            button15.Image = (Image)resources.GetObject("button15.Image");
            button15.Location = new Point(1741, 259);
            button15.Name = "button15";
            button15.Size = new Size(160, 87);
            button15.TabIndex = 22;
            button15.Text = "システム情報";
            button15.TextAlign = ContentAlignment.BottomCenter;
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click_1;
            // 
            // button16
            // 
            button16.Image = (Image)resources.GetObject("button16.Image");
            button16.Location = new Point(593, 202);
            button16.Name = "button16";
            button16.Size = new Size(141, 77);
            button16.TabIndex = 23;
            button16.Text = "CMD only Mode";
            button16.TextAlign = ContentAlignment.BottomCenter;
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(593, 388);
            button5.Name = "button5";
            button5.Size = new Size(141, 94);
            button5.TabIndex = 24;
            button5.Text = "コントロールパネル";
            button5.TextAlign = ContentAlignment.BottomCenter;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button17
            // 
            button17.Image = (Image)resources.GetObject("button17.Image");
            button17.Location = new Point(231, 528);
            button17.Name = "button17";
            button17.Size = new Size(141, 94);
            button17.TabIndex = 25;
            button17.Text = "Windows ライセンス認証";
            button17.TextAlign = ContentAlignment.BottomCenter;
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button18
            // 
            button18.Image = (Image)resources.GetObject("button18.Image");
            button18.Location = new Point(412, 388);
            button18.Name = "button18";
            button18.Size = new Size(138, 94);
            button18.TabIndex = 26;
            button18.Text = "エクスプローラー";
            button18.TextAlign = ContentAlignment.BottomCenter;
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(541, 42);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 27;
            label8.Text = "アクセサリ";
            // 
            // button19
            // 
            button19.Image = (Image)resources.GetObject("button19.Image");
            button19.Location = new Point(412, 202);
            button19.Name = "button19";
            button19.Size = new Size(138, 77);
            button19.TabIndex = 28;
            button19.Text = "Windowsに切り替え";
            button19.TextAlign = ContentAlignment.BottomCenter;
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1913, 1061);
            Controls.Add(button19);
            Controls.Add(label8);
            Controls.Add(button18);
            Controls.Add(button17);
            Controls.Add(button5);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(label7);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(label6);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(monthCalendar1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "ランチャー";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private MonthCalendar monthCalendar1;
        private Label label1;
        private Button button4;
        private Label label2;
        private Label label3;
        private Button button6;
        private Button button7;
        private Button button8;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private Label label5;
        private Button button9;
        private Button button10;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button11;
        private Label label6;
        private Button button12;
        private Button button13;
        private Button button14;
        private Label label7;
        private Button button15;
        private Button button16;
        private Button button5;
        private Button button17;
        private Button button18;
        private Label label8;
        private Button button19;
    }
}
