using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Reporting;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
   
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();  
    SqlCommand cmd = new SqlCommand();
    //ReportDocument report = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Bind();
            //ReportBind();
            con.Close();
            Average();
           
        }
        

    }
    private void Bind()
    {
        adp = new SqlDataAdapter("select * from Ogrenci", con);    
        adp.Fill(ds, "stu"); 
        Repeater1.DataSource = ds.Tables["stu"];
        Repeater1.DataBind();
        con.Close();
       
    }

    //private void ReportBind()
    //{
    //    adp = new SqlDataAdapter("select * from Ogrenci", con);
    //    adp.Fill(ds, "Procedure");
    //    //report.Load(Server.MapPath("CrystalReport.rpt"));
    //    //report.SetDataSource(ds);
    //    CrystalReportViewer1.ReportSource = ds.Tables["Ogrenci"];
    //    CrystalReportViewer1.DataBind();
    //    con.Close();

    //}


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        string id = Convert.ToString(e.CommandArgument);
        switch (e.CommandName)
        {
            case ("Delete"):
                DeleteRepeaterData(id);
                break;
          
            case ("Insert"):
                InsertRepeaterData(e);
                break;
            case ("Add"):
                AddRepeaterData(e);
                break;
 
        }
    }
   
    private void DeleteRepeaterData(string id)
    {
        string str = "delete from Ogrenci where TC=" + id;
        try
        {
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.ExecuteNonQuery();
           
            lblresult.Text = "Record Deleted Successfully";
            lblresult.ForeColor = System.Drawing.Color.Green;
            
        }
        catch (Exception ex)
        {
            lblresult.Text = ex.Message.ToString();
            lblresult.ForeColor = System.Drawing.Color.Red;
        }
        finally
        {
            Bind();
            Average();
            con.Close();
        }
        
    }
 
    

    private void InsertRepeaterData(RepeaterCommandEventArgs e)
    {
        TextBox tc = (TextBox)e.Item.FindControl("TextBox1");
        TextBox ad = (TextBox)e.Item.FindControl("TextBox2");
        TextBox soyad = (TextBox)e.Item.FindControl("TextBox3");
        TextBox ders = (TextBox)e.Item.FindControl("TextBox4");
        TextBox not = (TextBox)e.Item.FindControl("TextBox5");
        int res = 0;
        if (not.Text.Contains(","))
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not Ortalaması alanında lütfen nokta kullanınız.')", true);
        }
        else if (tc.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('TC alanı boş olamaz.')", true);
        }
        else if (tc.Text.Trim().Length != 11)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('TC alanı 11 haneden oluşmalıdır.')", true);
        }
        
        else if (int.TryParse(ad.Text, out res))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lütfen geçerli bir isim giriniz(İsim alanı karakter içermelidir.Rakam içeremez.).')", true);
        }
        else if (int.TryParse(soyad.Text, out res))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lütfen geçerli bir isim giriniz(Soyisim alanı karakter içermelidir.Rakam içeremez.).')", true);
        }
        else
        {
            string str = "insert into Ogrenci (TC,Ad,Soyad,Aldigi_ders_sayisi,not_ortalamasi) values('" + tc.Text + "','" + ad.Text + "','" + soyad.Text + "'," + ders.Text + "," + not.Text + ")";

            try
            {
                cmd = new SqlCommand(str, con);
                con.Open();
                cmd.ExecuteNonQuery();

                lblresult.Text = "Record Inserted Successfully";
                lblresult.ForeColor = System.Drawing.Color.Green;

            }
            catch (Exception ex)
            {
                lblresult.Text = ex.Message.ToString();
                lblresult.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                Bind();
                Average();
                con.Close();
            }
        }
        
    }

    public void Average()
    {
        string str = "Select avg(not_ortalamasi) as notOrtalamasi from Ogrenci";
        cmd = new SqlCommand(str, con);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Label1.Text += reader["notOrtalamasi"];
        }
        Bind();
        reader.Close();
        con.Close();


    }

    protected void AddRepeaterData(RepeaterCommandEventArgs e)
    {
       
        ((ImageButton)e.Item.FindControl("LinkInsert2")).Visible = true;
        ((ImageButton)e.Item.FindControl("lnkDelete2")).Visible = true;
        ((TextBox)e.Item.FindControl("TextBox1")).Visible = true;
        ((TextBox)e.Item.FindControl("TextBox2")).Visible = true;
        ((TextBox)e.Item.FindControl("TextBox3")).Visible = true;
        ((TextBox)e.Item.FindControl("TextBox4")).Visible = true;
        ((TextBox)e.Item.FindControl("TextBox5")).Visible = true;
       

    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
 
    //    cmd = new SqlCommand("Procedure", con);
    //    con.Open();
    //    adp = new SqlDataAdapter(cmd);        
    //    adp.Fill(ds, "DataTable1");
    //    report.SetDataSource(ds);
    //    CrystalReportViewer1.ReportSource = report;
    //    CrystalReportViewer1.DataBind();
    //    con.Close();
       
    //}
}