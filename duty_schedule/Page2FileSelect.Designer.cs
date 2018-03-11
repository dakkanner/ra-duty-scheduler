//Copyright (C) 2014-2018 Dakota Kanner
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program. If not, see <http://www.gnu.org/licenses/>.

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
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.dateFileSelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFileSelBtn = new System.Windows.Forms.Button();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.csvFileSelBtn = new System.Windows.Forms.Button();
            this.csvTextBox = new System.Windows.Forms.TextBox();
            this.buttonP2Next = new System.Windows.Forms.Button();
            this.groupBoxOption1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxWeekdaysEnableScheduling = new System.Windows.Forms.CheckBox();
            this.checkBoxWeekdaysShuffle = new System.Windows.Forms.CheckBox();
            this.checkBoxWeekdaysSamePeople = new System.Windows.Forms.CheckBox();
            this.groupBoxWeekendDays = new System.Windows.Forms.GroupBox();
            this.checkBoxWeekendsEnableScheduling = new System.Windows.Forms.CheckBox();
            this.weekendRadioButton3 = new System.Windows.Forms.RadioButton();
            this.checkBoxWeekendsShuffle = new System.Windows.Forms.CheckBox();
            this.weekendRadioButton2 = new System.Windows.Forms.RadioButton();
            this.checkBoxWeekendsSamePeople = new System.Windows.Forms.CheckBox();
            this.weekendRadioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBoxOption2 = new System.Windows.Forms.GroupBox();
            this.groupBoxOption1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxWeekendDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonP1Next
            // 
            this.buttonP1Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonP1Next.Location = new System.Drawing.Point(113, 378);
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
            this.labelHeader.Location = new System.Drawing.Point(140, 7);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(533, 35);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Let\'s get started making a calendar.";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(48, 110);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(206, 14);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "What do the text files look like?";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(51, 85);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(262, 20);
            this.dateTextBox.TabIndex = 7;
            // 
            // dateFileSelBtn
            // 
            this.dateFileSelBtn.Location = new System.Drawing.Point(314, 84);
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
            this.label1.Location = new System.Drawing.Point(51, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select date file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select group/name file";
            // 
            // groupFileSelBtn
            // 
            this.groupFileSelBtn.Location = new System.Drawing.Point(314, 128);
            this.groupFileSelBtn.Name = "groupFileSelBtn";
            this.groupFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.groupFileSelBtn.TabIndex = 11;
            this.groupFileSelBtn.Text = "...";
            this.groupFileSelBtn.UseVisualStyleBackColor = true;
            this.groupFileSelBtn.Click += new System.EventHandler(this.groupFileSelBtn_Click);
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(51, 129);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(262, 20);
            this.groupTextBox.TabIndex = 10;
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLinkLabel.Location = new System.Drawing.Point(12, 478);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(147, 14);
            this.aboutLinkLabel.TabIndex = 13;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "About Calendar Maker";
            this.aboutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(435, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Select CSV file";
            // 
            // csvFileSelBtn
            // 
            this.csvFileSelBtn.Location = new System.Drawing.Point(698, 231);
            this.csvFileSelBtn.Name = "csvFileSelBtn";
            this.csvFileSelBtn.Size = new System.Drawing.Size(29, 22);
            this.csvFileSelBtn.TabIndex = 17;
            this.csvFileSelBtn.Text = "...";
            this.csvFileSelBtn.UseVisualStyleBackColor = true;
            this.csvFileSelBtn.Click += new System.EventHandler(this.csvFileSelBtn_Click);
            // 
            // csvTextBox
            // 
            this.csvTextBox.Location = new System.Drawing.Point(435, 232);
            this.csvTextBox.Name = "csvTextBox";
            this.csvTextBox.Size = new System.Drawing.Size(262, 20);
            this.csvTextBox.TabIndex = 16;
            // 
            // buttonP2Next
            // 
            this.buttonP2Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonP2Next.Location = new System.Drawing.Point(537, 271);
            this.buttonP2Next.Name = "buttonP2Next";
            this.buttonP2Next.Size = new System.Drawing.Size(95, 30);
            this.buttonP2Next.TabIndex = 19;
            this.buttonP2Next.Text = "Next";
            this.buttonP2Next.UseVisualStyleBackColor = true;
            this.buttonP2Next.Click += new System.EventHandler(this.buttonP2Next_Click);
            // 
            // groupBoxOption1
            // 
            this.groupBoxOption1.Controls.Add(this.groupBox1);
            this.groupBoxOption1.Controls.Add(this.groupBoxWeekendDays);
            this.groupBoxOption1.Controls.Add(this.buttonP1Next);
            this.groupBoxOption1.Controls.Add(this.linkLabel2);
            this.groupBoxOption1.Location = new System.Drawing.Point(33, 47);
            this.groupBoxOption1.Name = "groupBoxOption1";
            this.groupBoxOption1.Size = new System.Drawing.Size(334, 415);
            this.groupBoxOption1.TabIndex = 21;
            this.groupBoxOption1.TabStop = false;
            this.groupBoxOption1.Text = "Option 1: From scratch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxWeekdaysEnableScheduling);
            this.groupBox1.Controls.Add(this.checkBoxWeekdaysShuffle);
            this.groupBox1.Controls.Add(this.checkBoxWeekdaysSamePeople);
            this.groupBox1.Location = new System.Drawing.Point(18, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 99);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weekday handling";
            // 
            // checkBoxWeekdaysEnableScheduling
            // 
            this.checkBoxWeekdaysEnableScheduling.AutoSize = true;
            this.checkBoxWeekdaysEnableScheduling.Checked = true;
            this.checkBoxWeekdaysEnableScheduling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWeekdaysEnableScheduling.Location = new System.Drawing.Point(14, 24);
            this.checkBoxWeekdaysEnableScheduling.Name = "checkBoxWeekdaysEnableScheduling";
            this.checkBoxWeekdaysEnableScheduling.Size = new System.Drawing.Size(137, 17);
            this.checkBoxWeekdaysEnableScheduling.TabIndex = 9;
            this.checkBoxWeekdaysEnableScheduling.Text = "Schedule on weekdays";
            this.checkBoxWeekdaysEnableScheduling.UseVisualStyleBackColor = true;
            this.checkBoxWeekdaysEnableScheduling.CheckedChanged += new System.EventHandler(this.checkBoxWeekdaysEnableScheduling_CheckedChanged);
            // 
            // checkBoxWeekdaysShuffle
            // 
            this.checkBoxWeekdaysShuffle.AutoSize = true;
            this.checkBoxWeekdaysShuffle.Enabled = false;
            this.checkBoxWeekdaysShuffle.Location = new System.Drawing.Point(14, 70);
            this.checkBoxWeekdaysShuffle.Name = "checkBoxWeekdaysShuffle";
            this.checkBoxWeekdaysShuffle.Size = new System.Drawing.Size(265, 17);
            this.checkBoxWeekdaysShuffle.TabIndex = 8;
            this.checkBoxWeekdaysShuffle.Text = "Shuffle responsibilities on weekdays when possible";
            this.checkBoxWeekdaysShuffle.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeekdaysSamePeople
            // 
            this.checkBoxWeekdaysSamePeople.AutoSize = true;
            this.checkBoxWeekdaysSamePeople.Location = new System.Drawing.Point(14, 47);
            this.checkBoxWeekdaysSamePeople.Name = "checkBoxWeekdaysSamePeople";
            this.checkBoxWeekdaysSamePeople.Size = new System.Drawing.Size(232, 17);
            this.checkBoxWeekdaysSamePeople.TabIndex = 7;
            this.checkBoxWeekdaysSamePeople.Text = "Weekdays have the same people each day";
            this.checkBoxWeekdaysSamePeople.UseVisualStyleBackColor = true;
            this.checkBoxWeekdaysSamePeople.CheckedChanged += new System.EventHandler(this.checkBoxWeekdaysSamePeople_CheckedChanged);
            // 
            // groupBoxWeekendDays
            // 
            this.groupBoxWeekendDays.Controls.Add(this.checkBoxWeekendsEnableScheduling);
            this.groupBoxWeekendDays.Controls.Add(this.weekendRadioButton3);
            this.groupBoxWeekendDays.Controls.Add(this.checkBoxWeekendsShuffle);
            this.groupBoxWeekendDays.Controls.Add(this.weekendRadioButton2);
            this.groupBoxWeekendDays.Controls.Add(this.checkBoxWeekendsSamePeople);
            this.groupBoxWeekendDays.Controls.Add(this.weekendRadioButton1);
            this.groupBoxWeekendDays.Location = new System.Drawing.Point(18, 138);
            this.groupBoxWeekendDays.Name = "groupBoxWeekendDays";
            this.groupBoxWeekendDays.Size = new System.Drawing.Size(292, 121);
            this.groupBoxWeekendDays.TabIndex = 9;
            this.groupBoxWeekendDays.TabStop = false;
            this.groupBoxWeekendDays.Text = "Weekend handling";
            // 
            // checkBoxWeekendsEnableScheduling
            // 
            this.checkBoxWeekendsEnableScheduling.AutoSize = true;
            this.checkBoxWeekendsEnableScheduling.Checked = true;
            this.checkBoxWeekendsEnableScheduling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWeekendsEnableScheduling.Location = new System.Drawing.Point(14, 48);
            this.checkBoxWeekendsEnableScheduling.Name = "checkBoxWeekendsEnableScheduling";
            this.checkBoxWeekendsEnableScheduling.Size = new System.Drawing.Size(138, 17);
            this.checkBoxWeekendsEnableScheduling.TabIndex = 9;
            this.checkBoxWeekendsEnableScheduling.Text = "Schedule on weekends";
            this.checkBoxWeekendsEnableScheduling.UseVisualStyleBackColor = true;
            this.checkBoxWeekendsEnableScheduling.CheckedChanged += new System.EventHandler(this.checkBoxWeekendsEnableScheduling_CheckedChanged);
            // 
            // weekendRadioButton3
            // 
            this.weekendRadioButton3.AutoSize = true;
            this.weekendRadioButton3.Location = new System.Drawing.Point(204, 20);
            this.weekendRadioButton3.Name = "weekendRadioButton3";
            this.weekendRadioButton3.Size = new System.Drawing.Size(66, 17);
            this.weekendRadioButton3.TabIndex = 2;
            this.weekendRadioButton3.TabStop = true;
            this.weekendRadioButton3.Text = "Sat, Sun";
            this.weekendRadioButton3.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeekendsShuffle
            // 
            this.checkBoxWeekendsShuffle.AutoSize = true;
            this.checkBoxWeekendsShuffle.Enabled = false;
            this.checkBoxWeekendsShuffle.Location = new System.Drawing.Point(14, 94);
            this.checkBoxWeekendsShuffle.Name = "checkBoxWeekendsShuffle";
            this.checkBoxWeekendsShuffle.Size = new System.Drawing.Size(266, 17);
            this.checkBoxWeekendsShuffle.TabIndex = 8;
            this.checkBoxWeekendsShuffle.Text = "Shuffle responsibilities on weekends when possible";
            this.checkBoxWeekendsShuffle.UseVisualStyleBackColor = true;
            // 
            // weekendRadioButton2
            // 
            this.weekendRadioButton2.AutoSize = true;
            this.weekendRadioButton2.Location = new System.Drawing.Point(123, 19);
            this.weekendRadioButton2.Name = "weekendRadioButton2";
            this.weekendRadioButton2.Size = new System.Drawing.Size(58, 17);
            this.weekendRadioButton2.TabIndex = 1;
            this.weekendRadioButton2.TabStop = true;
            this.weekendRadioButton2.Text = "Fri, Sat";
            this.weekendRadioButton2.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeekendsSamePeople
            // 
            this.checkBoxWeekendsSamePeople.AutoSize = true;
            this.checkBoxWeekendsSamePeople.Location = new System.Drawing.Point(14, 71);
            this.checkBoxWeekendsSamePeople.Name = "checkBoxWeekendsSamePeople";
            this.checkBoxWeekendsSamePeople.Size = new System.Drawing.Size(233, 17);
            this.checkBoxWeekendsSamePeople.TabIndex = 7;
            this.checkBoxWeekendsSamePeople.Text = "Weekends have the same people each day";
            this.checkBoxWeekendsSamePeople.UseVisualStyleBackColor = true;
            this.checkBoxWeekendsSamePeople.CheckedChanged += new System.EventHandler(this.checkBoxWeekendsSamePeople_CheckedChanged);
            // 
            // weekendRadioButton1
            // 
            this.weekendRadioButton1.AutoSize = true;
            this.weekendRadioButton1.Location = new System.Drawing.Point(25, 20);
            this.weekendRadioButton1.Name = "weekendRadioButton1";
            this.weekendRadioButton1.Size = new System.Drawing.Size(83, 17);
            this.weekendRadioButton1.TabIndex = 0;
            this.weekendRadioButton1.TabStop = true;
            this.weekendRadioButton1.Text = "Fri, Sat, Sun";
            this.weekendRadioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBoxOption2
            // 
            this.groupBoxOption2.Location = new System.Drawing.Point(415, 185);
            this.groupBoxOption2.Name = "groupBoxOption2";
            this.groupBoxOption2.Size = new System.Drawing.Size(334, 122);
            this.groupBoxOption2.TabIndex = 20;
            this.groupBoxOption2.TabStop = false;
            this.groupBoxOption2.Text = "Option 2: From previous export";
            // 
            // Page2FileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.buttonP2Next);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.csvFileSelBtn);
            this.Controls.Add(this.csvTextBox);
            this.Controls.Add(this.aboutLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupFileSelBtn);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFileSelBtn);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.groupBoxOption2);
            this.Controls.Add(this.groupBoxOption1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Page2FileSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxOption1.ResumeLayout(false);
            this.groupBoxOption1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxWeekendDays.ResumeLayout(false);
            this.groupBoxWeekendDays.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonP1Next;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Button dateFileSelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button groupFileSelBtn;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.LinkLabel aboutLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button csvFileSelBtn;
        private System.Windows.Forms.TextBox csvTextBox;
        private System.Windows.Forms.Button buttonP2Next;
        private System.Windows.Forms.GroupBox groupBoxOption2;
        private System.Windows.Forms.GroupBox groupBoxOption1;
        private System.Windows.Forms.CheckBox checkBoxWeekendsSamePeople;
        private System.Windows.Forms.CheckBox checkBoxWeekendsShuffle;
        private System.Windows.Forms.GroupBox groupBoxWeekendDays;
        private System.Windows.Forms.RadioButton weekendRadioButton3;
        private System.Windows.Forms.RadioButton weekendRadioButton2;
        private System.Windows.Forms.RadioButton weekendRadioButton1;
        private System.Windows.Forms.CheckBox checkBoxWeekendsEnableScheduling;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxWeekdaysEnableScheduling;
        private System.Windows.Forms.CheckBox checkBoxWeekdaysShuffle;
        private System.Windows.Forms.CheckBox checkBoxWeekdaysSamePeople;
    }
}

