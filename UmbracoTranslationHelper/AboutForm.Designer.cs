
namespace UmbracoTranslationHelper
{
    partial class AboutForm
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
            this.versionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.versionContentLabel = new System.Windows.Forms.Label();
            this.repoLabel = new System.Windows.Forms.Label();
            this.repositoryValueLinkLabel = new System.Windows.Forms.LinkLabel();
            this.umbracoRepoLabel = new System.Windows.Forms.Label();
            this.umbracoRepositoryValueLinkLabel = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(3, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(79, 25);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version: ";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(766, 177);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 34);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Controls.Add(this.versionLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.versionContentLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.repoLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.repositoryValueLinkLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.umbracoRepoLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.umbracoRepositoryValueLinkLabel, 1, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(866, 159);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // versionContentLabel
            // 
            this.versionContentLabel.AutoSize = true;
            this.versionContentLabel.Location = new System.Drawing.Point(262, 0);
            this.versionContentLabel.Name = "versionContentLabel";
            this.versionContentLabel.Size = new System.Drawing.Size(0, 25);
            this.versionContentLabel.TabIndex = 1;
            // 
            // repoLabel
            // 
            this.repoLabel.AutoSize = true;
            this.repoLabel.Location = new System.Drawing.Point(3, 53);
            this.repoLabel.Name = "repoLabel";
            this.repoLabel.Size = new System.Drawing.Size(151, 25);
            this.repoLabel.TabIndex = 2;
            this.repoLabel.Text = "Github repository";
            // 
            // repositoryValueLinkLabel
            // 
            this.repositoryValueLinkLabel.AutoSize = true;
            this.repositoryValueLinkLabel.Location = new System.Drawing.Point(262, 53);
            this.repositoryValueLinkLabel.Name = "repositoryValueLinkLabel";
            this.repositoryValueLinkLabel.Size = new System.Drawing.Size(528, 25);
            this.repositoryValueLinkLabel.TabIndex = 3;
            this.repositoryValueLinkLabel.TabStop = true;
            this.repositoryValueLinkLabel.Text = "https://github.com/SteveVaneeckhout/UmbracoTranslationHelper";
            this.repositoryValueLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.repositoryValueLinkLabel_LinkClicked);
            // 
            // umbracoRepoLabel
            // 
            this.umbracoRepoLabel.AutoSize = true;
            this.umbracoRepoLabel.Location = new System.Drawing.Point(3, 106);
            this.umbracoRepoLabel.Name = "umbracoRepoLabel";
            this.umbracoRepoLabel.Size = new System.Drawing.Size(171, 25);
            this.umbracoRepoLabel.TabIndex = 4;
            this.umbracoRepoLabel.Text = "Umbraco repository";
            // 
            // umbracoRepositoryValueLinkLabel
            // 
            this.umbracoRepositoryValueLinkLabel.AutoSize = true;
            this.umbracoRepositoryValueLinkLabel.Location = new System.Drawing.Point(262, 106);
            this.umbracoRepositoryValueLinkLabel.Name = "umbracoRepositoryValueLinkLabel";
            this.umbracoRepositoryValueLinkLabel.Size = new System.Drawing.Size(364, 25);
            this.umbracoRepositoryValueLinkLabel.TabIndex = 5;
            this.umbracoRepositoryValueLinkLabel.TabStop = true;
            this.umbracoRepositoryValueLinkLabel.Text = "https://github.com/umbraco/Umbraco-CMS";
            this.umbracoRepositoryValueLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.umbracoRepositoryValueLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(890, 223);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.closeButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label versionContentLabel;
        private System.Windows.Forms.Label repoLabel;
        private System.Windows.Forms.LinkLabel repositoryValueLinkLabel;
        private System.Windows.Forms.Label umbracoRepoLabel;
        private System.Windows.Forms.LinkLabel umbracoRepositoryValueLinkLabel;
    }
}