
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanitizeForm));
            closeButton = new System.Windows.Forms.Button();
            ExplanationLabel = new System.Windows.Forms.Label();
            sanitizeButton = new System.Windows.Forms.Button();
            errorsLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            closeButton.Location = new System.Drawing.Point(660, 419);
            closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(149, 45);
            closeButton.TabIndex = 3;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // ExplanationLabel
            // 
            ExplanationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ExplanationLabel.Location = new System.Drawing.Point(16, 12);
            ExplanationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ExplanationLabel.Name = "ExplanationLabel";
            ExplanationLabel.Size = new System.Drawing.Size(793, 196);
            ExplanationLabel.TabIndex = 1;
            ExplanationLabel.Text = resources.GetString("ExplanationLabel.Text");
            // 
            // sanitizeButton
            // 
            sanitizeButton.Location = new System.Drawing.Point(16, 212);
            sanitizeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            sanitizeButton.Name = "sanitizeButton";
            sanitizeButton.Size = new System.Drawing.Size(215, 45);
            sanitizeButton.TabIndex = 2;
            sanitizeButton.Text = "Sanitize";
            sanitizeButton.UseVisualStyleBackColor = true;
            sanitizeButton.Click += sanitizeButton_Click;
            // 
            // errorsLabel
            // 
            errorsLabel.AutoSize = true;
            errorsLabel.Location = new System.Drawing.Point(16, 261);
            errorsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            errorsLabel.Name = "errorsLabel";
            errorsLabel.Size = new System.Drawing.Size(79, 32);
            errorsLabel.TabIndex = 4;
            errorsLabel.Text = "Errors:";
            errorsLabel.Visible = false;
            // 
            // SanitizeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = closeButton;
            ClientSize = new System.Drawing.Size(825, 480);
            Controls.Add(errorsLabel);
            Controls.Add(sanitizeButton);
            Controls.Add(ExplanationLabel);
            Controls.Add(closeButton);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SanitizeForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Sanitize dictionaries";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label ExplanationLabel;
        private System.Windows.Forms.Button sanitizeButton;
        private System.Windows.Forms.Label errorsLabel;
    }
}