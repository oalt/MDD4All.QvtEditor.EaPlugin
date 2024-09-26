namespace MDD4All.QvtEditor.EaPlugin.DataModels
{
    /// <summary>
    /// method of getting the name of the selected element
    /// </summary>
    public class RelationListModel
    {
        public EA.Element element = null;
        public EA.Repository repository;
        
        public override string ToString()
        {
            string values = "";
            values = element.Name;
            return values;
        }
    }
}
