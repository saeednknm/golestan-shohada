<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/masterpages/MgrMaster.master" AutoEventWireup="true" Inherits="panel_Album" Codebehind="Album.aspx.cs" %>

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
        <div class="row heigh_30">
            <div class="Rcolumn">
                نام آلبوم
                :</div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtName" runat="server" CssClass="Mytxt persian"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" 
                    ErrorMessage="لطفا نام آلبوم را وارد نمایید" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;
            </div>
        </div>
        <!-- end of row -->
              <div class="row height_auto">
            <div class="Rcolumn">
               توضیحات:</div>
            <div class="Lcolumn">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="Mytxt persian" 
                    Height="50px" TextMode="MultiLine" Width="350px" style="overflow:auto;"></asp:TextBox>
            </div>
        </div>
        <!-- end of row -->
        <div class="clear"></div>
        <div class="last_row">
            <asp:Button ID="btnOk" runat="server" Text="ثبت" CssClass="Mybtn" 
                onclick="btnOk_Click" />
        </div>
        <div class="clear"></div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" CssClass="MyGrid" 
                AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="عنوان آلبوم" DataField="AlbumName" />
                    <asp:TemplateField HeaderText="تاریخ ایجاد">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# MyClass.GetFarsiDate(Eval("AlbumDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PhotoCount" HeaderText="تعداد تصاویر" />
                    <asp:TemplateField HeaderText="افزودن تصویر">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("AlbumID").ToString() %>' CommandName="AddC" 
                                ImageUrl="../images/Add.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مشاهده تصاویر">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                CommandArgument='<%# Eval("AlbumID").ToString() %>' CommandName="ListC" 
                                ImageUrl="../images/photoList.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ویرایش مشخصات آلبوم">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton3" runat="server" 
                                CommandArgument='<%# Eval("AlbumID").ToString() %>' CommandName="EditC" 
                                ImageUrl="../images/Edit.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="حذف آلبوم">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnDel" runat="server" 
                                CommandArgument='<%# Eval("AlbumID").ToString() %>' CommandName="DelC" 
                                ImageUrl="../images/delete.png" CausesValidation="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
