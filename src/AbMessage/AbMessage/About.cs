using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbMessage
{
    public partial class About : Form
    {
        private bool FormMoveFlag;
        private Point mousePoint;

        public About()
        {
            InitializeComponent();
            FormMoveFlag = false;
        }

        private void CloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 30)
            {
                mousePoint = e.Location;
                FormMoveFlag = true;
            }
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (FormMoveFlag)
            {
                Point temp = e.Location;
                int x = Location.X + temp.X - mousePoint.X;
                int y = Location.Y + temp.Y - mousePoint.Y;
                Location = new Point(x, y);
            }
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormMoveFlag)
                FormMoveFlag = false;
        }
    }
}
