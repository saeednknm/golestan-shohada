using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class panel_ItemsList : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    public int Customer()
    {
        int CstID = Convert.ToInt32(Session["CustomerID"]);
        return CstID;
    }
    //public int Part()
    //{
    //    int PartID = Convert.ToInt32(Request.QueryString["PartID"]);
    //    return PartID;
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckCustomer();
            FillGroup();
            //ReferenceGroup();
            //FillTitle();
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
    //protected void FillTitle()
    //{
    //    switch (Part())
    //    {
    //        case 1:
    //            {
    //                lblTitle.Text = "لیست خبرها";
    //                lblSpanTitle.Text = "مشاهده و جستجو در آرشیو اخبار";
    //            } break;
    //        case 2:
    //            {
    //                lblTitle.Text = "لیست فایل های موجود در پرتال";
    //                lblSpanTitle.Text = "مشاهده و جستجو در بین فایل ها";
    //            } break;
    //        case 3:
    //            {
    //                lblTitle.Text = "لیست فعالیت ها";
    //                lblSpanTitle.Text = "مشاهده و جستجو در بین فعالیت ها";
    //            } break;
    //        case 4:
    //            {
    //                lblTitle.Text = "لیست مطالب تابلو اعلانات تصویری";
    //                lblSpanTitle.Text = "مشاهده لیست مطالب درج شده در تابلوی تصویری";
    //                DivSearch.Visible = false;
    //                GridView1.Columns[1].Visible = false;
    //                GridView1.Columns[4].Visible = false;
    //                DivBoard.Visible = true;
    //            } break;

    //    }
    //}
    //protected void ReferenceGroup()
    //{
    //    string grpID = "0";
    //    try
    //    {
    //        grpID = Request.QueryString["RefGroup"].ToString();
    //    }
    //    catch (Exception)
    //    {
    //    }
    //    if (grpID != "-1" && Part() != 4)
    //    {
    //        drpGrp.SelectedValue = grpID;
    //        Search();
    //    }
    //    else if (Part() == 4)
    //        SearchBoard();

    //}
    protected void FillGroup()
    {
        //sql = "select GrpID,GrpName from TGroups where StatID={0} and CustomerID={1}";
        sql = "SELECT     dbo.TGroups.GrpID, dbo.TGroups.GrpName, dbo.TParts.PartName,dbo.TParts.PartName + ' -- ' + dbo.TGroups.GrpName AS name " +
          " FROM         dbo.TGroups INNER JOIN " +
          " dbo.TParts ON dbo.TGroups.PartID = dbo.TParts.PartID " +
          " WHERE     (dbo.TGroups.CustomerID = {0}) AND (dbo.TGroups.StatID = {1})";
        sql = string.Format(sql, Customer(), 1);
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        drpGrp.DataSource = dt;
        drpGrp.DataValueField = "GrpID";
        drpGrp.DataTextField = "name";
        drpGrp.DataBind();
        drpGrp.Items.Add("همه گروه ها");
        drpGrp.Items.FindByText("همه گروه ها").Value = "0";
        drpGrp.SelectedValue = "0";

    }
    protected void Search()
    {
        string partID = null;

        string topic = null;
        if (txtTopic.Text != "")
            topic = txtTopic.Text;

        string grp = null;
        if (drpGrp.SelectedValue != "0")
            grp = drpGrp.SelectedValue;

        string FromDate = null;
        if (txtFrom.Text != "")
            FromDate = mc.DateMiladi(txtFrom.Text.Trim()).ToString();

        string ToDate = null;
        if (txtTo.Text != "")
            ToDate = mc.DateMiladi(txtTo.Text.Trim()).ToString();

        mc.connect();
        DataView dv = mc.SpSearch(partID, topic, grp, FromDate, ToDate, Customer().ToString());
        mc.disconnect();

        GridView1.DataSource = dv;
        GridView1.DataBind();
    }

    protected int GetGroupIDBoard()
    {
        mc.connect();
        try
        {
            sql = "select GrpID from TGroups where PartID=4 and CustomerID=" + Customer();
            int grp = Convert.ToInt32(mc.docommandScalar(sql));
            return grp;
        }
        catch (Exception)
        {
            sql = "insert into TGroups (PartID,GrpName,StatID,CustomerID) values ({0},N'{1}',{2},{3});select SCOPE_IDENTITY() As GrpID ";
            sql = string.Format(sql, 4, "تابلو اعلانات تصویری", 1, Customer());
            SqlDataReader dr = mc.DoCommanddr(sql);
            int id = -1;
            if (dr.Read())
            {
                id = Convert.ToInt32(dr["GrpID"].ToString());
            }
            dr.Close();
            return id;
        }
    }
    //protected void SearchBoard()
    //{
    //    string partID = Part().ToString();
    //    string topic = null;
    //    string grp = GetGroupIDBoard().ToString();
    //    string FromDate = null;
    //    string ToDate = null;

    //    mc.connect();
    //    DataView dv = mc.SpSearch(partID, topic, grp, FromDate, ToDate, Customer().ToString());
    //    mc.disconnect();

    //    GridView1.DataSource = dv;
    //    GridView1.DataBind();
    //}

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditC")
        {
            //if (Part() != 4)
            Response.Redirect("MakeItem.aspx?&ItemId=" + e.CommandArgument);
            //else if (Part() == 4)
            //    Response.Redirect("PictureBoard.aspx?ItemId=" + e.CommandArgument);
        }
        if (e.CommandName == "DelC")
        {
            try
            {
                mc.connect();
                sql = "delete TComments where ItemID=" + e.CommandArgument;
                mc.docommand(sql);
                sql = "delete TItems where ItemID=" + e.CommandArgument;
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "مطلب مورد نظر حذف گردید";
                //if (Part() != 4)
                Search();
                //else SearchBoard();
            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "";
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton del = (ImageButton)e.Row.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف مطلب مورد نظر اطمینان دارید؟') ");
        }
    }
    protected void lnkBtnAddBoard_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PictureBoard.aspx");
    }
}