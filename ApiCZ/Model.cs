using CsvHelper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ApiCZ
{
    
    class Parser
    {
        //public List<string> Parser(string str, int index, string arg, string separator)
        //{
        //    string str2;
        //    List<string> arr = new List<string>();
        //    while (index != -1)
        //    {
        //        index = str.IndexOf(arg);
        //        if (index != -1)
        //        {
        //            str = str.Substring(index + arg.Length + 3);
        //            int endIndexOfName = str.IndexOf(separator);
        //            str2 = str.Substring(0, endIndexOfName);
        //            arr.Add(str2);
        //            str = str.Substring(str2.Length);
        //        }
        //    }
        //    return arr;
        //}
        public System.Collections.Specialized.StringCollection ParserSettings(string settings)
        {
            System.Collections.Specialized.StringCollection parseSetting = new System.Collections.Specialized.StringCollection();
            string str;
            int index = 0;

            do
            {
                index = settings.IndexOf(",");
                if (index != -1)
                {
                    str = settings.Substring(0, index);
                    parseSetting.Add(str);
                    settings = settings.Substring(index + 2);
                }
                else
                {
                    parseSetting.Add(settings);
                }

            } while (index != -1);
            return parseSetting;

        }

        public string DeParseSettings(System.Collections.Specialized.StringCollection settings)
        {
            string str = null;
           for(int i = 0; i < settings.Count; i++)
            {
                if (i == 0)
                    str = settings[i];
                else
                    str = str + ", " + settings[i];
                
            }
            return str;
            
        }
    }
    public class Token
    {
        [JsonProperty("uuid")]
        public string uuid = null;

        [JsonProperty("data")]
        public string data = null;

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Order
    {
        [JsonProperty("products")]
        public List<OrderProducts> products = new List<OrderProducts>();

        [JsonProperty("releaseMethodType")]
        public string releaseMethodType = null;

        [JsonProperty("productionOrderId")]
        public string productionOrderId = null;

        [JsonProperty("createMethodType")]
        public string createMethodType = null;

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class OrderProducts
    {
        [JsonProperty("gtin")]
        public string gtin = null;

        [JsonProperty("quantity")]
        public int quantity = 0;

        [JsonProperty("serialNumberType")]
        public string serialNumberType = null;

        [JsonProperty("templateId")]
        public int templateId = 0;

        [JsonProperty("cisType")]
        public string cisType = null;
    }

    public class AppliedWater
    {
        [JsonProperty("sntins")]
        public List<string> sntins = null;

        [JsonProperty("usageType")]
        public string usageType = null;

        [JsonProperty("usedInProduction")]
        public int usedInProduction { get; set; }

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class AppliedBeer
    {
        [JsonProperty("sntins")]
        public List<string> sntins = null;

        [JsonProperty("usageType")]
        public string usageType = null;

        [JsonProperty("participantId")]
        public string participantId = null;

        [JsonProperty("kpp")]
        public string kpp = null;

        [JsonProperty("productionDate")]
        public string productionDate { get; set; }

        [JsonProperty("fiasId")]
        public string fiasId { get; set; }

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    public class DropoutReport
    {
        [JsonProperty("dropoutReason")]
        public string dropoutReason = null;

        [JsonProperty("sntins")]
        public List<string> sntins = null;

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ReportResponse
    {
        [JsonProperty("omsId")]
        public string omsId = null;

        [JsonProperty("reportId")]
        public string reportId = null;
    }

    public class Aggregation
    {
        [JsonProperty("participantId")]
        public string participantId = null;

        [JsonProperty("aggregationUnits")]
        public List<AggregationUnits> aggregationUnits = new List<AggregationUnits>();

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class AggregationUnits
    {
        public AggregationUnits(int AggregatedItemsCount, string AggregationType, int AggregationUnitCapacity, List<string> Sntins, string UnitSerialNumber)
        {
            aggregatedItemsCount = AggregatedItemsCount;
            aggregationType = AggregationType;
            aggregationUnitCapacity = AggregationUnitCapacity;
            sntins = Sntins;
            unitSerialNumber = UnitSerialNumber;
        }

        [JsonProperty("aggregatedItemsCount")]
        public int aggregatedItemsCount = 0;

        [JsonProperty("aggregationType")]
        public string aggregationType = null;

        [JsonProperty("aggregationUnitCapacity")]
        public int aggregationUnitCapacity = 0;

        [JsonProperty("sntins")]
        public List<string> sntins = new List<string>();

        [JsonProperty("unitSerialNumber")]
        public string unitSerialNumber = null;
    }

    class Circulation
    {
        [JsonProperty("participant_inn")]
        public string participant_inn = null;

        [JsonProperty("producer_inn")]
        public string producer_inn = null;

        [JsonProperty("owner_inn")]
        public string owner_inn = null;

        [JsonProperty("production_date")]
        public string production_date = null;

        [JsonProperty("production_type")]
        public string production_type = null;

        [JsonProperty("products")]
        public List<ProductsCirc> products = new List<ProductsCirc>();

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    class ProductsCirc
    {
        public ProductsCirc(string Uit_code, string Tnved_code, List<CertCirc> Certificate_document_data)
        {
            uit_code = Uit_code;
            tnved_code = Tnved_code;
            certificate_document_data = Certificate_document_data;

        }

        [JsonProperty("uit_code")]
        public string uit_code = null;

        [JsonProperty("tnved_code")]
        public string tnved_code = null;

        [JsonProperty("certificate_document_data")]
        public List<CertCirc> certificate_document_data = new List<CertCirc>();

    }

    class CertCirc
    {   public CertCirc(string Certificate_type, string Certificate_number, string Certificate_date, string Well_number)
        {
            certificate_date = Certificate_date;
            certificate_number = Certificate_number;
            certificate_type = Certificate_type;
            well_number = Well_number;
        }

        [JsonProperty("certificate_type")]
        public string certificate_type = null;

        [JsonProperty("certificate_number")]
        public string certificate_number = null;

        [JsonProperty("certificate_date")]
        public string certificate_date = null;

        [JsonProperty("well_number")]
        public string well_number = null;
    }

    class SingleDocument
    {
        [JsonProperty("document_format")]
        public string document_format = null;

        [JsonProperty("product_document")]
        public string product_document = null;

        [JsonProperty("signature")]
        public string signature = null;

        [JsonProperty("type")]
        public string type = null;

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    class ReportStatusResponse
    {
        [JsonProperty("errorReason")]
        public string errorReason = null;

        [JsonProperty("omsId")]
        public string omsId = null;

        [JsonProperty("reportId")]
        public string reportId = null;

        [JsonProperty("reportStatus")]
        public string reportStatus = null;
    }

    class ReportStatusResponseCirc
    {

        [JsonProperty("number")]
        public string number = null;

        [JsonProperty("docDate")]
        public string docDate = null;

        [JsonProperty("receivedAt")]
        public string receivedAt = null;

        [JsonProperty("type")]
        public string type = null;

        [JsonProperty("status")]
        public string status = null;

        [JsonProperty("senderInn")]
        public string senderInn = null;

        [JsonProperty("senderName")]
        public string senderName = null;

        [JsonProperty("receiverInn")]
        public string receiverInn = null;

        [JsonProperty("receiverName")]
        public string receiverName = null;

        [JsonProperty("invoiceNumber")]
        public string invoiceNumber = null;

        [JsonProperty("invoiceDate")]
        public string invoiceDate = null;

        [JsonProperty("relatedDocId")]
        public string relatedDocId = null;

        [JsonProperty("input")]
        public bool input = false;

        [JsonProperty("errors")]
        public List<string> errors = new List<string>();

        [JsonProperty("productGroup")]
        public List<string> productGroup = new List<string>();

        [JsonProperty("productGroupId")]
        public List<int> productGroupId = new List<int>();

       
    }

    class CardProduct
    {
        [JsonProperty("results")]
        public List<CardProductResults> results { get; set; }

    }

    class NewOrderResponse
    {
        [JsonProperty("orderId")]
        public string orderId { get; set; }
    }
    class CardProductResults
    {
        public CardProductResults(string Name, string Gtin, string TnVedCode10)
        {
            name = Name;
            gtin = Gtin;
            tnVedCode10 = TnVedCode10;
        }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("gtin")]
        public string gtin { get; set; }

        [JsonProperty("tnVedCode10")]
        public string tnVedCode10 { get; set; }
    }
    class Orders
    {
        [JsonProperty("omsId")]
        public string omsId { get; set; }
        [JsonProperty("orderInfos")]
        public List<OrderInfos> orderInfos { get; set; }
        
    }

    class OrderInfos
    {
        public OrderInfos(string OrderStatus, List<OrderBuffers> Buffers, Int64 CreatedTimestamp)
        {
            orderStatus = OrderStatus;
            buffers = Buffers;
            createdTimestamp = CreatedTimestamp;
        }
        
        [JsonProperty("orderStatus")]
        public string orderStatus { get; set; }

        [JsonProperty("buffers")]
        public List<OrderBuffers> buffers { get; set; }

        [JsonProperty("createdTimestamp")]
        public Int64 createdTimestamp { get; set; }

    }

    class OrderBuffers
    {
        public OrderBuffers(int TotalCodes, int AvailableCodes, string OrderId, string Gtin, string BufferStatus)
        {
            totalCodes = TotalCodes;
            availableCodes = AvailableCodes;
            orderId = OrderId;
            gtin = Gtin;
            bufferStatus = BufferStatus;
        }

       
        [JsonProperty("totalCodes")]
        public int totalCodes { get; set; }

        [JsonProperty("availableCodes")]
        public int availableCodes { get; set; }

        [JsonProperty("orderId")]
        public string orderId { get; set; }

        [JsonProperty("gtin")]
        public string gtin { get; set; }

        [JsonProperty("bufferStatus")]
        public string bufferStatus { get; set; }

    }

    class BufferInfo
    {
        [JsonProperty("totalCodes")]
        public int totalCodes { get; set; }

        [JsonProperty("availableCodes")]
        public int availableCodes { get; set; }

        [JsonProperty("orderId")]
        public string orderId { get; set; }

        [JsonProperty("gtin")]
        public string gtin { get; set; }

        [JsonProperty("bufferStatus")]
        public string bufferStatus { get; set; }

        [JsonProperty("expiredDate")]
        public Int64 expiredDate { get; set; }
    }

    //class Codes
    //{
        
    //    public markWS.СтрокаСтатусКМ  { get; set; }
    //    public DateTime Date { get; set; }
    //    [JsonProperty("blockId")]
    //    public string blockId { get; set; }
    //}
    
    class DataBase
    {
        public static MySql.Data.MySqlClient.MySqlConnection conn;
        public DataBase(string host, string port, string database, string username, string password)
        {
            string connString = "server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";SSL Mode=None; convert zero datetime=True";
            conn = new MySqlConnection(connString);

        }
        
        public void OpenConnection()
        {
           conn.Open();   
        }

        public bool CloseConnection()
        {
            conn.Close();
            // Выбьет эксепшн если не может
            return true;
        }

        public bool CheckOrdersTable()
        {
            //string count = "";
            //OpenConnection();
            //MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM orders WHERE productGroup = '" + Properties.Settings.Default.productGroup + "'", conn);
            //cmd.ExecuteNonQuery();
            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //  count = reader["count"].ToString();
            //}
            //reader.Close();
            //reader.Dispose();
            //CloseConnection();
            //if (count == "0")
            //    return false;
            //else
            return true;
        }

        public void SelectProd()
        {
            string gtin = null;
            string name = null;
            List<string> gtins = new List<string>();
            List<string> names = new List<string>();
            
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT GtinId, GtinName FROM gtin", conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gtin = reader["GtinId"].ToString();
                name = reader["GtinName"].ToString();
                gtins.Add(gtin);
                names.Add(name);
            }
            reader.Close();
            reader.Dispose();
            CloseConnection();
            Properties.Settings.Default.name = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.gtin = new System.Collections.Specialized.StringCollection();

            foreach (string n in names)
            {
                Properties.Settings.Default.name.Add(n);   
            }

            foreach (string g in gtins)
            {
                Properties.Settings.Default.gtin.Add("0" + g);
            }

            Properties.Settings.Default.Save();

        }
        public void UploadKMToDB(markWS.СписокКМ poolKM)
        {
            List<markWS.КМ> km = new List<markWS.КМ>();
            string count = null;
           for(int i = 0; i < poolKM.Items.Length - 3; i++)
           {
                km.Add((markWS.КМ)poolKM.Items[i]);
           }
            OpenConnection();
            //DateTime date1 = new DateTime(2022, 10, 19, 11, 30, 25);
            //DateTime date2 = new DateTime(2022, 10, 19, 8, 36, 12);
            //DateTime date3 = new DateTime(2022, 10, 20, 13, 30, 25);
            foreach (markWS.КМ k in km)
            {
               //try
               //{
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO main (Code, GtinId, DateImport) VALUES (@code, " + k.gtin + ", @date);", DataBase.conn);
                    //MySqlCommand cmd = new MySqlCommand("INSERT INTO main (Code, GtinId, DateImport, StatusId, DatePrint, DateVerify) VALUES (@code, " + k.gtin + ", @date, 1, @datePrint, @dateVerify);", DataBase.conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = k.Код.Replace("(/29)", "\u001d");
                    cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
                    //cmd.Parameters.Add("@datePrint", MySqlDbType.DateTime).Value = date1;
                    //cmd.Parameters.Add("@dateVerify", MySqlDbType.DateTime).Value = date3;
                    cmd.ExecuteNonQuery();
               //}
               //catch(Exception ex) { }
            }
            MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) AS count FROM main WHERE GtinId = " + km[1].gtin +";", DataBase.conn);
            cmd2.ExecuteNonQuery();
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                count = reader["count"].ToString();
            }
            reader.Close();
            reader.Dispose();

            MySqlCommand cmd3 = new MySqlCommand("UPDATE gtin SET CountAviable = '" + count + "' WHERE  GtinId= " + km[1].gtin, DataBase.conn);
            cmd3.ExecuteNonQuery();
     
            CloseConnection();

        }

        public void WriteToOrdersTable(string orderId, string timeStamp, string gtin, int total, int available, string status)
        { 
            
            int index = 0;

            OpenConnection();

            DateTime beforeTime = new DateTime(1970, 1, 1);
            TimeSpan ts = new System.TimeSpan(0, 7, 0, 0);
            DateTime date;
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `orders` (`productGroup`, `id`, `date`, `name`, `total`, `available`, `status`) VALUES (@productGroup, @id, @date, @name, @total, @available, @status);", conn);

            cmd.Parameters.Add("@productGroup", MySqlDbType.VarChar).Value = Properties.Settings.Default.productGroup;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = orderId;
            if(timeStamp != "0")
            {
                timeStamp = timeStamp.Substring(0, timeStamp.Length - 3);
                date = beforeTime.AddSeconds(Convert.ToInt32(timeStamp)) + ts;

                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
            }
            else
            {
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
            }      

            index = Properties.Settings.Default.gtin.IndexOf(gtin);
            if (index != -1)
            {
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = gtin + ", " + Properties.Settings.Default.name[index];
            }
            else
            {
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = gtin;
            }
            cmd.Parameters.Add("@total", MySqlDbType.Int32).Value = total;
            cmd.Parameters.Add("@available", MySqlDbType.Int32).Value = available;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public DataTable ReadFromOrdersTable()
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT id, date, name, total, available, status FROM orders WHERE productGroup = '" + Properties.Settings.Default.productGroup + "' ORDER BY date DESC", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            CloseConnection();

            return table;
            
        }

        public void UpdateOrdersTable(List<string> ordersId, List<string> statuses, List<int> totals, List<int> availables)
        {
            OpenConnection();
            int i = 0;
            foreach (string order in ordersId)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE orders SET total = " + totals[i] + ", available = " + availables[i] + ", status = '" + statuses[i] + "' WHERE id = '" + order + "'",conn);
                cmd.ExecuteNonQuery();
                i++;
            }
            CloseConnection();
        }

        //public Tuple<List<string>, List<string>> GetOrderId()
        //{
        //    //List<string> ordersId = new List<string>();
        //    //List<string> gtins = new List<string>();

        //    //OpenConnection();
        //    //MySqlCommand cmd = new MySqlCommand("SELECT id, name FROM orders WHERE productGroup = '" + Properties.Settings.Default.productGroup + "'", conn);
        //    //cmd.ExecuteNonQuery();
        //    //MySqlDataReader reader = cmd.ExecuteReader();
        //    //while (reader.Read())
        //    //{
        //    //    ordersId.Add(reader["id"].ToString());
        //    //    gtins.Add(reader["name"].ToString().Substring(0, 14));
        //    //}
        //    //reader.Close();
        //    //reader.Dispose();
        //    //CloseConnection();
        //    //return Tuple.Create(ordersId, gtins);
        //}

        public List<string> GetQuantityFromDB(string gtin, DateTime dateVerify)
        {
            List<string> quantity = new List<string>();
            string count = "";
            //string count2 = "";
            //string count3 = "";
            //string count4 = "";
            //string count5 = "";

                DateTime startTime = new DateTime(Convert.ToInt16(dateVerify.Year), Convert.ToInt16(dateVerify.Month), Convert.ToInt16(dateVerify.Day));
                DateTime endTime = startTime.AddDays(1);
                string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
                string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");

                OpenConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", conn);
            //MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM main WHERE (DatePrint BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", conn);
            cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = reader["count"].ToString();
                    quantity.Add(count);
                }
                reader.Close();
                reader.Dispose();

                //MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) AS 'count' FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 10", conn);
                //cmd2.ExecuteNonQuery();
                //MySqlDataReader reader2 = cmd2.ExecuteReader();
                //while (reader2.Read())
                //{
                //    count2 = reader2["count"].ToString();
                //    quantity.Add(count2);
                //}
                //reader2.Close();
                //reader2.Dispose();

                //MySqlCommand cmd3 = new MySqlCommand("SELECT count(DISTINCT(FAgg)) AS COUNT FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinID = " + gtin + " AND StatusId = 11", conn);
                //cmd3.ExecuteNonQuery();
                //MySqlDataReader reader3 = cmd3.ExecuteReader();
                //while (reader3.Read())
                //{
                //    count3 = reader3["count"].ToString();
                //    quantity.Add(count3);
                //}
                //reader3.Close();
                //reader3.Dispose();

                //MySqlCommand cmd4 = new MySqlCommand("SELECT count(DISTINCT(SAgg)) AS COUNT FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinID = " + gtin + " AND StatusId = 11", conn);
                //cmd4.ExecuteNonQuery();
                //MySqlDataReader reader4 = cmd4.ExecuteReader();
                //while (reader4.Read())
                //{
                //    count4 = reader4["count"].ToString();
                //    quantity.Add(count4);
                //}
                //reader4.Close();
                //reader4.Dispose();



                //MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) AS COUNT FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 9", conn);
                //cmd2.ExecuteNonQuery();
                //MySqlDataReader reader5 = cmd2.ExecuteReader();
                //while (reader5.Read())
                //{
                //    count5 = reader5["count"].ToString();
                //    quantity.Add(count2);
                //}
                //reader5.Close();
                //reader5.Dispose();

                CloseConnection();
            
            return quantity;

        }

        public void UpdateStatusApp(List<string> appCodes)
        {
            string statusId = null;
           
            if (Properties.Settings.Default.productGroup == "water")
                statusId = "9";
            if (Properties.Settings.Default.productGroup == "beer")
                statusId = "11";
            try
            {
                OpenConnection();
                foreach (string code in appCodes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE main SET StatusId = " + statusId + " WHERE Code = @code", conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
                    if (cmd.ExecuteNonQuery() < 1)
                        throw new Exception("Не удалось выполнить запрос");
                }
                CloseConnection();
                API.appCodes.Clear();
            }
            catch 
            {
               

            }
        }

        public void UpdateStatusRej(List<string> rejCodes)
        {
            try
            {
                OpenConnection();
                foreach (string code in rejCodes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE main SET StatusId = 13 WHERE Code = @code", conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
                    if (cmd.ExecuteNonQuery() < 1)
                        throw new Exception("Не удалось выполнить запрос");
                }
                CloseConnection();
                API.rejCodes.Clear();
            }
            catch 
            {
                

            }
        }

        public void UpdateStatusAgg(string gtin, DateTime prodDate)
        {
            try
            {
                DateTime startTime = new DateTime(Convert.ToInt16(prodDate.Year), Convert.ToInt16(prodDate.Month), Convert.ToInt16(prodDate.Day));
                DateTime endTime = startTime.AddDays(1);
                string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
                string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");
                string productionDate = startTime.ToString("yyyy-MM-dd");
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE main SET StatusId = 12 WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 11", conn);
                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("Не удалось выполнить запрос");
                CloseConnection();
            }
            catch 
            {
                
            }
        }

        public void UpdateStatusCirc(string gtin, DateTime prodDate)
        {
            try
            {
                DateTime startTime = new DateTime(Convert.ToInt16(prodDate.Year), Convert.ToInt16(prodDate.Month), Convert.ToInt16(prodDate.Day));
                DateTime endTime = startTime.AddDays(1);
                string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
                string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");
                string productionDate = startTime.ToString("yyyy-MM-dd");
                OpenConnection();
                foreach (string code in API.codes)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE main SET StatusId = 7, DateExport = @dateExport WHERE Code = @code", conn);
                    cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = code.Replace("(/29)", "\u001d");
                    cmd.Parameters.Add("@dateExport", MySqlDbType.DateTime).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();   
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageWindow msg = new MessageWindow(ex.Message, true);
                msg.Show();

            }
        }
    }
    class WebService1C
    {
       markWS.homeportPortTypeClient ws;
      
        public markWS.РезультатОбработкиЗаказа OrderCodes(string gtin, string count, string inn)
        {

            ws = new markWS.homeportPortTypeClient("homeportSoap");
            ws.ClientCredentials.UserName.UserName = "ws";
            ws.ClientCredentials.UserName.Password = "123";

            markWS.Заказ order = new markWS.Заказ();
            markWS.Организация org = new markWS.Организация();
            markWS.СтрокаЗаказа strOrder = new markWS.СтрокаЗаказа();

            org.инн = inn;
            strOrder.gtin = gtin;
            strOrder.Количество = Convert.ToInt32(count);

            order.Items = new object[] { org, strOrder };

            markWS.РезультатОбработкиЗаказа resultOrder = ws.ЗаказатьКоды(order);
            return resultOrder;

            
        }
        public markWS.СписокКМ GetCodes(markWS.РезультатОбработкиЗаказа resultOrder)
        {
            markWS.СписокКМ poolKM = null;
            
            ws = new markWS.homeportPortTypeClient("homeportSoap");
            ws.ClientCredentials.UserName.UserName = "ws";
            ws.ClientCredentials.UserName.Password = "123";

            //try
            //{
            poolKM = ws.ПолучитьКоды(resultOrder.ИдЗаказаЧЗ);
            //poolKM = ws.ПолучитьКоды("5abcc95c-d5ae-4be8-ae31-dc196841419c");
            return poolKM;

            //}
            //catch {
            //    return poolKM;
            //}

            
        }
    }
    class API
    {
        public static List<string> codes = new List<string>();
        public static string reportId;
        public static string docId;
        public static List<string> appCodes = new List<string>();
        public static List<string> appDates = new List<string>();
        public static List<string> rejCodes = new List<string>();
        public static List<string> orders = new List<string>();
        public static List<string> gtins = new List<string>();

        markWS.homeportPortTypeClient ws;
        public static markWS.РезультатОбработкиОтчетаКМ reportResult;
        DataBase dB = new DataBase(Properties.Settings.Default.host, Properties.Settings.Default.port, Properties.Settings.Default.database, Properties.Settings.Default.user, Properties.Settings.Default.password);
        CSP csp = new CSP();
        public Tuple<string, string> AuthRequest()
        {
            string line = "";
            string str = null;
            string uuid = null;
            string data = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlServer + "api/v3/true-api/auth/key");
                httpWebRequest.Method = "GET";
                WebResponse response = httpWebRequest.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {

                        while ((line = reader.ReadLine()) != null)
                        {
                            str = line;
                        }

                    }
                }
                uuid = str.Substring(9, 36);
                data = str.Substring(55, 30);

                
            }
            catch
            {
                
            }

            return Tuple.Create(uuid, data);
        }
        public Tuple<string, DateTime> Token()
        {

            string token_json;
            DateTime now = DateTime.Now;
            Properties.Settings.Default.dateTime = now;
            CSP csp = new CSP();
            string token = null;
            Tuple<string, string> returnRequest = AuthRequest();
            string newData = csp.SigningData(returnRequest.Item2, "", "txt");
            Properties.Settings.Default.newData = newData;
            Properties.Settings.Default.Save();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlServer + "api/v3/true-api/auth/simpleSignIn/" + Properties.Settings.Default.idConn);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Token json = new Token();
                    json.uuid = returnRequest.Item1;
                    json.data = newData;

                    string json2 = json.GetJsonString();
                    streamWriter.Write(json2);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    token_json = streamReader.ReadToEnd();
                }

                token = token_json.Substring(10, 36);
                Properties.Settings.Default.token = token;
            }
            catch (Exception ex)
            {
                MessageWindow msg = new MessageWindow(ex.Message, true);
                msg.Show();
            }

            return Tuple.Create(token, now);
        }

        public string BearerToken()
        {
            string token_json;
            string bearerToken = null;
            try
            {
                Tuple<string, string> returnRequest = AuthRequest();
                CSP csp = new CSP();
                string newData = csp.SigningData(returnRequest.Item2, "", "txt");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlServer + "api/v3/true-api/auth/simpleSignIn");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Token json = new Token();
                    json.uuid = returnRequest.Item1;
                    json.data = newData;

                    string json2 = json.GetJsonString();
                    streamWriter.Write(json2);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    token_json = streamReader.ReadToEnd();
                }

                 bearerToken = token_json.Substring(10, token_json.Length - 29);
            }
            catch 
            {
                
            }

            return bearerToken;
        }

        public Tuple<string, string, bool> ReportStatus(string reportId)
        {

            string line;
            string response = "";
            ReportStatusResponse reportStatus = new ReportStatusResponse();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlSUZ + "api/v2/" + Properties.Settings.Default.productGroup + "/report/info?reportId=" + reportId + "&omsId=" + Properties.Settings.Default.omsID);
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("clientToken", Properties.Settings.Default.token);
                httpWebRequest.ContentType = "application/json";

                WebResponse httpResponse = httpWebRequest.GetResponse();

                using (Stream stream = httpResponse.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(stream))
                    {

                        while ((line = responseReader.ReadLine()) != null)
                        {
                            response = line;
                        }
                    }
                }

                reportStatus = JsonConvert.DeserializeObject<ReportStatusResponse>(response);
            }
            catch
            {
                return Tuple.Create(reportStatus.reportStatus, reportStatus.errorReason, false);

            }

            return Tuple.Create(reportStatus.reportStatus, reportStatus.errorReason, true);
        }

        public markWS.СтатусВводаВОборот ReportStatusCirc()
        {
            
            markWS.СтатусВводаВОборот reportStatus = new markWS.СтатусВводаВОборот();
            try
            {

                ws = new markWS.homeportPortTypeClient("homeportSoap");
                ws.ClientCredentials.UserName.UserName = "ws";
                ws.ClientCredentials.UserName.Password = "123";
                string str = reportResult.Items[2].ToString();
                reportStatus =  ws.ПолучитьСтатусВводаВОборот(str);
                

            }
            catch
            {
                //return Tuple.Create(reportStatusCirc.status, reportStatusCirc.errors, false);
                return null;
            }
            return reportStatus;
            /*Tuple.Create(reportStatusCirc.status, reportStatusCirc.errors, true);*/
        }

        

        public void ReportCirc(string gtin, DateTime prodDate)
        {

            codes.Clear();
            List<string> dates = new List<string>();
            DateTime startTime = new DateTime(Convert.ToInt16(prodDate.Year), Convert.ToInt16(prodDate.Month), Convert.ToInt16(prodDate.Day));
            DateTime endTime = startTime.AddDays(1);
            string startTimeStr = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            string endTimeStr = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            string productionDate = startTime.ToString("yyyy-MM-dd");
            int k = 0;
            try
            {
                dB.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT Code, DateVerify FROM main WHERE (DateVerify BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", DataBase.conn);
                //MySqlCommand cmd = new MySqlCommand("SELECT Code, DatePrint FROM main WHERE (DatePrint BETWEEN '" + startTimeStr + "' AND '" + endTimeStr + "') AND GtinId = " + gtin + " AND StatusId = 2", DataBase.conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    k++;
                    if (k <= 29998)
                    {
                        codes.Add(reader["Code"].ToString().Replace("\u001d", "(/29)")/*.Substring(0, reader["Code"].ToString().Length - 7)*/);
                        dates.Add(reader["DateVerify"].ToString());
                        //dates.Add(reader["DatePrint"].ToString());
                    }
                    else
                        break;

                }
                reader.Close();
                reader.Dispose();

                
                dB.CloseConnection();

                ws = new markWS.homeportPortTypeClient("homeportSoap");
                ws.ClientCredentials.UserName.UserName = "ws";
                ws.ClientCredentials.UserName.Password = "123";
                markWS.СтрокаСтатусКМ[] kmArr = new markWS.СтрокаСтатусКМ[codes.Count()];
                markWS.Организация org = new markWS.Организация();
                markWS.ОтчетКМ report = new markWS.ОтчетКМ();
                org.инн = Properties.Settings.Default.oINN;
                object owner = Properties.Settings.Default.owINN;
                List<object> list = new List<object>();

                for (int i = 0; i < codes.Count(); i++)
                {
                    kmArr[i] = new markWS.СтрокаСтатусКМ();
                    kmArr[i].КМ = codes[i];
                    kmArr[i].ДатаПроизводства = Convert.ToDateTime(dates[i]);

                }
                list.Add(Properties.Settings.Default.wells);
                list.Add(Properties.Settings.Default.certNumber);
                list.Add(org);
                list.Add(Properties.Settings.Default.employer);
                list.Add(owner);
                list.AddRange(kmArr.ToArray());
                List<markWS.ItemsChoiceType1> choice = new List<markWS.ItemsChoiceType1>();

                choice.Add(markWS.ItemsChoiceType1.НомерЛицензии);
                choice.Add(markWS.ItemsChoiceType1.НомерСертификата);
                choice.Add(markWS.ItemsChoiceType1.Организация);
                choice.Add(markWS.ItemsChoiceType1.Ответственный);
                choice.Add(markWS.ItemsChoiceType1.Собственник);
                for (int i = 0; i < codes.Count(); i++)
                {
                    choice.Add(markWS.ItemsChoiceType1.Строки);
                }
                report.ItemsElementName = choice.ToArray();
                report.Items = list.ToArray();
                
                
                reportResult = ws.ОтчетПоИспользованиюКМ(report);        
            }
            catch 
            {
                reportResult = null;
            }
        }
  
        public void ProductSearch()
        {
            
            string line;
            string str = null;
            string bearerToken = Properties.Settings.Default.bearerToken;
           
                string url = Properties.Settings.Default.urlServer + "api/v3/product/search?limit=50&offset=0&page=0&pg=" + Properties.Settings.Default.productGroup;
                string urlReplaced = url.Replace("markirovka.", "");
                var httpWebRequest2 = (HttpWebRequest)WebRequest.Create(urlReplaced);
                httpWebRequest2.Method = "GET";
                httpWebRequest2.ContentType = "application/json";
                httpWebRequest2.Headers.Add("Authorization", "Bearer " + bearerToken);

                WebResponse response2 = httpWebRequest2.GetResponse();

                using (Stream stream2 = response2.GetResponseStream())
                {
                    using (StreamReader reader2 = new StreamReader(stream2))
                    {

                        while ((line = reader2.ReadLine()) != null)
                        {
                            str = line;
                        }

                    }
                }

                CardProduct cp = JsonConvert.DeserializeObject<CardProduct>(str);

                Properties.Settings.Default.tnVed = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.name = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.gtin = new System.Collections.Specialized.StringCollection();

                foreach (CardProductResults cpr in cp.results)
                {
                    Properties.Settings.Default.name.Add(cpr.name);
                    Properties.Settings.Default.gtin.Add(cpr.gtin);
                    Properties.Settings.Default.tnVed.Add(cpr.tnVedCode10);
                }

                Properties.Settings.Default.Save();
            
            

        }

        public void OrderCodes(string gtin, string quantity)
        {
            string responce;
            Order order = new Order();
            OrderProducts products = new OrderProducts();
           
            products.gtin = gtin;
            products.quantity = Convert.ToInt32(quantity);
            products.serialNumberType = "OPERATOR";
            products.templateId = Convert.ToInt32(Properties.Settings.Default.codeID);
            products.cisType = "UNIT";

            order.products.Add(products);
            order.releaseMethodType = "PRODUCTION";
            order.productionOrderId = "99";
            order.createMethodType = "SELF_MADE";
            string json = order.GetJsonString();

            string signature = csp.SigningData(json, "-detached", "json");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlSUZ + "api/v2/" + Properties.Settings.Default.productGroup + "/orders?omsId=" + Properties.Settings.Default.omsID);
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
            httpWebRequest.Headers.Add("clientToken", Properties.Settings.Default.token);
            httpWebRequest.Headers.Add("X-Signature", signature);
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

             var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
             using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
             {
                responce = streamReader.ReadToEnd();
             }

            NewOrderResponse nor = JsonConvert.DeserializeObject<NewOrderResponse>(responce);
            orders.Add(nor.orderId);
            gtins.Add(gtin);
             
        }
        
        public DataTable GetStatusOrder()
        {
            string line;
            string json = null;
            int i = 0;
            DataTable dt = new DataTable();

            List<string> statuses = new List<string>();
            List<int> totals = new List<int>();
            List<int> availables = new List<int>();

            if (!dB.CheckOrdersTable()) { 
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlSUZ + "api/v2/" + Properties.Settings.Default.productGroup + "/orders?omsId=" + Properties.Settings.Default.omsID);
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("clientToken", Properties.Settings.Default.token);
                WebResponse response = httpWebRequest.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            json = line;
                        }
                    }
                }

                Orders orders = JsonConvert.DeserializeObject<Orders>(json);
                ProductSearch();
                foreach (OrderInfos infos in orders.orderInfos)
                {
                    foreach (OrderBuffers buffers in infos.buffers)
                    {
                        dB.WriteToOrdersTable(buffers.orderId, Convert.ToString(infos.createdTimestamp), buffers.gtin, buffers.totalCodes, buffers.availableCodes, buffers.bufferStatus);
                    }
                }

                dt = dB.ReadFromOrdersTable();
            }
            else
            {
               //Tuple<List<string>, List<string>> dbResponse = dB.GetOrderId();

                //foreach (string orderId in dbResponse.Item1)
                //{
                //    BufferInfo buffer = GetBufferInfo(orderId, dbResponse.Item2[i++]);
                //    statuses.Add(buffer.bufferStatus);
                //    totals.Add(buffer.totalCodes);
                //    availables.Add(buffer.availableCodes);
                //}

                //dB.UpdateOrdersTable(dbResponse.Item1, statuses, totals, availables);
                dt = dB.ReadFromOrdersTable();
            }
            
            return dt;
        }

        

        public DataTable GetFullStatusBuffer()
        {
            
            DataTable dt = new DataTable();
            int i = 0;

            foreach (string orderId in orders)
            {
               BufferInfo buffer = GetBufferInfo(orderId, gtins[i++]); 
               ProductSearch();
               dB.WriteToOrdersTable(buffer.orderId, Convert.ToString(buffer.expiredDate), buffer.gtin, buffer.totalCodes, buffer.availableCodes, buffer.bufferStatus);
            }

            if(Properties.Settings.Default.ordersId != null)
            {
                foreach (string orderId in Properties.Settings.Default.ordersId)
                {
                    BufferInfo buffer = GetBufferInfo(orderId, Properties.Settings.Default.gtinsOrders[i++]);
                    ProductSearch();
                    dB.WriteToOrdersTable(buffer.orderId, Convert.ToString(buffer.expiredDate), buffer.gtin, buffer.totalCodes, buffer.availableCodes, buffer.bufferStatus);
                }
                Properties.Settings.Default.ordersId.Clear();
                Properties.Settings.Default.gtinsOrders.Clear();
                Properties.Settings.Default.Save();
            }
            dt = dB.ReadFromOrdersTable();
            return dt;
        }

        public Tuple<List<string>, List<int>, List<int>> GetOnlyStatusBuffer()
        {
            //Tuple<List<string>, List<string>> ordersAndGtins = dB.GetOrderId();
            List<string> statuses = new List<string>();
            List<int> totals = new List<int>();
            List<int> availables = new List<int>();
            int i = 0;

            foreach (string orderId in orders)
            {
                BufferInfo buffer = GetBufferInfo(orderId, gtins[i++]);
                statuses.Add(buffer.bufferStatus);
                totals.Add(buffer.totalCodes);
                availables.Add(buffer.availableCodes);
            }

            return Tuple.Create(statuses, totals, availables);
        }

        public BufferInfo GetBufferInfo(string orderId, string gtin)
        {
            string line;
            string json = null;

            //Сформировать запрос статуса КМ из бизнес-заказа
            try //Проверить наличие ошибок
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.urlSUZ + "api/v2/" + Properties.Settings.Default.productGroup + "/buffer/status?orderId=" + orderId + "&gtin=" + gtin + "&omsId=" + Properties.Settings.Default.omsID);
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("clientToken", Properties.Settings.Default.token);
                WebResponse response = httpWebRequest.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            json = line;
                        }
                    }
                }

                BufferInfo buffer = JsonConvert.DeserializeObject<BufferInfo>(json);
                return buffer;
            }
            catch // Зарегистрировать ошибку в журнале
            {
                return null;
            }
              
        }
    }

    class CSP
    {
        public Tuple<List<string>, List<string>> GetCertInfo()
        {
            string[] arr;
            string listInfo = null;
            string substr = null;
            string date = null;
            int startIndex = 0;
            int endIndex = 0;

            List<string> data = new List<string>();
            List<string> dateArr = new List<string>();
            List<string> arrCert = new List<string>();
            List<string> noTrimArr = new List<string>();

            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = @"C:\Program Files\Crypto Pro\CSP\certmgr",
                Arguments = "-list",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                StandardOutputEncoding = Encoding.GetEncoding("CP866")

            }) ;

            listInfo = process.StandardOutput.ReadToEnd();
            string[] separator = { Environment.NewLine };
            arr = listInfo.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in arr)
            {
                int indexOfSubstring = str.IndexOf("Subject");
                int indexOfDate = str.IndexOf("Not valid after");

                if (indexOfSubstring != -1)
                {
                    substr = str.Substring(indexOfSubstring + 7);
                    indexOfSubstring = str.IndexOf("O=");
                    startIndex = indexOfSubstring;
                    if(indexOfSubstring != -1)
                    {
                        substr = str.Substring(indexOfSubstring);
                        endIndex = substr.IndexOf(",");
                        startIndex = substr.IndexOf("O=");
                        if (endIndex != -1)
                        {
                            substr = substr.Substring(2, endIndex - 2);
                            noTrimArr.Add(substr);
                            substr = substr.Replace("\"", "");
                            data.Add(substr);
                        }

                    }
                }

                if (indexOfDate != -1)
                {
                    date = str.Substring(indexOfDate + 22);
                    dateArr.Add(date);
                }

            }
            for (int s = 0; s < data.Count; s++)
            {
                arrCert.Add(data[s] + " " + dateArr[s]);
            }

            return Tuple.Create(arrCert, noTrimArr);
        }

        public string SigningData(string data, string key, string format)
        {
            string cert = Properties.Settings.Default.noTrimCert;
            int indexOfSubstring = cert.IndexOf("\"\"");

            if (indexOfSubstring != -1)
            {
                cert = cert.Substring(indexOfSubstring + 2);
                cert = cert.Substring(0, cert.Length - 3);
            }

            using (FileStream fstream = new FileStream("C:\\buffer\\input." + format, FileMode.Create))
            {
              
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(data);
                // запись массива байтов в файл
                //await fstream.WriteAsync(buffer, 0, buffer.Length);
                fstream.Write(buffer, 0, buffer.Length);
               
            }
            
            ProcessStartInfo start = new ProcessStartInfo("C:\\Program Files\\Crypto Pro\\CSP\\csptest.exe");
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.Arguments = "ENTERPRISE /F " + Properties.Settings.Default.pathDb1C + " /N " + Properties.Settings.Default.login1C + " /P " + Properties.Settings.Default.password1C;
            start.CreateNoWindow = true;
            Process process = Process.Start(start);
            process.WaitForExit();
            process.Close();
            process.Dispose();

            byte[] byteFile = File.ReadAllBytes("C:\\buffer\\output." + format);
            string newData = System.Text.Encoding.UTF8.GetString(byteFile);
            newData = newData.Replace("\r", "");
            newData = newData.Replace("\n", "");

            return newData;
        }
    }
}
