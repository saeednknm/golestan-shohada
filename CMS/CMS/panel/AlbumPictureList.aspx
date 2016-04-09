<%@ Page Title="" Language="C#" MasterPageFile="~/CMS/masterpages/MgrMaster.master" AutoEventWireup="true" Inherits="aspx_AlbumPictureList" Codebehind="AlbumPictureList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--script type="text/javascript" src="../js/jquery-1.6.3.min.js"></script>
    <script type="text/javascript" src="../js/jquery.lightbox-0.5.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/jquery.lightbox-0.5.css" media="screen" />
    <script type="text/javascript">
        $(function () {
            $('.lightbox').lightBox();
        });
    </script-->
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="TitleContentPH">
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
        </h1>
        <span></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row">
            <div class="RCol2">
                <div class="row color1">
                    <asp:Label ID="lblNameAlbum" runat="server"></asp:Label>
                    <br />
                    <span>
                        <asp:Label ID="lblDateAlbum" runat="server"></asp:Label></span>
                </div>
                <p class="row">
                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                </p>
            </div>
            <div class="LCol2">
                <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Center" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" Width="95%" OnItemCommand="DataList1_ItemCommand" 
                    onitemdatabound="DataList1_ItemDataBound1">
                    <ItemTemplate>
                        <a style="position: relative; left: 0; top: 0;" runat="server" class="lightbox" target="_blank"
                            href='<%# "..\\files\\Album\\"+ DataBinder.Eval(Container, "DataItem.PicName") %>'>
                            <asp:Image Style="position: relative; top: 0; left: 0;" ID="Image1" runat="server"
                                Height="100px" Width="100px" ImageUrl='<%# "..\\files\\Album\\"+ DataBinder.Eval(Container, "DataItem.PicName") %>' />
                            <asp:ImageButton ID="imgbtnDel" runat="server" Style="position: absolute; top: 90;
                                left: 0;" ImageUrl="../images/delete2.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PicID")%>'
                                 CommandName="DelC" ToolTip="حذف" AlternateText="حذف" />
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
