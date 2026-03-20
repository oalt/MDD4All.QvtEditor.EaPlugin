using MDD4All.QvtEditor.EaPlugin.DataModels;
using MDD4All.QvtEditor.EaPlugin.ViewModels;
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
        private TransformationLinkViewModel DataContext { get; set; }

        public QvtTransformationLinkDialog(QvtTransformationTaggedValues data, EA.Repository repository, EA.Connector transformationLinkConnector)
        {
            InitializeComponent();

            DataContext = new TransformationLinkViewModel(repository, transformationLinkConnector);

            checkRadioButton.Checked = Enabled;
            _data = data;
            _repository = repository;

            foreach (TypedModelDataModel item in DataContext.TypedModelsOfTransformation)
            {
                metaModelComboBox.Items.Add(item);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _data.MetaName = ((TypedModelDataModel)metaModelComboBox.SelectedItem).MetamodelName;
            _data.ModelName = ((TypedModelDataModel)metaModelComboBox.SelectedItem).Name;
            _data.CEType = (checkRadioButton.Checked ? "checkonly" : "enforce");
            
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }


}