namespace MDD4All.QvtEditor.EaPlugin.UI
{
    partial class ObjektAttributeDialog
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
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.attributeListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.attributeLabel = new System.Windows.Forms.Label();
            this.arrValueLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.attValueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._myDataGrid = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this._myDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(268, 202);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(51, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(271, 481);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(48, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // attributeListBox
            // 
            this.attributeListBox.FormattingEnabled = true;
            this.attributeListBox.Location = new System.Drawing.Point(12, 78);
            this.attributeListBox.Name = "attributeListBox";
            this.attributeListBox.Size = new System.Drawing.Size(307, 108);
            this.attributeListBox.TabIndex = 9;
            this.attributeListBox.SelectedIndexChanged += new System.EventHandler(this.attributeListBox_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(53, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(266, 20);
            this.nameTextBox.TabIndex = 11;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(9, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Name:";
            // 
            // attributeLabel
            // 
            this.attributeLabel.AutoSize = true;
            this.attributeLabel.Location = new System.Drawing.Point(9, 49);
            this.attributeLabel.Name = "attributeLabel";
            this.attributeLabel.Size = new System.Drawing.Size(51, 13);
            this.attributeLabel.TabIndex = 13;
            this.attributeLabel.Text = "Attributes";
            // 
            // arrValueLabel
            // 
            this.arrValueLabel.AutoSize = true;
            this.arrValueLabel.Location = new System.Drawing.Point(12, 207);
            this.arrValueLabel.Name = "arrValueLabel";
            this.arrValueLabel.Size = new System.Drawing.Size(76, 13);
            this.arrValueLabel.TabIndex = 14;
            this.arrValueLabel.Text = "Attribute Value";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(211, 481);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(51, 23);
            this.okButton.TabIndex = 19;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnOkButtonClick);
            // 
            // attValueTextBox
            // 
            this.attValueTextBox.Location = new System.Drawing.Point(105, 204);
            this.attValueTextBox.Name = "attValueTextBox";
            this.attValueTextBox.Size = new System.Drawing.Size(157, 20);
            this.attValueTextBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Attributes";
            // 
            // _myDataGrid
            // 
            this._myDataGrid.CaptionText = "Existing Values ";
            this._myDataGrid.DataMember = "";
            this._myDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._myDataGrid.Location = new System.Drawing.Point(12, 259);
            this._myDataGrid.Name = "_myDataGrid";
            this._myDataGrid.ReadOnly = true;
            this._myDataGrid.Size = new System.Drawing.Size(307, 200);
            this._myDataGrid.TabIndex = 24;
            // 
            // ObjektAttributeDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(328, 516);
            this.ControlBox = false;
            this.Controls.Add(this._myDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attValueTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.arrValueLabel);
            this.Controls.Add(this.attributeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.attributeListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.MaximizeBox = false;
            this.Name = "ObjektAttributeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QVT Object Properties";
            ((System.ComponentModel.ISupportInitialize)(this._myDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox attributeListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label attributeLabel;
        private System.Windows.Forms.Label arrValueLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox attValueTextBox;
        private System.Windows.Forms.Label label1;

    }
}