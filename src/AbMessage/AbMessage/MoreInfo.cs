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
    public partial class MoreInfo : Form
    {
        private bool FormMoveFlag;
        private Point mousePoint;

        public MoreInfo()
        {
            InitializeComponent();
            FormMoveFlag = false;
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 30)
            {
                mousePoint = e.Location;
                FormMoveFlag = true;
            }
        }
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (FormMoveFlag)
            {
                Point temp = e.Location;
                int x = Location.X + temp.X - mousePoint.X;
                int y = Location.Y + temp.Y - mousePoint.Y;
                Location = new Point(x, y);
            }
        }
        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (FormMoveFlag)
                FormMoveFlag = false;
        }
    }
}
