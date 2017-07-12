using System;
using System.Linq;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class Home : System.Web.UI.Page
{
    static int total;
    public string[,] needs = new string[total, 31];
    string[,] display = new string[total, 31];

    /// <summary>
    /// Checks to make sure password matches
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
        if (PasswordTextBox.Text == "Password")
        {
            MainDiv.Visible = true;
            LoginDiv.Visible = false;
        }
    }

    /// <summary>
    /// Main method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        total = CountParts();

        needs = new string[total, 31];
        display = new string[total, 31];

        if (!Page.IsPostBack)
        {
            display = LoadFiles();
            LoadTable(display);
        }  
    }


    /// <summary>
    /// Finds How many parts exist
    /// </summary>
    /// <returns></returns>
    protected int CountParts()
    {
        int total = 0;
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsNested.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsFormed.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\InProgress.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\FinishedPB.txt")).Count();
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Finished.txt")).Count() + 5;
        return (total);
    }

    /// <summary>
    /// Loads all of parts
    /// </summary>
    protected string[,] LoadFiles() { 
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsNested.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsNested.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsFormed.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsFormed.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\InProgress.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\InProgress.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Finished.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Finished.txt"));
            yep.Close();
        }
        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
            yep.Close();
        }
		
        string[] split = new string[3900];
        StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsNested.txt"));
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
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsFormed.txt"));
                        break;
                    case 2:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\InProgress.txt"));
                        break;
                    case 3:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Finished.txt"));
                        break;
                    case 4:
                        SR.Close();
                        SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\FinishedPB.txt"));
                        break;
					case 5:
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
            if (date != null && date != "")
                closed.Add(date);
        }



        List<DateTime> dates = closed.Select(date => DateTime.Parse(date)).ToList();

        dates.Sort((a, b) => b.CompareTo(a));


        display = new string[total, 31];
        int p = 0;
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
        return display;
    }
    
    /// <summary>
    /// Puts parts in Chart
    /// </summary>
    /// <param name="display"> Array of parts </param>
    protected void LoadTable(string[,] display) { 

        if (display[0, 0] != null)
        {
            Needs_Box.Visible = false;
            Session["array"] = display;
            DataTable dt2 = new DataTable("test");

            // DataColumn you can use constructor DataColumn(name,type);
            DataColumn dc0 = new DataColumn("Location");
            DataColumn dc1 = new DataColumn("Date Entered");
            DataColumn dc2 = new DataColumn("Function");
            DataColumn dc3 = new DataColumn("Engineer's Initials");
            DataColumn dc4 = new DataColumn("Part Description");
            DataColumn dc5 = new DataColumn("Part Number");
            DataColumn dc6 = new DataColumn("Quantity");
            DataColumn dc7 = new DataColumn("Revision");
            DataColumn dc8 = new DataColumn("Cut by Date");
            DataColumn dc9 = new DataColumn("Form by Date");
            DataColumn dc10 = new DataColumn("Type of Part");
            DataColumn dc11 = new DataColumn("Material");
            DataColumn dc12 = new DataColumn("Gas");
            DataColumn dc13 = new DataColumn("Priority");
            DataColumn dc14 = new DataColumn("Grain Restrictions");
            DataColumn dc15 = new DataColumn("Etch Lines");
            DataColumn dc16 = new DataColumn("Seam of Tube Location Critical");
            DataColumn dc17 = new DataColumn("Nest in Pairs");
            DataColumn dc18 = new DataColumn("Product Line");
            DataColumn dc19 = new DataColumn("Department to Charge");
            DataColumn dc20 = new DataColumn("Restirctions on Pierces");
            DataColumn dc21 = new DataColumn("Circle Correction");
            DataColumn dc22 = new DataColumn("After Laser Cut");
            DataColumn dc23 = new DataColumn("After Press Brake");
            DataColumn dc24 = new DataColumn("DXF");
            DataColumn dc25 = new DataColumn("PDF");
            DataColumn dc26 = new DataColumn("Notes for Programmer");
            DataColumn dc27 = new DataColumn("Programmer's Initials");
            DataColumn dc28 = new DataColumn("Nest File Location");
            DataColumn dc29 = new DataColumn("Date Nested");
            DataColumn dc30 = new DataColumn("Machine Progrmaed For");


            dt2.Columns.Add(dc0);
            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc29);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc27);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc30);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc7);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc11);
            dt2.Columns.Add(dc12);
            dt2.Columns.Add(dc13);
            dt2.Columns.Add(dc14);
            dt2.Columns.Add(dc15);
            dt2.Columns.Add(dc16);
            dt2.Columns.Add(dc17);
            dt2.Columns.Add(dc18);
            dt2.Columns.Add(dc19);
            dt2.Columns.Add(dc20);
            dt2.Columns.Add(dc21);
            dt2.Columns.Add(dc22);
            dt2.Columns.Add(dc23);
            dt2.Columns.Add(dc24);
            dt2.Columns.Add(dc25);
            dt2.Columns.Add(dc28);
            dt2.Columns.Add(dc26);


            for (int i = 0; i < total; i++)
            {
                if (display[i, 0] != null)
                {
                    
                    DataRow dr = dt2.NewRow();
                    dr["Location"] = display[i, 28];
                    dr["Date Entered"] = display[i, 0];
                    dr["Function"] = display[i, 1];
                    dr["Engineer's Initials"] = display[i, 2];
                    dr["Part Description"] = display[i, 3];
                    dr["Part Number"] = display[i, 4];
                    dr["Quantity"] = display[i, 5];
                    dr["Revision"] = display[i, 6];
                    dr["Cut by Date"] = display[i, 7];
                    dr["Form by Date"] = display[i, 8];
                    dr["Type of Part"] = display[i, 9];
                    dr["Material"] = display[i, 10];
                    dr["Gas"] = display[i, 11];
                    dr["Priority"] = display[i, 12];
                    dr["Grain Restrictions"] = display[i, 13];
                    dr["Etch Lines"] = display[i, 14];
                    dr["Seam of Tube Location Critical"] = display[i, 15];
                    dr["Nest in Pairs"] = display[i, 16];
                    dr["Product Line"] = display[i, 17];
                    dr["Department to Charge"] = display[i, 18];
                    dr["Restirctions on Pierces"] = display[i, 19];
                    dr["Circle Correction"] = display[i, 20];
                    dr["After Laser Cut"] = display[i, 21];
                    dr["After Press Brake"] = display[i, 22];
                    dr["DXF"] = display[i, 23];
                    dr["PDF"] = display[i, 24];
                    dr["Notes for Programmer"] = display[i, 25];
                    if (display[i, 27] != null)
                    {
                        dr["Programmer's Initials"] = display[i, 27];
                    }
                    if (display[i, 26] != null)
                    {
                        dr["Nest File Location"] = display[i, 26];
                    }
                    dr["Date Nested"] = display[i, 29];
                    dr["Machine Progrmaed For"] = display[i, 30];
                    //GridView1.Columns.Insert(0, checkBox);
                    dt2.Rows.Add(dr);
                }
            }

            GridView1.DataSource = dt2;
            Session["dt2"] = dt2;
                GridView1.DataBind();

        }
        else
        {
            Needs_Box.Text = "No Parts";
        }
    }


    /// <summary>
    /// Puts colors on parts
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
    /// Remakes lists so they are all correct
    /// </summary>
    /// <param name="use"></param>
    protected void FixLists(string [,] use)
    {

        total = CountParts();

        string[,] NN = new string[total, 31];
        string[,] NF = new string[total, 31];
        string[,] IP = new string[total, 31];
        string[,] FN = new string[total, 31];
        string[,] FF = new string[total, 31];

        int e = 0;
        int o = 0;
        int r = 0;
        int n = 0;
        int f = 0;
        
        for (int i = 0; i < total; i++)
        {
            if (use[i, 28] == "Needs Nested")
            {
                for (int k = 0; k < 31; k++)
                {
                    NN[e, k] = use[i, k];
                }
                e++;
            }
            else if (use[i, 28] == "Needs Formed")
            {
                for (int k = 0; k < 31; k++)
                {
                    NF[o, k] = use[i, k];
                }
                o++;
            }
            else if (use[i, 28] == "In Progress")
            {
                for (int k = 0; k < 31; k++)
                {
                    IP[r, k] = use[i, k];
                }
                r++;
            }
            else if (use[i, 28] == "Finished Nested")
            {
                for (int k = 0; k < 31; k++)
                {
                    FN[n, k] = use[i, k];
                }
                n++;
            }
            else if (use[i, 28] == "Finished Formed")
            {
                for (int k = 0; k < 31; k++)
                {
                    FF[f, k] = use[i, k];
                }
                f++;
            }
        }
        
                var file1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\needsNested.txt"));
                file1.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\needsNested.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (NN[i, 0] != null && NN[i, 0] != "")
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                output += NN[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
          
                var file2 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\needsFormed.txt"));
                file2.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\needsFormed.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (NF[i, 0] != null && NF[i, 0] != "")
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                output += NF[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }

                var file3 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\InProgress.txt"));
                file3.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\InProgress.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (IP[i, 0] != null && IP[i, 0] != "")
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                output += IP[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }

                var file4 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\Finished.txt"));
                file4.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\Finished.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (FN[i, 0] != null && FN[i, 0] != "")
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                output += FN[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
				
				
                var file5 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\FinishedPB.txt"));
                file5.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data\FinishedPB.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (FF[i, 0] != null && FF[i, 0] != "")
                        {
                            for (int j = 0; j < 31; j++)
                            {
                                output += FF[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["dt2"];

        //Update the values.
        GridViewRow row = GridView1.Rows[e.RowIndex];


        display = (string[,])Session["array"];
        display[e.RowIndex, 0] = null;
       
        //Reset the edit index.
        GridView1.EditIndex = -1;

        //Bind data to the GridView control.
        FixLists(display);
        display = LoadFiles();
        LoadTable(display);
        

    }
    

    protected void Export_But_Click(object sender, EventArgs e)
    {
        DateTime cutoff = DateTime.Parse(Exp_Date.Text);
        FindDates(cutoff);
        display = LoadFiles();
        LoadTable(display);


        Exp_Date.Text = "";

        SendFile();

    }

    protected void FindDates(DateTime cutoff)
    {
        display = LoadFiles();

        string[,] keep = new string[total, 32];
        string[,] move = new string[total, 32];

        int moveNow = 0;
        int keepNow = 0;

        for(int i = 0; i < total; i++)
        {
            if (display[i, 0] != "" && display[i, 0] != null)
            {
                DateTime use = DateTime.Parse(display[i, 0]);

                int decide = DateTime.Compare(cutoff, use);
                if (decide > 0)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        move[moveNow, j] = display[i, j];
                    }
                    moveNow++;
                }
                else
                {
                    for (int j = 0; j < 31; j++)
                    {
                        keep[keepNow, j] = display[i, j];
                    }
                    keepNow++;
                }
            }
        }

        FixLists(keep);

        MakeFile(move);
    }

    /// <summary>
    /// Gives table a source and then Binds it
    /// </summary>
    protected void BindData()
    {
        GridView1.DataSource = Session["dt2"];
        GridView1.DataBind();
    }

    protected void MakeFile(string[,] old)
    {
        var file1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\export.csv"));
        file1.Close();
        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\export.csv"), true))
        {
            for (int i = 0; i < total; i++)
            {
                string output = "";
                if (old[i, 0] != null && old[i, 0] != "")
                {
                    for (int j = 0; j < 31; j++)
                    {
                        output += old[i, j] + "\",";

                        if (j < 30)
                        {
                            output += "\"";
                        }
                    }
                    sw.WriteLine(output);
                }

            }
            sw.Close();
        }

    }

    protected void SendFile()
    {

        Response.ContentType = "Application/csv";
        Response.AppendHeader("Content-Disposition", "attachment; filename=export.csv");
        Response.TransmitFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\export.csv"));
        Response.End();
    }

}




