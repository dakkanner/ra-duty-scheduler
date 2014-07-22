using System;
namespace Duty_Schedule
{
    partial class Page2FileSelect
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
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.DateFileSelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFileSelBtn = new System.Windows.Forms.Button();
            this.groupTextBox = new System.Windows.Forms.TextBox();
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
            this.buttonP1Next.Click += new System.EventHandler(this.buttonP1Next_Click);
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
            // 
            // labelSubHeader
            // 
            this.labelSubHeader.AutoSize = true;
            this.labelSubHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHeader.Location = new System.Drawing.Point(326, 144);
            this.labelSubHeader.Name = "labelSubHeader";
            this.labelSubHeader.Size = new System.Drawing.Size(151, 25);
            this.labelSubHeader.TabIndex = 2;
            this.labelSubHeader.Text = "Let\'s begin...";
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
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(260, 219);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(262, 20);
            this.dateTextBox.TabIndex = 7;
            this.dateTextBox.Text = "J:\\Users\\Dak\\Documents";
            // 
            // DateFileSelBtn
            // 
            this.DateFileSelBtn.Location = new System.Drawing.Point(523, 218);
            this.DateFileSelBtn.Name = "DateFileSelBtn";
            this.DateFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.DateFileSelBtn.TabIndex = 8;
            this.DateFileSelBtn.Text = "...";
            this.DateFileSelBtn.UseVisualStyleBackColor = true;
            this.DateFileSelBtn.Click += new System.EventHandler(this.DateFileSelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select date file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select group/name file";
            // 
            // groupFileSelBtn
            // 
            this.groupFileSelBtn.Location = new System.Drawing.Point(523, 281);
            this.groupFileSelBtn.Name = "groupFileSelBtn";
            this.groupFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.groupFileSelBtn.TabIndex = 11;
            this.groupFileSelBtn.Text = "...";
            this.groupFileSelBtn.UseVisualStyleBackColor = true;
            this.groupFileSelBtn.Click += new System.EventHandler(this.groupFileSelBtn_Click);
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(260, 282);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(262, 20);
            this.groupTextBox.TabIndex = 10;
            this.groupTextBox.Text = "J:\\Users\\Dak\\Documents";
            // 
            // Page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupFileSelBtn);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateFileSelBtn);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.labelSubHeader);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.buttonP1Next);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Page2";
            this.Text = "Calendar Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonP1Next;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSubHeader;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Button DateFileSelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button groupFileSelBtn;
        private System.Windows.Forms.TextBox groupTextBox;
        
    }
}

