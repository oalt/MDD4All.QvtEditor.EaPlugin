namespace MDD4All.QvtEditor.EaPlugin.DataModels
{
    /// <summary>
    /// method of getting the classifier element of the selected element
    /// </summary>
    public class RelationListModelType
    {
        public EA.Element ele = null;
        public EA.Repository rep;

        public override string ToString()
        {
            string values = "";
            values = this.ele.Name +" : "+ this.rep.GetElementByID((int)ele.ClassifierID).Name;
            return values;
        }
    }
}