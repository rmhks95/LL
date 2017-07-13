<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Home" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h1><%: Title %>
    <script src="Scripts/sorttable.js"></script>
        <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
         Search for Part </h1>
        <p class="lead">
            <br />
            Search:
            <asp:TextBox ID="PartNum" runat="server" required="true"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; in&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>Part Numbers</asp:ListItem>
                <asp:ListItem>Description</asp:ListItem>
            </asp:DropDownList>
        </p>
     <p class="lead">

         <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
        </p>
    <div style="margin-left: -100px ; margin-right:auto;">
     <p class="lead">

    <asp:GridView ID="GridView1" runat="server" class="sortable" OnRowDataBound="GridView1_DataBound" OnRowUpdating="TaskGridView_RowUpdating" OnRowCancelingEdit="TaskGridView_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ShowEditButton="True" Visible="true">
            <ItemStyle Font-Italic="True" Font-Underline="True" ForeColor="Black" />
            </asp:CommandField>
        </Columns>
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
    

            <asp:TextBox ID="Needs_Box" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Larger">No Parts Found</asp:TextBox>
         <br /> 
        <br />
        </p>
    


</asp:Content>

