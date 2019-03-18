namespace PipesCalculator
{
    partial class Main
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
            this.PipeName = new System.Windows.Forms.Label();
            this.listOfFixtures = new System.Windows.Forms.ListBox();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.MaterialsList = new System.Windows.Forms.ComboBox();
            this.Material = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // PipeName
            // 
            this.PipeName.AutoSize = true;
            this.PipeName.Location = new System.Drawing.Point(19, 12);
            this.PipeName.Name = "PipeName";
            this.PipeName.Size = new System.Drawing.Size(35, 13);
            this.PipeName.TabIndex = 0;
            this.PipeName.Text = "label1";
            this.PipeName.Click += new System.EventHandler(this.PipeName_Click);
            // 
            // listOfFixtures
            // 
            this.listOfFixtures.FormattingEnabled = true;
            this.listOfFixtures.Location = new System.Drawing.Point(19, 38);
            this.listOfFixtures.Name = "listOfFixtures";
            this.listOfFixtures.Size = new System.Drawing.Size(204, 355);
            this.listOfFixtures.TabIndex = 1;
            this.listOfFixtures.SelectedIndexChanged += new System.EventHandler(this.PipeParameters_SelectedIndexChanged);
            // 
            // layout
            // 
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout.Controls.Add(this.label14, 1, 4);
            this.layout.Controls.Add(this.label13, 1, 3);
            this.layout.Controls.Add(this.label12, 1, 2);
            this.layout.Controls.Add(this.label11, 1, 1);
            this.layout.Controls.Add(this.label3, 0, 1);
            this.layout.Controls.Add(this.label2, 1, 0);
            this.layout.Controls.Add(this.label1, 0, 0);
            this.layout.Controls.Add(this.label4, 0, 2);
            this.layout.Controls.Add(this.label5, 0, 3);
            this.layout.Controls.Add(this.label6, 0, 4);
            this.layout.Controls.Add(this.label7, 0, 5);
            this.layout.Controls.Add(this.label8, 0, 6);
            this.layout.Controls.Add(this.label9, 0, 7);
            this.layout.Controls.Add(this.label15, 1, 5);
            this.layout.Controls.Add(this.label16, 1, 6);
            this.layout.Controls.Add(this.label17, 1, 7);
            this.layout.Controls.Add(this.label18, 1, 8);
            this.layout.Controls.Add(this.label10, 0, 8);
            this.layout.Location = new System.Drawing.Point(229, 71);
            this.layout.Name = "layout";
            this.layout.RowCount = 9;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layout.Size = new System.Drawing.Size(513, 359);
            this.layout.TabIndex = 2;
            this.layout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(259, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 19);
            this.label13.TabIndex = 12;
            this.label13.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(259, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 19);
            this.label12.TabIndex = 11;
            this.label12.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(259, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre total d\'appareils";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Débit Brut (l/s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Coeffecient de simultanité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Débit probable (l/s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vitesse (m/s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Diamètre calculé (mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tube";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Diamètre commercial";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "Vitesse réelle";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(259, 234);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 19);
            this.label16.TabIndex = 15;
            this.label16.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(259, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "0";
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(351, 436);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(155, 36);
            this.Calculate.TabIndex = 3;
            this.Calculate.Text = "Calculer";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(544, 436);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(155, 36);
            this.Apply.TabIndex = 4;
            this.Apply.Text = "Appliquer";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // MaterialsList
            // 
            this.MaterialsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaterialsList.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialsList.FormattingEnabled = true;
            this.MaterialsList.Location = new System.Drawing.Point(408, 22);
            this.MaterialsList.Name = "MaterialsList";
            this.MaterialsList.Size = new System.Drawing.Size(264, 27);
            this.MaterialsList.TabIndex = 5;
            // 
            // Material
            // 
            this.Material.AutoSize = true;
            this.Material.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Material.Location = new System.Drawing.Point(324, 22);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(69, 19);
            this.Material.TabIndex = 6;
            this.Material.Text = "Matériel";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(259, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 19);
            this.label17.TabIndex = 16;
            this.label17.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(259, 312);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 19);
            this.label18.TabIndex = 17;
            this.label18.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(259, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 19);
            this.label14.TabIndex = 18;
            this.label14.Text = "0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 484);
            this.Controls.Add(this.Material);
            this.Controls.Add(this.MaterialsList);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.layout);
            this.Controls.Add(this.listOfFixtures);
            this.Controls.Add(this.PipeName);
            this.Name = "Main";
            this.Text = "Pipe Controller";
            this.Load += new System.EventHandler(this.Main_Load);
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PipeName;
        private System.Windows.Forms.ListBox listOfFixtures;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.ComboBox MaterialsList;
        private System.Windows.Forms.Label Material;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
    }
}