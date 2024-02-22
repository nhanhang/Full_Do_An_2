using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;

namespace Đo_an_2
{
    public partial class Form1 : Form
    {

        private StringBuilder receivedData = new StringBuilder();
        private System.Windows.Forms.Timer portCheckTimer = new System.Windows.Forms.Timer();
        String tamthoi = "";
        int result = 0;
        public Form1()
        {
            InitializeComponent();
            string[] Baudrate = { "1200", "2400", "4800", "9600", "115200" };
            string[] thietbi = {  "Slave1", "Slave2" };
            string[] kieutruyen = { "Sequentially", "Request" };
            cboBaudrate.Items.AddRange(Baudrate);
            cboR.Items.AddRange(thietbi);
            cboT.Items.AddRange(kieutruyen);
            Control.CheckForIllegalCrossThreadCalls = false;
            serialCOM.DataReceived += new SerialDataReceivedEventHandler(serialCOM_DataReceived);
            portCheckTimer.Interval = 1000; // 1000 milliseconds = 1 second
            portCheckTimer.Tick += PortCheckTimer_Tick;
            portCheckTimer.Start();
            txtData.Multiline = true;
            txtData.ScrollBars = ScrollBars.Vertical;
           // int a = value_crc('A', 'D', '0', 8, "40121288", 6, "421280");
            //String m = a.ToString();
            //txtAllData.Text = m;
            //int b=xorbyte('A', 0xFFFF);
            //int  b =Vary1("A");
            //String n= b.ToString();
            //txtData.Text = n;
        }
        
        int Vary(char a)
        {
            int b;
            b = (int)a;
            return b;

        }
        int Vary1(String a)
        {
            int b;
            b = (int)a[0];
            return b;

        }
        int xorbyte(int a,int crc)
        {
            crc = crc ^ a;
            for (int i = 0; i < 8; i++)
            {
                
                if ((crc & 1)==1)
                {
                    
                    crc = crc >> 1;

                    crc = crc ^ 0xA001;
                    
                }
                else
                {
                    crc = crc >> 1;
                    
                }
            }

            return crc;
        } 
        int value_crc(char a,char b, char c, int d, String e, int f, String g)
        {
            String k;
            int crc = 0xFFFF;
            int a1, a2, a3,k1;
            a1 = Vary(a);
            a2 = Vary(b);
            a3 = Vary(c);
            crc = xorbyte(a1, crc);
            
            crc = xorbyte(a2, crc);

            crc = xorbyte(a3, crc);
            k=d.ToString();
            k1 = Vary1(k);
            crc = xorbyte(k1, crc);
            
            for (int i=0; i < d; i++)
            {
                k = e.Substring(i, 1);
                k1 = Vary1(k);
                crc= xorbyte(k1, crc);
            }
            k = f.ToString();   
            k1 = Vary1(k);
            crc = xorbyte(k1, crc);
            for(int i = 0; i < f; i++)
            {
                k = g.Substring(i,  1);
                k1 = Vary1(k);
                crc = xorbyte(k1, crc);
            }
            return crc;
        }
        int value_crc1(char a, char b, char c, int d, String e)
        {
            String k;
            int crc = 0xFFFF;
            int a1, a2, a3, k1;
            a1 = Vary(a);
            a2 = Vary(b);
            a3 = Vary(c);
            crc = xorbyte(a1, crc);
            crc = xorbyte(a2, crc);
            crc = xorbyte(a3, crc);
            k = d.ToString();
            k1 = Vary1(k);
            crc = xorbyte(k1, crc);

            for (int i = 0; i < d; i++)
            {
                k = e.Substring(i, 1);
                k1 = Vary(k[0]);
                crc = xorbyte(k1, crc);
            }
            
            return crc;
        }
        private void PortCheckTimer_Tick(object sender, EventArgs e)
        {
            // Kiểm tra cổng serial định kỳ
            CheckAvailablePorts();

        }

        private void CheckAvailablePorts()
        {
            
            //cboTB.DataSource = SerialPort.GetPortNames();
            string[] ports = SerialPort.GetPortNames();
            if(cboTB.Text!= tamthoi)
            {
                serialCOM.Close();
            }
          
            if (!ports.Contains(cboTB.Text))
            {
                // Nếu không có, làm sạch ComboBox
                cboTB.Text = "";
                serialCOM.Close();
                COMTrangthai.Text = "Can't find COM";
                COMTrangthai.ForeColor = Color.Blue;

            }
            if (cboTB.Text != "" && serialCOM.IsOpen == false)
            {
                COMTrangthai.Text = "Disconnected";
                COMTrangthai.ForeColor = Color.Red;

            }
            if (!ports.SequenceEqual(cboTB.Items.OfType<string>()))
            {
                String[] a = SerialPort.GetPortNames();
                
                if (cboTB.Text != "")
                {
                    tamthoi = cboTB.Text;
                }
                else
                {
                    if (a.Length > 0) 
                    {
                        tamthoi = a[0];
                    }

                }
                // Có sự thay đổi trong danh sách cổng serial
                //cboComPort.DataSource = null;
                //cboComPort.Items.Clear();
                //cboTB.DataSource = SerialPort.GetPortNames();
                
                if (cboTB.InvokeRequired)
                {
                    cboTB.Invoke(new Action(() =>
                    {
                        //cboComPort.Text = ""; // Xóa giá trị trong ComboBox.Text
                        cboTB.DataSource = null;
                        cboTB.Items.Clear();
                        cboTB.Items.AddRange(ports);
                        cboTB.Text = tamthoi;
                    }));
                }
                else
                {
                    if (cboTB.IsHandleCreated) // Kiểm tra xem handle đã được tạo chưa để tránh lỗi trong một số trường hợp
                    {
                        //cboComPort.Text = ""; // Xóa giá trị trong ComboBox.Text
                        cboTB.DataSource = null;
                        cboTB.Items.Clear();
                        cboTB.Items.AddRange(ports);
                        cboTB.Text = tamthoi;
                    }
                }
                

            }
        }
        private void serialCOM_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            if (e.EventType == SerialPinChange.CtsChanged || e.EventType == SerialPinChange.DsrChanged)
            {
                if (!serialCOM.CtsHolding || !serialCOM.DsrHolding)
                {
                    cboTB.Items.Clear();
                    cboTB.DataSource = null;
                    cboTB.Text = "";
                    // Cổng COM đã bị disconnect
                    // Thực hiện xử lý tại đây

                }
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cboTB.DataSource = SerialPort.GetPortNames();
            if (cboTB.Text != "")
            {
                serialCOM.Close();
                COMTrangthai.Text = "Disconnected";
                COMTrangthai.ForeColor = Color.Red;
            }
            cboBaudrate.Text = "115200";
            cboT.Text = "Sequentially";
        }
        private void ButConnect_Click(object sender, EventArgs e)
        {
            //cboTB.DataSource = SerialPort.GetPortNames();
            tamthoi = cboTB.Text;
            if (cboTB.Text != "")
            {
                if (!serialCOM.IsOpen)
                {
                    serialCOM.PortName = cboTB.Text;
                    serialCOM.BaudRate = Convert.ToInt32(cboBaudrate.Text);
                }
                if (cboTB.Text != "" && !serialCOM.IsOpen)
                {
                    serialCOM.Open();
                    if (serialCOM.IsOpen)
                    {
                        COMTrangthai.Text = "Connected";
                        textEC1.Text = "0";
                        textEC2.Text = "0";
                        textHUMI1.Text = "0";
                        textHUMI2.Text = "0";
                        txtData1.Text = "0";
                        txtData2.Text = "0";
                        txtAllData.Text = "";
                        receivedData.Clear();
                        UpdateTextBox(receivedData.ToString());
                        COMTrangthai.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                COMTrangthai.Text = "Can't find COM";
                COMTrangthai.ForeColor = Color.Blue;
            }


        }

      //  private void butSend_Click(object sender, EventArgs e)
        //{
          //  String dulieu ;
            //String address_receive;
            //String pack;
            
     //       if (cboT.Text == "")
       //     {
         //       MessageBox.Show("You haven't selected transmisstion type.");
           // }
     //       else if (cboTB.Text == "")
       //     {
         //       MessageBox.Show("You haven't selected COM.");
           // }
     //       else if (cboBaudrate.Text == "")
       //     {
         //       MessageBox.Show("You haven't selected baudrate.");
           // }
       //     else if (trangthaiKieuTruyen.Text == "Sequentially")
         //   {
           //     MessageBox.Show("Transmission type does not match");
       //     }
         //   else
           // {
      //          if (serialCOM.IsOpen)
        //        {
          //           if (cboR.Text == "SLAVE1")
            //         {
              //          address_receive = "B";
                //    }
                  //  else 
                    //{
                      //  address_receive = "C";
       //             }
    
         //           String m = "";
           //         int l = m.Length;
             //       String n = l.ToString();
               //     int q = value_crc1('D', address_receive[0], '3', l, m);
                 //   String p = q.ToString();
                    //dulieu = "@" + "D" + address_receive + "0" + n + m + p + "#";
                   // dulieu = "@" + "D" + address_receive[0] + "3" + n + m + p + "#";
           //         serialCOM.Write(dulieu);
             //       receivedData.Append($"Sent: {dulieu}{Environment.NewLine}");
               //     UpdateTextBox(receivedData.ToString());
                //}
            //}
        //}
        private async void serialCOM_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //const int MaxHistoryItems = 1000000;
            result = 0;
            String Alldata = "";
            String length_str1 = "";
            String length_str2 = "";
            String data1 = "";
            String data2 = "";
            int length_data1, length_data2;
            String ec1_str = "";
            String humi1_str = "";
            String ec2_str = "";
            String humi2_str = "";
            String crc_str = "";
            String pack, r;
            int crc, value_crc16, o;
            double ec1, ec2, humi1, humi2;
            if (cboTB.Text == "")
            {
                MessageBox.Show("You haven't selected COM.");
            }
            else if (cboBaudrate.Text == "")
            {
                MessageBox.Show("You haven't selected baudrate.");
            }
            else
            {
                if (serialCOM.IsOpen)
                {

                    Alldata = serialCOM.ReadExisting();
                    await Task.Delay(100);
                    //Alldata = Alldata.Trim();
                    txtAllData.Text = Alldata;
                    int len = Alldata.Length;
                    if (len > 0)
                    {
                        receivedData.Append($"Received: {Alldata}{Environment.NewLine}");
                        if (Alldata[0] == '@')
                        {
                            if (Alldata[1] == 'A')
                            {
                                if (Alldata[2] == 'D')
                                {
                                    if (Alldata[3] == '0')
                                    {
                                        if (Alldata[len - 1] == '#')
                                        {
                                            length_str1 = Alldata.Substring(4, 1);
                                            int.TryParse(length_str1, out length_data1);
                                            data1 = Alldata.Substring(5, length_data1);
                                            length_str2 = Alldata.Substring(5 + length_data1, 1);
                                            int.TryParse(length_str2, out length_data2);
                                            data2 = Alldata.Substring(6 + length_data1, length_data2);
                                            txtData1.Text = data1;
                                            txtData2.Text = data2;
                                            crc_str = Alldata.Substring(6 + length_data2 + length_data1, len - 1 - length_data1 - length_data2 - 6);
                                            int.TryParse(crc_str, out crc);
                                            value_crc16 = value_crc(Alldata[1], Alldata[2], Alldata[3], length_data1, data1, length_data2, data2);
                                            if (value_crc16 == crc)
                                            {
                                                if (length_data1 > 4)
                                                {
                                                    humi1_str = data1.Substring(0, 4);
                                                    ec1_str = data1.Substring(4, length_data1 - 4);
                                                }
                                                else
                                                {
                                                    ec1_str = "0";
                                                    humi1_str = "0";
                                                }
                                                if (length_data2 > 4)
                                                {
                                                    humi2_str = data2.Substring(0, 4);
                                                    ec2_str = data2.Substring(4, length_data2 - 4);
                                                }
                                                else
                                                {
                                                    ec2_str = "0";
                                                    humi2_str = "0";
                                                }

                                                double.TryParse(ec1_str, out ec1);
                                                double.TryParse(humi1_str, out humi1);
                                                double.TryParse(ec2_str, out ec2);
                                                double.TryParse(humi2_str, out humi2);
                                                ec1 = ec1 / 100;
                                                humi1 = humi1 / 100;
                                                humi2 = humi2 / 100;
                                                ec2 = ec2 / 100;
                                                ec1_str = ec1.ToString();
                                                ec2_str = ec2.ToString();
                                                humi1_str = humi1.ToString();
                                                humi2_str = humi2.ToString();
                                                textEC1.Text = ec1_str;
                                                textEC2.Text = ec2_str;
                                                textHUMI1.Text = humi1_str;
                                                textHUMI2.Text = humi2_str;
                                                result = 1;
                                            }

                                        }
                                        else result = 2;
                                    }
                                    else if (Alldata[3] == '3')
                                    {
                                        textEC1.Text = "0";
                                        textEC2.Text = "0";
                                        textHUMI1.Text = "0";
                                        textHUMI2.Text = "0";
                                        txtData1.Text = "ERROR";
                                        txtData2.Text = "ERROR";
                                        MessageBox.Show("Both NODE devices are faulty");

                                    }
                                    else;

                                    //int vitriT = Alldata.IndexOf('T'); //@10AT1234789481234789475123# --> T:4
                                    //txtTemp.Text = Alldata.Substring(vitriT + 1, len - vitriT - 2);
                                }
                                if (Alldata[2]=='B' || Alldata[2] == 'C')
                                {
                                    if (Alldata[3] == '3')
                                    {
                                        if (Alldata[2] == 'B')
                                        {
                                            textEC2.Text = "0";
                                            textHUMI2.Text = "0";
                                            txtData2.Text = "ERROR";
                                        }
                                        else if (Alldata[2] == 'C')
                                        {
                                            textEC1.Text = "0";
                                            textHUMI1.Text = "0";
                                            txtData1.Text = "ERROR";
                                        }
                                    }
                                }
                            }
                            else if (Alldata[1] == 'B')
                            {
                                if (Alldata[2] == 'D')
                                {
                                    if (Alldata[3] == '0')
                                    {
                                        if (Alldata[len - 1] == '#')
                                        {
                                            length_str1 = Alldata.Substring(4, 1);
                                            int.TryParse(length_str1, out length_data1);
                                            data1 = Alldata.Substring(5, length_data1);
                                            txtData1.Text = data1;
                                            
                                            crc_str = Alldata.Substring(5 + length_data1, len - 1 - length_data1 - 5);
                                            int.TryParse(crc_str, out crc);
                                            value_crc16 = value_crc1(Alldata[1], Alldata[2], Alldata[3], length_data1, data1);
                                            if (value_crc16 == crc)
                                            {
                                                if (length_data1 > 4)
                                                {
                                                    humi1_str = data1.Substring(0, 4);
                                                    ec1_str = data1.Substring(4, length_data1 - 4);
                                                }
                                                else
                                                {
                                                    ec1_str = "0";
                                                    humi1_str = "0";
                                                }
                                                double.TryParse(ec1_str, out ec1);
                                                double.TryParse(humi1_str, out humi1);
                                                ec1 = ec1 / 100;
                                                humi1 = humi1 / 100;
                                                ec1_str = ec1.ToString();
                                                humi1_str = humi1.ToString();
                                                textEC1.Text = ec1_str;
                                                textHUMI1.Text = humi1_str;
                                                result = 3;
                                            }
                                            else result = 4;
                                        }
                                    }
                                }
                            }

                            else if (Alldata[1] == 'C')
                            {
                                if (Alldata[2] == 'D')
                                {
                                    if (Alldata[3] == '0')
                                    {
                                        if (Alldata[len - 1] == '#')
                                        {
                                            length_str2 = Alldata.Substring(4, 1);
                                            int.TryParse(length_str2, out length_data2);
                                            data2 = Alldata.Substring(5, length_data2);
                                            txtData2.Text = data2;
                                            crc_str = Alldata.Substring(5 + length_data2, len - 1 - length_data2 - 5);
                                            int.TryParse(crc_str, out crc);
                                            value_crc16 = value_crc1(Alldata[1], Alldata[2], Alldata[3], length_data2, data2);
                                            if (value_crc16 == crc)
                                            {
                                                if (length_data2 > 4)
                                                {
                                                    humi2_str = data2.Substring(0, 4);
                                                    ec2_str = data2.Substring(4, length_data2 - 4);
                                                }
                                                else
                                                {
                                                    ec2_str = "0";
                                                    humi2_str = "0";
                                                }
                                                double.TryParse(ec2_str, out ec2);
                                                double.TryParse(humi2_str, out humi2);
                                                ec2 = ec2 / 100;
                                                humi2 = humi2 / 100;
                                                ec2_str = ec2.ToString();
                                                humi2_str = humi2.ToString();
                                                textEC2.Text = ec2_str;
                                                textHUMI2.Text = humi2_str;
                                                result = 5;
                                            }
                                            else result = 6;
                                        }
                                    }
                                }
                            }
                        }
                        else;
                        //receivedData.Append($"Received: {Alldata}{Environment.NewLine}");
                        //if (receivedData.Length > MaxHistoryItems)
                        //{
                        //    receivedData.Clear();
                        //}
                        UpdateTextBox(receivedData.ToString());
                        
                            //await Task.Delay(2000);


                        if (result == 1)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'A', '1', 0, "");
                            r = o.ToString();
                            pack = "@DA10" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                            receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else if (result == 2)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'A', '2', 0, "");
                            r = o.ToString();
                            pack = "@DA20" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                           receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else if (result == 3)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'B', '1', 0, "");
                            r = o.ToString();
                            pack = "@DB10" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                           receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else if (result == 4)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'B', '2', 0, "");
                            r = o.ToString();
                            pack = "@DB20" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                           receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else if (result == 5)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'C', '1', 0, "");
                            r = o.ToString();
                            pack = "@DC10" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                           receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else if (result == 6)
                        {
                            await Task.Delay(500);
                            o = value_crc1('D', 'C', '2', 0, "");
                            r = o.ToString();
                            pack = "@DC20" + r + "#";
                            result = 0;
                            serialCOM.Write(pack);
                           receivedData.Append($"Sent: {pack}{Environment.NewLine}");
                            UpdateTextBox(receivedData.ToString());
                            result = 0;
                        }
                        else;
                    }
                }
                //receivedData.Append($"Data: {txtTemp.Text}                                                ");
                //UpdateTextBox(receivedData.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //cboTB.DataSource = SerialPort.GetPortNames();
            receivedData.Clear();
            if (cboTB.Text != "")
            {
                serialCOM.Close();
                if (!serialCOM.IsOpen)
                {
                    COMTrangthai.Text = "Disconnected";
                    COMTrangthai.ForeColor = Color.Red;
                }
            }
            else
            {
                COMTrangthai.Text = "Can't find COM";
                COMTrangthai.ForeColor = Color.Blue;
            }

        }
        private void UpdateTextBox(string text)
        {
            if (txtData.InvokeRequired)
            {
                txtData.Invoke(new Action<string>(UpdateTextBox), new object[] { text });
            }
            else
            {
                txtData.Text = text;
                txtData.SelectionStart = txtData.Text.Length;
                txtData.ScrollToCaret();
            }
        }
        private void SerialCOM_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            if (e.EventType == SerialPinChange.CtsChanged || e.EventType == SerialPinChange.DsrChanged)
            {
                if (!serialCOM.CtsHolding || !serialCOM.DsrHolding)
                {
                    DisconnectSerialPort();
                }
            }

        }
        private void DisconnectSerialPort()
        {
            if (serialCOM.IsOpen)
            {
                 serialCOM.Close();
                 if (!serialCOM.IsOpen)
                 {
                  // Đóng cổng COM thành công, làm sạch ComboBox
                  cboTB.Text = "";
                 }
            }
        }

        private void RequestRead_Click(object sender, EventArgs e)
        {
            String dulieu;
            String address_receive;
            String pack;

            if (trangthaiKieuTruyen.Text == "Sequentially")
            {
                MessageBox.Show("Transmission type does not match");
            }
            else if (cboTB.Text == "")
            {
                MessageBox.Show("You haven't selected COM.");
            }
            else if (cboBaudrate.Text == "")
            {
                MessageBox.Show("You haven't selected baudrate.");
            }
            else
            {
                if (serialCOM.IsOpen)
                {
                    if (cboR.Text == "Slave1")
                    {
                        address_receive = "B";
                    }
                    else
                    {
                        address_receive = "C";
                    }

                    String m = "";
                    int l = m.Length;
                    String n = l.ToString();
                    int q = value_crc1('D', address_receive[0], '3', l, m);
                    String p = q.ToString();
                    //dulieu = "@" + "D" + address_receive + "0" + n + m + p + "#";
                    dulieu = "@" + "D" + address_receive[0] + "3" + n + m + p + "#";
                    serialCOM.Write(dulieu);
                    receivedData.Append($"Sent: {dulieu}{Environment.NewLine}");
                    UpdateTextBox(receivedData.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String dulieu;
            if (cboT.Text == "")
            {
                MessageBox.Show("You have not selected a transmission type");
            }
            else if (cboTB.Text == "")
            {
                MessageBox.Show("You haven't selected COM.");
            }
            else if (cboBaudrate.Text == "")
            {
                MessageBox.Show("You haven't selected baudrate.");
            }
            else
            {
                if (serialCOM.IsOpen)
                {
                    receivedData.Clear();
                    if (cboT.Text == "Sequentially")
                    {
                        cboR.Text = "";
                        String m = "";
                        int l = m.Length;
                        String n = l.ToString();
                        int q = value_crc1('D', 'E', '4', l, m);
                        String p = q.ToString();
                        //dulieu = "@" + "D" + address_receive + "0" + n + m + p + "#";
                        dulieu = "@" + "D" + 'E' + "4" + n + m + p + "#";
                        serialCOM.Write(dulieu);
                        receivedData.Append($"Sent: {dulieu}{Environment.NewLine}");
                        UpdateTextBox(receivedData.ToString());
                        trangthaiKieuTruyen.Text = "Sequentially";
                        trangthaiKieuTruyen.ForeColor = Color.Green;
                    }
                    else

                    {
                        String m = "";
                        int l = m.Length;
                        String n = l.ToString();
                        int q = value_crc1('D', 'E', '5', l, m);
                        String p = q.ToString();
                        //dulieu = "@" + "D" + address_receive + "0" + n + m + p + "#";
                        dulieu = "@" + "D" + 'E' + "5" + n + m + p + "#";
                        serialCOM.Write(dulieu);
                        receivedData.Append($"Sent: {dulieu}{Environment.NewLine}");
                        UpdateTextBox(receivedData.ToString());
                        trangthaiKieuTruyen.Text = "Request";
                        trangthaiKieuTruyen.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void txtData1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void Send_Click(object sender, EventArgs e)
        //{
        //    String dulieu;
        //    String address_receive;
        //    String pack;

        //    if (cboQ.Text == "")
        //    {
        //        MessageBox.Show("You haven't selected transmisstion type.");
        //    }
        //    else if (cboTB.Text == "")
        //    {
        //        MessageBox.Show("You haven't selected COM.");
        //    }
        //    else if (cboBaudrate.Text == "")
        //    {
        //        MessageBox.Show("You haven't selected baudrate.");
        //    }
        //    else
        //    {
        //        if (serialCOM.IsOpen)
        //        {
        //            String m = "";
        //            m = cboQ.Text;
        //            dulieu = "@" + m + "#";
        //            dulieu = "@" + "D" + address_receive[0] + "3" + n + m + p + "#";
        //            serialCOM.Write(dulieu);
        //            receivedData.Append($"Sent: {dulieu}{Environment.NewLine}");
        //            UpdateTextBox(receivedData.ToString());
        //        }
        //    }
        //}
    }
}
