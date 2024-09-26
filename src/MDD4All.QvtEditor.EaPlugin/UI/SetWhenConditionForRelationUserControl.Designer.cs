namespace MDD4All.QvtEditor.EaPlugin.UI
{
    partial class SetWhenConditionForRelationUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.relationCombo = new System.Windows.Forms.ComboBox();
            this.relationParameterList = new System.Windows.Forms.ListBox();
            this.parameterValueList = new System.Windows.Forms.ListBox();
            this.whenLabel = new System.Windows.Forms.Label();
            this.relationTextField = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.conditionsListBox = new System.Windows.Forms.ListBox();
            this.whenCondLabel = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Relation Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parameter Values";
            // 
            // relationCombo
            // 
            this.relationCombo.FormattingEnabled = true;
            this.relationCombo.Location = new System.Drawing.Point(14, 24);
            this.relationCombo.Name = "relationCombo";
            this.relationCombo.Size = new System.Drawing.Size(408, 21);
            this.relationCombo.TabIndex = 3;
            this.relationCombo.SelectedIndexChanged += new System.EventHandler(this.OnRelationComboSelectedIndexChanged);
            // 
            // relationParameterList
            // 
            this.relationParameterList.FormattingEnabled = true;
            this.relationParameterList.Location = new System.Drawing.Point(15, 89);
            this.relationParameterList.Name = "relationParameterList";
            this.relationParameterList.Size = new System.Drawing.Size(206, 108);
            this.relationParameterList.TabIndex = 4;
            this.relationParameterList.SelectedIndexChanged += new System.EventHandler(this.relationParameterList_SelectedIndexChanged);
            // 
            // parameterValueList
            // 
            this.parameterValueList.FormattingEnabled = true;
            this.parameterValueList.Location = new System.Drawing.Point(242, 89);
            this.parameterValueList.Name = "parameterValueList";
            this.parameterValueList.Size = new System.Drawing.Size(181, 108);
            this.parameterValueList.TabIndex = 5;
            this.parameterValueList.SelectedIndexChanged += new System.EventHandler(this.parameterValueList_SelectedIndexChanged);
            // 
            // whenLabel
            // 
            this.whenLabel.AutoSize = true;
            this.whenLabel.Location = new System.Drawing.Point(11, 210);
            this.whenLabel.Name = "whenLabel";
            this.whenLabel.Size = new System.Drawing.Size(36, 13);
            this.whenLabel.TabIndex = 6;
            this.whenLabel.Text = "When";
            // 
            // relationTextField
            // 
            this.relationTextField.Location = new System.Drawing.Point(15, 226);
            this.relationTextField.Name = "relationTextField";
            this.relationTextField.Size = new System.Drawing.Size(408, 20);
            this.relationTextField.TabIndex = 10;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(242, 264);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(67, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(356, 264);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(67, 23);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // conditionsListBox
            // 
            this.conditionsListBox.FormattingEnabled = true;
            this.conditionsListBox.Location = new System.Drawing.Point(15, 312);
            this.conditionsListBox.Name = "conditionsListBox";
            this.conditionsListBox.Size = new System.Drawing.Size(343, 121);
            this.conditionsListBox.TabIndex = 14;
            this.conditionsListBox.SelectedIndexChanged += new System.EventHandler(this.conditionsListBox_SelectedIndexChanged);
            // 
            // whenCondLabel
            // 
            this.whenCondLabel.AutoSize = true;
            this.whenCondLabel.Location = new System.Drawing.Point(12, 286);
            this.whenCondLabel.Name = "whenCondLabel";
            this.whenCondLabel.Size = new System.Drawing.Size(56, 13);
            this.whenCondLabel.TabIndex = 15;
            this.whenCondLabel.Text = "Conditions";
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(373, 312);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(50, 23);
            this.upButton.TabIndex = 16;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(373, 410);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(50, 23);
            this.downButton.TabIndex = 17;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(15, 465);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(408, 87);
            this.resultTextBox.TabIndex = 20;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(373, 363);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(50, 23);
            this.delButton.TabIndex = 21;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // SetWhenConditionForRelationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.whenCondLabel);
            this.Controls.Add(this.conditionsListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.relationTextField);
            this.Controls.Add(this.whenLabel);
            this.Controls.Add(this.parameterValueList);
            this.Controls.Add(this.relationParameterList);
            this.Controls.Add(this.relationCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetWhenConditionForRelationUserControl";
            this.Size = new System.Drawing.Size(438, 570);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox relationCombo;
        private System.Windows.Forms.ListBox relationParameterList;
        private System.Windows.Forms.ListBox parameterValueList;
        private System.Windows.Forms.Label whenLabel;
        private System.Windows.Forms.TextBox relationTextField;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox conditionsListBox;
        private System.Windows.Forms.Label whenCondLabel;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button delButton;
    }
}