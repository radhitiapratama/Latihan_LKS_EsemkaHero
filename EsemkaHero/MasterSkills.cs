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
    public partial class MasterSkills : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();
        int op = -1;

        public MasterSkills()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }

        private void MasterSkills_Load(object sender, EventArgs e)
        {
            bindingSource2.AddNew();
            loadSkills();
            loadElement();
            loadLevel();
        }

        void loadElement()
        {

            var query = db.Elements.OrderBy(f => f.Element1).ToList();
            query.Insert(0, new Element()
            {
                ID = 0,
                Element1 = ""
            });


            comboBox1.DataSource = query;
            comboBox1.SelectedIndex = 0;
        }

        void loadLevel()
        {
            List<String> listLevel = new List<string>
            {
                "Easy",
                "Medium",
                "Hard",
                "Supreme"
            };

            comboBox2.DataSource = listLevel;
            comboBox2.SelectedIndex = 0;

        }

        void resetState()
        {
            bindingSource2.Clear();
            bindingSource2.AddNew();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            this.op = -1;
        }

        void loadSkills()
        {
            bindingSource1.Clear();
            var query = db.Skills.AsQueryable();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                query = query.Where(f => f.Name.Contains(textBox1.Text));
            }

            var result = query.ToList();
            bindingSource1.DataSource = result;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Skill skill)
            {
                var data = db.Skills.Where(f => f.ID == skill.ID).AsNoTracking().First();
                bindingSource2.DataSource = data;
                this.op = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current is Skill skil)
            {
                if (Alerts.Confirm("Yakin hapus skill?") == DialogResult.Yes)
                {
                    db.Skills.Remove(skil);
                    int rows = db.SaveChanges();
                    if (rows > 0)
                    {
                        Alerts.Success("Skill berhasil di hapus!");
                        loadSkills();
                        resetState();
                    }
                    else
                    {
                        Alerts.Success("Skilll gagal di hapus!");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadSkills();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Skill skil)
            {
                if (e.ColumnIndex == ElementColumn.Index)
                {
                    var element = skil.Element;
                    if (element == null)
                    {
                        e.Value = "Unknown";
                    }
                    else
                    {
                        e.Value = element.Element1;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                Alerts.Error("Semua input wajib di isi!");
                return;
            }

            if (bindingSource2.Current is Skill skill)
            {
                if (skill.ElementID != null)
                {
                    if ((int)comboBox1.SelectedValue == 0)
                    {
                        skill.ElementID = null;
                    }
                }

                skill.DifficultyLevel = comboBox2.SelectedValue.ToString();
                db.Skills.AddOrUpdate(skill);
                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    if (this.op == -1)
                    {
                        Alerts.Success("Skill berhasil di tambahkan!");
                    }
                    else
                    {
                        Alerts.Success("Skill berhasil di edit!");
                    }

                    loadSkills();
                    resetState();
                    return;
                }

                if (this.op == -1)
                {
                    Alerts.Error("Skill gagal di tambahkan!");
                }
                else
                {
                    Alerts.Error("Skill gagal di edit!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            resetState();
        }
    }
}
