using GalaSoft.MvvmLight.Command;
using MDD4All.QvtEditor.EaPlugin.DataModels;
using MDD4All.EnterpriseArchitect.Manipulations;
using System.Collections.Generic;
using System.Windows.Input;
using EAAPI = EA;

namespace MDD4All.QvtEditor.EaPlugin.ViewModels
{
    internal class TransformationLinkViewModel
    {
        public TransformationLinkViewModel(EAAPI.Repository repository, EAAPI.Connector transformationLinkConnector)
        {
            Repository = repository;
            TransformationLinkConnector = transformationLinkConnector;
        }

        private void InitializeCommands()
        {
            ConfirmDialogCommand = new RelayCommand(ExecuteConfirmDialog);
        }

        

        public EAAPI.Repository Repository { get; set; }

        public EAAPI.Connector TransformationLinkConnector { get; set; }

        public EAAPI.Element TransformationNode
        {
            get
            {
                EAAPI.Element result = null;

                EAAPI.Element sourceElement = Repository.GetElementByID(TransformationLinkConnector.ClientID);

                if (sourceElement != null)
                {
                    if(sourceElement.Stereotype == "qvtTransformationNode")
                    {
                        result = sourceElement;
                    }
                }

                return result;
            }
        }

        public EAAPI.Element Relation
        {
            get
            {
                EAAPI.Element result = null;

                EAAPI.Element transformationNode = TransformationNode;

                if (transformationNode != null)
                {
                    EAAPI.Element parent = Repository.GetElementByID(transformationNode.ParentID);

                    if (parent != null && parent.Stereotype == "qvtRelation")
                    {
                        result = parent;
                    }
                }

                return result;
            }
        }

        public EAAPI.Element Transformation
        {
            get
            {
                EAAPI.Element result = null;

                EAAPI.Element transformationNode = TransformationNode;

                if (transformationNode != null)
                {
                    EAAPI.Element parent = Repository.GetElementByID(transformationNode.ParentID);

                    if (parent != null && parent.Stereotype == "qvtRelation")
                    {
                        EAAPI.Element transformation = Repository.GetElementByID(parent.ParentID);

                        if (transformation != null)
                        {
                            result = transformation;
                        }
                    }
                }

                return result;
            }
        }

        public List<TypedModelDataModel> TypedModelsOfTransformation
        {
            get
            {
                List<TypedModelDataModel> result = new List<TypedModelDataModel>();
                
                EAAPI.Element transformation = Transformation;
                
                if(transformation != null)
                {
                    for (short counter = 0; counter < transformation.Connectors.Count; counter++)
                    {
                        EAAPI.Connector connector = (EAAPI.Connector) transformation.Connectors.GetAt(counter);
                        if(connector != null && connector.Stereotype == "metamodelRelation")
                        {
                            string name = connector.GetTaggedValueString("name");
                            string metaModelName = "";

                            EAAPI.Element packageTarget = Repository.GetElementByID(connector.SupplierID);

                            if(packageTarget != null && packageTarget.Type == "Package")
                            {
                                EAAPI.Package package = Repository.GetPackageByGuid(packageTarget.ElementGUID);

                                metaModelName = package.GetNamespace(Repository);
                            }

                            TypedModelDataModel typedModelDataModel = new TypedModelDataModel()
                            {
                                Name = name,
                                MetamodelName = metaModelName
                            };
                            result.Add(typedModelDataModel);

                        }
                    }
                }

                return result;
            }
        }

        public ICommand ConfirmDialogCommand { get; private set; }

        public ICommand CancelDialogCommand { get; private set; }

        private void ExecuteConfirmDialog()
        {
            
        }
    }
}
