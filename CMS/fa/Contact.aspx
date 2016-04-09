<%@ Page Language="C#" AutoEventWireup="true" Inherits="Professor_Contact"
    MasterPageFile="~/MasterPages/WebMaster.master" Codebehind="Contact.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
  <title>تماس با ما</title>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="SingleItem">
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
        <div class="first_row color1"> اطلاعات تماس</div>
        <div class="row heigh_30">
        <div class="Rcolumn">
            آدرس:
        </div>
        <div class="Lcolumn">
            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <!-- end of row -->
          <div class="row heigh_30" style="display:none;">
        <div class="Rcolumn">
            شماره تماس:
        </div>
        <div class="Lcolumn">
            <asp:Label ID="lblTel" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <!-- end of row -->
          <div class="row heigh_30">
        <div class="Rcolumn">
            ایمیل:
        </div>
        <div class="Lcolumn">
            <asp:Label ID="lblEmail2" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <!-- end of row -->
        <div class="first_row color1">ارسال پیام</div>
    <div class="row heigh_30">
        <div class="Rcolumn">
            نام شما:
        </div>
        <div class="Lcolumn">
            <asp:TextBox ID="txtName" runat="server" CssClass="Mytxt persian"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtName"></asp:RequiredFieldValidator>
        </div>
    </div>
    <!-- end of row -->
    <div class="row heigh_30">
        <div class="Rcolumn">
            ایمیل شما:
        </div>
        <div class="Lcolumn">
            <asp:TextBox ID="txtMail" runat="server" CssClass="Mytxt persian"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ایمیل خود را صحیح وارد نمایید"
                ControlToValidate="txtMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <!-- end of row -->
      <div class="row heigh_30">
        <div class="Rcolumn">
            موضوع:
        </div>
        <div class="Lcolumn">
            <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                ControlToValidate="txtTopic"></asp:RequiredFieldValidator>
        </div>
    </div>
    <!-- end of row -->
    <div class="row heigh_30">
        <div class="Rcolumn">
            پیغام شما:
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفا پیغام خود را وارد نمایید"
                ControlToValidate="txtBody"></asp:RequiredFieldValidator>
        </div>
        <div class="Lcolumn">
            <asp:TextBox ID="txtBody" runat="server" CssClass="Mytxt persian" Height="200px"
                TextMode="MultiLine" Width="95%"></asp:TextBox>
        </div>
    </div>
    <!-- end of row -->
    <div class="last_row" style="text-align: left;">
        <asp:Button ID="btnClear" runat="server" Text="پاک کن" CssClass="Mybtn" 
            onclick="btnClear_Click" />
        &nbsp;
        <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="Mybtn" 
            onclick="btnSend_Click" />
    </div>
        </div>
</asp:Content>
