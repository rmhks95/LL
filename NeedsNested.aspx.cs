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
    static int total = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")).Count() + 5;
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
        int num = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")).Count() + 5;
        return num;
    }

    /// <summary>
    /// Displays parts in table
    /// </summary>
    protected void LoadTable() {
        display = new string[total, 30];
        display = ReadFile();

        if (display[0,0] != null)
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


                    
                    dt2.Columns.Add(dc1);
                    dt2.Columns.Add(dc11);
                    dt2.Columns.Add(dc5);
                    dt2.Columns.Add(dc4);
                    dt2.Columns.Add(dc3);
                    dt2.Columns.Add(dc10);
                    dt2.Columns.Add(dc6);
                    dt2.Columns.Add(dc8);
                    dt2.Columns.Add(dc9);
                    dt2.Columns.Add(dc24);
                    dt2.Columns.Add(dc25);
                    dt2.Columns.Add(dc12);
                    dt2.Columns.Add(dc14);
                    dt2.Columns.Add(dc15);
                    dt2.Columns.Add(dc17);
                    dt2.Columns.Add(dc20);
                    dt2.Columns.Add(dc21);
                    dt2.Columns.Add(dc16);
                    dt2.Columns.Add(dc2);
                    dt2.Columns.Add(dc22);
                    dt2.Columns.Add(dc23);
                    dt2.Columns.Add(dc26);
                    dt2.Columns.Add(dc18);
                    dt2.Columns.Add(dc19);


            for (int i = 0; i < total; i++)
                    {
                        if (display[i, 0] != null)
                        {
                            //DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
                            DataRow dr = dt2.NewRow();
                            dr["Date Entered"] = display[i, 0];
                            dr["Function"] = display[i, 1];
                            dr["Engineer"] = display[i, 2];
                            dr["Description"] = display[i, 3];
                            dr["Part Num."] = display[i, 4];
                            dr["Qty"] = display[i, 5];
                            dr["Cut by Date"] = display[i, 7];
                            dr["Form by Date"] = display[i, 8];
                            dr["Part Type"] = display[i, 9];
                            dr["Material"] = display[i, 10];
                            dr["Gas"] = display[i, 11];
                            dr["Product Line"] = display[i, 17];
                            dr["Grain Rest."] = display[i, 13];
                            dr["Etch Lines"] = display[i, 14];
                            dr["Tube Seam"] = display[i, 15];
                            dr["Nest in Pairs"] = display[i, 16];
                            dr["Charge To:"] = display[i, 18];
                            dr["Pierce Rest."] = display[i, 19];
                            dr["Circle Corr."] = display[i, 20];
                            dr["After Cut"] = display[i, 21];
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
                    NestBut.Visible = false;
                    NestBut0.Visible = false;
                    PrInIT.Enabled = false;
                    Needs_Box.Text = "No More Parts Need Nested";
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
    /// Opends page of the url
    /// </summary>
    /// <param name="url"></param>
    private void OpenNewWindown(string url)
    {
        
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>document.location.href = ('{0}');</script>", url));
    }


    /// <summary>
    /// Reads file for parts
    /// </summary>
    /// <returns></returns>
    protected string[,] ReadFile()
    {
        needs = new string[total, 30];
        string[] split = new string[1300];
        using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/needsNested.txt")))
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
                for (int m = total-1; m > -1; m--)
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
    /// Remake files to remove parts selected
    /// </summary>
    /// <param name="edited"></param>
    protected void RemakeFile(string[,] edited)
    {
        var make = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsNested.txt"));
        make.Close();
        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/needsNested.txt"), true))
        {
            for (int i = 0; i < total; i++) { 
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
    ///  Hyperlinks
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string location = (e.Row.Cells[1].Text);
            string type;
            string dxf = (e.Row.Cells[10].Text);
            if (dxf != "&nbsp;")
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
                e.Row.Cells[10].Controls.Add(dxfLink);
            }


            string pdf = (e.Row.Cells[11].Text);
            if (pdf != "&nbsp;")
            {
                HyperLink pdfLink = new HyperLink();
                pdfLink.NavigateUrl = pdf;
                pdfLink.Text = "PDF";
                e.Row.Cells[11].Controls.Add(pdfLink);
            }
;
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[2].Font.Size = 10;
        }

    }

    /// <summary>
    /// Moves parts to programmer and in progress
    /// </summary>
    /// <param name="edited"></param>
    protected bool inProgress(string[,] edited)
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

        if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P1.txt"))))
        {
            programmer = 1;
        }
        else if(!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P2.txt"))))
        {
            programmer = 2;
        }
        else if(!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P3.txt"))))
        {
            programmer = 3;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P4.txt"))))
        {
            programmer = 4;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P5.txt"))))
        {
            programmer = 5;
        }
        else if (!(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P6.txt"))))
        {
            programmer = 6;
        }
        else
        {
            Label1.Visible = true;
            Label2.Visible = true;
            return false;
        }

        //Int32.Parse(PrInIT.SelectedValue)

        switch (programmer)
        {
            case 1:
                var file1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P1.txt"));
                file1.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P1.txt"), true))
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
                OpenNewWindown(@"Programmer1");
                break;
            case 2:
                var file2 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P2.txt"));
                file2.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P2.txt"), true))
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
                OpenNewWindown(@"Programmer2");
                break;
            case 3:
                var file3 =File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P3.txt"));
                file3.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/P3.txt"), true))
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
                OpenNewWindown(@"Programmer3");
                break;
            case 4:
                var file4 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P4.txt"));
                file4.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P4.txt"), true))
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
                OpenNewWindown(@"Programmer4");
                break;
            case 5:
                var file5 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P5.txt"));
                file5.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P5.txt"), true))
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
                OpenNewWindown(@"Programmer5");
                break;
            case 6:
                var file6 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P6.txt"));
                file6.Close();
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/P6.txt"), true))
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
                OpenNewWindown(@"Programmer6");
                break;
        }
        return true;

        }


    /// <summary>
    /// Get checked rows
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void NestBut_Click(object sender, EventArgs e)
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
        bool go = inProgress(InProgresss);
        if(go)
            RemakeFile(display);

    }

  
    
}



