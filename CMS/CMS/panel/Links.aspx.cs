using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_Links : System.Web.UI.Page
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
            FillGrv();
            Session["Edit"] = 0;
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
        try
        {

        sql = "select  * from TWebLink where CustomerID={0} ORDER BY LinkID DESC";
        sql = string.Format(sql, Customer());
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        GridView1.DataSource = dt;
        GridView1.DataBind();

        }
        catch (Exception)
        {
        }
    }
    protected void InsertLink()
    {
        string url =  txtAddress.Text;
        sql = "insert into TWebLink (LinkTitle,LinkURL,CustomerID) values (N'{0}','{1}',{2})";
        sql = string.Format(sql, txtTopic.Text, url, Customer());
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        FillGrv();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "آدرس مورد نظر با موفقیت ثبت گردید و در صفحه اول به نمایش گذاشته شد";
    }
    protected void EditLink(int lnkID)
    {
        string url =  txtAddress.Text;
        sql = "update TWebLink set LinkTitle=N'{0}',LinkURL='{1}' where LinkID={2}";
        sql = string.Format(sql, txtTopic.Text.Trim(), url, lnkID);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "آدرس با موفقیت ویرایش گردید";
        FillGrv();
        Button1.Text = "ثبت";
        Session["Edit"] = 0;
    }
    protected void Filling(int lnkID)
    {
        sql = "select LinkTitle,LinkURL from TWebLink where LinkID=" + lnkID;
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        txtTopic.Text = dt.Rows[0]["LinkTitle"].ToString();
        txtAddress.Text = dt.Rows[0]["LinkURL"].ToString();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditC")
        {
            Filling(Convert.ToInt32(e.CommandArgument));
            Session["Edit"] = e.CommandArgument;
            Button1.Text = "ویرایش";
            errorDiv.Visible = false;
            confirmDiv.Visible = false;
        }
        if (e.CommandName == "DelC")
        {
            try
            {
                sql = "delete TWebLink where LinkID=" + e.CommandArgument;
                mc.connect();
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "آدرس مورد نظر حذف گردید";
                FillGrv();
                txtTopic.Text = "";
                txtAddress.Text = "";
                Button1.Text = "ثبت";
                Session["Edit"] = 0;

            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "خطا 111: حذف انجام نشد، لطفا دوباره تلاش نمایید";
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton del = (ImageButton)e.Row.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف آدرس مورد نظر اطمینان دارید؟') ");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int lnkid = Convert.ToInt32(Session["Edit"]);
            if (lnkid != 0)
                EditLink(lnkid);
            else InsertLink();
            txtTopic.Text = "";
            txtAddress.Text = "";
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 112: عملیات انجام نشد، لطفا دوباره تلاش نمایید";
        }
    }
}