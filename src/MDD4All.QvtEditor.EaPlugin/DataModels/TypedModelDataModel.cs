namespace MDD4All.QvtEditor.EaPlugin.DataModels
{
    internal class TypedModelDataModel
    {
        public string Name { get; set; } = string.Empty;

        public string MetamodelName { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name + " :" + MetamodelName; 
        }
    }


}
