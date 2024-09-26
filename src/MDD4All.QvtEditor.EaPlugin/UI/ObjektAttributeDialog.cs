using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using MDD4All.EnterpriseArchitect.Manipulations;

namespace MDD4All.QvtEditor.EaPlugin.UI
{
    /// <summary>
    /// Dialog of the input of the attributes for the object
    /// </summary>
    public partial class ObjektAttributeDialog : Form
    {
        private string _newValue = "";
        private string _newName = "";
        private string _newPara = "";
        private EA.Element _element;
        private EA.Repository repository;
        private DataGrid _myDataGrid;
        private DataSet _attributeDateSet;

        
        public ObjektAttributeDialog(List<EA.Attribute> attributes, EA.Element element, EA.Repository rep)
        {
            InitializeComponent();

            _element = element;
            repository = rep;

            nameTextBox.Text = element.Name.ToString();
            _newName = element.Name.ToString();

            /// to get the existed values in the tagged values
            /// 

            List<ObjectRunState> objectRunStates = element.GetObjectRunStates();

            /// show all the definede attributes in reference Model
            /// 
            foreach (EA.Attribute attr in attributes)
            {
                this.attributeListBox.Items.Add(attr.Name);
            }

            /// relate existed values in the table form
            /// 
            MakeDataSet(objectRunStates);
            _myDataGrid.SetDataBinding(_attributeDateSet, "attValues");

        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            _newPara = "";
            _newValue = "";
            Close();
        }

        /// input the new values for attributes and feed back to QVTEditorAddin.cs 
        /// meanwhile show the new value in the datagrid
        ///

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            _newPara = attributeListBox.Text;
            _newValue = attValueTextBox.Text;

            _element.SetRunStateValue(_newPara, _newValue, "=");

            MakeDataSet(_element.GetObjectRunStates());
            _myDataGrid.Update();
            _myDataGrid.SetDataBinding(_attributeDateSet, "attValues");
        }

        ///
        /// to search the existed value for attributes
        ///         

        private void attributeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string attrName = attributeListBox.Text;

            ObjectRunState objectRunState = _element.GetRunStateByName(attrName);

            if(objectRunState != null)
            {
                attValueTextBox.Text = objectRunState.Value;
            }
            else
            {
                attValueTextBox.Text = "";
            }

            
        }

        ///
        /// check the unique of the name 
        /// 
        private void OnOkButtonClick(object sender, EventArgs e)
        {
            string newname = nameTextBox.Text;

            if (!newname.Equals(""))
            {
                if (!newname.Equals(_element.Name))
                {
                    /*
                    for (int q = 0; q < objects.Count; q++)
                    {
                        EA.DiagramObject objindia = (EA.DiagramObject)objects.GetAt((short)q);
                        EA.Element eleindia = rep.GetElementByID((int)objindia.ElementID);
                        if (eleindia.Name.Equals(newname))
                        {
                            t = t + 1;
                            if (t > 0)
                            {
                                MessageBox.Show("Dieser Name ist schon vorhanden");
                                break;
                            }
                        }
                    }
                     */

                    _element.Name = newname;
                    _element.Update();

                }
            }
            Close();
        }

        ///
        /// DataSet bind with dataGrid
        /// 

        private void MakeDataSet(List<ObjectRunState> runStates)
        {
            // initial DataGrid 
            _attributeDateSet = new DataSet("attDataSet");
            DataTable tAtt = new DataTable("attValues");
            DataColumn cName = new DataColumn("Name", typeof(string));
            DataColumn cValue = new DataColumn("Value", typeof(string));
            tAtt.Columns.Add(cName);
            tAtt.Columns.Add(cValue);
            _attributeDateSet.Tables.Add(tAtt);

            _myDataGrid.TableStyles.Clear();
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = "attValues";
            DataGridColumnStyle csName = new DataGridTextBoxColumn();
            csName.HeaderText = "Attribute";
            csName.MappingName = "Name";
            csName.Width = 135;
            DataGridColumnStyle csValue = new DataGridTextBoxColumn();
            csValue.HeaderText = "Value";
            csValue.MappingName = "Value";
            csValue.Width = 135;
            ts.GridColumnStyles.Add(csName);
            ts.GridColumnStyles.Add(csValue);
            _myDataGrid.TableStyles.Add(ts);

            // add datas to dataset
            foreach (ObjectRunState rs in runStates)
            {
                object[] data = new object[2];
                data[0] = rs.Name;
                data[1] = rs.Value;

                DataRow row = tAtt.Rows.Add(data);


            }


        }




    }
}