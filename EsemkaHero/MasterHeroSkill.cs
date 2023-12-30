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
    public partial class MasterHeroSkill : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int op = -1;
        int hsID = -1;

        public MasterHeroSkill()
        {
            InitializeComponent();
        }

        private void MasterHeroSkill_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = decimal.MaxValue;

            bindingSource2.AddNew();
            loadHeroSkill();
            loadHero();
            loadSkill();
        }

        void loadHero()
        {
            var query = db.Heroes.OrderBy(f => f.Name).ToList();
            query.Insert(0, new Hero()
            {
                ID = 0,
                Name = ""
            });

            comboBox1.DataSource = query;
            comboBox1.SelectedIndex = 0;
        }

        void loadSkill()
        {
            var query = db.Skills.OrderBy(f => f.Name).ToList();
            query.Insert(0, new Skill
            {
                ID = 0,
                Name = ""
            });

            comboBox2.DataSource = query;
            comboBox2.SelectedIndex = 0;
        }

        void loadHeroSkill()
        {
            bindingSource1.Clear();
            var query = db.HeroSkills.AsQueryable();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                query = query.Where(f => f.Hero.Name.Contains(textBox1.Text));
            }

            var result = query.ToList();
            bindingSource1.DataSource = result;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is HeroSkill heroSkill)
            {
                if (e.ColumnIndex == HeroColumn.Index)
                {
                    e.Value = heroSkill.Hero.Name;
                }

                if (e.ColumnIndex == SkillColumn.Index)
                {
                    e.Value = heroSkill.Skill.Name;
                }

                if (e.ColumnIndex == PowerColumn.Index)
                {
                    e.Value = heroSkill.Power.ToString("N");
                }
            }

        }

        void resetState()
        {
            bindingSource2.Clear();
            bindingSource2.AddNew();
            this.op = -1;
            this.hsID = -1;
            numericUpDown1.Value = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadHeroSkill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var heroId = (int)comboBox1.SelectedValue;
            var skillId = (int)comboBox2.SelectedValue;

            if (heroId == 0 || skillId == 0)
            {
                Alerts.Error("Hero atau skill wajib di isi!");
                return;
            }

            if (this.op == -1)
            {
                var check = db.HeroSkills.Where(f => f.HeroID == heroId && f.SkillID == skillId).FirstOrDefault();
                if (check != null)
                {
                    Alerts.Error("Hero sudah punya skill yang di pilih!");
                    return;
                }
            }
            else
            {
                var check = db.HeroSkills.Where(f => f.HeroID == heroId && f.SkillID == skillId && f.ID != this.hsID).FirstOrDefault();
                if (check != null)
                {
                    Alerts.Error("Hero sudah punya skill yang di pilih!");
                    return;
                }
            }



            if (bindingSource2.Current is HeroSkill heroSkill)
            {
                heroSkill.HeroID = heroId;
                heroSkill.SkillID = skillId;
                heroSkill.Power = (int)numericUpDown1.Value;
                db.HeroSkills.AddOrUpdate(heroSkill);
                int rows = db.SaveChanges();

                if (rows > 0)
                {
                    if (this.op == -1)
                    {
                        Alerts.Success("Hero skill berhasil di tambahkan!");
                    }
                    else
                    {
                        Alerts.Success("Hero skill berhasil di edit!");
                    }
                    loadHeroSkill();
                    resetState();
                }
                else
                {
                    if (this.op == -1)
                    {
                        Alerts.Error("Hero skill gagal di tambahkan!");
                    }
                    else
                    {
                        Alerts.Error("Hero skill gagal di edit!");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is HeroSkill hs)
            {
                if (Alerts.Confirm("Yakin hapus hero skill ?") == DialogResult.Yes)
                {
                    db.HeroSkills.Remove(hs);
                    int rows = db.SaveChanges();

                    if (rows > 0)
                    {
                        Alerts.Success("Hero skill berhasil di hapus!");
                        loadHeroSkill();
                        resetState();
                    }
                    else
                    {
                        Alerts.Error("Hero skill gagal di hapus!");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is HeroSkill hs)
            {
                var data = db.HeroSkills.Where(f => f.ID == hs.ID).AsNoTracking().First();
                bindingSource2.DataSource = data;
                this.op = 1;
                this.hsID = hs.ID;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            resetState();
        }
    }
}
