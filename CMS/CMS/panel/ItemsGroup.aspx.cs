using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class panel_ItemsGroup : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    public int Customer()
    {
        // Session["CustomerID"] = 12;
        int CstID = Convert.ToInt32(Session["CustomerID"]);
        return CstID;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            FirstGroup();
            BindPartDrp();
            BindGrv();
            BindStatDrp();
            Session["Edit"] = 0;
            Session["father"] = 0;
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
    protected void FirstGroup()
    {
        sql = "select count(*) from tgroups where customerid={0}";
        sql = string.Format(sql, Customer());
        mc.connect();
        int grpNo = Convert.ToInt32(mc.docommandScalar(sql));
        if (grpNo == 0)
        {
            string name = "عمومی";
            sql = "insert into TGroups (PartID,GrpName,StatID,CustomerID,root,fatherID) values ({0},N'{1}',{2},{3},{4},{5})";
            sql = string.Format(sql, 0, name, 1, Customer(), 0, 0);
            mc.docommand(sql);
        }
        mc.disconnect();
    }
    protected void BindPartDrp()
    {
        try
        {
            sql = "select PartID,PartName from TParts where CustomerID=" + mc.GetCustomer();
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            drpPart.DataSource = dt;
            drpPart.DataValueField = "PartID";
            drpPart.DataTextField = "PartName";
            drpPart.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void BindStatDrp()
    {
        sql = "select StatID,StatName from Tstat where StatGrp=1";
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpStat.DataSource = dt;
        drpStat.DataValueField = "StatID";
        drpStat.DataTextField = "StatName";
        drpStat.DataBind();
    }
    protected void BindGrv()
    {
        int fatherID = Convert.ToInt32(Session["father"]);
        sql = "SELECT     dbo.TGroups.GrpName, dbo.TStat.StatName, dbo.TGroups.GrpID, dbo.TParts.PartName " +
            " FROM         dbo.TGroups INNER JOIN " +
            " dbo.TStat ON dbo.TGroups.StatID = dbo.TStat.StatID INNER JOIN " +
            " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
            " WHERE     (dbo.TGroups.CustomerID = {0}) AND (dbo.TGroups.fatherID = {1}) AND (dbo.TParts.PartID = {2})";
        sql = string.Format(sql, Customer(), fatherID, drpPart.SelectedValue);
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void AddGroup()
    {
        int fatherID = Convert.ToInt32(Session["father"]);
        int root = BackRoot(fatherID);
        sql = "insert into TGroups (PartID,GrpName,StatID,CustomerID,root,fatherID) values ({0},N'{1}',{2},{3},{4},{5})";
        sql = string.Format(sql, drpPart.SelectedValue, txtTopic.Text.Trim(), drpStat.SelectedValue, Customer(), root, fatherID);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        BindGrv();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "گروه جدید با موفقیت ایجاد گردید";
    }
    protected int BackRoot(int fatherID)
    {
        if (fatherID != 0)
        {
            sql = "select fatherID,root from TGroups where GrpID=" + fatherID;
            mc.connect();
            dt = mc.select(sql);
            int fid = Convert.ToInt32(dt.Rows[0]["fatherID"]);
            mc.disconnect();
            if (fid == 0)
                return 1;
            else
            {
                int Lastroot = Convert.ToInt32(dt.Rows[0]["root"]) + 1;
                return Lastroot;
            }
        }
        else return 0;
    }
    protected void EditGroup(int grpID)
    {
        sql = "update TGroups set PartID={0},GrpName=N'{1}',StatID={2} where GrpID={3}";
        sql = string.Format(sql, drpPart.SelectedValue, txtTopic.Text.Trim(), drpStat.SelectedValue, grpID);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "مشخصات گروه با موفقیت ویرایش گردید";
        BindGrv();
        btnOk.Text = "ثبت";
        Session["Edit"] = 0;
    }

    protected void Filling(int GrpID)
    {
        sql = "select PartID,GrpName,StatID from TGroups where GrpID=" + GrpID;
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpPart.SelectedValue = dt.Rows[0]["PartID"].ToString();
        txtTopic.Text = dt.Rows[0]["GrpName"].ToString();
        drpStat.SelectedValue = dt.Rows[0]["StatID"].ToString();
        btnOk.Text = "ویرایش";
        errorDiv.Visible = false;
        confirmDiv.Visible = false;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditC")
        {
            Filling(Convert.ToInt32(e.CommandArgument));
            Session["Edit"] = e.CommandArgument;
        }
        if (e.CommandName == "DelC")
        {
            try
            {
                sql = "delete TGroups where GrpID=" + e.CommandArgument;
                mc.connect();
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "گروه مورد نظر حذف گردید";
                BindGrv();
            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "خطا 101: پیش تر اخبار(هایی) با این موضوع ایجاد شده اند بنابراین امکان حذف گروه مورد نظر وجود ندارد";
            }
        }
        if (e.CommandName == "ListC")
        {
            Response.Redirect("ItemsList.aspx?RefGroup=" + e.CommandArgument);
        }
        if (e.CommandName == "AddC")
        {
            Response.Redirect("MakeItem.aspx?GrpID=" + e.CommandArgument);
        }
        if (e.CommandName == "AddSubC")
        {
            partDiv.Visible = false;
            Session["father"] = e.CommandArgument;
            BindGrv();
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            int grpid = Convert.ToInt32(Session["Edit"]);
            if (grpid != 0)
                EditGroup(grpid);
            else AddGroup();
            txtTopic.Text = "";
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 100: عملیات انجام نشد، لطفا دوباره تلاش نمایید";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton del = (ImageButton)e.Row.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف گروه مورد نظر اطمینان دارید؟') ");
        }
    }
}