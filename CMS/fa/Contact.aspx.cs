using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Data.SqlClient;

public partial class Professor_Contact : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSpec();
        }
    }
    protected string ProfMail()
    {
        sql = "select Email from TCustomers where CustomerID=" + mc.GetCustomer();
        mc.connect();
        string mail = mc.docommandScalar(sql).ToString();
        mc.disconnect();
        return mail;
    }
    protected void FillSpec()
    {
        try
        {
            sql = "select Address,TelNo,ShowEmail from TCustomers where CustomerID=" + mc.GetCustomer();
            mc.connect();
            dt = mc.select(sql);
            mc.disconnect();
            lblAddress.Text = dt.Rows[0]["Address"].ToString();
            lblTel.Text = dt.Rows[0]["TelNo"].ToString();
            lblEmail2.Text = dt.Rows[0]["ShowEmail"].ToString();
        }
        catch (Exception)
        {
        }
    }
    protected string MailHost()
    {
        sql = "select MailHost from TCustomers where CustomerID=" + mc.GetCustomer();
        mc.connect();
        string MailHost = mc.docommandScalar(sql).ToString();
        mc.disconnect();
        return MailHost;
    }
    public void SendMail()
    {
        string name = "--";
        name = txtName.Text;
        string FromMail = txtMail.Text.Trim();
        string bodytext = txtBody.Text;
        string topic = txtTopic.Text.Trim();

        MailMessage mail = new MailMessage();
        SmtpClient sc = new SmtpClient();

        mail.From = new MailAddress(FromMail, name);
        mail.To.Add(new MailAddress(ProfMail()));
        mail.Subject = topic;
        mail.Body = bodytext;
        try
        {
            sc.Host = MailHost();
            sc.Send(mail);
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = "با تشکر فراوان از تماس شما، ما پیغام شما را دریافت نمودیم";
        }
        catch
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 116: متاسفانه پیغام شما ارسال نگردید، لطفا دوباره تلاش نمایید";
        }
    }
    public void clear()
    {
        txtName.Text = "";
        txtMail.Text = "";
        txtTopic.Text = "";
        txtBody.Text = "";
    }
    public void SaveEmail()
    {
        try
        {
            sql = "insert into TVisitors (Name,Email,CustomerID) values (N'{0}',N'{1}','{2}') ";
            sql = string.Format(sql, txtName.Text, txtMail.Text, mc.GetCustomer());
            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
        }
        catch (Exception)
        {

        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtMail.Text != "")
        {
            SendMail();
            SaveEmail();
            clear();
        }
        else
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 117: لطفا ایمیل خود را وارد نمایید";
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
}