namespace ImageTagging
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMostUsed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMostRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearPreviousTags = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.txtTagEntry = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.openImageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitAll = new System.Windows.Forms.SplitContainer();
            this.splitLeftContent = new System.Windows.Forms.SplitContainer();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.lblCurrentTagsText = new System.Windows.Forms.Label();
            this.lblExistingTags = new System.Windows.Forms.LinkLabel();
            this.lblTagsHeader = new System.Windows.Forms.Label();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrevTags = new ImageTagging.ResizableButtonPanel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.dlgOpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAll)).BeginInit();
            this.splitAll.Panel1.SuspendLayout();
            this.splitAll.Panel2.SuspendLayout();
            this.splitAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftContent)).BeginInit();
            this.splitLeftContent.Panel1.SuspendLayout();
            this.splitLeftContent.Panel2.SuspendLayout();
            this.splitLeftContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.SystemColors.Control;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.viewToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuMain.Size = new System.Drawing.Size(627, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFolder,
            this.mnuFileOpenImage,
            this.mnuFileQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuOpenFolder
            // 
            this.mnuOpenFolder.Name = "mnuOpenFolder";
            this.mnuOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenFolder.Size = new System.Drawing.Size(182, 22);
            this.mnuOpenFolder.Text = "&Open Folder";
            this.mnuOpenFolder.Click += new System.EventHandler(this.mnuOpenFolder_Click);
            // 
            // mnuFileOpenImage
            // 
            this.mnuFileOpenImage.Name = "mnuFileOpenImage";
            this.mnuFileOpenImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuFileOpenImage.Size = new System.Drawing.Size(182, 22);
            this.mnuFileOpenImage.Text = "Open &Image";
            this.mnuFileOpenImage.Click += new System.EventHandler(this.mnuFileOpenImage_Click);
            // 
            // mnuFileQuit
            // 
            this.mnuFileQuit.Name = "mnuFileQuit";
            this.mnuFileQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuFileQuit.Size = new System.Drawing.Size(182, 22);
            this.mnuFileQuit.Text = "&Quit";
            this.mnuFileQuit.Click += new System.EventHandler(this.mnuFileQuit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuEditPaste});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopy.Image")));
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(230, 22);
            this.mnuCopy.Text = "Copy From Text Entry";
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditPaste.Image")));
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEditPaste.Size = new System.Drawing.Size(230, 22);
            this.mnuEditPaste.Text = "Paste Into Text Entry";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagSortingToolStripMenuItem,
            this.mnuClearPreviousTags});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // tagSortingToolStripMenuItem
            // 
            this.tagSortingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMostUsed,
            this.mnuMostRecent});
            this.tagSortingToolStripMenuItem.Name = "tagSortingToolStripMenuItem";
            this.tagSortingToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.tagSortingToolStripMenuItem.Text = "Tag Sorting";
            // 
            // mnuMostUsed
            // 
            this.mnuMostUsed.Name = "mnuMostUsed";
            this.mnuMostUsed.Size = new System.Drawing.Size(140, 22);
            this.mnuMostUsed.Text = "Most Used";
            this.mnuMostUsed.Click += new System.EventHandler(this.mnuMostUsed_Click);
            // 
            // mnuMostRecent
            // 
            this.mnuMostRecent.Name = "mnuMostRecent";
            this.mnuMostRecent.Size = new System.Drawing.Size(140, 22);
            this.mnuMostRecent.Text = "Most Recent";
            this.mnuMostRecent.Click += new System.EventHandler(this.mnuMostRecent_Click);
            // 
            // mnuClearPreviousTags
            // 
            this.mnuClearPreviousTags.Name = "mnuClearPreviousTags";
            this.mnuClearPreviousTags.Size = new System.Drawing.Size(177, 22);
            this.mnuClearPreviousTags.Text = "Clear Previous Tags";
            this.mnuClearPreviousTags.Click += new System.EventHandler(this.mnuClearPreviousTags_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "JPEG|*.jpg";
            // 
            // txtTagEntry
            // 
            this.txtTagEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTagEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagEntry.Location = new System.Drawing.Point(19, 287);
            this.txtTagEntry.Name = "txtTagEntry";
            this.txtTagEntry.Size = new System.Drawing.Size(119, 26);
            this.txtTagEntry.TabIndex = 0;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(627, 425);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 470;
            this.lineShape1.X2 = 545;
            this.lineShape1.Y1 = -8;
            this.lineShape1.Y2 = 15;
            // 
            // tlsMain
            // 
            this.tlsMain.BackColor = System.Drawing.SystemColors.Control;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.pasteToolStripButton});
            this.tlsMain.Location = new System.Drawing.Point(0, 24);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(627, 25);
            this.tlsMain.TabIndex = 7;
            this.tlsMain.Text = "Open Image";
            // 
            // openImageToolStripButton
            // 
            this.openImageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openImageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openImageToolStripButton.Image")));
            this.openImageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openImageToolStripButton.Name = "openImageToolStripButton";
            this.openImageToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openImageToolStripButton.Text = "toolStripButton1";
            this.openImageToolStripButton.ToolTipText = "Open Image (Ctrl+I)";
            this.openImageToolStripButton.Click += new System.EventHandler(this.openImageToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open Folder (Ctrl+O)";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste Into Text Entry";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // splitAll
            // 
            this.splitAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitAll.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitAll.ForeColor = System.Drawing.SystemColors.WindowText;
            this.splitAll.Location = new System.Drawing.Point(-10, 52);
            this.splitAll.Name = "splitAll";
            // 
            // splitAll.Panel1
            // 
            this.splitAll.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitAll.Panel1.Controls.Add(this.splitLeftContent);
            // 
            // splitAll.Panel2
            // 
            this.splitAll.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitAll.Panel2.Controls.Add(this.lblTagsHeader);
            this.splitAll.Panel2.Controls.Add(this.btnAddTag);
            this.splitAll.Panel2.Controls.Add(this.label1);
            this.splitAll.Panel2.Controls.Add(this.pnlPrevTags);
            this.splitAll.Panel2.Controls.Add(this.txtTagEntry);
            this.splitAll.Panel2.Controls.Add(this.shapeContainer2);
            this.splitAll.Size = new System.Drawing.Size(637, 361);
            this.splitAll.SplitterDistance = 357;
            this.splitAll.SplitterWidth = 5;
            this.splitAll.TabIndex = 9;
            // 
            // splitLeftContent
            // 
            this.splitLeftContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitLeftContent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitLeftContent.Location = new System.Drawing.Point(0, 0);
            this.splitLeftContent.Name = "splitLeftContent";
            this.splitLeftContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeftContent.Panel1
            // 
            this.splitLeftContent.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitLeftContent.Panel1.Controls.Add(this.picMain);
            // 
            // splitLeftContent.Panel2
            // 
            this.splitLeftContent.Panel2.AutoScroll = true;
            this.splitLeftContent.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitLeftContent.Panel2.Controls.Add(this.btnNextImage);
            this.splitLeftContent.Panel2.Controls.Add(this.btnPrevImage);
            this.splitLeftContent.Panel2.Controls.Add(this.lblCurrentTagsText);
            this.splitLeftContent.Panel2.Controls.Add(this.lblExistingTags);
            this.splitLeftContent.Panel2.Resize += new System.EventHandler(this.splitLeftContent_Panel2_Resize);
            this.splitLeftContent.Panel2MinSize = 65;
            this.splitLeftContent.Size = new System.Drawing.Size(355, 348);
            this.splitLeftContent.SplitterDistance = 204;
            this.splitLeftContent.SplitterWidth = 6;
            this.splitLeftContent.TabIndex = 10;
            // 
            // picMain
            // 
            this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image")));
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(355, 204);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 3;
            this.picMain.TabStop = false;
            // 
            // btnNextImage
            // 
            this.btnNextImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNextImage.Location = new System.Drawing.Point(124, 14);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(111, 23);
            this.btnNextImage.TabIndex = 9;
            this.btnNextImage.TabStop = false;
            this.btnNextImage.Text = "Next >>";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrevImage.Location = new System.Drawing.Point(10, 14);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(111, 23);
            this.btnPrevImage.TabIndex = 8;
            this.btnPrevImage.TabStop = false;
            this.btnPrevImage.Text = "<< Previous";
            this.btnPrevImage.UseVisualStyleBackColor = true;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // lblCurrentTagsText
            // 
            this.lblCurrentTagsText.AutoSize = true;
            this.lblCurrentTagsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTagsText.Location = new System.Drawing.Point(21, 45);
            this.lblCurrentTagsText.Name = "lblCurrentTagsText";
            this.lblCurrentTagsText.Size = new System.Drawing.Size(161, 20);
            this.lblCurrentTagsText.TabIndex = 7;
            this.lblCurrentTagsText.Text = "Tagged in this Image:";
            // 
            // lblExistingTags
            // 
            this.lblExistingTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExistingTags.AutoEllipsis = true;
            this.lblExistingTags.AutoSize = true;
            this.lblExistingTags.Location = new System.Drawing.Point(32, 68);
            this.lblExistingTags.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblExistingTags.Name = "lblExistingTags";
            this.lblExistingTags.Size = new System.Drawing.Size(0, 13);
            this.lblExistingTags.TabIndex = 6;
            this.lblExistingTags.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExistingTags_LinkClicked);
            // 
            // lblTagsHeader
            // 
            this.lblTagsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTagsHeader.AutoSize = true;
            this.lblTagsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagsHeader.Location = new System.Drawing.Point(4, 7);
            this.lblTagsHeader.Name = "lblTagsHeader";
            this.lblTagsHeader.Size = new System.Drawing.Size(108, 17);
            this.lblTagsHeader.TabIndex = 9;
            this.lblTagsHeader.Text = "Text Goes Here";
            // 
            // btnAddTag
            // 
            this.btnAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTag.Location = new System.Drawing.Point(144, 287);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(73, 31);
            this.btnAddTag.TabIndex = 7;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Tag:";
            // 
            // pnlPrevTags
            // 
            this.pnlPrevTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPrevTags.Location = new System.Drawing.Point(7, 26);
            this.pnlPrevTags.Name = "pnlPrevTags";
            this.pnlPrevTags.Size = new System.Drawing.Size(246, 227);
            this.pnlPrevTags.TabIndex = 5;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(273, 359);
            this.shapeContainer2.TabIndex = 8;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 7;
            this.lineShape2.X2 = 262;
            this.lineShape2.Y1 = 258;
            this.lineShape2.Y2 = 258;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 403);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(627, 22);
            this.statusBar.TabIndex = 10;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(19, 17);
            this.statusLabel.Text = "    ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 425);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.splitAll);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.shapeContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "JPEG Tag";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.splitAll.Panel1.ResumeLayout(false);
            this.splitAll.Panel2.ResumeLayout(false);
            this.splitAll.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAll)).EndInit();
            this.splitAll.ResumeLayout(false);
            this.splitLeftContent.Panel1.ResumeLayout(false);
            this.splitLeftContent.Panel2.ResumeLayout(false);
            this.splitLeftContent.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftContent)).EndInit();
            this.splitLeftContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenImage;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuFileQuit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.TextBox txtTagEntry;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.LinkLabel lblExistingTags;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.SplitContainer splitAll;
        private ResizableButtonPanel pnlPrevTags;
        private System.Windows.Forms.SplitContainer splitLeftContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTag;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label lblCurrentTagsText;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolder;
        private System.Windows.Forms.ToolStripButton openImageToolStripButton;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label lblTagsHeader;
        private System.Windows.Forms.ToolStripMenuItem tagSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMostUsed;
        private System.Windows.Forms.ToolStripMenuItem mnuMostRecent;
        private System.Windows.Forms.ToolStripMenuItem mnuClearPreviousTags;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

