using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : Page
{
    static int total = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")).Count() + 5;
    public string[,] needs = new string[total, 30];
    public string[,] display = new string[total, 30];

    /// <summary>
    /// Main method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadTable();
        }
    }

    /// <summary>
    /// Displays parts in table
    /// </summary>
    protected void LoadTable()
    {
        display = new string[total, 30];
        display = ReadFile();

        if (display[0, 0] != null)
        {
            NoneLable.Visible = false;
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
            DataColumn dc13 = new DataColumn("Priority");
            DataColumn dc14 = new DataColumn("Grain Rest.");
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
            DataColumn dc27 = new DataColumn("Programmer");
            



            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc27);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc5);
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
            dt2.Columns.Add(dc20);
            dt2.Columns.Add(dc21);
            dt2.Columns.Add(dc22);
            dt2.Columns.Add(dc23);
            dt2.Columns.Add(dc24);
            dt2.Columns.Add(dc25);
            dt2.Columns.Add(dc26);


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
                    dr["Rev"] = display[i, 6];
                    dr["Cut by Date"] = display[i, 7];
                    dr["Form by Date"] = display[i, 8];
                    dr["Part Type"] = display[i, 9];
                    dr["Material"] = display[i, 10];
                    dr["Gas"] = display[i, 11];
                    dr["Priority"] = display[i, 12];
                    dr["Grain Rest."] = display[i, 13];
                    dr["Etch Lines"] = display[i, 14];
                    dr["Tube Seam"] = display[i, 15];
                    dr["Nest in Pairs"] = display[i, 16];
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
                    dt2.Rows.Add(dr);

                }
            }


            Grid.DataSource = dt2;
            Grid.DataBind();
        }
        else
        {
            NoneLable.Visible = true;
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
  /// Reads file to get all parts
  /// </summary>
  /// <returns></returns>
    protected string[,] ReadFile()
    {
        needs = new string[total, 30];
        string[] split = new string[1300];
        using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")))
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

                    for (int j = 0; j < 28; j++)
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
        for (int i = 0; i < total; i++)
        {
            if (needs[i, 10] != null)
            {
                open[i] = needs[i, 10];
            }
        }
        System.Array.Sort(open);

        int p = 0;
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
                            for (int q = 0; q < 28; q++)
                            {
                                if (needs[m, q] != null)
                                {
                                    display[p, q] = needs[m, q];
                                }
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
    /// Opends page of the url
    /// </summary>
    /// <param name="url"></param>
    private void OpenNewWindown(string url)
    {

        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>document.location.href = ('{0}');</script>", url));
    }

    protected void P1_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer1");
    }


    protected void P2_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer2");
    }

    protected void P3_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer3");
    }

    protected void P4_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer4");
    }

    protected void P5_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer5");
    }

    protected void P6_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"Programmer6");

    }

    protected void PB1_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB1");
    }


    protected void PB2_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB2");
    }

    protected void PB3_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB3");
    }

    protected void PB4_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB4");
    }

    protected void PB5_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB5");
    }

    protected void PB6_Click(object sender, EventArgs e)
    {

        OpenNewWindown(@"PB6");

    }

}

//Response.Write("  <script language='javascript'> window.open('HomePage.aspx','','width=1020,Height=720,fullscreen=1,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");




