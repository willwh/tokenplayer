<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Settings.ascx.cs" Inherits="DotNetNuke.Modules.TokenPlayer.Settings" %> 

<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("BasicSettings")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblFlowplayerKey" runat="server" /> 
 
            <asp:TextBox ID="FlowplayerKey" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblSecretCode" runat="server" />
            <asp:TextBox ID="SecretCode" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblPrimaryDNS" runat="server" />
            <asp:TextBox ID="PrimaryDNS" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblPublishingPoint" runat="server" />
            <asp:TextBox ID="PublishingPoint" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblStreamName" runat="server" />
            <asp:TextBox ID="StreamName" runat="server" />
        </div>
    </fieldset>