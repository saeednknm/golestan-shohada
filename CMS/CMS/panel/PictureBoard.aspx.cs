using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

public partial class aspx_PictureBoard : System.Web.UI.Page
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
    protected int GetGroupID()
    {
        mc.connect();
        try
        {
            sql = "select GrpID from TGroups where PartID=4 and CustomerID=" + Customer();
            int grp = Convert.ToInt32(mc.docommandScalar(sql));
            return grp;
        }
        catch (Exception)
        {
            sql = "insert into TGroups (PartID,GrpName,StatID,CustomerID) values ({0},N'{1}',{2},{3});select SCOPE_IDENTITY() As GrpID ";
            sql = string.Format(sql, 4, "تابلو اعلانات تصویری", 1, Customer());
            SqlDataReader dr = mc.DoCommanddr(sql);
            int id = -1;
            if (dr.Read())
            {
                id = Convert.ToInt32(dr["GrpID"].ToString());
            }
            dr.Close();
            return id;
        }
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

            DivPhoto.Visible = true;
            string photoName = dt.Rows[0]["PhotoName"].ToString();
            Session["photo"] = photoName;
            imgItem.ImageUrl = "..\\files\\photoItems\\" + photoName;
            lblPhoto.Text = "تصویر جایگزین";

            txtSummary.Text = dt.Rows[0]["SummaryTxt"].ToString();
            Editor1.Content = dt.Rows[0]["BodyTxt"].ToString();

            string fName = dt.Rows[0]["FileURL"].ToString();
            Session["file"] = fName;
            DivExFile.Visible = true;
            lnkBtnExFile.Text = fName;
            lblFile.Text = "فایل جایگزین:";
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

            //image
            string ImgSaveLocation = "";
            if (AsyncFileUpload1.FileName.Length != 0)
            {
                photoName = System.IO.Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                string format = photoName.Split('.').Last();
                photoName = RandomName() + "." + format;
                ImgSaveLocation = Server.MapPath("..\\files\\photoItems") + "\\" + photoName;
                AsyncFileUpload1.PostedFile.SaveAs(ImgSaveLocation);
            }

            string summary = txtSummary.Text;
            string BodyTxt = "-";
            BodyTxt = Editor1.Content;

            //File
            string FileSaveLocation = "";
            if (AsyncFileUpload2.FileName.Length != 0)
            {
                FileName = System.IO.Path.GetFileName(AsyncFileUpload2.PostedFile.FileName);
                string format = FileName.Split('.').Last();
                FileName = RandomName() + "." + format;
                FileSaveLocation = Server.MapPath("..\\files\\UploadFiles") + "\\" + FileName;
                AsyncFileUpload2.PostedFile.SaveAs(FileSaveLocation);
            }

            int grp = GetGroupID();
            int FreshStat = 11;
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
                sql = "insert into TItems (GrpID,ItemTopic,PhotoName,SummaryTxt,BodyTxt,FileURL,InputDate,ShowDate,FreshStat,CommentStat,PubStat) " +
                    " values ({0},N'{1}','{2}',N'{3}',N'{4}','{5}','{6}','{7}',{8},{9},{10})";
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
        Editor1.Content = "";
        FillDate();
        Session["Edit"] = 0;
        DivPhoto.Visible = false;
        DivExFile.Visible = false;
        btnSubmit.Text = "درج مطلب";
        lblFile.Text = "فایل جهت دانلود:";
        lblPhoto.Text = "تصویر مطلب:";
    }

    protected void lnkBtnExFile_Click(object sender, EventArgs e)
    {
        string filename = lnkBtnExFile.Text;
        string Path = "..\\files\\UploadFiles\\" + filename;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddEdit();
    }
}