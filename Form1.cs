using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form,CursorPositionUser
    {

        private const int XOffset = 20; 
        private const int YOffset = 30; 
        private const int XMoveRange = 30; 
        private const int YMoveRange = 30; 
        
        public Form1()
        {
            InitializeComponent();
            closeButton.Click += (sender, args) =>
            {
                MessageBox.Show("Bravo tu as réussi :(", "Pfff...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            };
        }


        public void SetCursorPosition(Point position)
        {
            int cursorX = position.X;
            int cursorY = position.Y;
            int formX1 = this.DesktopLocation.X - XOffset;
            int formY1 = this.DesktopLocation.Y - YOffset;
            int formX2 = formX1 + this.Width + XOffset;
            int formY2 = formY1 + this.Height + YOffset;

            bool cursorIsInXRange = cursorX > formX1 && cursorX < formX2;
            bool cursorIsInYRange = cursorY > formY1 && cursorY < formY2;
            
            if (cursorIsInXRange && cursorIsInYRange)
            {
                bool ifCursorIsInFirstHalfOfXRange = cursorX > formX1 && cursorX < (formX1 + (this.Width / 2));
                bool ifCursorIsInFirstHalfOfYRange = cursorY > formY1 && cursorY < (formY1 + (this.Height / 2));

                if (ifCursorIsInFirstHalfOfXRange && ifCursorIsInFirstHalfOfYRange)
                    this.DesktopLocation = new Point(this.DesktopLocation.X + XMoveRange, this.DesktopLocation.Y + YMoveRange);
                else if (ifCursorIsInFirstHalfOfXRange) //&& !ifCursorIsInFirstHalfOfYRange
                    this.DesktopLocation = new Point(this.DesktopLocation.X + XMoveRange, this.DesktopLocation.Y - YMoveRange);
                else if (ifCursorIsInFirstHalfOfYRange) //&& !ifCursorIsInFirstHalfOfXRange
                    this.DesktopLocation = new Point(this.DesktopLocation.X - XMoveRange, this.DesktopLocation.Y + YMoveRange);
                else
                    this.DesktopLocation = new Point(this.DesktopLocation.X - XMoveRange, this.DesktopLocation.Y - YMoveRange);

                if ((this.DesktopLocation.X + this.Width) >= Screen.PrimaryScreen.Bounds.Width)
                    this.DesktopLocation = new Point(0, this.DesktopLocation.Y);
                else if (this.DesktopLocation.X < 0)
                    this.DesktopLocation = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.DesktopLocation.Y);

                if((this.DesktopLocation.Y + this.Height) >= Screen.PrimaryScreen.Bounds.Height)
                    this.DesktopLocation = new Point(this.DesktopLocation.X, 0);
                else if (this.DesktopLocation.Y < 0)
                    this.DesktopLocation = new Point(this.DesktopLocation.X, Screen.PrimaryScreen.Bounds.Height - this.Height);
            }
        }
    }
}