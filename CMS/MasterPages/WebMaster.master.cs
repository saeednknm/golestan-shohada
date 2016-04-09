using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPages_WebMaster : System.Web.UI.MasterPage
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteTitle();
            BindNewsMenu();
            BindDownLoadMenu();
            BindActivityMenu();
            FillLinkAddress();
            FillDataList();
        }
    }
    //**** Title ****//
    protected void SiteTitle()
    {
        try
        {
            sql = "select SiteTopic from TCustomers where CustomerID=" + mc.GetCustomer();
            mc.connect();
            string title = mc.docommandScalar(sql).ToString();
            mc.disconnect();
            lblTitle.Text = title;
        }
        catch (Exception)
        {
        }
    }

    //**** Start OF menu ****//
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
    //**** Fresh ****//
    public void FillDataList()
    {
        try
        {
            sql = "SELECT  top 17  dbo.TItems.ItemID, dbo.TItems.ItemTopic FROM   dbo.TGroups INNER JOIN " +
                " dbo.TItems ON dbo.TGroups.GrpID = dbo.TItems.GrpID " +
                " WHERE     (dbo.TItems.FreshStat = 3 ) AND (dbo.TItems.PubStat = 9) AND (dbo.TGroups.CustomerID = {0}) AND (GETDATE() >= dbo.TItems.ShowDate) " +
                " ORDER BY dbo.TItems.ShowDate DESC";
            sql = string.Format(sql, mc.GetCustomer());
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }
        catch (Exception)
        {
        }
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
