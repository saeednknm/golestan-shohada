<%@ Page Language="C#" AutoEventWireup="true" Inherits="Professor_ReadItem"
    MasterPageFile="~/MasterPages/WebMaster.master" Codebehind="ReadItem.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
    <title><%= Page.Title %></title>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <div class="clear">
    </div>
    <div class="confirmMSG" id="confirmDiv" visible="false" runat="server" style="width: 92%;
        margin: 5px 0 5px 0;">
        <asp:Label ID="lblOk" runat="server"></asp:Label></div>
    <div class="clearFloat">
    </div>
    <div class="errorMSG" id="errorDiv" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label></div>
    <div class="clear">
    </div>
    <div class="SingleItem">
   <!-- <span>تاریخ:
        <asp:Label ID="lbldate" runat="server"></asp:Label>
        &nbsp;-
        <asp:Label ID="lblTime" runat="server"></asp:Label>
    </span>
    <br />
    <span>
        <asp:Label ID="lblPart" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="Label1" runat="server" Text=">"></asp:Label>
        &nbsp;<asp:Label ID="lblGrp" runat="server"></asp:Label>
    </span> -->
    <h3>
        <asp:Label ID="lblTopic" runat="server"></asp:Label></h3>
        </div>
    <asp:Image ID="imgItem" runat="server" Height="150px" Width="220px" CssClass="itemImg" />
    <div id="DivItem" runat="server" class="readBody">
    </div>
    <div class="cleaner">
    </div>
    <div id="DivDownload" class="DnlFile last_row color2" runat="server" visible="false">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/download.png"
            OnClick="ImageButton1_Click" CausesValidation="False" />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="MyLink" OnClick="LinkButton1_Click">دریافت فایل</asp:LinkButton>
    </div>
    <div class="cleaner">
    </div>
    <div id="DivComment" runat="server" visible="false">
        <p class="title">
            ارسال نظر</p>
        <div class="row heigh_30">
            <label class="Rcolumn">
                نام شما:</label>
            <label class="Lcolumn">
                <asp:TextBox ID="txtName" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="لطفا نام خود را وارد نمایید"
                    Font-Size="Smaller" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </label>
        </div>
        <div class="row heigh_30">
            <label class="Rcolumn">
                ایمیل (اختیاری):</label>
            <label class="Lcolumn">
                <asp:TextBox ID="txtMail" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                &nbsp;</label></div>
        <div class="row height_auto">
            <label class="Rcolumn">
                نظر شما:</label>
            <label class="Lcolumn">
                <asp:TextBox ID="txtComment" runat="server" CssClass="Mytxt persian" TextMode="MultiLine"
                    Height="50px" Width="350px" Style="overflow: auto;"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفا نظر خود را وارد نمایید"
                    ControlToValidate="txtComment"></asp:RequiredFieldValidator>
            </label>
        </div>
        <div class="last_row">
            <asp:Button ID="btnSend" runat="server" Text="ارسال" CssClass="Mybtn btnComment"
                OnClick="btnSend_Click" /></div>
    </div>
    <br />
    <br />
    <div id="DivExDiv" runat="server" visible="false">
        <asp:DataList ID="DataList1" runat="server" Width="100%">
            <ItemTemplate>
                <section class="col2">
                    <div class="NameCmt">
                        <asp:Label ID="lblCommentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WrittenBy") %>'></asp:Label>
                    </div>
                    <div class="wrapper">
                        <p class="Div_justify BodyCmt">
                            <asp:Label ID="lblCommentBody" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CmtTxt") %>'></asp:Label>
                        </p>
                        <div class="DateCmt">
                            <asp:Label ID="Label2" runat="server" Text='<%# MyClass.GetFarsiDate(Eval("CmtDate")) %>'></asp:Label>
                            ساعت
                            <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(Eval("CmtDate")).ToString("HH:mm") %>'></asp:Label>
                        </div>
                    </div>
                </section>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
