using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class Contact : Page
{
    static int total = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")).Count() + 5;
    public string[,] needs = new string[total, 30];
    public string[,] display = new string[total, 30];

    /// <summary>
    /// Main Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        total = CountParts();
        if (!Page.IsPostBack)
        {
            LoadTable();
        }
    }

    protected int CountParts()
    {
        int num = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")).Count() + 5;
        return num;
    }

    /// <summary>
    /// Puts parts into table
    /// </summary>
    protected void LoadTable()
    {
        display = new string[total, 30];
        display = ReadFile();

        if (display[0, 0] != null)
        {
            PrInIT.Enabled = true;  
            Needs_Box.Visible = false;
            DataTable dt2 = new DataTable("test");

            // DataColumn you can use constructor DataColumn(name,type);
            CheckBox dc0 = new CheckBox();
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
            DataColumn dc13 = new DataColumn("Product Line");
            DataColumn dc14 = new DataColumn("Charge To:");
            DataColumn dc15 = new DataColumn("Etch Lines");
            DataColumn dc16 = new DataColumn("Tube Seam");
            DataColumn dc17 = new DataColumn("Nest in Pairs");
            DataColumn dc20 = new DataColumn("Pierce Rest.");
            DataColumn dc21 = new DataColumn("Circle Corr.");
            DataColumn dc22 = new DataColumn("After Cut");
            DataColumn dc23 = new DataColumn("After Form");
            DataColumn dc24 = new DataColumn("DXF");
            DataColumn dc25 = new DataColumn("PDF");
            DataColumn dc26 = new DataColumn("Program Notes");



            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc11);
            dt2.Columns.Add(dc10);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc8);
            dt2.Columns.Add(dc9);
            dt2.Columns.Add(dc24);
            dt2.Columns.Add(dc25);
            dt2.Columns.Add(dc23);
            dt2.Columns.Add(dc26);
            dt2.Columns.Add(dc13);
            dt2.Columns.Add(dc14);
            
            //dt2.Columns.Add(dc27);


            for (int i = 0; i < total; i++)
            {
                if (display[i, 0] != null)
                {
                    //DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
                    DataRow dr = dt2.NewRow();
                    dr["Date Entered"] = display[i, 0];
                    dr["Engineer"] = display[i, 2];
                    dr["Description"] = display[i, 3];
                    dr["Part Num."] = display[i, 4];
                    dr["Qty"] = display[i, 5];
                    dr["Cut by Date"] = display[i, 7];
                    dr["Form by Date"] = display[i, 8];
                    dr["Part Type"] = display[i, 9];
                    dr["Material"] = display[i, 10];
                    dr["Product Line"] = display[i, 17];
                    dr["Charge To:"] = display[i, 18];
                    dr["After Form"] = display[i, 22];
                    dr["DXF"] = display[i, 23];
                    dr["PDF"] = display[i, 24];
                    dr["Program Notes"] = display[i, 25];
                    dt2.Rows.Add(dr);

                }
            }


            GridView1.DataSource = dt2;
            GridView1.DataBind();
        }
        else
        {
            Form_But.Visible = false;
            Form_But0.Visible = false;
            PrInIT.Enabled = false;
            Needs_Box.Text = "No More Parts Need Formed";
        }
    }


    public class ArrayComparer : System.Collections.IComparer
    {
        int ix;
        public ArrayComparer(int SortFieldIndex)
        {
            ix = SortFieldIndex;
        }
        public int Compare(object x, object y)
        {
            IComparable cx = (IComparable)((Array)x).GetValue(ix);
            IComparable cy = (IComparable)((Array)y).GetValue(ix);
            return cx.CompareTo(cy);
        }
    }

    /// <summary>
    /// Opens new window of given url
    /// </summary>
    /// <param name="url"></param>
    private void OpenNewWindown(string url)
    {

        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>document.location.href = ('{0}');</script>", url));
    }

    /// <summary>
    /// Reads file into for parts
    /// </summary>
    /// <returns></returns>
    protected string[,] ReadFile()
    {
        needs = new string[total, 30];
        string[] split = new string[1300];
        using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsFormed.txt")))
        {
            string line;
            int m = 0;
            for (int i = 0; i < total; i++)
            {
                line = SR.ReadLine();
                if (line != null)
                {
                    m = 0;
                    split = line.Split('|');

                    for (int j = 0; j < 30; j++)
                    {
                        if ((split.Length - 2) >= m)
                        {
                            needs[i, j] = split[m];
                            m++;
                        }
                    }
                }
            }
            SR.Close();
        }

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
                            for (int q = 0; q < 30; q++)
                            {
                                display[p, q] = needs[h, q];
                            }
                            needs[h, 0] = "";

                            p++;
                        }

                    }
                }
        }

        needs = display;
        display = new string[total, 31];
        open = new string[total];
        for (int i = 0; i < total; i++)
        {
            if (needs[i, 10] != null)
            {
                open[i] = needs[i, 10];
            }
        }
        System.Array.Sort(open);

        p = 0;
        int n = 0;
        while (n < open.Length)
        {
            if (open[n] != null)
            {
                for (int m = total-1 ; m > -1; m--)
                {
                    if (p < total)
                    {
                        if (open[n] == needs[m, 10])
                        {
                            for (int q = 0; q < 30; q++)
                            {
                                display[p, q] = needs[m, q];
                            }
                            needs[m, 10] = "";

                            p++;
                        }

                    }
                }
            }
            n++;
        }

        return display;

    }

    /// <summary>
    /// Updates files
    /// </summary>
    /// <param name="edited"></param>
    protected void RemakeFile(string[,] edited)
    {
        var make = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsFormed.txt"));
        make.Close();
        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsFormed.txt"), true))
        {
            for (int i = 0; i < total; i++)
            {
                string output = "";
                if (edited[i, 0] != null && edited[i, 0] != "")
                {
                    for (int j = 0; j < 30; j++)
                    {
                        output += edited[i, j] + "|";
                    }
                    sw.WriteLine(output);
                }

            }
            sw.Close();
        }

        LoadTable();
    }


    /// <summary>
    /// Sends parts to the programmer and in progress
    /// </summary>
    /// <param name="edited"></param>
    protected void inProgress(string[,] edited)
    {


        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt"), true))
        {
            for (int i = 0; i < total; i++)
            {
                string output = "";
                if (edited[i, 0] != null && edited[i, 0] != "")
                {
                    edited[i, 27] = PrInIT.Text;
                    for (int j = 0; j < 30; j++)
                    {
                        output += edited[i, j] + "|";
                    }
                    sw.WriteLine(output);
                }

            }
            sw.Close();
        }

        int programmer = 0;

        if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB1.txt"))))
        {
            programmer = 1;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB2.txt"))))
        {
            programmer = 2;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB3.txt"))))
        {
            programmer = 3;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB4.txt"))))
        {
            programmer = 4;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB5.txt"))))
        {
            programmer = 5;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB6.txt"))))
        {
            programmer = 6;
        }

        switch (programmer)
        {
            case 1:
                var file1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB1.txt"));
                file1.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB1.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB1");
                break;
            case 2:
                var file2 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB2.txt"));
                file2.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB2.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB2");
                break;
            case 3:
                var file3 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB3.txt"));
                file3.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB3.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB3");
                break;
            case 4:
                var file4 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB4.txt"));
                file4.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB4.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB4");
                break;
            case 5:
                var file5 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB5.txt"));
                file5.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB5.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB5");
                break;
            case 6:
                var file6 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB6.txt"));
                file6.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB6.txt"), true))
                {
                    for (int i = 0; i < total; i++)
                    {
                        string output = "";
                        if (edited[i, 0] != null && edited[i, 0] != "")
                        {
                            edited[i, 27] = PrInIT.Text;
                            for (int j = 0; j < 30; j++)
                            {
                                output += edited[i, j] + "|";
                            }
                            sw.WriteLine(output);
                        }

                    }
                    sw.Close();
                }
                OpenNewWindown(@"PB6");
                break;
        }

    }

    /// <summary>
    /// Finds the rows that are selected
    /// </summary>
    protected void FormBut_Click(object sender, EventArgs e)
    {

        display = ReadFile();

        string[] selected = new string[total];
        int counter = 0;
        string[,] InProgresss = new string[total, 30];
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    selected[counter] = row.RowIndex.ToString();
                    counter++;
                }
            }
        }

        if (selected != null)
        {
            for (int i = 0; i < counter; i++)
            {
                int row = Int32.Parse(selected[i]);
                //int count = 0;
                for (int m = 0; m < 30; m++)
                {
                    InProgresss[i, m] = display[row, m];
                }
                display[row, 0] = "";

            }
        }
        inProgress(InProgresss);
        RemakeFile(display);

    }

    /// <summary>
    /// If priority is high it changes to yellow
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string location = (e.Row.Cells[13].Text);
			e.Row.Cells[5].Font.Bold = true;
            e.Row.Cells[5].Font.Size = 10;

            /*
            e.Row.Cells[8].Font.Size = 9;
            e.Row.Cells[9].Font.Bold = true;
           e.Row.Cells[9].Font.Size = 10;
           if (e.Row.Cells[9].Text != "" && e.Row.Cells[9].Text != "&nbsp;") { 
               string date = e.Row.Cells[9].Text;

               DateTime formated = DateTime.Parse(date);

               if(formated < DateTime.Today.AddDays(2))
               {
                   e.Row.BackColor = Color.FromArgb(0, 252, 252, 100);
               }
            }
            */
        }
    }

}





