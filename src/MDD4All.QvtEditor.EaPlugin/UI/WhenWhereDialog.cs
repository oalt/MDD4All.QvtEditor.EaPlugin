using System;
using System.Windows.Forms;


namespace MDD4All.QvtEditor.EaPlugin.UI
{
    /// <summary>
    /// class for the input of when and where
    /// </summary>
    public partial class WhenWhereDialog : Form
    {
        private EA.Repository rep;
        private EA.Package package;
        public string value = "";

        public WhenWhereDialog()
        {
            
            InitializeComponent();
      
        }

        public WhenWhereDialog(EA.Repository rep, EA.Package package)
        {
            this.rep = rep;
            this.package = package;

            InitializeComponent();
       
            whenUserControl.Repository = this.rep;
            whenUserControl.Package = this.package;

            whereUserControl.Repository = rep;
            whereUserControl.Package = package;

            whereUserControl.SetWhenWhereText(false);
       
            whenUserControl.SetWhenConditionForRelationUserControlMethod(rep, package);
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.whenWhereTab.SelectedTab.Name.Equals("When"))
            {
                whenUserControl.SetTaggedValues(true);
            }
            else
            {
                whereUserControl.SetTaggedValues(false);
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void whenWhereTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.whenWhereTab.SelectedTab.Name.Equals("When"))
            {
                whenUserControl.SetWhenWhereText(true);
                whenUserControl.SetWhenConditionForRelationUserControlMethod(rep, package);
            }
            else
            {
                whenUserControl.SetWhenWhereText(false);
                whereUserControl.SetWhenConditionForRelationUserControlMethod(rep, package);
            }
        }

        
    }
}