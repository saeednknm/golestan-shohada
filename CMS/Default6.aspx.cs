using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
namespace CMS
{
    public partial class Default : System.Web.UI.Page
    {
        MyClass mc = new MyClass();
        DataTable dt = new DataTable();
        string sql = "";
        protected string[] Values = new string[5];
        public String PageTitle
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DailyMsg();
                BindBoard();
                FillResume();
                FillDataList();
                BindAlbum();
                FillLinkAddress();
                BindNewsMenu();
                BindDownLoadMenu();
                BindActivityMenu();
            }

        }
        //**** DailyMsg ****//
        protected void DailyMsg()
        {
            try
            {

                sql = "select top 5 DMsgtxt from TDailyMsg where Active=1 and CustomerID={0} ORDER BY DailyMsgID DESC";
                sql = string.Format(sql, mc.GetCustomer());
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                int count = dt.Rows.Count;
                int j = -1;
                for (int i = 0; i < 5; i++)
                {
                    j++;
                    if (j >= count)
                        j = 0;
                    Values[i] = dt.Rows[j]["DMsgtxt"].ToString();

                }

            }
            catch (Exception)
            {
            }
        }
        //**** Board ****//
        protected void BindBoard()
        {
            sql = "SELECT     TOP (5) dbo.TItems.PhotoName, dbo.TItems.SummaryTxt, dbo.TItems.ItemID, dbo.TItems.ItemTopic " +
                " FROM    dbo.TItems INNER JOIN dbo.TGroups ON dbo.TItems.GrpID = dbo.TGroups.GrpID INNER JOIN " +
                " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
                " WHERE     (dbo.TItems.FreshStat = 11) AND (dbo.TItems.PubStat = 9) AND (dbo.TGroups.CustomerID = {0}) AND (GETDATE() >= dbo.TItems.ShowDate) " +
                " ORDER BY dbo.TItems.ItemID DESC";
            sql = string.Format(sql, mc.GetCustomer());
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            try
            {
                int count = dt.Rows.Count;
                int i = 0;
                //1
                if (count > 0)
                {
                    Board1.Visible = true;
                    pgBoard1.Visible = true;
                    ImgBoard1.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[0]["PhotoName"].ToString();
                    lblTitleBoard1.Text = dt.Rows[i]["ItemTopic"].ToString();
                    lblTxtBoard1.Text = dt.Rows[i]["SummaryTxt"].ToString();
                    Session["Board1"] = dt.Rows[i]["ItemID"];
                }
                //2
                if (count > 1)
                {
                    i++;
                    Board2.Visible = true;
                    pgBoard2.Visible = true;
                    ImgBoard2.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[i]["PhotoName"].ToString();
                    lblTitleBoard2.Text = dt.Rows[i]["ItemTopic"].ToString();
                    lblTxtBoard2.Text = dt.Rows[i]["SummaryTxt"].ToString();
                    Session["Board2"] = dt.Rows[i]["ItemID"];
                }
                //3
                if (count > 2)
                {
                    i++;
                    Board3.Visible = true;
                    pgBoard3.Visible = true;
                    ImgBoard3.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[i]["PhotoName"].ToString();
                    lblTitleBoard3.Text = dt.Rows[i]["ItemTopic"].ToString();
                    lblTxtBoard3.Text = dt.Rows[i]["SummaryTxt"].ToString();
                    Session["Board3"] = dt.Rows[i]["ItemID"];
                }
                //4
                if (count > 3)
                {
                    i++;
                    Board4.Visible = true;
                    pgBoard4.Visible = true;
                    ImgBoard4.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[i]["PhotoName"].ToString();
                    lblTitleBoard4.Text = dt.Rows[i]["ItemTopic"].ToString();
                    lblTxtBoard4.Text = dt.Rows[i]["SummaryTxt"].ToString();
                    Session["Board4"] = dt.Rows[i]["ItemID"];
                }
                //5
                if (count > 4)
                {
                    i++;
                    Board5.Visible = true;
                    pgBoard5.Visible = true;
                    ImgBoard5.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[i]["PhotoName"].ToString();
                    lblTitleBoard5.Text = dt.Rows[i]["ItemTopic"].ToString();
                    lblTxtBoard5.Text = dt.Rows[i]["SummaryTxt"].ToString();
                    Session["Board5"] = dt.Rows[i]["ItemID"];
                }
            }
            catch (Exception)
            {
            }

        }
        protected void lnkbtnBoard1_Click(object sender, EventArgs e)
        {
            int item = Convert.ToInt32(Session["Board1"]);
            Response.Redirect("Professor/ReadItem.aspx?itemId=" + item);
        }
        protected void lnkbtnBoard2_Click(object sender, EventArgs e)
        {
            int item = Convert.ToInt32(Session["Board2"]);
            Response.Redirect("Professor/ReadItem.aspx?itemId=" + item);
        }
        protected void lnkbtnBoard3_Click(object sender, EventArgs e)
        {
            int item = Convert.ToInt32(Session["Board3"]);
            Response.Redirect("Professor/ReadItem.aspx?itemId=" + item);
        }
        protected void lnkbtnBoard4_Click(object sender, EventArgs e)
        {
            int item = Convert.ToInt32(Session["Board4"]);
            Response.Redirect("Professor/ReadItem.aspx?itemId=" + item);
        }
        protected void lnkbtnBoard5_Click(object sender, EventArgs e)
        {
            int item = Convert.ToInt32(Session["Board5"]);
            Response.Redirect("Professor/ReadItem.aspx?itemId=" + item);
        }

        //**** menu ****//
        public void BindNewsMenu()
        {
            try
            {
                sql = "select GrpID,GrpName from Tgroups where StatID=1 and PartID=1  and CustomerID=" + mc.GetCustomer();
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                int cnt = dt.Rows.Count;
                int col = cnt / 5;
                dtListNews.RepeatColumns = col;
                dtListNews.DataSource = dt;
                dtListNews.DataBind();
            }
            catch (Exception)
            {
            }
        }
        public void BindDownLoadMenu()
        {
            try
            {
                sql = "select GrpID,GrpName from Tgroups where StatID=1 and PartID=2  and CustomerID=" + mc.GetCustomer();
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                int cnt = dt.Rows.Count;
                int col = cnt / 5;
                dtListDownload.RepeatColumns = col;
                dtListDownload.DataSource = dt;
                dtListDownload.DataBind();
            }
            catch (Exception)
            {
            }
        }
        public void BindActivityMenu()
        {
            try
            {
                sql = "select GrpID,GrpName from Tgroups where StatID=1 and PartID=3  and CustomerID=" + mc.GetCustomer();
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                int cnt = dt.Rows.Count;
                int col = cnt / 5;
                dtListActivity.RepeatColumns = col;
                dtListActivity.DataSource = dt;
                dtListActivity.DataBind();
            }
            catch (Exception)
            {
            }
        }
        //*** Resume ***//
        protected void FillResume()
        {
            try
            {
                sql = "select ResTopic,ResPhoto,ResSummary from TResume where CustomerID=" + mc.GetCustomer();
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                hyplnkResume.Text = dt.Rows[0]["ResTopic"].ToString();
                imgResume.ImageUrl = "~\\files\\photoItems\\" + dt.Rows[0]["ResPhoto"].ToString();
                lblResume.Text = dt.Rows[0]["ResSummary"].ToString();
            }
            catch (Exception)
            {
            }
        }

        //**** Fresh ****//
        public void FillDataList()
        {
            try
            {
                sql = "SELECT  top 6  dbo.TParts.PartName, dbo.TGroups.GrpName, dbo.TItems.ItemTopic, dbo.TItems.PhotoName, dbo.TItems.SummaryTxt, " +
                    " dbo.TItems.ItemID, dbo.TItems.ShowDate  FROM   dbo.TItems INNER JOIN " +
                    " dbo.TGroups ON dbo.TItems.GrpID = dbo.TGroups.GrpID INNER JOIN " +
                    " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
                    " WHERE     (dbo.TItems.FreshStat = 3 ) AND (dbo.TItems.PubStat = 9) AND (dbo.TGroups.CustomerID = {0}) AND (GETDATE() >= dbo.TItems.ShowDate) " +
                    " ORDER BY dbo.TItems.ShowDate DESC";
                sql = string.Format(sql, mc.GetCustomer());
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                DataList1.DataSource = dt.Rows.Cast<System.Data.DataRow>().Take(3).CopyToDataTable();
                DataList1.DataBind();
                DataList2.DataSource = dt;
                DataList2.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void BindAlbum()
        {
            try
            {
                sql = "SELECT   top 6  dbo.TPicture.PicName, dbo.TAlbum.AlbumID, dbo.TAlbum.AlbumName " +
                    " FROM   dbo.TAlbum INNER JOIN dbo.TPicture ON dbo.TAlbum.AlbumID = dbo.TPicture.AlbumID " +
                    " WHERE     (dbo.TAlbum.CustomerID = {0})";
                sql = string.Format(sql, mc.GetCustomer());
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                try
                {
                    int count = dt.Rows.Count;
                    int i = 0;
                    //1
                    if (count > 0)
                    {
                        LiAlb1.Visible = true;
                        ImageButton1.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        // LinkButton1.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album1"] = dt.Rows[i]["AlbumID"];
                    }
                    //2
                    if (count > 1)
                    {
                        i++;
                        LiAlb2.Visible = true;
                        ImageButton2.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton2.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album2"] = dt.Rows[i]["AlbumID"];
                    }
                    //3
                    if (count > 2)
                    {
                        i++;
                        LiAlb3.Visible = true;
                        ImageButton3.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        // LinkButton3.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album3"] = dt.Rows[i]["AlbumID"];
                    }
                    //4
                    if (count > 3)
                    {
                        i++;
                        LiAlb4.Visible = true;
                        ImageButton4.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton4.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album4"] = dt.Rows[i]["AlbumID"];
                    }
                    //5
                    if (count > 4)
                    {
                        i++;
                        LiAlb5.Visible = true;
                        ImageButton5.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton5.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album5"] = dt.Rows[i]["AlbumID"];
                    }
                    //6
                    if (count > 5)
                    {
                        i++;
                        LiAlb6.Visible = true;
                        ImageButton6.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton6.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album6"] = dt.Rows[i]["AlbumID"];
                    }
                    //7
                    if (count > 6)
                    {
                        i++;
                        LiAlb7.Visible = true;
                        ImageButton7.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton7.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album7"] = dt.Rows[i]["AlbumID"];
                    }
                    //8
                    if (count > 7)
                    {
                        i++;
                        LiAlb8.Visible = true;
                        ImageButton8.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton8.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album8"] = dt.Rows[i]["AlbumID"];
                    }
                    //9
                    if (count > 8)
                    {
                        i++;
                        LiAlb9.Visible = true;
                        ImageButton9.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton9.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album9"] = dt.Rows[i]["AlbumID"];
                    }
                    //10
                    if (count > 9)
                    {
                        i++;
                        LiAlb10.Visible = true;
                        ImageButton10.ImageUrl = "~\\files\\Album\\" + dt.Rows[i]["PicName"].ToString();
                        //LinkButton10.Text = dt.Rows[i]["AlbumName"].ToString();
                        Session["Album10"] = dt.Rows[i]["AlbumID"];
                    }
                }
                catch (Exception)
                {
                }


            }
            catch (Exception)
            {
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album1"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album2"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album3"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album4"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album5"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album6"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album7"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album8"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album9"];
            Response.Redirect("Professor/Album.aspx");
        }
        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            Session["AlbumID"] = Session["Album10"];
            Response.Redirect("Professor/Album.aspx");
        }

        //*** Link ***//
        protected void FillLinkAddress()
        {
            try
            {
                sql = "select top 10 LinkTitle,LinkURL from TWebLink where CustomerID={0} ORDER BY LinkID DESC";
                sql = string.Format(sql, mc.GetCustomer());
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                dtListLink.DataSource = dt;
                dtListLink.DataBind();

            }
            catch (Exception)
            {
            }
        }
    }

    public static class JavaScript
    {
        public static string Serialize(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
    }
}