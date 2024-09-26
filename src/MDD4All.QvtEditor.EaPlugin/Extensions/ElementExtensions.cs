using System.Collections.Generic;

namespace MDD4All.QvtEditor.EaPlugin.Extensions
{
    internal static class ElementExtensions
    {
        public static List<EA.Attribute> GetMetaclassAttributeList(this EA.Element metaclass, EA.Repository repository)
        {
            List<EA.Attribute> attrList = new List<EA.Attribute>();

            Dictionary<string, EA.Attribute> attrDict = new Dictionary<string, EA.Attribute>();
            GetMetaclassAttributeListRecursive(ref attrDict, metaclass, repository);

            foreach (KeyValuePair<string, EA.Attribute> kvp in attrDict)
            {
                attrList.Add(kvp.Value);
            }

            return attrList;
        }

        private static void GetMetaclassAttributeListRecursive(ref Dictionary<string, EA.Attribute> attrDict, EA.Element metaclass, EA.Repository repository)
        {
            for (int i = 0; i < metaclass.Attributes.Count; i++)
            {
                EA.Attribute attr = (EA.Attribute)metaclass.Attributes.GetAt((short)i);
                if (attrDict.ContainsKey(attr.Name))
                {
                    return;
                }
                else
                {
                    attrDict.Add(attr.Name, attr);
                }
            }
            // no attribute found, search in generalized classes
            for (short j = 0; j < metaclass.Connectors.Count; j++)
            {
                EA.Connector con = (EA.Connector)metaclass.Connectors.GetAt(j);
                if (con.Type == "Generalization" && con.ClientID == metaclass.ElementID)
                {
                    EA.Element generalizedMC = (EA.Element)repository.GetElementByID(con.SupplierID);
                    GetMetaclassAttributeListRecursive(ref attrDict, generalizedMC, repository);
                }
            }
        }


    }
}
