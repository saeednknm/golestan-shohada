using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Professor_Resume : System.Web.UI.Page
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
            Fill();
        }
    }
    protected void Fill()
    {
        try
        {
            sql = "select * from TResume where CustomerID=" + mc.GetCustomer();
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            string resTopic=dt.Rows[0]["ResTopic"].ToString();
            lblTopic.Text = resTopic;
            PageTitle = resTopic;
            string photoName = dt.Rows[0]["ResPhoto"].ToString();
            imgResume.ImageUrl = "..\\files\\photoItems\\" + photoName;
            string Summary = dt.Rows[0]["ResSummary"].ToString();
            lblTXt.Text = Summary;
            Session["MyFileName"] = dt.Rows[0]["ResFile"];
        }
        catch (Exception)
        {
        }

    }
    protected void Download()
    {
        string filename = Session["MyFileName"].ToString();
        string Path = "..\\files\\Resume\\" + filename;
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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Download();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Download();
    }
}