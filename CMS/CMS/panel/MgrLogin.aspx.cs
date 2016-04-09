using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class aspx_MgrLogin : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    public int Customer()
    {
        // active customer
        int CustomerID = mc.GetCustomer();
        return CustomerID;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteTitle();
        }
    }
    protected void Login()
    {
        try
        {
            //string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPass.Value, "MD5");
            string user = txtUser.Value;
            string pass = txtPass.Value;
            mc.connect();
            sql = "select count(*) from TCustomers where UserName='{0}' and Password='{1}' and Enable={2} and CustomerID={3}";
            sql = string.Format(sql, user, pass, 1, Customer());
            int Count = Convert.ToInt32(mc.docommandScalar(sql));
            mc.disconnect();
            if (user != "" && pass != "" && Count == 1)
            {
                Session["CustomerID"] = Customer();
                Response.Redirect("MgrPanel.aspx");
            }
            else if (dt.Rows.Count != 1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "خطا 114: شناسه کاربری یا کلمه عبور صحیح نمی باشد";
            }

        }
        catch (Exception)
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "خطا 115: ورود ناموفق، لطفا دوباره تلاش نمایید";
        }
    }
    protected void SiteTitle()
    {
        try
        {
            sql = "select SiteTopic from TCustomers where CustomerID=" + Customer();
            mc.connect();
            string title = mc.docommandScalar(sql).ToString();
            mc.disconnect();
            lblSiteTitle.Text = title;
        }
        catch (Exception)
        {
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Login();
    }

}