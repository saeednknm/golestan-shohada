using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Professor_PartList : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    PersianCalendar pc = new PersianCalendar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDataList();
        }
    }
    protected int GetGrpID()
    {
        try
        {
            int grp = Convert.ToInt32(Request.QueryString["GrpiD"]);
            return grp;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    protected int GetPartID()
    {
        try
        {
            int part = Convert.ToInt32(Request.QueryString["PartiD"]);
            return part;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    protected void GoToItem(int itemid)
    {
        try
        {
            Response.Redirect("ReadItem.aspx?itemId=" + itemid);
        }
        catch (Exception)
        {
        }
    }
    public void FillDataList()
    {
        int grpid = GetGrpID();
        int partid = GetPartID();
        try
        {
            if (grpid != 0 && partid == 0)
            {
                sql = "SELECT  dbo.TParts.PartName, dbo.TGroups.GrpName, dbo.TItems.ItemTopic, dbo.TItems.PhotoName, dbo.TItems.SummaryTxt, " +
                      " dbo.TItems.ItemID,dbo.TItems.ShowDate  FROM   dbo.TItems INNER JOIN " +
                      " dbo.TGroups ON dbo.TItems.GrpID = dbo.TGroups.GrpID INNER JOIN " +
                      " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
                      " WHERE     (dbo.TItems.PubStat = 9) AND (dbo.TGroups.CustomerID = {0}) AND (GETDATE() >= dbo.TItems.ShowDate) " +
                      " AND (dbo.TItems.GrpID = {1})";
                sql = string.Format(sql, mc.GetCustomer(), grpid);
            }
            else if (partid != 0 && grpid == 0)
            {
                sql = "SELECT  dbo.TParts.PartName, dbo.TGroups.GrpName, dbo.TItems.ItemTopic, dbo.TItems.PhotoName, dbo.TItems.SummaryTxt, " +
                    " dbo.TItems.ItemID,dbo.TItems.ShowDate  FROM   dbo.TItems INNER JOIN " +
                    " dbo.TGroups ON dbo.TItems.GrpID = dbo.TGroups.GrpID INNER JOIN " +
                    " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
                    " WHERE     (dbo.TItems.PubStat = 9) AND (dbo.TGroups.CustomerID = {0}) AND (GETDATE() >= dbo.TItems.ShowDate) " +
                    " AND (dbo.TGroups.PartID = {1})";
                sql = string.Format(sql, mc.GetCustomer(), partid);
            }
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            //
            if (dt.Rows.Count == 1)
            {
                int item = Convert.ToInt32(dt.Rows[0]["ItemID"]);
                GoToItem(item);
            }
            //
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 10;

            pds.CurrentPageIndex = CurrentPage;
            int count = pds.PageCount;

            lblCurrentPage.Text = "صفحه: " + (CurrentPage + 1).ToString() + " از " + pds.PageCount.ToString();

            // Disable Prev or Next buttons if necessary
            imgbtnPrev.Enabled = !pds.IsFirstPage;
            imgbtnNext.Enabled = !pds.IsLastPage;
            imgbtnPrev2.Enabled = !pds.IsFirstPage;
            imgbtnNext2.Enabled = !pds.IsLastPage;

            DataList1.DataSource = pds;
            DataList1.DataBind();
        }
        catch (Exception)
        {
        }
    }
    public int CurrentPage
    {
        get
        {

            // look for current page in ViewStat
            object o = this.ViewState["_CurrentPage"];
            if (o == null)
                return 0; // default to showing the first page
            else
                return (int)o;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }

    }
    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        CurrentPage += 1;
        FillDataList();
    }
    protected void imgbtnPrev_Click(object sender, ImageClickEventArgs e)
    {
        CurrentPage -= 1;
        FillDataList();
    }
    public string GetMonth(object date)
    {
        DateTime d = Convert.ToDateTime(date);
        string month = pc.GetMonth(d).ToString();
        return month;
    }
    public string GetDay(object date)
    {
        DateTime d = Convert.ToDateTime(date);
        string day = pc.GetDayOfMonth(d).ToString();
        return day;
    }


}