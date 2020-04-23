namespace WindowsFormsAppProject
{
    partial class FormDialogAggiungiVeicolo
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
            this.cmbTipoVeicolo = new System.Windows.Forms.ComboBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMarcaSella = new System.Windows.Forms.Label();
            this.lblNumeroAir = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.txtMarcaSella = new System.Windows.Forms.TextBox();
            this.nmrCilindrata = new System.Windows.Forms.NumericUpDown();
            this.nmrNumAirbag = new System.Windows.Forms.NumericUpDown();
            this.nmrKmPercorsi = new System.Windows.Forms.NumericUpDown();
            this.nmrPotenza = new System.Windows.Forms.NumericUpDown();
            this.dtpImmatricolazione = new System.Windows.Forms.DateTimePicker();
            this.cmbKmZero = new System.Windows.Forms.ComboBox();
            this.cmbColore = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbSi = new System.Windows.Forms.RadioButton();
            this.nmrPrezzo = new System.Windows.Forms.NumericUpDown();
            this.lblPrezzo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCilindrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNumAirbag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrKmPercorsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPotenza)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrezzo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoVeicolo
            // 
            this.cmbTipoVeicolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVeicolo.FormattingEnabled = true;
            this.cmbTipoVeicolo.Items.AddRange(new object[] {
            "MOTO",
            "AUTO"});
            this.cmbTipoVeicolo.Location = new System.Drawing.Point(93, 15);
            this.cmbTipoVeicolo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoVeicolo.Name = "cmbTipoVeicolo";
            this.cmbTipoVeicolo.Size = new System.Drawing.Size(160, 24);
            this.cmbTipoVeicolo.TabIndex = 0;
            this.cmbTipoVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVeicolo_SelectedIndexChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(155, 495);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(100, 28);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(263, 495);
            this.btnAggiungi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(100, 28);
            this.btnAggiungi.TabIndex = 2;
            this.btnAggiungi.Text = "AGGIUNGI";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "MARCA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "MODELLO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "COLORE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "CILINDRATA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 192);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "POTENZA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 226);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "IMMATRICOLAZIONE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 271);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "USATA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 305);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "KM 0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 340);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "KM PERCORSI";
            // 
            // lblMarcaSella
            // 
            this.lblMarcaSella.AutoSize = true;
            this.lblMarcaSella.Location = new System.Drawing.Point(16, 378);
            this.lblMarcaSella.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarcaSella.Name = "lblMarcaSella";
            this.lblMarcaSella.Size = new System.Drawing.Size(103, 17);
            this.lblMarcaSella.TabIndex = 12;
            this.lblMarcaSella.Text = "MARCA SELLA";
            // 
            // lblNumeroAir
            // 
            this.lblNumeroAir.AutoSize = true;
            this.lblNumeroAir.Location = new System.Drawing.Point(16, 411);
            this.lblNumeroAir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroAir.Name = "lblNumeroAir";
            this.lblNumeroAir.Size = new System.Drawing.Size(124, 17);
            this.lblNumeroAir.TabIndex = 13;
            this.lblNumeroAir.Text = "NUMERO AIRBAG";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(176, 65);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(132, 22);
            this.txtMarca.TabIndex = 14;
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(176, 98);
            this.txtModello.Margin = new System.Windows.Forms.Padding(4);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(132, 22);
            this.txtModello.TabIndex = 15;
            // 
            // txtMarcaSella
            // 
            this.txtMarcaSella.Location = new System.Drawing.Point(176, 374);
            this.txtMarcaSella.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarcaSella.Name = "txtMarcaSella";
            this.txtMarcaSella.Size = new System.Drawing.Size(132, 22);
            this.txtMarcaSella.TabIndex = 23;
            // 
            // nmrCilindrata
            // 
            this.nmrCilindrata.Location = new System.Drawing.Point(176, 160);
            this.nmrCilindrata.Margin = new System.Windows.Forms.Padding(4);
            this.nmrCilindrata.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrCilindrata.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmrCilindrata.Name = "nmrCilindrata";
            this.nmrCilindrata.Size = new System.Drawing.Size(133, 22);
            this.nmrCilindrata.TabIndex = 25;
            this.nmrCilindrata.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nmrNumAirbag
            // 
            this.nmrNumAirbag.Location = new System.Drawing.Point(176, 409);
            this.nmrNumAirbag.Margin = new System.Windows.Forms.Padding(4);
            this.nmrNumAirbag.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmrNumAirbag.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmrNumAirbag.Name = "nmrNumAirbag";
            this.nmrNumAirbag.Size = new System.Drawing.Size(133, 22);
            this.nmrNumAirbag.TabIndex = 26;
            this.nmrNumAirbag.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nmrKmPercorsi
            // 
            this.nmrKmPercorsi.Location = new System.Drawing.Point(176, 337);
            this.nmrKmPercorsi.Margin = new System.Windows.Forms.Padding(4);
            this.nmrKmPercorsi.Name = "nmrKmPercorsi";
            this.nmrKmPercorsi.Size = new System.Drawing.Size(133, 22);
            this.nmrKmPercorsi.TabIndex = 27;
            // 
            // nmrPotenza
            // 
            this.nmrPotenza.Location = new System.Drawing.Point(176, 190);
            this.nmrPotenza.Margin = new System.Windows.Forms.Padding(4);
            this.nmrPotenza.Name = "nmrPotenza";
            this.nmrPotenza.Size = new System.Drawing.Size(133, 22);
            this.nmrPotenza.TabIndex = 28;
            // 
            // dtpImmatricolazione
            // 
            this.dtpImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpImmatricolazione.Location = new System.Drawing.Point(176, 222);
            this.dtpImmatricolazione.Margin = new System.Windows.Forms.Padding(4);
            this.dtpImmatricolazione.Name = "dtpImmatricolazione";
            this.dtpImmatricolazione.Size = new System.Drawing.Size(132, 22);
            this.dtpImmatricolazione.TabIndex = 29;
            // 
            // cmbKmZero
            // 
            this.cmbKmZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKmZero.FormattingEnabled = true;
            this.cmbKmZero.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cmbKmZero.Location = new System.Drawing.Point(176, 302);
            this.cmbKmZero.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKmZero.Name = "cmbKmZero";
            this.cmbKmZero.Size = new System.Drawing.Size(132, 24);
            this.cmbKmZero.TabIndex = 30;
            // 
            // cmbColore
            // 
            this.cmbColore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColore.FormattingEnabled = true;
            this.cmbColore.Items.AddRange(new object[] {
            "Rosso",
            "Nero",
            "Blu",
            "Verde",
            "Giallo",
            "Bianco",
            "Rosa",
            "Arancione"});
            this.cmbColore.Location = new System.Drawing.Point(176, 129);
            this.cmbColore.Margin = new System.Windows.Forms.Padding(4);
            this.cmbColore.Name = "cmbColore";
            this.cmbColore.Size = new System.Drawing.Size(132, 24);
            this.cmbColore.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNo);
            this.groupBox1.Controls.Add(this.rdbSi);
            this.groupBox1.Location = new System.Drawing.Point(176, 249);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(133, 47);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Location = new System.Drawing.Point(71, 20);
            this.rdbNo.Margin = new System.Windows.Forms.Padding(4);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(47, 21);
            this.rdbNo.TabIndex = 1;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbSi
            // 
            this.rdbSi.AutoSize = true;
            this.rdbSi.Location = new System.Drawing.Point(4, 20);
            this.rdbSi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSi.Name = "rdbSi";
            this.rdbSi.Size = new System.Drawing.Size(41, 21);
            this.rdbSi.TabIndex = 0;
            this.rdbSi.Text = "Sì";
            this.rdbSi.UseVisualStyleBackColor = true;
            // 
            // nmrPrezzo
            // 
            this.nmrPrezzo.Location = new System.Drawing.Point(177, 445);
            this.nmrPrezzo.Margin = new System.Windows.Forms.Padding(4);
            this.nmrPrezzo.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmrPrezzo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmrPrezzo.Name = "nmrPrezzo";
            this.nmrPrezzo.Size = new System.Drawing.Size(133, 22);
            this.nmrPrezzo.TabIndex = 34;
            this.nmrPrezzo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrezzo
            // 
            this.lblPrezzo.AutoSize = true;
            this.lblPrezzo.Location = new System.Drawing.Point(17, 447);
            this.lblPrezzo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrezzo.Name = "lblPrezzo";
            this.lblPrezzo.Size = new System.Drawing.Size(65, 17);
            this.lblPrezzo.TabIndex = 33;
            this.lblPrezzo.Text = "PREZZO";
            // 
            // FormDialogAggiungiVeicolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(379, 541);
            this.Controls.Add(this.nmrPrezzo);
            this.Controls.Add(this.lblPrezzo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbColore);
            this.Controls.Add(this.cmbKmZero);
            this.Controls.Add(this.dtpImmatricolazione);
            this.Controls.Add(this.nmrPotenza);
            this.Controls.Add(this.nmrKmPercorsi);
            this.Controls.Add(this.nmrNumAirbag);
            this.Controls.Add(this.nmrCilindrata);
            this.Controls.Add(this.txtMarcaSella);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblNumeroAir);
            this.Controls.Add(this.lblMarcaSella);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.cmbTipoVeicolo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDialogAggiungiVeicolo";
            this.Text = "AGGIUNGI VEICOLO";
            this.Load += new System.EventHandler(this.FormDialogAggiungiVeicolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrCilindrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrNumAirbag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrKmPercorsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPotenza)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrezzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoVeicolo;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMarcaSella;
        private System.Windows.Forms.Label lblNumeroAir;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.TextBox txtMarcaSella;
        private System.Windows.Forms.NumericUpDown nmrCilindrata;
        private System.Windows.Forms.NumericUpDown nmrNumAirbag;
        private System.Windows.Forms.NumericUpDown nmrKmPercorsi;
        private System.Windows.Forms.NumericUpDown nmrPotenza;
        private System.Windows.Forms.DateTimePicker dtpImmatricolazione;
        private System.Windows.Forms.ComboBox cmbKmZero;
        private System.Windows.Forms.ComboBox cmbColore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbSi;
        private System.Windows.Forms.NumericUpDown nmrPrezzo;
        private System.Windows.Forms.Label lblPrezzo;
    }
}