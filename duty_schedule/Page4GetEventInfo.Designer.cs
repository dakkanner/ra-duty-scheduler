using System.Windows.Forms;
namespace Duty_Schedule
{
    partial class Page4GetEventInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page4GetEventInfo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCcList = new System.Windows.Forms.TextBox();
            this.textBoxSenderEmail = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelWarning = new System.Windows.Forms.Label();
            this.labelWarning2 = new System.Windows.Forms.Label();
            this.checkBoxAllDay = new System.Windows.Forms.CheckBox();
            this.checkBoxMergeDays = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableReminder = new System.Windows.Forms.CheckBox();
            this.textBoxEventTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxDontSendEmails = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(460, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Email";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(397, 630);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(316, 630);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Send";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartTime.Location = new System.Drawing.Point(46, 9);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(132, 18);
            this.labelStartTime.TabIndex = 3;
            this.labelStartTime.Text = "Calendar start time";
            this.labelStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM dd yyyy hh mm ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(20, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2014, 1, 1, 19, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "What are the email addresses for everyone?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(346, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Want to CC anyone? (separate emails with spaces)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 547);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "What\'s your Outlook email address? (enter if sending invites failed)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCcList
            // 
            this.textBoxCcList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCcList.Location = new System.Drawing.Point(12, 512);
            this.textBoxCcList.Name = "textBoxCcList";
            this.textBoxCcList.Size = new System.Drawing.Size(460, 20);
            this.textBoxCcList.TabIndex = 7;
            // 
            // textBoxSenderEmail
            // 
            this.textBoxSenderEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSenderEmail.Location = new System.Drawing.Point(12, 567);
            this.textBoxSenderEmail.Name = "textBoxSenderEmail";
            this.textBoxSenderEmail.Size = new System.Drawing.Size(460, 20);
            this.textBoxSenderEmail.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Email";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Email";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(35, 630);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(219, 13);
            this.labelWarning.TabIndex = 8;
            this.labelWarning.Text = "*Warning: This feature may not work properly";
            // 
            // labelWarning2
            // 
            this.labelWarning2.AutoSize = true;
            this.labelWarning2.Location = new System.Drawing.Point(61, 645);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(163, 13);
            this.labelWarning2.TabIndex = 9;
            this.labelWarning2.Text = "depending on your email provider";
            // 
            // checkBoxAllDay
            // 
            this.checkBoxAllDay.AutoSize = true;
            this.checkBoxAllDay.Location = new System.Drawing.Point(68, 56);
            this.checkBoxAllDay.Name = "checkBoxAllDay";
            this.checkBoxAllDay.Size = new System.Drawing.Size(110, 17);
            this.checkBoxAllDay.TabIndex = 14;
            this.checkBoxAllDay.Text = "Events are all day";
            this.checkBoxAllDay.UseVisualStyleBackColor = true;
            this.checkBoxAllDay.CheckedChanged += new System.EventHandler(this.checkBoxAllDay_CheckedChanged);
            // 
            // checkBoxMergeDays
            // 
            this.checkBoxMergeDays.AutoSize = true;
            this.checkBoxMergeDays.Location = new System.Drawing.Point(276, 47);
            this.checkBoxMergeDays.Name = "checkBoxMergeDays";
            this.checkBoxMergeDays.Size = new System.Drawing.Size(184, 17);
            this.checkBoxMergeDays.TabIndex = 15;
            this.checkBoxMergeDays.Text = "Merge identical consecutive days";
            this.checkBoxMergeDays.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableReminder
            // 
            this.checkBoxEnableReminder.AutoSize = true;
            this.checkBoxEnableReminder.Checked = true;
            this.checkBoxEnableReminder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableReminder.Location = new System.Drawing.Point(276, 24);
            this.checkBoxEnableReminder.Name = "checkBoxEnableReminder";
            this.checkBoxEnableReminder.Size = new System.Drawing.Size(135, 17);
            this.checkBoxEnableReminder.TabIndex = 16;
            this.checkBoxEnableReminder.Text = "Enable 1 hour reminder";
            this.checkBoxEnableReminder.UseVisualStyleBackColor = true;
            this.checkBoxEnableReminder.CheckedChanged += new System.EventHandler(this.checkBoxEnableReminder_CheckedChanged);
            // 
            // textBoxEventTitle
            // 
            this.textBoxEventTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxEventTitle.Location = new System.Drawing.Point(12, 460);
            this.textBoxEventTitle.Name = "textBoxEventTitle";
            this.textBoxEventTitle.Size = new System.Drawing.Size(460, 20);
            this.textBoxEventTitle.TabIndex = 18;
            this.textBoxEventTitle.Text = "Duty:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Base event title";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxDontSendEmails
            // 
            this.checkBoxDontSendEmails.AutoSize = true;
            this.checkBoxDontSendEmails.Location = new System.Drawing.Point(82, 593);
            this.checkBoxDontSendEmails.Name = "checkBoxDontSendEmails";
            this.checkBoxDontSendEmails.Size = new System.Drawing.Size(329, 17);
            this.checkBoxDontSendEmails.TabIndex = 19;
            this.checkBoxDontSendEmails.Text = "Add events only to my calendar (don\'t send invites automatically)";
            this.checkBoxDontSendEmails.UseVisualStyleBackColor = true;
            // 
            // Page4GetEventInfo
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 665);
            this.Controls.Add(this.checkBoxDontSendEmails);
            this.Controls.Add(this.textBoxEventTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxEnableReminder);
            this.Controls.Add(this.checkBoxMergeDays);
            this.Controls.Add(this.checkBoxAllDay);
            this.Controls.Add(this.labelWarning2);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.textBoxCcList);
            this.Controls.Add(this.textBoxSenderEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Page4GetEventInfo";
            this.Text = "Event Info";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCcList;
        private System.Windows.Forms.TextBox textBoxSenderEmail;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label labelWarning;
        private Label labelWarning2;
        private CheckBox checkBoxAllDay;
        private CheckBox checkBoxMergeDays;
        private CheckBox checkBoxEnableReminder;
        private TextBox textBoxEventTitle;
        private Label label4;
        private CheckBox checkBoxDontSendEmails;
    }
}