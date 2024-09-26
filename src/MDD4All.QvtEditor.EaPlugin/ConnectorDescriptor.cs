/*
 * 
 * User: ao75da
 * 
 */

using System;

namespace EAAddins.Utils
{
	/// <summary>
	/// Description of ConnectorDescriptor used for QVT, testcase generation and TelematikAddin.
    /// 
    /// $Id: Utils/ConnectorDescriptor.cs 1.4 2012/05/22 15:32:01CEST Alt, Oliver (AltO) planned  $
	/// </summary>
	public class ConnectorDescriptor
	{
		public string Type = "";
		public string Subtype = "";
		public string Stereotype = "";
		public string ClientID = "";
		public string SupplierID = "";
		public string DiagramID = "";
		
		public ConnectorDescriptor(EA.EventProperties preConnectorProps)
		{
			for(int i=0; i < preConnectorProps.Count; i++)
			{
				EA.EventProperty prop = (EA.EventProperty) preConnectorProps.Get(i);
				switch(i)
				{
					case 0:
						this.Type = (string)prop.Value;
					break;
					case 1:
						this.Subtype = (string)prop.Value;
					break;
					case 2:
						this.Stereotype = (string)prop.Value;
					break;
					case 3:
						this.ClientID = (string)prop.Value;
					break;
					case 4:
						this.SupplierID = (string)prop.Value;
					break;
					case 5:
						this.DiagramID = (string)prop.Value;
					break;
				}
				
			}
		}
	}
}
