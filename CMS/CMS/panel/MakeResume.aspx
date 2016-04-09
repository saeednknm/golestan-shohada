<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_MakeResume"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="MakeResume.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="TitleContentPH">
    <div id="roadmap">
    </div>
    <div class="clear">
    </div>
    <div class="confirmMSG" id="confirmDiv" visible="false" runat="server">
        <asp:Label ID="lblOk" runat="server"></asp:Label></div>
    <div class="clearFloat">
    </div>
    <div class="errorMSG" id="errorDiv" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label></div>
    <div class="clear">
    </div>
    <div id="title_bar">
        <h1>
            درباره ما
        </h1>
        <span>معرفی سوابق، فعالیت ها، محصولات و خدمات</span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn">
                عنوان:</div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"></asp:TextBox>
            </div>
        </div>
        <!-- end of row -->
        <div class="row height_auto" id="DivPhoto" runat="server" visible="false">
            <div class="Rcolumn">
                تصویر فعلی :</div>
            <div class="Lcolumn">
                <asp:Image ID="Image1" runat="server" Height="175px" Width="150px" />
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row height_auto">
            <div class="Rcolumn">
                <asp:Label ID="lblPhoto" runat="server" Text="تصویر :" Font-Size="12px"></asp:Label></div>
            <div class="Lcolumn">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
                <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row height_auto">
            <div class="Rcolumn">
                خلاصه رزومه:</div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtSummary" runat="server" CssClass="Mytxt persian" Height="150px"
                    TextMode="MultiLine" Width="70%" Style="overflow: auto;"></asp:TextBox>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row heigh_30" id="DivFile" runat="server" visible="false">
            <div class="Rcolumn">
                فایل فعلی رزومه:</div>
            <div class="Lcolumn">
                <asp:LinkButton ID="lnkbtnFile" runat="server" OnClick="lnkbtnFile_Click" Style="direction: ltr"></asp:LinkButton>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row height_auto">
            <div class="Rcolumn">
                <asp:Label ID="lblFile" runat="server" Text="فایل رزومه:" Font-Size="12px"></asp:Label></div>
            <div class="Lcolumn">
                <asp:AsyncFileUpload ID="AsyncFileUpload2" runat="server" />
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="last_row color3">
            <asp:Button ID="btnSubmit" runat="server" Text="ثبت رزومه" CssClass="Mybtn" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
