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

using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using System.Data;
using DotNetNuke.Data.PetaPoco;
using DotNetNuke.Data;

namespace DotNetNuke.Modules.TokenPlayer.Data
{

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// SQL Server implementation of the abstract DataProvider class
	/// 
	/// This concreted data provider class provides the implementation of the abstract methods 
	/// from data dataprovider.cs
	/// 
	/// In most cases you will only modify the Public methods region below.
	/// </summary>
	/// -----------------------------------------------------------------------------
	public class SqlDataProvider : DataProvider
	{

		#region vars

		private const string moduleQualifier = "";

		#endregion

		#region private methods

		private string GetFullyQualifiedName(string name)
		{
			return moduleQualifier + name;
		}

		#endregion

		#region override methods

		public override IDataReader GetSecurePlayer(int TabModuleId)
		{
			return PetaPocoHelper.ExecuteReader(DotNetNuke.Data.DataProvider.Instance().ConnectionString, CommandType.StoredProcedure, GetFullyQualifiedName("GetSecurePlayer"), TabModuleId);
		}

		public override int AddSecurePlayer(int ModuleId, int TabMobuleId, string PrimaryDNS, string PublishingPoint, string StreamName, string SecretCode, string FlowplayerKey)
		{
			using (var context = DataContext.Instance())
			{
				return context.ExecuteScalar<int>(CommandType.StoredProcedure, GetFullyQualifiedName("AddSecurePlayer"), ModuleId, PrimaryDNS, PublishingPoint, StreamName, SecretCode, FlowplayerKey);
			}
		}

		public override void UpdateSecurePlayer(int ModuleId, int TabMobuleId, string PrimaryDNS, string PublishingPoint, string StreamName, string SecretCode, string FlowplayerKey)
		{
			using (var context = DotNetNuke.Data.DataContext.Instance())
			{
				context.Execute(CommandType.StoredProcedure, GetFullyQualifiedName("UpdateSecurePlayer"), ModuleId, TabMobuleId, PrimaryDNS, PublishingPoint, StreamName, SecretCode, FlowplayerKey);
			}
		}

		#endregion
	}

}