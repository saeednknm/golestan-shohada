using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Control_Panel_aspx_MgrPanel : System.Web.UI.Page
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
            LoadRemark();
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

    protected void LoadRemark()
    {
        try
        {
            sql = "select count(*) from TRemark where CustomerID=" + Customer();
            mc.connect();
            int cnt = Convert.ToInt32(mc.docommandScalar(sql));
            if (cnt == 0)
            {
                sql = "insert into TRemark (RemarkBody,CustomerID) values ('{0}',{1})";
                sql = string.Format(sql, " ", Customer());
                mc.docommand(sql);
            }
            else
            {
                sql = "select RemarkBody from TRemark where CustomerID=" + Customer();
                string body = mc.docommandScalar(sql).ToString();
                txtRemark.Text = body;
            }
            mc.disconnect();
        }
        catch (Exception)
        {
        }

    }
    protected void UpdateRemark()
    {
        try
        {
        sql = "update TRemark set RemarkBody=N'{0}' where CustomerID={1}";
        sql = string.Format(sql, txtRemark.Text, Customer());
        mc.connect();
        mc.docommand(sql);
        mc.disconnect();
        errorDiv.Visible = false;
        confirmDiv.Visible = true;
        lblOk.Text = "دفترچه یادداشت به روز گردید.";
        }
        catch (Exception)
        {
            errorDiv.Visible = true;
            confirmDiv.Visible = false;
            lblOk.Text = "لطفا دوباره تلاش نمایید.";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UpdateRemark();
    }
}