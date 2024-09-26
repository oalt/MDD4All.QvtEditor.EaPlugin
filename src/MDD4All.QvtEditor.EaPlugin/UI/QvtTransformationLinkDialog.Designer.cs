namespace MDD4All.QvtEditor.EaPlugin.UI
{
    partial class QvtTransformationLinkDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.checkRadioButton = new System.Windows.Forms.RadioButton();
            this.enforceRadioButton = new System.Windows.Forms.RadioButton();
            this.metaModelComboBox = new System.Windows.Forms.ComboBox();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please choose the Metamodel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Please choose the Model";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(15, 183);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(53, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(106, 183);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // checkRadioButton
            // 
            this.checkRadioButton.AutoSize = true;
            this.checkRadioButton.Location = new System.Drawing.Point(15, 147);
            this.checkRadioButton.Name = "checkRadioButton";
            this.checkRadioButton.Size = new System.Drawing.Size(74, 17);
            this.checkRadioButton.TabIndex = 9;
            this.checkRadioButton.TabStop = true;
            this.checkRadioButton.Text = "checkonly";
            this.checkRadioButton.UseVisualStyleBackColor = true;
            // 
            // enforceRadioButton
            // 
            this.enforceRadioButton.AutoSize = true;
            this.enforceRadioButton.Location = new System.Drawing.Point(106, 147);
            this.enforceRadioButton.Name = "enforceRadioButton";
            this.enforceRadioButton.Size = new System.Drawing.Size(61, 17);
            this.enforceRadioButton.TabIndex = 10;
            this.enforceRadioButton.TabStop = true;
            this.enforceRadioButton.Text = "enforce";
            this.enforceRadioButton.UseVisualStyleBackColor = true;
            // 
            // metaModelComboBox
            // 
            this.metaModelComboBox.FormattingEnabled = true;
            this.metaModelComboBox.Location = new System.Drawing.Point(15, 39);
            this.metaModelComboBox.Name = "metaModelComboBox";
            this.metaModelComboBox.Size = new System.Drawing.Size(147, 21);
            this.metaModelComboBox.TabIndex = 11;
            // 
            // modelComboBox
            // 
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(15, 109);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(147, 21);
            this.modelComboBox.TabIndex = 12;
            // 
            // QvtTransformationLinkDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 232);
            this.ControlBox = false;
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.metaModelComboBox);
            this.Controls.Add(this.enforceRadioButton);
            this.Controls.Add(this.checkRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "QvtTransformationLinkDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QVT Relation Link";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton checkRadioButton;
        private System.Windows.Forms.RadioButton enforceRadioButton;
        private System.Windows.Forms.ComboBox metaModelComboBox;
        private System.Windows.Forms.ComboBox modelComboBox;
    }
}