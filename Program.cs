using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        private static DebuggerForm _debuggerForm = null;
        private static Form1 _form1 = null;
        static bool _stopRequested = false;
        static String[] _sentences = {
            "Salut",
            "Hey !",
            "Pk tu me fermes ?",
            "Mais wsh !",
            "STOOOP",
            "Bon ok tiens tu peux m'arrêter.."
        };
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            _debuggerForm = new DebuggerForm();
            _form1 = new Form1();

            Thread backgroundWorker = new Thread(BackgroundWork);

            backgroundWorker.Start();

            foreach (String s in _sentences)
                MessageBox.Show(s, "Info", MessageBoxButtons.OK);
            
            _form1.Show();

            _debuggerForm.ShowDialog();

            _stopRequested = true;
            
            backgroundWorker.Join();

        }

        private static void BackgroundWork()
        {
            Thread.Sleep(1000);
            while (!_stopRequested)
            {
                _form1.SetCursorPosition(Cursor.Position);
                _debuggerForm.SetCursorPosition(Cursor.Position);
                _debuggerForm.SetLabel1("Form1 pos = " + _form1.DesktopLocation.X + "X/" + _form1.DesktopLocation.Y + "Y");
                Thread.Sleep(10);
            }
        }
    }
}