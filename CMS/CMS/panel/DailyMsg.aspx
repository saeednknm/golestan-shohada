<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_DailyMsg"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="DailyMsg.aspx.cs" %>

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
            روزنوشت
        </h1>
        <span>نمایش پیام های روزانه به صورت تک جمله ای در صفحه اول پرتال</span><br />
        <span>جهت بهبود نمایش پیام ها و جلوگیری از سردرگمی مخاطبان حداکثر تعداد پیام ها 5 عدد
            می باشد</span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row height_auto">
            <div class="Rcolumn">
                متن پیام:</div>
            <div class="Lcolumn">
                &nbsp;<asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian" Width="75%"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="ثبت" CssClass="Mybtn" Width="50px"
                    OnClick="Button1_Click" />
                <br />
                &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="لطفا پیام خود را وارد نمایید" Font-Size="12px" Font-Underline="False"
                    ForeColor="Red" ControlToValidate="txtTopic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" CssClass="MyGrid" AutoGenerateColumns="False"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="متن پیام" DataField="DMsgtxt" />
                    <asp:TemplateField HeaderText="تاریخ ثبت">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# MyClass.GetFarsiDate(Eval("MsgDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ساعت ثبت">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToDateTime(Eval("MsgDate")).ToString("HH:mm") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ویرایش پیام">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("DailyMsgID").ToString() %>'
                                CommandName="EditC" ImageUrl="../images/Edit.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف پیام">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDel" runat="server" CommandArgument='<%# Eval("DailyMsgID").ToString() %>'
                                CommandName="DelC" ImageUrl="../images/delete.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
