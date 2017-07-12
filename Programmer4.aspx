<%@ Page Title="Programmer::" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Programmer4.aspx.cs" Inherits="Contact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="Scripts/sorttable.js"></script>
    <meta http-equiv="refresh" content="60" />
    <h1>  <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
        Input for Programmer</h1>


    <div style="margin-left: -100px ; margin-right:auto;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" OnRowDataBound="GridView1_DataBound" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <AlternatingRowStyle BackColor="#DCDCDC" />
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
    Machine Part is Nested for: 
    <asp:TextBox ID="MachineNum" runat="server" required="true"></asp:TextBox>
    <br />
    <br />
    Nest File Location:
    <asp:TextBox ID="fileLoca" runat="server" required ="true"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Finish_But" runat="server" Text="Finished" OnClick="Finish_But_Click" />
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
