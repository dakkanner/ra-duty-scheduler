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
namespace Duty_Schedule
{
    partial class Page3FileOutput
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
        private void InitializeComponent(int groupCount, int peopleCount, int daycount)
        //private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page2FileSelect));
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSubHeader = new System.Windows.Forms.Label();
            this.excelOutputBtn = new System.Windows.Forms.Button();
            this.csvOutputBtn = new System.Windows.Forms.Button();
            this.iCalOutputBtn = new System.Windows.Forms.Button();
            this.foundLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(182, 73);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(436, 35);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Cool. Everything looks good.";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubHeader
            // 
            this.labelSubHeader.AutoSize = true;
            this.labelSubHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHeader.Location = new System.Drawing.Point(170, 140);
            this.labelSubHeader.Name = "labelSubHeader";
            this.labelSubHeader.Size = new System.Drawing.Size(460, 25);
            this.labelSubHeader.TabIndex = 2;
            this.labelSubHeader.Text = "How do you want to output your calendar?";
            // 
            // excelOutputBtn
            // 
            this.excelOutputBtn.Location = new System.Drawing.Point(344, 326);
            this.excelOutputBtn.Name = "excelOutputBtn";
            this.excelOutputBtn.Size = new System.Drawing.Size(100, 22);
            this.excelOutputBtn.TabIndex = 8;
            this.excelOutputBtn.Text = "Output to Excel";
            this.excelOutputBtn.UseVisualStyleBackColor = true;
            this.excelOutputBtn.Click += new System.EventHandler(this.excelOutputBtn_Click);
            // 
            // csvOutputBtn
            // 
            this.csvOutputBtn.Location = new System.Drawing.Point(344, 356);
            this.csvOutputBtn.Name = "csvOutputBtn";
            this.csvOutputBtn.Size = new System.Drawing.Size(100, 22);
            this.csvOutputBtn.TabIndex = 11;
            this.csvOutputBtn.Text = "Output to a CSV";
            this.csvOutputBtn.UseVisualStyleBackColor = true;
            this.csvOutputBtn.Click += new System.EventHandler(this.csvOutputBtn_Click);
            // 
            // iCalOutputBtn
            // 
            this.iCalOutputBtn.Location = new System.Drawing.Point(270, 386);
            this.iCalOutputBtn.Name = "iCalOutputBtn";
            this.iCalOutputBtn.Size = new System.Drawing.Size(250, 22);
            this.iCalOutputBtn.TabIndex = 11;
            this.iCalOutputBtn.Text = "Create Outlook events and send invites";
            this.iCalOutputBtn.UseVisualStyleBackColor = true;
            this.iCalOutputBtn.Click += new System.EventHandler(this.iCalOutputBtn_Click);
            // 
            // foundLabel
            // 
            this.foundLabel.AutoSize = true;
            this.foundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foundLabel.Location = new System.Drawing.Point(358, 196);
            this.foundLabel.Name = "foundLabel";
            this.foundLabel.Size = new System.Drawing.Size(68, 16);
            this.foundLabel.TabIndex = 12;
            this.foundLabel.Text = "We found:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = groupCount.ToString() + " groups";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = peopleCount.ToString() + " people";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = daycount.ToString() + " days";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Page3FileOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foundLabel);
            this.Controls.Add(this.csvOutputBtn);
            this.Controls.Add(this.excelOutputBtn);
       this.Controls.Add(this.iCalOutputBtn);
            this.Controls.Add(this.labelSubHeader);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Page3FileOutput";
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Maker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSubHeader;
        private System.Windows.Forms.Button excelOutputBtn;
        private System.Windows.Forms.Button csvOutputBtn;
        private System.Windows.Forms.Button iCalOutputBtn;
        private System.Windows.Forms.Label foundLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
    }
}

