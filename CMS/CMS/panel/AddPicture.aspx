<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS_panel_AddPicture" MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="AddPicture.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="TitleContentPH">
    <div id="roadmap">
    </div>
    <div class="clear">
    </div>
    <div id="title_bar">
        <h1>
        </h1>
        <span></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn">
                نام آلبوم:</div>
            <div class="Lcolumn">
                <asp:Label ID="lblAlbum" runat="server"></asp:Label>
            </div>
        </div>
        <!-- end of row -->
        <div class="row height_auto">
            <div class="Rcolumn">
                افزودن تصاویر(فرمت jpeg,jpg):</div>
            <div class="Lcolumn">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" ThrobberID="myThrobber" ContextKeys="cntFileUpload"
                            Width="50%" AllowedFileTypes="jpg,jpeg" Height="100%" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="last_row">
        </div>
    </div>
            </asp:Content>
