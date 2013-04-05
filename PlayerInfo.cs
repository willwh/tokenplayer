using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Modules;

namespace DotNetNuke.Modules.TokenPlayer
{
	public class PlayerInfo : ModuleSettingsBase
	{
		private int _ModuleId;
		private int _TabModuleId;
		private int _PlayerId;
		private String _PrimaryDNS;
		private String _PublishingPoint;
		private String _StreamName;
		private String _FlowplayerKey;
		private String _SecretCode;

		public void New()
		{
		}

		public int PlayerId
		{
			get { return _PlayerId; }
			set { _PlayerId = value; }
		}

		public int ModuleId
		{
			get { return _ModuleId; }
			set { _ModuleId = value; }
		}

		public int TabModuleId
		{
			get { return _TabModuleId; }
			set { _TabModuleId = value; }
		}

		public String PrimaryDNS
		{
			get 
			{
				if (Settings.Contains("PrimaryDNS"))
					return Convert.ToString(Settings["PrimaryDNS"]);
				return null;
			}
			set 
			{
				var mc = new ModuleController();
				mc.UpdateTabModuleSetting(tabModuleId, "PrimaryDNS", value.ToString());
			}
		}

		public String PublishingPoint
		{
			get { return _PublishingPoint; }
			set { _PublishingPoint = value; }
		}

		public String StreamName
		{
			get { return _StreamName; }
			set { _StreamName = value; }
		}

		public String SecretCode
		{
			get { return _SecretCode; }
			set { _SecretCode = value; }
		}

		public String FlowplayerKey
		{
			get { return _FlowplayerKey; }
			set { _FlowplayerKey = value; }
		}

		public bool isLackingSomething()
		{
			if (String.IsNullOrEmpty(PrimaryDNS) || String.IsNullOrEmpty(PublishingPoint) || String.IsNullOrEmpty(StreamName) || String.IsNullOrEmpty(SecretCode))
				return true;
			return false;
		}
	}
}