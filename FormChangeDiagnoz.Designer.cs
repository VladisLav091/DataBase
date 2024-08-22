namespace LAB7_BDBD
{
    partial class FormChangeDiagnoz
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox4 = new TextBox();
            button2 = new Button();
            label4 = new Label();
            button3 = new Button();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(35, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(210, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(35, 189);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(210, 23);
            textBox3.TabIndex = 2;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 167);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "Лечение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 119);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 4;
            label2.Text = "Описание диагноза";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 74);
            label3.Name = "label3";
            label3.Size = new Size(146, 15);
            label3.TabIndex = 5;
            label3.Text = "Идентификатор диагноза";
            // 
            // button1
            // 
            button1.Location = new Point(94, 230);
            button1.Name = "button1";
            button1.Size = new Size(91, 23);
            button1.TabIndex = 6;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(334, 189);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(169, 23);
            textBox4.TabIndex = 7;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(370, 230);
            button2.Name = "button2";
            button2.Size = new Size(92, 23);
            button2.TabIndex = 8;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(337, 168);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 9;
            label4.Text = "ID для удаления";
            // 
            // button3
            // 
            button3.Location = new Point(713, 33);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Найти";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(535, 33);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(153, 23);
            textBox5.TabIndex = 11;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(535, 15);
            label5.Name = "label5";
            label5.Size = new Size(157, 15);
            label5.TabIndex = 12;
            label5.Text = "Для обновления введите ID";
            label5.Click += label5_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(535, 77);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(153, 23);
            textBox7.TabIndex = 14;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(535, 121);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(153, 23);
            textBox8.TabIndex = 15;
            textBox8.TextChanged += textBox8_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(535, 59);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 17;
            label7.Text = "Описание";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(535, 103);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 18;
            label8.Text = "Лечение";
            // 
            // button4
            // 
            button4.Location = new Point(574, 150);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 19;
            button4.Text = "Обновить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FormChangeDiagnoz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 298);
            Controls.Add(button4);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "FormChangeDiagnoz";
            Text = "FormChangeDiagnoz";
            Load += FormChangeDiagnoz_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBox4;
        private Button button2;
        private Label label4;
        private Button button3;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label7;
        private Label label8;
        private Button button4;
    }
}