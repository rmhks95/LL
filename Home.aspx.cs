using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Home : System.Web.UI.Page
{
    static int total;
    int showing;
    public string[,] needs = new string[total, 31];
    string[,] display = new string[total, 31];


    /// <summary>
    /// Main method that gets parts and displays in table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        total = CountParts();
        showing = Show();
        Start();
    }

    protected void Start()
    {

        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
            yep.Close();
        }


        needs = new string[total, 31];
        display = new string[total, 31];
        string[] split = new string[(total * 31)];
        StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt"));
        int toUse = 0;
        string line;
        for (int i = 0; i < total; i++)
        {


            line = SR.ReadLine();
            if (line != null)
            {
                split = line.Split('|');
                int use;
                if (split.Length < 31)
                    use = split.Length;
                else
                    use = 31;

                for (int j = 0; j < use; j++)
                {
                    needs[i, j] = split[j];
                }
                if (toUse == 0)
                {
                    needs[i, 28] = "Needs Nested";
                }
                else if (toUse == 1)
                {
                    needs[i, 28] = "Needs Formed";
                }
                else if (toUse == 2)
                {
                    needs[i, 28] = "In Progress";
                }
                else if (toUse == 3)
                {
                    needs[i, 28] = "Finished Nested";

                }
                else if (toUse == 4)
                {
                    needs[i, 28] = "Finished Formed";

                }
                //needs = (string[,])Session["nest"];

            }
            else
            {
                toUse++;
                switch (toUse)
                {
                    case 1:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt"));
                        break;
                    case 2:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt"));
                        break;
                    case 3:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt"));
                        break;
                    case 4:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
                        break;
                    case 5:
                        //SR.Close();
                        break;
                }


            }
        }
        SR.Close();

        string[] open = new string[total];
        List<string> closed = new List<string>();
        for (int i = 0; i < total; i++)
        {
            if (needs[i, 0] != null)
            {
                open[i] = needs[i, 0];
            }
        }

        foreach (string date in open)
        {
            if (date != null)
                closed.Add(date);
        }



        List<DateTime> dates = closed.Select(date => DateTime.Parse(date)).ToList();

        dates.Sort((a, b) => b.CompareTo(a));


        display = new string[showing, 31];
        int p = 0;

                foreach (var date in dates)
                {
                    for (int h = total - 1; h > -1; h--)
                    {
                        if (p < showing)
                        {
                            if (date.ToString() == needs[h, 0])
                            {
                                for (int q = 0; q < 31; q++)
                                {
                                    display[p, q] = needs[h, q];
                                }
                                needs[h, 0] = "";

                                p++;
                            }

                        }
                    }
        }
        loadTable(display);
    }
    protected void loadTable(string[,] display) { 
        if (display[0, 0] != null)
        {
            Needs_Box.Visible = false;
            Session["array"] = display;
            DataTable dt2 = new DataTable("test");

            // DataColumn you can use constructor DataColumn(name,type);
            DataColumn dc0 = new DataColumn("Status");
            DataColumn dc1 = new DataColumn("Date Entered");
            DataColumn dc2 = new DataColumn("Function");
            DataColumn dc3 = new DataColumn("Engineer");
            DataColumn dc4 = new DataColumn("Description");
            DataColumn dc5 = new DataColumn("Part Num.");
            DataColumn dc6 = new DataColumn("Qty");
            DataColumn dc7 = new DataColumn("Rev");
            DataColumn dc8 = new DataColumn("Cut by Date");
            DataColumn dc9 = new DataColumn("Form by Date");
            DataColumn dc10 = new DataColumn("Part Type");
            DataColumn dc11 = new DataColumn("Material");
            DataColumn dc12 = new DataColumn("Gas");
            DataColumn dc14 = new DataColumn("Grain Rest.");
            DataColumn dc15 = new DataColumn("Etch Lines");
            DataColumn dc16 = new DataColumn("Tube Seam");
            DataColumn dc17 = new DataColumn("Nest in Pairs");
            DataColumn dc18 = new DataColumn("Product Line");
            DataColumn dc19 = new DataColumn("Charge To:");
            DataColumn dc20 = new DataColumn("Pierce Rest.");
            DataColumn dc21 = new DataColumn("Circle Corr.");
            DataColumn dc22 = new DataColumn("After Cut");
            DataColumn dc23 = new DataColumn("After Form");
            DataColumn dc24 = new DataColumn("DXF");
            DataColumn dc25 = new DataColumn("PDF");
            DataColumn dc26 = new DataColumn("Program Notes");
            DataColumn dc27 = new DataColumn("Programmer");
            DataColumn dc28 = new DataColumn("Nest File");
            DataColumn dc29 = new DataColumn("Date Nested");
            DataColumn dc30 = new DataColumn("Machine");


            dt2.Columns.Add(dc0);
            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc11);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc29);
            dt2.Columns.Add(dc18);
            dt2.Columns.Add(dc27);
            dt2.Columns.Add(dc19);
            dt2.Columns.Add(dc30);
            dt2.Columns.Add(dc7);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);
            dt2.Columns.Add(dc12);
            dt2.Columns.Add(dc14);
            dt2.Columns.Add(dc15);
            dt2.Columns.Add(dc17);
            dt2.Columns.Add(dc20);
            dt2.Columns.Add(dc21);
            dt2.Columns.Add(dc16);
            dt2.Columns.Add(dc22);
            dt2.Columns.Add(dc23);
            dt2.Columns.Add(dc24);
            dt2.Columns.Add(dc25);
            dt2.Columns.Add(dc26);
            dt2.Columns.Add(dc28);

            int show;
            if (display.Length / 31 > 0)
                show = (display.Length / 31);
            else
                show = 1;

            for (int i = 0; i < show; i++)
            {
                if (display[i, 0] != null)
                {

                    DataRow dr = dt2.NewRow();
                    dr["Status"] = display[i, 28];
                    dr["Date Entered"] = display[i, 0];
                    dr["Function"] = display[i, 1];
                    dr["Engineer"] = display[i, 2];
                    dr["Description"] = display[i, 3];
                    dr["Part Num."] = display[i, 4];
                    dr["Qty"] = display[i, 5];
                    dr["Rev"] = display[i, 6];
                    dr["Cut by Date"] = display[i, 7];
                    dr["Form by Date"] = display[i, 8];
                    dr["Part Type"] = display[i, 9];
                    dr["Material"] = display[i, 10];
                    dr["Gas"] = display[i, 11];
                    dr["Grain Rest."] = display[i, 13];
                    dr["Etch Lines"] = display[i, 14];
                    dr["Tube Seam"] = display[i, 15];
                    dr["Nest in Pairs"] = display[i, 16];
                    dr["Product Line"] = display[i, 17];
                    dr["Charge To:"] = display[i, 18];
                    dr["Pierce Rest."] = display[i, 19];
                    dr["Circle Corr."] = display[i, 20];
                    dr["After Cut"] = display[i, 21];
                    dr["After Form"] = display[i, 22];
                    dr["DXF"] = display[i, 23];
                    dr["PDF"] = display[i, 24];
                    dr["Program Notes"] = display[i, 25];
                    if (display[i, 27] != null)
                    {
                        dr["Programmer"] = display[i, 27];
                    }
                    if (display[i, 26] != null)
                    {
                        dr["Nest File"] = display[i, 26];
                    }
                    dr["Date Nested"] = display[i, 29];
                    dr["Machine"] = display[i, 30];
                    //GridView1.Columns.Insert(0, checkBox);
                    dt2.Rows.Add(dr);
                }
            }

            GridView1.DataSource = dt2;
            Session["dt2"] = dt2;
            if (!IsPostBack)
                GridView1.DataBind();

        }
        else
        {
            Needs_Box.Text = "No Parts";
        }
    }


    protected int Show()
    {
        int picked;


        if (DropDownList1.Text == "100")
        {
            picked = 100;
        }
        else if (DropDownList1.Text == "500")
        {
            picked = 500;
        }
        else
        {
            picked = CountParts();
        }

        return picked;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        showing = Show();
        BindData();
    }


    /// <summary>
    /// Finds How many parts exist
    /// </summary>
    /// <returns></returns>
    protected int CountParts()
    {
        int total = 0;
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt")).Count() + 5;
    return (total);
    }


    /// <summary>
    /// Colors parts based on location & Hyperlinks
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string location = (e.Row.Cells[1].Text);
            string type;
            string dxf = (e.Row.Cells[27].Text);
            if (dxf != "&nbsp;" && dxf != "")
            {
                type = dxf.Substring(dxf.Length - 3);
                HyperLink dxfLink = new HyperLink();
                dxfLink.NavigateUrl = dxf;
                if (type == "stp")
                {

                    dxfLink.Text = "STEP";
                }
                else
                {

                    dxfLink.Text = "DXF";
                }
                e.Row.Cells[27].Controls.Add(dxfLink);
            }


            string pdf = (e.Row.Cells[28].Text);
            if(pdf != "&nbsp;" && pdf != "")
            { 
                HyperLink pdfLink = new HyperLink();
                pdfLink.NavigateUrl = pdf;
                pdfLink.Text = "PDF";
                pdfLink.Target = "_blank";
                e.Row.Cells[28].Controls.Add(pdfLink);
            }


            foreach (TableCell cell in e.Row.Cells)
            {

                if (location.Equals("In Progress"))
                {
                    cell.BackColor = Color.FromArgb(0, 252, 252, 100);
                }
                else if (location.Equals("Needs Nested") || location.Equals("Needs Formed"))
                {
                    cell.BackColor = Color.IndianRed;
                }
                else if (location.Equals("Finished Nested") || location.Equals("Finished Formed"))
                {
                    cell.BackColor = Color.LightGreen;
                }
                
            }
        }
    }


    /// <summary>
    /// Gets row number and calls bind data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       //GridView1.PageIndex = e.NewEditIndex;
       GridView1.EditIndex = e.NewEditIndex;
       BindData();
    }

    /// <summary>
    /// Cancels row edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TaskGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        GridView1.EditIndex = -1;
        //Bind data to the GridView control.
        BindData();
    }

    /// <summary>
    /// Edits part from textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["dt2"];
       
            //Update the values.
            GridViewRow row = GridView1.Rows[e.RowIndex];

        int selected = e.RowIndex;

            display= (string[,])Session["array"];
            display[selected,2] = ((TextBox)(row.Cells[5].Controls[0])).Text;
            display[selected,3] = ((TextBox)(row.Cells[4].Controls[0])).Text;
            display[selected,4] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            display[selected,5] = ((TextBox)(row.Cells[8].Controls[0])).Text;
            display[selected,6] = ((TextBox)(row.Cells[15].Controls[0])).Text;
            display[selected,7] = ((TextBox)(row.Cells[16].Controls[0])).Text;
            display[selected,8] = ((TextBox)(row.Cells[17].Controls[0])).Text;
            display[selected,9] = ((TextBox)(row.Cells[9].Controls[0])).Text;
            display[selected,10] = ((TextBox)(row.Cells[6].Controls[0])).Text;
            display[selected,11] = ((TextBox)(row.Cells[18].Controls[0])).Text;
            display[selected,13] = ((TextBox)(row.Cells[19].Controls[0])).Text;
            display[selected,14] = ((TextBox)(row.Cells[20].Controls[0])).Text;
            display[selected,15] = ((TextBox)(row.Cells[24].Controls[0])).Text;
            display[selected,16] = ((TextBox)(row.Cells[21].Controls[0])).Text;
            display[selected,17] = ((TextBox)(row.Cells[11].Controls[0])).Text;
            display[selected,18] = ((TextBox)(row.Cells[13].Controls[0])).Text;
            display[selected,19] = ((TextBox)(row.Cells[22].Controls[0])).Text;
            display[selected,20] = ((TextBox)(row.Cells[23].Controls[0])).Text;
            display[selected,21] = ((TextBox)(row.Cells[25].Controls[0])).Text;
            display[selected,22] = ((TextBox)(row.Cells[26].Controls[0])).Text;
            display[selected,23] = ((TextBox)(row.Cells[27].Controls[0])).Text;
            display[selected,24] = ((TextBox)(row.Cells[28].Controls[0])).Text;
            display[selected,25] = ((TextBox)(row.Cells[29].Controls[0])).Text;
            //dt.Rows[row.DataItemIndex]["Nest File"] = ((TextBox)(row.Cells[29].Controls[0])).Text;
            //dt.Rows[row.DataItemIndex]["IsComplete"] = ((CheckBox)(row.Cells[3].Controls[0])).Checked;
            
            //Reset the edit index.
            GridView1.EditIndex = -1;

            //Bind data to the GridView control.
            FixLists(display, selected);
            Page_Load(null, null);
            BindData();
    }

    /// <summary>
    /// Sets table source and binds it
    /// </summary>
    protected void BindData()
    {
        GridView1.DataSource = Session["dt2"];
        GridView1.DataBind();
    }


    /// <summary>
    /// Updates files to new inputs
    /// </summary>
    /// <param name="use"></param>
    protected void FixLists(string[,] use, int selected)
    {

        string location = use[selected, 28];
        string[] split = new string[(total * 31)];
        if (location.Equals("Needs Nested"))
        {
            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")))
            {
                string line;
                for (int i = 0; i < total; i++)
                {


                    line = SR.ReadLine();
                    if (line != null)
                    {
                        split = line.Split('|');
                        if (split[0] != use[selected, 0])
                        {
                            for (int j = 0; j < split.Length - 1; j++)
                            {
                                needs[i, j] = split[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 30 - 1; j++)
                            {
                                needs[i, j] = use[selected, j];
                            }
                        }
                    }
                }
            }
            var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt"));
            fole1.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt"), true))
            {
                for (int i = 0; i < total; i++)
                {
                    string output = "";
                    if (needs[i, 0] != null && needs[i, 0] != "")
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            output += needs[i, j] + "|";
                        }
                        sw.WriteLine(output);
                    }

                }
                sw.Close();
            }

        }
        else if (location.Equals("Needs Formed"))
        {
            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")))
            {
                string line;
                for (int i = 0; i < total; i++)
                {

                    line = SR.ReadLine();
                    if (line != null)
                    {
                        split = line.Split('|');
                        if (split[0] != use[selected, 0])
                        {
                            for (int j = 0; j < split.Length - 1; j++)
                            {
                                needs[i, j] = split[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 30 - 1; j++)
                            {
                                needs[i, j] = use[selected, j];
                            }
                        }
                    }
                }
            }
            var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt"));
            fole1.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt"), true))
            {
                for (int i = 0; i < total; i++)
                {
                    string output = "";
                    if (needs[i, 0] != null && needs[i, 0] != "")
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            output += needs[i, j] + "|";
                        }
                        sw.WriteLine(output);
                    }

                }
                sw.Close();
            }
        }
        else if (location.Equals("In Progress"))
        {
            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")))
            {
                string line;
                for (int i = 0; i < total; i++)
                {


                    line = SR.ReadLine();
                    if (line != null)
                    {
                        split = line.Split('|');
                        if (split[0] != use[selected, 0])
                        {
                            for (int j = 0; j < split.Length - 1; j++)
                            {
                                needs[i, j] = split[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 30-1; j++)
                            {
                                needs[i, j] = use[selected, j];
                            }
                        }
                    }
                }
            }
            var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt"));
            fole1.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt"), true))
            {
                for (int i = 0; i < total; i++)
                {
                    string output = "";
                    if (needs[i, 0] != null && needs[i, 0] != "")
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            output += needs[i, j] + "|";
                        }
                        sw.WriteLine(output);
                    }

                }
                sw.Close();
            }
        }
        else if ((location.Equals("Finished Nested")))
        {
            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt")))
            {
                string line;
                for (int i = 0; i < total; i++)
                {


                    line = SR.ReadLine();
                    if (line != null)
                    {
                        split = line.Split('|');
                        if (split[0] != use[selected, 0])
                        {
                            for (int j = 0; j < split.Length - 1; j++)
                            {
                                needs[i, j] = split[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 31 ; j++)
                            {
                                needs[i, j] = use[selected, j];
                            }
                        }
                    }
                }
            }
            var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt"));
            fole1.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt"), true))
            {
                for (int i = 0; i < total; i++)
                {
                    string output = "";
                    if (needs[i, 0] != null && needs[i, 0] != "")
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            output += needs[i, j] + "|";
                        }
                        sw.WriteLine(output);
                    }

                }
                sw.Close();
            }
        }

         else
        {
            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")))
            {
                string line;
                for (int i = 0; i < total; i++)
                {


                    line = SR.ReadLine();
                    if (line != null)
                    {
                        split = line.Split('|');
                        if (split[0] != use[selected, 0])
                        {
                            for (int j = 0; j < split.Length - 1; j++)
                            {
                                needs[i, j] = split[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                needs[i, j] = use[selected, j];
                            }
                        }
                    }
                }
            }
            var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
            fole1.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"), true))
            {
                for (int i = 0; i < total; i++)
                {
                    string output = "";
                    if (needs[i, 0] != null && needs[i, 0] != "")
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            output += needs[i, j] + "|";
                        }
                        sw.WriteLine(output);
                    }

                }
                sw.Close();
            }
        }
    }

}




