namespace ClassOption.UI
{
    /// <summary>
    /// 修改学生信息窗体
    /// </summary>
    partial class StudentEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEditForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ReSet_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.StudentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentNameBox = new System.Windows.Forms.TextBox();
            this.StudentGradeBox = new System.Windows.Forms.TextBox();
            this.StudentMajorBox = new System.Windows.Forms.TextBox();
            this.StudentCollegeCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "年级：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "专业：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "学院：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(125, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReSet_Button
            // 
            this.ReSet_Button.BackColor = System.Drawing.Color.White;
            this.ReSet_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReSet_Button.Location = new System.Drawing.Point(206, 137);
            this.ReSet_Button.Name = "ReSet_Button";
            this.ReSet_Button.Size = new System.Drawing.Size(75, 23);
            this.ReSet_Button.TabIndex = 9;
            this.ReSet_Button.Text = "重置";
            this.ReSet_Button.UseVisualStyleBackColor = false;
            this.ReSet_Button.Click += new System.EventHandler(this.ReSet_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColor = System.Drawing.Color.White;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Location = new System.Drawing.Point(287, 137);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.UseVisualStyleBackColor = false;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // StudentID
            // 
            this.StudentID.AutoSize = true;
            this.StudentID.Location = new System.Drawing.Point(84, 46);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(0, 12);
            this.StudentID.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "学号：";
            // 
            // StudentNameBox
            // 
            this.StudentNameBox.Location = new System.Drawing.Point(84, 70);
            this.StudentNameBox.Name = "StudentNameBox";
            this.StudentNameBox.Size = new System.Drawing.Size(169, 21);
            this.StudentNameBox.TabIndex = 13;
            // 
            // StudentGradeBox
            // 
            this.StudentGradeBox.Location = new System.Drawing.Point(84, 97);
            this.StudentGradeBox.Name = "StudentGradeBox";
            this.StudentGradeBox.Size = new System.Drawing.Size(169, 21);
            this.StudentGradeBox.TabIndex = 14;
            // 
            // StudentMajorBox
            // 
            this.StudentMajorBox.Location = new System.Drawing.Point(321, 70);
            this.StudentMajorBox.Name = "StudentMajorBox";
            this.StudentMajorBox.Size = new System.Drawing.Size(183, 21);
            this.StudentMajorBox.TabIndex = 16;
            // 
            // StudentCollegeCB
            // 
            this.StudentCollegeCB.FormattingEnabled = true;
            this.StudentCollegeCB.Location = new System.Drawing.Point(321, 43);
            this.StudentCollegeCB.Name = "StudentCollegeCB";
            this.StudentCollegeCB.Size = new System.Drawing.Size(183, 20);
            this.StudentCollegeCB.TabIndex = 17;
            // 
            // StudentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(521, 172);
            this.Controls.Add(this.StudentCollegeCB);
            this.Controls.Add(this.StudentMajorBox);
            this.Controls.Add(this.StudentGradeBox);
            this.Controls.Add(this.StudentNameBox);
            this.Controls.Add(this.StudentID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.ReSet_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StudentEditForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReSet_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label StudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StudentNameBox;
        private System.Windows.Forms.TextBox StudentGradeBox;
        private System.Windows.Forms.TextBox StudentMajorBox;
        private System.Windows.Forms.ComboBox StudentCollegeCB;
    }
}