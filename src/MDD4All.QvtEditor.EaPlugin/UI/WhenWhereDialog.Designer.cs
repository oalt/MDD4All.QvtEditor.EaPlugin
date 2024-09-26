namespace MDD4All.QvtEditor.EaPlugin.UI
{
    partial class WhenWhereDialog
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
            this.whenWhereTab = new System.Windows.Forms.TabControl();
            this.When = new System.Windows.Forms.TabPage();
            this.whenUserControl = new MDD4All.QvtEditor.EaPlugin.UI.SetWhenConditionForRelationUserControl();
            this.Where = new System.Windows.Forms.TabPage();
            this.whereUserControl = new MDD4All.QvtEditor.EaPlugin.UI.SetWhenConditionForRelationUserControl();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.whenWhereTab.SuspendLayout();
            this.When.SuspendLayout();
            this.Where.SuspendLayout();
            this.SuspendLayout();
            // 
            // whenWhereTab
            // 
            this.whenWhereTab.Controls.Add(this.When);
            this.whenWhereTab.Controls.Add(this.Where);
            this.whenWhereTab.Location = new System.Drawing.Point(12, 12);
            this.whenWhereTab.Name = "whenWhereTab";
            this.whenWhereTab.SelectedIndex = 0;
            this.whenWhereTab.Size = new System.Drawing.Size(452, 604);
            this.whenWhereTab.TabIndex = 0;
            this.whenWhereTab.SelectedIndexChanged += new System.EventHandler(this.whenWhereTab_SelectedIndexChanged);
            // 
            // When
            // 
            this.When.Controls.Add(this.whenUserControl);
            this.When.Location = new System.Drawing.Point(4, 22);
            this.When.Name = "When";
            this.When.Padding = new System.Windows.Forms.Padding(3);
            this.When.Size = new System.Drawing.Size(444, 578);
            this.When.TabIndex = 0;
            this.When.Text = "WHEN";
            this.When.UseVisualStyleBackColor = true;
            // 
            // whenUserControl
            // 
            this.whenUserControl.Location = new System.Drawing.Point(0, 0);
            this.whenUserControl.Name = "whenUserControl";
            this.whenUserControl.Package = null;
            this.whenUserControl.Repository = null;
            this.whenUserControl.Size = new System.Drawing.Size(438, 570);
            this.whenUserControl.TabIndex = 0;
            // 
            // Where
            // 
            this.Where.Controls.Add(this.whereUserControl);
            this.Where.Location = new System.Drawing.Point(4, 22);
            this.Where.Name = "Where";
            this.Where.Padding = new System.Windows.Forms.Padding(3);
            this.Where.Size = new System.Drawing.Size(444, 578);
            this.Where.TabIndex = 1;
            this.Where.Text = "WHERE";
            this.Where.UseVisualStyleBackColor = true;
            // 
            // whereUserControl
            // 
            this.whereUserControl.Location = new System.Drawing.Point(0, 0);
            this.whereUserControl.Name = "whereUserControl";
            this.whereUserControl.Package = null;
            this.whereUserControl.Repository = null;
            this.whereUserControl.Size = new System.Drawing.Size(438, 570);
            this.whereUserControl.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(282, 622);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 26);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(376, 622);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 26);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // WhenWhereDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 657);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.whenWhereTab);
            this.Name = "WhenWhereDialog";
            this.Text = "Set WHEN and WHERE condition";
            this.whenWhereTab.ResumeLayout(false);
            this.When.ResumeLayout(false);
            this.Where.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl whenWhereTab;
        private System.Windows.Forms.TabPage When;
        private System.Windows.Forms.TabPage Where;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private SetWhenConditionForRelationUserControl whenUserControl;
        private SetWhenConditionForRelationUserControl whereUserControl;
    }
}