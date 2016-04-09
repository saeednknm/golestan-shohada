using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class CMS_panel_AddVideo : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    PersianCalendar pc = new PersianCalendar();
    public int Customer()
    {
        int CstID = Convert.ToInt32(Session["CustomerID"]);
        return CstID;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            BindPart();
            BindFreshStat();
            BindCommentStat();
            BindPubStat();
            FillDate();
            Session["Edit"] = 0;
            CheckEdit();
        }
    }
    protected void CheckCustomer()
    {
        try
        {
            int CustomerID = Convert.ToInt32(Session["CustomerID"]);
            string sql = "select Count(*) from TCustomers where CustomerID={0} and Enable=1";
            sql = string.Format(sql, CustomerID);
            mc.connect();
            int Cnt = Convert.ToInt32(mc.docommandScalar(sql));
            mc.disconnect();
            if (Cnt != 1)
            {
                Session["CustomerID"] = "";
                Response.Redirect("MgrLogin.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("MgrLogin.aspx");
        }
    }
    protected void BindPart()
    {
        sql = "select PartID,PartName from TParts";
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpPart.DataSource = dt;
        drpPart.DataValueField = "PartID";
        drpPart.DataTextField = "PartName";
        drpPart.DataBind();
    }
    protected void BindFreshStat()
    {
        sql = "select StatID,StatName from TStat where StatGrp=2";
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpFreshStat.DataSource = dt;
        drpFreshStat.DataValueField = "StatID";
        drpFreshStat.DataTextField = "StatName";
        drpFreshStat.DataBind();
    }
    protected void BindCommentStat()
    {
        sql = "select StatID,StatName from TStat where StatGrp=3";
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpCommentStat.DataSource = dt;
        drpCommentStat.DataValueField = "StatID";
        drpCommentStat.DataTextField = "StatName";
        drpCommentStat.DataBind();
        drpCommentStat.SelectedValue = "7";
    }
    protected void BindPubStat()
    {
        sql = "select StatID,StatName from TStat where StatGrp=4";
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpPubStat.DataSource = dt;
        drpPubStat.DataValueField = "StatID";
        drpPubStat.DataTextField = "StatName";
        drpPubStat.DataBind();
    }
    protected void FillDate()
    {
        txtYearPub.Text = pc.GetYear(DateTime.Now).ToString();
        txtmonthPub.Text = pc.GetMonth(DateTime.Now).ToString();
        txtDayPub.Text = pc.GetDayOfMonth(DateTime.Now).ToString();
    }
    protected bool CheckImgSize()
    {
        if (AsyncFileUpload1.FileName.Length != 0)
        {
            int size = AsyncFileUpload1.PostedFile.ContentLength;
            if (size <= 150000)
                return true;
            else return false;
        }
        else return true;
    }
    public string RandomName()
    {
        Random rnd = new Random();
        string dateNow = mc.DateShamsi(DateTime.Now).Replace("/", "");
        string num = rnd.Next().ToString();
        return dateNow + num;
    }
    protected void AddEdit()
    {
        if (CheckImgSize())
        {
            int EditThis = Convert.ToInt32(Session["Edit"]);
            string photoName = "";
            if (EditThis != 0)
            {
                photoName = Session["photo"].ToString();
            }

            string topic = txtTopic.Text.Trim();
            int part = Convert.ToInt32(drpPart.SelectedValue);
            //image
            string ImgSaveLocation = "";
            if (AsyncFileUpload1.FileName.Length != 0)
            {
                photoName = System.IO.Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                string format = photoName.Split('.').Last();
                photoName = RandomName() + "." + format;
                ImgSaveLocation = Server.MapPath("\\CMS\\files\\photoItems") + "\\" + photoName;
                AsyncFileUpload1.PostedFile.SaveAs(ImgSaveLocation);
            }

            string FileSaveLocation = txtFileURL.Text;
            int FreshStat = Convert.ToInt32(drpFreshStat.SelectedValue);
            int CommentStat = Convert.ToInt32(drpCommentStat.SelectedValue);

            int yearPub = Convert.ToInt32(txtYearPub.Text);
            int monthPub = Convert.ToInt32(txtmonthPub.Text);
            int dayPub = Convert.ToInt32(txtDayPub.Text);
            int hourPub = Convert.ToInt32(TimeSelector1.Hour);
            int MinPub = Convert.ToInt32(TimeSelector1.Minute);
            DateTime ShowDate = pc.ToDateTime(yearPub, monthPub, dayPub, hourPub, MinPub, 0, 0);

            int PubStat = Convert.ToInt32(drpPubStat.SelectedValue);

            string msg = "";
            if (EditThis == 0)
            {
                sql = "insert into TVideos (PartID,VideoName,VideoLink,InputDate,ShowDate,PictureURL,FreshStat,CommentStat,PubStat,VisitCnt) " +
                    " values ({0},N'{1}',N'{2}','{3}','{4}','{5}',{6},{7},{8},0)";
                msg = "ویدیو جدید با موفقیت ثبت گردید";
            }
            else if (EditThis != 0)
            {
                sql = "update TVideos set PartID={0},VideoName=N'{1}',VideoLink=N'{2}',InputDate='{3}',ShowDate='{4}',PictureURL='{5}' " +
                " ,FreshStat={6},CommentStat={7},PubStat={8} where VideoID=" + EditThis;
                msg = "ویدیو با موفقیت ویرایش گردید";
            }
            sql = string.Format(sql, part, topic, FileSaveLocation, DateTime.Now, ShowDate, photoName, FreshStat, CommentStat, PubStat);
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            cleaner();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = msg;

        }
        else
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 102: حداکثر حجم تصویر 150 کیلو بایت می باشد ";
        }
    }
    protected void cleaner()
    {
        txtTopic.Text = "";
        txtFileURL.Text = "";
        FillDate();
        Session["Edit"] = 0;
        DivPhoto.Visible = false;
        DivExFile.Visible = false;
        btnSubmit.Text = "درج ویدیو";
        lblPhoto.Text = "تصویر ویدیو:";
    }
    protected void CheckEdit()
    {
        try
        {
            int videoID = Convert.ToInt32(Request.QueryString["videoid"]);
            sql = "select * from TVideos where VideoID=" + videoID;
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            txtTopic.Text = dt.Rows[0]["ItemTopic"].ToString();
            drpPart.SelectedValue = dt.Rows[0]["PartID"].ToString();

            DivPhoto.Visible = true;
            string photoName = dt.Rows[0]["PictureURL"].ToString();
            Session["photo"] = photoName;
            imgItem.ImageUrl = "\\CMS\\files\\photoItems\\" + photoName;
            lblPhoto.Text = "تصویر جایگزین:";

           txtFileURL.Text = dt.Rows[0]["VideoLink"].ToString();

            drpFreshStat.SelectedValue = dt.Rows[0]["FreshStat"].ToString();
            drpCommentStat.SelectedValue = dt.Rows[0]["CommentStat"].ToString();
            drpPubStat.SelectedValue = dt.Rows[0]["PubStat"].ToString();

            DateTime ShDate = Convert.ToDateTime(dt.Rows[0]["ShowDate"]);
            txtYearPub.Text = pc.GetYear(ShDate).ToString();
            txtmonthPub.Text = pc.GetMonth(ShDate).ToString();
            txtDayPub.Text = pc.GetDayOfMonth(ShDate).ToString();
            TimeSelector1.Hour = pc.GetHour(ShDate);
            TimeSelector1.Minute = pc.GetMinute(ShDate);
            btnSubmit.Text = "ویرایش ویدیو";
            Session["Edit"] = videoID;
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = "اطلاعات فعلی ویدیو را در زیر مشاهده می نمایید، در صورت نیاز آنها را ویرایش و دکمه ویرایش ویدیو را کلیک نمایید.";
        }
        catch (Exception)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddEdit();
    }
}