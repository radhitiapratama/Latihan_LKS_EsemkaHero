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
    public partial class MasterHero : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int op = -1;

        public MasterHero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }


        private void MasterHero_Load(object sender, EventArgs e)
        {
            bindingSource2.AddNew();
            loadHero();
            loadClan();
        }

        void clearInput()
        {
            bindingSource2.Clear();
            bindingSource2.AddNew();
            comboBox2.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            this.op = -1;
        }

        void loadClan()
        {
            List<Clan> listClan = new List<Clan>();
            Clan clan = new Clan
            {
                ID = 0,
                Name = ""
            };

            List<Clan> listClan2 = new List<Clan>();
            Clan clan2 = new Clan
            {
                ID = 0,
                Name = ""
            };


            listClan.Add(clan);
            listClan2.Add(clan2);

            var query = db.Clans.OrderBy(f => f.Name).ToList();

            foreach (var q in query)
            {
                listClan.Add(q);
                listClan2.Add(q);
            }

            comboBox1.DataSource = listClan;
            comboBox1.SelectedIndex = 0;

            comboBox2.DataSource = listClan2;
            comboBox2.SelectedIndex = 0;
        }

        void loadHero()
        {
            var query = db.Heroes.AsQueryable();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                query = query.Where(f => f.Name.Contains(textBox1.Text));
            }

            if (comboBox1.SelectedIndex != -1 && (int)comboBox1.SelectedValue != 0)
            {
                query = query.Where(f => f.ClanID == (int)comboBox1.SelectedValue);
            }

            var result = query.ToList();
            bindingSource1.DataSource = result;
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Hero hero)
            {
                if (e.ColumnIndex == BirthDateColumn.Index)
                {
                    e.Value = hero.BirthDate.ToString("dd-MMM-yyyy");
                }

                if (e.ColumnIndex == ClanColumn.Index)
                {
                    var clan = hero.Clan;
                    if (clan == null)
                    {
                        e.Value = "Unknown";
                        return;
                    }
                    e.Value = hero.Clan.Name;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadHero();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHero();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource2.Current is Hero hero)
            {
                hero.BirthDate = dateTimePicker1.Value;
                if ((int)comboBox2.SelectedValue != 0)
                {
                    hero.ClanID = (int)comboBox2.SelectedValue;
                }
                else
                {
                    hero.ClanID = null;
                }
                db.Heroes.AddOrUpdate(hero);
                int rows = db.SaveChanges();

                if (rows > 0)
                {
                    if (this.op == -1)
                    {
                        Alerts.Success("Hero berhasil di tambahkan!");
                    }
                    else
                    {
                        Alerts.Success("Hero berhasil di edit!");
                    }

                    loadHero();
                    clearInput();
                    return;
                }

                if (this.op == -1)
                {
                    Alerts.Error("Hero gagal di tambahkan!");
                }
                else
                {
                    Alerts.Error("Hero gagal di edit!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (bindingSource1.Current is Hero hero)
            {
                if (Alerts.Confirm("Yakin hapus hero?") == DialogResult.Yes)
                {
                    db.Heroes.Remove(hero);

                    int rows = db.SaveChanges();
                    if (rows > 0)
                    {
                        Alerts.Success("Hero berhasil di hapus!");
                        loadHero();
                        clearInput();
                    }
                    else
                    {
                        Alerts.Success("Hero gagal di hapus!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Hero hero)
            {
                var data = db.Heroes.Where(f => f.ID == hero.ID).AsNoTracking().First();
                bindingSource2.DataSource = data;
                dateTimePicker1.Value = hero.BirthDate;
                if (hero.ClanID != null) comboBox2.SelectedValue = hero.ClanID;
                this.op = 1;
            }
        }

    }
}
