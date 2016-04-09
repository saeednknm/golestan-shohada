using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_DailyMsg : System.Web.UI.Page
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
        sql = "select top 5 * from TDailyMsg where Active=1 and CustomerID={0} ORDER BY DailyMsgID DESC";
        sql = string.Format(sql, Customer());
        mc.connect();
        dt = mc.select(sql);
        mc.disconnect();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void InsertMsg()
    {
        sql = "insert into TDailyMsg (DMsgtxt,MsgDate,CustomerID,Active) values (N'{0}','{1}',{2},{3})";
        sql = string.Format(sql, txtTopic.Text, DateTime.Now, Customer(), 1);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        FillGrv();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "پیغام با موفقیت ثبت گردید و در صفحه اول به نمایش گذاشته شد";
    }
    protected void EditMsg(int msgID)
    {
        sql = "update TDailyMsg set DMsgtxt=N'{0}' where DailyMsgID={1}";
        sql = string.Format(sql, txtTopic.Text.Trim(), msgID);
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "پیغام با موفقیت ویرایش گردید";
        FillGrv();
        Button1.Text = "ثبت";
        Session["Edit"] = 0;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int msgid = Convert.ToInt32(Session["Edit"]);
            if (msgid != 0)
                EditMsg(msgid);
            else InsertMsg();
            txtTopic.Text = "";
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 107: عملیات انجام نشد، لطفا دوباره تلاش نمایید";
        }
    }
    protected void Filling(int msgID)
    {
        sql = "select DMsgtxt from TDailyMsg where DailyMsgID=" + msgID;
        mc.connect();
        string txt = mc.docommandScalar(sql).ToString();
        mc.disconnect();
        txtTopic.Text = txt;
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
                sql = "delete TDailyMsg where DailyMsgID=" + e.CommandArgument;
                mc.connect();
                mc.docommand(sql);
                mc.disconnect();
                errorDiv.Visible = false;
                confirmDiv.Visible = true;
                lblOk.Text = "پیغام مورد نظر حذف گردید";
                FillGrv();
            }
            catch (Exception)
            {
                confirmDiv.Visible = false;
                errorDiv.Visible = true;
                lblError.Text = "خطا 106: حذف انجام نشد، لطفا دوباره تلاش نمایید";
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton del = (ImageButton)e.Row.FindControl("imgbtnDel");
            del.Attributes.Add("onclick", "javascript:return " +
            "confirm('آیا از حذف پیغام مورد نظر اطمینان دارید؟') ");
        }
    }
}