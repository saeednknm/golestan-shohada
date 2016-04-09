using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

public partial class CMS_panel_AddPicture : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            FillAlbumName();
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
    protected void FillAlbumName()
    {
        int Albumid = Convert.ToInt32(Session["AlbumID"]);
        sql = "select AlbumName from TAlbum where AlbumID=" + Albumid;
        mc.connect();
        string albName = mc.docommandScalar(sql).ToString();
        mc.disconnect();
        lblAlbum.Text = albName;
    }
    protected void AddPicture(string PicName)
    {
        int AlbumID = Convert.ToInt32(Session["AlbumID"]);
        sql = "insert into TPicture (AlbumID,PicDate,PicName,bodyText) values ({0},'{1}','{2}',N'{3}')";
        sql = string.Format(sql, AlbumID, DateTime.Now, PicName, "-");
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
    }

    public string RandomName()
    {
        Random rnd = new Random();
        string dateNow = mc.DateShamsi(DateTime.Now).Replace("/", "");
        string num = rnd.Next().ToString();
        return dateNow + num;
    }
    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string format = e.FileName.Split('.').Last();
        string phName = RandomName() + "." + format;
        string filePath = MapPath("../files/Album/") + System.IO.Path.GetFileName(phName);
        AjaxFileUpload1.SaveAs(filePath);
        AddPicture(phName);
    }
}