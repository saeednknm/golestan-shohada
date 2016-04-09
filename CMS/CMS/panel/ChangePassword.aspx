<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_ChangePassword"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="ChangePassword.aspx.cs" %>

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
        تغییر کلمه عبور
        </h1>
        <span></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn">
                کلمه عبور فعلی:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="Mytxt" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtCurrentPass"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn">
                کلمه عبور جدید:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtNewPass" runat="server" CssClass="Mytxt" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtNewPass"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn">
                تکرار کلمه عبور جدید:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtNewPass2" runat="server" CssClass="Mytxt" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="تکرار کلمه عبور صحیح نمی باشد"
                    ControlToCompare="txtNewPass" ControlToValidate="txtNewPass2" Font-Bold="False"
                    Font-Italic="False"></asp:CompareValidator>
            </div>
        </div>
        <div class="last_row">
            <asp:Button ID="btnChange" runat="server" Text="ثبت" CssClass="Mybtn" OnClick="btnChange_Click" />
        </div>
    </div>
</asp:Content>
