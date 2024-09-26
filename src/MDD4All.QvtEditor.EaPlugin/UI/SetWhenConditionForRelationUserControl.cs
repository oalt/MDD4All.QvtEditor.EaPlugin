using MDD4All.QvtEditor.EaPlugin.DataModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MDD4All.QvtEditor.EaPlugin.UI
{
    /// <summary>
    /// dialog for when and where attributes of the Relation
    /// </summary>
    public partial class SetWhenConditionForRelationUserControl : UserControl
    {
        public EA.Repository Repository { get; set; }
        public EA.Package Package { get; set; }

        private string relationName = "";
        //private ArrayList values = new ArrayList();
        private List<object> relations = new List<object>();
        private int flag;                                ///to control the listbox2
        private int index;
        private List<object> paras = new List<object>();
        private EA.Element _relationElement = null;
        private EA.Element _currentRelationElement = null;
        public string relationlist = "";
        public string value = "";
        private List<EA.Element> _qvtRelationElements = new List<EA.Element>();

        public SetWhenConditionForRelationUserControl()
        {
            InitializeComponent();
        }
        
        public void SetWhenConditionForRelationUserControlMethod(EA.Repository repository, EA.Package package)
        {
            Repository = repository;
            Package = package;
            
            upButton.Enabled = false;
            downButton.Enabled = false;
            relationCombo.Items.Clear();
            relationCombo.Text = "";
            relationParameterList.Items.Clear();
            conditionsListBox.Items.Clear();
            parameterValueList.Items.Clear();
            resultTextBox.Text = "";
            relationTextField.Text = "";
            delButton.Enabled = false;

            flag = 0;
            value = "";
            paras = new List<object>();
            //values = new ArrayList();
            relations = new List<object>();
            _qvtRelationElements = new List<EA.Element>();            
            _relationElement = null;
            _currentRelationElement = null;
            

            EA.Diagram currentDiagram = repository.GetCurrentDiagram();
            EA.Collection collections = currentDiagram.DiagramObjects;
            for (int j = 0; j < collections.Count; j++)
            {
                EA.DiagramObject db = (EA.DiagramObject)collections.GetAt((short)j);
                EA.Element ele = repository.GetElementByID((int)db.ElementID);

                if (ele.Stereotype.Equals("qvtRelation"))
                {
                    _currentRelationElement = ele;
                    break;
                }
            }

            EA.Collection elements = package.Elements;
            for (int i = 0; i < elements.Count; i++)
            {
                EA.Element ele = (EA.Element)elements.GetAt((short)i);
                if (ele.Stereotype.Equals("qvtRelation"))
                {
                    _qvtRelationElements.Add(ele);
                }
            }

            foreach (EA.Element element in _qvtRelationElements)
            {
                RelationListModel rlm = new RelationListModel();
                rlm.element = element;
                relationCombo.Items.Add(rlm);

            }
           
            GetInitialTaggedValues(whenLabel.Name.ToString());

        }
       /// <summary>
       /// to get the related domains 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void OnRelationComboSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            //int count = 0;
            relationParameterList.Items.Clear();
            relationTextField.Text = "";

            RelationListModel rlm = (RelationListModel)relationCombo.SelectedItem;
            _relationElement = (EA.Element)rlm.element;
            relationTextField.Text = _relationElement.Name + "()";

            EA.Collection elements = _relationElement.Elements;
            for (int i = 0; i < elements.Count; i++)
            {
                EA.Element ele = (EA.Element)elements.GetAt((short)i);
                if (ele.Stereotype.Equals("qvtTransformationNode"))
                {
                    EA.Collection connectors = ele.Connectors;
                    RelationListModelType[] entries = new RelationListModelType[connectors.Count];
                    for (int j = 0; j < connectors.Count; j++)
                    {
                        EA.Connector con = (EA.Connector)connectors.GetAt((short)j);
                        if (con.Stereotype.Equals("qvtTransformationLink"))
                        {
                                index = int.Parse(con.Name);
                                
                                RelationListModelType rlmt = new RelationListModelType();
                                rlmt.rep = Repository;
                                rlmt.ele = Repository.GetElementByID(con.SupplierID);
                                entries[index-1] = rlmt;
                        }
                    }

                    for (int k = 0; k < connectors.Count; k++)
                    {
                        relationParameterList.Items.Add(entries[k]);   
                    }
                    relationName = _relationElement.Name;
                    break;
                }

            }/// to get the domian in order 
        }

        /// <summary>
        /// show the related parameters to choose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void relationParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int q = 0;
            flag = 0;
            
            parameterValueList.Items.Clear();
            
            RelationListModelType olv = (RelationListModelType)relationParameterList.SelectedItem;
            EA.Element selectedEle = olv.ele;

            string eleclass = Repository.GetElementByID(selectedEle.ClassifierID).Name;

            EA.Diagram currentDiagram = Repository.GetCurrentDiagram();
            EA.Collection collections = currentDiagram.DiagramObjects;
            for (int j = 0; j < collections.Count; j++)
            {
                EA.DiagramObject diagramObject = (EA.DiagramObject)collections.GetAt((short)j);
                EA.Element element = Repository.GetElementByID(diagramObject.ElementID);

                if (element.Type.Equals("Object"))
                {
                    EA.Element eles = Repository.GetElementByID(element.ClassifierID);
                    if (eles.Name.Equals(eleclass))
                    {
                        q = 1;
                        RelationListModel rlm = new RelationListModel();
                        rlm.element = element;
                        parameterValueList.Items.Add(rlm);
                    }
                }
            }
            if (q != 1)
            {
                paras.Add(" ");
            }

        }

        /// <summary>
        /// to choose the parameters and can be only one 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parameterValueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = 0;
            string displayedText = "";

            switch (flag)
            {
                case (1):
                    {
                        if (paras.Count >= 1)
                        {
                            paras.RemoveAt(paras.Count - 1);
                        }
                        paras.Add(parameterValueList.SelectedItem);

                    }
                    break;

                case (0):
                    {
                        paras.Add(parameterValueList.SelectedItem);
                        flag = 1;
                    } break;
            }

            displayedText += relationName + "(";
            foreach (Object m in paras)
            {
                displayedText += m;
                if (!j.Equals(paras.Count - 1))
                {
                    displayedText += ", ";
                }
                j++;
            }
            displayedText += ");";
            relationTextField.Text = displayedText;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            relationTextField.Clear();
            paras.Clear();
            if (relationCombo.Text != "")
            {
                relationTextField.Text = relationCombo.Text + "()";
            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        { 
            relations = new List<object>();
            conditionsListBox.Items.Add(relationTextField.Text);
            foreach (Object m in conditionsListBox.Items)
            {
               relations.Add(m.ToString());
            }

            AddValueInResultTextbox(relations);
            relationTextField.Text = "";
            paras.Clear();
            value = "";
            foreach (object o in relations)
            {
                value += o.ToString() + "\n\r";
            }
            
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (conditionsListBox.SelectedIndex != -1)
            {
                int oIndex = conditionsListBox.SelectedIndex;
                object oItem = conditionsListBox.SelectedItem;
                conditionsListBox.Items.RemoveAt(oIndex);
                oIndex--;
                conditionsListBox.Items.Insert(oIndex, oItem);
                conditionsListBox.Update();
                relations = new List<object>();
                foreach (object o in conditionsListBox.Items)
                {
                    relations.Add(o);
                }
                AddValueInResultTextbox(relations);
            }
            
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (conditionsListBox.SelectedIndex!=-1)
            {
                int oIndex = conditionsListBox.SelectedIndex;
                object oItem = conditionsListBox.SelectedItem;
                conditionsListBox.Items.RemoveAt(oIndex);
                oIndex++;
                conditionsListBox.Items.Insert(oIndex, oItem);
                conditionsListBox.Update();

                relations = new List<object>();

                foreach (object o in conditionsListBox.Items)
                {
                    relations.Add(o);
                }
                AddValueInResultTextbox(relations);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            //values.Remove(conditionsListBox.SelectedItem);
            relations.Remove(conditionsListBox.SelectedItem);
            conditionsListBox.Items.RemoveAt(conditionsListBox.SelectedIndex);
            conditionsListBox.Update();
            resultTextBox.Update();

            relations = new List<object>();

            foreach (object o in conditionsListBox.Items)
            {
                relations.Add(o);
            }
            AddValueInResultTextbox(relations);

             
        }

        /// <summary>
        /// to adjust the right position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conditionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            delButton.Enabled = true;
            index = conditionsListBox.SelectedIndex;
            if (conditionsListBox.Items.Count != 1)
            {
                if (index == 0)
                {
                    upButton.Enabled = false;
                    downButton.Enabled = true;
                }
                else if (index == (relations.Count - 1))
                {
                    upButton.Enabled = true;
                    downButton.Enabled = false;
                }
                else
                {
                    upButton.Enabled = true;
                    downButton.Enabled = true;
                }
            }
            else
            {
                upButton.Enabled = false;
                downButton.Enabled = false;
            }

        }

        public void SetWhenWhereText(bool isWhen)
        {
            if (!isWhen)
            {
                whenLabel.Text = "Where";
                whenCondLabel.Text = "Where Condition";
            }
            else
            {
                whenLabel.Text = "When";
                whenCondLabel.Text = "When Condition";
            }
        }
        
        /// <summary>
        /// to add new values to taggedValues
        /// </summary>
        /// <param name="isWhen"></param>
        public void SetTaggedValues(bool isWhen)
        {   
            
            value = "";
            foreach (object o in relations)
            {
                value += o.ToString()+" " ;
            }
            if (isWhen)
            {
                EA.Collection whenTagvalues = _currentRelationElement.TaggedValues;
                for (int i = 0; i < whenTagvalues.Count; i++)
                {
                    EA.TaggedValue tag = (EA.TaggedValue)whenTagvalues.GetAt((short)i);
                    if (tag.Name.Equals("When"))
                    {
                        if (value.Length < 256)
                        {
                            tag.Value = value;
                            tag.Update();
                        }
                        else if (value.Length >= 256)
                        {
                            tag.Value = value.Substring(0, 250) + "...";
                            tag.Notes = value;
                            tag.Update();
                        }
                        
                    }
                }
                
            }
            else if (!isWhen)
            {
                EA.Collection whereTagvalues = _currentRelationElement.TaggedValues;
                for (int i = 0; i < whereTagvalues.Count; i++)
                {
                    EA.TaggedValue tag = (EA.TaggedValue)whereTagvalues.GetAt((short)i);
                    if (tag.Name.Equals("Where"))
                    {
                        if (value.Length < 256)
                        {
                            tag.Value = value;
                            tag.Notes = value;
                            tag.Update();
                        }
                        else if (value.Length >= 256)
                        {
                            tag.Value = value.Substring(0, 250) + "...";
                            tag.Notes = value;
                            tag.Update();
                        }
                    }
                }
                
            }
        }

        public void GetInitialTaggedValues(string whenLable)
        {
            conditionsListBox.Items.Clear();
            if (whenLabel.Text.Equals("When"))
            {
                AddTagValue(whenLabel.Text);
                
            }
            else if (whenLabel.Text.Equals("Where"))
            {
                AddTagValue(whenLabel.Text);
                
            }
        }

        /// <summary>
        /// method to add Values in editable textbox
        /// </summary>
        /// <param name="values"></param>
        private void AddValueInResultTextbox(List<object> values)
        {
            
            resultTextBox.Text = "";
            foreach (object o in values)
            {
               resultTextBox.Text += o.ToString()+" ";
  
            }
            

        }

        /// <summary>
        /// get initial TaggedValues from the relations
        /// </summary>
        /// <param name="tagName"></param>
        private void AddTagValue(string tagName)
        {
            string[] newvalue;
            EA.Collection taggedValues = _currentRelationElement.TaggedValues;
            foreach (EA.TaggedValue tagValue in taggedValues)
            {
                if (tagValue.Name.Equals(tagName))
                {
                    if (!tagValue.Notes.Equals(""))
                    {
                        newvalue = tagValue.Notes.Split(new char[] { ';' });
                        foreach (string s in newvalue)
                        {
                            if (s.Equals(newvalue[0]))
                            {
                                if (!newvalue[0].Equals(""))
                                {
                                    conditionsListBox.Items.Add(s + ";");
                                    resultTextBox.Text = s + ";" + " ";
                                    relations.Add(s + ";");
                                }
                            }

                            else
                            {
                                if (s.StartsWith(" "))
                                {
                                    if (!s.Equals(" "))
                                    {
                                        conditionsListBox.Items.Add(s.Remove(0, 1) + ";");
                                        resultTextBox.Text += s.Remove(0, 1) + ";" + " ";
                                        relations.Add(s.Remove(0, 1));
                                    }
                                    if (s.Equals(" "))
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    
                                        if (!s.Equals(""))
                                        {
                                            conditionsListBox.Items.Add(s + ";");
                                            resultTextBox.Text += s + ";" + " ";
                                            relations.Add(s + ";");
                                        }
                                    
                                    else if (s.Equals(" "))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        newvalue = tagValue.Value.Split(new char[] { ';' });
                        foreach (string s in newvalue)
                        {
                            if (s.Equals(newvalue[0]))
                            {
                                if (!newvalue[0].Equals(""))
                                {
                                    conditionsListBox.Items.Add(s + ";");
                                    resultTextBox.Text = s + ";" + " ";
                                    relations.Add(s + ";");
                                }
                            }

                            else
                            {
                                if (s.StartsWith(" "))
                                {
                                    if (!s.Equals(" "))
                                    {
                                        conditionsListBox.Items.Add(s.Remove(0, 1) + ";" );
                                        resultTextBox.Text += s.Remove(0, 1) + ";" + " ";
                                        relations.Add(s.Remove(0, 1));
                                    }
                                    if (s.Equals(" "))
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                        if (!s.Equals(""))
                                        {
                                            conditionsListBox.Items.Add(s + ";");
                                            resultTextBox.Text += s + ";" + " ";
                                            relations.Add(s + ";");
                                        }
                                    
                                    else if (s.Equals(""))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }  
        }
    }
}