using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Professor_Album : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    public String PageTitle
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAll();
        }
    }
    protected void BindAll()
    {
        try
        {
            int fromtitle = Convert.ToInt32(Request.QueryString["FromMenu"]);
            if (fromtitle == 1)
            {
                sql = "SELECT  dbo.TPicture.PicID, dbo.TPicture.PicDate, dbo.TPicture.PicName " +
                    " FROM         dbo.TAlbum INNER JOIN " +
                    " dbo.TPicture ON dbo.TAlbum.AlbumID = dbo.TPicture.AlbumID " +
                    " WHERE     (dbo.TAlbum.CustomerID = {0})";
                sql = string.Format(sql, mc.GetCustomer());
                mc.connect();
                dt = mc.select(sql);
                mc.disconnect();
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
        catch (Exception)
        {
            BindDataList();
            FillLbl();
        }
    }
    protected void BindDataList()
    {
        try
        {
            int Albumid = Convert.ToInt32(Session["AlbumID"]);
            sql = "select PicID,PicName,PicDate from TPicture where albumID=" + Albumid;
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void FillLbl()
    {
        try
        {
            int Albumid = Convert.ToInt32(Session["AlbumID"]);
            sql = "select AlbumName,AlbumDate,Remark from TAlbum where AlbumID=" + Albumid;
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            string albName = dt.Rows[0]["AlbumName"].ToString();
            lblNameAlbum.Text = albName;
            PageTitle = albName;
            lblDateAlbum.Text = MyClass.GetFarsiDate(dt.Rows[0]["AlbumDate"]);
            lblRemark.Text = dt.Rows[0]["Remark"].ToString();

        }
        catch (Exception)
        {
        }
    }
}