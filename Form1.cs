using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form,CursorPositionUser
    {
        private readonly EscapeFormComportment _escapeFormComportment;
        
        public Form1()
        {
            InitializeComponent();
            closeButton.Click += (sender, args) =>
            {
                MessageBox.Show("Bravo tu as réussi :(", "Pfff...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            };

            _escapeFormComportment = new EscapeFormComportment(
                Width, 
                Height,
                Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            
            _escapeFormComportment.SetUpdateFormPositionEvent((x, y) => this.DesktopLocation = new Point(x,y));
        }

        public void SetCursorPosition(Point position)
        {
            _escapeFormComportment.UpdateMousePosition(position.X,position.Y, 
                DesktopLocation.X, DesktopLocation.Y);
        }
    }
}