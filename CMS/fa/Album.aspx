<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebMaster.master" AutoEventWireup="true" Inherits="Professor_Album" Codebehind="Album.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title><%=PageTitle%></title>
    <script type="text/javascript" src="../js/jquery.lightbox-0.5.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/jquery.lightbox-0.5.css" media="screen" />
    <script type="text/javascript">
        $(function () {
            $('.lightbox').lightBox();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="main_content" style="margin-bottom: 450px;" class="SingleItem">
        <div class="row">
            <div class="RCol2">
                <div class="row color1">
                    <asp:Label ID="Label2" runat="server" Text="نام آلبوم:"></asp:Label>
                    <asp:Label ID="lblNameAlbum" runat="server"></asp:Label>
                    <br />
                    <br />
                    <span>
                        <asp:Label ID="Label1" runat="server" Text="تاریخ ثبت آلبوم:"></asp:Label>
                        <asp:Label ID="lblDateAlbum" runat="server"></asp:Label></span>
                </div>
                <p class="row">
                    &nbsp;</p>
                <p class="row">
                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                </p>
            </div>
            <div class="LCol2 height_auto">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" Width="100%"
                    RepeatColumns="4">
                    <ItemTemplate>
                        <a class="lightbox" target="_blank" href='<%# "..\\files\\Album\\"+ DataBinder.Eval(Container, "DataItem.PicName") %>'>
                            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%# "..\\files\\Album\\"+ DataBinder.Eval(Container, "DataItem.PicName") %>' />
                        </a>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl="../images/Seprator.jpg"
                            Width="2px" />
                    </SeparatorTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
