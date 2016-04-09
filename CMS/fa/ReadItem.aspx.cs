using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Professor_ReadItem : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    PersianCalendar pc = new PersianCalendar();
    public String PageTitle
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
            Comment();
        }
    }
    protected void Fill()
    {
        try
        {
            int itemID = Convert.ToInt32(Request.QueryString["itemId"]);
            sql = "SELECT     dbo.TItems.ShowDate, dbo.TParts.PartID, dbo.TParts.PartName, dbo.TGroups.GrpName, dbo.TItems.ItemTopic, dbo.TItems.PhotoName, " +
                " dbo.TItems.BodyTxt, dbo.TItems.FileURL FROM   dbo.TGroups INNER JOIN " +
                " dbo.TItems ON dbo.TGroups.GrpID = dbo.TItems.GrpID INNER JOIN dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
                " WHERE     (dbo.TItems.ItemID = {0}) ";
            sql = string.Format(sql, itemID);
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            lbldate.Text = MyClass.GetFarsiDate(dt.Rows[0]["ShowDate"]);
            lblTime.Text = Convert.ToDateTime(dt.Rows[0]["ShowDate"]).ToString("HH:mm");
            lblPart.Text = dt.Rows[0]["PartName"].ToString();
            lblGrp.Text = dt.Rows[0]["GrpName"].ToString();
            lblTopic.Text = dt.Rows[0]["ItemTopic"].ToString();

            PageTitle = dt.Rows[0]["ItemTopic"].ToString();

            string photoName = dt.Rows[0]["PhotoName"].ToString();
            imgItem.ImageUrl = "..\\files\\photoItems\\" + photoName;
            string Bodytxt = dt.Rows[0]["BodyTxt"].ToString();
            DivItem.InnerHtml = Bodytxt;
            int pID = Convert.ToInt32(dt.Rows[0]["PartID"]);
            int len = dt.Rows[0]["FileURL"].ToString().Length;
            if (pID == 2 || (len > 1 && pID == 3) || (len > 0 && pID == 4))
            {
                DivDownload.Visible = true;
                Session["MyFileName"] = dt.Rows[0]["FileURL"];
            }

            //fileurl

        }
        catch (Exception)
        {
        }

    }
    protected void Comment()
    {
        int itemID = Convert.ToInt32(Request.QueryString["itemId"]);
        sql = "select CommentStat from TItems where ItemID=" + itemID;
        mc.connect();
        int CmtStat = Convert.ToInt32(mc.docommandScalar(sql));
        if (CmtStat != 7)
        {
            DivComment.Visible = true;
            DivExDiv.Visible = true;
            sql = "SELECT     dbo.TComments.CmtID, dbo.TComments.WrittenBy, dbo.TComments.CmtTxt, dbo.TComments.CmtDate " +
                " FROM   dbo.TComments INNER JOIN " +
                " dbo.TItems ON dbo.TComments.ItemID = dbo.TItems.ItemID " +
                " WHERE     (dbo.TComments.Active = 1) AND (dbo.TComments.ItemID = {0}) ORDER BY dbo.TComments.CmtDate DESC";
            sql = string.Format(sql, itemID);
            dt = mc.select(sql);
            mc.disconnect();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
    protected void Download()
    {
        string filename = Session["MyFileName"].ToString();
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
    protected void insertComment()
    {
        try
        {
            int itemID = Convert.ToInt32(Request.QueryString["itemId"]);
            sql = "select CommentStat from TItems where ItemID=" + itemID;
            mc.connect();
            int cmtStat = Convert.ToInt32(mc.docommandScalar(sql));
            int act = 0;
            string msg = "";
            if (cmtStat == 6)
            {
                act = 1;
                msg = "نظر شما با موفقیت ثبت گردید";
            }
            else if (cmtStat == 8)
                msg = "نظر شما ثبت گردید و پس از تائید مدیریت نمایش داده خواهد شد";
            sql = "insert into TComments (ItemID,WrittenBy,CmtTxt,CmtDate,Active,WriterEmail) values ({0},N'{1}',N'{2}','{3}',{4},N'{5}')";
            sql = string.Format(sql, itemID, txtName.Text.Trim(), txtComment.Text.Trim(), DateTime.Now, act, txtMail.Text.Trim());
            mc.docommand(sql);
            mc.disconnect();
            if (cmtStat == 6)
                Comment();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = msg;
            ClearTxt();
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 113: نظر شما ثبت نشد لطقا دوباره تلاش نمایید";
        }
    }
    protected void ClearTxt()
    {
        txtName.Text = "";
        txtMail.Text = "";
        txtComment.Text = "";
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Download();
        }
        catch (Exception)
        {
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Download();
        }
        catch (Exception)
        {
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        insertComment();
    }
}