<%@ Page Title="In Progress::" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InProgress.aspx.cs" Inherits="Contact" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="Scripts/sorttable.js"></script>
    <meta http-equiv="refresh" content="60" />
   <h1> <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
    In Progress</h1>
    <br />

    <div style="margin-left: -100px ; margin-right:auto;">
    <asp:GridView ID="Grid"  runat="server" class="sortable" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <AlternatingRowStyle BackColor="#DCDCDC" />
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
    <asp:Label ID="NoneLable" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large" Font-Underline="True" Text="No Parts Are In Process"></asp:Label>
  
<br />
  <div style="width:700px; margin:0 auto;" runat="server">
    <asp:LinkButton ID="P1" Text="Programmer 1" runat ="server" OnClick="P1_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="P2" Text="Programmer 2" runat ="server" OnClick="P2_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="P3" Text="Programmer 3" runat ="server" OnClick="P3_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="P4" Text="Programmer 4" runat ="server" OnClick="P4_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="P5" Text="Programmer 5" runat ="server" OnClick="P5_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="P6" Text="Programmer 6" runat ="server" OnClick="P6_Click"></asp:LinkButton>
    <br />
    </div>
    
  <div style=" width:350px; margin:0 auto;" runat="server">
    <asp:LinkButton ID="PB1" Text="PB 1" runat ="server" OnClick="PB1_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="PB2" Text="PB 2" runat ="server" OnClick="PB2_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="PB3" Text="PB 3" runat ="server" OnClick="PB3_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="PB4" Text="PB 4" runat ="server" OnClick="PB4_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="PB5" Text="PB 5" runat ="server" OnClick="PB5_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="PB6" Text="PB 6" runat ="server" OnClick="PB6_Click"></asp:LinkButton>
    <br />
      </div>

<script type="text/javascript">  
// for check all checkbox  
        function CheckAll(Checkbox) {  
            var GridVwHeaderCheckbox = document.getElementById("<%=Grid.ClientID %>");  
            for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {  
                GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;  
            }  
        }  
    </script>  
    
</asp:Content>
      


