using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ
{
    public partial class OrderForm : Form
    {
        //public static bool endCheck = false;
        //public static bool endCheck2 = false;
        //API api = new API();
        //public OrderForm()
        //{
        //    InitializeComponent();
        //    productGroupComboBox.Text = Properties.Settings.Default.fullProductGroup;

        //    DataTable tableOrders = api.GetStatusOrder();

        //    ordersGridView.DataSource = tableOrders;
        //    ordersGridView.Update();
                
        //    foreach (DataGridViewColumn column in ordersGridView.Columns)
        //    {
        //        column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //    }
        //}

        //private void orderKMButton_Click(object sender, EventArgs e)
        //{
        //    NewOrderForm nof = new NewOrderForm();
        //    nof.Show();
        //}

        //private void productGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Properties.Settings.Default.fullProductGroup = productGroupComboBox.Text;
        //    switch (Convert.ToString(productGroupComboBox.SelectedItem))
        //    {
        //        case "Молочная продукция":
        //            Properties.Settings.Default.productGroup = "milk";
        //            Properties.Settings.Default.codeID = "20";
        //            break;
        //        case "Вода питьевая":
        //            Properties.Settings.Default.productGroup = "water";
        //            Properties.Settings.Default.codeID = "16";
        //            break;
        //        case "Пиво и пивные напитки":
        //            Properties.Settings.Default.productGroup = "beer";
        //            Properties.Settings.Default.codeID = "18";
        //            break;
        //    }
        //    Properties.Settings.Default.Save();
        //    DataTable tableOrders;
        //    ordersGridView.AutoResizeColumns();
        //    while (ordersGridView.Rows.Count > 1)
        //    {
        //        ordersGridView.DataSource = null;
        //        ordersGridView.Rows.Clear();
        //    }
        //    try
        //    {
        //        //tableOrders = api.GetStatusOrder();
        //        //ordersGridView.DataSource = tableOrders;
        //        //ordersGridView.Update();

        //        foreach (DataGridViewColumn column in ordersGridView.Columns)
        //        {
        //            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //        }

        //        ordersGridView.AutoResizeColumns();
        //        api.ProductSearch();
        //    }
        //    catch
        //    {
        //        MessageWindow msg = new MessageWindow("Нет связи с СУЗ. Проверьте соединение с интернетом или c серверами ЧЗ и повторите попытку", true);
        //        msg.Show();
        //        GenForm gf = new GenForm();
        //        gf.Show();
        //        this.Close();
        //    }
        //}

        //private void uploadButton_Click(object sender, EventArgs e)
        //{
        //    int rowIndex = ordersGridView.CurrentRow.Index;
        //    this.Enabled = false;
        //    UploadCodesWindow ucw = new UploadCodesWindow(Convert.ToString(ordersGridView.Rows[rowIndex].Cells[0].Value), Convert.ToString(ordersGridView.Rows[rowIndex].Cells[2].Value), Convert.ToString(ordersGridView.Rows[rowIndex].Cells[3].Value));
        //    ucw.Show();
        //}

        //private void updateStatusButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable tableOrders;
        //        ordersGridView.AutoResizeColumns();
        //        while (ordersGridView.Rows.Count > 1)
        //        {
        //            ordersGridView.DataSource = null;
        //            ordersGridView.Rows.Clear();
        //        }

        //        tableOrders = api.GetStatusOrder();

        //        ordersGridView.DataSource = tableOrders;
        //        ordersGridView.Update();

        //        foreach (DataGridViewColumn column in ordersGridView.Columns)
        //        {
        //            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //        }

        //        ordersGridView.AutoResizeColumns();
        //    }
        //    catch
        //    {
        //        MessageWindow msg = new MessageWindow("Нет связи с СУЗ. Проверьте соединение с интернетом или c серверами ЧЗ и повторите попытку", true);
        //        msg.Show();
        //        GenForm gf = new GenForm();
        //        gf.Show();
        //        this.Close();
        //    }
        //}

        //private void checkOrdersTimer_Tick(object sender, EventArgs e)
        //{

        //}
        //private void backButton_Click(object sender, EventArgs e)
        //{
        //    GenForm gf = new GenForm();
        //    gf.Show();
        //    this.Close();
        //}
        //private void enabledTimer_Tick(object sender, EventArgs e)
        //{
        //    try 
        //    {
        //        if (endCheck == true)
        //        {
        //            DataTable tableOrders;

        //            while (ordersGridView.Rows.Count > 1)
        //            {
        //                ordersGridView.DataSource = null;
        //                ordersGridView.Rows.Clear();
        //            }

        //            //tableOrders = api.GetStatusOrder();
        //            //ordersGridView.AutoResizeColumns();
        //            //ordersGridView.DataSource = tableOrders;
        //            //ordersGridView.Update();

        //            foreach (DataGridViewColumn column in ordersGridView.Columns)
        //            {
        //                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //            }
        //            this.Enabled = true;
        //            ordersGridView.AutoResizeColumns();
        //            endCheck = false;
        //        }
        //    }
        //    catch
        //    {
        //        GenForm gf = new GenForm();
        //        gf.Show();
        //        this.Close();
        //    }

        //}

        //private void OrderForm_Load(object sender, EventArgs e)
        //{
        //    ordersGridView.AutoResizeColumns();
        //}

        //private void ordersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void newOrderTimer_Tick(object sender, EventArgs e)
        //{
        //    if (endCheck2 == true)
        //    {
        //        try
        //        {
        //            DataTable dt = api.GetFullStatusBuffer();
        //            while (ordersGridView.Rows.Count > 1)
        //            {
        //                ordersGridView.DataSource = null;
        //                ordersGridView.Rows.Clear();
        //            }

        //            ordersGridView.AutoResizeColumns();

        //            ordersGridView.DataSource = dt;

        //            ordersGridView.Update();


        //            foreach (DataGridViewColumn column in ordersGridView.Columns)
        //            {
        //                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //            }
        //        }
        //        catch
        //        {
        //            MessageWindow msg = new MessageWindow("Нет связи с СУЗ. Проверьте соединение с интернетом или c серверами ЧЗ и повторите попытку", true);
        //            msg.Show();
        //            foreach(string order in API.orders)
        //                Properties.Settings.Default.ordersId.Add(order);
        //            foreach (string gtin in API.gtins)
        //                Properties.Settings.Default.ordersId.Add(gtin);
        //        }
        //        this.Enabled = true;
        //        ordersGridView.AutoResizeColumns();
        //        newOrderTimer.Enabled = false;
        //        endCheck2 = false;
        //        checkStatusTimer.Enabled = true;
        //    }
        //}

        //private void checkStatusTimer_Tick(object sender, EventArgs e)
        //{
         
        //    Tuple<List<string>, List<int>, List<int>> response =  api.GetOnlyStatusBuffer();
        //    bool isAllEqual = response.Item1.Distinct().Count() == 1;
            
        //    for (int i = 0; i < response.Item1.Count(); i++)
        //    {
        //        if (isAllEqual == true && response.Item1[i] == "PENDING")
        //        {
        //            ordersGridView.Rows[i].Cells[5].Value = response.Item1[i];
        //            ordersGridView.Rows[i].Cells[3].Value = response.Item2[i];
        //            ordersGridView.Rows[i].Cells[4].Value = response.Item3[i];
        //        }
        //        else 
        //        {
        //            if(response.Item1[i] == "DECLINED")
        //            {
        //                ordersGridView.Rows[i].Cells[5].Value = response.Item1[i];
        //                ordersGridView.Rows[i].Cells[3].Value = response.Item2[i];
        //                ordersGridView.Rows[i].Cells[4].Value = response.Item3[i];
        //                ordersGridView.Rows.RemoveAt(i);
        //                response.Item1.RemoveAt(i);
        //            }
        //            if ((isAllEqual == true && response.Item1[i] == "ACTIVE") )
        //            {
        //                ordersGridView.Rows[i].Cells[5].Value = response.Item1[i];
        //                ordersGridView.Rows[i].Cells[3].Value = response.Item2[i];
        //                ordersGridView.Rows[i].Cells[4].Value = response.Item3[i];

        //                //DataTable tableOrders = api.GetStatusOrder();

        //                //ordersGridView.DataSource = tableOrders;
        //                //ordersGridView.Update();

        //                foreach (DataGridViewColumn column in ordersGridView.Columns)
        //                {
        //                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //                }
        //                checkStatusTimer.Enabled = false;
        //            }
        //            else if(response.Item1.Count == 0)
        //            {
        //                //DataTable tableOrders = api.GetStatusOrder();

        //                //ordersGridView.DataSource = tableOrders;
        //                //ordersGridView.Update();

        //                foreach (DataGridViewColumn column in ordersGridView.Columns)
        //                {
        //                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //                }
        //                checkStatusTimer.Enabled = false;
        //            }
        //        }
        //     }

        //}
    }
}
