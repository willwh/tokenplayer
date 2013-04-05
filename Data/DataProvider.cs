/*
' Copyright (c) 2013 DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Data;
using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;


namespace DotNetNuke.Modules.TokenPlayer.Data
{

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// An abstract class for the data access layer
	/// 
	/// The abstract data provider provides the methods that a control data provider (sqldataprovider)
	/// must implement. You'll find two commented out examples in the Abstract methods region below.
	/// </summary>
	/// -----------------------------------------------------------------------------
	public abstract class DataProvider
	{

		#region Shared/Static Methods

		private static DataProvider provider;

		// return the provider
		public static DataProvider Instance()
		{
			if (provider == null)
			{
				const string assembly = "DotNetNuke.Modules.TokenPlayer.Data.SqlDataprovider,TokenPlayer";
				Type objectType = Type.GetType(assembly, true, true);

				provider = (DataProvider)Activator.CreateInstance(objectType);
				DataCache.SetCache(objectType.FullName, provider);
			}

			return provider;
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Not returning class state information")]
		public static IDbConnection GetConnection()
		{
			const string providerType = "data";
			ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);

			Provider objProvider = ((Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);
			string _connectionString;
			if (!String.IsNullOrEmpty(objProvider.Attributes["connectionStringName"]) && !String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]]))
			{
				_connectionString = System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]];
			}
			else
			{
				_connectionString = objProvider.Attributes["connectionString"];
			}

			IDbConnection newConnection = new System.Data.SqlClient.SqlConnection();
			newConnection.ConnectionString = _connectionString.ToString();
			newConnection.Open();
			return newConnection;
		}

		#endregion

		#region Abstract methods

		public abstract IDataReader GetSecurePlayer(int TabModuleId);
		public abstract int AddSecurePlayer(int ModuleId, int TabModuleId, string PrimaryDNS, string PublishingPoint, string StreamName, string SecretCode, string FlowplayerKey);
		public abstract void UpdateSecurePlayer(int ModuleId, int TabModuleId, string PrimaryDNS, string PublishingPoint, string StreamName, string SecretCode, string FlowplayerKey);       


		#endregion

	}

}