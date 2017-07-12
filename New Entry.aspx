 <%@ Page Title="New Entry::" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="New Entry.aspx.cs" Inherits="About" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
    <p>&nbsp;</p>
   <h2> <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/Content/B&amp;W-Logo.jpg" Width="165px" />
    New Entry&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Copy_Lab" runat="server" Font-Bold="True" Font-Size="Medium" Text="Copy from part:"></asp:Label>
        <asp:TextBox ID="CNum_Box" runat="server" Height="22px" Width="205px" Font-Size="Small"></asp:TextBox>
&nbsp;<asp:Button ID="Get_but" runat="server" Font-Size="Small" Height="22px" Text="Get" Width="62px" formnovalidate="true" OnClick="Get_but_Click" />
&nbsp;<asp:Button ID="GP_But" runat="server" Font-Size="Small" Height="22px" Text="Get from previous" formnovalidate="true" Width="146px" OnClick="GP_But_Click" />
    </h2>
<html>
<head>
	<title>2 Column CSS Demo - Equal Height Columns with Cross-Browser CSS</title>
	<meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8" />
	<meta name="Description"" content="2 Column CSS Demo - Equal Height Columns with Cross-Browser CSS" />
	<meta name="keywords" content="2 Column CSS Demo - Equal Height Columns with Cross-Browser CSS" />
	<meta name="robots" content="index, follow" />
	<link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
	<style media="screen" type="text/css">
/* <!-- */
body {
	margin:0;
	padding:0;
}
#header h1,
#header h2,
#header p {
	margin-left:2%;
	padding-right:2%;
}
#active2 #tab2,
#active3 #tab3,
#active4 #tab4,
#active5 #tab5 {
	font-weight:bold;
	text-decoration:none;
	color:#000;
}
#footer {
	clear:both;
	float:left;
	width:100%;
}
#footer p {
	margin-left:2%;
	padding-right:2%;
}

/* Start of Column CSS */
#container2 {
	clear:left;
	float:left;
	width:100%;
	overflow:hidden;
	}
#container1 {
	float:left;
	width:100%;
	position:relative;
	right:50%;
	}

#container3 {
	clear:left;
	float:left;
	width:100%;
	overflow:hidden;
	}
#container4 {
	float:left;
	width:100%;
	position:relative;
	right:50%;
	}
#col1 {
	float:left;
	width:46%;
	position:relative;
	left:52%;
	overflow:hidden;
}
#col2 {
	float:left;
	width:46%;
	position:relative;
	left:56%;
	overflow:hidden;
}
#col3 {
	float:left;
	width:46%;
	position:relative;
	left:52%;
	overflow:hidden;
}
/* --> */
    </style>
</head>
<body>
    <asp:UpdatePanel ID="Info" runat="server">
        <ContentTemplate>
     <p>
         Function To Be Preformed: <asp:DropDownList ID="Function_Drop" runat="server" EnableViewState="true" OnSelectedIndexChanged="Function_Drop_SelectedIndexChanged" AutoPostBack="true" Height="19px" Width="561px">
            <asp:ListItem>2D: ECR REV/RELEASE</asp:ListItem>
            <asp:ListItem Selected="True">2D: NEST &amp; CUT</asp:ListItem>
            <asp:ListItem>2D: NEST, CUT, &amp; FORM</asp:ListItem>
            <asp:ListItem>2D: RE-CUT PART</asp:ListItem>
            <asp:ListItem>2D: RE-CUT, &amp; FORM PART</asp:ListItem>
            <asp:ListItem>2D: NEST EVAL</asp:ListItem>
            <asp:ListItem>3D: ECR REV/RELEASE </asp:ListItem>
            <asp:ListItem>3D: NEST &amp; CUT</asp:ListItem>
            <asp:ListItem>3D: RE-CUT PART</asp:ListItem>
            <asp:ListItem>3D: NEST EVAL</asp:ListItem>
            <asp:ListItem>PB: BEND EVAL</asp:ListItem>
        </asp:DropDownList>
   </p>
<div id="container2">
	<div id="container1">
		<div id="col1">
			<!-- Column one start -->
			<p>
                Initials:<asp:TextBox ID="Initials_Box" runat="server" Enabled="False" required="true"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
            </p>
            <p>
                Part Number:<asp:TextBox ID="Part_Num_Box" runat="server" Enabled="False" required="true"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
            </p>
            <p>
                Part Description:<asp:TextBox ID="Desc_Box" runat="server" Enabled="False" EnableTheming="True" required="true"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
            </p>
            <p>
                 Revision:<asp:TextBox ID="Rev_Box" runat="server" Enabled="False" required="true"></asp:TextBox>
                 <asp:Label ID="Label4" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
            </p>
            <p>
                Part Type: <asp:DropDownList ID="Type_Drop" runat="server" required="true" OnSelectedIndexChanged="Type_Drop_Changed" AutoPostBack="true" Enabled="False">
                    <asp:ListItem Selected="True">Prototype</asp:ListItem>
                    <asp:ListItem>Shop Use</asp:ListItem>
                    <asp:ListItem>Personal Project</asp:ListItem>
                    <asp:ListItem>ECR Release</asp:ListItem>
                    <asp:ListItem>ECR Revision</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>       
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label7" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
                <asp:Label ID="Type_Explain" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Type_Exp_Box" runat="server" Visible="False"></asp:TextBox>
            </p>
            <p>
                  Material: <asp:DropDownList ID="Mat_Drop" runat="server" required="true" EnableViewState="true" OnSelectedIndexChanged="Mat_Drop_Changed" AutoPostBack="true" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>22GA, CR</asp:ListItem>
                        <asp:ListItem>20GA, CR</asp:ListItem>
                        <asp:ListItem>18GA, CR</asp:ListItem>
                        <asp:ListItem>16GA, CR OR HR</asp:ListItem>
                        <asp:ListItem>14GA, P&amp;O</asp:ListItem>
                        <asp:ListItem>12GA, P&amp;O</asp:ListItem>
                        <asp:ListItem>11GA, P&amp;O</asp:ListItem>
                        <asp:ListItem>10GA P&amp;O</asp:ListItem>
                        <asp:ListItem>7GA P&amp;O</asp:ListItem>
                        <asp:ListItem>1/4&quot; P&amp;O</asp:ListItem>
                        <asp:ListItem>1/4&quot; HR</asp:ListItem>
                        <asp:ListItem>5/6&quot; HR</asp:ListItem>
                        <asp:ListItem>3/8&quot; HR</asp:ListItem>
                        <asp:ListItem>1/2&quot; P&amp;O</asp:ListItem>
                        <asp:ListItem>3/4&quot; HR</asp:ListItem>
                        <asp:ListItem>1&quot; HR</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                  <asp:Label ID="Label6" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
                 <asp:Label ID="Mat_Explain" runat="server" Text="Explain:" Visible="False"></asp:Label>
                 <asp:TextBox ID="Mat_Exp_Box" runat="server" required="true" Visible="False"></asp:TextBox>
            </p>
            <p>
                Quantity:<asp:TextBox ID="Quan_Box" runat="server" Enabled="False" required="true"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
            </p>
            <p>
                Product Line:<asp:DropDownList ID="Prod_Drop" runat="server" EnableViewState="true" OnSelectedIndexChanged="Prod_Drop_Changed" AutoPostBack="true" Enabled="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Farm &amp; Ranch</asp:ListItem>
                        <asp:ListItem>Balls</asp:ListItem>
                        <asp:ListItem>Ball Mounts</asp:ListItem>
                        <asp:ListItem>Cab Protector</asp:ListItem>
                        <asp:ListItem>Flat Bed</asp:ListItem>
                        <asp:ListItem>Gooseneck</asp:ListItem>
                        <asp:ListItem>Job Shop</asp:ListItem>
                        <asp:ListItem>Motorcycle Latch</asp:ListItem>
                        <asp:ListItem>RCVR Hitch</asp:ListItem>
                        <asp:ListItem>RV</asp:ListItem>
                        <asp:ListItem>GN Coupler</asp:ListItem>
                        <asp:ListItem>Tow/Stow</asp:ListItem>
                        <asp:ListItem>Bison</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                <asp:Label ID="Prod_Line_exp" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Prod_Ex_box" runat="server" Visible="False"></asp:TextBox>
            </p>
            <p>
                Department to Charge:<asp:DropDownList ID="Dept_Drop" runat="server" required="true" EnableViewState="true" OnSelectedIndexChanged="Dept_Drop_Changed" AutoPostBack="true" Enabled="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>R&amp;D Product Prototypes</asp:ListItem>
                    <asp:ListItem>Engineering, Testing</asp:ListItem>
                    <asp:ListItem>Production Equipment</asp:ListItem>
                    <asp:ListItem>Fixtures, Jigs, Tooling</asp:ListItem>
                    <asp:ListItem>Show Inventory</asp:ListItem>
                    <asp:ListItem>Marketing</asp:ListItem>
                    <asp:ListItem>Maintance</asp:ListItem>
                    <asp:ListItem>Safety</asp:ListItem>
                    <asp:ListItem>Quality</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label11" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
                <asp:Label ID="Dept_exp" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Dep_Ex_box" runat="server" Visible="False"></asp:TextBox>
            </p>
             <p>
                After Laser Cut: <asp:DropDownList ID="Las_drop" runat="server" required="true" OnSelectedIndexChanged="Las_drop_Changed" AutoPostBack="true" Enabled="False">
                        <asp:ListItem Selected="True">Place in R&amp;D Rack</asp:ListItem>
                        <asp:ListItem>Page Engineer, Then Place in R&amp;D Rack</asp:ListItem>
                        <asp:ListItem>To Press Brake</asp:ListItem>
                        <asp:ListItem>To R&amp;D Shop</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                 <asp:Label ID="Label9" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
                <br /><asp:Label ID="Aft_las_exp" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Las_Ex_box" runat="server" Visible="False"></asp:TextBox>
            </p>
            <p>
                After Press Brake: <asp:DropDownList ID="Pres_drop" runat="server" required="true" OnSelectedIndexChanged='Pres_drop_Changed' AutoPostBack="true" Enabled="False">
                        <asp:ListItem Selected="True">Page Engineer</asp:ListItem>
                        <asp:ListItem>To R&amp;D Rack</asp:ListItem>
                        <asp:ListItem>To R&amp;D Shop</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                <asp:Label ID="Label10" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
                <asp:Label ID="Aft_press_exp" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Pres_Ex_box" runat="server" Visible="False"></asp:TextBox>
            </p>
            
			<!-- Column one end -->
		</div>
		<div id="col2">
			<!-- Column two start -->
            <p>
                Cut Needed by:<asp:TextBox ID="Cut_Date" runat="server" Enabled="False"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="Need_Cal" runat="server" TargetControlID="Cut_Date" Format="M/d/yyyy" PopupButtonID="Image1"/>  
            </p>
            <p>
                Formed Needed by:<asp:TextBox ID="Form_Date" runat="server" Enabled="False"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Form_Date" Format="M/d/yyyy" PopupButtonID="Image1"/>  
            </p>
            <p>
                 Gas: <asp:DropDownList ID="Gas_Drop" runat="server" OnSelectedIndexChanged="Gas_Drop_Changed" AutoPostBack="true" Enabled="False">
                    <asp:ListItem Selected="True">Any</asp:ListItem>
                    <asp:ListItem>Oxygen</asp:ListItem>
                    <asp:ListItem>Nitrogen</asp:ListItem>
                    <asp:ListItem>Shop Air</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                     <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Gas_Exp" runat="server" Text="Explain:" Visible="False"></asp:Label>
                <asp:TextBox ID="Gas_Exp_Box" runat="server" Visible="False"></asp:TextBox>
            </p>
            <p>
                 Grain Restriction: <asp:DropDownList ID="Grain_drop" runat="server" Enabled="False">
                    <asp:ListItem>X</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem Selected="True">None</asp:ListItem>
                     <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Etch Lines: <asp:DropDownList ID="Etch_drop" runat="server" Enabled="False">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>Yes, to be created by Programmer</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Nest in Pairs:<asp:DropDownList ID="Pair_drop" runat="server" Enabled="False">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Restrictions on Pierces: <asp:DropDownList ID="Rescrit_drop" runat="server" Enabled="False">
                    <asp:ListItem>Yes, Not on Back Gauge Edge</asp:ListItem>
                    <asp:ListItem>Yes, See Print for Details</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Circle Correction:<asp:DropDownList ID="Circle_drop" runat="server" Enabled="False">
                    <asp:ListItem>Yes, All Holes</asp:ListItem>
                    <asp:ListItem>Yes, Only Holes Indicated on Print</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Seam of Tube Location Critical:<asp:DropDownList ID="Seam_Drop" runat="server" Enabled="False">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
            </p>

            <!-- Column two end -->
		</div>
	</div>

</div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="Files" runat="server" UpdateMode="Conditional">    
                    <ContentTemplate>     
<div id="container3">
	<div id="container4">
	    <div id="col3">
            <p>
                 
                    DXF or STEP File:<asp:Label ID="Label5" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label> 
                <asp:Label ID="dxfSp" runat="server" Visible="false" ForeColor="Red" Text ="FILE NOT FOUND"></asp:Label>
                 &nbsp;<asp:Label ID="dxfPath" runat="server" Text ="must be in S:/Documents/Programming"></asp:Label>
            &nbsp;<asp:FileUpload ID="DXF_Up" runat="server" required="true" Enabled="False" accept=".dxf,.step,.stp" />
            </p>
            <p>
                PDF File: <asp:Label ID="pdfSp" runat="server" Visible="false" ForeColor="Red" Text ="FILE NOT FOUND"></asp:Label>
                 &nbsp;<asp:Label ID="pdfPath" runat="server"  Text ="must be in S:/Workforce Share"></asp:Label>
                <asp:FileUpload ID="PDF_Up" runat="server" Enabled="False" accept=".pdf" />
                  
            </p>
        </div>
        </div>
    </div>

                    </ContentTemplate> 

                </asp:UpdatePanel> 
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             Notes to Programmer:<asp:TextBox ID="Notes_Box" runat="server" Width="900px" Height="42px"></asp:TextBox>

     <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label12" runat="server" ForeColor="Red" Height="25px" Text="*"></asp:Label>
    Required<br />
    <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Submit_Button" runat="server" OnClick="Button1_Click" Text="Submit"/>
	&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SC_But" runat="server" Font-Bold="True" Text="Submit &amp; Copy" onclick="SC_But_Click"/>
	</p>
   
 </asp:Content>


