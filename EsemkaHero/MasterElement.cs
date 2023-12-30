using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHero
{
    public partial class MasterElement : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int op = -1;

        public MasterElement()
        {
            InitializeComponent();
        }

        private void MasterElement_Load(object sender, EventArgs e)
        {
            bindingSource2.AddNew();
            loadElement();
        }

        void loadElement()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                bindingSource1.DataSource = db.Elements.Where(f => f.Element1.Contains(textBox1.Text)).ToList();
            }
            else
            {
                bindingSource1.DataSource = db.Elements.ToList();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadElement();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Element element)
            {
                var data = db.Elements.Where(f => f.ID == element.ID).AsNoTracking().First();
                bindingSource2.DataSource = data;
                this.op = 1;
            }
        }

        void clearInput()
        {
            bindingSource2.Clear();
            bindingSource2.AddNew();
            this.op = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Alerts.Error("Semua input wajib di isi");
                return;
            }

            if (bindingSource2.Current is Element element)
            {
                db.Elements.AddOrUpdate(element);
                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    if (this.op == -1)
                    {
                        Alerts.Success("Element berhasil di tambahkan");

                    }
                    else
                    {
                        Alerts.Success("Element berhasil di edit");
                    }
                    loadElement();
                    clearInput();
                    return;
                }

                if (this.op == -1)
                {
                    Alerts.Success("Element gagal di tambahkan");

                }
                else
                {
                    Alerts.Success("Element gagal di edit");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Element element)
            {
                if (Alerts.Confirm("Yakin hapus element?") == DialogResult.Yes)
                {
                    db.Elements.Remove(element);
                    int rows = db.SaveChanges();
                    if (rows > 0)
                    {
                        Alerts.Success("Element berhasil di hapus!");
                        loadElement();
                        clearInput();
                        return;
                    }
                    Alerts.Error("Element berhasil di hapus!");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
