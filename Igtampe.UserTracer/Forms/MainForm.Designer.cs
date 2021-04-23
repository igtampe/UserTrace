
namespace Igtampe.UserTracer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Professor Chopo",
            "20"}, -1);
            this.TheMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RootUserComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TileBG = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PFPPictureBox = new System.Windows.Forms.PictureBox();
            this.CreatedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.LinkButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.UserListView = new System.Windows.Forms.ListView();
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChildNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UsersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUnderThisUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BGOptionsToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bGOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeServerIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.ImagePicker = new System.Windows.Forms.OpenFileDialog();
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ProjectDirPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TheMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PFPPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.UsersContextMenu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TheMenuStrip
            // 
            this.TheMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.TheMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TheMenuStrip.Name = "TheMenuStrip";
            this.TheMenuStrip.Size = new System.Drawing.Size(1142, 24);
            this.TheMenuStrip.TabIndex = 1;
            this.TheMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(145, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.printToolStripMenuItem.Text = "&Export";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RootUserComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TileBG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PFPPictureBox);
            this.groupBox1.Controls.Add(this.CreatedDateTimePicker);
            this.groupBox1.Controls.Add(this.NameBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 114);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Info";
            // 
            // RootUserComboBox
            // 
            this.RootUserComboBox.FormattingEnabled = true;
            this.RootUserComboBox.Location = new System.Drawing.Point(134, 90);
            this.RootUserComboBox.Name = "RootUserComboBox";
            this.RootUserComboBox.Size = new System.Drawing.Size(204, 21);
            this.RootUserComboBox.TabIndex = 11;
            this.RootUserComboBox.Text = "Professor Chopo";
            this.TheToolTip.SetToolTip(this.RootUserComboBox, "The root user (User where all other users will stem from)\r\n\r\n\r\nNOTE: If you chang" +
        "e this, Users that come before the new root,\r\n(IE Its parent, its parent\'s paren" +
        "t, etc.) may be lost!!");
            this.RootUserComboBox.SelectedIndexChanged += new System.EventHandler(this.RootUserComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Root User";
            // 
            // TileBG
            // 
            this.TileBG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TileBG.Location = new System.Drawing.Point(3, 88);
            this.TileBG.Margin = new System.Windows.Forms.Padding(0);
            this.TileBG.Name = "TileBG";
            this.TileBG.Size = new System.Drawing.Size(70, 23);
            this.TileBG.TabIndex = 9;
            this.TileBG.Text = "BG Options";
            this.TheToolTip.SetToolTip(this.TileBG, "Choose an image to tile in the background");
            this.TileBG.UseVisualStyleBackColor = true;
            this.TileBG.Click += new System.EventHandler(this.TileBG_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Created";
            // 
            // PFPPictureBox
            // 
            this.PFPPictureBox.Image = global::Igtampe.UserTracer.Properties.Resources.UnknownPerson;
            this.PFPPictureBox.Location = new System.Drawing.Point(6, 19);
            this.PFPPictureBox.Name = "PFPPictureBox";
            this.PFPPictureBox.Size = new System.Drawing.Size(64, 64);
            this.PFPPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PFPPictureBox.TabIndex = 7;
            this.PFPPictureBox.TabStop = false;
            this.TheToolTip.SetToolTip(this.PFPPictureBox, "Click me to change the server icon");
            this.PFPPictureBox.Click += new System.EventHandler(this.PFPPictureBox_Click);
            // 
            // CreatedDateTimePicker
            // 
            this.CreatedDateTimePicker.Location = new System.Drawing.Point(134, 64);
            this.CreatedDateTimePicker.Name = "CreatedDateTimePicker";
            this.CreatedDateTimePicker.Size = new System.Drawing.Size(204, 20);
            this.CreatedDateTimePicker.TabIndex = 6;
            this.TheToolTip.SetToolTip(this.CreatedDateTimePicker, "The date that the server was created on");
            this.CreatedDateTimePicker.ValueChanged += new System.EventHandler(this.CreatedDateTimePicker_ValueChanged);
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.Location = new System.Drawing.Point(76, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(262, 39);
            this.NameBox.TabIndex = 5;
            this.NameBox.Text = "A Server";
            this.TheToolTip.SetToolTip(this.NameBox, "The Name of the Server");
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 458);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.AddButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.LinkButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.EditButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.UserListView, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(353, 439);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 412);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(267, 412);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // LinkButton
            // 
            this.LinkButton.Location = new System.Drawing.Point(179, 412);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(75, 23);
            this.LinkButton.TabIndex = 4;
            this.LinkButton.Text = "Re-Link";
            this.LinkButton.UseVisualStyleBackColor = true;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(91, 412);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // UserListView
            // 
            this.UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.ChildNumber});
            this.tableLayoutPanel2.SetColumnSpan(this.UserListView, 4);
            this.UserListView.ContextMenuStrip = this.UsersContextMenu;
            this.UserListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserListView.FullRowSelect = true;
            this.UserListView.HideSelection = false;
            this.UserListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.UserListView.Location = new System.Drawing.Point(3, 3);
            this.UserListView.MultiSelect = false;
            this.UserListView.Name = "UserListView";
            this.UserListView.Size = new System.Drawing.Size(347, 403);
            this.UserListView.TabIndex = 0;
            this.TheToolTip.SetToolTip(this.UserListView, "Users in this UserTrace");
            this.UserListView.UseCompatibleStateImageBehavior = false;
            this.UserListView.View = System.Windows.Forms.View.Details;
            this.UserListView.SelectedIndexChanged += new System.EventHandler(this.UserListView_SelectedIndexChange);
            this.UserListView.DoubleClick += new System.EventHandler(this.EditButton_Click);
            // 
            // UserName
            // 
            this.UserName.Text = "Name";
            this.UserName.Width = 199;
            // 
            // ChildNumber
            // 
            this.ChildNumber.Text = "Number of Subusers";
            this.ChildNumber.Width = 108;
            // 
            // UsersContextMenu
            // 
            this.UsersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUnderThisUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.reLinkToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.BGOptionsToolStripSeparator,
            this.bGOptionsToolStripMenuItem,
            this.changeServerIconToolStripMenuItem});
            this.UsersContextMenu.Name = "contextMenuStrip1";
            this.UsersContextMenu.Size = new System.Drawing.Size(180, 142);
            this.UsersContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.UsersContextMenu_Opening);
            // 
            // newUnderThisUserToolStripMenuItem
            // 
            this.newUnderThisUserToolStripMenuItem.Name = "newUnderThisUserToolStripMenuItem";
            this.newUnderThisUserToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newUnderThisUserToolStripMenuItem.Text = "New under this user";
            this.newUnderThisUserToolStripMenuItem.Click += new System.EventHandler(this.NewUnderThisUserToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // reLinkToolStripMenuItem
            // 
            this.reLinkToolStripMenuItem.Name = "reLinkToolStripMenuItem";
            this.reLinkToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.reLinkToolStripMenuItem.Text = "Re-Link";
            this.reLinkToolStripMenuItem.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // BGOptionsToolStripSeparator
            // 
            this.BGOptionsToolStripSeparator.Name = "BGOptionsToolStripSeparator";
            this.BGOptionsToolStripSeparator.Size = new System.Drawing.Size(176, 6);
            // 
            // bGOptionsToolStripMenuItem
            // 
            this.bGOptionsToolStripMenuItem.Name = "bGOptionsToolStripMenuItem";
            this.bGOptionsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.bGOptionsToolStripMenuItem.Text = "BG Options";
            this.bGOptionsToolStripMenuItem.Click += new System.EventHandler(this.TileBG_Click);
            // 
            // changeServerIconToolStripMenuItem
            // 
            this.changeServerIconToolStripMenuItem.Name = "changeServerIconToolStripMenuItem";
            this.changeServerIconToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.changeServerIconToolStripMenuItem.Text = "Change Server Icon";
            this.changeServerIconToolStripMenuItem.Click += new System.EventHandler(this.PFPPictureBox_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PreviewPictureBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(368, 3);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(771, 578);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PreviewPictureBox.BackgroundImage = global::Igtampe.UserTracer.Properties.Resources.Banner__faint_;
            this.PreviewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PreviewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewPictureBox.Image = global::Igtampe.UserTracer.Properties.Resources.Sandstone;
            this.PreviewPictureBox.Location = new System.Drawing.Point(3, 16);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(765, 559);
            this.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewPictureBox.TabIndex = 0;
            this.PreviewPictureBox.TabStop = false;
            this.TheToolTip.SetToolTip(this.PreviewPictureBox, "Too small? Click me for a full size preview");
            this.PreviewPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PreviewPictureBox_Click);
            // 
            // ImagePicker
            // 
            this.ImagePicker.FileName = "Pfp.png";
            this.ImagePicker.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            // 
            // ExportFileDialog
            // 
            this.ExportFileDialog.DefaultExt = "png";
            this.ExportFileDialog.FileName = "UserTrace.png";
            this.ExportFileDialog.Filter = "PNG Files|*.png";
            this.ExportFileDialog.Title = "Export";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 365F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1142, 584);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TheMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TheMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserTracer - New Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingHandler);
            this.Load += new System.EventHandler(this.MainForm_Loading);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.TheMenuStrip.ResumeLayout(false);
            this.TheMenuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PFPPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.UsersContextMenu.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TheMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PFPPictureBox;
        private System.Windows.Forms.DateTimePicker CreatedDateTimePicker;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView UserListView;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader ChildNumber;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button TileBG;
        private System.Windows.Forms.ComboBox RootUserComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.OpenFileDialog ImagePicker;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
        private System.Windows.Forms.FolderBrowserDialog ProjectDirPicker;
        private System.Windows.Forms.ContextMenuStrip UsersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newUnderThisUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolTip TheToolTip;
        private System.Windows.Forms.ToolStripSeparator BGOptionsToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem bGOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeServerIconToolStripMenuItem;
    }
}

