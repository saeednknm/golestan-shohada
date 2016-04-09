<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_ChangeEmail"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="ChangeEmail.aspx.cs" %>

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
        تغییر پست الکترونیک
        </h1>
        <span> ایمیل در بخش ارتباط با ما بیشترین کاربرد را دارد </span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn">
                پست الکترونیک فعلی:
            </div>
            <div class="Lcolumn">
                <asp:Label ID="lblCurrentEmail" runat="server" Font-Italic="False" Font-Size="Small"></asp:Label>
            </div>
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn">
                پست الکترونیک جدید:
            </div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtNewEmail" runat="server" CssClass="Mytxt"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="ایمیل صحیح نمی باشد" ControlToValidate="txtNewEmail" 
                    Font-Italic="False" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="last_row">
            <asp:Button ID="btnChange" runat="server" Text="ثبت" CssClass="Mybtn" 
                onclick="btnChange_Click" />
        </div>
    </div>
</asp:Content>
