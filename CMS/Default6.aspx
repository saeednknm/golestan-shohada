<%@ Page Language="C#" AutoEventWireup="true" Inherits="CMS.Default" Codebehind="Default6.aspx.cs" %>

<!DOCTYPE html>
<html>
<head>
    <title>وب سایت رسمی دکتر اکبر عالم تبریز</title>
    <meta charset="utf-8" />
<meta name="description" content="دکتر اکبر عالم تبریز، در سال 1334 دیده به جهان گشود. کارشناسی علوم سیاسی از دانشگاه ملی ایران (شهید بهشتی) در سال 1356، کارشناسی ارشد MBA از دانشگاه E.N.M.U پرتالس ایالات متحده در سال 1359، و دکترای تخصصی خود را از دانشگاه Gazi آنکارا ترکیه در سال 1368 دریافت نمودند">
<meta name="keywords" content="اکبر عالم تبریز، دانشگاه شهید بهشتی، مدیریت صنعتی، مدیریت کارآفرینی، دانشکده مدیریت و حسابداری، alemtabriz، alem tabriz، alamtabriz، alam tabriz">
<meta name="author" content="دکتر اکبر عالم تبریز">
    <link rel="icon" href="/images/favicon.ico" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link rel="stylesheet" href="css_Alemtabriz/style.css" />
    <link rel="stylesheet" href="css_Alemtabriz/Home_Component.css" />
    <script src="js/jquery-1.6.3.min.js" type="text/javascript"></script>
    <script src="js/tms-0.3.js" type="text/javascript"></script>
    <script src="js/tms_presets.js" type="text/javascript"></script>
    <script src="js/jquery.carouFredSel-6.1.0-packed.js" type="text/javascript"></script>
    <script src="js/superfish.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(window).load(
        function () {
            $('.carousel1').carouFredSel({
                auto: false, prev: '.prev', next: '.next', width: 960, items: {
                    visible: {
                        min: 5,
                        max: 7
                    },
                    height: 'auto',
                    width: 300,
                }, responsive: true,
                scroll: 1,
                mousewheel: false,
                swipe: { onMouse: true, onTouch: true }
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            $('.close').bind('click', function () {
                $(this).parent().show().fadeOut(500);
            });
        });
    </script>
    <!--[if lt IE 8]>
       <div style=' clear: both; text-align:center; position: relative;'>
         <a href="http://windows.microsoft.com/en-US/internet-explorer/products/ie/home?ocid=ie6_countdown_bannercode">
           <img src="http://storage.ie6countdown.com/assets/100/images/banners/warning_bar_0000_us.jpg" border="0" height="42" width="820" alt="You are using an outdated browser. For a faster, safer browsing experience, upgrade for free today." />
         </a>
      </div>
    <![endif]-->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.js"></script>
      <link rel="stylesheet" media="screen" href="css/ie.css">

    <![endif]-->
</head>
<body class="page1">
    <form runat="server">
        <!--==============================header=================================-->

        <header>
            <div class="container_12">
                <div class="grid_12">
                    <h1>
                        <a href="#">
                            <img src="images_Alemtabriz/logo.jpg" alt="Akbar Alemtabriz"></a>
                    </h1>

                    <div class="menu_block">
                        <nav>
                            <ul class="sf-menu">
                                <li><a href="Professor/Contact.aspx">ارتباط با استاد</a> </li>
                                <li><a href="Professor/Resume.aspx">درباره استاد</a></li>
                                <li><a href="Professor/Album.aspx">آلبوم تصاویر</a></li>
                                <li><a href="Professor/PartList.aspx?PartiD=2">دریافت فایل</a>
                                    <ul class="Download">
                                        <asp:DataList ID="dtListDownload" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="Hypink" NavigateUrl='<%# "Professor/PartList.aspx?GrpiD="+ DataBinder.Eval(Container.DataItem, "GrpID") %>'
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "GrpName") %>'></asp:HyperLink></li>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ul>
                                </li>
                                <li><a href="Professor/PartList.aspx?PartiD=3">معرفی فعالیت ها</a>
                                    <ul class="News">
                                        <asp:DataList ID="dtListActivity" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="Hypink" NavigateUrl='<%# "Professor/PartList.aspx?GrpiD="+ DataBinder.Eval(Container.DataItem, "GrpID") %>'
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "GrpName") %>'></asp:HyperLink></li>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ul>
                                </li>
                                <li><a href="Professor/PartList.aspx?PartiD=1">آرشیو اخبار</a>
                                    <ul class="News">
                                        <asp:DataList ID="dtListNews" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Hypink" NavigateUrl='<%# "Professor/PartList.aspx?GrpiD="+ DataBinder.Eval(Container.DataItem, "GrpID") %>'
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "GrpName") %>'></asp:HyperLink>
                                                </li>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ul>
                                </li>
                                <li id="menu_active"><a class="active" href="Default6.aspx">صفحه نخست</a></li>
                            </ul>
                        </nav>
                        <div class="clear">
                        </div>
                    </div>


                </div>
            </div>

        </header>

        <div class="main2">
            <div class="wrapper" onclick="HideTabs()">
                <div class="slider-wrapper">
                    <div class="slider">
                        <ul class="items">
                            <li id="Board1" runat="server" visible="false">
                                <asp:Image ID="ImgBoard1" runat="server" ImageUrl="~/images/slider-img2.jpg" />
                                <strong class="banner"><a class="close" href="#">x</a> <strong>
                                    <asp:Label ID="lblTitleBoard1" runat="server" Style="margin: 5px; font-weight: bold;"></asp:Label></strong>
                                    <span>
                                        <asp:Label ID="lblSpanBoard1" runat="server"></asp:Label></span> <b class="margin-bot">
                                            <asp:Label ID="lblTxtBoard1" runat="server" Style="margin-bottom: 5px; font-weight: normal;"></asp:Label>
                                        </b>
                                    <asp:LinkButton ID="lnkbtnBoard1" runat="server" CssClass="button2" OnClick="lnkbtnBoard1_Click">بیشتر بخوانید</asp:LinkButton>
                                </strong></li>
                            <li id="Board2" runat="server" visible="false">
                                <asp:Image ID="ImgBoard2" runat="server" ImageUrl="~/images/slider-img2.jpg" />
                                <strong class="banner"><a class="close" href="#">x</a> <strong>
                                    <asp:Label ID="lblTitleBoard2" runat="server" Style="margin: 5px; font-weight: bold;"></asp:Label></strong>
                                    <span>
                                        <asp:Label ID="lblSpanBoard2" runat="server"></asp:Label></span> <b class="margin-bot">
                                            <asp:Label ID="lblTxtBoard2" runat="server" Style="margin-bottom: 5px; font-weight: normal;"></asp:Label>
                                        </b>
                                    <asp:LinkButton ID="lnkbtnBoard2" runat="server" CssClass="button2" OnClick="lnkbtnBoard2_Click">بیشتر بخوانید</asp:LinkButton>
                                </strong></li>
                            <li id="Board3" runat="server" visible="false">
                                <asp:Image ID="ImgBoard3" runat="server" ImageUrl="~/images/slider-img2.jpg" />
                                <strong class="banner"><a class="close" href="#">x</a> <strong>
                                    <asp:Label ID="lblTitleBoard3" runat="server" Style="margin: 5px; font-weight: bold;"></asp:Label></strong>
                                    <span>
                                        <asp:Label ID="lblSpanBoard3" runat="server"></asp:Label></span> <b class="margin-bot">
                                            <asp:Label ID="lblTxtBoard3" runat="server" Style="margin-bottom: 5px; font-weight: normal;"></asp:Label>
                                        </b>
                                    <asp:LinkButton ID="lnkbtnBoard3" runat="server" CssClass="button2" OnClick="lnkbtnBoard3_Click">بیشتر بخوانید</asp:LinkButton>
                                </strong></li>
                            <li id="Board4" runat="server" visible="false">
                                <asp:Image ID="ImgBoard4" runat="server" ImageUrl="~/images/slider-img2.jpg" />
                                <strong class="banner"><a class="close" href="#">x</a> <strong>
                                    <asp:Label ID="lblTitleBoard4" runat="server" Style="margin: 5px; font-weight: bold;"></asp:Label></strong>
                                    <span>
                                        <asp:Label ID="lblSpanBoard4" runat="server"></asp:Label></span> <b class="margin-bot">
                                            <asp:Label ID="lblTxtBoard4" runat="server" Style="margin-bottom: 5px; font-weight: normal;"></asp:Label>
                                        </b>
                                    <asp:LinkButton ID="lnkbtnBoard4" runat="server" CssClass="button2" OnClick="lnkbtnBoard4_Click">بیشتر بخوانید</asp:LinkButton>
                                </strong></li>
                            <li id="Board5" runat="server" visible="false">
                                <asp:Image ID="ImgBoard5" runat="server" ImageUrl="~/images/slider-img2.jpg" />
                                <strong class="banner"><a class="close" href="#">x</a> <strong>
                                    <asp:Label ID="lblTitleBoard5" runat="server" Style="margin: 5px; font-weight: bold;"></asp:Label></strong>
                                    <span>
                                        <asp:Label ID="lblSpanBoard5" runat="server"></asp:Label></span> <b class="margin-bot">
                                            <asp:Label ID="lblTxtBoard5" runat="server" Style="margin-bottom: 5px; font-weight: normal;"></asp:Label>
                                        </b>
                                    <asp:LinkButton ID="lnkbtnBoard5" runat="server" CssClass="button2" OnClick="lnkbtnBoard5_Click">بیشتر بخوانید</asp:LinkButton>
                                </strong></li>
                        </ul>
                    </div>
                    <ul class="pagination">
                        <li id="pgBoard1" runat="server" visible="false"><a class="item-1" href=""><strong>01</strong></a></li>
                        <li id="pgBoard2" runat="server" visible="false"><a class="item-2" href=""><strong>02</strong></a></li>
                        <li id="pgBoard3" runat="server" visible="false"><a class="item-3" href=""><strong>03</strong></a></li>
                        <li id="pgBoard4" runat="server" visible="false"><a class="item-4" href=""><strong>04</strong></a></li>
                        <li id="pgBoard5" runat="server" visible="false"><a class="item-5" href=""><strong>05</strong></a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="DailyMsg">
            <div class="container_12">
                <script lang="javascript" type="text/javascript">
                    var theSummaries  = <%=CMS.JavaScript.Serialize(this.Values) %>;
                    var theSiteLinks = new Array();
                </script>
                <div class="tickerpane">
                    <asp:Image ID="Image3" runat="server" ImageUrl="images/Icon.png" Width="14px" Height="14px" />
                    &nbsp;<span id="theTicker">...</span>
                </div>
                <script src="js/Ticker.js" type="text/javascript"></script>
            </div>
        </div>
        <div class="clear">
        </div>

        <!--==============================Content=================================-->
        <div class="content">
            <div class="ic">
            </div>
            <div class="container_12">
                <div class="grid_12">
                    <div class="SummaryAbout">
                        <h3>
                            <span>
                                <asp:HyperLink ID="hyplnkResume" runat="server" CssClass="Hypink" NavigateUrl="~/Professor/Resume.aspx"></asp:HyperLink></span></h3>
                        <p class="SingleItem">
                            <asp:Image ID="imgResume" runat="server" CssClass="ResumeImg" Height="140px" Width="110px" />
                            <br />
                            <asp:Label ID="lblResume" runat="server"></asp:Label>
                        </p>
                        <a href="Professor/Resume.aspx" class="left">بیشتر بدانید</a>
                    </div>
                </div>
                <div class="grid_12">
                    <h3>
                        <span class="Topic">تازه ها</span></h3>
                </div>
                <div class="grid_12">
                    <asp:DataList ID="DataList1" runat="server" CssClass="dtListFresh" RepeatDirection="Horizontal"
                        Width="100%">
                        <ItemTemplate>
                            <section class="col2" style="width: 300px; text-align: center">
                                <asp:Image ID="Image1" runat="server" CssClass="right marg_right2 fig_news" Height="140px"
                                    Width="115px" ImageUrl='<%# "files\\photoItems\\"+ DataBinder.Eval(Container, "DataItem.PhotoName") %>' />
                                <br />
                                <span class="GroupSpan">
                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PartName") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GrpName") %>'></asp:Label>
                                    <asp:Label ID="Label4" runat="server" Text="-"></asp:Label><asp:Label ID="Label5"
                                        runat="server" Text='<%# MyClass.GetFarsiDate(Eval("ShowDate")) %>'></asp:Label>
                                </span>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Hypink" NavigateUrl='<%# "Professor/ReadItem.aspx?itemId="+ DataBinder.Eval(Container.DataItem, "ItemID") %>'
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ItemTopic") %>'></asp:HyperLink>
                                <br />
                                <div class="wrapper">
                                    <p class="Div_justify">
                                        <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SummaryTxt") %>'></asp:Label>
                                    </p>
                                </div>
                            </section>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <div style="width: 20px;">
                            </div>
                        </SeparatorTemplate>
                    </asp:DataList>
                </div>
                <div class="grid_12" style="height: 0px;">
                    <h3>
                        <span class="Topic">کتاب ها</span></h3>
                </div>
                <div class="clear">
                </div>
                <div class="works">
                    <div class="container_12">
                        <div class="albumBtn">
                            <a href="#" class="next"></a><a href="#" class="prev"></a>
                        </div>
                        <div class="cleaner">
                        </div>
                        <ul class="carousel1" runat="server" id="UlAlbum">
                            <li class="grid_4" runat="server" id="LiAlb1" visible="false">
                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton1_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb2" visible="false">
                                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton2_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb3" visible="false">
                                <asp:ImageButton ID="ImageButton3" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton3_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb4" visible="false">
                                <asp:ImageButton ID="ImageButton4" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton4_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb5" visible="false">
                                <asp:ImageButton ID="ImageButton5" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton5_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb6" visible="false">
                                <asp:ImageButton ID="ImageButton6" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton6_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb7" visible="false">
                                <asp:ImageButton ID="ImageButton7" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton7_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb8" visible="false">
                                <asp:ImageButton ID="ImageButton8" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton8_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb9" visible="false">
                                <asp:ImageButton ID="ImageButton9" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton9_Click" />
                            </li>
                            <li class="grid_4" runat="server" id="LiAlb10" visible="false">
                                <asp:ImageButton ID="ImageButton10" runat="server" CssClass="img_inner fleft" Width="125"
                                    Height="160" OnClick="ImageButton10_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <!--==============================footer=================================-->
        <footer>
            <div class="container_12">
                <div class="grid_6">
                    <p class="Subtitle">
                        پیوندها
                    </p>
                    <asp:DataList ID="dtListLink" runat="server" CssClass="dtlistLeft">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/bullet1.png" />&nbsp;<asp:HyperLink
                                ID="HyperLink4" runat="server" Target="_blank" CssClass="HyplnkMore" NavigateUrl='<%# "http://"+ DataBinder.Eval(Container.DataItem, "LinkURL") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "LinkTitle") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="grid_6">
                    <p class="Subtitle">
                        بیشتر بخوانید
                    </p>
                    <asp:DataList ID="DataList2" runat="server" CssClass="dtlistLeft">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/bullet1.png" />&nbsp;<asp:HyperLink
                                ID="HyperLink4" runat="server" CssClass="HyplnkMore" NavigateUrl='<%# "Professor/ReadItem.aspx?itemId="+ DataBinder.Eval(Container.DataItem, "ItemID") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "ItemTopic") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:DataList>
                </div>

                <div class="clear"></div>
                <br />
                <div class="copyright" style="margin-bottom:5px;">
                    <a href="http://linksystem.ir/" rel="nofollow" target="_blank" style="text-decoration: none;">طراحی شده توسط شرکت پیشگامان گسترش سامانه پیوند &copy;</a>
                </div>
                <!-- Begin WebGozar.com Counter code -->
                <script type="text/javascript" language="javascript" src="http://www.webgozar.ir/c.aspx?Code=3197698&amp;t=counter"></script>
                <noscript><a href="http://www.webgozar.com/counter/stats.aspx?code=3197698" target="_blank">&#1570;&#1605;&#1575;&#1585;</a></noscript>
                <!-- End WebGozar.com Counter code -->
            </div>
        </footer>
        <script type="text/javascript">        Cufon.now(); </script>
        <script type="text/javascript">
            $(window).load(function () {
                $('.slider')._TMS({
                    duration: 800,
                    easing: 'easeOutQuart',
                    preset: 'diagonalExpand',
                    slideshow: 7000,
                    pagNums: false,
                    pagination: '.pagination',
                    banners: 'fade',
                    pauseOnHover: true,
                    waitBannerAnimation: true
                });
            });
        </script>
    </form>
</body>
</html>
