using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace FeedScanAlgo
{
    public struct Feed
    {
        public String symbol;
        public double BidPrice;
        public int BidQty;
        public double AskPrice;
        public int AskQty;
        public DateTime dttIME;
        public double Distance;
        public double _Index;
    };

    public struct Feed_Depth
    {
        public String symbol;
        public String BidExch;
        public int BidSize;
        public double Bid;

        public String AskExch;
        public int AskSize;
        public double Ask;

        public String LastExch;
        public int lastSize;
        public double Last;

        public DateTime dtFeed;
    };

    public struct Trade
    {
        public String symbol;
        public String Customer;
        public double Price_LP;
        public Int32 Qty_LP;
        public double Price_LT;
        public Int32 Qty_LT;
        public double Qty;
        public String OrdNo;

        public int T1_Sec;
        public int T1_Milli_Sec;
        public int T2_Sec;
        public int T2_Milli_Sec;
        public int T3_Sec;
        public int T3_Milli_Sec;
        public int T4_Sec;
        public int T4_Milli_Sec;

        public int BidQty;
        public double AskPrice;
        public int AskQty;
        public DateTime dttIME;
        public double Distance;
        public double _Index;
    };


    public partial class Form1 : Form
    {
        public Hashtable ht_Symbol = new Hashtable();
        public Hashtable ht_RTFeed = new Hashtable();

        public Hashtable ht_LP_Unmanaged = new Hashtable();
        public Hashtable ht_LT_Unmanaged = new Hashtable();
        public Hashtable ht_Managed = new Hashtable();

        public ArrayList arr_Managed = new ArrayList();

        Random rand = new Random();
        public FileStream SourceStream_Simualtor = null;
        public StreamWriter stWriter_Simualtor = null;
        public Form1()
        {
            InitializeComponent();

            comboBox4.SelectedIndex = 1;
            comboBox3.SelectedIndex = 0;

            textBox20.Text = "47";
            textBox16.Text = "47";

            List<Feed> lstFeed = new List<Feed>();
            Feed oFeedobj= new Feed();
            oFeedobj.symbol = "MSFT";
            oFeedobj.BidPrice = 47.65;
            oFeedobj.BidQty = 80;
            lstFeed.Add(oFeedobj);

            oFeedobj = new Feed();
            oFeedobj.symbol = "MSFT";
            oFeedobj.BidPrice = 47.65;
            oFeedobj.BidQty = 80;
            lstFeed.Add(oFeedobj);

            oFeedobj = new Feed();
            oFeedobj.symbol = "MSFT";
            oFeedobj.BidPrice = 47.52;
            oFeedobj.BidQty = 70;
            lstFeed.Add(oFeedobj);

            oFeedobj = new Feed();
            oFeedobj.symbol = "MSFT";
            oFeedobj.BidPrice = 47.65;
            oFeedobj.BidQty = 60;
            lstFeed.Add(oFeedobj);

            String changePass = "C:\\AlertSend\\Simulator_22.txt";
            //SourceStream_Simualtor = File.Open(changePass, FileMode.OpenOrCreate);
            //stWriter_Simualtor = new StreamWriter(SourceStream_Simualtor);
           

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            // oFeedobj.BidPrice = 47.64;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.68;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.68;
            //oFeedobj.BidQty = 60;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.60;
            //oFeedobj.BidQty = 70;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.63;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.63;
            //oFeedobj.BidQty = 65;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            // oFeedobj.BidPrice = 47.62;
            //oFeedobj.BidQty = 60;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.56;
            //oFeedobj.BidQty = 70;
            //lstFeed.Add(oFeedobj);

            //oFeedobj.BidPrice = 47.60;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.60;
            //oFeedobj.BidQty = 65;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.62;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.69;
            //oFeedobj.BidQty = 65;
            //lstFeed.Add(oFeedobj);

            //oFeedobj.BidPrice = 47.60;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.60;
            //oFeedobj.BidQty = 65;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.62;
            //oFeedobj.BidQty = 80;
            //lstFeed.Add(oFeedobj);

            //oFeedobj = new Feed();
            //oFeedobj.symbol = "MSFT";
            //oFeedobj.BidPrice = 47.62;
            //oFeedobj.BidQty = 65;
            //lstFeed.Add(oFeedobj);


            //ThreadStart mpThread_QuoteBase = delegate { Process_Full(lstFeed); };
            //Thread threadObj_QuoteBase = new Thread(new ThreadStart(mpThread_QuoteBase));
            //threadObj_QuoteBase.Start();

         


            //ThreadStart mpThread_QuoteBase = delegate { RandomNo(); };
            //Thread threadObj_QuoteBase = new Thread(new ThreadStart(mpThread_QuoteBase));
            //threadObj_QuoteBase.Start();

            //ThreadStart mpThread_Time = delegate { Process_Timer(); };
            //Thread threadOb_Timer = new Thread(new ThreadStart(mpThread_Time));
            //threadOb_Timer.Start();

             int tt = 100;

             //ThreadStart mpThread_QuoteBase = delegate { Process_Quote(); };
             //Thread threadObj_QuoteBase = new Thread(new ThreadStart(mpThread_QuoteBase));
             //threadObj_QuoteBase.Start();

             //ThreadStart mpThread_QuoteBase = delegate { FeedObj(); };
             //Thread threadObj_QuoteBase = new Thread(new ThreadStart(mpThread_QuoteBase));
             //threadObj_QuoteBase.Start();

             //ThreadStart mpThread_Task3 = delegate { Process_Task3(); };
             //Thread threadObj_Task3 = new Thread(new ThreadStart(mpThread_Task3));
             //threadObj_Task3.Start();

             ThreadStart mpThread_QuoteBase_Event = delegate { DisplayScren(); };
             Thread threadObj_QuoteBase_Event = new Thread(new ThreadStart(mpThread_QuoteBase_Event));
             threadObj_QuoteBase_Event.Start();

             ThreadStart mpThread_QC= delegate { AllFeedExch(); };
             Thread threadObj_QC = new Thread(new ThreadStart(mpThread_QC));
             threadObj_QC.Start();
         

             //ThreadStart mpThread_QuoteBase_Event = delegate { Process_Quote_Event(); };
             //Thread threadObj_QuoteBase_Event = new Thread(new ThreadStart(mpThread_QuoteBase_Event));
             //threadObj_QuoteBase_Event.Start();
        }
       
        private void DisplayScren()
        {
            Thread.Sleep(5000);
            while (true)
            {
                this.Invoke(((MethodInvoker)delegate
                {
                    ArrayList arr_List = new ArrayList();
                    foreach (DictionaryEntry dtEntry in ht_LP_Unmanaged)
                    {
                        int size = (int)dtEntry.Key;
                        arr_List.Add(size);
                    }
                    arr_List.Sort();

                    ArrayList arr_List_LT = new ArrayList();
                    foreach (DictionaryEntry dtEntry in ht_LT_Unmanaged)
                    {
                        int size = (int)dtEntry.Key;
                        arr_List_LT.Add(size);
                    }

                    arr_List_LT.Sort();


                    dataGridView2.Rows.Clear();
                    for (int ind = arr_List.Count -1; ind >= 0; ind--)
                    {
                        int size = (int)arr_List[ind];
                        if (ht_LP_Unmanaged.Contains(size))
                        {
                            ArrayList oArrTotal = (ArrayList)ht_LP_Unmanaged[size];

                            for (int ind1 = 0; ind1 < oArrTotal.Count; ind1++)
                            {
                                Order ORD = (Order)oArrTotal[ind1];

                                int OrdQty = Convert.ToInt32(ORD.OrderSize);
                                int roundqty = OrdQty / 100;
                                int total = roundqty * 100;
                                InsertGrid(ORD);
                            }
                        }
                    }

                    Trade oTrade = new Trade();
                    for (int ind = arr_List_LT.Count-1; ind >= 0; ind--)
                    {
                        int size = (int)arr_List_LT[ind];
                        if (ht_LT_Unmanaged.Contains(size))
                        {
                            ArrayList oArrTotal = (ArrayList)ht_LT_Unmanaged[size];

                            //ArrayList oArr = new ArrayList();
                            for (int ind1 = 0; ind1 < oArrTotal.Count; ind1++)
                            {
                                Order ORD = (Order)oArrTotal[ind1];
                                if (ht_RTFeed.Contains(ORD.Symbol))
                                {
                                    Feed feedObj = (Feed)ht_RTFeed[ORD.Symbol];
                                    if (feedObj.BidPrice > Convert.ToDouble(ORD.Limit))
                                        InsertGrid(ORD);
                                    else
                                    {
                                        for (int ind2 = 0; ind2 < dataGridView2.Rows.Count - 1; ind2++)
                                        {
                                            if (dataGridView2.Rows[ind2].Cells[21].Style.BackColor == Color.LightGreen)
                                            {
                                                double currentLTP = Convert.ToDouble(dataGridView2.Rows[ind2].Cells[17].Value);
                                                double currentQty = Convert.ToDouble(dataGridView2.Rows[ind2].Cells[18].Value);
                                                int OrderQty_LP = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[9].Value);

                                                if (currentLTP <= 0 && currentQty <= 0 && size <= OrderQty_LP)
                                                {
                                                    dataGridView2.Rows[ind2].Cells[17].Value = ORD.Limit;
                                                    dataGridView2.Rows[ind2].Cells[18].Value = ORD.OrderSize;

                                                    dataGridView2.Rows[ind2].Cells[2].Value = ORD.SEC;
                                                    dataGridView2.Rows[ind2].Cells[3].Value = ORD.MilliSec;
                                                    for (int ind3 = 0; ind3 < dataGridView2.ColumnCount; ind3++)
                                                    {
                                                        dataGridView2.Rows[ind].Cells[ind3].Style.BackColor = Color.LightPink;
                                                    }

                                                    double currentLTP1 = Convert.ToDouble(dataGridView2.Rows[ind2].Cells[10].Value);
                                                    Int32 currentQty1 = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[9].Value);

                                                    oTrade.Customer = ORD.CustNo;
                                                    oTrade.symbol = ORD.Symbol;
                                                    oTrade.Price_LP = currentLTP1;
                                                    oTrade.Qty_LP = currentQty1;
                                                    oTrade.OrdNo = Convert.ToString(dataGridView2.Rows[ind2].Cells[10].Value);

                                                    oTrade.Price_LT = Convert.ToDouble(ORD.Limit);
                                                    oTrade.Qty_LT = Convert.ToInt32(ORD.OrderSize);

                                                    oTrade.T1_Sec = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[0].Value);
                                                    oTrade.T1_Milli_Sec = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[1].Value);
                                                    oTrade.T2_Sec = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[2].Value);
                                                    oTrade.T2_Milli_Sec = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[3].Value);

                                                    ThreadStart mpThread_QuoteBase_Event = delegate { MatchInitial(ORD, oTrade); };
                                                    Thread threadObj_QuoteBase_Event = new Thread(new ThreadStart(mpThread_QuoteBase_Event));
                                                    threadObj_QuoteBase_Event.Start();
                                                   

                                                   // oTrade.T1_Sec = Convert.ToInt32(dataGridView2.Rows[ind2].Cells[17].Value);

                                                    break;
                                                }                                               
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (ht_LP_Unmanaged.Contains(oTrade.Qty_LP))
                    {
                        ArrayList arr_Ordr = (ArrayList)ht_LP_Unmanaged[oTrade.Qty_LP];
                        ArrayList arr_New = (ArrayList)arr_Ordr.Clone();

                        for (int ind1 = 0; ind1 < arr_Ordr.Count; ind1++)
                        {
                            Order ord = (Order)arr_Ordr[ind1];
                            if (Convert.ToDouble(ord.Limit) == oTrade.Price_LP)
                            {
                                arr_New.RemoveAt(ind1);
                                break;
                            }
                        }

                        ht_LP_Unmanaged[oTrade.Qty_LP] = arr_New;
                    }

                    if (ht_LT_Unmanaged.Contains(oTrade.Qty_LT))
                    {
                        ArrayList arr_Ordr = (ArrayList)ht_LT_Unmanaged[oTrade.Qty_LT];
                        ArrayList arr_New = (ArrayList)arr_Ordr.Clone();

                        for (int ind1 = 0; ind1 < arr_Ordr.Count; ind1++)
                        {
                            Order ord = (Order)arr_Ordr[ind1];
                            if (Convert.ToDouble(ord.Limit) == oTrade.Price_LT)
                            {
                                arr_New.RemoveAt(ind1);
                                break;
                            }
                        }

                        ht_LT_Unmanaged[oTrade.Qty_LT] = arr_New;
                    }

                    for (int ind_Mn = 0; ind_Mn < arr_Managed.Count; ind_Mn++)
                    {
                        Trade oTrade11 = (Trade)arr_Managed[ind_Mn];

                        this.Invoke(((MethodInvoker)delegate
                        {
                            int count = dataGridView2.Rows.Count;
                            dataGridView2.Rows.Add();
                            count = count - 1;

                            dataGridView2.Rows[count].Cells[15].Value = oTrade11.Customer;
                            dataGridView2.Rows[count].Cells[2].Value = oTrade11.T1_Sec;
                            dataGridView2.Rows[count].Cells[3].Value = oTrade11.T1_Milli_Sec;

                            //dataGridView2.Rows[count].Cells[6].Value = ord.MM;
                            //dataGridView2.Rows[count].Cells[7].Value = ord.YY;
                            //if (oTrade11.Buy_Sell.ToLower() == "buy")
                            //    dataGridView2.Rows[count].Cells[8].Value = "B";
                            //else
                            //    dataGridView2.Rows[count].Cells[8].Value = "S";



                            int remain = Convert.ToInt32(oTrade11.Qty_LT) / 100;
                            int total = remain * 100;

                            dataGridView2.Rows[count].Cells[9].Value = total;
                            dataGridView2.Rows[count].Cells[10].Value = oTrade11.Price_LP; 
                            dataGridView2.Rows[count].Cells[11].Value = "0";
                            dataGridView2.Rows[count].Cells[12].Value = oTrade11.symbol;

                            //int _ordFlag = (int)ord.ordStatus;
                            //dataGridView2.Rows[count].Cells[11].Value = _ordFlag;

                            //String arounf = orderNo.ToString();
                            //if (arounf.Length == 1)
                            //    arounf = "00000" + arounf;

                            //++orderNo;

                            //if (ord.oType == Provider.PROVIDER)
                            {
                                dataGridView2.Rows[count].Cells[0].Value = oTrade11.T2_Sec;
                                dataGridView2.Rows[count].Cells[1].Value = oTrade11.T2_Milli_Sec;
                                dataGridView2.Rows[count].Cells[2].Value = oTrade11.T2_Sec;
                                dataGridView2.Rows[count].Cells[3].Value = oTrade11.T2_Milli_Sec;
                                dataGridView2.Rows[count].Cells[4].Value = oTrade11.T3_Sec;
                                dataGridView2.Rows[count].Cells[5].Value = oTrade11.T3_Milli_Sec;

                                dataGridView2.Rows[count].Cells[17].Value = oTrade11.Price_LT;
                                dataGridView2.Rows[count].Cells[18].Value = oTrade11.Qty_LT;

                                for (int ind = 0; ind < dataGridView2.ColumnCount; ind++)
                                {
                                    dataGridView2.Rows[count].Cells[ind].Style.BackColor = Color.LightPink;
                                }
                            }

                            //if (ord.Enable)
                            //    dataGridView2.Rows[count].Cells[17].Value = "2";
                            //else
                            //    dataGridView2.Rows[count].Cells[17].Value = "1";

                            //dataGridView2.Rows[count].Cells[20].Value = ord.SA;
                            //dataGridView2.Rows[count].Cells[19].Value = ord.MS;

                            //dataGridView2.Rows[count].Cells[14].Value = arounf;

                            //ord.OrderIndex = count;

                        }));
                    }

                    // dataGridView2.Rows[count]
                }));
                Thread.Sleep(3000);
            }
        }

        private void Process_Full_Snap()
        {
            while (true)
            {
                  String response = "C:\\AlertSend\\data.txt";
                DateTime dtLast = DateTime.Now;
                Random rnd = new Random();
                int first = 0;
                while (true)
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader stWriter = new StreamReader(fileStream))
                            {
                                String lineNo = "";
                                while ((lineNo = stWriter.ReadLine()) != null)
                                {
                                    stWriter.Close();
                                    String[] arrLen = lineNo.Split('@');
                                    for (int ind = 0; ind < arrLen.Length; ind++)
                                    {
                                        String dat = arrLen[ind];
                                        if (dat.Length > 4)
                                        {
                                            String[] dataField = dat.Split(',');
                                            Feed oFeed = new Feed();
                                            oFeed.symbol = dataField[0];
                                            if (oFeed.symbol == "MSFT")
                                            {
                                                oFeed.AskPrice = Convert.ToDouble(dataField[1]);
                                                oFeed.AskQty = Convert.ToInt32(dataField[2]);
                                                oFeed.BidPrice = Convert.ToDouble(dataField[3]);
                                                oFeed.BidQty = Convert.ToInt32(dataField[4]);

                                                int hh = Convert.ToInt32(dataField[7]);
                                                int mm = Convert.ToInt32(dataField[8]);
                                                int ss = Convert.ToInt32(dataField[9]);

                                                DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh, mm, ss);
                                                
                                                if (!ht_RTFeed.Contains(oFeed.symbol))
                                                    ht_RTFeed.Add(oFeed.symbol, oFeed);
                                                else
                                                    ht_RTFeed[oFeed.symbol] = oFeed;

                                                String symbol_File = oFeed.symbol + "," + oFeed.BidPrice + "," + oFeed.BidQty + "," + hh + "," + mm + "," + ss;
                                                stWriter_Simualtor.WriteLine(symbol_File);
                                                stWriter_Simualtor.Flush();

                                                InsertGrid(oFeed);                                             
                                            }
                                            int thre = rand.Next(10, 100);
                                            Thread.Sleep(thre);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void Process_Full(List<Feed> lstFeed)
        {
            while(true)
            {
                for (int ind = 0; ind < lstFeed.Count; ind++)
                {
                    Feed feed = (Feed)lstFeed[ind];
                    feed.dttIME = DateTime.Now;
                    InsertGrid(feed);


                    if (!ht_RTFeed.Contains(feed.symbol))
                        ht_RTFeed.Add(feed.symbol, feed);
                    else
                        ht_RTFeed[feed.symbol] = feed;

                    int thre = rand.Next(10, 100);
                    Thread.Sleep(thre);
                }

               // Thread.Sleep(1000);
            }
        }

        public ArrayList arr = new ArrayList();
        private void Process_Full()
        {
            this.Invoke(((MethodInvoker)delegate
            {            
                int noOf = Convert.ToInt32(textBox12.Text);
                int delay = Convert.ToInt32(textBox13.Text);

                //while (true)
                {
                    int minQty = Convert.ToInt32(textBox25.Text);
                    int maxQty = Convert.ToInt32(textBox24.Text);
                    Random oRnad = new Random(10);
                    int qty_L = oRnad.Next(minQty, maxQty);
                    for( int indq = 0; indq < noOf; indq++)
                    {
                        //for (int ind = 0; ind < arr.Count; ind++)
                        //{
                            //Order ord = (Order)arr[0];
                            Order ordObj = new Order();
                            ordObj.Symbol = textBox17.Text;
                            qty_L = oRnad.Next(minQty, maxQty);
                            if (ht_RTFeed.Contains(ordObj.Symbol))
                            {
                                Feed feedObj = (Feed)ht_RTFeed[ordObj.Symbol];
                                ordObj.Limit = feedObj.BidPrice.ToString();
                            }
                            else
                            {
                                ordObj.Limit = textBox16.Text;
                            }

                            
                            ordObj.MS = textBox18.Text;
                            ordObj.SA = textBox19.Text;
                            ordObj.OrderSize = ordObj.SA;
                            ordObj.Buy_Sell = (String)comboBox3.SelectedItem;
                            ordObj.oType = Provider.PROVIDER;

                            String hour = DateTime.Now.Hour.ToString();
                            String min = DateTime.Now.Minute.ToString();
                            String sec = DateTime.Now.Second.ToString();
                            String Year = DateTime.Now.Year.ToString();
                            String Mon = DateTime.Now.Month.ToString();
                            String day = DateTime.Now.Day.ToString();
                            ordObj.MilliSec = DateTime.Now.Millisecond;
                            ordObj.HH = hour;
                            ordObj.MIN = min;
                            ordObj.SEC = sec;
                            ordObj.YY = Year;
                            ordObj.CustNo = "001";
                            ordObj.ordStatus = ORDER_STATUS.ACCEPTED;
                            ordObj.MM = Mon;
                            ordObj.DD = day;
                          
                            ordObj.OrderSize = qty_L.ToString();
                            ordObj.SA = ordObj.OrderSize;
                            //InsertGrid(ord);

                            int ORDERqRT = Convert.ToInt32(ordObj.OrderSize);
                            if (ht_LP_Unmanaged.Contains(ORDERqRT))
                            {
                                ArrayList _ordObj = (ArrayList)ht_LP_Unmanaged[ORDERqRT];
                                _ordObj.Add(ordObj);
                                //_ordObj.OrderSize += ordObj.OrderSize;
                                ht_LP_Unmanaged[ORDERqRT] = _ordObj;
                            }
                            else
                            {
                                ArrayList _ordObj = new ArrayList();
                                _ordObj.Add(ordObj);
                                ht_LP_Unmanaged[ORDERqRT] = _ordObj;
                            }


                            //ThreadStart mpThread_QuoteBase_Event = delegate { InsertGrid(ordObj); };
                            //Thread threadObj_QuoteBase_Event = new Thread(new ThreadStart(mpThread_QuoteBase_Event));
                            //threadObj_QuoteBase_Event.Start();
                     //   }
                          int thre = rand.Next(10, 100);
                          Thread.Sleep(thre);
                    }
                }

            }));
        }
       

        double Intial = 1;
        private void Process_Timer()
        {
            DateTime dtTime = new DateTime(2014, 01, 01, 00, 00, 00);
            DateTime dtInitial = dtTime;
            while (true)
            {                
                String hh = dtTime.Hour.ToString();
                if (hh.Length == 1)
                    hh = "0" + hh;

                String mm = dtTime.Minute.ToString();
                if (mm.Length == 1)
                    mm = "0" + mm;

                String ss = dtTime.Second.ToString();
                if (ss.Length == 1)
                    ss = "0" + ss;

                int ms_Sec = rand.Next(123, 900);

                TimeSpan tsSpan = dtTime - dtInitial;

                String timeStam = hh + ":" + mm + ":" + ss  ;

                Thread.Sleep(100);
                dtTime = dtTime.AddMilliseconds(100);
                try
                {
                    this.Invoke(((MethodInvoker)delegate
                    {                        
                        double value = tsSpan.TotalSeconds - (Intial * 0.1);
                        //textBox3.Text = tsSpan.TotalSeconds.ToString();
                        //textBox6.Text = Math.Round(value,2).ToString();
                    }));
                }
                catch (Exception ex) { }
            }
        }

        private void MatchInitial(Order ord, Trade oTrade)
        {
            double falseCount = 0, trueCount = 0; ;
            double total = 0;
            int ran = rand.Next(1, 5);
            while (true)
            {
                int value = Get_Primary_Time(1, 2);
                Thread.Sleep(100);
                Hashtable ht_Local = (Hashtable)ht_RTFeed.Clone();

                if (ht_RTFeed.Contains(ord.Symbol))
                {
                    Feed _oFeedObj = (Feed)ht_RTFeed[ord.Symbol];

                    int value11 = Get_Primary_Time(5, 2500);
                    Thread.Sleep(value11 * 2);

                    if (ht_RTFeed.Contains(ord.Symbol))
                    {
                        Feed oFeedObj = (Feed)ht_RTFeed[ord.Symbol];
                        String value11111 = "FALSE";
                        double OrdPrice = Convert.ToDouble(ord.Limit);
                        int OrdQty = Convert.ToInt32(ord.OrderSize);
                        if (_oFeedObj.BidPrice == oFeedObj.BidPrice)
                        {
                            value11111 = "TRUE";
                            ord.MilliSec += value11;
                            ++trueCount;
                        }
                        else
                        {
                            String ss = DateTime.Now.Second.ToString();
                            if (ss.Length == 1)
                                ss = "0" + ss;

                            int assignedMS = ord.MilliSec;   

                            ++falseCount;
                            oTrade.T4_Sec = Convert.ToInt32(ss);
                            oTrade.T4_Milli_Sec = assignedMS;
                        }

                        ++total;
                        this.Invoke(((MethodInvoker)delegate
                        {       
                            dataGridView2.Rows[ord.OrderIndex].Cells[23].Value = value11111;                            
                            dataGridView2.Rows[ord.OrderIndex].Cells[27].Value = value;

                            dataGridView2.Rows[ord.OrderIndex].Cells[32].Value = falseCount;
                            dataGridView2.Rows[ord.OrderIndex].Cells[33].Value = trueCount;
                         //   dataGridView2.Rows[ord.OrderIndex].Cells[30].Value = trueCount;.

                            if (falseCount == 1)
                                dataGridView2.Rows[ord.OrderIndex].Cells[30].Value = value11;

                            if (falseCount == 2)
                                dataGridView2.Rows[ord.OrderIndex].Cells[31].Value = value11;

                            double per = trueCount / total;
                            per = per * 100;
                            per = Math.Round(per, 2);
                         //   textBox10.Text = per.ToString();
                        }));

                        

                        if (value11111 == "TRUE")
                        {
                            String hh = DateTime.Now.Hour.ToString();
                            if (hh.Length == 1)
                                hh = "0" + hh;

                            String mm = DateTime.Now.Minute.ToString();
                            if (mm.Length == 1)
                                mm = "0" + mm;

                            String ss = DateTime.Now.Second.ToString();
                            if (ss.Length == 1)
                                ss = "0" + ss;

                            int assignedMS = ord.MilliSec;                           

                            dataGridView2.Rows[ord.OrderIndex].Cells[4].Value = ss;
                            dataGridView2.Rows[ord.OrderIndex].Cells[5].Value = assignedMS + value11;                            
                            dataGridView2.Rows[ord.OrderIndex].Cells[11].Value = "F";
                            dataGridView2.Rows[ord.OrderIndex].Cells[24].Value = hh;
                            dataGridView2.Rows[ord.OrderIndex].Cells[25].Value = mm;
                            dataGridView2.Rows[ord.OrderIndex].Cells[26].Value = ss;
                            dataGridView2.Rows[ord.OrderIndex].Cells[27].Value = assignedMS + value11;
                            dataGridView2.Rows[ord.OrderIndex].Cells[28].Value = value11;
                            dataGridView2.Rows[ord.OrderIndex].Cells[29].Value = assignedMS;
                          
                            if(falseCount == 1)
                                dataGridView2.Rows[ord.OrderIndex].Cells[30].Value = value11;

                            if (falseCount == 2)
                                dataGridView2.Rows[ord.OrderIndex].Cells[31].Value = value11;

                            dataGridView2.Rows[ord.OrderIndex].Cells[32].Value = falseCount;
                            dataGridView2.Rows[ord.OrderIndex].Cells[33].Value = trueCount;

                            oTrade.T3_Sec = Convert.ToInt32(ss);
                            oTrade.T3_Milli_Sec = Convert.ToInt32(dataGridView2.Rows[ord.OrderIndex].Cells[5].Value);

                            arr_Managed.Add(oTrade);
                            
                            break;
                        }

                    }
                }
            }
        }

        private void Process_Task3()
        {
            
            double trueCount = 0;
            double falseCount = 0;
            while (true)
            {
                int value = Get_Primary_Time(1, 2);
                Thread.Sleep(100);

                //List<Feed> lstFeed = new List<Feed>();
                //foreach (DictionaryEntry dtEntry in ht_RTFeed)
                //{
                //    Feed oFeedObj = (Feed)dtEntry.Value;
                //    lstFeed.Add(oFeedObj);
                //}

                Hashtable ht_Local = (Hashtable)ht_RTFeed.Clone();

                int value11 = Get_Primary_Time(5, 25);
                Thread.Sleep(value11 * 2 );

                foreach (DictionaryEntry dtEntry in ht_Local)
                {
                    Feed oFeedObj = (Feed)dtEntry.Value;
                    if (ht_RTFeed.Contains(oFeedObj.symbol))
                    {
                        Feed _oFeedObj = (Feed)ht_RTFeed[oFeedObj.symbol];
                        String value11111 = "TRUE";
                        if (_oFeedObj.BidPrice != oFeedObj.BidPrice || _oFeedObj.BidQty != oFeedObj.BidQty)
                        {
                            value11111 = "FALSE";
                            ++falseCount;
                        }
                        else
                            ++trueCount;

                        this.Invoke(((MethodInvoker)delegate
                        {
                            //textBox1.Text = falseCount.ToString();
                            //textBox2.Text = trueCount.ToString();
                            double val1 = Convert.ToDouble(dgvFeed2.Rows[0].Cells[6].Value);
                            if (falseCount > 0 && trueCount > 0)
                            {
                                double val = (falseCount / val1);
                                val = val* 100;
                                val = Math.Round(val, 2);
                               // textBox5.Text = val.ToString();
                            }
                         
                            int count = dataGridView1.Rows.Count;
                           // dataGridView1.Rows.Add();

                            

                            object[] Val = new object[8];
                            Val[0] =  1;;
                            //Val[1] = oFeedObj.symbol;
                            //Val[2] = value;
                            //Val[3] = Get_TimeStamp(_oFeedObj.dttIME);
                            //Val[4] = value11;
                            //Val[5] = oFeedObj.BidPrice.ToString() + "     |     " + oFeedObj.BidQty.ToString();
                            //Val[6] = _oFeedObj.BidPrice + "     |     " + _oFeedObj.BidQty.ToString();
                            //Val[7] = value11111;
                            //dataGridView1.Rows.Insert(0, Val); ;
                            //dgvFeed2.Rows[count].Cells[1].Style.BackColor = Color.LightBlue;

                            //dataGridView1.Rows[0].Cells[0].Value = ++Intial;
                            //dtGridRow.Cells[1].Value = oFeedObj.symbol;
                            //dtGridRow.Cells[2].Value = value;
                            //dtGridRow.Cells[3].Value = Get_TimeStamp(_oFeedObj.dttIME);
                            //dtGridRow.Cells[4].Value = value11;
                            //dtGridRow.Cells[5].Value = oFeedObj.BidPrice.ToString() + "     |     " + oFeedObj.BidQty.ToString();
                            //dtGridRow.Cells[6].Value = _oFeedObj.BidPrice + "     |     " + _oFeedObj.BidQty.ToString();
                            //dtGridRow.Cells[7].Value = value11111;

                            //int count = dataGridView1.Rows.Count;
                            //dataGridView1.Rows.Add(;
                            //count = count - 1;

                            //DataGridViewRow dtGridRow = new DataGridViewRow();
                            //DataGridViewCell dtCel;
                            //dtCel.DataGridView = new DataGridView(); = 0;

                            //dtGridRow.Cells.Add(new DataGridViewCell());
                            //dtGridRow.Cells[0].Value = ++Intial;

                            ////.DataGridViewRow.dataGridView1.Rows[count].Cells[0].Value = ++Intial;
                            //dtGridRow.Cells[1].Value = oFeedObj.symbol;
                            //dtGridRow.Cells[2].Value = value;
                            //dtGridRow.Cells[3].Value = Get_TimeStamp(_oFeedObj.dttIME);
                            //dtGridRow.Cells[4].Value = value11;
                            //dtGridRow.Cells[5].Value = oFeedObj.BidPrice.ToString() + "     |     " + oFeedObj.BidQty.ToString();
                            //dtGridRow.Cells[6].Value = _oFeedObj.BidPrice + "     |     " + _oFeedObj.BidQty.ToString();
                            //dtGridRow.Cells[7].Value = value11111;
                            //dataGridView1.Rows.Insert(1 (dtGridRow);;
                            ////ht_Symbol.Add(oFeedObj.symbol, count);
                        }));
                    }                    
                }
            }
        }

        public String Get_TimeStamp(DateTime dtTime)
        {
            String hh = dtTime.Hour.ToString();
            if (hh.Length == 1)
                hh = "0" + hh;

            String mm = dtTime.Minute.ToString();
            if (mm.Length == 1)
                mm = "0" + mm;

            String ss = dtTime.Second.ToString();
            if (ss.Length == 1)
                ss = "0" + ss;

            int ms_Sec = rand.Next(123, 900);

            String timeStam = hh + ":" + mm + ":" + ss + "." + ms_Sec.ToString(); ;

            return timeStam;
        }

        double diff(double min, double max)
        {
            return (max - min);
        }

        private void RandomNo()
        {
            int VAL = 250;
            while (true)
            {
                int val_clickEvt = rand.Next(100,250);
                int val = rand.Next(05, 50);
                double perc_val = val * 0.01;

                double val_Diff = diff(5, 25);

                double value_Final = val_Diff * perc_val;

                double afterVal = 5 + value_Final;

                this.Invoke(((MethodInvoker)delegate
                {
                    String hh = DateTime.Now.Hour.ToString();
                    if (hh.Length == 1)
                        hh = "0" + hh;

                    String mm = DateTime.Now.Minute.ToString();
                    if (mm.Length == 1)
                        mm = "0" + mm;

                    String ss = DateTime.Now.Second.ToString();
                    if (ss.Length == 1)
                        ss = "0" + ss;

                    String ms_Sec = DateTime.Now.Millisecond.ToString();

                    String timeStam = hh + ":" + mm + ":" + ss + "." + ms_Sec;
                    listBox1.Items.Insert(0, timeStam + "  : " + val_clickEvt);               
             
                }));

                Thread.Sleep(val_clickEvt);

            }
        }

        private void Process_Quote_Event()
        {
            while (true)
            {
                String response = "C:\\AlertSend\\data.txt";
                DateTime dtLast = DateTime.Now;
                Random rnd = new Random();
                int first = 0;
                while (true)
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader stWriter = new StreamReader(fileStream))
                            {
                                String lineNo = "";
                                while ((lineNo = stWriter.ReadLine()) != null)
                                {
                                    stWriter.Close();
                                    String[] arrLen = lineNo.Split('@');
                                    for (int ind = 0; ind < arrLen.Length; ind++)
                                    {
                                        String dat = arrLen[ind];
                                        if (dat.Length > 4)
                                        {
                                            String[] dataField = dat.Split(',');
                                            Feed oFeed = new Feed();
                                            oFeed.symbol = dataField[0];
                                            oFeed.AskPrice = Convert.ToDouble(dataField[1]);
                                            oFeed.AskQty = Convert.ToInt32(dataField[2]);
                                            oFeed.BidPrice = Convert.ToDouble(dataField[3]);
                                            oFeed.BidQty = Convert.ToInt32(dataField[4]);

                                            int hh = Convert.ToInt32(dataField[7]);
                                            int mm = Convert.ToInt32(dataField[8]);
                                            int ss = Convert.ToInt32(dataField[9]);

                                            DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh, mm, ss);

                                            if (first == 0)
                                            {
                                                dtLast = dtTime;
                                                first = 1;
                                            }
                                            else
                                            {
                                                TimeSpan tsSan = dtTime - dtLast;

                                                int constant = 110;
                                                //if ((tsSan.Milliseconds < 1000) && (dtTime.Hour == dtLast.Hour) && (dtTime.Minute == dtLast.Minute) && (dtTime.Second == dtLast.Second)) 
                                                if ((tsSan.Milliseconds < 1000))
                                                {
                                                    double msI = (-1) * tsSan.Milliseconds;
                                                    // ++msI;
                                                    constant = rnd.Next(Convert.ToInt32(msI), 999);
                                                }
                                                dtTime = dtTime.AddMilliseconds(constant);
                                                dtLast = dtTime;
                                            }

                                            oFeed.dttIME = dtTime;
                                            InsertGrid(oFeed);

                                            if (!ht_RTFeed.Contains(oFeed.symbol))
                                                ht_RTFeed.Add(oFeed.symbol, oFeed);
                                            else
                                                ht_RTFeed[oFeed.symbol] = oFeed;

                                        }
                                    }

                                }

                                //     stWriter.Close();
                                fileStream.Close();
                            }
                        }
                    }
                    catch (Exception ex) { }

                    //Thread.Sleep(100);
                }
                Thread.Sleep(500);
            }
        }

        private void MatchPrice(String log, DateTime exchTime)
        {
            this.Invoke(((MethodInvoker)delegate
            {
                String hh = exchTime.Hour.ToString();
                if (hh.Length == 1)
                    hh = "0" + hh;

                String mm = exchTime.Minute.ToString();
                if (mm.Length == 1)
                    mm = "0" + mm;

                String ss = exchTime.Second.ToString();
                if (ss.Length == 1)
                    ss = "0" + ss;

                String ms_Sec = exchTime.Millisecond.ToString();

                String timeStam = hh + ":" + mm + ":" + ss + "." + ms_Sec;
                listBox1.Items.Insert(0, timeStam + "  :" + log);               
            }));
        }
        int counter= 0;
        private void InsertGrid(Feed oFeedObj)
        {   
            String hh = oFeedObj.dttIME.Hour.ToString();
            if (hh.Length == 1)
                hh = "0" + hh;

            String mm = oFeedObj.dttIME.Minute.ToString();
            if (mm.Length == 1)
                mm = "0" + mm;

            String ss = oFeedObj.dttIME.Second.ToString();
            if (ss.Length == 1)
                ss = "0" + ss;

            String ms_Sec = oFeedObj.dttIME.Millisecond.ToString();

            String timeStam = hh + ":" + mm + ":" + ss + "." + ms_Sec;
            if (ht_Symbol.Contains(oFeedObj.symbol))
            {
                this.Invoke(((MethodInvoker)delegate
                {
                    int count = (int)ht_Symbol[oFeedObj.symbol];

                                      
                    double preBidVal = Convert.ToDouble(dgvLocalDataFeed.Rows[count].Cells[1].Value);
                    dgvLocalDataFeed.Rows[count].Cells[1].Value = oFeedObj.BidPrice;
                    if (preBidVal > oFeedObj.BidPrice)
                    {
                        ++counter;
                        dgvLocalDataFeed.Rows[count].Cells[1].Style.BackColor = Color.LightBlue;
                        //log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                    }
                    else
                        if (preBidVal < oFeedObj.BidPrice)
                        {
                            ++counter;
                            dgvLocalDataFeed.Rows[count].Cells[1].Style.BackColor = Color.LightPink;
                          //  log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                        }


                    double preBidQVal = Convert.ToDouble(dgvLocalDataFeed.Rows[count].Cells[2].Value);
                    dgvLocalDataFeed.Rows[count].Cells[2].Value = oFeedObj.BidQty;
                    if (preBidQVal > oFeedObj.BidQty)
                    {
                        ++counter;
                        dgvLocalDataFeed.Rows[count].Cells[2].Style.BackColor = Color.LightBlue;
                        //log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                    }
                    else
                        if (preBidQVal < oFeedObj.BidQty)
                        {
                            ++counter;
                            dgvLocalDataFeed.Rows[count].Cells[2].Style.BackColor = Color.LightPink;
                            //  log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                        }

                    dgvLocalDataFeed.Rows[count].Cells[3].Value = oFeedObj._Index;
                    if (dataGridView2.Rows.Count > 0)
                    {
                        for (int ind = 0; ind < dataGridView2.Rows.Count-1; ind++)
                        {
                            dataGridView2.Rows[ind].Cells[21].Value = oFeedObj.BidPrice;
                            dataGridView2.Rows[ind].Cells[22].Value = oFeedObj.BidQty;

                            if (dataGridView2.Rows[ind].Cells[21].Style.BackColor == Color.LightGreen)
                            {
                                int previsou = Convert.ToInt32(dataGridView2.Rows[ind].Cells[20].Value);
                                previsou += oFeedObj.BidQty;

                                int remain = previsou / 100;
                                int total = remain * 100;
                                dataGridView2.Rows[ind].Cells[9].Value = total;
                            }
                        }
                    }
                }));
            }
            else
            {
                try
                {
                    this.Invoke(((MethodInvoker)delegate
                    {
                        int count = dgvLocalDataFeed.Rows.Count;
                        dgvLocalDataFeed.Rows.Add();
                        count = count - 1;
                        dgvLocalDataFeed.Rows[count].Cells[0].Value = oFeedObj.symbol;
                        dgvLocalDataFeed.Rows[count].Cells[1].Value = oFeedObj.BidPrice;
                        dgvLocalDataFeed.Rows[count].Cells[3].Value = oFeedObj._Index;


                        dgvLocalDataFeed.Rows[count].Cells[2].Value = oFeedObj.BidQty;
                        ht_Symbol.Add(oFeedObj.symbol, count);
                    }));
                }
                catch (Exception ex) { }
            }

            return;

            if (ht_Symbol.Contains(oFeedObj.symbol))
            {                
                this.Invoke(((MethodInvoker)delegate
                {
                    String log = "";
                    int count = (int)ht_Symbol[oFeedObj.symbol];
                    dgvFeed2.Rows[count].Cells[5].Value = timeStam;

                    dgvFeed2.Rows[count].Cells[0].Value = oFeedObj.symbol;
                    int preBidQVal = Convert.ToInt32(dgvFeed2.Rows[count].Cells[1].Value);

                    dgvFeed2.Rows[count].Cells[1].Value = oFeedObj.BidQty;
                    if (preBidQVal > oFeedObj.BidQty)
                    {
                        ++counter;
                        dgvFeed2.Rows[count].Cells[1].Style.BackColor = Color.LightBlue;
                        log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                    }
                    else
                        if (preBidQVal < oFeedObj.BidQty)
                        {
                            ++counter;
                            dgvFeed2.Rows[count].Cells[1].Style.BackColor = Color.LightPink;
                            log = oFeedObj.symbol + "," + " BID QTY Change [Current- " + oFeedObj.BidQty.ToString() + " : Last: " + preBidQVal.ToString() + "]";
                        }

                    if (log.Length > 0)
                        MatchPrice(log, oFeedObj.dttIME);

                    log = "";
                    double preBidVal = Convert.ToDouble(dgvFeed2.Rows[count].Cells[2].Value);
                    dgvFeed2.Rows[count].Cells[2].Value = oFeedObj.BidPrice;
                    if (preBidVal > oFeedObj.BidPrice)
                    {
                        ++counter;
                        dgvFeed2.Rows[count].Cells[2].Style.BackColor = Color.LightBlue;
                        log = oFeedObj.symbol + "," + " BID Price Change [Current- " + oFeedObj.BidPrice.ToString() + " : Last: " + preBidVal.ToString() + "]";
                    }
                    else
                    if (preBidVal < oFeedObj.BidPrice)
                    {
                        ++counter;
                        dgvFeed2.Rows[count].Cells[2].Style.BackColor = Color.LightPink;
                        log = oFeedObj.symbol + "," + " BID Price Change [Current- " + oFeedObj.BidPrice.ToString() + " : Last: " + preBidVal.ToString() + "]";
                    }

                    if (log.Length > 0)
                        MatchPrice(log, oFeedObj.dttIME);

                    log = "";
                    double preAskVal = Convert.ToDouble(dgvFeed2.Rows[count].Cells[3].Value);
                    dgvFeed2.Rows[count].Cells[3].Value = oFeedObj.AskPrice;
                    if (preAskVal < oFeedObj.AskPrice)
                    {
                        dgvFeed2.Rows[count].Cells[3].Style.BackColor = Color.LightBlue;
                        log = oFeedObj.symbol + "," + " ASK Price Change [Current- " + oFeedObj.AskPrice.ToString() + " : Last: " + preAskVal.ToString() + "]";
                    }
                    else
                    if (preAskVal > oFeedObj.AskPrice)                    
                    {
                        dgvFeed2.Rows[count].Cells[3].Style.BackColor = Color.LightPink;
                        log = oFeedObj.symbol + "," + " ASK Price Change [Current- " + oFeedObj.AskPrice.ToString() + " : Last: " + preAskVal.ToString() + "]";
                    }

                    if(log.Length >0)
                        MatchPrice(log, oFeedObj.dttIME);

                    log = "";
                    int preAskQVal = Convert.ToInt32(dgvFeed2.Rows[count].Cells[4].Value);
                    dgvFeed2.Rows[count].Cells[4].Value = oFeedObj.AskQty;
                    if (preAskQVal > oFeedObj.AskQty)
                    {
                        dgvFeed2.Rows[count].Cells[4].Style.BackColor = Color.LightBlue;
                        log = oFeedObj.symbol + "," + " ASK Qty Change [Current- " + oFeedObj.AskQty.ToString() + " : Last: " + preAskQVal.ToString() + "]";
                    }
                    else
                    if (preAskQVal < oFeedObj.AskQty)
                    {
                        dgvFeed2.Rows[count].Cells[4].Style.BackColor = Color.LightPink;
                        log = oFeedObj.symbol + "," + " ASK Qty Change [Current- " + oFeedObj.AskQty.ToString() + " : Last: " + preAskQVal.ToString() + "]";
                    }

                    dgvFeed2.Rows[count].Cells[6].Value = counter.ToString();
                    if (log.Length > 0)
                        MatchPrice(log, oFeedObj.dttIME);
                }));

            }
            else
            {    
                this.Invoke(((MethodInvoker)delegate
                {
                    int count = dgvFeed2.Rows.Count;
                    dgvFeed2.Rows.Add();
                    count = count - 1;
                    dgvFeed2.Rows[count].Cells[0].Value = oFeedObj.symbol;
                    dgvFeed2.Rows[count].Cells[1].Value = oFeedObj.BidQty;
                    dgvFeed2.Rows[count].Cells[2].Value = oFeedObj.BidPrice;
                    dgvFeed2.Rows[count].Cells[3].Value = oFeedObj.AskPrice;
                //    dgvFeed2.Rows[count].Cells[3].Visible = false;
                    dgvFeed2.Rows[count].Cells[4].Value = oFeedObj.AskQty;
                    //dgvFeed2.Rows[count].Cells[4].Visible = false;
                    dgvFeed2.Rows[count].Cells[5].Value = timeStam;
                    dgvFeed2.Rows[count].Cells[6].Value = counter.ToString();
                   
                     ht_Symbol.Add(oFeedObj.symbol, count);
                }));

              
            }
        }

        public void Process_Quote()
        {
            String response= "C:\\AlertSend\\data.txt";
            DateTime dtLast = DateTime.Now;
            Random rnd = new Random();
            int first = 0;

            
            while (true)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader stWriter = new StreamReader(fileStream))
                        {
                            String lineNo = "";
                            while ((lineNo = stWriter.ReadLine()) != null)
                            {
                                stWriter.Close();
                                String[] arrLen = lineNo.Split('@');
                                for (int ind = 0; ind < arrLen.Length; ind++)
                                {
                                    String dat = arrLen[ind];
                                    if (dat.Length > 4)
                                    {
                                        String[] dataField = dat.Split(',');
                                        Feed oFeed = new Feed();
                                        oFeed.symbol = dataField[0];
                                        if (oFeed.symbol != "MSFT")
                                            continue;

                                        oFeed.AskPrice= Convert.ToDouble(dataField[1]);
                                        oFeed.AskQty = Convert.ToInt32(dataField[2]);
                                        oFeed.BidPrice = Convert.ToDouble(dataField[3]);
                                        oFeed.BidQty = Convert.ToInt32(dataField[4]);

                                        int hh = Convert.ToInt32(dataField[7]);
                                        int mm = Convert.ToInt32(dataField[8]);
                                        int ss = Convert.ToInt32(dataField[9]);

                                        DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh, mm, ss);

                                        if(first == 0)
                                        {
                                            dtLast = dtTime;
                                            first = 1;
                                        }
                                        else
                                        {
                                            TimeSpan tsSan = dtTime - dtLast;

                                            int constant = 110;
                                            //if ((tsSan.Milliseconds < 1000) && (dtTime.Hour == dtLast.Hour) && (dtTime.Minute == dtLast.Minute) && (dtTime.Second == dtLast.Second)) 
                                            if ((tsSan.Milliseconds < 1000))
                                            {
                                                double msI = (-1) * tsSan.Milliseconds;
                                               // ++msI;
                                                constant = rnd.Next(Convert.ToInt32(msI), 999);
                                            }
                                            dtTime = dtTime.AddMilliseconds(constant);
                                            dtLast = dtTime;                                           
                                        }

                                        oFeed.dttIME = dtTime;
                                        InsertGrid(oFeed);
                                        if (!ht_RTFeed.Contains(oFeed.symbol))
                                            ht_RTFeed.Add(oFeed.symbol, oFeed);
                                        else
                                            ht_RTFeed[oFeed.symbol] = oFeed;
                                    }
                                }

                            }

                       //     stWriter.Close();
                            fileStream.Close();
                        }
                    }
                }
                catch (Exception ex) { }

              //Thread.Sleep(100);
            }
        }

        public int Get_Primary_Time(int RangeMin, int RangeMax)
        {
            return rand.Next(RangeMin, RangeMax);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public enum Provider
        {
            PROVIDER = 0,
            TAKER = 1
        };

        public enum ORDER_STATUS
        {
            ACCEPTED = 0,
            CANCELLED = 1,
            FILLED = 2,
            PENDING = 3
        };

        public struct Order
        {
            public String YY;
            public String MM;
            public String DD;

            public String HH;
            public String MIN;
            public String SEC;
            public int MilliSec;

            public String OrderNo;
            public String Symbol;
            public String Limit;
            public String OrderSize;

            public String MS;
            public String SA;
            public String Provide;

            public String  CustNo;

            public String Buy_Sell;
            public Provider oType;
            public ORDER_STATUS ordStatus;
            public int OrderIndex;
        };

        int orderNo = 1;

        private Order InsertGrid(Order ord)
        {
            this.Invoke(((MethodInvoker)delegate
           {        
                int count = dataGridView2.Rows.Count;
                dataGridView2.Rows.Add();
                count = count - 1;
           
                dataGridView2.Rows[count].Cells[15].Value = ord.CustNo;
                dataGridView2.Rows[count].Cells[0].Value = ord.SEC;
                dataGridView2.Rows[count].Cells[1].Value = ord.MIN;
                
                //dataGridView2.Rows[count].Cells[6].Value = ord.MM;
                //dataGridView2.Rows[count].Cells[7].Value = ord.YY;
                if (ord.Buy_Sell.ToLower() == "buy")
                    dataGridView2.Rows[count].Cells[8].Value = "B";
                else
                    dataGridView2.Rows[count].Cells[8].Value = "S";

                int remain = Convert.ToInt32(ord.OrderSize) / 100;
                int total = remain * 100;
                dataGridView2.Rows[count].Cells[9].Value = ord.OrderSize;
                dataGridView2.Rows[count].Cells[10].Value = ord.Limit;
                dataGridView2.Rows[count].Cells[11].Value = "0";
                dataGridView2.Rows[count].Cells[12].Value = ord.Symbol;

                int _ordFlag = (int)ord.ordStatus;
                dataGridView2.Rows[count].Cells[11].Value = _ordFlag;

                String arounf = orderNo.ToString();
                if (arounf.Length == 1)
                    arounf = "00000" + arounf;

                 ++orderNo;

                 if (ord.oType == Provider.PROVIDER)
                 {
                     dataGridView2.Rows[count].Cells[4].Value = 0;
                     dataGridView2.Rows[count].Cells[5].Value = 00;
                     for (int ind = 0; ind < dataGridView2.ColumnCount; ind++)
                     {
                         dataGridView2.Rows[count].Cells[ind].Style.BackColor = Color.LightGreen;
                     }
                 }

                //if (ord.Enable)
                //    dataGridView2.Rows[count].Cells[17].Value = "2";
                //else
                //    dataGridView2.Rows[count].Cells[17].Value = "1";

                dataGridView2.Rows[count].Cells[20].Value = ord.SA;
                dataGridView2.Rows[count].Cells[19].Value = ord.MS;

                dataGridView2.Rows[count].Cells[14].Value = arounf;

                ord.OrderIndex = count;
               
           }));

            return ord;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox17.Text.Length > 0 && textBox16.Text.Length > 0 && textBox19.Text.Length > 0 && textBox18.Text.Length > 0 && comboBox3.SelectedIndex > -1)
            {
                Order ordObj = new Order();
                ordObj.Symbol = textBox17.Text;
                ordObj.Limit = textBox16.Text;
                ordObj.MS = textBox18.Text;
                ordObj.SA = textBox19.Text;
                ordObj.OrderSize = ordObj.SA;
                ordObj.Buy_Sell =  (String)comboBox3.SelectedItem;
                ordObj.oType = Provider.PROVIDER;

                String hour = DateTime.Now.Hour.ToString();
                String min = DateTime.Now.Minute.ToString();
                String sec = DateTime.Now.Second.ToString();
                String Year = DateTime.Now.Year.ToString();
                String Mon = DateTime.Now.Month.ToString();
                String day = DateTime.Now.Day.ToString();
                ordObj.MilliSec = DateTime.Now.Millisecond;
                ordObj.HH = hour;
                ordObj.MIN = min;
                ordObj.SEC = sec;
                ordObj.YY = Year;
                ordObj.CustNo = "001";
                ordObj.ordStatus = ORDER_STATUS.ACCEPTED;
                ordObj.MM = Mon;
                ordObj.DD = day;

                int ORDERqRT = Convert.ToInt32(ordObj.OrderSize);
                if (ht_LP_Unmanaged.Contains(ORDERqRT))
                {
                    ArrayList _ordObj = (ArrayList)ht_LP_Unmanaged[ORDERqRT];
                    _ordObj.Add(ordObj);
                    //_ordObj.OrderSize += ordObj.OrderSize;
                    ht_LP_Unmanaged[ORDERqRT] = _ordObj;
                }
                else
                {
                    ArrayList _ordObj = new ArrayList();
                    _ordObj.Add(ordObj);
                    ht_LP_Unmanaged[ORDERqRT] = _ordObj;
                }

                //arr.Add(ordObj);
                //InsertGrid(ordObj);             
            }
            else
                MessageBox.Show("Error please insert valid parameter ");          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart mpThread_Task3 = delegate { Process_Full(); };
            Thread threadObj_Task3 = new Thread(new ThreadStart(mpThread_Task3));
            threadObj_Task3.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox21.Text.Length > 0 && textBox20.Text.Length > 0 && textBox22.Text.Length > 0 && comboBox4.SelectedIndex > -1)
            {
                Order ordObj = new Order();
                ordObj.Symbol = textBox21.Text;
                ordObj.OrderSize = textBox22.Text;
                ordObj.Limit = textBox20.Text;

                double LimitPrice = Convert.ToDouble(ordObj.Limit);
                ordObj.MS = "0";
                ordObj.SA = "0";
                ordObj.Buy_Sell = (String)comboBox4.SelectedItem;

                String hour = DateTime.Now.Hour.ToString();
                String min = DateTime.Now.Minute.ToString();
                String sec = DateTime.Now.Second.ToString();
                String Year = DateTime.Now.Year.ToString();
                String Mon = DateTime.Now.Month.ToString();
                String day = DateTime.Now.Day.ToString();

                ordObj.MilliSec = DateTime.Now.Millisecond;

                ordObj.oType = Provider.TAKER;
                ordObj.HH = hour;
                ordObj.MIN = min;
                ordObj.SEC = sec;
                ordObj.YY = Year;
                ordObj.MM = Mon;
                ordObj.DD = day;
                ordObj.CustNo = "002";
                ordObj.ordStatus = ORDER_STATUS.ACCEPTED;

                int ORDERqRT = Convert.ToInt32(ordObj.OrderSize);
                if (ht_LT_Unmanaged.Contains(ORDERqRT))
                {
                    ArrayList _ordObj = (ArrayList)ht_LT_Unmanaged[ORDERqRT];
                    _ordObj.Add(ordObj);
                    ht_LT_Unmanaged[ORDERqRT] = _ordObj;
                }
                else
                {
                    ArrayList _ordObj = new ArrayList();
                    _ordObj.Add(ordObj);
                    ht_LT_Unmanaged.Add(ORDERqRT, _ordObj);
                }

                //return;
                if (dataGridView2.Rows.Count > 0)
                {
                    if (ht_RTFeed.Contains(ordObj.Symbol))
                    {
                        Feed feedObj = (Feed)ht_RTFeed[ordObj.Symbol];
                        if (feedObj.BidPrice < LimitPrice)
                        {
                            InsertGrid(ordObj);                           
                        }
                        else
                        {
                            for (int ind = 0; ind < dataGridView2.Rows.Count - 1; ind++)
                            {
                                //dataGridView2.Rows[ind].Cells[21].Value = oFeedObj.BidPrice;
                                //dataGridView2.Rows[ind].Cells[22].Value = oFeedObj.BidQty;

                                if (dataGridView2.Rows[ind].Cells[21].Style.BackColor == Color.LightGreen)
                                {
                                    string currentLTP = Convert.ToString(dataGridView2.Rows[ind].Cells[17].Value);
                                    string currentQty = Convert.ToString(dataGridView2.Rows[ind].Cells[18].Value);

                                    //    Feed feedObj = (Feed)ht_Symbol[ordObj.Symbol];
                                    //    if (feedObj.BidPrice > LimitPrice)
                                    //        InsertGrid(ordObj);
                                    //}                                
                                    if (currentLTP.Trim().Length <= 0 && currentQty.Trim().Length <= 0)
                                    {
                                        dataGridView2.Rows[ind].Cells[17].Value = ordObj.Limit;
                                        dataGridView2.Rows[ind].Cells[18].Value = ordObj.OrderSize;

                                        //dataGridView2.Rows[ind].Cells[2].Value = ordObj.SEC; ;
                                        //dataGridView2.Rows[ind].Cells[3].Value = ordObj.MilliSec - 4;


                                        dataGridView2.Rows[ind].Cells[4].Value = sec;
                                        dataGridView2.Rows[ind].Cells[5].Value = ordObj.MilliSec;
                                        for (int ind1 = 0; ind1 < dataGridView2.ColumnCount; ind1++)
                                        {
                                            dataGridView2.Rows[ind].Cells[ind1].Style.BackColor = Color.LightPink;
                                        }

                                        //ThreadStart mpThread_QuoteBase_Event = delegate { MatchInitial(ordObj); };
                                        //Thread threadObj_QuoteBase_Event = new Thread(new ThreadStart(mpThread_QuoteBase_Event));
                                        //threadObj_QuoteBase_Event.Start();
                                    }
                                    //previsou += oFeedObj.BidQty;
                                    //dataGridView2.Rows[ind].Cells[9].Value = previsou;
                                }
                            }
                        }
                    }
                }


                


               arr.Add(ordObj);
              //  InsertGrid(ordObj);
            }
            else
                MessageBox.Show("Error please insert valid parameter ");   
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ThreadStart mpThread_QuoteBase_IT = delegate { Process_Full_Snap(); };
            Thread threadObj_QuoteBase_Tick = new Thread(new ThreadStart(mpThread_QuoteBase_IT));
            threadObj_QuoteBase_Tick.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThreadStart mpThread_QuoteBase_IT = delegate { Simulator(); };
            Thread threadObj_QuoteBase_Tick = new Thread(new ThreadStart(mpThread_QuoteBase_IT));
            threadObj_QuoteBase_Tick.Start();
        }

        public void Simulator()
        {
            String response = "C:\\AlertSend\\Simulator_22.txt";
            ArrayList arrFeed = new ArrayList();
            DateTime dtLastTime = new DateTime();
            int count = 0;
            double _lastTime = 0;
            using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader stWriter = new StreamReader(fileStream))
                {
                    String lineNo = "";
                    while ((lineNo = stWriter.ReadLine()) != null)
                    {
                       
                        String[] arrLen = lineNo.Split('@');
                        for (int ind = 0; ind < arrLen.Length; ind++)
                        {
                            String dat = arrLen[ind];
                            if (dat.Length > 4)
                            {
                                String[] dataField = dat.Split(',');
                                Feed oFeed = new Feed();
                                oFeed.symbol = dataField[0];
                                if (oFeed.symbol == "MSFT")
                                {
                                    //oFeed.AskPrice = Convert.ToDouble(dataField[1]);
                                    //oFeed.AskQty = Convert.ToInt32(dataField[2]);
                                    oFeed.BidPrice = Convert.ToDouble(dataField[1]);
                                    oFeed.BidQty = Convert.ToInt32(dataField[2]);

                                    int hh = Convert.ToInt32(dataField[3]);
                                    int mm = Convert.ToInt32(dataField[4]);
                                    int ss = Convert.ToInt32(dataField[5]);

                                    oFeed.Distance = 0;
                                    DateTime dtTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh, mm, ss);

                                    bool insert = false;
                                    if (count == 0)
                                        dtLastTime = dtTime;
                                    else
                                    {
                                        TimeSpan tsSpan = dtTime - dtLastTime;

                                        if (tsSpan.TotalMilliseconds != _lastTime)
                                        {
                                            oFeed.Distance = tsSpan.TotalMilliseconds - _lastTime;
                                            insert = true;
                                            _lastTime = tsSpan.TotalMilliseconds;
                                        }                                      
                                    }

                                    double value = 0;
                                    this.Invoke(((MethodInvoker)delegate
                                    {
                                        value =Convert.ToDouble(textBox15.Text);
                                        //   textBox10.Text = per.ToString();
                                    }));

                                    double muli = (value / 100.00);
                                    oFeed.Distance = oFeed.Distance * muli;

                                    ++count;

                                    if (!ht_RTFeed.Contains(oFeed.symbol))
                                        ht_RTFeed.Add(oFeed.symbol, oFeed);
                                    else
                                        ht_RTFeed[oFeed.symbol] = oFeed;

                                    //String symbol_File = oFeed.symbol + "," + oFeed.BidPrice + "," + oFeed.BidQty;
                                    //stWriter_Simualtor.WriteLine(symbol_File);
                                    //stWriter_Simualtor.Flush();

                                    if(insert)
                                      arrFeed.Add(oFeed);
                                  //  InsertGrid(oFeed);
                                }

                               // int va =Convert.ToInt32(textBox12.Text);

                                //int delay = va / 100;
                                //Thread.Sleep(delay);
                            }
                        }
                    }

                    stWriter.Close();
                }
            }

            int index = 0;
            while (true)
            {
                int value = 0;
                //this.Invoke(((MethodInvoker)delegate
                //{
                //    value =Convert.ToInt32(textBox15.Text);
                //    //   textBox10.Text = per.ToString();
                //}));

                //++index;
                //if (index > 3) break;
                double sec = 0;
                for (int ind = 0; ind < arrFeed.Count; ind++)
                {
                    Feed oFeed = (Feed)arrFeed[ind];
                    oFeed._Index = sec;
                    InsertGrid(oFeed);

                    int delay = 100;
                    if(value != 100)
                      delay = value / 500;

                    //dgvLocalDataFeed.Rows[count].Cells[3].Value = sec;

                    int delay11 = Convert.ToInt32(oFeed.Distance);
                    Thread.Sleep(delay11);
                    sec += oFeed.Distance;
                }

                break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AllFeedExch()
        {
            String response = "C:\\AlertSend\\depth.txt";
            DateTime dtLast = DateTime.Now;
            Random rnd = new Random();
            int first = 0;
            Hashtable ht_DataFeed = new Hashtable();
            Hashtable ht_Exchange = new Hashtable();
            while (true)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader stWriter = new StreamReader(fileStream))
                        {
                            String lineNo = "";
                            while ((lineNo = stWriter.ReadLine()) != null)
                            {
                                 String[] arrLen = lineNo.Split('@');
                                 //NASDAQ,47.2,1,NASDAQ,47.14,3,NASDAQ,47.2,MSFT,400@
                                 for (int ind = 0; ind < arrLen.Length; ind++)
                                 {
                                     String field = arrLen[ind];
                                     String[] fieldArray = field.Split(',');
                                     String BiExch = fieldArray[0];
                                     double bidP = Convert.ToDouble( fieldArray[1]);
                                     int bidQ = Convert.ToInt32(fieldArray[2]);

                                     String AskExch = fieldArray[3];
                                     double AskP = Convert.ToDouble(fieldArray[4]);
                                     int AskQ = Convert.ToInt32(fieldArray[5]);

                                     String LastExch = fieldArray[6];
                                     double LastP = Convert.ToDouble(fieldArray[7]);
                                     String symbool = fieldArray[8];
                                     int LastQ = Convert.ToInt32(fieldArray[9]);

                                     this.Invoke(((MethodInvoker)delegate
                                     {
                                         dataGridView5.Rows[0].Cells[1].Value = AskP - 0.01;
                                         dataGridView5.Rows[0].Cells[2].Value = AskP;
                                         dataGridView5.Rows[0].Cells[3].Value = bidP;
                                         dataGridView5.Rows[0].Cells[4].Value = bidP + 0.01;

                                         if (ht_Exchange.Contains(BiExch))
                                         {
                                             int index = (int)ht_Exchange[BiExch];
                                             //dataGridView4.Rows[index].Cells[1].Value = AskQ;
                                             dataGridView6.Rows[index].Cells[2].Value = bidQ;
                                         }
                                         else
                                         {
                                             int count = dataGridView6.Rows.Count;
                                             dataGridView6.Rows.Add();
                                             count = count - 1;


                                             dataGridView6.Rows[count].Cells[2].Value = bidQ;

                                             dataGridView6.Rows[count].Cells[0].Value = BiExch;
                                             ht_Exchange.Add(BiExch, count);
                                         }

                                         if (ht_Exchange.Contains(AskExch))
                                         {
                                             int index = (int)ht_Exchange[AskExch];
                                             //dataGridView4.Rows[index].Cells[1].Value = AskQ;
                                             dataGridView6.Rows[index].Cells[1].Value = AskQ;
                                         }
                                         else
                                         {
                                             int count = dataGridView6.Rows.Count;
                                             dataGridView6.Rows.Add();
                                             count = count - 1;

                                             dataGridView6.Rows[count].Cells[1].Value = AskQ;
                                             dataGridView6.Rows[count].Cells[0].Value = BiExch;
                                             ht_Exchange.Add(AskExch, count);
                                         }
                                     }));




                                     if (ht_DataFeed.Contains(symbool))
                                     {
                                         int index = (int)ht_DataFeed[symbool];
                                         this.Invoke(((MethodInvoker)delegate
                                         {
                                             dataGridView4.Rows[index].Cells[0].Value = BiExch;
                                             dataGridView4.Rows[index].Cells[1].Value = bidQ;
                                             dataGridView4.Rows[index].Cells[2].Value = bidP;
                                             dataGridView4.Rows[index].Cells[3].Value = AskP;
                                             dataGridView4.Rows[index].Cells[4].Value = AskQ;
                                             dataGridView4.Rows[index].Cells[5].Value = AskExch;
                                             dataGridView4.Rows[index].Cells[6].Value = LastP;
                                             dataGridView4.Rows[index].Cells[7].Value = LastQ;
                                             dataGridView4.Rows[index].Cells[8].Value = LastExch;
                                           
                                         }));

                                     }
                                     else
                                     {
                                         this.Invoke(((MethodInvoker)delegate
                                         {
                                             int count = dataGridView2.Rows.Count;
                                             dataGridView2.Rows.Add();
                                             count = count - 1;

                                             dataGridView4.Rows[count].Cells[0].Value = BiExch;
                                             dataGridView4.Rows[count].Cells[1].Value = bidQ;
                                             dataGridView4.Rows[count].Cells[2].Value = bidP;
                                             dataGridView4.Rows[count].Cells[3].Value = AskP;
                                             dataGridView4.Rows[count].Cells[4].Value = AskQ;
                                             dataGridView4.Rows[count].Cells[5].Value = AskExch;
                                             dataGridView4.Rows[count].Cells[6].Value = LastP;
                                             dataGridView4.Rows[count].Cells[7].Value = LastQ;
                                             dataGridView4.Rows[count].Cells[8].Value = LastExch;
                                             ht_DataFeed.Add(symbool, count);
                                         }));
                                     }                                 
                                 }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(100);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ThreadStart mpThread_QC = delegate { AllFeedExch(); };
            Thread threadObj_QC = new Thread(new ThreadStart(mpThread_QC));
            threadObj_QC.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Dashboard dsBoard = new Dashboard();
            dsBoard.Show();
        }
    }
}
