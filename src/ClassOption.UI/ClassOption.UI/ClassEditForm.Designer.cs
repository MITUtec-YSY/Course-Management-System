namespace ClassOption.UI
{
    /// <summary>
    /// 课程数据修改窗体
    /// </summary>
    partial class ClassEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClassCreditBox = new System.Windows.Forms.TextBox();
            this.ClassNameBox = new System.Windows.Forms.TextBox();
            this.ClassCapBox = new System.Windows.Forms.TextBox();
            this.ClassGradeBox = new System.Windows.Forms.TextBox();
            this.ClassIntroductBox = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ClassID = new System.Windows.Forms.Label();
            this.ClassCollegeCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "课程名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "选修学期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "课程学分：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "课程容量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "所属学院：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "课程简介：";
            // 
            // ClassCreditBox
            // 
            this.ClassCreditBox.Location = new System.Drawing.Point(314, 29);
            this.ClassCreditBox.Name = "ClassCreditBox";
            this.ClassCreditBox.Size = new System.Drawing.Size(100, 21);
            this.ClassCreditBox.TabIndex = 7;
            // 
            // ClassNameBox
            // 
            this.ClassNameBox.Location = new System.Drawing.Point(104, 59);
            this.ClassNameBox.Name = "ClassNameBox";
            this.ClassNameBox.Size = new System.Drawing.Size(142, 21);
            this.ClassNameBox.TabIndex = 8;
            // 
            // ClassCapBox
            // 
            this.ClassCapBox.Location = new System.Drawing.Point(314, 59);
            this.ClassCapBox.Name = "ClassCapBox";
            this.ClassCapBox.Size = new System.Drawing.Size(100, 21);
            this.ClassCapBox.TabIndex = 9;
            // 
            // ClassGradeBox
            // 
            this.ClassGradeBox.Location = new System.Drawing.Point(104, 89);
            this.ClassGradeBox.Name = "ClassGradeBox";
            this.ClassGradeBox.Size = new System.Drawing.Size(100, 21);
            this.ClassGradeBox.TabIndex = 10;
            // 
            // ClassIntroductBox
            // 
            this.ClassIntroductBox.Location = new System.Drawing.Point(104, 120);
            this.ClassIntroductBox.Multiline = true;
            this.ClassIntroductBox.Name = "ClassIntroductBox";
            this.ClassIntroductBox.Size = new System.Drawing.Size(310, 79);
            this.ClassIntroductBox.TabIndex = 12;
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(124, 219);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 13;
            this.OK_Button.Text = "确认";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(286, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ClassID
            // 
            this.ClassID.AutoSize = true;
            this.ClassID.Location = new System.Drawing.Point(102, 32);
            this.ClassID.Name = "ClassID";
            this.ClassID.Size = new System.Drawing.Size(0, 12);
            this.ClassID.TabIndex = 16;
            // 
            // ClassCollegeCB
            // 
            this.ClassCollegeCB.FormattingEnabled = true;
            this.ClassCollegeCB.Location = new System.Drawing.Point(272, 89);
            this.ClassCollegeCB.Name = "ClassCollegeCB";
            this.ClassCollegeCB.Size = new System.Drawing.Size(142, 20);
            this.ClassCollegeCB.TabIndex = 17;
            // 
            // ClassEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(457, 254);
            this.Controls.Add(this.ClassCollegeCB);
            this.Controls.Add(this.ClassID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.ClassIntroductBox);
            this.Controls.Add(this.ClassGradeBox);
            this.Controls.Add(this.ClassCapBox);
            this.Controls.Add(this.ClassNameBox);
            this.Controls.Add(this.ClassCreditBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClassEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClassEditForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ClassCreditBox;
        private System.Windows.Forms.TextBox ClassNameBox;
        private System.Windows.Forms.TextBox ClassCapBox;
        private System.Windows.Forms.TextBox ClassGradeBox;
        private System.Windows.Forms.TextBox ClassIntroductBox;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label ClassID;
        private System.Windows.Forms.ComboBox ClassCollegeCB;
    }
}