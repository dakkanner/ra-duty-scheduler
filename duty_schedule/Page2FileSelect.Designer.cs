namespace Duty_Schedule
{
    partial class Page1
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
            this.buttonP1Next = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSubHeader = new System.Windows.Forms.Label();
            this.radioButtonWizard = new System.Windows.Forms.RadioButton();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.radioButtonFiles = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonP1Next
            // 
            this.buttonP1Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonP1Next.Location = new System.Drawing.Point(677, 419);
            this.buttonP1Next.Name = "buttonP1Next";
            this.buttonP1Next.Size = new System.Drawing.Size(95, 30);
            this.buttonP1Next.TabIndex = 0;
            this.buttonP1Next.Text = "Next";
            this.buttonP1Next.UseVisualStyleBackColor = true;
            this.buttonP1Next.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(60, 72);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(651, 35);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Alright. Let\'s get started making a calendar.";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHeader.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelSubHeader
            // 
            this.labelSubHeader.AutoSize = true;
            this.labelSubHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHeader.Location = new System.Drawing.Point(254, 142);
            this.labelSubHeader.Name = "labelSubHeader";
            this.labelSubHeader.Size = new System.Drawing.Size(298, 25);
            this.labelSubHeader.TabIndex = 2;
            this.labelSubHeader.Text = "How do you want to begin?";
            // 
            // radioButtonWizard
            // 
            this.radioButtonWizard.AutoSize = true;
            this.radioButtonWizard.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonWizard.Location = new System.Drawing.Point(300, 219);
            this.radioButtonWizard.Name = "radioButtonWizard";
            this.radioButtonWizard.Size = new System.Drawing.Size(205, 22);
            this.radioButtonWizard.TabIndex = 3;
            this.radioButtonWizard.Text = "Let\'s fill in the blanks";
            this.radioButtonWizard.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(297, 343);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(206, 14);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "What do the text files look like?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // radioButtonFiles
            // 
            this.radioButtonFiles.AutoSize = true;
            this.radioButtonFiles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFiles.Location = new System.Drawing.Point(259, 263);
            this.radioButtonFiles.Name = "radioButtonFiles";
            this.radioButtonFiles.Size = new System.Drawing.Size(285, 22);
            this.radioButtonFiles.TabIndex = 4;
            this.radioButtonFiles.Text = "I\'ve already got some text files";
            this.radioButtonFiles.UseVisualStyleBackColor = true;
            // 
            // Page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.radioButtonFiles);
            this.Controls.Add(this.radioButtonWizard);
            this.Controls.Add(this.labelSubHeader);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonP1Next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Page1";
            this.Text = "Calendar Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonP1Next;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSubHeader;
        private System.Windows.Forms.RadioButton radioButtonWizard;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.RadioButton radioButtonFiles;
    }
}

