using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CAPSLOCK_APP
{
    public partial class Form1 : Form
    {

        string ProgramAdi = "CAPSLOCK APP";

        public Form1()
        {
            InitializeComponent();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(ProgramAdi, "\"" + Application.ExecutablePath + "\"");

            
        }

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern short GetAsyncKeyState(int Tus);

        public static bool TusKontrol(byte Kod) 
        {
            if (GetAsyncKeyState((int)Kod) == System.Int16.MinValue + 1)
                return true;
            else
                return false;
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TusKontrol((byte)Keys.CapsLock))
            {
                if (Control.IsKeyLocked(Keys.CapsLock))
                {                                
                    this.Show();
                }
                else
                {                                  
                    this.Hide();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (TusKontrol((byte)Keys.CapsLock))
            {
                if (Control.IsKeyLocked(Keys.CapsLock))
                {
                    this.Show();
                }
                else
                {
                    this.Hide();
                }
            }
        }

        
    }
}
