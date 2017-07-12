<%@ Page Title="Needs Formed::"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="NeedsFormed.aspx.cs" Inherits="Contact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="Scripts/sorttable.js"></script>
    <meta http-equiv="refresh" content="300" />
   <h1> <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
    Needs Formed</h1>
    Programmers Initials <asp:textbox ID="PrInIT" runat="server"  required="true"></asp:textbox>

    <br />
    <asp:Button ID="Form_But" runat="server" OnClick="FormBut_Click" Text="Form Selected" />
  
    <br />
  
    <br />
    <div style="margin-left: -100px ; margin-right:auto;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" OnRowDataBound="GridView1_DataBound" BorderWidth="1px" CellPadding="3">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField>
                    <HeaderTemplate>   
                        <asp:CheckBox ID="chkAllSelect" runat="server" onclick="CheckAll(this);" />  
                    </HeaderTemplate>  
                    <ItemTemplate>  
                        <asp:CheckBox ID="chkSelect" runat="server"/>  
                    </ItemTemplate>  
                </asp:TemplateField>  
        </Columns>
                <EmptyDataTemplate>
            <asp:CheckBox ID="Selected" runat="server" Enabled="true"/>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#015F9F" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
  
    </div>
    

    <br />
    <asp:Button ID="Form_But0" runat="server" Text="Form Selected" OnClick="FormBut_Click" />
    <br />
  
    
    

<asp:TextBox ID="Needs_Box" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Large" Font-Underline="True" Width="240px"></asp:TextBox>
<br />
  
    
<script type="text/javascript">  
// for check all checkbox  
        function CheckAll(Checkbox) {  
            var GridVwHeaderCheckbox = document.getElementById("<%=GridView1.ClientID %>");  
            for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {  
                GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;  
            }  
        }  
    </script>  

</asp:Content>