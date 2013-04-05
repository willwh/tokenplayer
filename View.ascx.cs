/*
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
using System.Security.Cryptography;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.Text;

namespace DotNetNuke.Modules.TokenPlayer
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// The View class displays the content
	/// 
	/// Typically your view control would be used to display content or functionality in your module.
	/// 
	/// View may be the only control you have in your project depending on the complexity of your module
	/// 
	/// Because the control inherits from TokenPlayerModuleBase you have access to any custom properties
	/// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
	/// 
	/// </summary>
	/// -----------------------------------------------------------------------------
	public partial class View : TokenPlayerModuleBase
	{
		// Flowplayer information
		protected String sPRIMARY_DNS		= "";
		protected String sPUB_POINT			= "";
		protected String sSTREAM_NAME		= "";
		protected String sFLOWPLAYER_KEY	= "";
		protected String sQUERY_STRING		= "";

		// Security vars
		protected String sSECRET_CODE		= "";
		protected String sTIME_STAMP		= "";
		protected String sSIGNATURE			= "";

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				PlayerInfo objPlayer = PlayerController.GetSecurePlayer(ModuleId);

				// Player cannot be loaded?  Tell user to set it up! 
				if (objPlayer.isLackingSomething() || objPlayer == null)
				{
					pnlFlowPlayerContainer.Visible = false;
					return;
				}

				// Initialize security vars...
				sSECRET_CODE = objPlayer.SecretCode;
				sTIME_STAMP = time().ToString();
				sSIGNATURE = md5(objPlayer.StreamName + sTIME_STAMP + sSECRET_CODE);

				// Load player information
				sPRIMARY_DNS = objPlayer.PrimaryDNS;
				sPUB_POINT = objPlayer.PublishingPoint;
				sFLOWPLAYER_KEY = objPlayer.FlowplayerKey;
				sSTREAM_NAME = objPlayer.StreamName;
				sQUERY_STRING = "?t=" + sTIME_STAMP + "&s=" + sSIGNATURE;

				pnlFlowPlayerContainer.Visible = true;
				pERROR_MESSAGE.Visible = false;

			}
			catch (Exception exc) //Module failed to load
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}


		// C# equivalent of php time() function
		private long time()
		{
			DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
			TimeSpan span = DateTime.UtcNow.Subtract(unixEpoch);

			return (long)span.TotalSeconds;
		}

		// C# equivalent of php md5(string) function
		public static string md5(string password)
		{
			byte[] textBytes = Encoding.Default.GetBytes(password);
			try
			{
				MD5CryptoServiceProvider cryptHandler;
				cryptHandler = new MD5CryptoServiceProvider();
				byte[] hash = cryptHandler.ComputeHash(textBytes);
				string ret = "";
				foreach (byte a in hash)
				{
					if (a < 16)
						ret += "0" + a.ToString("x");
					else
						ret += a.ToString("x");
				}
				return ret;
			}
			catch
			{
				throw;
			}
		}
	}
}