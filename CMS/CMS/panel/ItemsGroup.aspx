<%@ Page Language="C#" AutoEventWireup="true" Inherits="panel_ItemsGroup" MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="ItemsGroup.aspx.cs" %>

<script runat="server">

    protected void drpPart_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrv();
    }
</script>


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
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        <span>
            <asp:Label ID="lblSpanTitle" runat="server"></asp:Label></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
           <div class="row heigh_30" id="partDiv" runat="server">
            <div class="Rcolumn">
                بخش:</div>
            <div class="Lcolumn">
                <asp:DropDownList ID="drpPart" runat="server" CssClass="Mydrp persian" OnSelectedIndexChanged="drpPart_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn">
                عنوان گروه اصلی:</div>
            <div class="Lcolumn">
                <asp:Label ID="lblFather" runat="server" ></asp:Label>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn">
                عنوان زیر گروه:</div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTopic"
                    ErrorMessage="* لطفا عنوان گروه را وارد نمایید" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn">
                وضعیت گروه:</div>
            <div class="Lcolumn">
                <asp:DropDownList ID="drpStat" runat="server" CssClass="Mydrp persian">
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="last_row">
            <asp:Button ID="btnOk" runat="server" Text="ثبت" CssClass="Mybtn" OnClick="btnOk_Click" />
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="MyGrid"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="عنوان گروه" DataField="GrpName" />
                    <asp:BoundField DataField="PartName" HeaderText="بخش" />
                    <asp:BoundField HeaderText="وضعیت" DataField="StatName" />
                    <asp:TemplateField HeaderText="ویرایش">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("GrpID").ToString() %>'
                                CommandName="EditC" ImageUrl="../images/Edit.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDel" runat="server" CommandArgument='<%# Eval("GrpID").ToString() %>'
                                CommandName="DelC" ImageUrl="../images/delete.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="لیست مطالب">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("GrpID").ToString() %>'
                                CommandName="ListC" ImageUrl="../images/List.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ایجاد مطلب جدید">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                CommandArgument='<%# Eval("GrpID").ToString() %>' CommandName="AddC" 
                                ImageUrl="../images/Add.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ایجاد زیر گروه">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton5" runat="server" CommandArgument='<%# Eval("GrpID").ToString() %>' CommandName="AddSubC" ImageUrl="../images/previous.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="clear_1">
        </div>
        <!-- end of row -->
    </div>
    <div class="clear">
    </div>
</asp:Content>
