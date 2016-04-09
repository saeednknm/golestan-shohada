using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class aspx_MakeResume : System.Web.UI.Page
{
    MyClass mc = new MyClass();
    DataTable dt = new DataTable();
    string sql = "";
    PersianCalendar pc = new PersianCalendar();
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
            CheckExResume();
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
    protected void CheckExResume()
    {
        sql = "select * from TResume where CustomerID=" + Customer();
        mc.connect();
        dt = mc.select(sql);
        if (dt.Rows.Count == 1)
        {
            int resID = Convert.ToInt32(dt.Rows[0]["ResumeID"]);
            txtTopic.Text = dt.Rows[0]["ResTopic"].ToString();
            DivPhoto.Visible = true;
            string photoname = dt.Rows[0]["ResPhoto"].ToString();
            Session["photo"] = photoname;
            Image1.ImageUrl = "\\files\\photoItems\\" + photoname;
            lblPhoto.Text = "تصویر جایگزین";
            txtSummary.Text = dt.Rows[0]["ResSummary"].ToString();
            DivFile.Visible = true;
            string filename = dt.Rows[0]["ResFile"].ToString();
            lnkbtnFile.Text = filename;
            Session["file"] = filename;
            lblFile.Text = "فایل رزومه جایگزین";
            btnSubmit.Text = "ویرایش رزومه";
            mc.disconnect();
            Session["Edit"] = resID;
        }
        else
        {
            Session["photo"] = "";
            Session["file"] = "";
            Session["Edit"] = -1;
        }
    }
    protected bool CheckImgSize()
    {
        if (AsyncFileUpload1.FileName.Length != 0)
        {
            int size = AsyncFileUpload1.PostedFile.ContentLength;
            if (size <= 150000)
                return true;
            else return false;
        }
        else return true;
    }
    protected bool CheckFileURL()
    {
        int EditThis = Convert.ToInt32(Session["Edit"]);
        if (AsyncFileUpload2.FileName.Length != 0)
            return true;
        else if (EditThis != 0)
            return true;
        else return false;
    }
    public string RandomName()
    {
        Random rnd = new Random();
        string dateNow = mc.DateShamsi(DateTime.Now).Replace("/", "");
        string num = rnd.Next().ToString();
        return dateNow + num;
    }
    protected void AddEdit()
    {
        //if (CheckImgSize() && CheckFileURL())
        if (CheckImgSize())
        {
            int EditThis = Convert.ToInt32(Session["Edit"]);
            string photoName = "";
            string FileName = "";
            if (EditThis != 0)
            {
                photoName = Session["photo"].ToString();
                FileName = Session["file"].ToString();
            }

            string topic = txtTopic.Text.Trim();
            //image
            string ImgSaveLocation = "";
            if (AsyncFileUpload1.FileName.Length != 0)
            {
                photoName = System.IO.Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                string format = photoName.Split('.').Last();
                photoName = RandomName() + "." + format;
                ImgSaveLocation = Server.MapPath("..\\files\\photoItems") + "\\" + photoName;
                AsyncFileUpload1.PostedFile.SaveAs(ImgSaveLocation);
            }

            string summary = txtSummary.Text;

            //File
            string FileSaveLocation = "";
            if (AsyncFileUpload2.FileName.Length != 0)
            {
                FileName = System.IO.Path.GetFileName(AsyncFileUpload2.PostedFile.FileName);
                string format = FileName.Split('.').Last();
                FileName = RandomName() + "." + format;
                FileSaveLocation = Server.MapPath("..\\files\\Resume") + "\\" + FileName;
                AsyncFileUpload2.PostedFile.SaveAs(FileSaveLocation);
            }
            string msg = "";
            if (EditThis == -1)
            {
                sql = "insert into TResume (ResTopic,ResSummary,ResFile,ResPhoto,CustomerID) " +
                    " values (N'{0}',N'{1}','{2}','{3}',{4})";
                sql = string.Format(sql, topic, summary, FileName, photoName, Customer());
                msg = "رزومه شما با موفقیت ثبت گردید و در پرتال شما به نمایش درآمد";
            }
            else if (EditThis != 0)
            {
                sql = "update TResume set ResTopic=N'{0}',ResSummary=N'{1}',ResFile='{2}',ResPhoto='{3}' where ResumeID={4}";
                sql = string.Format(sql, topic, summary, FileName, photoName, EditThis);
                msg = "اطلاعات رزومه با موفقیت ویرایش گردید";
            }

            mc.connect();
            mc.docommand(sql);
            mc.disconnect();
            clear();
            errorDiv.Visible = false;
            confirmDiv.Visible = true;
            lblOk.Text = msg;
            btnSubmit.Text = "ثبت رزومه";
        }
        else if (!CheckImgSize())
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خطا 104: حداکثر حجم تصویر 150 کیلو بایت می باشد ";
        }
        else
        {
            confirmDiv.Visible = false;
            errorDiv.Visible = true;
            lblError.Text = "خظا 105: لطفا فایل رزومه خود را جهت دانلود از طریق گزینه Choose File انتخاب نمایید";
        }
    }
    protected void clear()
    {
        txtTopic.Text = "";
        txtSummary.Text = "";
    }
    protected void lnkbtnFile_Click(object sender, EventArgs e)
    {
        string filename = lnkbtnFile.Text;
        string Path = "..\\files\\Resume\\" + filename;
        if (Path != "")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.WriteFile(Path);
            Response.End();
        }
        Response.Redirect(Path);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddEdit();
    }
}