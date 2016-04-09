<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS_panel_AddVideo" MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="AddVideo.aspx.cs" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <title>ایجاد و ویرایش ویدیو جدید</title>
    <meta name="robots" content="nosnippet">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="پیوند سیستم">
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="TitleContentPH">
    <div id="roadmap">
    </div>
    <div class="clear">
    </div>
    <div class="confirmMSG" id="confirmDiv" visible="false" runat="server">
        <asp:Label ID="lblOk" runat="server"></asp:Label>
    </div>
    <div class="clearFloat">
    </div>
    <div class="errorMSG" id="errorDiv" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
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
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                عنوان ویدیو<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtTopic" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                :
            </div>
            <div class="Lcolumn width_84">
                <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian"
                    Width="500px" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                بخش:
            </div>
            <div class="Lcolumn width_84">
                <asp:DropDownList ID="drpPart" runat="server" CssClass="Mydrp">
                </asp:DropDownList>
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row height_auto" id="DivPhoto" runat="server" visible="false">
            <div class="Rcolumn width_15">
                تصویر فعلی:
            </div>
            <div class="Lcolumn width_84">
                <asp:Image ID="imgItem" runat="server" Height="150px" Width="220px" />
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row height_auto">
            <div class="Rcolumn width_15">
                <asp:Label ID="lblPhoto" runat="server" Text="تصویر ویدیو:" Font-Size="13px"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="حداکثر حجم 150 کیلوبایت"></asp:Label>
            </div>
            <div class="Lcolumn width_84">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
                <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
            </div>
        </div>
        <div class="clear">
        </div>
        <!-- end of row -->
        <div class="row height_auto" id="DivExFile" runat="server">
            <div class="Rcolumn width_15">
              آدرس فایل:
            </div>
            <div class="Lcolumn width_84">
                <asp:TextBox ID="txtFileURL" runat="server" Width="400px"></asp:TextBox>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="first_row color1">
            وضعیت مطلب
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                نمایش در صفحه اول:
            </div>
            <div class="Lcolumn width_84">
                <asp:DropDownList ID="drpFreshStat" runat="server" CssClass="Mydrp persian">
                </asp:DropDownList>
            </div>
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                وضعیت نظردهی:
            </div>
            <div class="Lcolumn width_84">
                <asp:DropDownList ID="drpCommentStat" runat="server" CssClass="Mydrp persian">
                </asp:DropDownList>
            </div>
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                وضعیت انتشار:
            </div>
            <div class="Lcolumn width_84">
                <asp:DropDownList ID="drpPubStat" runat="server" CssClass="Mydrp persian">
                </asp:DropDownList>
            </div>
        </div>
        <!-- end of row -->
        <div class="first_row color1">
            زمان و تاریخ انتشار مطلب
        </div>
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                تاریخ انتشار:
            </div>
            <div class="Lcolumn width_84">
                <asp:TextBox ID="txtDayPub" runat="server" CssClass="Mytxt persian" Width="25px"
                    MaxLength="2"></asp:TextBox>
                /
                <asp:TextBox ID="txtmonthPub" runat="server" CssClass="Mytxt persian" Width="25px"
                    MaxLength="2"></asp:TextBox>
                /
                <asp:TextBox ID="txtYearPub" runat="server" CssClass="Mytxt persian" Width="50px"
                    MaxLength="4"></asp:TextBox>
            </div>
        </div>
        <!-- end of row -->
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                زمان انتشار:
            </div>
            <div class="Lcolumn width_84">
                <MKB:TimeSelector ID="TimeSelector1" runat="server" CssClass="english right" SelectedTimeFormat="TwentyFour"
                    DisplaySeconds="False">
                </MKB:TimeSelector>
            </div>
        </div>
        <!-- end of row -->
        <div class="last_row color3">
            <asp:Button ID="btnSubmit" runat="server" Text="درج ویدیو" CssClass="Mybtn" Style="float: left; margin-left: 10px;" OnClick="btnSubmit_Click" />
        </div>
    </div>
            </asp:Content>
