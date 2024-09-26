using System.Windows.Forms;
using MDD4All.EnterpriseArchitect.Manipulations;

namespace MDD4All.QvtEditor.EaPlugin
{
    class CheckStatus
    {
        public CheckStatus(EA.Repository rep)
        {

            EA.Diagram currentDiagram = rep.GetCurrentDiagram();
            EA.Collection diagramObjects = currentDiagram.DiagramObjects;

            int k = 0;
            for (int i = 0; i < diagramObjects.Count; i++)
            {
                EA.Element element = (EA.Element)diagramObjects.GetAt((short)i);
                if (element.Name.Equals(""))
                {
                    MessageBox.Show("Name can not be null");
                    break;
                }

                string elementName = "";
                elementName = element.GetClassifierName(rep);

                if (element.Stereotype.Equals("Domain"))
                {
                    EA.Collection connectors = element.Connectors;

                    for (int j = 0; j < connectors.Count; j++)
                    {
                        EA.Connector con = (EA.Connector)connectors.GetAt((short)j);

                        if (!con.Stereotype.Equals("qvtTransformationNode"))
                        {
                            break;
                        }
                        EA.Collection tagvalues = con.TaggedValues;
                        for (int m = 0; m < tagvalues.Count; m++)
                        {
                            EA.TaggedValue taggedValue = (EA.TaggedValue)tagvalues.GetAt((short)m);
                            if (taggedValue.Name.Equals("CEType"))
                            {
                                if (taggedValue.Value.Equals("enforceable"))
                                {
                                    k = k + 1;
                                }
                            }
                        }


                    }//for 
                    if (k > 1)
                    {
                        MessageBox.Show("Only one domain can be enforceable");
                        break;
                    }
                }//if
            }

        }
    }
}
