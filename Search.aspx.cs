using System;
using System.Linq;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class Home : System.Web.UI.Page
{
    static int total;
    public string[,] needs = new string[total, 31];
    string[,] display = new string[total, 31];
    string[,] found = new string[total, 31];


    /// <summary>
    /// Main method, that gets and displays the parts
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        total = CountParts();

        needs = new string[total, 31];
        display = new string[total, 31];
        found = new string[total,31];


        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsNested.txt")))
        {
            var yep= File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsNested.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsFormed.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsFormed.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/Finished.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/Finished.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
            yep.Close();
        }
        string[] split = new string[total];
        StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsNested.txt"));
        int toUse = 0;
        string line;
        int m = 0;
        for (int i = 0; i < total; i++)
        {
            if (toUse == 0)
            {
                needs[i, 28] = "Needs Nested";
            }
            else if (toUse == 1)
            {
                needs[i, 28] = "Needs Formed";
            }
            else if(toUse == 2)
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


            line = SR.ReadLine();
            if (line != null)
            {
                m = 0;
                split = line.Split('|');

                for (int j = 0; j < 31; j++)
                {
                    if ((split.Length - 2) >= m)
                    {
                        if (j != 28)
                        {
                            needs[i, j] = split[m];
                        }
                        m++;
                        //needs = (string[,])Session["nest"];
                    }
                }
            }
            else
            {
                toUse++;
                switch (toUse)
                {
                    case 1:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsFormed.txt"));
                        break;
                    case 2:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt"));
                        break;
                    case 3:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/Finished.txt"));
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


        string[] open = new string[(total * 31)];
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


        display = new string[total, 31];
        int p = 0;
        int n = open.Length - 1;
        while (n > -1)
        {
            foreach (var date in dates)
            {
                for (int h = total - 1; h > -1; h--)
                {
                    if (p < total)
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
            n = n - 1;
        }

        if (DropDownList1.Text == "All")
            found = findAll(display);
        else if (DropDownList1.Text == "Part Numbers")
            found = findPN(display);
        else
        {
            found = findDS(display);
        }

        if (found[0, 0] != null && PartNum.Text != "")
        {
            
            GridView1.Visible = true;
            Session["array"] = found;

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

            for (int i = 0; i < total; i++)
            {
                if (found[i, 0] != null)
                {

                    DataRow dr = dt2.NewRow();
                    dr["Status"] = found[i, 28];
                    dr["Date Entered"] = found[i, 0];
                    dr["Function"] = found[i, 1];
                    dr["Engineer"] = found[i, 2];
                    dr["Description"] = found[i, 3];
                    dr["Part Num."] = found[i, 4];
                    dr["Qty"] = found[i, 5];
                    dr["Rev"] = found[i, 6];
                    dr["Cut by Date"] = found[i, 7];
                    dr["Form by Date"] = found[i, 8];
                    dr["Part Type"] = found[i, 9];
                    dr["Material"] = found[i, 10];
                    dr["Gas"] = found[i, 11];
                    dr["Grain Rest."] = found[i, 13];
                    dr["Etch Lines"] = found[i, 14];
                    dr["Tube Seam"] = found[i, 15];
                    dr["Nest in Pairs"] = found[i, 16];
                    dr["Product Line"] = found[i, 17];
                    dr["Charge To:"] = found[i, 18];
                    dr["Pierce Rest."] = found[i, 19];
                    dr["Circle Corr."] = found[i, 20];
                    dr["After Cut"] = found[i, 21];
                    dr["After Form"] = found[i, 22];
                    dr["DXF"] = found[i, 23];
                    dr["PDF"] = found[i, 24];
                    dr["Program Notes"] = found[i, 25];
                    if (found[i, 27] != null)
                    {
                        dr["Programmer"] = found[i, 27];
                    }
                    if (found[i, 26] != null)
                    {
                        dr["Nest File"] = found[i, 26];
                    }
                    dr["Date Nested"] = found[i, 29];
                    dr["Machine"] = found[i, 30];
                    //GridView1.Columns.Insert(0, checkBox);
                    dt2.Rows.Add(dr);
                }
            }

            GridView1.DataSource = dt2;

            Session["dt2"] = dt2;

            if (!IsPostBack) { GridView1.DataBind(); }
                

            Needs_Box.Visible = false;
        }
        else
        {
            Needs_Box.Visible = true;
            GridView1.Visible = false;
        }
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
    /// Finds the part in the array of parts
    /// </summary>
    /// <param name="display"> Array of Parts </param>
    /// <returns></returns>
   /* protected string[,] find(string[,] display)
    {
        int o = 0;
        for (int i = 0; i < total; i++)
        {
            if (display[i, 4] == (PartNum.Text))
            {
                for (int j = 0; j < 31; j++)
                {
               
                    found[o, j] = display[i, j];
                }
                o++;
            }
        }
        return found;
    }
    */

    protected string[,] findPN(string [,] display)
    {
        string[] check = new string[32];
        int o = 0;
        for (int k = 0; k < (display.Length / 31); k++)
        {
            if (display[k, 0] != null)
            {
                for (int z = 0; z < 31; z++)
                {
                    check[z] = display[k, 4];
                }


                for (int p = 0; p < 31; p++)
                {
                    if (check[p] != null)
                    {
                        if (check[p].ToLower().Contains(PartNum.Text.ToLower()))
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                found[o, j] = display[k, j];
                            }
                            o++;
                            break;
                        }
                    }

                }


            }

        }
        return found;
    }


    protected string[,] findDS(string[,] display)
    {
        string[] check = new string[32];
        int o = 0;
        for (int k = 0; k < (display.Length / 31); k++)
        {
            if (display[k, 0] != null)
            {
                for (int z = 0; z < 31; z++)
                {
                    check[z] = display[k, 3];
                }


                for (int p = 0; p < 31; p++)
                {
                    if (check[p] != null)
                    {
                        if (check[p].ToLower().Contains(PartNum.Text.ToLower()))
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                found[o, j] = display[k, j];
                            }
                            o++;
                            break;
                        }
                    }

                }


            }

        }
        return found;
    }
    protected string[,] findAll(string [,] display)
    {
        string[] check = new string[32];
        int o = 0;
        for (int k = 0; k < (display.Length/31); k++)
        {
            if (display[k, 0] != null)
            {
                for(int z = 0; z<31; z++)
                {
                    check[z] = display[k, z];
                }


                for(int p=0; p<31; p++)
                {
                    if (check[p] != null)
                    {
                        if (check[p].ToLower().Contains(PartNum.Text.ToLower()))
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                found[o, j] = display[k, j];
                            }
                            o++;
                            break;
                        }
                    }
                   
                }

                
            }
            
        }
        return found;
    }




    /// <summary>
    /// Colors the Cells based on location
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string location = (e.Row.Cells[1].Text);

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
    /// Gets row index, then calls BindData()
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
    /// Cancels the editing
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
    /// Updates the row to what is inputed in the textboxes
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

        display = (string[,])Session["array"];
        display[selected, 2] = ((TextBox)(row.Cells[5].Controls[0])).Text;
        display[selected, 3] = ((TextBox)(row.Cells[4].Controls[0])).Text;
        display[selected, 4] = ((TextBox)(row.Cells[3].Controls[0])).Text;
        display[selected, 5] = ((TextBox)(row.Cells[8].Controls[0])).Text;
        display[selected, 6] = ((TextBox)(row.Cells[15].Controls[0])).Text;
        display[selected, 7] = ((TextBox)(row.Cells[16].Controls[0])).Text;
        display[selected, 8] = ((TextBox)(row.Cells[17].Controls[0])).Text;
        display[selected, 9] = ((TextBox)(row.Cells[9].Controls[0])).Text;
        display[selected, 10] = ((TextBox)(row.Cells[6].Controls[0])).Text;
        display[selected, 11] = ((TextBox)(row.Cells[18].Controls[0])).Text;
        display[selected, 13] = ((TextBox)(row.Cells[19].Controls[0])).Text;
        display[selected, 14] = ((TextBox)(row.Cells[20].Controls[0])).Text;
        display[selected, 15] = ((TextBox)(row.Cells[24].Controls[0])).Text;
        display[selected, 16] = ((TextBox)(row.Cells[21].Controls[0])).Text;
        display[selected, 17] = ((TextBox)(row.Cells[11].Controls[0])).Text;
        display[selected, 18] = ((TextBox)(row.Cells[13].Controls[0])).Text;
        display[selected, 19] = ((TextBox)(row.Cells[22].Controls[0])).Text;
        display[selected, 20] = ((TextBox)(row.Cells[23].Controls[0])).Text;
        display[selected, 21] = ((TextBox)(row.Cells[25].Controls[0])).Text;
        display[selected, 22] = ((TextBox)(row.Cells[26].Controls[0])).Text;
        display[selected, 23] = ((TextBox)(row.Cells[27].Controls[0])).Text;
        display[selected, 24] = ((TextBox)(row.Cells[28].Controls[0])).Text;
        display[selected, 25] = ((TextBox)(row.Cells[29].Controls[0])).Text;
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
    /// Gives table a source and then Binds it
    /// </summary>
    protected void BindData()
    {
        GridView1.DataSource = Session["dt2"];
        GridView1.DataBind();
    }

    /// <summary>
    /// Fixs part in file
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
        else if(location.Equals("Needs Formed"))
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
        else if(location.Equals("In Progress"))
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
                            for (int j = 0; j < 30 - 1; j++)
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
        else if(location.Equals("Finished Nested"))
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
                            for (int j = 0; j < 30 - 1; j++)
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
                            for (int j = 0; j < 30 - 1; j++)
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



    protected void Search_Click(object sender, EventArgs e)
    {
        Page_Load(null, null);
        BindData();
    }
}