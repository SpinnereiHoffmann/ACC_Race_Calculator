namespace WindowsFormsApp1
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.buttonAddDriver = new System.Windows.Forms.Button();
      this.buttonRemoveDriver = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.labelDuration = new System.Windows.Forms.Label();
      this.textBoxDurationHours = new System.Windows.Forms.TextBox();
      this.labelMinutes = new System.Windows.Forms.Label();
      this.textBoxDurationMins = new System.Windows.Forms.TextBox();
      this.labelLiters = new System.Windows.Forms.Label();
      this.labelStint = new System.Windows.Forms.Label();
      this.textBoxStintTime = new System.Windows.Forms.TextBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.textBoxFuelQuantity = new System.Windows.Forms.TextBox();
      this.labelFuelQuantity = new System.Windows.Forms.Label();
      this.labelStintTime = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.buttonAddPitstop = new System.Windows.Forms.Button();
      this.buttonRemovePitstop = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.comboBoxTracks = new System.Windows.Forms.ComboBox();
      this.buttonWrite = new System.Windows.Forms.Button();
      this.labelTrack = new System.Windows.Forms.Label();
      this.buttonOpenGlobal = new System.Windows.Forms.Button();
      this.textBoxLocalPath = new System.Windows.Forms.TextBox();
      this.labelLocalPath = new System.Windows.Forms.Label();
      this.textBoxGlobalPath = new System.Windows.Forms.TextBox();
      this.labelGlobalPath = new System.Windows.Forms.Label();
      this.buttonOpenLocal = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(140, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(501, 409);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.groupBox3);
      this.tabPage1.Controls.Add(this.groupBox2);
      this.tabPage1.Controls.Add(this.groupBox1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(493, 383);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Daten";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.buttonAddDriver);
      this.groupBox3.Controls.Add(this.buttonRemoveDriver);
      this.groupBox3.Location = new System.Drawing.Point(6, 7);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(480, 124);
      this.groupBox3.TabIndex = 32;
      this.groupBox3.TabStop = false;
      // 
      // buttonAddDriver
      // 
      this.buttonAddDriver.Location = new System.Drawing.Point(6, 14);
      this.buttonAddDriver.Name = "buttonAddDriver";
      this.buttonAddDriver.Size = new System.Drawing.Size(75, 46);
      this.buttonAddDriver.TabIndex = 15;
      this.buttonAddDriver.Text = "Fahrer hinzufügen";
      this.buttonAddDriver.UseVisualStyleBackColor = true;
      this.buttonAddDriver.Click += new System.EventHandler(this.buttonAddDriver_Click);
      // 
      // buttonRemoveDriver
      // 
      this.buttonRemoveDriver.Location = new System.Drawing.Point(6, 66);
      this.buttonRemoveDriver.Name = "buttonRemoveDriver";
      this.buttonRemoveDriver.Size = new System.Drawing.Size(75, 46);
      this.buttonRemoveDriver.TabIndex = 16;
      this.buttonRemoveDriver.Text = "Fahrer entfernen";
      this.buttonRemoveDriver.UseVisualStyleBackColor = true;
      this.buttonRemoveDriver.Click += new System.EventHandler(this.buttonRemoveDriver_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.labelDuration);
      this.groupBox2.Controls.Add(this.textBoxDurationHours);
      this.groupBox2.Controls.Add(this.labelMinutes);
      this.groupBox2.Controls.Add(this.textBoxDurationMins);
      this.groupBox2.Controls.Add(this.labelLiters);
      this.groupBox2.Controls.Add(this.labelStint);
      this.groupBox2.Controls.Add(this.textBoxStintTime);
      this.groupBox2.Controls.Add(this.comboBox1);
      this.groupBox2.Controls.Add(this.textBoxFuelQuantity);
      this.groupBox2.Controls.Add(this.labelFuelQuantity);
      this.groupBox2.Controls.Add(this.labelStintTime);
      this.groupBox2.Location = new System.Drawing.Point(6, 137);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(480, 96);
      this.groupBox2.TabIndex = 31;
      this.groupBox2.TabStop = false;
      // 
      // labelDuration
      // 
      this.labelDuration.AutoSize = true;
      this.labelDuration.Location = new System.Drawing.Point(6, 16);
      this.labelDuration.Name = "labelDuration";
      this.labelDuration.Size = new System.Drawing.Size(59, 13);
      this.labelDuration.TabIndex = 17;
      this.labelDuration.Text = "Rennlänge";
      // 
      // textBoxDurationHours
      // 
      this.textBoxDurationHours.Location = new System.Drawing.Point(9, 32);
      this.textBoxDurationHours.Name = "textBoxDurationHours";
      this.textBoxDurationHours.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxDurationHours.Size = new System.Drawing.Size(25, 20);
      this.textBoxDurationHours.TabIndex = 18;
      this.textBoxDurationHours.Text = "hh";
      // 
      // labelMinutes
      // 
      this.labelMinutes.AutoSize = true;
      this.labelMinutes.Location = new System.Drawing.Point(374, 35);
      this.labelMinutes.Name = "labelMinutes";
      this.labelMinutes.Size = new System.Drawing.Size(23, 13);
      this.labelMinutes.TabIndex = 27;
      this.labelMinutes.Text = "min";
      // 
      // textBoxDurationMins
      // 
      this.textBoxDurationMins.Location = new System.Drawing.Point(40, 32);
      this.textBoxDurationMins.Name = "textBoxDurationMins";
      this.textBoxDurationMins.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxDurationMins.Size = new System.Drawing.Size(25, 20);
      this.textBoxDurationMins.TabIndex = 19;
      this.textBoxDurationMins.Text = "mm";
      // 
      // labelLiters
      // 
      this.labelLiters.AutoSize = true;
      this.labelLiters.Location = new System.Drawing.Point(374, 16);
      this.labelLiters.Name = "labelLiters";
      this.labelLiters.Size = new System.Drawing.Size(9, 13);
      this.labelLiters.TabIndex = 26;
      this.labelLiters.Text = "l";
      // 
      // labelStint
      // 
      this.labelStint.AutoSize = true;
      this.labelStint.Location = new System.Drawing.Point(115, 16);
      this.labelStint.Name = "labelStint";
      this.labelStint.Size = new System.Drawing.Size(84, 13);
      this.labelStint.TabIndex = 20;
      this.labelStint.Text = "Stintbegrenzung";
      // 
      // textBoxStintTime
      // 
      this.textBoxStintTime.Enabled = false;
      this.textBoxStintTime.Location = new System.Drawing.Point(338, 32);
      this.textBoxStintTime.Name = "textBoxStintTime";
      this.textBoxStintTime.Size = new System.Drawing.Size(30, 20);
      this.textBoxStintTime.TabIndex = 25;
      this.textBoxStintTime.Text = "65";
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "Tankvolumen",
            "Stintzeit"});
      this.comboBox1.Location = new System.Drawing.Point(118, 32);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(100, 21);
      this.comboBox1.TabIndex = 21;
      this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
      // 
      // textBoxFuelQuantity
      // 
      this.textBoxFuelQuantity.Location = new System.Drawing.Point(338, 13);
      this.textBoxFuelQuantity.Name = "textBoxFuelQuantity";
      this.textBoxFuelQuantity.Size = new System.Drawing.Size(30, 20);
      this.textBoxFuelQuantity.TabIndex = 24;
      this.textBoxFuelQuantity.Text = "120";
      // 
      // labelFuelQuantity
      // 
      this.labelFuelQuantity.AutoSize = true;
      this.labelFuelQuantity.Location = new System.Drawing.Point(268, 16);
      this.labelFuelQuantity.Name = "labelFuelQuantity";
      this.labelFuelQuantity.Size = new System.Drawing.Size(60, 13);
      this.labelFuelQuantity.TabIndex = 22;
      this.labelFuelQuantity.Text = "Spritmenge";
      // 
      // labelStintTime
      // 
      this.labelStintTime.AutoSize = true;
      this.labelStintTime.Location = new System.Drawing.Point(268, 35);
      this.labelStintTime.Name = "labelStintTime";
      this.labelStintTime.Size = new System.Drawing.Size(44, 13);
      this.labelStintTime.TabIndex = 23;
      this.labelStintTime.Text = "Stintzeit";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.buttonAddPitstop);
      this.groupBox1.Controls.Add(this.buttonRemovePitstop);
      this.groupBox1.Location = new System.Drawing.Point(6, 239);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(480, 138);
      this.groupBox1.TabIndex = 30;
      this.groupBox1.TabStop = false;
      // 
      // buttonAddPitstop
      // 
      this.buttonAddPitstop.Location = new System.Drawing.Point(6, 25);
      this.buttonAddPitstop.Name = "buttonAddPitstop";
      this.buttonAddPitstop.Size = new System.Drawing.Size(75, 46);
      this.buttonAddPitstop.TabIndex = 28;
      this.buttonAddPitstop.Text = "Pitstopp hinzufügen";
      this.buttonAddPitstop.UseVisualStyleBackColor = true;
      this.buttonAddPitstop.Click += new System.EventHandler(this.buttonAddPitstop_Click);
      // 
      // buttonRemovePitstop
      // 
      this.buttonRemovePitstop.Location = new System.Drawing.Point(6, 77);
      this.buttonRemovePitstop.Name = "buttonRemovePitstop";
      this.buttonRemovePitstop.Size = new System.Drawing.Size(75, 46);
      this.buttonRemovePitstop.TabIndex = 29;
      this.buttonRemovePitstop.Text = "Pitstopp entfernen";
      this.buttonRemovePitstop.UseVisualStyleBackColor = true;
      this.buttonRemovePitstop.Click += new System.EventHandler(this.buttonRemovePitstop_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(483, 383);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Strategie";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // tabPage3
      // 
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(483, 383);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Bestzeiten";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // comboBoxTracks
      // 
      this.comboBoxTracks.FormattingEnabled = true;
      this.comboBoxTracks.Items.AddRange(new object[] {
            "Barcelona",
            "Brands Hatch",
            "Donnington Park",
            "Hungaroring",
            "Imola",
            "Kyalami",
            "Laguna Seca",
            "Misano",
            "Monza",
            "Mount Panorama",
            "Nürburgring",
            "Oulton Park",
            "Paul Ricard",
            "Silverstone",
            "Snetterton",
            "Spa-Francorchamps",
            "Suzuka",
            "Zandvoort",
            "Zolder"});
      this.comboBoxTracks.Location = new System.Drawing.Point(12, 37);
      this.comboBoxTracks.Name = "comboBoxTracks";
      this.comboBoxTracks.Size = new System.Drawing.Size(122, 21);
      this.comboBoxTracks.Sorted = true;
      this.comboBoxTracks.TabIndex = 1;
      this.comboBoxTracks.SelectedValueChanged += new System.EventHandler(this.comboBoxTracks_SelectedValueChanged);
      // 
      // buttonWrite
      // 
      this.buttonWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonWrite.Location = new System.Drawing.Point(12, 393);
      this.buttonWrite.Name = "buttonWrite";
      this.buttonWrite.Size = new System.Drawing.Size(122, 23);
      this.buttonWrite.TabIndex = 2;
      this.buttonWrite.Text = "Schreiben";
      this.buttonWrite.UseVisualStyleBackColor = true;
      this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
      // 
      // labelTrack
      // 
      this.labelTrack.AutoSize = true;
      this.labelTrack.Location = new System.Drawing.Point(13, 12);
      this.labelTrack.Name = "labelTrack";
      this.labelTrack.Size = new System.Drawing.Size(0, 13);
      this.labelTrack.TabIndex = 3;
      // 
      // buttonOpenGlobal
      // 
      this.buttonOpenGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonOpenGlobal.Location = new System.Drawing.Point(12, 364);
      this.buttonOpenGlobal.Name = "buttonOpenGlobal";
      this.buttonOpenGlobal.Size = new System.Drawing.Size(122, 23);
      this.buttonOpenGlobal.TabIndex = 4;
      this.buttonOpenGlobal.Text = "Öffne Global";
      this.buttonOpenGlobal.UseVisualStyleBackColor = true;
      // 
      // textBoxLocalPath
      // 
      this.textBoxLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxLocalPath.Location = new System.Drawing.Point(11, 270);
      this.textBoxLocalPath.Name = "textBoxLocalPath";
      this.textBoxLocalPath.Size = new System.Drawing.Size(121, 20);
      this.textBoxLocalPath.TabIndex = 5;
      this.textBoxLocalPath.TextChanged += new System.EventHandler(this.textBoxLocalPath_TextChanged);
      // 
      // labelLocalPath
      // 
      this.labelLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelLocalPath.AutoSize = true;
      this.labelLocalPath.Location = new System.Drawing.Point(12, 254);
      this.labelLocalPath.Name = "labelLocalPath";
      this.labelLocalPath.Size = new System.Drawing.Size(54, 13);
      this.labelLocalPath.TabIndex = 6;
      this.labelLocalPath.Text = "Pfad lokal";
      // 
      // textBoxGlobalPath
      // 
      this.textBoxGlobalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxGlobalPath.Location = new System.Drawing.Point(12, 338);
      this.textBoxGlobalPath.Name = "textBoxGlobalPath";
      this.textBoxGlobalPath.Size = new System.Drawing.Size(121, 20);
      this.textBoxGlobalPath.TabIndex = 7;
      this.textBoxGlobalPath.TextChanged += new System.EventHandler(this.textBoxGlobalPath_TextChanged);
      // 
      // labelGlobalPath
      // 
      this.labelGlobalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelGlobalPath.AutoSize = true;
      this.labelGlobalPath.Location = new System.Drawing.Point(9, 322);
      this.labelGlobalPath.Name = "labelGlobalPath";
      this.labelGlobalPath.Size = new System.Drawing.Size(60, 13);
      this.labelGlobalPath.TabIndex = 8;
      this.labelGlobalPath.Text = "Pfad global";
      // 
      // buttonOpenLocal
      // 
      this.buttonOpenLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonOpenLocal.Location = new System.Drawing.Point(11, 296);
      this.buttonOpenLocal.Name = "buttonOpenLocal";
      this.buttonOpenLocal.Size = new System.Drawing.Size(122, 23);
      this.buttonOpenLocal.TabIndex = 9;
      this.buttonOpenLocal.Text = "Öffne Local";
      this.buttonOpenLocal.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(653, 433);
      this.Controls.Add(this.buttonOpenLocal);
      this.Controls.Add(this.labelGlobalPath);
      this.Controls.Add(this.textBoxGlobalPath);
      this.Controls.Add(this.labelLocalPath);
      this.Controls.Add(this.textBoxLocalPath);
      this.Controls.Add(this.buttonOpenGlobal);
      this.Controls.Add(this.labelTrack);
      this.Controls.Add(this.buttonWrite);
      this.Controls.Add(this.comboBoxTracks);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form1";
      this.Text = "ACC Race Calculator";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Enter += new System.EventHandler(this.buttonWrite_Click);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.ComboBox comboBoxTracks;
    private System.Windows.Forms.Button buttonWrite;
    private System.Windows.Forms.Label labelTrack;
    private System.Windows.Forms.Button buttonOpenGlobal;
    private System.Windows.Forms.TextBox textBoxLocalPath;
    private System.Windows.Forms.Label labelLocalPath;
    private System.Windows.Forms.TextBox textBoxGlobalPath;
    private System.Windows.Forms.Label labelGlobalPath;
    private System.Windows.Forms.Button buttonOpenLocal;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button buttonAddDriver;
    private System.Windows.Forms.Button buttonRemoveDriver;
    private System.Windows.Forms.Label labelDuration;
    private System.Windows.Forms.TextBox textBoxDurationMins;
    private System.Windows.Forms.TextBox textBoxDurationHours;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label labelStint;
    private System.Windows.Forms.Label labelMinutes;
    private System.Windows.Forms.Label labelLiters;
    private System.Windows.Forms.TextBox textBoxStintTime;
    private System.Windows.Forms.TextBox textBoxFuelQuantity;
    private System.Windows.Forms.Label labelStintTime;
    private System.Windows.Forms.Label labelFuelQuantity;
    private System.Windows.Forms.Button buttonRemovePitstop;
    private System.Windows.Forms.Button buttonAddPitstop;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}

