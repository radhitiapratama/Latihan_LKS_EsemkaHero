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
    public partial class MasterClan : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int op = -1;

        public MasterClan()
        {
            InitializeComponent();
        }

        private void MasterClan_Load(object sender, EventArgs e)
        {
            bindingSource2.AddNew();
            loadClan();
        }

        void loadClan()
        {
            bindingSource1.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                bindingSource1.DataSource = db.Clans.Where(f => f.Name.Contains(textBox1.Text)).ToList();
            }
            else
            {
                bindingSource1.DataSource = db.Clans.ToList();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadClan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }

        void clearInput()
        {
            this.op = -1;
            bindingSource2.Clear();
            bindingSource2.AddNew();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource2.Current is Clan clan)
            {
                db.Clans.AddOrUpdate(clan);
                int rows = db.SaveChanges();

                if (rows > 0)
                {
                    if (this.op == -1)
                    {
                        Alerts.Success("Clan berhasil di tambahkan !");
                    }
                    else
                    {
                        Alerts.Success("Clan berhasil di edit !");
                    }
                    loadClan();
                    clearInput();
                    return;
                }

                if (this.op == -1)
                {
                    Alerts.Error("Clan gagal di tambahkan !");
                }
                else
                {
                    Alerts.Error("Clan gagal di edit !");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Clan clan)
            {
                var data = db.Clans.Where(f => f.ID == clan.ID).AsNoTracking().First();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Clan clan)
            {
                var data = db.Clans.Where(f => f.ID == clan.ID).AsNoTracking().First();
                bindingSource2.DataSource = data;
                this.op = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Clan clan)
            {
                if (Alerts.Confirm("Yakin hapus data?") == DialogResult.Yes)
                {
                    db.Clans.Remove(clan);
                    int rows = db.SaveChanges();
                    if (rows > 0)
                    {
                        Alerts.Success("Data berhasil di hapus!");
                        loadClan();
                        clearInput();
                    }
                    else
                    {
                        Alerts.Error("Data gagal di hapus!");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearInput();
        }
    }
}
