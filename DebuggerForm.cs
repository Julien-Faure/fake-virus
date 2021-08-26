using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DebuggerForm : Form,CursorPositionUser
    {
        public DebuggerForm()
        {
            InitializeComponent();
        }
        
        public void SetCursorPosition(Point position)
        {
            posLabel.Text = "Cursor position = " + position.X + "X/" + position.Y + "Y";
        }

        public void setLabel1(String value)
        {
            label1.Text = value;
        }
    }
}