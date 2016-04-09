using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class panel_MakeItem : System.Web.UI.Page
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
    //public int Part()
    //{
    //    int PartID = Convert.ToInt32(Request.QueryString["PartID"]);
    //    if (PartID == 1)
    //        DivUplode.Visible = false;
    //    if (PartID == 2)
    //    {
    //        lblSummary.Text = "خلاصه ای در مورد فایل";
    //        DivBody.Visible = false;
    //    }
    //    return PartID;
    //}
    //protected void FillTitle()
    //{
    //    switch (Part())
    //    {
    //        case 1:
    //            {
    //                lblTitle.Text = "درج خبر جدید";
    //                lblSpanTitle.Text = "ایجاد و ویرایش اخبار";
    //            } break;
    //        case 2:
    //            {
    //                lblTitle.Text = "بارگذاری فایل جدید";
    //                lblSpanTitle.Text = "قرار دادن فایل جهت دانلود به همراه توضیحات مربوط به فایل";
    //            } break;
    //        case 3:
    //            {
    //                lblTitle.Text = "معرفی فعالیت ها";
    //                lblSpanTitle.Text = "ایجاد و ویرایش فعالیت جدید ";
    //            } break;

    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            //FillTitle();
            BindGrp();
            BindFreshStat();
            BindCommentStat();
            BindPubStat();
            FillDate();
            FromGroupList();
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
    protected void FromGroupList()
    {
        try
        {
            string grp = Request.QueryString["GrpID"].ToString();
            drpGrpNews.SelectedValue = grp;
        }
        catch (Exception)
        {
        }
    }
    protected void BindGrp()
    {
        sql = "SELECT     dbo.TGroups.GrpID, dbo.TGroups.GrpName, dbo.TParts.PartName,dbo.TParts.PartName + ' -- ' + dbo.TGroups.GrpName AS name " +
            " FROM         dbo.TGroups INNER JOIN " +
            " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
            " WHERE     (dbo.TGroups.CustomerID = {0}) AND (dbo.TGroups.StatID = {1})";
        sql = string.Format(sql, Customer(), 1);
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpGrpNews.DataSource = dt;
        drpGrpNews.DataValueField = "GrpID";
        drpGrpNews.DataTextField = "name";
        drpGrpNews.DataBind();
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
    //protected bool CheckFileURL()
    //{
    //    int EditThis = Convert.ToInt32(Session["Edit"]);
    //    if (Part() == 2 && AsyncFileUpload2.FileName.Length != 0)
    //        return true;
    //    else if (Part() != 2)
    //        return true;
    //    else if (Part() == 2 && EditThis != 0)
    //        return true;
    //    else return false;
    //}
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
            string FileName = "-";
            if (EditThis != 0)
            {
                photoName = Session["photo"].ToString();
                FileName = Session["file"].ToString();
            }

            string topic = txtTopic.Text.Trim();
            int grp = Convert.ToInt32(drpGrpNews.SelectedValue);
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

            string summary = txtSummary.Text;
            string BodyTxt = editor.Value;

            //File
            string FileSaveLocation = "";
            if (AsyncFileUpload2.FileName.Length != 0)
            {
                FileName = System.IO.Path.GetFileName(AsyncFileUpload2.PostedFile.FileName);
                string format = FileName.Split('.').Last();
                FileName = RandomName() + "." + format;
                FileSaveLocation = Server.MapPath("\\CMS\\files\\UploadFiles") + "\\" + FileName;
                AsyncFileUpload2.PostedFile.SaveAs(FileSaveLocation);
            }

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
                sql = "insert into TItems (GrpID,ItemTopic,PhotoName,SummaryTxt,BodyTxt,FileURL,InputDate,ShowDate,FreshStat,CommentStat,PubStat,VisitCnt) " +
                    " values ({0},N'{1}','{2}',N'{3}',N'{4}','{5}','{6}','{7}',{8},{9},{10},0)";
                msg = "مطلب جدید با موفقیت ثبت گردید";
            }
            else if (EditThis != 0)
            {
                sql = "update TItems set GrpID={0},ItemTopic=N'{1}',PhotoName='{2}',SummaryTxt=N'{3}',BodyTxt=N'{4}' " +
                " ,FileURL='{5}',InputDate='{6}',ShowDate='{7}',FreshStat={8},CommentStat={9},PubStat={10} where ItemId=" + EditThis;
                msg = "مطلب با موفقیت ویرایش گردید";
            }
            sql = string.Format(sql, grp, topic, photoName, summary, BodyTxt, FileName, DateTime.Now, ShowDate, FreshStat, CommentStat, PubStat);
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            cleaner();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = msg;

        }
        else if (!CheckImgSize())
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 102: حداکثر حجم تصویر 150 کیلو بایت می باشد ";
        }
        else
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خظا 103: لطفا فایل مورد نظر را جهت دانلود از طریق گزینه Choose File انتخاب نمایید";
        }
    }
    protected void cleaner()
    {
        txtTopic.Text = "";
        txtSummary.Text = "";
        editor.Value = "";
        FillDate();
        Session["Edit"] = 0;
        DivPhoto.Visible = false;
        DivExFile.Visible = false;
        btnSubmit.Text = "درج مطلب";
        lblFile.Text = "فایل جهت دانلود:";
        lblPhoto.Text = "تصویر مطلب:";
    }
    protected void CheckEdit()
    {
        try
        {
            int itemID = Convert.ToInt32(Request.QueryString["ItemId"]);
            sql = "select * from TItems where ItemID=" + itemID;
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            txtTopic.Text = dt.Rows[0]["ItemTopic"].ToString();
            drpGrpNews.SelectedValue = dt.Rows[0]["GrpID"].ToString();

            DivPhoto.Visible = true;
            string photoName = dt.Rows[0]["PhotoName"].ToString();
            Session["photo"] = photoName;
            imgItem.ImageUrl = "\\CMS\\files\\photoItems\\" + photoName;
            lblPhoto.Text = "تصویر جایگزین:";

            txtSummary.Text = dt.Rows[0]["SummaryTxt"].ToString();
            editor.Value = dt.Rows[0]["BodyTxt"].ToString();

            string fName = dt.Rows[0]["FileURL"].ToString();
            Session["file"] = fName;

            lnkBtnExFile.Text = fName;
            lblFile.Text = "فایل جایگزین:";

            drpFreshStat.SelectedValue = dt.Rows[0]["FreshStat"].ToString();
            drpCommentStat.SelectedValue = dt.Rows[0]["CommentStat"].ToString();
            drpPubStat.SelectedValue = dt.Rows[0]["PubStat"].ToString();

            DateTime ShDate = Convert.ToDateTime(dt.Rows[0]["ShowDate"]);
            txtYearPub.Text = pc.GetYear(ShDate).ToString();
            txtmonthPub.Text = pc.GetMonth(ShDate).ToString();
            txtDayPub.Text = pc.GetDayOfMonth(ShDate).ToString();
            TimeSelector1.Hour = pc.GetHour(ShDate);
            TimeSelector1.Minute = pc.GetMinute(ShDate);
            btnSubmit.Text = "ویرایش مطلب";
            Session["Edit"] = itemID;
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = "اطلاعات فعلی مطلب را در زیر مشاهده می نمایید، در صورت نیاز آنها را ویرایش و دکمه ویرایش مطالب را کلیک نمایید.";
        }
        catch (Exception)
        {
        }
    }
    protected void lnkBtnExFile_Click(object sender, EventArgs e)
    {
        string filename = lnkBtnExFile.Text;
        string Path = "\\CMS\\files\\UploadFiles\\" + filename;
        if (Path != "")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.WriteFile(Path);
            Response.End();
        }
        Response.Redirect(Path);
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        AddEdit();
    }
}