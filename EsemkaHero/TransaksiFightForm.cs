using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHero
{
    public partial class TransaksiFightForm : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int heroPower1 = 0;
        int heroPower2 = 0;


        public TransaksiFightForm()
        {
            InitializeComponent();
        }

        private void TransaksiFightForm_Load(object sender, EventArgs e)
        {
            bindingSource2.AddNew();
            loadHero();
        }

        void loadHero()
        {
            bindingSource1.Clear();
            var hero = db.Heroes.OrderBy(f => f.Name).ToList();
            bindingSource1.DataSource = hero;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Hero hero)
            {
                bindingSource2.Clear();
                var data = db.HeroSkills.Where(f => f.HeroID == hero.ID).Select(g => new
                {
                    g.Skill.Name,
                    g.Skill.ID
                }).ToList();

                bindingSource2.DataSource = data;
                bindingSource3.Clear();
                heroPower1 = 0;
                checkPointHero();
                checkWinner();
                loadHero2(hero);
            }
        }

        void loadHero2(Hero hero)
        {
            bindingSource4.Clear();
            bindingSource4.DataSource = db.Heroes.Where(f => f.ID != hero.ID).OrderBy(f => f.Name).ToList();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Hero hero)
            {
                if (bindingSource2.Current != null)
                {
                    var skillID = (int)comboBox3.SelectedValue;
                    bindingSource2.RemoveCurrent();
                    var data = db.HeroSkills.Where(f => f.SkillID == skillID && f.HeroID == hero.ID).FirstOrDefault();

                    if (data == null)
                    {
                        Alerts.Error("Skill not found!");
                        return;
                    }

                    bindingSource3.Add(data);
                    heroPower1 += (int)data.Power;
                    checkPointHero();
                    checkWinner();
                    comboBox1.Enabled = false;
                }
            }
        }

        void checkWinner()
        {
            if (heroPower1 > heroPower2)
            {
                if (bindingSource1.Current is Hero hero)
                {
                    label7.Text = hero.Name;
                }
            }
            else
            {
                if (bindingSource4.Current is Hero hero)
                {
                    label7.Text = hero.Name;
                }
            }
        }

        void checkPointHero()
        {
            label4.Text = $"{heroPower1.ToString("N")}";
            label5.Text = $"{heroPower2.ToString("N")}";
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is HeroSkill heroSkill)
            {
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

        private void bindingSource4_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource4.Current is Hero hero)
            {
                var data = db.HeroSkills.Where(f => f.HeroID == hero.ID).Select(g => new
                {
                    g.Skill.ID,
                    g.Skill.Name
                }).ToList();

                bindingSource5.DataSource = data;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource4.Current is Hero hero)
            {
                if (bindingSource5.Current != null)
                {
                    var SkillID = (int)comboBox4.SelectedValue;
                    var data = db.HeroSkills.Where(f => f.SkillID == SkillID && f.HeroID == hero.ID).FirstOrDefault();

                    if (data == null)
                    {
                        Alerts.Error("Skill not found!");
                        return;
                    }

                    bindingSource5.RemoveCurrent();
                    bindingSource6.Add(data);

                    heroPower2 += (int)data.Power;
                    checkPointHero();
                    checkWinner();
                    comboBox2.Enabled = false;
                }
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].DataBoundItem is HeroSkill hs)
            {
                if (e.ColumnIndex == SkillColumnHero2.Index)
                {
                    e.Value = hs.Skill.Name;
                }

                if (e.ColumnIndex == PowerColumnHero2.Index)
                {
                    e.Value = hs.Power.ToString("N");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (heroPower1 == 0 || heroPower2 == 0)
            {
                Alerts.Error("Select hero first !");
                return;
            }

            FightHistory fh = new FightHistory
            {
                Hero1ID = (int)comboBox1.SelectedValue,
                Hero2ID = (int)comboBox2.SelectedValue,
                Hero1TotalPower = heroPower1,
                Hero2TotalPower = heroPower2,
                FightDate = DateTime.Now
            };

            db.FightHistories.Add(fh);
            int rows = db.SaveChanges();
            if (rows > 0)
            {
                Alerts.Success("Fight History sucessfully saved!");
                new AppContext(new FightHistoryForm());
                this.Close();
                return;
            }

            Alerts.Error("Failed to save Fight History");
        }
    }
}
