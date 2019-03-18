namespace PipesCalculator
{
    partial class Displayer
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
            this.ChoiceButton = new System.Windows.Forms.Button();
            this.ChoiceText = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.systems = new System.Windows.Forms.ComboBox();
            this.header = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.calculate = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.table.SuspendLayout();
            this.header.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChoiceButton
            // 
            this.ChoiceButton.BackColor = System.Drawing.Color.YellowGreen;
            this.ChoiceButton.FlatAppearance.BorderSize = 0;
            this.ChoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceButton.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceButton.Location = new System.Drawing.Point(677, 10);
            this.ChoiceButton.Name = "ChoiceButton";
            this.ChoiceButton.Size = new System.Drawing.Size(182, 29);
            this.ChoiceButton.TabIndex = 2;
            this.ChoiceButton.Text = "Choisir";
            this.ChoiceButton.UseVisualStyleBackColor = false;
            this.ChoiceButton.Click += new System.EventHandler(this.ChoiceButton_Click);
            // 
            // ChoiceText
            // 
            this.ChoiceText.AutoSize = true;
            this.ChoiceText.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceText.Location = new System.Drawing.Point(3, 10);
            this.ChoiceText.Name = "ChoiceText";
            this.ChoiceText.Size = new System.Drawing.Size(190, 19);
            this.ChoiceText.TabIndex = 3;
            this.ChoiceText.Text = "Choisir une systeme MEP:";
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.table.ColumnCount = 9;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.table.Controls.Add(this.label9, 8, 0);
            this.table.Controls.Add(this.label8, 7, 0);
            this.table.Controls.Add(this.label7, 6, 0);
            this.table.Controls.Add(this.label6, 5, 0);
            this.table.Controls.Add(this.label5, 4, 0);
            this.table.Controls.Add(this.label2, 1, 0);
            this.table.Controls.Add(this.label1, 0, 0);
            this.table.Controls.Add(this.label3, 2, 0);
            this.table.Controls.Add(this.label4, 3, 0);
            this.table.Location = new System.Drawing.Point(14, 109);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Size = new System.Drawing.Size(1014, 30);
            this.table.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(897, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ø commercial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(767, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Tube";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(641, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ø calculé (mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(535, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vitesse (m/s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(480, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Coeff";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(211, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Débit Brut";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nbr total d\'appareils";
            // 
            // systems
            // 
            this.systems.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systems.FormattingEnabled = true;
            this.systems.Location = new System.Drawing.Point(227, 10);
            this.systems.Name = "systems";
            this.systems.Size = new System.Drawing.Size(404, 27);
            this.systems.TabIndex = 5;
            // 
            // header
            // 
            this.header.Controls.Add(this.ChoiceButton);
            this.header.Controls.Add(this.systems);
            this.header.Controls.Add(this.ChoiceText);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1040, 42);
            this.header.TabIndex = 6;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.export);
            this.buttonsPanel.Controls.Add(this.apply);
            this.buttonsPanel.Controls.Add(this.calculate);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 42);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(1040, 61);
            this.buttonsPanel.TabIndex = 7;
            // 
            // calculate
            // 
            this.calculate.BackColor = System.Drawing.Color.YellowGreen;
            this.calculate.FlatAppearance.BorderSize = 0;
            this.calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculate.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate.Location = new System.Drawing.Point(94, 28);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(200, 30);
            this.calculate.TabIndex = 3;
            this.calculate.Text = "Calculer";
            this.calculate.UseVisualStyleBackColor = false;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.YellowGreen;
            this.apply.FlatAppearance.BorderSize = 0;
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply.Location = new System.Drawing.Point(401, 28);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(200, 30);
            this.apply.TabIndex = 4;
            this.apply.Text = "Appliquer";
            this.apply.UseVisualStyleBackColor = false;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // export
            // 
            this.export.BackColor = System.Drawing.Color.YellowGreen;
            this.export.FlatAppearance.BorderSize = 0;
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export.Location = new System.Drawing.Point(731, 28);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(200, 30);
            this.export.TabIndex = 5;
            this.export.Text = "Exporter à un fichier Excel";
            this.export.UseVisualStyleBackColor = false;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Displayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1040, 408);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.table);
            this.Name = "Displayer";
            this.Text = "Displayer";
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChoiceButton;
        private System.Windows.Forms.Label ChoiceText;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox systems;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button calculate;
    }
}