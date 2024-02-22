namespace Đo_an_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ButConnect = new System.Windows.Forms.Button();
            this.ButExit = new System.Windows.Forms.Button();
            this.serialCOM = new System.IO.Ports.SerialPort(this.components);
            this.butSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.COMTrangthai = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtData = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboT = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textHUMI1 = new System.Windows.Forms.TextBox();
            this.textEC1 = new System.Windows.Forms.TextBox();
            this.textEC2 = new System.Windows.Forms.TextBox();
            this.textHUMI2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBaudrate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.lable5 = new System.Windows.Forms.Label();
            this.txtAllData = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.RequestRead = new System.Windows.Forms.Button();
            this.cboR = new System.Windows.Forms.ComboBox();
            this.trangthaiKieuTruyen = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(815, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỒ ÁN 2";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ButConnect
            // 
            this.ButConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButConnect.ForeColor = System.Drawing.Color.Green;
            this.ButConnect.Location = new System.Drawing.Point(179, 543);
            this.ButConnect.Name = "ButConnect";
            this.ButConnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButConnect.Size = new System.Drawing.Size(199, 64);
            this.ButConnect.TabIndex = 1;
            this.ButConnect.Text = "CONNECT";
            this.ButConnect.UseVisualStyleBackColor = true;
            this.ButConnect.Click += new System.EventHandler(this.ButConnect_Click);
            // 
            // ButExit
            // 
            this.ButExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButExit.ForeColor = System.Drawing.Color.Red;
            this.ButExit.Location = new System.Drawing.Point(1044, 543);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(199, 64);
            this.ButExit.TabIndex = 2;
            this.ButExit.Text = "EXIT";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // butSend
            // 
            this.butSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSend.ForeColor = System.Drawing.Color.Black;
            this.butSend.Location = new System.Drawing.Point(23, 174);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(209, 40);
            this.butSend.TabIndex = 8;
            this.butSend.Text = "Mode Status:";
            this.butSend.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(607, 543);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(199, 64);
            this.button1.TabIndex = 10;
            this.button1.Text = "DISCONNECT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(18, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "COM Status:";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // COMTrangthai
            // 
            this.COMTrangthai.AutoSize = true;
            this.COMTrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMTrangthai.ForeColor = System.Drawing.Color.Blue;
            this.COMTrangthai.Location = new System.Drawing.Point(244, 180);
            this.COMTrangthai.Name = "COMTrangthai";
            this.COMTrangthai.Size = new System.Drawing.Size(161, 25);
            this.COMTrangthai.TabIndex = 12;
            this.COMTrangthai.Text = "Can\'t find COM";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(1414, 180);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(350, 427);
            this.txtData.TabIndex = 13;
            // 
            // cboT
            // 
            this.cboT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT.FormattingEnabled = true;
            this.cboT.Location = new System.Drawing.Point(276, 47);
            this.cboT.Name = "cboT";
            this.cboT.Size = new System.Drawing.Size(123, 26);
            this.cboT.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(23, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 40);
            this.button3.TabIndex = 16;
            this.button3.Text = "Mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // textHUMI1
            // 
            this.textHUMI1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHUMI1.Location = new System.Drawing.Point(432, 34);
            this.textHUMI1.Name = "textHUMI1";
            this.textHUMI1.Size = new System.Drawing.Size(91, 24);
            this.textHUMI1.TabIndex = 20;
            // 
            // textEC1
            // 
            this.textEC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEC1.Location = new System.Drawing.Point(454, 33);
            this.textEC1.Name = "textEC1";
            this.textEC1.Size = new System.Drawing.Size(91, 24);
            this.textEC1.TabIndex = 21;
            // 
            // textEC2
            // 
            this.textEC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEC2.Location = new System.Drawing.Point(454, 88);
            this.textEC2.Name = "textEC2";
            this.textEC2.Size = new System.Drawing.Size(91, 24);
            this.textEC2.TabIndex = 22;
            // 
            // textHUMI2
            // 
            this.textHUMI2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHUMI2.Location = new System.Drawing.Point(432, 88);
            this.textHUMI2.Name = "textHUMI2";
            this.textHUMI2.Size = new System.Drawing.Size(91, 24);
            this.textHUMI2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(275, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "EC SLAVE1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(275, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "EC SLAVE2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(247, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "HUMI SLAVE1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(247, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 25);
            this.label8.TabIndex = 27;
            this.label8.Text = "HUMI SLAVE2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select COM:";
            // 
            // cboTB
            // 
            this.cboTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTB.FormattingEnabled = true;
            this.cboTB.Location = new System.Drawing.Point(249, 47);
            this.cboTB.Name = "cboTB";
            this.cboTB.Size = new System.Drawing.Size(121, 26);
            this.cboTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Baudrate:";
            // 
            // cboBaudrate
            // 
            this.cboBaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBaudrate.FormattingEnabled = true;
            this.cboBaudrate.Location = new System.Drawing.Point(249, 114);
            this.cboBaudrate.Name = "cboBaudrate";
            this.cboBaudrate.Size = new System.Drawing.Size(121, 26);
            this.cboBaudrate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "DATA1:";
            // 
            // txtData1
            // 
            this.txtData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData1.Location = new System.Drawing.Point(219, 50);
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(160, 24);
            this.txtData1.TabIndex = 5;
            this.txtData1.TextChanged += new System.EventHandler(this.txtData1_TextChanged);
            // 
            // lable5
            // 
            this.lable5.AutoSize = true;
            this.lable5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable5.ForeColor = System.Drawing.Color.Red;
            this.lable5.Location = new System.Drawing.Point(8, 183);
            this.lable5.Name = "lable5";
            this.lable5.Size = new System.Drawing.Size(190, 25);
            this.lable5.TabIndex = 6;
            this.lable5.Text = "All Data Received:";
            // 
            // txtAllData
            // 
            this.txtAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllData.Location = new System.Drawing.Point(219, 181);
            this.txtAllData.Name = "txtAllData";
            this.txtAllData.Size = new System.Drawing.Size(160, 24);
            this.txtAllData.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(8, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "DATA2:";
            // 
            // txtData2
            // 
            this.txtData2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData2.Location = new System.Drawing.Point(219, 117);
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(160, 24);
            this.txtData2.TabIndex = 9;
            // 
            // RequestRead
            // 
            this.RequestRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestRead.ForeColor = System.Drawing.Color.Black;
            this.RequestRead.Location = new System.Drawing.Point(23, 110);
            this.RequestRead.Name = "RequestRead";
            this.RequestRead.Size = new System.Drawing.Size(209, 40);
            this.RequestRead.TabIndex = 30;
            this.RequestRead.Text = "Request Read:";
            this.RequestRead.UseVisualStyleBackColor = true;
            this.RequestRead.Click += new System.EventHandler(this.RequestRead_Click);
            // 
            // cboR
            // 
            this.cboR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboR.FormattingEnabled = true;
            this.cboR.Location = new System.Drawing.Point(276, 114);
            this.cboR.Name = "cboR";
            this.cboR.Size = new System.Drawing.Size(123, 26);
            this.cboR.TabIndex = 30;
            // 
            // trangthaiKieuTruyen
            // 
            this.trangthaiKieuTruyen.AutoSize = true;
            this.trangthaiKieuTruyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangthaiKieuTruyen.ForeColor = System.Drawing.Color.Green;
            this.trangthaiKieuTruyen.Location = new System.Drawing.Point(271, 182);
            this.trangthaiKieuTruyen.Name = "trangthaiKieuTruyen";
            this.trangthaiKieuTruyen.Size = new System.Drawing.Size(131, 25);
            this.trangthaiKieuTruyen.TabIndex = 31;
            this.trangthaiKieuTruyen.Text = "Sequentially";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Đo_an_2.Properties.Resources.Icons8_Windows_8_Industry_Electricity_512;
            this.pictureBox2.Location = new System.Drawing.Point(23, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Đo_an_2.Properties.Resources.Custom_Icon_Design_Lovely_Weather_2_Humidity_512;
            this.pictureBox1.Location = new System.Drawing.Point(24, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trangthaiKieuTruyen);
            this.groupBox1.Controls.Add(this.cboR);
            this.groupBox1.Controls.Add(this.RequestRead);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cboT);
            this.groupBox1.Controls.Add(this.butSend);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(506, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmission Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboBaudrate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboTB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.COMTrangthai);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(40, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 234);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM and Baudrate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtData2);
            this.groupBox3.Controls.Add(this.lable5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtAllData);
            this.groupBox3.Controls.Add(this.txtData1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(983, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 233);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATA";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textEC2);
            this.groupBox4.Controls.Add(this.textEC1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(39, 383);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 134);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Displays electrical conductivity";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.textHUMI2);
            this.groupBox5.Controls.Add(this.textHUMI1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(744, 383);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(546, 134);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Displays humidity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(1542, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 31);
            this.label10.TabIndex = 28;
            this.label10.Text = "Monitor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1817, 643);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButExit);
            this.Controls.Add(this.ButConnect);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButConnect;
        private System.Windows.Forms.Button ButExit;
        private System.IO.Ports.SerialPort serialCOM;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label COMTrangthai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboT;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.TextBox textHUMI1;
        private System.Windows.Forms.TextBox textEC1;
        private System.Windows.Forms.TextBox textEC2;
        private System.Windows.Forms.TextBox textHUMI2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBaudrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.Label lable5;
        private System.Windows.Forms.TextBox txtAllData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.Button RequestRead;
        private System.Windows.Forms.ComboBox cboR;
        private System.Windows.Forms.Label trangthaiKieuTruyen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
    }
}

