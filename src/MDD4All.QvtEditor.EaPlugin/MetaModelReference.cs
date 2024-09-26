using System.Collections.Generic;

namespace MDD4All.QvtEditor.EaPlugin
{
    /// <summary>
    /// Method of getting the relations of the elements in MetaModels
    /// </summary>
    class MetaModelReference
    {
        public EA.Connector Connector = null;
        public List<EA.Connector> connectorList = new List<EA.Connector>();

        public MetaModelReference(EA.Repository repository, EA.Element clientMetaClass, EA.Element supplierMetaClass)
        {   
            EA.Package MetaClassPackage = repository.GetPackageByID((int)clientMetaClass.PackageID);

            EA.Collection MetaClassConnectors = clientMetaClass.Connectors;

            for (int j = 0; j < clientMetaClass.Connectors.Count; j++)
            {
                    EA.Connector MetaClassConnector = (EA.Connector)clientMetaClass.Connectors.GetAt((short)j);

                    EA.Element supplierElement = repository.GetElementByID(MetaClassConnector.SupplierID);
                    EA.Element clientElement = repository.GetElementByID(MetaClassConnector.ClientID);
                
                    if ((clientElement.ElementID == clientMetaClass.ElementID && supplierElement.ElementID == supplierMetaClass.ElementID) ||
                        (supplierElement.ElementID == clientMetaClass.ElementID && clientElement.ElementID == supplierMetaClass.ElementID)
                        )
                    {
                        connectorList.Add(MetaClassConnector);
                    }
            }
           
         }

    }

}
