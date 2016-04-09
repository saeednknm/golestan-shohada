using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_ChangeUsername : System.Web.UI.Page
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
            BindUser();
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
    public void Change()
    {
        string CurUser = txtCurrentUser.Text;
        string NewUser = txtNewUser.Text;
        if (CurUser != NewUser && SameUserName() && ValidUser())
        {
            sql = "update TCustomers set UserName='{0}' where CustomerID={1}";
            sql = string.Format(sql, txtNewUser.Text, Customer());
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = "شناسه کاربری با موفقیت تغییر یافت";
            txtCurrentUser.Text = "";
            txtNewUser.Text = "";
        }
        else if (CurUser == NewUser)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "شناسه کاربری جدید و فعلی نمی توانند مشابه باشند";
        }
        else if (!ValidUser())
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "شناسه کاربری فعلی صحیح نمی باشد";
        }
        else if (!SameUserName())
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "شناسه کاربری تکراری می باشد، لطفا نام کاربری دیگری را انتخاب نمایید";
        }
    }
    public bool SameUserName()
    {
        try
        {
            sql = "select count(*) from TCustomers where UserName='{0}'";
            sql = string.Format(sql, txtNewUser.Text);
            mc.connect();
            int cnt = Convert.ToInt32(mc.docommandScalar(sql));
            mc.disconnect();
            if (cnt == 0) return true;
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool ValidUser()
    {
        try
        {
            sql = "select count(*) from TCustomers where CustomerID={0} and UserName='{1}'";
            sql = string.Format(sql, Customer(), txtCurrentUser.Text);
            mc.connect();
            int cnt = Convert.ToInt32(mc.docommandScalar(sql));
            mc.disconnect();
            if (cnt == 1) return true;
            else return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public void BindUser()
    {
        try
        {
            sql = "select UserName from TCustomers where CustomerID=" + Customer();
            mc.connect();
            string user = mc.docommandScalar(sql).ToString();
            mc.disconnect();
            txtCurrentUser.Text = user;
        }
        catch (Exception)
        {
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        Change();
    }
}