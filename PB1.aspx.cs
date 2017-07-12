using System;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Contact : System.Web.UI.Page
{
    public string[,] needs = new string[50, 30];
    public string[,] display = new string[50, 30];
    public string[,] finished = new string[50, 30];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadTable();
        }
    }

    private void LoadTable()
    {
        display = new string[50, 30];
        display = ReadFile();

        if (display[0, 0] != null)
        {
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


            for (int i = 0; i < 50; i++)
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
    }


    protected string[,] ReadIP()
    {
        needs = new string[50, 28];
        string[] split = new string[1300];
        using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/InProgress.txt")))
        {
            string line;
            int m = 0;
            for (int i = 0; i < 50; i++)
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


        string[] open = new string[50];
        for (int i = 0; i < 50; i++)
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
                for (int m = 49; m > -1; m--)
                {
                    if (p < 50)
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

    protected string[,] ReadFile()
    {
        string[,] needs1 = new string[50, 30];
        string[,] display1 = new string[50, 30];
        string[] split = new string[1300];
        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB1.txt");
        if (File.Exists(file))
        {

            using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/PB1.txt")))
            {
                string line;
                int m = 0;
                for (int i = 0; i < 50; i++)
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
                                needs1[i, j] = split[m];
                                m++;
                            }
                        }
                    }
                }
                SR.Close();
            }


            string[] open = new string[50];
            for (int i = 0; i < 50; i++)
            {
                if (needs1[i, 10] != null)
                {
                    open[i] = needs1[i, 10];
                }
            }
            System.Array.Sort(open);

            int p = 0;
            int n = 0;
            while (n < open.Length)
            {
                if (open[n] != null)
                {
                    for (int m = 49; m > -1; m--)
                    {
                        if (p < 50)
                        {
                            if (open[n] == needs1[m, 10])
                            {
                                for (int q = 0; q < 30; q++)
                                {
                                    display1[p, q] = needs1[m, q];
                                }
                                needs1[m, 10] = "";

                                p++;
                            }

                        }
                    }
                }
                n++;
            }
        }
        return display1;

    }

    protected void Finish_But_Click(object sender, EventArgs e)
    {
        string fileLoc = fileLoca.Text;
        display = ReadFile();

        for (int j = 0; j < 50; j++)
        {
            for (int k = 0; k < 30; k++)
            {
                finished[j, k] = display[j, k];
            }
        }


        for (int i = 0; i < 30; i++)
        {
            if (finished[i, 0] != "" && finished[i, 0] != null)
            {
                finished[i, 26] = fileLoc;
                finished[i, 29] = DateTime.Now.ToString();
            }

        }

        SendEmail(finished);
        Next(finished);

        RemakeFile(finished);

        GoBack();

    }


    protected void SendEmail(string[,] items)
    {

        for (int i = 0; i < 50; i++)
        {
            if (items[i, 0] != null)
            {
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient("turnoverball-com.mail.protection.outlook.com");
                sc.Host = "turnoverball-com.mail.protection.outlook.com";
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                m.From = new MailAddress("CNC@turnoverball.com", "Formed Parts");
                m.To.Add(new MailAddress("jeremymoyer@turnoverball.com", "Engineering"));
                m.To.Add(new MailAddress("cleatstockebrand@turnoverball.com", "Engineering"));
                m.To.Add(new MailAddress("austinrasmussen@turnoverball.com", "Engineering"));
                m.To.Add(new MailAddress("ryanhuse@turnoverball.com", "Engineering"));
                m.Subject = items[i, 2] + " " + items[i, 4];
                m.Body = "Part #: " + items[i, 4] + "\nPart Description: " + items[i, 3] + "\nMaterial: " + items[i, 10] + "\nNested at: " + items[i, 29];
                sc.EnableSsl = true;
                sc.Send(m);
            }
        }
    }


    private void GoBack()
    {
        File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/PB1.txt"));
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>document.location.href = ('{0}');</script>", "NeedsFormed"));
    }

    protected void RemakeFile(string[,] edited3)
    {
        display = ReadIP();

        var make = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt"));
        make.Close();


        for (int m = 0; m < 50; m++)
        {
            for (int n = 0; n < 50; n++)
            {
                if (edited3[m, 4] == display[n, 4])
                {
                    display[n, 0] = "";
                    edited3[m, 4] = "";
                }
            }
        }

        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/InProgress.txt"), true))
        {
            for (int i = 0; i < 50; i++)
            {
                string output = "";
                if (display[i, 0] != null && display[i, 0] != "")
                {
                    for (int j = 0; j < 30; j++)
                    {
                        output += display[i, j] + "|";
                    }
                    sw.WriteLine(output);
                }
            }
            sw.Close();
        }

    }

    protected void Next(string[,] edited)
    {

        for (int i = 0; i < 50; i++)
        {
            if (edited[i, 0] != null && edited[i, 0] != "")
            {
                using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"App_Data/FinishedPB.txt"), true))
                {

                    string output = "";

                    for (int j = 0; j < 30; j++)
                    {
                        if (edited[i, j] != null)
                            output += edited[i, j] + "|";
                    }
                    sw.WriteLine(output);
                    sw.Flush();
                    sw.Close();
                }


            }

        }

    }
}