<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Home" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <h1><%: Title %>
    <script src="Scripts/sorttable.js"></script>
    <meta http-equiv="refresh" content="60" />
        <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
         CNC Laser Log</h1>
        
    <div id="LoginDiv" runat="server" Visible="true">
        <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Button ID="LoginButton" runat="server" Text="Submit" OnClick="LoginButton_Click" /></div>


<div id ="MainDiv" runat="server" visible="false" style="margin-left: -100px ; margin-right:auto;">
    <p class="lead">
	 Date: <asp:TextBox ID="Exp_Date" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="Need_Cal" runat="server" TargetControlID="Exp_Date" Format="M/d/yyyy" PopupButtonID="Image1"/>  
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Export_But" runat="server" OnClick="Export_But_Click" Text="Export" />
    <asp:GridView ID="GridView1" runat="server" class="sortable" OnRowDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle Font-Italic="True" Font-Underline="True" ForeColor="Black" />
                <HeaderStyle Font-Italic="True" Font-Underline="True" ForeColor="Black" />
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
  
    
    

            <asp:TextBox ID="Needs_Box" runat="server"></asp:TextBox>
         <br /> 
        <br />
        </p>
    
 </div>

</asp:Content>

