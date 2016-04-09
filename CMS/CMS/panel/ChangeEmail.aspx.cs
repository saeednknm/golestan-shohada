using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_ChangeEmail : System.Web.UI.Page
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
            BindEmail();
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
    public string BindEmail()
    {
        try
        {
            sql = "select Email from TCustomers where CustomerID=" + Customer();
            mc.connect();
            string email = mc.docommandScalar(sql).ToString();
            mc.disconnect();
            lblCurrentEmail.Text = email;
            return email;
        }
        catch (Exception)
        {
            return "0";
        }
    }
    protected void Change()
    {
        try
        {
            sql = "update TCustomers set Email='{0}' where CustomerID={1}";
            sql = string.Format(sql, txtNewEmail.Text, Customer());
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = "پست الکترونیکی شما با موفقیت تغییر یافت";
            BindEmail();
            txtNewEmail.Text = "";
        }
        catch (Exception)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "اطلاعات وارد شده صحیح نمی باشد";
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        Change();
    }
}