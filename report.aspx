<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
    
        <asp:Label ID="Label1" runat="server" Text="Report"></asp:Label>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"  Height="1202px" ReportSourceID="CrystalReportSource1"  ToolPanelView="None" ToolPanelWidth="200px" Width="903px" ReuseParameterValuesOnRefresh="True" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport.rpt">
            </Report>
        </CR:CrystalReportSource>
   
    
    </div>
    </form>
</body>
</html>
