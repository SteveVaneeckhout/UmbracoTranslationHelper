
namespace UmbracoTranslationHelper
{
    partial class OptionsForm
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
            this.sourceDictionaryDirectoryLabel = new System.Windows.Forms.Label();
            this.sourcePathTextbox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.leadingLanguagesComboBox = new System.Windows.Forms.ComboBox();
            this.leadingLanguageLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceDictionaryDirectoryLabel
            // 
            this.sourceDictionaryDirectoryLabel.AutoSize = true;
            this.sourceDictionaryDirectoryLabel.Location = new System.Drawing.Point(12, 43);
            this.sourceDictionaryDirectoryLabel.Name = "sourceDictionaryDirectoryLabel";
            this.sourceDictionaryDirectoryLabel.Size = new System.Drawing.Size(217, 25);
            this.sourceDictionaryDirectoryLabel.TabIndex = 0;
            this.sourceDictionaryDirectoryLabel.Text = "Umbraco source directory";
            // 
            // sourcePathTextbox
            // 
            this.sourcePathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePathTextbox.Location = new System.Drawing.Point(235, 40);
            this.sourcePathTextbox.Name = "sourcePathTextbox";
            this.sourcePathTextbox.Size = new System.Drawing.Size(474, 31);
            this.sourcePathTextbox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(597, 240);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(112, 34);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(715, 38);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(112, 34);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the root folder of the Umbraco source repository";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // leadingLanguagesComboBox
            // 
            this.leadingLanguagesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leadingLanguagesComboBox.DisplayMember = "Text";
            this.leadingLanguagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leadingLanguagesComboBox.FormattingEnabled = true;
            this.leadingLanguagesComboBox.Location = new System.Drawing.Point(235, 104);
            this.leadingLanguagesComboBox.Name = "leadingLanguagesComboBox";
            this.leadingLanguagesComboBox.Size = new System.Drawing.Size(474, 33);
            this.leadingLanguagesComboBox.TabIndex = 4;
            this.leadingLanguagesComboBox.ValueMember = "Value";
            // 
            // leadingLanguageLabel
            // 
            this.leadingLanguageLabel.Location = new System.Drawing.Point(12, 107);
            this.leadingLanguageLabel.Name = "leadingLanguageLabel";
            this.leadingLanguageLabel.Size = new System.Drawing.Size(217, 30);
            this.leadingLanguageLabel.TabIndex = 3;
            this.leadingLanguageLabel.Text = "Leading language";
            this.leadingLanguageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(715, 240);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(839, 286);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.leadingLanguageLabel);
            this.Controls.Add(this.leadingLanguagesComboBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.sourcePathTextbox);
            this.Controls.Add(this.sourceDictionaryDirectoryLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sourceDictionaryDirectoryLabel;
        private System.Windows.Forms.TextBox sourcePathTextbox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ComboBox leadingLanguagesComboBox;
        private System.Windows.Forms.Label leadingLanguageLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}