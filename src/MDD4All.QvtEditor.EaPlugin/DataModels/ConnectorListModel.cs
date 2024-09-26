namespace MDD4All.QvtEditor.EaPlugin.DataModels
{
    /// <summary>
    /// method to get the role of the selected connectors
    /// </summary>
    public class ConnectorListModel
    {
        public EA.Connector Connector = null;
        public EA.Element SourceElement = null;

        public ConnectorListModel()
        {
        }

        public ConnectorListModel(EA.Element sourceElement, EA.Connector connector)
        {
            SourceElement = sourceElement;
            Connector = connector;
        }

        public override string ToString()
        {
            string value = "";
            if (Connector.Type == "Aggregation")
            {
                if (Connector.SupplierID == SourceElement.ElementID)
                {
                    value = Connector.SupplierEnd.Role + " --> " + Connector.ClientEnd.Role;
                }
                else
                {
                    value = Connector.ClientEnd.Role + " --> " + Connector.SupplierEnd.Role;
                }
           }
            else
            {
                if (Connector.ClientID == SourceElement.ElementID)
                {
                    value = Connector.ClientEnd.Role + " --> " + Connector.SupplierEnd.Role;
                }
                else
                {
                    value = Connector.SupplierEnd.Role + " --> " + Connector.ClientEnd.Role;
                }
            }
            return value;
        }
    }
}
