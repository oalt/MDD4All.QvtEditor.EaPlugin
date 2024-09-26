using MDD4All.EnterpriseArchitect.Manipulations;
using MDD4All.QvtEditor.EaPlugin.DataModels;
using MDD4All.QvtEditor.EaPlugin.Extensions;
using MDD4All.QvtEditor.EaPlugin.UI;
using System;
using System.Collections.Generic;

namespace MDD4All.QvtEditor.EaPlugin
{
    public class QvtEditorAddin
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(QVTEditorAddin));
        
        private ConnectorDescriptor _connectorData = null;
        private QvtTransformationTaggedValues _data;
        private List<EA.Attribute> _attributes = new List<EA.Attribute>();

        private const string MENUNAME = "QVT Editor";
        private const string MENU_SET_WHEN_WHERE = "Set WHEN and WHERE condition for relation";

        #region EA menu handling

        public object EA_GetMenuItems(EA.Repository repository, string location, string menuName)
        {
            switch (menuName)
            {
                case "":
                    return "-&" + MENUNAME;

                case "-&" + MENUNAME:
                    string[] menuItems = { MENU_SET_WHEN_WHERE };
                    return menuItems;
            }
            return "";
        }

        bool IsProjectOpen(EA.Repository repository)
        {
            try
            {
                EA.Collection models = repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EA_GetMenuState(EA.Repository repository, string location, string menuName, string itemName, ref bool isEnabled, ref bool isChecked)
        {
            isEnabled = true;
        }


        public void EA_MenuClick(EA.Repository repository, string location, string menuName, string itemName)
        {
            try
            {
                switch (itemName)
                {
                    case MENU_SET_WHEN_WHERE:
                        {
                            EA.Diagram dia = repository.GetCurrentDiagram();
                            EA.Package package = repository.GetPackageByID((int)dia.PackageID);
                            WhenWhereDialog swd = new WhenWhereDialog(repository, package);
                            swd.ShowDialog();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                //log.Debug(ex.ToString());
            }
        }

        #endregion

        #region EA events
        public bool EA_OnPreNewConnector(EA.Repository repository, EA.EventProperties info)
        {

            _connectorData = new ConnectorDescriptor(info);
            return true;
        }

        /// <summary>
        /// qvtTransformationLink and association
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool EA_OnPostNewConnector(EA.Repository repository, EA.EventProperties info)
        {
            EA.EventProperty prop = info.Get(0);
            EA.Connector connector = repository.GetConnectorByID(int.Parse((string)prop.Value));
            EA.Element clientElement = repository.GetElementByID(connector.ClientID);
            EA.Element supplierElement = repository.GetElementByID(connector.SupplierID);
            EA.Diagram currentdia = repository.GetCurrentDiagram();

            EA.ConnectorEnd AssociationClient = connector.ClientEnd;
            EA.ConnectorEnd AssociationSupplier = connector.SupplierEnd;

            if (CalculateTransformationLinkOrderNumber(currentdia, repository).Equals(1))
            {
                string ConnectorType = connector.Stereotype;

                switch (ConnectorType)
                {
                    case ("qvtTransformationLink"):
                        {
                            if (_connectorData.ClientID.Equals(_connectorData.SupplierID))
                            {
                                return false;
                            }
                            if (!supplierElement.Stereotype.Equals("domain"))
                            {
                                supplierElement.Stereotype = "domain";
                                supplierElement.Update();
                            }
                            _data = new QvtTransformationTaggedValues();
                            EA.Element domainElement = repository.GetElementByID(int.Parse(_connectorData.SupplierID));
                            domainElement.Stereotype = "domain";
                            domainElement.Update();
                            QvtTransformationLinkDialog qvtTransformationLinkDialog = new QvtTransformationLinkDialog(_data, repository);
                            qvtTransformationLinkDialog.ShowDialog();

                            for (int i = 0; i < connector.TaggedValues.Count; i++)
                            {
                                EA.ConnectorTag tag = (EA.ConnectorTag)connector.TaggedValues.GetAt((short)i);
                                if (tag.Name.Equals("CEType"))
                                {
                                    tag.Value = _data.CEType;
                                    tag.Update();
                                }
                                if (tag.Name.Equals("modelName"))
                                {
                                    tag.Value = _data.ModelName;
                                    tag.Update();
                                }
                                if (tag.Name.Equals("metaModelName"))
                                {
                                    tag.Value = _data.MetaName;
                                    tag.Update();
                                }
                            }
                            connector.Name = AddOrder(repository, currentdia).ToString();
                            connector.Update();
                            currentdia.Update();
                            repository.RefreshOpenDiagrams(false);

                        }
                        break;

                    case (""):
                        {
                            if (_connectorData.ClientID.Equals(_connectorData.SupplierID))
                            {
                                return false;
                            }
                            if (clientElement.Type == "Object" && supplierElement.Type == "Object" && connector.Type == "Association")
                            {
                                EA.Element clientMetaClass = repository.GetElementByID(clientElement.ClassifierID);
                                EA.Element supplierMetaClass = repository.GetElementByID(supplierElement.ClassifierID);
                                MetaModelReference EAmodel = new MetaModelReference(repository, clientMetaClass, supplierMetaClass);
                                if (EAmodel.connectorList.Count == 1)
                                {
                                    SetConnectorRoles(EAmodel.connectorList[0], clientMetaClass, connector);
                                }
                                else if (EAmodel.connectorList.Count == 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    AssociationMessageDialog associationMessageDialog = new AssociationMessageDialog(repository, EAmodel.connectorList, connector);
                                    associationMessageDialog.ShowDialog();
                                    if (associationMessageDialog.SelectedConnector != null)
                                    {
                                        SetConnectorRoles(associationMessageDialog.SelectedConnector, clientMetaClass, connector);
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                }
                repository.RefreshOpenDiagrams(true);
                //Repository.ReloadDiagram((int)currentdia.DiagramID);

            }
            return true;
        }

        public bool EA_OnContextItemDoubleClicked(EA.Repository repository, string guid, EA.ObjectType objectType)
        {
            bool result = false;

            EA.Diagram currentdia = repository.GetCurrentDiagram();
            
            if (objectType.ToString().Equals("otElement"))
            {
                EA.Element ClickedElement = repository.GetElementByGuid(guid);
                if (!ClickedElement.ParentID.Equals(0))
                {
                    EA.Element parentele = repository.GetElementByID(ClickedElement.ParentID);
                    if (parentele.Stereotype.Equals("qvtRelation"))
                    {
                        if (ClickedElement.Type.Equals("Object"))
                        {
                            if (CalculateTransformationLinkOrderNumber(currentdia, repository).Equals(1))
                            {
                                //QVTUtils qu = new QVTUtils(Repository);

                                _attributes = new List<EA.Attribute>();
                                EA.Element Classifier;
                                try
                                {
                                    // ClassifierID's only available for instance elements, such as object instances
                                    Classifier = repository.GetElementByID(ClickedElement.ClassifierID);
                                }
                                catch (Exception ex)
                                {
                                    //log.Error(ClickedElement.Name + " is not an instance type. Error: " + ex.Message);
                                    return false;
                                }
                                EA.Diagram diagram = repository.GetCurrentDiagram();
                                EA.Collection objects = diagram.DiagramObjects;

                                /// get existed defined attributes
                                /// 
                                _attributes = Classifier.GetMetaclassAttributeList(repository);

                                /// dialog for new attributes
                                /// 
                                ObjektAttributeDialog OP = new ObjektAttributeDialog(_attributes, ClickedElement, repository);
                                OP.ShowDialog();

                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool EA_OnPreDeleteConnector(EA.Repository repository, EA.EventProperties info)
        {
            EA.EventProperty prop = info.Get(0);
            EA.Connector con = repository.GetConnectorByID(int.Parse((string)prop.Value));
            if (con.Stereotype.Equals("qvtTransformationLink"))
            {
                EA.Diagram currentdia = repository.GetCurrentDiagram();
                if (CalculateTransformationLinkOrderNumber(currentdia, repository).Equals(1))
                {
                    DeleteConnector(con, repository);
                    currentdia.Update();
                    repository.RefreshOpenDiagrams(false);
                }

            }
            return true;
        }

        #endregion

        private void SetConnectorRoles(EA.Connector selectedConnector, EA.Element sourceMetaClass, EA.Connector objectConnector)
        {

            if (selectedConnector.Type == "Aggregation")
            {
                if (sourceMetaClass.ElementID == selectedConnector.SupplierID)
                {
                    objectConnector.ClientEnd.Role = selectedConnector.SupplierEnd.Role;
                    objectConnector.SupplierEnd.Role = selectedConnector.ClientEnd.Role;
                }
                else
                {
                    objectConnector.ClientEnd.Role = selectedConnector.ClientEnd.Role;
                    objectConnector.SupplierEnd.Role = selectedConnector.SupplierEnd.Role;
                }
            }
            else
            {
                if (sourceMetaClass.ElementID == selectedConnector.ClientID)
                {
                    objectConnector.SupplierEnd.Role = selectedConnector.ClientEnd.Role;
                    objectConnector.ClientEnd.Role = selectedConnector.SupplierEnd.Role;
                }
                else
                {
                    objectConnector.ClientEnd.Role = selectedConnector.SupplierEnd.Role;
                    objectConnector.SupplierEnd.Role = selectedConnector.ClientEnd.Role;
                }
            }
            objectConnector.Update();
        }


        /// <summary>
        /// auto add the order of transformationLink
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="diagram"></param>
        /// <returns></returns>
        private int AddOrder(EA.Repository repository, EA.Diagram diagram)
        {
            int j = 0;
            EA.Collection objects = diagram.DiagramObjects;

            for (int i = 0; i < objects.Count; i++)
            {
                EA.DiagramObject diagramObject = (EA.DiagramObject)objects.GetAt((short)i);
                EA.Element element = repository.GetElementByID(diagramObject.ElementID);
                if (element.Stereotype.Equals("qvtTransformationNode"))
                {
                    EA.Collection connectors = element.Connectors;
                    for (int k = 0; k < connectors.Count; k++)
                    {
                        EA.Connector con = (EA.Connector)connectors.GetAt((short)k);
                        if (con.Stereotype.Equals("qvtTransformationLink"))
                        {
                            j++;
                        }
                    }
                }
            }
            return j;
        }

        public bool DeleteConnector(EA.Connector connector, EA.Repository repository)
        {
            if (!connector.Name.Equals(""))
            {
                EA.Diagram dia = repository.GetCurrentDiagram();
                int index = 0;
                index = int.Parse(connector.Name);
                EA.Collection diaobjcts = dia.DiagramObjects;

                for (int i = 0; i < diaobjcts.Count; i++)
                {
                    EA.DiagramObject diagramObject = (EA.DiagramObject)diaobjcts.GetAt((short)i);
                    EA.Element element = repository.GetElementByID(diagramObject.ElementID);
                    if (element.Stereotype.Equals("qvtTransformationNode"))
                    {
                        EA.Collection connectors = element.Connectors;
                        for (short counter = 0; counter < connectors.Count; counter++)
                        {
                            EA.Connector existingConnector = (EA.Connector)connectors.GetAt(counter);
                            if (existingConnector.Stereotype.Equals("qvtTransformationLink"))
                            {

                                int count = int.Parse(existingConnector.Name);

                                if (count >= index)
                                {
                                    count--;
                                    existingConnector.Name = count.ToString();
                                    existingConnector.Update();
                                }
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Set the sequence of the transformationlinks
        /// </summary>
        private int CalculateTransformationLinkOrderNumber(EA.Diagram currentDiagram, EA.Repository repository)
        {
            int symbol = 0;
            EA.Collection elements = currentDiagram.DiagramObjects;
            for (int i = 0; i < elements.Count; i++)
            {
                EA.DiagramObject dobject = (EA.DiagramObject)elements.GetAt((short)i);
                EA.Element element = repository.GetElementByID(dobject.ElementID);
                if (element.Stereotype.Equals("qvtTransformationNode"))
                {
                    symbol = 1;
                    break;
                }
            }
            return symbol;
        }

    }

}

