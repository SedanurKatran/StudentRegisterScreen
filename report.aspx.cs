using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.Shared;


public partial class report : System.Web.UI.Page
{ 

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            ReportDocument reportdocument = new ReportDocument();
            reportdocument.Load(Server.MapPath("~/CrystalReport.rpt"));
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)) 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Ogrenci", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Ogrenci");
                con.Close();
            }
            reportdocument.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = reportdocument;
        }
    }
}

