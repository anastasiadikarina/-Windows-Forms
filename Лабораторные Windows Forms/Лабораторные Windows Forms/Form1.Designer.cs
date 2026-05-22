namespace Лабораторные_Windows_Forms
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            comboBoxDestination = new ComboBox();
            buttonStep = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1603, 825);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(30, 368);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonCreate_Click;
            // 
            // button2
            // 
            button2.Location = new Point(568, 305);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 2;
            button2.Text = "Up";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonMove_Click;
            // 
            // button3
            // 
            button3.Location = new Point(568, 345);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 3;
            button3.Text = "Down";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ButtonMove_Click;
            // 
            // button4
            // 
            button4.Location = new Point(450, 325);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 4;
            button4.Text = "Left";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ButtonMove_Click;
            // 
            // button5
            // 
            button5.Location = new Point(686, 325);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 5;
            button5.Text = "Right";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ButtonMove_Click;
            // 
            // button6
            // 
            button6.Location = new Point(30, 408);
            button6.Name = "button6";
            button6.Size = new Size(285, 34);
            button6.TabIndex = 6;
            button6.Text = "Создать продвинутый";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ButtonCreateSport_Click;
            // 
            // comboBoxDestination
            // 
            comboBoxDestination.FormattingEnabled = true;
            comboBoxDestination.Location = new Point(148, 368);
            comboBoxDestination.Name = "comboBoxDestination";
            comboBoxDestination.Size = new Size(182, 33);
            comboBoxDestination.TabIndex = 7;
            comboBoxDestination.Text = "Выбор цели";
            comboBoxDestination.SelectedIndexChanged += ComboBoxDestination_SelectedIndexChanged;
            // 
            // buttonStep
            // 
            buttonStep.Location = new Point(336, 368);
            buttonStep.Name = "buttonStep";
            buttonStep.Size = new Size(112, 34);
            buttonStep.TabIndex = 8;
            buttonStep.Text = "Шаг";
            buttonStep.UseVisualStyleBackColor = true;
            buttonStep.Click += ButtonStep_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1603, 825);
            Controls.Add(buttonStep);
            Controls.Add(comboBoxDestination);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private ComboBox comboBoxDestination;
        private Button buttonStep;
    }
}
