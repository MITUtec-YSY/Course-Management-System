namespace ClassOption.UI
{
    partial class StudentDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDataForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentID = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.StudentGrade = new System.Windows.Forms.Label();
            this.StudentCollege = new System.Windows.Forms.Label();
            this.StudentMajor = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.Close_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "年级：";
            // 
            // StudentID
            // 
            this.StudentID.AutoSize = true;
            this.StudentID.Location = new System.Drawing.Point(66, 37);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(0, 12);
            this.StudentID.TabIndex = 5;
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Location = new System.Drawing.Point(66, 64);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(0, 12);
            this.StudentName.TabIndex = 6;
            // 
            // StudentGrade
            // 
            this.StudentGrade.AutoSize = true;
            this.StudentGrade.Location = new System.Drawing.Point(66, 93);
            this.StudentGrade.Name = "StudentGrade";
            this.StudentGrade.Size = new System.Drawing.Size(0, 12);
            this.StudentGrade.TabIndex = 7;
            // 
            // StudentCollege
            // 
            this.StudentCollege.AutoSize = true;
            this.StudentCollege.Location = new System.Drawing.Point(293, 37);
            this.StudentCollege.Name = "StudentCollege";
            this.StudentCollege.Size = new System.Drawing.Size(0, 12);
            this.StudentCollege.TabIndex = 8;
            // 
            // StudentMajor
            // 
            this.StudentMajor.AutoSize = true;
            this.StudentMajor.Location = new System.Drawing.Point(293, 64);
            this.StudentMajor.Name = "StudentMajor";
            this.StudentMajor.Size = new System.Drawing.Size(0, 12);
            this.StudentMajor.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(21, 141);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(446, 335);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "已选课程：";
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.White;
            this.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Button.Location = new System.Drawing.Point(212, 493);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(75, 23);
            this.Close_Button.TabIndex = 12;
            this.Close_Button.Text = "关闭";
            this.Close_Button.UseVisualStyleBackColor = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "学院：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "专业：";
            // 
            // StudentDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(490, 529);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.StudentMajor);
            this.Controls.Add(this.StudentCollege);
            this.Controls.Add(this.StudentGrade);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.StudentID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.Text = "StudentDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StudentID;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.Label StudentGrade;
        private System.Windows.Forms.Label StudentCollege;
        private System.Windows.Forms.Label StudentMajor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}