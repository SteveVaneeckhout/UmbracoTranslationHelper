
namespace UmbracoTranslationHelper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanitizeDictionaryFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpCheckForUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.wordsListView = new System.Windows.Forms.ListView();
            this.AliasHeader = new System.Windows.Forms.ColumnHeader();
            this.originalHeader = new System.Windows.Forms.ColumnHeader();
            this.translationHeader = new System.Windows.Forms.ColumnHeader();
            this.onlyNontranslationsCheckbox = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.toolsMenuItem,
            this.helpMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1912, 33);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewMenuItem,
            this.fileOpenMenuItem,
            this.fileSaveMenuItem,
            this.fileCloseMenuItem,
            this.toolStripSeparator1,
            this.fileExitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileMenuItem.Text = "File";
            // 
            // fileNewMenuItem
            // 
            this.fileNewMenuItem.Name = "fileNewMenuItem";
            this.fileNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileNewMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fileNewMenuItem.Text = "New...";
            this.fileNewMenuItem.Click += new System.EventHandler(this.fileNewMenuItem_Click);
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fileOpenMenuItem.Text = "Open...";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.fileOpenMenuItem_Click);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            this.fileSaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSaveMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fileSaveMenuItem.Text = "Save";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // fileCloseMenuItem
            // 
            this.fileCloseMenuItem.Name = "fileCloseMenuItem";
            this.fileCloseMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.fileCloseMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fileCloseMenuItem.Text = "Close";
            this.fileCloseMenuItem.Click += new System.EventHandler(this.fileCloseMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fileExitMenuItem.Text = "Exit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sanitizeDictionaryFilesMenuItem,
            this.toolStripSeparator2,
            this.optionsMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsMenuItem.Text = "Tools";
            // 
            // sanitizeDictionaryFilesMenuItem
            // 
            this.sanitizeDictionaryFilesMenuItem.Name = "sanitizeDictionaryFilesMenuItem";
            this.sanitizeDictionaryFilesMenuItem.Size = new System.Drawing.Size(305, 34);
            this.sanitizeDictionaryFilesMenuItem.Text = "Sanitize dictionary files...";
            this.sanitizeDictionaryFilesMenuItem.Click += new System.EventHandler(this.sanitizeDictionaryFilesMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(302, 6);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(305, 34);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpCheckForUpdateMenuItem,
            this.toolStripSeparator3,
            this.helpAboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpMenuItem.Text = "Help";
            // 
            // helpCheckForUpdateMenuItem
            // 
            this.helpCheckForUpdateMenuItem.Name = "helpCheckForUpdateMenuItem";
            this.helpCheckForUpdateMenuItem.Size = new System.Drawing.Size(250, 34);
            this.helpCheckForUpdateMenuItem.Text = "Check for update";
            this.helpCheckForUpdateMenuItem.Click += new System.EventHandler(this.helpCheckForUpdateMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(247, 6);
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.Size = new System.Drawing.Size(250, 34);
            this.helpAboutMenuItem.Text = "About";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.helpAboutMenuItem_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the root folder of the Umbraco repository";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // wordsListView
            // 
            this.wordsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AliasHeader,
            this.originalHeader,
            this.translationHeader});
            this.wordsListView.FullRowSelect = true;
            this.wordsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.wordsListView.HideSelection = false;
            this.wordsListView.Location = new System.Drawing.Point(12, 87);
            this.wordsListView.Name = "wordsListView";
            this.wordsListView.Size = new System.Drawing.Size(1888, 1005);
            this.wordsListView.TabIndex = 5;
            this.wordsListView.UseCompatibleStateImageBehavior = false;
            this.wordsListView.View = System.Windows.Forms.View.Details;
            this.wordsListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordsListView_KeyPress);
            this.wordsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.wordsListView_MouseDoubleClick);
            // 
            // AliasHeader
            // 
            this.AliasHeader.Text = "Alias";
            this.AliasHeader.Width = 300;
            // 
            // originalHeader
            // 
            this.originalHeader.Text = "Original";
            this.originalHeader.Width = 500;
            // 
            // translationHeader
            // 
            this.translationHeader.Text = "Translation";
            this.translationHeader.Width = 500;
            // 
            // onlyNontranslationsCheckbox
            // 
            this.onlyNontranslationsCheckbox.AutoSize = true;
            this.onlyNontranslationsCheckbox.Location = new System.Drawing.Point(12, 36);
            this.onlyNontranslationsCheckbox.Name = "onlyNontranslationsCheckbox";
            this.onlyNontranslationsCheckbox.Size = new System.Drawing.Size(283, 29);
            this.onlyNontranslationsCheckbox.TabIndex = 6;
            this.onlyNontranslationsCheckbox.Text = "Only show untranslated strings";
            this.onlyNontranslationsCheckbox.UseVisualStyleBackColor = true;
            this.onlyNontranslationsCheckbox.CheckedChanged += new System.EventHandler(this.onlyNontranslationsCheckbox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1912, 1104);
            this.Controls.Add(this.onlyNontranslationsCheckbox);
            this.Controls.Add(this.wordsListView);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Umbraco Package & Backoffice Translation Tool";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpCheckForUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListView wordsListView;
        private System.Windows.Forms.ColumnHeader AliasHeader;
        private System.Windows.Forms.ColumnHeader originalHeader;
        private System.Windows.Forms.ColumnHeader translationHeader;
        private System.Windows.Forms.CheckBox onlyNontranslationsCheckbox;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sanitizeDictionaryFilesMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileCloseMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

