using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Threading;
using OEFC_Manager.classes;
using System.Net;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;

namespace OEFC_Manager
{
    public partial class Form1 : Form
    {
        bool debug = false;

        string key = null;
        string api = null;
        string prodId_Tm_main = "42558A3J377172E034FE20";
        string prodId_Tm_opt_cam = "42558A3J377172E034FE20_L7RRA7R9";
        string prodId_Tm_opt_fett = "42558A3J377172E034FE20_CNLXLXKE";
        string prodId_Tm_opt_ov = "42558A3J377172E034FE20_37WNTYUE";

        string prodId_TmOV_main = "42558TTPR9J172E0382A0C";
        string prodId_TmOV_opt_fett = "42558TTPR9J172E0382A0C_9PKEKFER";
        string starttime = "";
        string endtime = "";

        static Excel.Application xlApp;
        static Excel.Workbook xlWorkbook;
        static Excel.Worksheet xlSheet;
        Excel.Range xlrange = null;
        Excel.Range last;
        int gs_start_row = 6;

        List<Payment> payments = new List<Payment>();

        public Form1()
        {
            InitializeComponent();
            debug = bool.Parse(ConfigurationManager.AppSettings["Debug"]);
            key = ConfigurationManager.AppSettings["Key"];
            api = ConfigurationManager.AppSettings["Api"];

            if (debug)
            {
                btn_file_Click(null, null);
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            if (debug)
            {
                string file = "C:\\Users\\floiso\\Downloads\\OEFCloud PAX Einteilung_dev.xlsx";
                lbl_file.Text = file;
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(file);
                xlApp.Visible = true;
                //Thread.Sleep(2000);
                tbc_main.Enabled = true;
                pnl_gsentwert.Enabled = true;
                rb_auto_CheckedChanged(sender, e);
                Console.WriteLine("Excel opened");
                return;
            }

            DialogResult result = fd_file.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = fd_file.FileName;
                lbl_file.Text = file;
                try
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(file);                    
                    xlApp.Visible = true;
                    Thread.Sleep(5000); //wait until open
                    tbc_main.Enabled = true;
                    pnl_gsentwert.Enabled = true;
                    rb_auto_CheckedChanged(sender, e);
                    Console.WriteLine("Excel opened");
                }
                catch (IOException)
                {
                    
                }
            }
        }

        private void btn_findGS_Click(object sender, EventArgs e)
        {           
            btn_findGS.Enabled = false;
            btn_entwerten.Enabled = false;
            filterNew();
            MessageBox.Show("Searching from: " + starttime + " to: "+ endtime, "Timespawn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            request_payments();
        }

        private void filterNew()
        {
            xlSheet = xlWorkbook.Sheets["GS ALL"];
            xlSheet.Select();
            if (xlSheet.AutoFilter != null)
            {
                xlSheet.AutoFilter.ShowAllData();
            }
            last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            xlrange = xlSheet.Range["A5:A" + last.Row.ToString()];
            xlrange.AutoFilter(1, "new", Excel.XlAutoFilterOperator.xlFilterValues, Type.Missing, true);
            Excel.Range filteredRange = xlrange.SpecialCells(Excel.XlCellType.xlCellTypeVisible, Excel.XlSpecialCellsValue.xlTextValues);
            last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
        }

        public async void request_payments()
        {
            payments = new List<Payment>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.bookeo.com/v2/");

            string url= "https://api.bookeo.com/v2/payments?startTime=" + starttime + 
                "&endTime=" + endtime + 
                "&itemsPerPage=300" +
                "&secretKey=" + key + 
                "&type=fixed&apiKey=" + api;
            try
            {
                Console.WriteLine("apicall {0}", url.ToString());
                
                var response = await client.GetStringAsync(url);
                JObject json = JObject.Parse(response);
                var jsonData = json["data"];

                Console.WriteLine("found {0} items from bookeo", jsonData.Count());

                if(jsonData.Count() == 0)
                {
                    MessageBox.Show("No new Tickts found", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (JToken ar in jsonData)
                    {
                        bool status = true;
                        Payment payment = new Payment();
                        string url_customer = "";
                        try
                        {                      
                            payment.id = ar["id"].ToString();
                            payment.creationTime = Convert.ToDateTime(ar["creationTime"]);
                            payment.receivedTime = Convert.ToDateTime(ar["receivedTime"]);
                            payment.reason = ar["reason"].ToString();
                            payment.code = ar["description"].ToString().Split(' ')[1];
                            payment.amount = Regex.Replace(ar["amount"].ToString(), @"\D", "");
                            payment.paymentMethod = ar["paymentMethod"].ToString();
                            payment.customerId = ar["customerId"].ToString();
                            payment.gatewayName = ar["gatewayName"].ToString();
                            payment.transactionId = ar["transactionId"].ToString();
                            url_customer = "https://api.bookeo.com/v2/customers/" + ar["customerId"].ToString() + "?type=fixed&secretKey=" + key + "&apiKey=" + api;

                            Console.WriteLine("apicall " + url_customer);
                            response = await client.GetStringAsync(url_customer);
                            Thread.Sleep(1000); //otherwise http error 429
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            //MessageBox.Show("Parsing customer info went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine("Parsing customer info went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // TODO console log
                            status = false;
                        }
                        
                        if(status)
                        {
                            json = JObject.Parse(response);
                            payment.customer = json["firstName"].ToString() + " " + json["lastName"].ToString();
                            payments.Add(payment);
                        }                       
                    }
                    payments.Sort((a, b) => a.receivedTime.CompareTo(b.receivedTime));

                    Console.WriteLine("start write to Excel");
                    writeToExcel();
                }
                btn_findGS.Enabled = true;
                btn_entwerten.Enabled = true;
            }
            catch
            {
                btn_findGS.Enabled = true;
                btn_entwerten.Enabled = true;
            }

            Console.WriteLine("{0} finished", nameof(request_payments));
        }

        public void writeToExcel()
        {
            List<string> coupons = new List<string>();
            int lastrow = last.Row;
            for (int i = gs_start_row; i <= lastrow; i++)
            {
                coupons.Add((string)(xlSheet.Cells[i, 2] as Excel.Range).Value);
            }
            foreach (Payment customer in payments)
            {
                if (coupons.Contains(customer.code.ToString()))
                {
                    //MessageBox.Show("Coupon: " + customer.code.ToString() + " already in List", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Debug.WriteLine("Coupon: " + customer.code.ToString() + " already in List", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine("Coupon: " + customer.code.ToString() + " already in List", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lastrow += 1;
                    xlSheet.Cells[lastrow, 1].Value = "new";
                    xlSheet.Cells[lastrow, 2].Value = customer.code.ToString();
                    xlSheet.Cells[lastrow, 3].Value = customer.amount.ToString();
                    xlSheet.Cells[lastrow, 4].Value = customer.customer.ToString();
                    xlSheet.Cells[lastrow, 6].Value = customer.receivedTime;

                    Console.WriteLine("written line {0}: {1}", lastrow, customer.code.ToString());
                }
            }
            last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            xlrange = xlSheet.Range["A5:A" + last.Row.ToString()];
            xlrange.AutoFilter(1, "new", Excel.XlAutoFilterOperator.xlFilterValues, Type.Missing, true);
            Excel.Range filteredRange = xlrange.SpecialCells(Excel.XlCellType.xlCellTypeVisible, Excel.XlSpecialCellsValue.xlTextValues);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {  
                if(xlWorkbook != null)
                {
                    xlWorkbook.Close();
                    xlApp.Quit();
                }        
            }
            catch { }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                    xlApp.Quit();
                }
            }
            catch { }

        }

        private void btn_entwerten_Click(object sender, EventArgs e)
        {
            btn_findGS.Enabled = false;
            btn_entwerten.Enabled = false;
            bool check_value = true;
            filterEntwerten();
            for (int count_row = gs_start_row; count_row <= last.Row; count_row++)
            {
                if(xlSheet.Cells[count_row, 1].Value.ToString()=="new" && xlSheet.Cells[count_row, 5].Value != null && xlSheet.Cells[count_row, 20].Value == null)
                {
                    string name = xlSheet.Cells[count_row, 4].Value.ToString();
                    string code = xlSheet.Cells[count_row, 2].Value.ToString();
                    string code_value = xlSheet.Cells[count_row, 3].Value.ToString();
                    DateTime starttime = Convert.ToDateTime(xlSheet.Cells[count_row, 5].Value.ToString("yyyy-MM-ddT07:00:00Z"));
                    DateTime endtime = starttime.AddMinutes(15.0);
                    check_value = true;
                    Customer cust = new Customer();
                    cust.firstName = name.Split(' ')[0];
                    cust.lastName = name.Split(' ').Length>1 ? name.Split(' ')[1] : "";                    
                    Participants partici = new Participants();
                    partici.numbers = new PeopleNumber[1];
                    PeopleNumber peoplenum = new PeopleNumber();
                    Booking booking = new Booking();                   
                    booking.customer = cust;
                    //booking.startTime = starttime;
                    //booking.endTime = endtime;
                    //booking.startTime = Convert.ToDateTime("2022-05-01T09:05:00+02:00");
                    //booking.endTime = Convert.ToDateTime("2022-05-01T12:55:00+02:00");
                    booking.giftVoucherCodeInput = code;
                    peoplenum.peopleCategoryId = "Cadults";
                    peoplenum.number = "1";
                    partici.numbers[0] = peoplenum;
                    booking.participants = partici;
                    BookingOption option = new BookingOption();
                    switch (code_value)
                    {
                        case "249":
                            booking.productId = prodId_Tm_main;
                            break;
                        case "299":
                            booking.options = new BookingOption[1];
                            option = new BookingOption();
                            booking.productId = prodId_Tm_main;
                            option.id = prodId_Tm_opt_fett;
                            option.name = "Aufpreis für mehr als 90KG Passagier";
                            option.value = "true";
                            booking.options[0] = option;
                            break;
                        case "324":
                            booking.options = new BookingOption[1];
                            option = new BookingOption();
                            booking.productId = prodId_Tm_main;
                            option.id = prodId_Tm_opt_cam;
                            option.name = "Handcam Video";
                            option.value = "true";
                            booking.options[0] = option;
                            break;
                        case "374":
                            booking.options = new BookingOption[2];
                            option = new BookingOption();
                            booking.productId = prodId_Tm_main;
                            option.id = prodId_Tm_opt_fett;
                            option.name = "Aufpreis für mehr als 90KG Passagier";
                            option.value = "true";
                            booking.options[0] =  option;
                            option = new BookingOption();
                            option.id = prodId_Tm_opt_cam;
                            option.name = "Handcam Video";
                            option.value = "true";
                            booking.options[1] = option;
                            break;
                        case "364":
                            booking.productId = prodId_TmOV_main;
                            break;
                        case "414":
                            booking.options = new BookingOption[1];
                            option = new BookingOption();
                            booking.productId = prodId_TmOV_main;
                            option.id = prodId_TmOV_opt_fett;
                            option.name = "Aufpreis für mehr als 90KG Passagier";
                            option.value = "true";
                            booking.options[0] = option;
                            break;
                        default:
                            check_value = false;
                            break;
                    }
                    if (check_value)
                    {
                        booking.eventId = "42558TTPR9J172E0382A0C_42558AFP3LA1738FD62AE8_2022-05-08";
                        post_booking(booking, count_row);
                    }
                    else
                    {
                        MessageBox.Show("Booking Value Invalid, Code: "+ booking.giftVoucherCodeInput.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                
            }

        }

        private void filterEntwerten()
        {
            xlSheet = xlWorkbook.Sheets["GS ALL"];
            xlSheet.Select();
            if (xlSheet.AutoFilter != null)
            {
                xlSheet.AutoFilter.ShowAllData();
            }
            last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            xlrange = xlSheet.Range["E5:E" + last.Row.ToString()];
            xlrange.AutoFilter(5, "<>", Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
            Excel.Range filteredRange = xlrange.SpecialCells(Excel.XlCellType.xlCellTypeVisible, Excel.XlSpecialCellsValue.xlTextValues);
            last = xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
        }

        public async void post_booking(Booking booking , int row)
        {
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (HttpClient client = new HttpClient(handler, false))
                    {
                        client.BaseAddress = new Uri("https://api.bookeo.com/");
                        string url = "https://api.bookeo.com/v2/bookings?notifyCustomer=false&notifyUsers=false&sendCustomerThankyou=false&sendCustomerReminders=false&mode=backend&secretKey=" + key + "&apiKey=" + api;
                        HttpResponseMessage response = new HttpResponseMessage();
                        string json = JsonConvert.SerializeObject(booking);
                        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                        MemoryStream ms = new MemoryStream();
                        using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
                        {
                            gzip.Write(jsonBytes, 0, jsonBytes.Length);
                        }
                        ms.Position = 0;
                        StreamContent content = new StreamContent(ms);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        content.Headers.ContentEncoding.Add("gzip");
                        response = await client.PostAsync(url, content);
                        if (response.IsSuccessStatusCode)
                        {
                            xlSheet.Cells[row, 20].Value = "X";
                        }
                        else
                        {
                            MessageBox.Show("Booking FAILED, Code: " + booking.giftVoucherCodeInput.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Booking FAILED, Code: " + booking.giftVoucherCodeInput.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rb_days_CheckedChanged(object sender, EventArgs e)
        {
            endtime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            double days = Convert.ToDouble(nud_days.Value);
            starttime = DateTime.Now.AddDays(-days).ToString("yyyy-MM-ddTHH:mm:ssZ");
            Console.WriteLine("endtime {0} starttime {1}", endtime, starttime);
        }

        private void rb_timespawn_CheckedChanged(object sender, EventArgs e)
        {
            starttime = dtp_start.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
            endtime = dtp_end.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private void rb_auto_CheckedChanged(object sender, EventArgs e)
        {
            filterNew();

            string[] formats = { "dd.MM.yyyy HH:mm", "dd.MM.yyyy H:mm" };

            var lastRowCell = xlSheet.Cells[last.Row, 6];
            DateTime dateTimeResult;
            DateTime.TryParseExact(lastRowCell.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeResult);

            if ((DateTime.Now - dateTimeResult).TotalDays > 30)
            {
                endtime = dateTimeResult.AddDays(30).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            else
            {
                endtime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            starttime = dateTimeResult.ToString("s") + "Z";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {
            starttime = dtp_start.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            endtime = dtp_end.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private void nud_days_ValueChanged(object sender, EventArgs e)
        {
            endtime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            double days = Convert.ToDouble(nud_days.Value);
            starttime = DateTime.Now.AddDays(-days).ToString("yyyy-MM-ddTHH:mm:ssZ");
            Console.WriteLine("endtime {0} starttime {1}", endtime, starttime);
        }
    }
}
