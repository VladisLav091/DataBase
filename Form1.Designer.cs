﻿namespace LAB7_BDBD
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
            button2 = new Button();
            button3 = new Button();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(31, 117);
            button2.Name = "button2";
            button2.Size = new Size(171, 23);
            button2.TabIndex = 1;
            button2.Text = "Показать таблицу Врач";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(223, 117);
            button3.Name = "button3";
            button3.Size = new Size(180, 23);
            button3.TabIndex = 2;
            button3.Text = "Изменить врача в БД";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(31, 146);
            button1.Name = "button1";
            button1.Size = new Size(171, 23);
            button1.TabIndex = 3;
            button1.Text = "Показать таблицу Диагноз";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(31, 175);
            button4.Name = "button4";
            button4.Size = new Size(171, 52);
            button4.TabIndex = 4;
            button4.Text = "Показать таблицу Лечебное учреждение";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(31, 233);
            button5.Name = "button5";
            button5.Size = new Size(171, 39);
            button5.TabIndex = 5;
            button5.Text = "Показать таблицу Пациент";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(31, 278);
            button6.Name = "button6";
            button6.Size = new Size(171, 38);
            button6.TabIndex = 6;
            button6.Text = "Показать таблицу приём";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(31, 325);
            button7.Name = "button7";
            button7.Size = new Size(171, 47);
            button7.TabIndex = 7;
            button7.Text = "Показать таблицу процедура";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(223, 146);
            button8.Name = "button8";
            button8.Size = new Size(180, 23);
            button8.TabIndex = 8;
            button8.Text = "Изменить таблицу Диагноз";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(223, 175);
            button9.Name = "button9";
            button9.Size = new Size(180, 52);
            button9.TabIndex = 9;
            button9.Text = "Изменить лечебное учреждение";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(223, 233);
            button10.Name = "button10";
            button10.Size = new Size(180, 39);
            button10.TabIndex = 10;
            button10.Text = "Изменить пациент";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(223, 278);
            button11.Name = "button11";
            button11.Size = new Size(180, 38);
            button11.TabIndex = 11;
            button11.Text = "Изменить приём";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(223, 325);
            button12.Name = "button12";
            button12.Size = new Size(180, 47);
            button12.TabIndex = 12;
            button12.Text = "Изменить процедура";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ebc39b2bea11789e5c10d8611df914f0;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(button2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button3;
        private Button button1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
    }
}