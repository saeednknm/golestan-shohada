<%@ Page Language="C#" AutoEventWireup="true" Inherits="panel_ItemsList"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="ItemsList.aspx.cs" %>

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
    <div id="title_bar">
        <h1>
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        <span>
            <asp:Label ID="lblSpanTitle" runat="server"></asp:Label></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div id="DivBoard" runat="server" visible="false">
            <div class="first_row color1" style="margin-bottom:5px;">
                <asp:ImageButton ID="lnkBtnAddBoard" runat="server" 
                    ImageUrl="../images/Board_Icon.png" onclick="lnkBtnAddBoard_Click1" />
            </div>
        </div>
        <div id="DivSearch" runat="server">
            <div class="first_row color1">
                جستجوی مطلب</div>
            <div class="row heigh_30">
                <div class="Rcolumn">
                    عنوان:
                </div>
                <div class="Lcolumn">
                    <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                </div>
            </div>
            <div class="row heigh_30">
                <div class="Rcolumn">
                    گروه:
                </div>
                <div class="Lcolumn">
                    <asp:DropDownList ID="drpGrp" runat="server" CssClass="Mydrp persian">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row heigh_30">
                <div class="Rcolumn">
                    تاریخ نمایش از:
                </div>
                <div class="Rcolumn">
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="Mytxt persian right" Width="100px"></asp:TextBox>
                </div>
                <div class="Rcolumn">
                    تا:
                </div>
                <div class="Rcolumn">
                    <asp:TextBox ID="txtTo" runat="server" CssClass="Mytxt persian right" Width="100px"></asp:TextBox>
                </div>
            </div>
            <div class="last_row">
                <asp:Button ID="btnOk" runat="server" Text="جستجو" CssClass="Mybtn" OnClick="btnOk_Click" />
            </div>
            <div class="clear_1">
            </div>
            <!-- end of row -->
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="MyGrid"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="عنوان مطلب" DataField="ItemTopic" />
                    <asp:TemplateField HeaderText="تاریخ نمایش">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# MyClass.GetFarsiDate(Eval("ShowDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="زمان نمایش">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Convert.ToDateTime(Eval("ShowDate")).ToString("HH:mm") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="نمایش در صفحه اول" DataField='FreshStat' />
                    <asp:BoundField HeaderText="وضعیت انتشار" DataField="PubStat" />
                    <asp:TemplateField HeaderText="ویرایش">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ItemID").ToString() %>'
                                CommandName="EditC" ImageUrl="../images/Edit.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDel" runat="server" CommandArgument='<%# Eval("ItemID").ToString() %>'
                                CommandName="DelC" ImageUrl="../images/delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
