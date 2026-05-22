namespace Лабораторные_Windows_Forms
{
    partial class FormLocomotiveCollection
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
            pictureBoxParking = new PictureBox();
            panelControls = new Panel();
            buttonRefresh = new Button();
            buttonTransfer = new Button();
            buttonRemove = new Button();
            textBoxPosition = new TextBox();
            labelPosition = new Label();
            buttonAddSport = new Button();
            buttonAddSimple = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxParking).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxParking
            // 
            pictureBoxParking.Dock = DockStyle.Fill;
            pictureBoxParking.Location = new Point(0, 0);
            pictureBoxParking.Name = "pictureBoxParking";
            pictureBoxParking.Size = new Size(1553, 741);
            pictureBoxParking.TabIndex = 0;
            pictureBoxParking.TabStop = false;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(buttonRefresh);
            panelControls.Controls.Add(buttonTransfer);
            panelControls.Controls.Add(buttonRemove);
            panelControls.Controls.Add(textBoxPosition);
            panelControls.Controls.Add(labelPosition);
            panelControls.Controls.Add(buttonAddSport);
            panelControls.Controls.Add(buttonAddSimple);
            panelControls.Dock = DockStyle.Right;
            panelControls.Location = new Point(1353, 0);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(200, 741);
            panelControls.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(-1, 374);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(148, 44);
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonTransfer
            // 
            buttonTransfer.Location = new Point(3, 315);
            buttonTransfer.Name = "buttonTransfer";
            buttonTransfer.Size = new Size(144, 53);
            buttonTransfer.TabIndex = 2;
            buttonTransfer.Text = "Передать в тест";
            buttonTransfer.UseVisualStyleBackColor = true;
            buttonTransfer.Click += buttonTransfer_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(3, 258);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(144, 51);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // textBoxPosition
            // 
            textBoxPosition.Location = new Point(19, 212);
            textBoxPosition.Name = "textBoxPosition";
            textBoxPosition.Size = new Size(141, 31);
            textBoxPosition.TabIndex = 5;
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.Location = new Point(-1, 167);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(201, 25);
            labelPosition.TabIndex = 4;
            labelPosition.Text = "Позиция для удаления:";
            // 
            // buttonAddSport
            // 
            buttonAddSport.Location = new Point(0, 91);
            buttonAddSport.Name = "buttonAddSport";
            buttonAddSport.Size = new Size(160, 73);
            buttonAddSport.TabIndex = 3;
            buttonAddSport.Text = "Добавить продвинутый";
            buttonAddSport.UseVisualStyleBackColor = true;
            buttonAddSport.Click += buttonAddSport_Click;
            // 
            // buttonAddSimple
            // 
            buttonAddSimple.Location = new Point(3, 12);
            buttonAddSimple.Name = "buttonAddSimple";
            buttonAddSimple.Size = new Size(160, 73);
            buttonAddSimple.TabIndex = 2;
            buttonAddSimple.Text = "Добавить простой";
            buttonAddSimple.UseVisualStyleBackColor = true;
            buttonAddSimple.Click += buttonAddSimple_Click;
            // 
            // FormLocomotiveCollection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1553, 741);
            Controls.Add(panelControls);
            Controls.Add(pictureBoxParking);
            Name = "FormLocomotiveCollection";
            Text = "FormLocomotiveCollection";
            ((System.ComponentModel.ISupportInitialize)pictureBoxParking).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxParking;
        private Panel panelControls;
        private Button buttonAddSimple;
        private Button buttonAddSport;
        private Button buttonTransfer;
        private Button buttonRemove;
        private TextBox textBoxPosition;
        private Label labelPosition;
        private Button buttonRefresh;
    }
}