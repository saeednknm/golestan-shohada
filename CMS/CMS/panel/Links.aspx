<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/masterpages/MgrMaster.master" AutoEventWireup="true" Inherits="aspx_Links" Codebehind="Links.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="TitleContentPH">
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
    <div class="confirmMSG" id="confirmDiv" visible="false" runat="server">
        <asp:Label ID="lblOk" runat="server"></asp:Label></div>
    <div class="clearFloat">
    </div>
    <div class="errorMSG" id="errorDiv" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label></div>
    <div class="clear">
    </div>
    <div id="main_content">
        <label class="row height_auto">
            <div class="Rcolumn">
                عنوان سایت:</div>
            <div class="Lcolumn">
                &nbsp;<asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                <br />
                &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="لطفا عنوان سایت را وارد نمایید" Font-Size="12px" Font-Underline="False"
                    ForeColor="Red" ControlToValidate="txtTopic"></asp:RequiredFieldValidator>
        </label>
    </div>
    <label class="row height_auto">
        <div class="Rcolumn">
            آدرس سایت:</div>
        <div class="Lcolumn">
            &nbsp;<asp:TextBox ID="txtAddress" runat="server" CssClass="Mytxt persian"></asp:TextBox>
            &nbsp;<asp:Label ID="Label2" runat="server" Text=".www" Font-Bold="False" Font-Italic="False"
                Font-Size="Small"></asp:Label>
            <br />
            &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="لطفا آدرس سایت را وارد نمایید" Font-Size="12px" Font-Underline="False"
                ForeColor="Red" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
        </div>
    </label>
    <!-- end of row -->
    <div class="clear">
    </div>
    <div class="last_row">
        <asp:Button ID="Button1" runat="server" Text="ثبت" CssClass="Mybtn" Width="50px"
            OnClick="Button1_Click" />
    </div>
    <div class="clear">
    </div>
    <div class="row">
        <asp:GridView ID="GridView1" runat="server" CssClass="MyGrid" AutoGenerateColumns="False"
            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="عنوان سایت" DataField="LinkTitle" />
                <asp:TemplateField HeaderText=" آدرس ">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "http://"+ Eval("LinkURL") %>'
                            Text='<%# Eval("LinkURL") %>'> </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ویرایش">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("LinkID").ToString() %>'
                            CommandName="EditC" ImageUrl="../images/Edit.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="حذف">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDel" runat="server" CommandArgument='<%# Eval("LinkID").ToString() %>'
                            CommandName="DelC" ImageUrl="../images/delete.png" CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </div>
</asp:Content>
