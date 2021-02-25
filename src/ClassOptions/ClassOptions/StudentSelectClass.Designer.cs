namespace ClassOptions
{
    partial class StudentSelectClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OK_Button = new System.Windows.Forms.Button();
            this.ClassCreditLabel = new System.Windows.Forms.Label();
            this.ClassNameLabel = new System.Windows.Forms.Label();
            this.ClassIDLabel = new System.Windows.Forms.Label();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Grade_Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "课程编号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "学    分：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "课程名称：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "授课教师：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Location = new System.Drawing.Point(33, 108);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 86);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "教工号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "教师姓名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "课程容量";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "课程余量";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OK_Button
            // 
            this.OK_Button.BackColor = System.Drawing.Color.White;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Location = new System.Drawing.Point(122, 213);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 12;
            this.OK_Button.Text = "确定";
            this.OK_Button.UseVisualStyleBackColor = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // ClassCreditLabel
            // 
            this.ClassCreditLabel.Location = new System.Drawing.Point(335, 52);
            this.ClassCreditLabel.Name = "ClassCreditLabel";
            this.ClassCreditLabel.Size = new System.Drawing.Size(100, 12);
            this.ClassCreditLabel.TabIndex = 15;
            this.ClassCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClassCreditLabel.Click += new System.EventHandler(this.ClassCreditLabel_Click);
            // 
            // ClassNameLabel
            // 
            this.ClassNameLabel.Location = new System.Drawing.Point(100, 52);
            this.ClassNameLabel.Name = "ClassNameLabel";
            this.ClassNameLabel.Size = new System.Drawing.Size(157, 12);
            this.ClassNameLabel.TabIndex = 14;
            this.ClassNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClassNameLabel.Click += new System.EventHandler(this.ClassNameLabel_Click);
            // 
            // ClassIDLabel
            // 
            this.ClassIDLabel.Location = new System.Drawing.Point(100, 20);
            this.ClassIDLabel.Name = "ClassIDLabel";
            this.ClassIDLabel.Size = new System.Drawing.Size(100, 12);
            this.ClassIDLabel.TabIndex = 13;
            this.ClassIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClassIDLabel.Click += new System.EventHandler(this.ClassIDLabel_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColor = System.Drawing.Color.White;
            this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Button.Location = new System.Drawing.Point(238, 213);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 16;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.UseVisualStyleBackColor = false;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Grade_Label
            // 
            this.Grade_Label.Location = new System.Drawing.Point(335, 20);
            this.Grade_Label.Name = "Grade_Label";
            this.Grade_Label.Size = new System.Drawing.Size(100, 12);
            this.Grade_Label.TabIndex = 18;
            this.Grade_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Grade_Label.Click += new System.EventHandler(this.Grade_Label_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "选修学期：";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // StudentSelectClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(459, 248);
            this.Controls.Add(this.Grade_Label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.ClassCreditLabel);
            this.Controls.Add(this.ClassNameLabel);
            this.Controls.Add(this.ClassIDLabel);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentSelectClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StudentSelectClass";
            this.Click += new System.EventHandler(this.Form_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label ClassCreditLabel;
        private System.Windows.Forms.Label ClassNameLabel;
        private System.Windows.Forms.Label ClassIDLabel;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label Grade_Label;
        private System.Windows.Forms.Label label7;
    }
}