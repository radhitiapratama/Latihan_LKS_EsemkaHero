using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHero
{
    class AppContext : ApplicationContext
    {
        public AppContext(Form form)
        {
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            int count = Application.OpenForms.Cast<Form>().Where(f => f.TopLevel).Count();
            if (count == 0)
            {
                Application.Exit();
                ExitThread();
            }

        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppContext(new MainForm()));
        }
    }
}
