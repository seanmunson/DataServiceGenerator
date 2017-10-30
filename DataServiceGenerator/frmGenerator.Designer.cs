namespace DataServiceGenerator
{
    partial class frmGenerator
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
            this.lstServers = new System.Windows.Forms.ListBox();
            this.lbServers = new System.Windows.Forms.Label();
            this.lbTableSelected = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtOutputText = new System.Windows.Forms.TextBox();
            this.tbConfig = new System.Windows.Forms.TabControl();
            this.tbConnections = new System.Windows.Forms.TabPage();
            this.ckEnableAutogeneration = new System.Windows.Forms.CheckBox();
            this.cmdServerDelete = new System.Windows.Forms.Button();
            this.cmbDatabaseType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.cmdTestAndSave = new System.Windows.Forms.Button();
            this.tbTable = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.lstFields = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTableKey = new System.Windows.Forms.TextBox();
            this.cmdAddTable = new System.Windows.Forms.Button();
            this.cmdRunTestGenerate = new System.Windows.Forms.Button();
            this.cmdEditPostUpdate = new System.Windows.Forms.Button();
            this.cmdEditPostInsert = new System.Windows.Forms.Button();
            this.cmdEditPostExists = new System.Windows.Forms.Button();
            this.cmdEditPostDelete = new System.Windows.Forms.Button();
            this.cmdEditPostSave = new System.Windows.Forms.Button();
            this.cmdEditPostConstructor = new System.Windows.Forms.Button();
            this.cmdEditPreUpdate = new System.Windows.Forms.Button();
            this.ckUpdate = new System.Windows.Forms.CheckBox();
            this.cmdEditPreInsert = new System.Windows.Forms.Button();
            this.ckInsert = new System.Windows.Forms.CheckBox();
            this.cmdEditPreExists = new System.Windows.Forms.Button();
            this.cmdEditPreDelete = new System.Windows.Forms.Button();
            this.cmdEditPreSave = new System.Windows.Forms.Button();
            this.cmdEditPreConstructor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSaveButton = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckExists = new System.Windows.Forms.CheckBox();
            this.ckDelete = new System.Windows.Forms.CheckBox();
            this.ckSave = new System.Windows.Forms.CheckBox();
            this.ckConstructor = new System.Windows.Forms.CheckBox();
            this.tbOutput = new System.Windows.Forms.TabPage();
            this.cmdBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.lbOutputDir = new System.Windows.Forms.Label();
            this.cmdTestBuild = new System.Windows.Forms.Button();
            this.cmdBuildAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOutputType = new System.Windows.Forms.ComboBox();
            this.cmbOutputLanguage = new System.Windows.Forms.ComboBox();
            this.cmdSqlTest = new System.Windows.Forms.Button();
            this.lbSubroutines = new System.Windows.Forms.Label();
            this.cmdSaveTable = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lstTableSelected = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.tbConfig.SuspendLayout();
            this.tbConnections.SuspendLayout();
            this.tbTable.SuspendLayout();
            this.tbOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(10, 43);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(162, 95);
            this.lstServers.TabIndex = 1;
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // lbServers
            // 
            this.lbServers.AutoSize = true;
            this.lbServers.Location = new System.Drawing.Point(7, 27);
            this.lbServers.Name = "lbServers";
            this.lbServers.Size = new System.Drawing.Size(43, 13);
            this.lbServers.TabIndex = 3;
            this.lbServers.Text = "Servers";
            // 
            // lbTableSelected
            // 
            this.lbTableSelected.AutoSize = true;
            this.lbTableSelected.Location = new System.Drawing.Point(7, 147);
            this.lbTableSelected.Name = "lbTableSelected";
            this.lbTableSelected.Size = new System.Drawing.Size(39, 13);
            this.lbTableSelected.TabIndex = 4;
            this.lbTableSelected.Text = "Tables";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveasToolStripMenuItem.Text = "Save &as";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // txtOutputText
            // 
            this.txtOutputText.AcceptsReturn = true;
            this.txtOutputText.Location = new System.Drawing.Point(10, 393);
            this.txtOutputText.Multiline = true;
            this.txtOutputText.Name = "txtOutputText";
            this.txtOutputText.Size = new System.Drawing.Size(570, 128);
            this.txtOutputText.TabIndex = 69;
            // 
            // tbConfig
            // 
            this.tbConfig.Controls.Add(this.tbConnections);
            this.tbConfig.Controls.Add(this.tbTable);
            this.tbConfig.Controls.Add(this.tbOutput);
            this.tbConfig.Location = new System.Drawing.Point(178, 27);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.SelectedIndex = 0;
            this.tbConfig.Size = new System.Drawing.Size(402, 359);
            this.tbConfig.TabIndex = 70;
            // 
            // tbConnections
            // 
            this.tbConnections.Controls.Add(this.ckEnableAutogeneration);
            this.tbConnections.Controls.Add(this.cmdServerDelete);
            this.tbConnections.Controls.Add(this.cmbDatabaseType);
            this.tbConnections.Controls.Add(this.label1);
            this.tbConnections.Controls.Add(this.label4);
            this.tbConnections.Controls.Add(this.txtConnectionString);
            this.tbConnections.Controls.Add(this.label3);
            this.tbConnections.Controls.Add(this.txtNickname);
            this.tbConnections.Controls.Add(this.cmdTestAndSave);
            this.tbConnections.Location = new System.Drawing.Point(4, 22);
            this.tbConnections.Name = "tbConnections";
            this.tbConnections.Padding = new System.Windows.Forms.Padding(3);
            this.tbConnections.Size = new System.Drawing.Size(394, 333);
            this.tbConnections.TabIndex = 0;
            this.tbConnections.Text = "Connections";
            this.tbConnections.UseVisualStyleBackColor = true;
            // 
            // ckEnableAutogeneration
            // 
            this.ckEnableAutogeneration.AutoSize = true;
            this.ckEnableAutogeneration.Location = new System.Drawing.Point(68, 238);
            this.ckEnableAutogeneration.Name = "ckEnableAutogeneration";
            this.ckEnableAutogeneration.Size = new System.Drawing.Size(243, 17);
            this.ckEnableAutogeneration.TabIndex = 41;
            this.ckEnableAutogeneration.Text = "Automatically generate classes for each Table";
            this.ckEnableAutogeneration.UseVisualStyleBackColor = true;
            // 
            // cmdServerDelete
            // 
            this.cmdServerDelete.Location = new System.Drawing.Point(10, 300);
            this.cmdServerDelete.Name = "cmdServerDelete";
            this.cmdServerDelete.Size = new System.Drawing.Size(63, 23);
            this.cmdServerDelete.TabIndex = 40;
            this.cmdServerDelete.Text = "Delete";
            this.cmdServerDelete.UseVisualStyleBackColor = true;
            // 
            // cmbDatabaseType
            // 
            this.cmbDatabaseType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDatabaseType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDatabaseType.FormattingEnabled = true;
            this.cmbDatabaseType.Items.AddRange(new object[] {
            "Microsoft Access",
            "My Sql",
            "Sql Server"});
            this.cmbDatabaseType.Location = new System.Drawing.Point(110, 19);
            this.cmbDatabaseType.Name = "cmbDatabaseType";
            this.cmbDatabaseType.Size = new System.Drawing.Size(121, 21);
            this.cmbDatabaseType.TabIndex = 35;
            this.cmbDatabaseType.SelectedIndexChanged += new System.EventHandler(this.cmbDatabaseType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Database Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Connection String";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(20, 115);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(291, 107);
            this.txtConnectionString.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(110, 52);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(121, 20);
            this.txtNickname.TabIndex = 33;
            // 
            // cmdTestAndSave
            // 
            this.cmdTestAndSave.Location = new System.Drawing.Point(250, 300);
            this.cmdTestAndSave.Name = "cmdTestAndSave";
            this.cmdTestAndSave.Size = new System.Drawing.Size(136, 23);
            this.cmdTestAndSave.TabIndex = 36;
            this.cmdTestAndSave.Text = "Test && Save Connection";
            this.cmdTestAndSave.UseVisualStyleBackColor = true;
            this.cmdTestAndSave.Click += new System.EventHandler(this.cmdTestAndSave_Click);
            // 
            // tbTable
            // 
            this.tbTable.Controls.Add(this.label10);
            this.tbTable.Controls.Add(this.lstFields);
            this.tbTable.Controls.Add(this.label9);
            this.tbTable.Controls.Add(this.txtTableKey);
            this.tbTable.Controls.Add(this.cmdAddTable);
            this.tbTable.Controls.Add(this.cmdRunTestGenerate);
            this.tbTable.Controls.Add(this.cmdEditPostUpdate);
            this.tbTable.Controls.Add(this.cmdEditPostInsert);
            this.tbTable.Controls.Add(this.cmdEditPostExists);
            this.tbTable.Controls.Add(this.cmdEditPostDelete);
            this.tbTable.Controls.Add(this.cmdEditPostSave);
            this.tbTable.Controls.Add(this.cmdEditPostConstructor);
            this.tbTable.Controls.Add(this.cmdEditPreUpdate);
            this.tbTable.Controls.Add(this.ckUpdate);
            this.tbTable.Controls.Add(this.cmdEditPreInsert);
            this.tbTable.Controls.Add(this.ckInsert);
            this.tbTable.Controls.Add(this.cmdEditPreExists);
            this.tbTable.Controls.Add(this.cmdEditPreDelete);
            this.tbTable.Controls.Add(this.cmdEditPreSave);
            this.tbTable.Controls.Add(this.cmdEditPreConstructor);
            this.tbTable.Controls.Add(this.label7);
            this.tbTable.Controls.Add(this.cmdSaveButton);
            this.tbTable.Controls.Add(this.txtTableName);
            this.tbTable.Controls.Add(this.label8);
            this.tbTable.Controls.Add(this.ckExists);
            this.tbTable.Controls.Add(this.ckDelete);
            this.tbTable.Controls.Add(this.ckSave);
            this.tbTable.Controls.Add(this.ckConstructor);
            this.tbTable.Location = new System.Drawing.Point(4, 22);
            this.tbTable.Name = "tbTable";
            this.tbTable.Padding = new System.Windows.Forms.Padding(3);
            this.tbTable.Size = new System.Drawing.Size(394, 333);
            this.tbTable.TabIndex = 1;
            this.tbTable.Text = "Object Definition";
            this.tbTable.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 117;
            this.label10.Text = "Fields";
            // 
            // lstFields
            // 
            this.lstFields.FormattingEnabled = true;
            this.lstFields.Location = new System.Drawing.Point(10, 121);
            this.lstFields.Name = "lstFields";
            this.lstFields.Size = new System.Drawing.Size(121, 173);
            this.lstFields.TabIndex = 116;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 115;
            this.label9.Text = "Keys";
            // 
            // txtTableKey
            // 
            this.txtTableKey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTableKey.Enabled = false;
            this.txtTableKey.Location = new System.Drawing.Point(10, 69);
            this.txtTableKey.Name = "txtTableKey";
            this.txtTableKey.Size = new System.Drawing.Size(121, 20);
            this.txtTableKey.TabIndex = 114;
            // 
            // cmdAddTable
            // 
            this.cmdAddTable.Location = new System.Drawing.Point(10, 300);
            this.cmdAddTable.Name = "cmdAddTable";
            this.cmdAddTable.Size = new System.Drawing.Size(88, 23);
            this.cmdAddTable.TabIndex = 113;
            this.cmdAddTable.Text = "Add Table";
            this.cmdAddTable.UseVisualStyleBackColor = true;
            this.cmdAddTable.Click += new System.EventHandler(this.cmdAddTable_Click);
            // 
            // cmdRunTestGenerate
            // 
            this.cmdRunTestGenerate.Location = new System.Drawing.Point(206, 300);
            this.cmdRunTestGenerate.Name = "cmdRunTestGenerate";
            this.cmdRunTestGenerate.Size = new System.Drawing.Size(88, 23);
            this.cmdRunTestGenerate.TabIndex = 112;
            this.cmdRunTestGenerate.Text = "Test";
            this.cmdRunTestGenerate.UseVisualStyleBackColor = true;
            this.cmdRunTestGenerate.Click += new System.EventHandler(this.cmdSqlTest_Click);
            // 
            // cmdEditPostUpdate
            // 
            this.cmdEditPostUpdate.Location = new System.Drawing.Point(316, 192);
            this.cmdEditPostUpdate.Name = "cmdEditPostUpdate";
            this.cmdEditPostUpdate.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostUpdate.TabIndex = 111;
            this.cmdEditPostUpdate.TabStop = false;
            this.cmdEditPostUpdate.Text = "...";
            this.cmdEditPostUpdate.UseVisualStyleBackColor = true;
            this.cmdEditPostUpdate.Visible = false;
            // 
            // cmdEditPostInsert
            // 
            this.cmdEditPostInsert.Location = new System.Drawing.Point(316, 166);
            this.cmdEditPostInsert.Name = "cmdEditPostInsert";
            this.cmdEditPostInsert.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostInsert.TabIndex = 110;
            this.cmdEditPostInsert.TabStop = false;
            this.cmdEditPostInsert.Text = "...";
            this.cmdEditPostInsert.UseVisualStyleBackColor = true;
            this.cmdEditPostInsert.Visible = false;
            this.cmdEditPostInsert.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmdEditPostExists
            // 
            this.cmdEditPostExists.Location = new System.Drawing.Point(316, 140);
            this.cmdEditPostExists.Name = "cmdEditPostExists";
            this.cmdEditPostExists.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostExists.TabIndex = 109;
            this.cmdEditPostExists.TabStop = false;
            this.cmdEditPostExists.Text = "...";
            this.cmdEditPostExists.UseVisualStyleBackColor = true;
            this.cmdEditPostExists.Visible = false;
            // 
            // cmdEditPostDelete
            // 
            this.cmdEditPostDelete.Location = new System.Drawing.Point(316, 114);
            this.cmdEditPostDelete.Name = "cmdEditPostDelete";
            this.cmdEditPostDelete.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostDelete.TabIndex = 108;
            this.cmdEditPostDelete.TabStop = false;
            this.cmdEditPostDelete.Text = "...";
            this.cmdEditPostDelete.UseVisualStyleBackColor = true;
            this.cmdEditPostDelete.Visible = false;
            // 
            // cmdEditPostSave
            // 
            this.cmdEditPostSave.Location = new System.Drawing.Point(316, 218);
            this.cmdEditPostSave.Name = "cmdEditPostSave";
            this.cmdEditPostSave.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostSave.TabIndex = 107;
            this.cmdEditPostSave.TabStop = false;
            this.cmdEditPostSave.Text = "...";
            this.cmdEditPostSave.UseVisualStyleBackColor = true;
            this.cmdEditPostSave.Visible = false;
            // 
            // cmdEditPostConstructor
            // 
            this.cmdEditPostConstructor.Location = new System.Drawing.Point(316, 90);
            this.cmdEditPostConstructor.Name = "cmdEditPostConstructor";
            this.cmdEditPostConstructor.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPostConstructor.TabIndex = 106;
            this.cmdEditPostConstructor.TabStop = false;
            this.cmdEditPostConstructor.Text = "...";
            this.cmdEditPostConstructor.UseVisualStyleBackColor = true;
            this.cmdEditPostConstructor.Visible = false;
            // 
            // cmdEditPreUpdate
            // 
            this.cmdEditPreUpdate.Location = new System.Drawing.Point(270, 192);
            this.cmdEditPreUpdate.Name = "cmdEditPreUpdate";
            this.cmdEditPreUpdate.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreUpdate.TabIndex = 105;
            this.cmdEditPreUpdate.TabStop = false;
            this.cmdEditPreUpdate.Text = "...";
            this.cmdEditPreUpdate.UseVisualStyleBackColor = true;
            this.cmdEditPreUpdate.Visible = false;
            // 
            // ckUpdate
            // 
            this.ckUpdate.AutoSize = true;
            this.ckUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckUpdate.Location = new System.Drawing.Point(197, 192);
            this.ckUpdate.Name = "ckUpdate";
            this.ckUpdate.Size = new System.Drawing.Size(67, 17);
            this.ckUpdate.TabIndex = 95;
            this.ckUpdate.Text = "Update()";
            this.ckUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckUpdate.UseVisualStyleBackColor = true;
            this.ckUpdate.CheckedChanged += new System.EventHandler(this.ckUpdate_CheckedChanged);
            // 
            // cmdEditPreInsert
            // 
            this.cmdEditPreInsert.Location = new System.Drawing.Point(270, 166);
            this.cmdEditPreInsert.Name = "cmdEditPreInsert";
            this.cmdEditPreInsert.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreInsert.TabIndex = 104;
            this.cmdEditPreInsert.TabStop = false;
            this.cmdEditPreInsert.Text = "...";
            this.cmdEditPreInsert.UseVisualStyleBackColor = true;
            this.cmdEditPreInsert.Visible = false;
            // 
            // ckInsert
            // 
            this.ckInsert.AutoSize = true;
            this.ckInsert.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckInsert.Location = new System.Drawing.Point(206, 166);
            this.ckInsert.Name = "ckInsert";
            this.ckInsert.Size = new System.Drawing.Size(58, 17);
            this.ckInsert.TabIndex = 94;
            this.ckInsert.Text = "Insert()";
            this.ckInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckInsert.UseVisualStyleBackColor = true;
            this.ckInsert.CheckedChanged += new System.EventHandler(this.ckInsert_CheckedChanged);
            // 
            // cmdEditPreExists
            // 
            this.cmdEditPreExists.Location = new System.Drawing.Point(270, 140);
            this.cmdEditPreExists.Name = "cmdEditPreExists";
            this.cmdEditPreExists.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreExists.TabIndex = 103;
            this.cmdEditPreExists.TabStop = false;
            this.cmdEditPreExists.Text = "...";
            this.cmdEditPreExists.UseVisualStyleBackColor = true;
            this.cmdEditPreExists.Visible = false;
            // 
            // cmdEditPreDelete
            // 
            this.cmdEditPreDelete.Location = new System.Drawing.Point(270, 114);
            this.cmdEditPreDelete.Name = "cmdEditPreDelete";
            this.cmdEditPreDelete.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreDelete.TabIndex = 102;
            this.cmdEditPreDelete.TabStop = false;
            this.cmdEditPreDelete.Text = "...";
            this.cmdEditPreDelete.UseVisualStyleBackColor = true;
            this.cmdEditPreDelete.Visible = false;
            // 
            // cmdEditPreSave
            // 
            this.cmdEditPreSave.Location = new System.Drawing.Point(270, 218);
            this.cmdEditPreSave.Name = "cmdEditPreSave";
            this.cmdEditPreSave.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreSave.TabIndex = 101;
            this.cmdEditPreSave.TabStop = false;
            this.cmdEditPreSave.Text = "...";
            this.cmdEditPreSave.UseVisualStyleBackColor = true;
            this.cmdEditPreSave.Visible = false;
            // 
            // cmdEditPreConstructor
            // 
            this.cmdEditPreConstructor.Location = new System.Drawing.Point(270, 90);
            this.cmdEditPreConstructor.Name = "cmdEditPreConstructor";
            this.cmdEditPreConstructor.Size = new System.Drawing.Size(40, 20);
            this.cmdEditPreConstructor.TabIndex = 100;
            this.cmdEditPreConstructor.TabStop = false;
            this.cmdEditPreConstructor.Text = "...";
            this.cmdEditPreConstructor.UseVisualStyleBackColor = true;
            this.cmdEditPreConstructor.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Create Subroutines";
            // 
            // cmdSaveButton
            // 
            this.cmdSaveButton.Location = new System.Drawing.Point(300, 300);
            this.cmdSaveButton.Name = "cmdSaveButton";
            this.cmdSaveButton.Size = new System.Drawing.Size(76, 23);
            this.cmdSaveButton.TabIndex = 98;
            this.cmdSaveButton.Text = "Save";
            this.cmdSaveButton.UseVisualStyleBackColor = true;
            this.cmdSaveButton.Click += new System.EventHandler(this.cmdSaveTable_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(10, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(121, 20);
            this.txtTableName.TabIndex = 90;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Name";
            // 
            // ckExists
            // 
            this.ckExists.AutoSize = true;
            this.ckExists.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckExists.Location = new System.Drawing.Point(197, 140);
            this.ckExists.Name = "ckExists";
            this.ckExists.Size = new System.Drawing.Size(67, 17);
            this.ckExists.TabIndex = 93;
            this.ckExists.Text = "Exists(id)";
            this.ckExists.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckExists.UseVisualStyleBackColor = true;
            this.ckExists.CheckedChanged += new System.EventHandler(this.ckExists_CheckedChanged);
            // 
            // ckDelete
            // 
            this.ckDelete.AutoSize = true;
            this.ckDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDelete.Location = new System.Drawing.Point(201, 114);
            this.ckDelete.Name = "ckDelete";
            this.ckDelete.Size = new System.Drawing.Size(63, 17);
            this.ckDelete.TabIndex = 92;
            this.ckDelete.Text = "Delete()";
            this.ckDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckDelete.UseVisualStyleBackColor = true;
            this.ckDelete.CheckedChanged += new System.EventHandler(this.ckDelete_CheckedChanged);
            // 
            // ckSave
            // 
            this.ckSave.AutoSize = true;
            this.ckSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckSave.Location = new System.Drawing.Point(208, 218);
            this.ckSave.Name = "ckSave";
            this.ckSave.Size = new System.Drawing.Size(57, 17);
            this.ckSave.TabIndex = 96;
            this.ckSave.Text = "Save()";
            this.ckSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckSave.UseVisualStyleBackColor = true;
            this.ckSave.CheckedChanged += new System.EventHandler(this.ckSave_CheckedChanged);
            // 
            // ckConstructor
            // 
            this.ckConstructor.AutoSize = true;
            this.ckConstructor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckConstructor.Location = new System.Drawing.Point(168, 90);
            this.ckConstructor.Name = "ckConstructor";
            this.ckConstructor.Size = new System.Drawing.Size(97, 17);
            this.ckConstructor.TabIndex = 91;
            this.ckConstructor.Text = "Constructor (id)";
            this.ckConstructor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckConstructor.UseVisualStyleBackColor = true;
            this.ckConstructor.CheckedChanged += new System.EventHandler(this.ckConstructor_CheckedChanged);
            // 
            // tbOutput
            // 
            this.tbOutput.Controls.Add(this.cmdBrowseOutput);
            this.tbOutput.Controls.Add(this.txtOutputDirectory);
            this.tbOutput.Controls.Add(this.lbOutputDir);
            this.tbOutput.Controls.Add(this.cmdTestBuild);
            this.tbOutput.Controls.Add(this.cmdBuildAll);
            this.tbOutput.Controls.Add(this.label2);
            this.tbOutput.Controls.Add(this.label6);
            this.tbOutput.Controls.Add(this.cmbOutputType);
            this.tbOutput.Controls.Add(this.cmbOutputLanguage);
            this.tbOutput.Location = new System.Drawing.Point(4, 22);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(394, 333);
            this.tbOutput.TabIndex = 2;
            this.tbOutput.Text = "Output Details";
            this.tbOutput.UseVisualStyleBackColor = true;
            // 
            // cmdBrowseOutput
            // 
            this.cmdBrowseOutput.Location = new System.Drawing.Point(249, 30);
            this.cmdBrowseOutput.Name = "cmdBrowseOutput";
            this.cmdBrowseOutput.Size = new System.Drawing.Size(76, 23);
            this.cmdBrowseOutput.TabIndex = 85;
            this.cmdBrowseOutput.Text = "Select";
            this.cmdBrowseOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(17, 30);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(215, 20);
            this.txtOutputDirectory.TabIndex = 84;
            // 
            // lbOutputDir
            // 
            this.lbOutputDir.AutoSize = true;
            this.lbOutputDir.Location = new System.Drawing.Point(14, 14);
            this.lbOutputDir.Name = "lbOutputDir";
            this.lbOutputDir.Size = new System.Drawing.Size(84, 13);
            this.lbOutputDir.TabIndex = 83;
            this.lbOutputDir.Text = "Output Directory";
            // 
            // cmdTestBuild
            // 
            this.cmdTestBuild.Location = new System.Drawing.Point(300, 300);
            this.cmdTestBuild.Name = "cmdTestBuild";
            this.cmdTestBuild.Size = new System.Drawing.Size(76, 23);
            this.cmdTestBuild.TabIndex = 82;
            this.cmdTestBuild.Text = "Test";
            this.cmdTestBuild.UseVisualStyleBackColor = true;
            this.cmdTestBuild.Click += new System.EventHandler(this.cmdTestBuild_Click);
            // 
            // cmdBuildAll
            // 
            this.cmdBuildAll.Location = new System.Drawing.Point(10, 300);
            this.cmdBuildAll.Name = "cmdBuildAll";
            this.cmdBuildAll.Size = new System.Drawing.Size(108, 23);
            this.cmdBuildAll.TabIndex = 81;
            this.cmdBuildAll.Text = "Build All ";
            this.cmdBuildAll.UseVisualStyleBackColor = true;
            this.cmdBuildAll.Click += new System.EventHandler(this.cmdBuildAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Output Language";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 79;
            this.label6.Text = "Output Type";
            // 
            // cmbOutputType
            // 
            this.cmbOutputType.FormattingEnabled = true;
            this.cmbOutputType.Items.AddRange(new object[] {
            "Text Window",
            "Files",
            "Output window"});
            this.cmbOutputType.Location = new System.Drawing.Point(135, 183);
            this.cmbOutputType.Name = "cmbOutputType";
            this.cmbOutputType.Size = new System.Drawing.Size(121, 21);
            this.cmbOutputType.TabIndex = 78;
            // 
            // cmbOutputLanguage
            // 
            this.cmbOutputLanguage.FormattingEnabled = true;
            this.cmbOutputLanguage.Items.AddRange(new object[] {
            "C#",
            "Java"});
            this.cmbOutputLanguage.Location = new System.Drawing.Point(135, 150);
            this.cmbOutputLanguage.Name = "cmbOutputLanguage";
            this.cmbOutputLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbOutputLanguage.TabIndex = 77;
            this.cmbOutputLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbOutputLanguage_SelectedIndexChanged);
            // 
            // cmdSqlTest
            // 
            this.cmdSqlTest.Location = new System.Drawing.Point(46, 263);
            this.cmdSqlTest.Name = "cmdSqlTest";
            this.cmdSqlTest.Size = new System.Drawing.Size(88, 23);
            this.cmdSqlTest.TabIndex = 89;
            this.cmdSqlTest.Text = "Test";
            this.cmdSqlTest.UseVisualStyleBackColor = true;
            // 
            // lbSubroutines
            // 
            this.lbSubroutines.AutoSize = true;
            this.lbSubroutines.Location = new System.Drawing.Point(18, 71);
            this.lbSubroutines.Name = "lbSubroutines";
            this.lbSubroutines.Size = new System.Drawing.Size(97, 13);
            this.lbSubroutines.TabIndex = 76;
            this.lbSubroutines.Text = "Create Subroutines";
            // 
            // cmdSaveTable
            // 
            this.cmdSaveTable.Location = new System.Drawing.Point(148, 263);
            this.cmdSaveTable.Name = "cmdSaveTable";
            this.cmdSaveTable.Size = new System.Drawing.Size(76, 23);
            this.cmdSaveTable.TabIndex = 75;
            this.cmdSaveTable.Text = "Save";
            this.cmdSaveTable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Name";
            // 
            // lstTableSelected
            // 
            this.lstTableSelected.FormattingEnabled = true;
            this.lstTableSelected.Location = new System.Drawing.Point(10, 164);
            this.lstTableSelected.Name = "lstTableSelected";
            this.lstTableSelected.Size = new System.Drawing.Size(162, 225);
            this.lstTableSelected.TabIndex = 71;
            this.lstTableSelected.SelectedIndexChanged += new System.EventHandler(this.lstTableSelected_SelectedIndexChanged);
            // 
            // frmGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 531);
            this.Controls.Add(this.lstTableSelected);
            this.Controls.Add(this.tbConfig);
            this.Controls.Add(this.txtOutputText);
            this.Controls.Add(this.lbTableSelected);
            this.Controls.Add(this.lbServers);
            this.Controls.Add(this.lstServers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGenerator";
            this.Text = "DataService Generator";
            this.Load += new System.EventHandler(this.frmGenerator_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbConfig.ResumeLayout(false);
            this.tbConnections.ResumeLayout(false);
            this.tbConnections.PerformLayout();
            this.tbTable.ResumeLayout(false);
            this.tbTable.PerformLayout();
            this.tbOutput.ResumeLayout(false);
            this.tbOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.Label lbServers;
        private System.Windows.Forms.Label lbTableSelected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtOutputText;
        private System.Windows.Forms.TabControl tbConfig;
        private System.Windows.Forms.TabPage tbConnections;
        private System.Windows.Forms.TabPage tbTable;
        private System.Windows.Forms.TabPage tbOutput;
        private System.Windows.Forms.Button cmdSqlTest;
      
        private System.Windows.Forms.Label lbSubroutines;
        private System.Windows.Forms.Button cmdSaveTable;
     
        private System.Windows.Forms.Label label5;
    
        private System.Windows.Forms.Button cmdServerDelete;
        private System.Windows.Forms.ComboBox cmbDatabaseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Button cmdTestAndSave;
        private System.Windows.Forms.Button cmdRunTestGenerate;
        private System.Windows.Forms.Button cmdEditPostUpdate;
        private System.Windows.Forms.Button cmdEditPostInsert;
        private System.Windows.Forms.Button cmdEditPostExists;
        private System.Windows.Forms.Button cmdEditPostDelete;
        private System.Windows.Forms.Button cmdEditPostSave;
        private System.Windows.Forms.Button cmdEditPostConstructor;
        private System.Windows.Forms.Button cmdEditPreUpdate;
        private System.Windows.Forms.CheckBox ckUpdate;
        private System.Windows.Forms.Button cmdEditPreInsert;
        private System.Windows.Forms.CheckBox ckInsert;
        private System.Windows.Forms.Button cmdEditPreExists;
        private System.Windows.Forms.Button cmdEditPreDelete;
        private System.Windows.Forms.Button cmdEditPreSave;
        private System.Windows.Forms.Button cmdEditPreConstructor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdSaveButton;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckExists;
        private System.Windows.Forms.CheckBox ckDelete;
        private System.Windows.Forms.CheckBox ckSave;
        private System.Windows.Forms.CheckBox ckConstructor;
        private System.Windows.Forms.Button cmdBrowseOutput;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Label lbOutputDir;
        private System.Windows.Forms.Button cmdTestBuild;
        private System.Windows.Forms.Button cmdBuildAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOutputType;
        private System.Windows.Forms.ComboBox cmbOutputLanguage;
        private System.Windows.Forms.Button cmdAddTable;
        private System.Windows.Forms.CheckBox ckEnableAutogeneration;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox lstTableSelected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTableKey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstFields;
    }
}

