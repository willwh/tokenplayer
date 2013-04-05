using System;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.Collections.Generic;
using DotNetNuke;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using System.Text;
using DotNetNuke.Modules.TokenPlayer;
using DotNetNuke.Modules.TokenPlayer.Data;

namespace DotNetNuke.Modules.TokenPlayer
{
	public class PlayerController : Entities.Modules.ISearchable, Entities.Modules.IPortable, DotNetNuke.Entities.Modules.IUpgradeable
	{
		static public PlayerInfo GetSecurePlayer(int TabModuleId)
		{
			PlayerInfo colPlayerInfo = new PlayerInfo();
			using (IDataReader dr = DataProvider.Instance().GetSecurePlayer(TabModuleId))
			{
				while (dr.Read())
				{
					colPlayerInfo.ModuleId = Convert.ToInt32(dr["ModuleID"]);
					colPlayerInfo.TabModuleId = Convert.ToInt32(dr["TabModuleID"]);
					colPlayerInfo.PlayerId = Convert.ToInt32(dr["PlayerID"]);
					colPlayerInfo.FlowplayerKey = Convert.ToString(dr["FlowplayerKey"]);
					colPlayerInfo.SecretCode = Convert.ToString(dr["SecretCode"]);
					colPlayerInfo.PrimaryDNS = Convert.ToString(dr["PrimaryDNS"]);
					colPlayerInfo.PublishingPoint = Convert.ToString(dr["PublishingPoint"]);
					colPlayerInfo.StreamName = Convert.ToString(dr["StreamName"]);
				}
			}
			return colPlayerInfo;
		}

		public static int AddSecurePlayer(PlayerInfo objPlayer)
		{
			return ((int)(DataProvider.Instance().AddSecurePlayer(objPlayer.ModuleId, objPlayer.TabModuleId, objPlayer.PrimaryDNS, objPlayer.PublishingPoint, objPlayer.StreamName, objPlayer.SecretCode, objPlayer.FlowplayerKey)));
		}

		public static void UpdateSecurePlayer(PlayerInfo objPlayer)
		{
			DataProvider.Instance().UpdateSecurePlayer(objPlayer.ModuleId, objPlayer.TabModuleId, objPlayer.PrimaryDNS, objPlayer.PublishingPoint, objPlayer.StreamName, objPlayer.SecretCode, objPlayer.FlowplayerKey);
		}

		// Some ferpectly useless placeholders.
		public string UpgradeModule(string Version)
		{
			return "Custom upgrade code goes here for Version: " + Version;
		}

		string DotNetNuke.Entities.Modules.IPortable.ExportModule(int ModuleID)
		{
			return "";
		}

		void DotNetNuke.Entities.Modules.IPortable.ImportModule(int ModuleID, string Content, string Version, int UserID)
		{
			return;
		}

		public SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
		{
			return null;
		}
	}
}