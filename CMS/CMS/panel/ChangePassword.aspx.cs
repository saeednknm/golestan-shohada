using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class aspx_ChangePassword : System.Web.UI.Page
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
        string curPass = txtCurrentPass.Text;
        string Newpass = txtNewPass2.Text;
        if (curPass != Newpass && ValidOldPass())
        {
            sql = "update TCustomers set Password='{0}' where CustomerID={1}";
            sql = string.Format(sql, txtNewPass2.Text, Customer());
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = " کلمه عبور با موفقیت تغییر یافت";
            txtCurrentPass.Text = "";
            txtNewPass.Text = "";
            txtNewPass2.Text = "";
        }
        else if (curPass == Newpass)
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "کلمه عبور فعلی و جدید نمی توانند مشابه باشند";
        }
        else if (!ValidOldPass())
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "کلمه عبور فعلی صحیح نمی باشد";
        }
    }
    public bool ValidOldPass()
    {
        try
        {
            sql = "select Password from TCustomers where CustomerID=" + Customer();
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            string OldPass = dt.Rows[0]["PassWord"].ToString();
            string txtPass = txtCurrentPass.Text;
            if (OldPass == txtPass) return true;
            else return false;
        }
        catch (Exception)
        {
            return false;
        }

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        Change();
    }
}