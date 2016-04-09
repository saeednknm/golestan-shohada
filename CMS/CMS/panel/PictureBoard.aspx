<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_PictureBoard"
    MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="PictureBoard.aspx.cs" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <title>ایجاد و ویرایش مطالب تابلو اعلانات تصویری</title>
    <meta name="robots" content="nosnippet">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="پیوند سیستم">
    <script type="text/javascript">
        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                    {
                        e.returnValue = false;
                        return false;
                    }
                    else//Firefox
                        e.preventDefault();
                }
            }
        }

        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 35 && e.keyCode != 36 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }
    </script>
</asp:Content>
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
            تابلو اعلانات تصویری</h1>
        <span>انتشار اطلاعیه ها، اخبار و دیگر مطالب مهم به صورت تصویری در صفحه اول پرتال</span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <div class="row heigh_30">
            <div class="Rcolumn width_15">
                عنوان مطلب<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtTopic" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                :
            </div>
            <div class="Lcolumn width_84">
                <asp:TextBox ID="txtTopic" runat="server" CssClass="Mytxt persian" 
                    Width="500px" MaxLength="70"></asp:TextBox>
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
                <asp:Image ID="imgItem" runat="server" Height="96px" Width="332px" />
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row height_auto">
            <div class="Rcolumn width_15">
                <asp:Label ID="lblPhoto" runat="server" Text="تصویر مطلب:" Font-Size="13px"></asp:Label>
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
        <div class="row height_auto">
            <div class="Rcolumn width_15">
                <asp:Label ID="lblSummary" runat="server" Text="خلاصه مطلب" Font-Size="12px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSummary"
                    ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                :
            </div>
            <div class="Lcolumn width_84">
                <asp:TextBox ID="txtSummary" runat="server" CssClass="Mytxt persian" Height="40px"
                    Width="350px" TextMode="MultiLine" 
                    onkeyDown="return checkTextAreaMaxLength(this,event,'101');" 
                    MaxLength="101"></asp:TextBox>
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row height_auto" id="DivBody" runat="server">
            <div class="Rcolumn width_15">
                متن کامل<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Editor1"
                    ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                :
            </div>
            <div class="Lcolumn width_84">
                <asp:Editor ID="Editor1" runat="server" />
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="row height_auto" id="DivExFile" runat="server" visible="false">
            <div class="Rcolumn width_15">
                فایل فعلی:
            </div>
            <div class="Lcolumn width_84">
                <asp:LinkButton ID="lnkBtnExFile" runat="server" OnClick="lnkBtnExFile_Click"></asp:LinkButton>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="row heigh_30" id="DivUplode" runat="server">
            <div class="Rcolumn width_15">
                <asp:Label ID="lblFile" runat="server" Text="فایل جهت دانلود:"></asp:Label>
            </div>
            <div class="Lcolumn width_84">
                <asp:AsyncFileUpload ID="AsyncFileUpload2" runat="server" />
                <br />
            </div>
        </div>
        <!-- end of row -->
        <div class="clear">
        </div>
        <div class="first_row color1">
            وضعیت خبر</div>
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
            زمان و تاریخ انتشار خبر</div>
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
        <div class="last_row">
            <asp:Button ID="btnSubmit" runat="server" Text="درج مطلب" CssClass="Mybtn" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
