using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHero
{
    public partial class FightHistoryForm : Form
    {
        EsemkaHeroEntities db = new EsemkaHeroEntities();

        public FightHistoryForm()
        {
            InitializeComponent();
        }

        private void FightHistoryForm_Load(object sender, EventArgs e)
        {
            loadHistory();
        }

        void loadHistory()
        {
            var query = db.FightHistories.OrderByDescending(f => f.FightDate).ToList();

            bindingSource1.DataSource = query;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is FightHistory fh)
            {
                if (e.ColumnIndex == Hero1Column.Index)
                {
                    e.Value = fh.Hero.Name;
                }

                if (e.ColumnIndex == Hero2Column.Index)
                {
                    e.Value = fh.Hero1.Name;
                }

                if (e.ColumnIndex == Hero1TotalPowerColumn.Index)
                {
                    e.Value = fh.Hero1TotalPower.ToString("N");
                }

                if (e.ColumnIndex == Hero2TotalPowerColumn.Index)
                {
                    e.Value = fh.Hero2TotalPower.ToString("N");
                }

                if (e.ColumnIndex == FightDateColumn.Index)
                {
                    e.Value = fh.FightDate.ToString("dd MMM yyyy");
                }

                if (e.ColumnIndex == WinnerColumn.Index)
                {
                    var hero1P = fh.Hero1TotalPower;
                    var hero2P = fh.Hero2TotalPower;

                    if (hero1P > hero2P)
                    {
                        e.Value = $"{fh.Hero.Name} Winner";
                    }
                    else
                    {
                        e.Value = $"{fh.Hero1.Name} Winner";
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AppContext(new MainForm());
            this.Close();
        }
    }
}
