using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CabManager
{
    static class Program
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //if (!IsAssociated())
            //{
            //    if (MessageBox.Show(null,"Cab Manager Varsayılan Programınız Değil. Varsayılan Olarak Ayarlamak İster Misiniz?","!!!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //    {
            //        Associate();
            //    }
            //}
            //else
            //{
            //    Associate();
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new MainForm(args[0]));
            }
        }

        public static bool IsAssociated()
        {
            return(Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.cab",false)==null);
        }

        public static void Associate()
        {
            try
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.cab");
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Application\\CabManager.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.cab");

                FileReg.CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + "\\1470748527_cab.ico");

                AppReg.CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + "\\1470748527_cab.ico");
                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\"%1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\"%1");

                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\CabManager.exe");

                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch
            {

            }

        }
    }
}
