<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_ChangeUsername"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="ChangeUsername.aspx.cs" %>

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
            تغییر شناسه کاربری
        </h1>
        <span></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn">
                شناسه کاربری فعلی:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtCurrentUser" runat="server" CssClass="Mytxt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtCurrentUser"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn">
                شناسه کاربری جدید:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtNewUser" runat="server" CssClass="Mytxt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtNewUser"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="last_row">
            <asp:Button ID="btnChange" runat="server" Text="ثبت" CssClass="Mybtn" 
                onclick="btnChange_Click" />
        </div>
    </div>
</asp:Content>
