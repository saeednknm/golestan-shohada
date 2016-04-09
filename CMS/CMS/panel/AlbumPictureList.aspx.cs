using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_AlbumPictureList : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            BindDataList();
            FillLbl();
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
            lblNameAlbum.Text = dt.Rows[0]["AlbumName"].ToString();
            lblDateAlbum.Text = dt.Rows[0]["AlbumDate"].ToString();
            lblRemark.Text = dt.Rows[0]["Remark"].ToString();
        
        }
        catch (Exception)
        {
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName=="DelC")
        {
            try
            {
                sql = "delete TPicture where PicID=" + e.CommandArgument;
                mc.connect();
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "تصویر مورد نظر حذف گردید";
                BindDataList();
            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "خطا 110: حذف انجام نشد، لطفا دوباره تلاش نمایید";
            }
        }
    }
    protected void DataList1_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton del = (ImageButton)e.Item.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف تصویر مورد نظر اطمینان دارید؟') ");
        }
    }
}