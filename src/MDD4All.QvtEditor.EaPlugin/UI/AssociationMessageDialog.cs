using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using MDD4All.EnterpriseArchitect.Manipulations;
using MDD4All.QvtEditor.EaPlugin.DataModels;


namespace MDD4All.QvtEditor.EaPlugin.UI
{
    /// <summary>
    /// Dialog for the associations of the objects
    /// </summary>
    public partial class AssociationMessageDialog : Form
    {

        public EA.Connector SelectedConnector = null;
        private ArrayList newconlist = new ArrayList();

        public AssociationMessageDialog(EA.Repository repository, List<EA.Connector> connectorList, EA.Connector con)
        {
            //EAControl control = new EAControl(Repository);

            InitializeComponent();

            this.rep = repository;
            EA.Element sourceObject = rep.GetElementByID((int)con.ClientID);
            EA.Element targetObject = rep.GetElementByID((int)con.SupplierID);

            if (connectorList.Count.Equals(1))
            {
                this.Close();
            }
            else
            {
                sourceLabel.Text = "Source = " + sourceObject.Name + ":" + sourceObject.GetClassifierName(repository);
                targetLabel.Text = "Target = " + targetObject.Name + ":" + targetObject.GetClassifierName(repository);

                foreach (EA.Connector connector in connectorList)
                {
                    ConnectorListModel clm = new ConnectorListModel(rep.GetElementByID(sourceObject.ClassfierID), connector);

                    this.relationListBox.Items.Add(clm);
                }
            }
            this.relationListBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ConnectorListModel selection = (ConnectorListModel)this.relationListBox.SelectedItem;
            SelectedConnector = selection.Connector;
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectedConnector = null;
        }
    }

}
