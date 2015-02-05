using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections;

namespace FeedScanAlgo
{
    public partial class Dashboard : Form
    {
        public struct MatchOrder
        {
            public String LP_CustNo;
            public String LT_CustNo;
            public String LP_OrderNo;
            public String LT_OrderNo;
            public Provider oProvide;
            public String symbol;
            public double LP_Price;
            public double LT_Price;
            public double LP_Qty;
            public double LT_Qty;
            public Buy_Sell LP_BSFlag;
            public Buy_Sell LT_BSFlag;
            public DateTime dtMatch;
            public DateTime dtInitial;
        };

        public struct NBBO
        {
            public String symbol;
            public double BidPrice;
            public int BidQty;
            public double AskPrice;
            public int AskQty;
        };
        public struct Feed_Bid
        {
            public String symbol;
            public String BidExch;
            public double BidPrice;
            public int BidQty;
        };

        public struct Feed_Ask
        {
            public String symbol;
            public double AskPrice;
            public int AskQty;
            public String AskExch;
        };

        public enum Buy_Sell
        {
            SELL = 0,
            BUY = 1
        };

        public enum Provider
        {
            PROVIDER = 0,
            TAKER = 1,
            MATCH = 2
        };

         public enum ORDER_STATUS
        {
            NonActvOrd = 0,
            PendActOrd = 1,
            ActvOrd = 2,
            Filled = 3,
            CanOrd = 4, 
            ExpOrd = 5,
            PendMatch = 6
        }
        //public enum ORDER_STATUS
        //{
        //    ACCEPTED = 0,
        //    CANCELLED = 1,
        //    FILLED = 2,
        //    PENDING = 3
        //};

         public enum Order_Size: int
         {
            FixSz = 0,
            AddSz = 1,
            TopSz = 2

         };
         public struct Order_Version_1
         {
             public String OrderNo;
             public String CustNo;
             public Provider oProvider;
             public Buy_Sell Buy_Sell;
             public String symbol;
             public double LimitPrice;
             public int Size;
             public Order_Size oSize;
             public double AggrLP;
             public double MakSz;
             public double TakSz;
             public DateTime FeedSz;
             public double CurBid;
             public double CurBidSz;
             public double CurAskSz;
             public double CurAsk;
             public ORDER_STATUS oStatus;
             public int Rank;
             public double FillPrc;
             public double FiilSz;
             public DateTime TimeEnt;
             public DateTime TimeExec;
             public DateTime TimeMatch;
             public bool isNBBO;
         };

        public struct Order_New
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

            public String CustNo;

            public Buy_Sell Buy_Sell;
            public Provider oType;
            public ORDER_STATUS ordStatus;
            public int OrderIndex;
        };       

        public struct Feed
        {
            public String symbol;
            public String BidExch;
            public double BidPrice;
            public int BidQty;
            public double AskPrice;
            public int AskQty;
            public String AskExch;
            public DateTime dttIME;
            public double LastPrice;
            public int LastQty;
        };

        public Hashtable ht_Order_Depth = new Hashtable();
        public Hashtable ht_Grid_Manager = new Hashtable();
        public ArrayList arr_Pending = new ArrayList();

        public Hashtable ht_RTFeed = new Hashtable();
        public Hashtable ht_RT_Depth = new Hashtable();
        public Hashtable ht_Orders = new Hashtable();
        public Hashtable ht_Traded = new Hashtable();
        private Queue qu_BidObj = new Queue();
        private Queue qu_AskObj = new Queue();
        private Queue qu_Feed = new Queue();

        private int OrderIndex = 8272;

        public Dashboard()
        {
            InitializeComponent();

            //int count = dataGridView2.Rows.Count;
            //dataGridView2.Rows.Add();
            //count = count - 1;

            //dataGridView2.Rows[count].Cells[0].Value = "17181";
            //dataGridView2.Rows[count].Cells[1].Value = "0091";
            //dataGridView2.Rows[count].Cells[2].Value = "LP";
            //dataGridView2.Rows[count].Cells[3].Value = "B/S";
            //dataGridView2.Rows[count].Cells[4].Value = "MSFT";
            //dataGridView2.Rows[count].Cells[5].Value = "49";
            //dataGridView2.Rows[count].Cells[6].Value = "100";
            //dataGridView2.Rows[count].Cells[7].Value = "19";
            //dataGridView2.Rows[count].Cells[8].Value = "200";
            //dataGridView2.Rows[count].Cells[9].Value = "0";
            //dataGridView2.Rows[count].Cells[10].Value = "0";
            //dataGridView2.Rows[count].Cells[11].Value = "23:00:00";
            //dataGridView2.Rows[count].Cells[12].Value = "47.10";
            //dataGridView2.Rows[count].Cells[13].Value = "200";
            //dataGridView2.Rows[count].Cells[14].Value = "500";
            //dataGridView2.Rows[count].Cells[15].Value = "48.10";
            //dataGridView2.Rows[count].Cells[16].Value = "PendActOrde";
            

            for(int ind = 0; ind < 14; ind++)
               dataGridView1.Rows.Add();

            //ThreadStart mpThread_QuoteBase_IT = delegate { Simulator(); };
            //Thread threadObj_QuoteBase_Tick = new Thread(new ThreadStart(mpThread_QuoteBase_IT));
            //threadObj_QuoteBase_Tick.Start();

            ThreadStart mpThread_Display = delegate { Simulator_Display(); };
            Thread threadObj_Display = new Thread(new ThreadStart(mpThread_Display));
            threadObj_Display.Start();

            ThreadStart mpThread_Matching = delegate { UpdateGrid(); };
            Thread threadObj_Matching = new Thread(new ThreadStart(mpThread_Matching));
            threadObj_Matching.Start();

            ThreadStart mpThread_Feed = delegate { MakeFeedMatching(); };
            Thread threadObj_Feed = new Thread(new ThreadStart(mpThread_Feed));
            threadObj_Feed.Start();

            //ThreadStart mpThread_Matching_Bid = delegate { Matching_Engine_Bid(); };
            //Thread threadObj_Matching_Bid = new Thread(new ThreadStart(mpThread_Matching_Bid));
            //threadObj_Matching_Bid.Start();


            int constamt = 8;
            dataGridView1.Rows[6].Cells[0].Value = "Offer";
            dataGridView1.Rows[7].Cells[0].Value = "Bid";
            for (int ind1 = 0; ind1 < 6; ind1++)
            {
                dataGridView1.Rows[ind1].Cells[0].Value = "Offer + 1";
                dataGridView1.Rows[ind1 + constamt].Cells[0].Value = "Bid - 1";
            }            
        }

        private void MakeFeedMatching()
        {
            while (true)
            {
                if (qu_Feed.Count > 0)
                {
                    NBBO oNBBo = (NBBO)qu_Feed.Dequeue();
                    AddMatch_Field(oNBBo);
                }
                Thread.Sleep(200);
            }
        }

        private void UpdateGrid()
        {
            ArrayList arr_List = new ArrayList();
            arr_List.Add(2);
            arr_List.Add(1);
            arr_List.Add(0);
            while (true)
            {
                try
                {
                    this.Invoke(((MethodInvoker)delegate
                    {
                        if(dataGridView2.Rows.Count > 1)
                          dataGridView2.Rows.Clear();
                    }));
                }
                catch (Exception ex) { }
                for (int ind = 0; ind < arr_List.Count; ind++)
                {
                    int index = (int)arr_List[ind];
                    if (ht_Grid_Manager.Contains(index))
                    {
                        Hashtable ht_Orders = (Hashtable)ht_Grid_Manager[index];
                        foreach (DictionaryEntry dtEntry_Ord in ht_Orders)
                        {
                            String _OrderNo = (String)dtEntry_Ord.Key;

                            try
                            {
                                this.Invoke(((MethodInvoker)delegate
                                {
                                    if (index == 1 || index == 0)
                                    {
                                        Order_Version_1 oOrder = (Order_Version_1)dtEntry_Ord.Value;
                                        int count = dataGridView2.Rows.Count;
                                        dataGridView2.Rows.Add();
                                        count = count - 1;

                                        dataGridView2.Rows[count].Cells[0].Value = oOrder.OrderNo;
                                        dataGridView2.Rows[count].Cells[1].Value = oOrder.CustNo;
                                        dataGridView2.Rows[count].Cells[2].Value = oOrder.oProvider;
                                        dataGridView2.Rows[count].Cells[3].Value = oOrder.Buy_Sell;
                                        dataGridView2.Rows[count].Cells[4].Value = oOrder.symbol;
                                        dataGridView2.Rows[count].Cells[5].Value = oOrder.LimitPrice;
                                        dataGridView2.Rows[count].Cells[6].Value = oOrder.Size;
                                        dataGridView2.Rows[count].Cells[7].Value = oOrder.oSize;
                                        dataGridView2.Rows[count].Cells[16].Value = ORDER_STATUS.PendActOrd;

                                        if (index == 0)
                                        {
                                            //dataGridView2.Rows[count].Cells[0].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[1].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[2].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[3].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[4].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[5].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[6].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[7].Style.BackColor = Color.LightGreen;
                                            //dataGridView2.Rows[count].Cells[16].Style.BackColor = Color.LightGreen;

                                            for (int gridCount = 0; gridCount < dataGridView2.ColumnCount -1; gridCount++)
                                            {
                                                dataGridView2.Rows[count].Cells[gridCount].Style.BackColor = Color.LightGreen;
                                            }
                                        }
                                    }
                                    else
                                        if (index == 2)
                                        {
                                            MatchOrder oOrder = (MatchOrder)dtEntry_Ord.Value;
                                            int count = dataGridView2.Rows.Count;
                                            dataGridView2.Rows.Add();
                                            count = count - 1;

                                            dataGridView2.Rows[count].Cells[0].Value = oOrder.LT_OrderNo;
                                           // dataGridView2.Rows[count].Cells[0].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[1].Value = oOrder.LT_CustNo;
                                           // dataGridView2.Rows[count].Cells[1].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[2].Value = Provider.MATCH;
                                           // dataGridView2.Rows[count].Cells[2].Style.BackColor = Color.LightPink;
                                            // dataGridView1.Rows[count].Cells[3].Value = oOrder.Buy_Sell;
                                            dataGridView2.Rows[count].Cells[4].Value = oOrder.symbol;
                                           // dataGridView2.Rows[count].Cells[4].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[5].Value = oOrder.LT_Price;
                                          //  dataGridView2.Rows[count].Cells[5].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[6].Value = oOrder.LT_Qty;
                                          //  dataGridView2.Rows[count].Cells[6].Style.BackColor = Color.LightPink;

                                           // dataGridView2.Rows[count].Cells[8].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[8].Value = oOrder.LP_Qty;
                                           // dataGridView2.Rows[count].Cells[9].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[9].Value = oOrder.LT_Qty;

                                         //   dataGridView2.Rows[count].Cells[16].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[16].Value = ORDER_STATUS.Filled;
                                           // dataGridView2.Rows[count].Cells[17].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[18].Value = oOrder.LP_Price;
                                           // dataGridView2.Rows[count].Cells[18].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[19].Value = oOrder.LP_Qty;
                                           // dataGridView2.Rows[count].Cells[19].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[20].Value = oOrder.dtInitial;
                                          //  dataGridView2.Rows[count].Cells[20].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[21].Value = oOrder.dtMatch;
                                           // dataGridView2.Rows[count].Cells[21].Style.BackColor = Color.LightPink;
                                            dataGridView2.Rows[count].Cells[22].Value = "YES";

                                            for (int gridCount = 0; gridCount < dataGridView2.ColumnCount -1; gridCount++)
                                            {
                                                dataGridView2.Rows[count].Cells[gridCount].Style.BackColor = Color.LightPink;
                                            }
                                            // dataGridView1.Rows[count].Cells[7].Value = SizeType.
                                        }
                                }));
                            }
                            catch (Exception ex) { }
                        }
                    }
                }

                Thread.Sleep(3000);
            }
        }
              
        
        private void InsertGrid(Order_New Ord)
        {
            if(ht_Orders.Contains(Ord.Symbol))
            {
                Hashtable ht_Buy_Sell = (Hashtable)ht_Orders[Ord.CustNo];
                if (!ht_Buy_Sell.Contains(Ord.Buy_Sell))
                {
                    ArrayList arr_Orders = new ArrayList();
                    arr_Orders.Add(Ord);
                    ht_Buy_Sell.Add(Ord.Buy_Sell, arr_Orders);
                }
                else
                {
                    ArrayList arr_Orders = (ArrayList)ht_Buy_Sell[Ord.Buy_Sell];
                    arr_Orders.Add(Ord);
                    ht_Buy_Sell[Ord.Buy_Sell] = arr_Orders;
                }
                ht_Orders[Ord.Symbol] = ht_Buy_Sell;
            }
            else
            {
                Hashtable ht_Buy_Sell = new Hashtable();
                ArrayList arr_Orders = new ArrayList();
                arr_Orders.Add(Ord);

                ht_Buy_Sell.Add(Ord.Buy_Sell, arr_Orders);
                ht_Orders.Add(Ord.Symbol, ht_Buy_Sell);
            }
        }

        private void Simulator_Display()
        {
            while (true)
            {
                if (ht_RT_Depth.Count > 0)
                {
                    Hashtable ht_RT_Bid = new Hashtable();
                    if (ht_RT_Depth.Contains(1))
                        ht_RT_Bid = (Hashtable)ht_RT_Depth[1];

                    Hashtable ht_RT_Ask = new Hashtable();
                    if (ht_RT_Depth.Contains(2))
                        ht_RT_Ask = (Hashtable)ht_RT_Depth[2];


                    Hashtable ht_LocalBid = (Hashtable)ht_RT_Bid.Clone();
                    Hashtable ht_LocalAsk = (Hashtable)ht_RT_Ask.Clone();
                    int Qty_B = 0;
                    int Qty_B1 = 0;
                    double Price_B = 0;
                    int index_Bid = 7;

                    NBBO oNBBO = new NBBO();
                    oNBBO.symbol = "MSFT";
                    foreach (DictionaryEntry dtEntry in ht_LocalBid)
                    {
                        String exchange = (String)dtEntry.Key;
                        Feed_Bid oFeed_Bid = (Feed_Bid)dtEntry.Value;

                        Qty_B += oFeed_Bid.BidQty;
                        Qty_B1 = oFeed_Bid.BidQty;
                        Price_B = oFeed_Bid.BidPrice;

                        try
                        {
                            this.Invoke(((MethodInvoker)delegate
                            {
                                dataGridView1.Rows[index_Bid].Cells[2].Value = Price_B;
                                dataGridView1.Rows[index_Bid].Cells[3].Value = Qty_B1;
                                dataGridView1.Rows[index_Bid].Cells[4].Value = exchange;
                                oNBBO.BidPrice = Price_B;
                                oNBBO.BidQty = Qty_B1;
                            }));
                        }
                        catch (Exception ex)
                        {

                        }
                        ++index_Bid;
                    }
                    
                    int Qty_A = 0;
                    int Qty_A1 = 0;
                    double Price_A = 0;

                    int index = 6;
                    foreach (DictionaryEntry dtEntry in ht_LocalAsk)
                    {
                        String exchange = (String)dtEntry.Key;
                        Feed_Ask oFeed_Bid = (Feed_Ask)dtEntry.Value;

                        Qty_A += oFeed_Bid.AskQty;
                        Qty_A1 = oFeed_Bid.AskQty;
                        Price_A = oFeed_Bid.AskPrice;
                        if (index > 0)
                        {
                            try
                            {
                                this.Invoke(((MethodInvoker)delegate
                                {
                                    dataGridView1.Rows[index].Cells[2].Value = Price_A;
                                    dataGridView1.Rows[index].Cells[3].Value = Qty_A1;
                                    dataGridView1.Rows[index].Cells[4].Value = exchange;
                                    oNBBO.AskPrice = Price_A;
                                    oNBBO.AskQty = Qty_A1;
                                }));
                            }
                            catch (Exception ex) { }
                        }

                        index--; 
                    }

                    if (!ht_RTFeed.Contains(oNBBO.symbol))
                        ht_RTFeed.Add(oNBBO.symbol, oNBBO);
                    else
                        ht_RTFeed[oNBBO.symbol] = oNBBO;

                    if(ht_Order_Depth.Count > 0)
                       qu_Feed.Enqueue(oNBBO);

                    try
                    {
                        this.Invoke(((MethodInvoker)delegate
                        {
                            dataGridView1.Rows[7].Cells[1].Value = Qty_B;
                            dataGridView1.Rows[6].Cells[1].Value = Qty_A;
                        }));
                    }
                    catch (Exception ex) { }

                }
                Thread.Sleep(300);
            }
        }
        
        public void Simulator_Master()
        {
            String response = "C:\\LogTest\\sdata.txt";
            String response1 = "C:\\LogTest\\sdata.txt";
            ArrayList arrFeed = new ArrayList();
            DateTime dtLastTime = new DateTime();
            int count = 0;
            double _lastTime = 0;

            FileStream fsStreamWite = new FileStream(response1, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter oWriter =new StreamWriter(fsStreamWite);

            while (true)
            {
                using (FileStream fileStream = new FileStream(response, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader stWriter = new StreamReader(fileStream))
                    {
                        String lineNo = "";
                        while ((lineNo = stWriter.ReadLine()) != null)
                        {
                            if (lineNo.Length > 4)
                            {
                                oWriter.WriteLine(lineNo);
                                oWriter.Flush();
                                String[] arrLen = lineNo.Split('@');
                                for (int ind = 0; ind < arrLen.Length; ind++)
                                {
                                    String complete = arrLen[ind];
                                    if (complete.Length > 10)
                                    {
                                        String[] lstArr = complete.Split(',');
                                        //NASDAQ,46.19,46,NASDAQ,46.18,56,46.19,200,15,39,30@
                                        Feed oFeed = new Feed();
                                        oFeed.symbol = "MSFT";
                                        oFeed.AskExch = lstArr[0];
                                        oFeed.AskPrice = Convert.ToDouble(lstArr[1]);
                                        oFeed.AskQty = Convert.ToInt32(lstArr[2]);

                                        oFeed.BidExch = lstArr[3];
                                        oFeed.BidPrice = Convert.ToDouble(lstArr[4]);
                                        oFeed.BidQty = Convert.ToInt32(lstArr[5]);

                                        Feed_Ask oFeed_Ask = new Feed_Ask();
                                        oFeed_Ask.AskExch = oFeed.AskExch;
                                        oFeed_Ask.AskPrice = oFeed.AskPrice;
                                        oFeed_Ask.AskQty = oFeed.AskQty;
                                        oFeed_Ask.symbol = "MSFT";

                                        qu_AskObj.Enqueue(oFeed_Ask);

                                        Feed_Bid oFeed_Bid = new Feed_Bid();
                                        oFeed_Bid.BidExch = oFeed.BidExch;
                                        oFeed_Bid.BidPrice = oFeed.BidPrice;
                                        oFeed_Bid.BidQty = oFeed.BidQty;
                                        oFeed_Bid.symbol = "MSFT";
                                        qu_BidObj.Enqueue(oFeed_Bid);

                                        oFeed.LastPrice = Convert.ToDouble(lstArr[6]);
                                        oFeed.LastQty = Convert.ToInt32(lstArr[7]);

                                        int hour = Convert.ToInt32(lstArr[8]);
                                        int minute = Convert.ToInt32(lstArr[9]);
                                        int Sec = Convert.ToInt32(lstArr[10]);

                                        oFeed.dttIME = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, Sec);

                                        String Bid_Exch = oFeed.BidExch;
                                        if (!ht_RT_Depth.Contains(1))  //Bid
                                        {
                                            Hashtable htDeoth = new Hashtable();
                                            htDeoth.Add(oFeed_Bid.BidExch, oFeed_Bid);
                                            ht_RT_Depth.Add(1, htDeoth);
                                        }
                                        else
                                        {
                                            Hashtable htDeoth = (Hashtable)ht_RT_Depth[1];
                                            htDeoth[oFeed_Bid.BidExch] = oFeed_Bid;
                                            ht_RT_Depth[1] = htDeoth;
                                        }

                                        if (!ht_RT_Depth.Contains(2))  //Ask
                                        {
                                            Hashtable htDeoth = new Hashtable();
                                            htDeoth.Add(oFeed_Ask.AskExch, oFeed_Ask);
                                            ht_RT_Depth.Add(2, htDeoth);
                                        }
                                        else
                                        {
                                            Hashtable htDeoth = (Hashtable)ht_RT_Depth[2];
                                            htDeoth[oFeed_Ask.AskExch] = oFeed_Ask;
                                            ht_RT_Depth[2] = htDeoth;
                                        }
                                    }

                                }
                            }
                            Thread.Sleep(50);
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void InsertGrid(Feed oFeed)
        {
            try
            {
                this.Invoke(((MethodInvoker)delegate
                {
                    dataGridView1.Rows[6].Cells[1].Value = oFeed.BidQty;
                    dataGridView1.Rows[6].Cells[2].Value = oFeed.BidPrice;
                    dataGridView1.Rows[7].Cells[1].Value = oFeed.AskQty;
                    dataGridView1.Rows[7].Cells[2].Value = oFeed.AskPrice;
                }));
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order_Version_1 oOrder = new Order_Version_1();
            oOrder.symbol = textBox1.Text;
            oOrder.CustNo = textBox59.Text;
            oOrder.LimitPrice = Convert.ToDouble(textBox2.Text);
            oOrder.Size = Convert.ToInt32(textBox3.Text);
            oOrder.Buy_Sell = (Buy_Sell)comboBox1.SelectedIndex;
            oOrder.oStatus = ORDER_STATUS.ActvOrd;
            oOrder.TimeExec = DateTime.Now;
            oOrder.oProvider = Provider.TAKER;
            AddOrder(oOrder);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order_Version_1 oOrder = new Order_Version_1();
            oOrder.symbol = textBox6.Text;
            oOrder.CustNo = textBox59.Text;
            oOrder.LimitPrice = Convert.ToDouble(textBox5.Text);
            oOrder.Size = Convert.ToInt32(textBox13.Text);
            oOrder.Buy_Sell = (Buy_Sell)comboBox2.SelectedIndex;
            oOrder.oSize = (Order_Size)comboBox5.SelectedIndex;
            oOrder.TimeExec = DateTime.Now;
            oOrder.oProvider = Provider.PROVIDER;
            oOrder.oStatus = ORDER_STATUS.ActvOrd;
            AddOrder(oOrder);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ThreadStart mpThread_QuoteBase_Msst = delegate { Simulator_Master(); };
            Thread threadObj_QuoteBase_Tick_Mst = new Thread(new ThreadStart(mpThread_QuoteBase_Msst));
            threadObj_QuoteBase_Tick_Mst.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Order_Version_1 oOrder = new Order_Version_1();
            oOrder.symbol = textBox34.Text;
            oOrder.CustNo = textBox60.Text;
            oOrder.LimitPrice = Convert.ToDouble(textBox33.Text);
            oOrder.Size = Convert.ToInt32(textBox32.Text);
            oOrder.Buy_Sell = (Buy_Sell)comboBox4.SelectedIndex;
            oOrder.TimeExec = DateTime.Now;
            oOrder.oProvider = Provider.TAKER;
            oOrder.oStatus = ORDER_STATUS.ActvOrd;
            AddOrder(oOrder);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Order_Version_1 oOrder = new Order_Version_1();
            oOrder.symbol = textBox31.Text;
            oOrder.CustNo = textBox60.Text;
            oOrder.LimitPrice = Convert.ToDouble(textBox30.Text);
            oOrder.Size = Convert.ToInt32(textBox28.Text);
            oOrder.Buy_Sell = (Buy_Sell)comboBox3.SelectedIndex;
            oOrder.TimeExec = DateTime.Now;
            oOrder.oProvider = Provider.PROVIDER;
            oOrder.oStatus = ORDER_STATUS.ActvOrd;
            AddOrder(oOrder);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private bool AddMatching(Order_Version_1 oOrder)
        {
            MatchOrder oMatch = new MatchOrder();
            oMatch.symbol = oOrder.symbol;
            String logMsg = "";
            bool isMatached = false;
            int match_LP_LT = 0, match_B_S = 0;
            int LP_LT = (int)oOrder.oProvider;
            if (LP_LT == 0)
                match_LP_LT = 1;
            if (LP_LT == 1)
                match_LP_LT = 0;
            
            int Buy_Sell = (int)oOrder.Buy_Sell;
            if (Buy_Sell == 0)
                match_B_S = 1;
            if (Buy_Sell == 1)
                match_B_S = 0;
            
            if (oOrder.oStatus == ORDER_STATUS.ActvOrd)
            {
                if (ht_RTFeed.Contains(oOrder.symbol))
                {
                    NBBO oNBBO = (NBBO)ht_RTFeed[oOrder.symbol];

                    bool isMatch = false;
                    if (match_B_S == 0)
                    {
                        if (oOrder.LimitPrice <= oNBBO.AskPrice)
                            isMatch = true;
                        else
                            logMsg = "No Valid Best Possibility";
                    }
                    else
                    {
                        if (oOrder.LimitPrice >= oNBBO.AskPrice)
                            isMatch = true;
                        else
                            logMsg = "No Valid Best Possibility";
                    }

                    if (isMatch)
                    {
                        Hashtable ht_Order_1 = (Hashtable)ht_Order_Depth.Clone();
                        foreach (DictionaryEntry dtEntry in ht_Order_1)
                        {
                            String customer = (String)dtEntry.Key;
                            if (customer != oOrder.CustNo)
                            {
                                Hashtable ht_LP_LT = (Hashtable)dtEntry.Value;
                                if (ht_LP_LT.Contains(match_LP_LT))
                                {
                                    Hashtable ht_BS_Ord = (Hashtable)ht_LP_LT[match_LP_LT];
                                    if (ht_BS_Ord.Contains(match_B_S))
                                    {
                                        ArrayList arr_List = (ArrayList)ht_BS_Ord[match_B_S];
                                        int matchIndex = -1;
                                        for (int ind = 0; ind < arr_List.Count; ind++)
                                        {
                                            Order_Version_1 ord = (Order_Version_1)arr_List[ind];
                                            if (Buy_Sell == 0)   //SELL
                                            {
                                                if (oOrder.LimitPrice <= ord.LimitPrice && oOrder.Size <= ord.Size && oOrder.oProvider != ord.oProvider)
                                                {
                                                    oMatch.LP_CustNo = ord.CustNo;
                                                    oMatch.LP_OrderNo = ord.OrderNo;
                                                    oMatch.LP_Price = ord.LimitPrice;
                                                    oMatch.LP_Qty = ord.Size;
                                                    oMatch.LP_BSFlag = ord.Buy_Sell;

                                                    oMatch.LT_BSFlag = oOrder.Buy_Sell;
                                                    oMatch.LT_CustNo = oOrder.CustNo;
                                                    oMatch.LT_OrderNo = oOrder.OrderNo;
                                                    oMatch.LT_Qty = oOrder.Size;
                                                    oMatch.LT_Price = oOrder.LimitPrice;
                                                    oMatch.dtInitial = oOrder.FeedSz;
                                                    oMatch.dtMatch = DateTime.Now;

                                                    if (arr_Pending.Contains(oOrder.OrderNo)) arr_Pending.Remove(oOrder.OrderNo);
                                                    if (arr_Pending.Contains(ord.OrderNo)) arr_Pending.Remove(ord.OrderNo);

                                                    AddGridManager(ord, ord.OrderNo, ord.oProvider, 1);
                                                    AddGridManager(oOrder, oOrder.OrderNo, oOrder.oProvider, 1);
                                                    AddGridManager(oMatch, oOrder.OrderNo, Provider.MATCH, 0);

                                                    matchIndex = ind;
                                                    isMatached = true;
                                                    break;
                                                }
                                                else                                                         
                                                    logMsg = "SELL: Counterparty no available";
                                            }
                                            if (Buy_Sell == 1)   //BUY
                                            {
                                                if (oOrder.LimitPrice >= ord.LimitPrice && oOrder.Size <= ord.Size && oOrder.oProvider != ord.oProvider)
                                                {
                                                    oMatch.LP_CustNo = ord.CustNo;
                                                    oMatch.LP_OrderNo = ord.OrderNo;
                                                    oMatch.LP_Price = ord.LimitPrice;
                                                    oMatch.LP_Qty = ord.Size;
                                                    oMatch.LP_BSFlag = ord.Buy_Sell;

                                                    oMatch.LT_BSFlag = oOrder.Buy_Sell;
                                                    oMatch.LT_CustNo = oOrder.CustNo;
                                                    oMatch.LT_OrderNo = oOrder.OrderNo;
                                                    oMatch.LT_Qty = oOrder.Size;
                                                    oMatch.LT_Price = oOrder.LimitPrice;
                                                    oMatch.dtInitial = oOrder.FeedSz;
                                                    oMatch.dtMatch = DateTime.Now;

                                                    if (arr_Pending.Contains(oOrder.OrderNo)) arr_Pending.Remove(oOrder.OrderNo);
                                                    if (arr_Pending.Contains(ord.OrderNo)) arr_Pending.Remove(ord.OrderNo);

                                                    AddGridManager(ord, ord.OrderNo, ord.oProvider, 1);
                                                    AddGridManager(oOrder, oOrder.OrderNo, oOrder.oProvider, 1);
                                                    AddGridManager(oMatch, oOrder.OrderNo, Provider.MATCH, 0);

                                                    matchIndex = ind;
                                                    isMatached = true;
                                                    break;
                                                }
                                                else
                                                    logMsg = "BUY: Counterparty no available";
                                            }
                                        }

                                        if (isMatached)
                                        {
                                            arr_List.Remove(matchIndex);
                                            ht_BS_Ord[match_B_S] = arr_List;
                                            ht_LP_LT[match_LP_LT] = ht_BS_Ord;
                                            ht_Order_Depth[customer] = ht_LP_LT;
                                        }                                            
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return isMatached;
        }

        private void AddPending(Order_Version_1 oOrder)
        {
            if (!arr_Pending.Contains(oOrder.OrderNo))
                arr_Pending.Add(oOrder.OrderNo);

            int LP_LT = (int)oOrder.oProvider;
            int Buy_Sell = (int)oOrder.Buy_Sell;
            if (ht_Order_Depth.Contains(oOrder.CustNo))
            {
                Hashtable ht_LT_LP = (Hashtable)ht_Order_Depth[oOrder.CustNo];
                if (ht_LT_LP.Contains(LP_LT))
                {
                    Hashtable ht_LT_LP_BS = (Hashtable)ht_LT_LP[LP_LT];
                    if (ht_LT_LP_BS.Contains(Buy_Sell))
                    {
                        ArrayList oArr = (ArrayList)ht_LT_LP_BS[Buy_Sell];
                        oArr.Add(oOrder);
                        ht_LT_LP_BS[Buy_Sell] = oArr;
                    }
                    else
                    {
                        ArrayList oArr = new ArrayList();
                        oArr.Add(oOrder);
                        ht_LT_LP_BS.Add(Buy_Sell, oArr);
                    }
                    ht_LT_LP[LP_LT] = ht_LT_LP_BS;
                }
                else
                {
                    Hashtable ht_LT_LP_BS = new Hashtable();                    
                    ArrayList oArr = new ArrayList();
                    oArr.Add(oOrder);
                    ht_LT_LP_BS.Add(Buy_Sell, oArr);
                    ht_LT_LP.Add(LP_LT, ht_LT_LP_BS);
                }
                ht_Order_Depth[oOrder.CustNo] = ht_LT_LP;
            }
            else
            {
                Hashtable ht_LT_LP_BS = new Hashtable();
                Hashtable ht_LT_LP = new Hashtable();
                ArrayList oArr = new ArrayList();
                oArr.Add(oOrder);
                ht_LT_LP_BS.Add(Buy_Sell, oArr);
                ht_LT_LP.Add(LP_LT, ht_LT_LP_BS);
                ht_Order_Depth.Add(oOrder.CustNo, ht_LT_LP);
            }

            int index = (int)Provider.PROVIDER;
            if (oOrder.oProvider == Provider.PROVIDER)
            {
                //int count = dataGridView1.Rows.Count;
                //dataGridView1.Rows.Add();
                //count = count - 1;

                //dataGridView1.Rows[count].Cells[0].Value = oOrder.OrderNo;
                //dataGridView1.Rows[count].Cells[1].Value = oOrder.CustNo;
                //dataGridView1.Rows[count].Cells[2].Value = Provider.PROVIDER;
                //dataGridView1.Rows[count].Cells[3].Value = oOrder.Buy_Sell;
                //dataGridView1.Rows[count].Cells[4].Value = oOrder.symbol;
                //dataGridView1.Rows[count].Cells[5].Value = oOrder.LimitPrice;
                //dataGridView1.Rows[count].Cells[6].Value = oOrder.Size;
                //dataGridView1.Rows[count].Cells[7].Value = oOrder.oSize;
                AddGridManager(oOrder, oOrder.OrderNo, Provider.PROVIDER, 0);                
            }
            if (oOrder.oProvider == Provider.TAKER)
            {
                //int count = dataGridView1.Rows.Count;
                //dataGridView1.Rows.Add();
                //count = count - 1;

                //dataGridView1.Rows[count].Cells[0].Value = oOrder.OrderNo;
                //dataGridView1.Rows[count].Cells[1].Value = oOrder.CustNo;
                //dataGridView1.Rows[count].Cells[2].Value = Provider.PROVIDER;
                //dataGridView1.Rows[count].Cells[3].Value = oOrder.Buy_Sell;
                //dataGridView1.Rows[count].Cells[4].Value = oOrder.symbol;
                //dataGridView1.Rows[count].Cells[5].Value = oOrder.LimitPrice;
                //dataGridView1.Rows[count].Cells[6].Value = oOrder.Size;
                AddGridManager(oOrder, oOrder.OrderNo, Provider.TAKER, 0);
            }            
        }

        private void AddGridManager(object obj, String OrderNo, Provider oType, int Add_Delete )
        {
            // Add_Delete = 0 // Add, 1- Manager
            int index = (int)oType;
            if (Add_Delete == 0)
            {
                if (ht_Grid_Manager.Contains(index))
                {
                    Hashtable ht_Match = (Hashtable)ht_Grid_Manager[index];
                    if (!ht_Match.Contains(OrderNo))
                    {
                        //ArrayList order = (ArrayList)ht_Match[OrderNo];
                        //order.Add(obj);
                        ht_Match.Add(OrderNo, obj);
                    }

                    ht_Grid_Manager[index] = ht_Match;
                }
                else
                {
                    Hashtable ht_Match = new Hashtable();
                    //ArrayList order = new ArrayList();
                    //order.Add(obj);
                    ht_Match.Add(OrderNo, obj);
                    ht_Grid_Manager.Add(index, ht_Match);
                }
            }
            else
            {
                if (ht_Grid_Manager.Contains(index))
                {
                    Hashtable ht_Match = (Hashtable)ht_Grid_Manager[index];
                    if (ht_Match.Contains(OrderNo))
                    {
                        ht_Match.Remove(OrderNo);
                        ht_Grid_Manager[index] = ht_Match; 
                    }
                }
            }
        }

        private void AddOrder(Order_Version_1 oOrder)
        {
            oOrder.OrderNo = OrderIndex.ToString();
            ++OrderIndex;
            bool ret = AddMatching(oOrder);
            if (!ret)
            {
                AddPending(oOrder);
            }
        }

        private void AddMatch_Field(NBBO oNbbo)
        {
            Hashtable ht_PendingOrder = (Hashtable)ht_Order_Depth.Clone();

            try
            {
                foreach (DictionaryEntry dtEntry in ht_PendingOrder)
                {
                    String CustNo = (String)dtEntry.Key;
                    Hashtable ht_LP_LT = (Hashtable)ht_PendingOrder[CustNo];
                    foreach (DictionaryEntry dtEntry_LP in ht_LP_LT)
                    {
                        int LP_LT = (int)dtEntry_LP.Key;
                        Hashtable ht_BS_Orders = (Hashtable)dtEntry_LP.Value;
                        foreach (DictionaryEntry dtEntry1 in ht_BS_Orders)
                        {
                            int bsflag = (int)dtEntry1.Key;
                            ArrayList arr_Orders = (ArrayList)dtEntry1.Value;

                            for (int ind = 0; ind < arr_Orders.Count; ind++)
                            {
                                Order_Version_1 ord = (Order_Version_1)arr_Orders[ind];
                                if (arr_Pending.Contains(ord.OrderNo))
                                    AddMatching(ord);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
