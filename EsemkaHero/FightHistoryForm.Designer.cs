namespace EsemkaHero
{
    partial class FightHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hero1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fightDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hero2TotalPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hero1TotalPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hero2IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hero1IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FightDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WinnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hero2TotalPowerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hero2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hero1TotalPowerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hero1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EsemkaHero.FightHistory);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "Main Form";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fight History";
            // 
            // hero1DataGridViewTextBoxColumn
            // 
            this.hero1DataGridViewTextBoxColumn.DataPropertyName = "Hero1";
            this.hero1DataGridViewTextBoxColumn.HeaderText = "Hero1";
            this.hero1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hero1DataGridViewTextBoxColumn.Name = "hero1DataGridViewTextBoxColumn";
            this.hero1DataGridViewTextBoxColumn.ReadOnly = true;
            this.hero1DataGridViewTextBoxColumn.Visible = false;
            // 
            // heroDataGridViewTextBoxColumn
            // 
            this.heroDataGridViewTextBoxColumn.DataPropertyName = "Hero";
            this.heroDataGridViewTextBoxColumn.HeaderText = "Hero";
            this.heroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.heroDataGridViewTextBoxColumn.Name = "heroDataGridViewTextBoxColumn";
            this.heroDataGridViewTextBoxColumn.ReadOnly = true;
            this.heroDataGridViewTextBoxColumn.Visible = false;
            // 
            // fightDateDataGridViewTextBoxColumn
            // 
            this.fightDateDataGridViewTextBoxColumn.DataPropertyName = "FightDate";
            this.fightDateDataGridViewTextBoxColumn.HeaderText = "FightDate";
            this.fightDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fightDateDataGridViewTextBoxColumn.Name = "fightDateDataGridViewTextBoxColumn";
            this.fightDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.fightDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // hero2TotalPowerDataGridViewTextBoxColumn
            // 
            this.hero2TotalPowerDataGridViewTextBoxColumn.DataPropertyName = "Hero2TotalPower";
            this.hero2TotalPowerDataGridViewTextBoxColumn.HeaderText = "Hero2TotalPower";
            this.hero2TotalPowerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hero2TotalPowerDataGridViewTextBoxColumn.Name = "hero2TotalPowerDataGridViewTextBoxColumn";
            this.hero2TotalPowerDataGridViewTextBoxColumn.ReadOnly = true;
            this.hero2TotalPowerDataGridViewTextBoxColumn.Visible = false;
            // 
            // hero1TotalPowerDataGridViewTextBoxColumn
            // 
            this.hero1TotalPowerDataGridViewTextBoxColumn.DataPropertyName = "Hero1TotalPower";
            this.hero1TotalPowerDataGridViewTextBoxColumn.HeaderText = "Hero1TotalPower";
            this.hero1TotalPowerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hero1TotalPowerDataGridViewTextBoxColumn.Name = "hero1TotalPowerDataGridViewTextBoxColumn";
            this.hero1TotalPowerDataGridViewTextBoxColumn.ReadOnly = true;
            this.hero1TotalPowerDataGridViewTextBoxColumn.Visible = false;
            // 
            // hero2IDDataGridViewTextBoxColumn
            // 
            this.hero2IDDataGridViewTextBoxColumn.DataPropertyName = "Hero2ID";
            this.hero2IDDataGridViewTextBoxColumn.HeaderText = "Hero2ID";
            this.hero2IDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hero2IDDataGridViewTextBoxColumn.Name = "hero2IDDataGridViewTextBoxColumn";
            this.hero2IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.hero2IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // hero1IDDataGridViewTextBoxColumn
            // 
            this.hero1IDDataGridViewTextBoxColumn.DataPropertyName = "Hero1ID";
            this.hero1IDDataGridViewTextBoxColumn.HeaderText = "Hero1ID";
            this.hero1IDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hero1IDDataGridViewTextBoxColumn.Name = "hero1IDDataGridViewTextBoxColumn";
            this.hero1IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.hero1IDDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // FightDateColumn
            // 
            this.FightDateColumn.DataPropertyName = "FightDate";
            this.FightDateColumn.HeaderText = "FightDate";
            this.FightDateColumn.MinimumWidth = 6;
            this.FightDateColumn.Name = "FightDateColumn";
            this.FightDateColumn.ReadOnly = true;
            // 
            // WinnerColumn
            // 
            this.WinnerColumn.HeaderText = "Winner";
            this.WinnerColumn.MinimumWidth = 6;
            this.WinnerColumn.Name = "WinnerColumn";
            this.WinnerColumn.ReadOnly = true;
            // 
            // Hero2TotalPowerColumn
            // 
            this.Hero2TotalPowerColumn.DataPropertyName = "Hero2TotalPower";
            this.Hero2TotalPowerColumn.HeaderText = "Hero2TotalPower";
            this.Hero2TotalPowerColumn.MinimumWidth = 6;
            this.Hero2TotalPowerColumn.Name = "Hero2TotalPowerColumn";
            this.Hero2TotalPowerColumn.ReadOnly = true;
            // 
            // Hero2Column
            // 
            this.Hero2Column.DataPropertyName = "Hero2ID";
            this.Hero2Column.HeaderText = "Hero2";
            this.Hero2Column.MinimumWidth = 6;
            this.Hero2Column.Name = "Hero2Column";
            this.Hero2Column.ReadOnly = true;
            // 
            // Hero1TotalPowerColumn
            // 
            this.Hero1TotalPowerColumn.DataPropertyName = "Hero1TotalPower";
            this.Hero1TotalPowerColumn.HeaderText = "Hero1TotalPower";
            this.Hero1TotalPowerColumn.MinimumWidth = 6;
            this.Hero1TotalPowerColumn.Name = "Hero1TotalPowerColumn";
            this.Hero1TotalPowerColumn.ReadOnly = true;
            // 
            // Hero1Column
            // 
            this.Hero1Column.DataPropertyName = "Hero1ID";
            this.Hero1Column.HeaderText = "Hero1";
            this.Hero1Column.MinimumWidth = 6;
            this.Hero1Column.Name = "Hero1Column";
            this.Hero1Column.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hero1Column,
            this.Hero1TotalPowerColumn,
            this.Hero2Column,
            this.Hero2TotalPowerColumn,
            this.WinnerColumn,
            this.FightDateColumn,
            this.iDDataGridViewTextBoxColumn,
            this.hero1IDDataGridViewTextBoxColumn,
            this.hero2IDDataGridViewTextBoxColumn,
            this.hero1TotalPowerDataGridViewTextBoxColumn,
            this.hero2TotalPowerDataGridViewTextBoxColumn,
            this.fightDateDataGridViewTextBoxColumn,
            this.heroDataGridViewTextBoxColumn,
            this.hero1DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(37, 147);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(842, 364);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // FightHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 526);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "FightHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FightHistoryForm";
            this.Load += new System.EventHandler(this.FightHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hero1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fightDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hero2TotalPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hero1TotalPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hero2IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hero1IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FightDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WinnerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hero2TotalPowerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hero2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hero1TotalPowerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hero1Column;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}