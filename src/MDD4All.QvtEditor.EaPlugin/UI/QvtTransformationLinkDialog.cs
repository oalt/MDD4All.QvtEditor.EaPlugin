using MDD4All.QvtEditor.EaPlugin.DataModels;
using System;
using System.Windows.Forms;

namespace MDD4All.QvtEditor.EaPlugin.UI
{
    /// <summary>
    /// Dialog for the taggedvalues of transformationlink
    /// </summary>
    public partial class QvtTransformationLinkDialog : Form
    {
        private QvtTransformationTaggedValues _data;
        private EA.Repository _repository;

        public QvtTransformationLinkDialog(QvtTransformationTaggedValues data, EA.Repository repository)
        {
            InitializeComponent();
            checkRadioButton.Checked = Enabled;
            _data = data;
            _repository = repository;

            EA.Collection models = repository.Models;
            for (int modelCounter = 0; modelCounter < models.Count; modelCounter++)
            {
                EA.Package modelsPackage = (EA.Package)models.GetAt((short)modelCounter);
                modelComboBox.Items.Add(modelsPackage.Name.ToString());
                EA.Collection subpackages = modelsPackage.Packages;
                for (int subpackageCounter = 0; subpackageCounter < subpackages.Count; subpackageCounter++)
                {
                    EA.Package subpackage = (EA.Package)subpackages.GetAt((short)subpackageCounter);

                    if (subpackage.Name.Equals("Metamodels"))
                    {
                        EA.Collection submodels = subpackage.Packages;
                        for (int j = 0; j < submodels.Count; j++)
                        {
                            EA.Package subpackage2 = (EA.Package)submodels.GetAt((short)j);
                            metaModelComboBox.Items.Add(subpackage2.Name.ToString());
                        }
                    }
                }
            }

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _data.MetaName = metaModelComboBox.Text;
            _data.ModelName = modelComboBox.Text;
            _data.CEType = (checkRadioButton.Checked ? "checkonly" : "enforce");
            
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }


}