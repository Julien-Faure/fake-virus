using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        private static DebuggerForm debuggerForm = null;
        private static Form1 form1 = null;
        static bool stopRequested = false;
        static String[] sentences = {
            "Salut",
            "Hey !",
            "Pk tu me fermes ?",
            "Mais wsh !",
            "STOOOP",
            "Bon je me casse.."
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            debuggerForm = new DebuggerForm();
            form1 = new Form1();

            Thread backgroundWorker = new Thread(BackgroundWork);

            backgroundWorker.Start();

            //foreach (String s in sentences)
            //    MessageBox.Show(s, "Info", MessageBoxButtons.OK);
            
            form1.Show();

            debuggerForm.ShowDialog();

            stopRequested = true;
            
            backgroundWorker.Join();

        }

        private static void BackgroundWork()
        {
            Thread.Sleep(1000);
            while (!stopRequested)
            {
                form1.SetCursorPosition(Cursor.Position);
                debuggerForm.SetCursorPosition(Cursor.Position);
                debuggerForm.setLabel1("Form1 pos = " + form1.DesktopLocation.X + "X/" + form1.DesktopLocation.Y + "Y");
                Thread.Sleep(10);
            }
        }
    }
}