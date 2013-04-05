<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="DotNetNuke.Modules.TokenPlayer.View" %>
<asp:panel id="pnlFlowPlayerContainer" resourcekey="pnlFlowPlayerContainer" runat="server" visible="False">
    <script type="text/javascript" src="http://player.netromedia.com/flowplayer-3.2.6.min.js"></script> 
	<div id="player<%= this.ModuleId %>" style="display:block;width:540px;height:270px;"></div>
	<script>
	    $f("player<%= this.ModuleId %>", "http://player.netromedia.com/flowplayer.commercial-3.2.7.swf", {
			<%= (String.IsNullOrEmpty(sFLOWPLAYER_KEY)) ? "" : "key: '" + sFLOWPLAYER_KEY + "'," %>
	        clip: {
	            baseUrl: '<%= "rtmp://" + sPRIMARY_DNS + "/" + sPUB_POINT  %>',
		        provider: 'netromedia',
		        url: escape('<%= sSTREAM_NAME + sQUERY_STRING %>'),
			    autoPlay: false
		    },
	        plugins: {
	            netromedia: {
	                url: 'http://player.netromedia.com/flowplayer.rtmp-3.2.3.swf',
	                netConnectionUrl: '<%= "rtmp://" + sPRIMARY_DNS + "/" + sPUB_POINT  %>'
		        }
		    }
	    });
	</script>
	<br />
	<a class="SkinObject" href="<%= "http://" + sPRIMARY_DNS + "/" + sPUB_POINT + "/" + sSTREAM_NAME + "/playlist.m3u8" + sQUERY_STRING %>">iPod/iPhone/iPad link</a> 
	<br />
	<a class="SkinObject" href="<%= "rtsp://" + sPRIMARY_DNS + "/" + sPUB_POINT + "/" + sSTREAM_NAME + sQUERY_STRING %>">Android/Blackberry link</a>
	<br />
	<%-- 
	<!-- For debugging purposes - show module id -->
	Module id: <%= this.ModuleId %> 
	--%>
</asp:panel>

<asp:panel ID="Panel1" runat="server">
	<span id="pERROR_MESSAGE" class="Normal" runat="server">Edit the page, click "Settings" in the menu and enter player config</span>
</asp:panel>