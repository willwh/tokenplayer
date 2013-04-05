﻿/*
' Copyright (c) 2013  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Modules.TokenPlayer
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// The Settings class manages Module Settings
	/// 
	/// Typically your settings control would be used to manage settings for your module.
	/// There are two types of settings, ModuleSettings, and TabModuleSettings.
	/// 
	/// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
	/// 
	/// TabModuleSettings apply only to the current module on the current page, if you copy that module to
	/// another page the settings are not transferred.
	/// 
	/// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
	/// 
	/// Below we have some examples of how to access these settings but you will need to uncomment to use.
	/// 
	/// Because the control inherits from TokenPlayerSettingsBase you have access to any custom properties
	/// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
	/// </summary>
	/// -----------------------------------------------------------------------------
	public partial class Settings : TokenPlayerModuleSettingsBase
	{
		#region Base Method Implementations

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// LoadSettings loads the settings from the Database and displays them
		/// </summary>
		/// -----------------------------------------------------------------------------
		public override void LoadSettings()
		{
			try
			{
				if (Page.IsPostBack == false)
				{
					//Check for existing settings and use those on this page
					//Settings["SettingName"]


					if (Settings.Contains("FlowplayerKey"))
						FlowplayerKey.Text = Settings["FlowplayerKey"].ToString();

					if (Settings.Contains("SecretCode"))
						SecretCode.Text = Settings["SecretCode"].ToString();

					if (Settings.Contains("PrimaryDNS"))
						PrimaryDNS.Text = Settings["PrimaryDNS"].ToString();

					if (Settings.Contains("PublishingPoint"))
						PublishingPoint.Text = Settings["PublishingPoint"].ToString();

					if (Settings.Contains("StreamName"))
						StreamName.Text = Settings["StreamName"].ToString();

				}
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// UpdateSettings saves the modified settings to the Database
		/// </summary>
		/// -----------------------------------------------------------------------------
		public override void UpdateSettings()
		{
			try
			{
				var modules = new ModuleController();

				modules.UpdateModuleSetting(ModuleId, "FlowplayerKey", FlowplayerKey.Text);
				modules.UpdateModuleSetting(ModuleId, "SecretCode", SecretCode.Text);
				modules.UpdateModuleSetting(ModuleId, "PrimaryDNS", PrimaryDNS.Text);
				modules.UpdateModuleSetting(ModuleId, "PublishingPoint", PublishingPoint.Text);
				modules.UpdateModuleSetting(ModuleId, "StreamName", StreamName.Text);

				modules.UpdateTabModuleSetting(TabModuleId, "FlowplayerKey", FlowplayerKey.Text);
				modules.UpdateTabModuleSetting(TabModuleId, "SecretCode", SecretCode.Text);
				modules.UpdateTabModuleSetting(TabModuleId, "PrimaryDNS", PrimaryDNS.Text);
				modules.UpdateTabModuleSetting(TabModuleId, "PublishingPoint", PublishingPoint.Text);
				modules.UpdateTabModuleSetting(TabModuleId, "StreamName", StreamName.Text);
			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		#endregion
	}
}