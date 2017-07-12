<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h1><%: Title %>
    <script src="Scripts/sorttable.js"></script>
    <meta http-equiv="refresh" content="60" />
        <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
         CNC Laser Log</h1>
        
    Display:
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>100</asp:ListItem>
                <asp:ListItem>500</asp:ListItem>
                <asp:ListItem>All</asp:ListItem>
            </asp:DropDownList>
    
<div style="margin-left: -100px ; margin-right:auto;">

    <p class="lead">
    <asp:GridView ID="GridView1" runat="server" class="sortable" OnRowDataBound="GridView1_DataBound" OnRowUpdating="TaskGridView_RowUpdating" OnRowCancelingEdit="TaskGridView_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle Font-Bold="False" Font-Italic="True" Font-Underline="True" ForeColor="Black" />
                <FooterStyle ForeColor="Black" />
                <HeaderStyle ForeColor="Black" />
                <ItemStyle ForeColor="Black" />
            </asp:TemplateField>
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
    </p>
    
    </div>

        
     <p class="lead">

    
    

            <asp:TextBox ID="Needs_Box" runat="server"></asp:TextBox>
         <br /> 
        <br />
        </p>
    


</asp:Content>

