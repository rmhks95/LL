using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


/// Use " " for CSV file to keep commas in info contained. 


public partial class Default3 : System.Web.UI.Page
{
    static int total = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt")).Count() +
        File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt")).Count() + 5;
    public string[,] needs = new string[total, 31];
    string[,] display = new string[total, 31];

    /// <summary>
    /// Main method that gets parts and displays in table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

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

            string[] split = new string[3900];
            StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/Finished.txt"));
            string line;
            int m = 0;
            int toUse = 0;
            for (int i = 0; i < total; i++)
            {
                line = SR.ReadLine();
                if (line != null)
                {
                    m = 0;
                    split = line.Split('|');

                    for (int j = 0; j < 31; j++)
                    {
                        if ((split.Length - 2) >= m)
                        {
                            needs[i, j] = split[m];
                            m++;
                            //needs = (string[,])Session["nest"];
                        }
                    }
                }
                else
                {
                    toUse++;
                    switch (toUse) { 
                        case 1:
                            SR.Close();
                            SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/FinishedPB.txt"));
                            break;
                        case 2:
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


        if (display[0, 0] != null)
        {
            Needs_Box.Visible = false;
            DataTable dt2 = new DataTable("test");

            // DataColumn you can use constructor DataColumn(name,type);
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
            DataColumn dc12 = new DataColumn("Product Line");
            DataColumn dc13 = new DataColumn("Charge To:");
            DataColumn dc24 = new DataColumn("DXF");
            DataColumn dc25 = new DataColumn("PDF");
            DataColumn dc27 = new DataColumn("Programmer");
            DataColumn dc28 = new DataColumn("Nest File");
            DataColumn dc29 = new DataColumn("Date Nested");
            DataColumn dc30 = new DataColumn("Machine");


            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc29);
            dt2.Columns.Add(dc27);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc7);
            dt2.Columns.Add(dc11);
            dt2.Columns.Add(dc30);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc12);
            dt2.Columns.Add(dc13);
            dt2.Columns.Add(dc24);
            dt2.Columns.Add(dc25);
            dt2.Columns.Add(dc28);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);

            


            for (int i = 0; i < total; i++)
            {
                if (display[i, 0] != null)
                {
                    DataRow dr = dt2.NewRow();
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
                    dr["Charge To:"] = display[i, 18];
                    dr["Product Line"] = display[i, 17];
                    dr["DXF"] = display[i, 23];
                    dr["PDF"] = display[i, 24];
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
            GridView1.DataBind();

        }
        else
        {
            Needs_Box.Text = "No Parts";
        }
    }
}