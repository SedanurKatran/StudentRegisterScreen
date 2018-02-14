<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title>Öğrenci kayıt ekranı</title>
   
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" >
    <div>
    <div class="container-fluid" >
        <div class="jumbotron" style="border:1px dashed;box-shadow : 5px 5px 5px silver;">
            <h1> ÖĞRENCİ KAYIT EKRANI </h1>
        </div>
        <%--DataSourceID="SqlDataSource1"--%>
        <div class="jumbotron" style="border:1px dashed;box-shadow : 5px 5px 5px silver;">
            <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
            
            <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped table-bordered" >
                    <tr>
                        <td><b></b></td>
                        <td><b></b></td>
                        <td><b>Tc kimlik numarası</b></td>
                        <td><b>Ad</b></td>
                        <td><b>Soyad</b></td>
                        <td><b>Aldığı ders sayısı</b></td>
                        <td><b>Not ortalaması</b></td>        
                                       
                    </tr>         
            </HeaderTemplate>
            <ItemTemplate>
               
                <tr>
                    <td><%#Container.ItemIndex + 1 %></td>
                      <td>                 
                           
                          <asp:ImageButton ID="add" runat="server" CommandName="Add"  ImageUrl="~/Images/plus_add_green.png" />
                        <asp:ImageButton ID="lnkDelete"  runat="server" OnClientClick="return confirm('Do you want to delete this row?');" CommandArgument='<%#Eval("TC") %>' CommandName="Delete"   ImageUrl="~/Images/red_delete_button.png" />
                     
                    </td>
                    
                    <td><asp:Label ID="lblTC" runat="server" Text='<%# Eval("TC") %>'></asp:Label>
                    <asp:TextBox ID="txtTC" runat="server" Visible="false" Text='<%# Eval("TC") %>'></asp:TextBox>
                    </td>
                    <td><asp:Label ID="lblad" runat="server" Text='<%# Eval("Ad") %>'></asp:Label>
                    <asp:TextBox ID="txtad" runat="server" Visible="false" Text='<%# Eval("Ad") %>'></asp:TextBox>
                    </td>
                    <td><asp:Label ID="lblsoyad" runat="server" Text='<%# Eval("Soyad") %>'></asp:Label>
                    <asp:TextBox ID="txtsoyad" runat="server" Visible="false" Text='<%# Eval("Soyad") %>'></asp:TextBox>
                    </td>
                    <td><asp:Label ID="lblders" runat="server" Text='<%# Eval("Aldigi_ders_sayisi") %>'></asp:Label>
                    <asp:TextBox ID="txtders" runat="server" Visible="false" Text='<%# Eval("Aldigi_ders_sayisi") %>'></asp:TextBox>
                    </td>
                   
                    <td><asp:Label ID="lblnot" runat="server" Text='<%# Eval("not_ortalamasi") %>'></asp:Label>
                    <asp:TextBox ID="txtnot" runat="server" Visible="false" Text='<%# Eval("not_ortalamasi") %>'></asp:TextBox>
                    </td>
                  
                </tr>
                 <th>
                    
                    <td>
                       
                        <asp:ImageButton ID="LinkInsert2"  CommandName="Insert" Visible="false" OnClientClick="return confirm('Do you want to insert this row?');" runat="server" ImageUrl="~/Images/plus_add_green.png"></asp:ImageButton>
                        <asp:ImageButton ID="lnkDelete2" runat="server" Visible="false" OnClientClick="return confirm('Do you want to delete this row?');"  CommandName="Delete" ImageUrl="~/Images/red_delete_button.png"></asp:ImageButton>
                    </td>
                   
                    <td> <asp:TextBox ID="TextBox1" runat="server" visible="false"  MaxLength="11"></asp:TextBox></td>
                    <td> <asp:TextBox ID="TextBox2" runat="server" Visible="false" ></asp:TextBox></td>
                    <td> <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox></td>
                    <td> <asp:TextBox ID="TextBox4" runat="server" Visible="false"></asp:TextBox></td>
                    <td> <asp:TextBox ID="TextBox5" runat="server" Visible="false"></asp:TextBox></td>
          
                </th>
                   
            </ItemTemplate>
               
            <FooterTemplate>      
               </table>
            </FooterTemplate>                 
                </asp:Repeater>
            <div class="jumbotron" style="border:1px dashed;box-shadow : 5px 5px 5px silver;">
               <tr>
                   <td><b> Genel ortalama :</b></td>
                    <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
                   </tr>    
                                    
                </div>
                </div>
        </div>
       
        </div>
        
        
    </form>    
</body>
</html>
