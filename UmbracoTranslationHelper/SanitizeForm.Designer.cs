
namespace UmbracoTranslationHelper
{
    partial class SanitizeForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.ExplanationLabel = new System.Windows.Forms.Label();
            this.sanitizeButton = new System.Windows.Forms.Button();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(495, 314);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 34);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ExplanationLabel
            // 
            this.ExplanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExplanationLabel.Location = new System.Drawing.Point(12, 9);
            this.ExplanationLabel.Name = "ExplanationLabel";
            this.ExplanationLabel.Size = new System.Drawing.Size(595, 127);
            this.ExplanationLabel.TabIndex = 1;
            this.ExplanationLabel.Text = "Sanitizing the dictionary files will:\r\n- Format the XML,\r\n- Use UTF-8 (no BOM)\r\n-" +
    " Remove duplicate translations,\r\n- Remove translations that don\'t exist in the l" +
    "eading dictionary (en-us).";
            // 
            // sanitizeButton
            // 
            this.sanitizeButton.Location = new System.Drawing.Point(12, 159);
            this.sanitizeButton.Name = "sanitizeButton";
            this.sanitizeButton.Size = new System.Drawing.Size(161, 34);
            this.sanitizeButton.TabIndex = 2;
            this.sanitizeButton.Text = "Sanitize";
            this.sanitizeButton.UseVisualStyleBackColor = true;
            this.sanitizeButton.Click += new System.EventHandler(this.sanitizeButton_Click);
            // 
            // errorsLabel
            // 
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.Location = new System.Drawing.Point(12, 205);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(62, 25);
            this.errorsLabel.TabIndex = 4;
            this.errorsLabel.Text = "Errors:";
            this.errorsLabel.Visible = false;
            // 
            // SanitizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(619, 360);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.sanitizeButton);
            this.Controls.Add(this.ExplanationLabel);
            this.Controls.Add(this.closeButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SanitizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sanitize dictionaries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label ExplanationLabel;
        private System.Windows.Forms.Button sanitizeButton;
        private System.Windows.Forms.Label errorsLabel;
    }
}