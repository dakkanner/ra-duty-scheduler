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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page3FileOutput));
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSubHeader = new System.Windows.Forms.Label();
            this.excelOutputBtn = new System.Windows.Forms.Button();
            this.csvOutputBtn = new System.Windows.Forms.Button();
            this.iCalOutputBtn = new System.Windows.Forms.Button();
            this.rerunBtn = new System.Windows.Forms.Button();
            this.foundLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.csvExportBtn = new System.Windows.Forms.Button();
            this.labelFairness = new System.Windows.Forms.Label();
            this.textBoxFairness = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(182, 13);
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
            this.labelSubHeader.Location = new System.Drawing.Point(170, 53);
            this.labelSubHeader.Name = "labelSubHeader";
            this.labelSubHeader.Size = new System.Drawing.Size(460, 25);
            this.labelSubHeader.TabIndex = 2;
            this.labelSubHeader.Text = "How do you want to output your calendar?";
            // 
            // excelOutputBtn
            // 
            this.excelOutputBtn.Location = new System.Drawing.Point(344, 179);
            this.excelOutputBtn.Name = "excelOutputBtn";
            this.excelOutputBtn.Size = new System.Drawing.Size(100, 22);
            this.excelOutputBtn.TabIndex = 8;
            this.excelOutputBtn.Text = "Output to Excel";
            this.excelOutputBtn.UseVisualStyleBackColor = true;
            this.excelOutputBtn.Click += new System.EventHandler(this.excelOutputBtn_Click);
            // 
            // csvOutputBtn
            // 
            this.csvOutputBtn.Location = new System.Drawing.Point(344, 209);
            this.csvOutputBtn.Name = "csvOutputBtn";
            this.csvOutputBtn.Size = new System.Drawing.Size(100, 22);
            this.csvOutputBtn.TabIndex = 11;
            this.csvOutputBtn.Text = "Output to a CSV";
            this.csvOutputBtn.UseVisualStyleBackColor = true;
            this.csvOutputBtn.Click += new System.EventHandler(this.csvOutputBtn_Click);
            // 
            // iCalOutputBtn
            // 
            this.iCalOutputBtn.Location = new System.Drawing.Point(269, 239);
            this.iCalOutputBtn.Name = "iCalOutputBtn";
            this.iCalOutputBtn.Size = new System.Drawing.Size(250, 22);
            this.iCalOutputBtn.TabIndex = 11;
            this.iCalOutputBtn.Text = "Create Outlook events and send invites";
            this.iCalOutputBtn.UseVisualStyleBackColor = true;
            this.iCalOutputBtn.Click += new System.EventHandler(this.iCalOutputBtn_Click);
            // 
            // rerunBtn
            // 
            this.rerunBtn.Location = new System.Drawing.Point(295, 367);
            this.rerunBtn.Name = "rerunBtn";
            this.rerunBtn.Size = new System.Drawing.Size(200, 22);
            this.rerunBtn.TabIndex = 8;
            this.rerunBtn.Text = "I don\'t like that schedule. Redo it.";
            this.rerunBtn.UseVisualStyleBackColor = true;
            this.rerunBtn.Click += new System.EventHandler(this.rerunBtn_Click);
            // 
            // foundLabel
            // 
            this.foundLabel.AutoSize = true;
            this.foundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foundLabel.Location = new System.Drawing.Point(358, 89);
            this.foundLabel.Name = "foundLabel";
            this.foundLabel.Size = new System.Drawing.Size(68, 16);
            this.foundLabel.TabIndex = 12;
            this.foundLabel.Text = "We found:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Some groups";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Some people";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Some days";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // csvExportBtn
            // 
            this.csvExportBtn.Location = new System.Drawing.Point(284, 282);
            this.csvExportBtn.Name = "csvExportBtn";
            this.csvExportBtn.Size = new System.Drawing.Size(220, 22);
            this.csvExportBtn.TabIndex = 16;
            this.csvExportBtn.Text = "Export calendar for later or to manually edit";
            this.csvExportBtn.UseVisualStyleBackColor = true;
            this.csvExportBtn.Click += new System.EventHandler(this.csvExportBtn_Click);
            // 
            // labelFairness
            // 
            this.labelFairness.AutoSize = true;
            this.labelFairness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFairness.Location = new System.Drawing.Point(12, 88);
            this.labelFairness.Name = "labelFairness";
            this.labelFairness.Size = new System.Drawing.Size(175, 16);
            this.labelFairness.TabIndex = 17;
            this.labelFairness.Text = "Uneven day count by group:";
            // 
            // textBoxFairness
            // 
            this.textBoxFairness.Location = new System.Drawing.Point(344, 413);
            this.textBoxFairness.Name = "textBoxFairness";
            this.textBoxFairness.Size = new System.Drawing.Size(100, 20);
            this.textBoxFairness.TabIndex = 18;
            this.textBoxFairness.TextChanged += new System.EventHandler(this.textBoxFairness_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(306, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Max number of uneven days:";
            // 
            // Page3FileOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFairness);
            this.Controls.Add(this.labelFairness);
            this.Controls.Add(this.csvExportBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foundLabel);
            this.Controls.Add(this.csvOutputBtn);
            this.Controls.Add(this.excelOutputBtn);
            this.Controls.Add(this.iCalOutputBtn);
            this.Controls.Add(this.rerunBtn);
            this.Controls.Add(this.labelSubHeader);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Page3FileOutput";
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
        private System.Windows.Forms.Button rerunBtn;
        private System.Windows.Forms.Label foundLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button csvExportBtn;
        private System.Windows.Forms.Label labelFairness;
        private System.Windows.Forms.TextBox textBoxFairness;
        private System.Windows.Forms.Label label4;
        
    }
}

