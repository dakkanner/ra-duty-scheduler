//Copyright (C) 2014  Dakota Kanner
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page2FileSelect));
            this.buttonP1Next = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSubHeader = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.dateFileSelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFileSelBtn = new System.Windows.Forms.Button();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.csvFileSelBtn = new System.Windows.Forms.Button();
            this.csvTextBox = new System.Windows.Forms.TextBox();
            this.buttonP2Next = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ShuffleCheckBox = new System.Windows.Forms.CheckBox();
            this.WeekendsSamePersonCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonP1Next
            // 
            this.buttonP1Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonP1Next.Location = new System.Drawing.Point(113, 255);
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
            this.labelHeader.Location = new System.Drawing.Point(43, 42);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(695, 35);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Alright. Time to get started making a calendar.";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubHeader
            // 
            this.labelSubHeader.AutoSize = true;
            this.labelSubHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHeader.Location = new System.Drawing.Point(309, 114);
            this.labelSubHeader.Name = "labelSubHeader";
            this.labelSubHeader.Size = new System.Drawing.Size(151, 25);
            this.labelSubHeader.TabIndex = 2;
            this.labelSubHeader.Text = "Let\'s begin...";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(55, 219);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(206, 14);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "What do the text files look like?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(51, 219);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(262, 20);
            this.dateTextBox.TabIndex = 7;
            // 
            // dateFileSelBtn
            // 
            this.dateFileSelBtn.Location = new System.Drawing.Point(314, 218);
            this.dateFileSelBtn.Name = "dateFileSelBtn";
            this.dateFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.dateFileSelBtn.TabIndex = 8;
            this.dateFileSelBtn.Text = "...";
            this.dateFileSelBtn.UseVisualStyleBackColor = true;
            this.dateFileSelBtn.Click += new System.EventHandler(this.dateFileSelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select date file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select group/name file";
            // 
            // groupFileSelBtn
            // 
            this.groupFileSelBtn.Location = new System.Drawing.Point(314, 281);
            this.groupFileSelBtn.Name = "groupFileSelBtn";
            this.groupFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.groupFileSelBtn.TabIndex = 11;
            this.groupFileSelBtn.Text = "...";
            this.groupFileSelBtn.UseVisualStyleBackColor = true;
            this.groupFileSelBtn.Click += new System.EventHandler(this.groupFileSelBtn_Click);
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(51, 282);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(262, 20);
            this.groupTextBox.TabIndex = 10;
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLinkLabel.Location = new System.Drawing.Point(12, 462);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(147, 14);
            this.aboutLinkLabel.TabIndex = 13;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "About Calendar Maker";
            this.aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13F);
            this.label3.Location = new System.Drawing.Point(133, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 22);
            this.label3.TabIndex = 14;
            this.label3.Text = "From scratch:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13F);
            this.label4.Location = new System.Drawing.Point(494, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "From previous export:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(445, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Select CSV file";
            // 
            // csvFileSelBtn
            // 
            this.csvFileSelBtn.Location = new System.Drawing.Point(708, 219);
            this.csvFileSelBtn.Name = "csvFileSelBtn";
            this.csvFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.csvFileSelBtn.TabIndex = 17;
            this.csvFileSelBtn.Text = "...";
            this.csvFileSelBtn.UseVisualStyleBackColor = true;
            this.csvFileSelBtn.Click += new System.EventHandler(this.csvFileSelBtn_Click);
            // 
            // csvTextBox
            // 
            this.csvTextBox.Location = new System.Drawing.Point(445, 220);
            this.csvTextBox.Name = "csvTextBox";
            this.csvTextBox.Size = new System.Drawing.Size(262, 20);
            this.csvTextBox.TabIndex = 16;
            // 
            // buttonP2Next
            // 
            this.buttonP2Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonP2Next.Location = new System.Drawing.Point(547, 263);
            this.buttonP2Next.Name = "buttonP2Next";
            this.buttonP2Next.Size = new System.Drawing.Size(95, 30);
            this.buttonP2Next.TabIndex = 19;
            this.buttonP2Next.Text = "Next";
            this.buttonP2Next.UseVisualStyleBackColor = true;
            this.buttonP2Next.Click += new System.EventHandler(this.buttonP2Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(425, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 151);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option 2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ShuffleCheckBox);
            this.groupBox2.Controls.Add(this.WeekendsSamePersonCheckBox);
            this.groupBox2.Controls.Add(this.buttonP1Next);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Location = new System.Drawing.Point(33, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 295);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option 1";
            // 
            // ShuffleCheckBox
            // 
            this.ShuffleCheckBox.AutoSize = true;
            this.ShuffleCheckBox.Enabled = false;
            this.ShuffleCheckBox.Location = new System.Drawing.Point(58, 179);
            this.ShuffleCheckBox.Name = "ShuffleCheckBox";
            this.ShuffleCheckBox.Size = new System.Drawing.Size(196, 17);
            this.ShuffleCheckBox.TabIndex = 8;
            this.ShuffleCheckBox.Text = "Shuffle on weekends when possible";
            this.ShuffleCheckBox.UseVisualStyleBackColor = true;
            // 
            // WeekendsSamePersonCheckBox
            // 
            this.WeekendsSamePersonCheckBox.AutoSize = true;
            this.WeekendsSamePersonCheckBox.Location = new System.Drawing.Point(47, 156);
            this.WeekendsSamePersonCheckBox.Name = "WeekendsSamePersonCheckBox";
            this.WeekendsSamePersonCheckBox.Size = new System.Drawing.Size(233, 17);
            this.WeekendsSamePersonCheckBox.TabIndex = 7;
            this.WeekendsSamePersonCheckBox.Text = "Weekends have the same people each day";
            this.WeekendsSamePersonCheckBox.UseVisualStyleBackColor = true;
            this.WeekendsSamePersonCheckBox.CheckedChanged += new System.EventHandler(this.buttonWeekend_Click);
            // 
            // Page2FileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 494);
            this.Controls.Add(this.buttonP2Next);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.csvFileSelBtn);
            this.Controls.Add(this.csvTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aboutLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupFileSelBtn);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFileSelBtn);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.labelSubHeader);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Page2FileSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonP1Next;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSubHeader;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Button dateFileSelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button groupFileSelBtn;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.LinkLabel aboutLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button csvFileSelBtn;
        private System.Windows.Forms.TextBox csvTextBox;
        private System.Windows.Forms.Button buttonP2Next;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox WeekendsSamePersonCheckBox;
        private System.Windows.Forms.CheckBox ShuffleCheckBox;
    }
}

