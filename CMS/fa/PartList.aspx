<%@ Page Language="C#" AutoEventWireup="true" Inherits="Professor_PartList"
    MasterPageFile="~/MasterPages/WebMaster.master" Codebehind="PartList.aspx.cs" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Head">
    <title>آرشیو مطالب</title>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="SingleItem">
        <div class="title">
            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
            <asp:ImageButton ID="imgbtnPrev2" runat="server" Style="float: left" OnClick="imgbtnPrev_Click"
                ImageUrl="~/images/previous.png" />
            <asp:ImageButton ID="imgbtnNext2" runat="server" Style="float: left" OnClick="imgbtnNext_Click"
                ImageUrl="~/images/next.png" />
        </div>
        <div class="cleaner">
        </div>
        <br />
        <asp:DataList ID="DataList1" runat="server" CssClass="dtListFresh" Width="100%">
            <ItemTemplate>
                <article id="content3">
                    <div class="wrapper tabs">
                        <div id="tab1" class="tab-content">
                            <h5>
                                <span class="dropcap"><strong>
                                    <asp:Label ID="lblDay" runat="server" CssClass="strong" Text='<%# GetDay(Eval("ShowDate")) %>'></asp:Label>
                                </strong><span>
                                    <asp:Label ID="lblMonth" runat="server" CssClass="span" Text='<%# GetMonth(Eval("ShowDate")) %>'></asp:Label>
                                </span></span>
                            </h5>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="Hypink" NavigateUrl='<%# "ReadItem.aspx?itemId="+ DataBinder.Eval(Container.DataItem, "ItemID") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "ItemTopic") %>'></asp:HyperLink>
                            <br />
                            &nbsp;&nbsp;&nbsp;<span>
                                <asp:Label ID="lblPart" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PartName") %>'></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text=">"></asp:Label>
                                <asp:Label ID="lblGrp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GrpName") %>'></asp:Label>
                            </span>
                            <div class="wrapper pad_bot2">
                                <figure class="left marg_right1">
                                    <asp:Image ID="Image1" runat="server" CssClass="right marg_right2 fig_news" Height="90px"
                                        Width="110px" ImageUrl='<%# "..\\files\\photoItems\\"+ DataBinder.Eval(Container, "DataItem.PhotoName") %>' />
                                </figure>
                                <p class="Fresh">
                                    <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SummaryTxt") %>'></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                </article>
            </ItemTemplate>
        </asp:DataList>
        <div class="last_row">
            <asp:ImageButton ID="imgbtnNext" runat="server" OnClick="imgbtnNext_Click" ImageUrl="~/images/next.png" />
            <asp:ImageButton ID="imgbtnPrev" runat="server" OnClick="imgbtnPrev_Click" ImageUrl="~/images/previous.png" />
        </div>
    </div>
</asp:Content>
