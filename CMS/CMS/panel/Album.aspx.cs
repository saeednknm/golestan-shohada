using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class panel_Album : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
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
            FirstAlbum();
            FillGrv();
            Session["AlbumID"] = 0;
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
    protected void FillGrv()
    {
        sql = "SELECT  COUNT(dbo.TPicture.PicID) AS PhotoCount, dbo.TAlbum.AlbumID, dbo.TAlbum.AlbumName, dbo.TAlbum.AlbumDate "+
            " FROM   dbo.TAlbum LEFT OUTER JOIN "+
            " dbo.TPicture ON dbo.TAlbum.AlbumID = dbo.TPicture.AlbumID "+
            " WHERE  (dbo.TAlbum.CustomerID = {0}) "+
            " GROUP BY dbo.TAlbum.AlbumID, dbo.TAlbum.AlbumName, dbo.TAlbum.AlbumDate "+
            " ORDER BY dbo.TAlbum.AlbumID DESC";
        sql = string.Format(sql, Customer());
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void FirstAlbum()
    {
        sql = "select count(*) from TAlbum where customerid={0}";
        sql = string.Format(sql, Customer());
        mc.connect();
        int cnt = Convert.ToInt32(mc.docommandScalar(sql));
        if (cnt == 0)
        {
            string name = "تصاویر من";
            sql = "insert into TAlbum (AlbumName,AlbumDate,Remark,CustomerID) values (N'{0}','{1}',N'{2}',{3})";
            sql = string.Format(sql, name, DateTime.Now, "", Customer());
            mc.docommand(sql);
        }
        mc.disconnect();
    }
    protected void AddAlbum()
    {
        sql = "insert into TAlbum (AlbumName,AlbumDate,Remark,CustomerID) values (N'{0}','{1}',N'{2}',{3})";
        sql = string.Format(sql, txtName.Text.Trim(), DateTime.Now, txtRemark.Text.Trim(), Customer());
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        FillGrv();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "آلبوم جدید با موفقیت ایجاد گردید";
    }
    protected void EditAlbum(int AlbumID)
    {
        sql = "update TAlbum set AlbumName='{0}',Remark=N'{1}' where AlbumID={2}";
        sql = string.Format(sql, txtName.Text.Trim(), txtRemark.Text.Trim(), AlbumID);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "مشخصات آلبوم با موفقیت ویرایش گردید";
        FillGrv();
        btnOk.Text = "ثبت";
        Session["AlbumID"] = 0;
    }
    protected void Filling(int GrpID)
    {
        sql = "select AlbumName,Remark from TAlbum where AlbumID=" + GrpID;
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        txtName.Text = dt.Rows[0]["AlbumName"].ToString();
        txtRemark.Text = dt.Rows[0]["Remark"].ToString();
        btnOk.Text = "ویرایش";
        errorDiv.Visible = false;
        confirmDiv.Visible = false;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            int AlbID = Convert.ToInt32(Session["AlbumID"]);
            if (AlbID != 0)
                EditAlbum(AlbID);
            else AddAlbum();
            txtName.Text = "";
            txtRemark.Text = "";
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 108: عملیات انجام نشد، لطفا دوباره تلاش نمایید";
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditC")
        {
            Filling(Convert.ToInt32(e.CommandArgument));
            Session["AlbumID"] = e.CommandArgument;
        }
        if (e.CommandName == "DelC")
        {
            try
            {
                sql = "delete TAlbum where AlbumID=" + e.CommandArgument;
                mc.connect();
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "آلبوم مورد نظر حذف گردید";
                FillGrv();
            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "خطا 109: پیش تر تصاویری در این آلبوم اضافه شده اند بنابراین امکان حذف آلبوم مورد نظر وجود ندارد";
            }
        }
        if (e.CommandName == "ListC")
        {
            Session["AlbumID"] = e.CommandArgument;
            Response.Redirect("AlbumPictureList.aspx");
        }
        if (e.CommandName == "AddC")
        {
            Session["AlbumID"] = e.CommandArgument;
            Response.Redirect("AddPicture.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton del = (ImageButton)e.Row.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف آلبوم مورد نظر اطمینان دارید؟') ");
        }
    }
}