namespace SerialComPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOpen = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.cBoxComPort = new System.Windows.Forms.ComboBox();
            this.cBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.cBoxStopBit = new System.Windows.Forms.ComboBox();
            this.cBoxParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxDataBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSend = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelCountRx = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearRecv = new System.Windows.Forms.Button();
            this.txtBoxReceive = new System.Windows.Forms.TextBox();
            this.btClear = new System.Windows.Forms.Button();
            this.txtBoxSend = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btOpen.Location = new System.Drawing.Point(10, 9);
            this.btOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(56, 31);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "OPEN";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(108, 9);
            this.btClose.Margin = new System.Windows.Forms.Padding(2);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(56, 31);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "CLOSE";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // cBoxComPort
            // 
            this.cBoxComPort.FormattingEnabled = true;
            this.cBoxComPort.Location = new System.Drawing.Point(74, 20);
            this.cBoxComPort.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxComPort.Name = "cBoxComPort";
            this.cBoxComPort.Size = new System.Drawing.Size(92, 21);
            this.cBoxComPort.TabIndex = 1;
            // 
            // cBoxBaudrate
            // 
            this.cBoxBaudrate.FormattingEnabled = true;
            this.cBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cBoxBaudrate.Location = new System.Drawing.Point(74, 44);
            this.cBoxBaudrate.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxBaudrate.Name = "cBoxBaudrate";
            this.cBoxBaudrate.Size = new System.Drawing.Size(92, 21);
            this.cBoxBaudrate.TabIndex = 1;
            this.cBoxBaudrate.Text = "9600";
            // 
            // cBoxStopBit
            // 
            this.cBoxStopBit.FormattingEnabled = true;
            this.cBoxStopBit.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cBoxStopBit.Location = new System.Drawing.Point(74, 93);
            this.cBoxStopBit.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxStopBit.Name = "cBoxStopBit";
            this.cBoxStopBit.Size = new System.Drawing.Size(92, 21);
            this.cBoxStopBit.TabIndex = 1;
            this.cBoxStopBit.Text = "1";
            // 
            // cBoxParity
            // 
            this.cBoxParity.FormattingEnabled = true;
            this.cBoxParity.Items.AddRange(new object[] {
            "None",
            "Old",
            "Even"});
            this.cBoxParity.Location = new System.Drawing.Point(74, 117);
            this.cBoxParity.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxParity.Name = "cBoxParity";
            this.cBoxParity.Size = new System.Drawing.Size(92, 21);
            this.cBoxParity.TabIndex = 1;
            this.cBoxParity.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baudrate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stop Bit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Parity:";
            // 
            // cBoxDataBit
            // 
            this.cBoxDataBit.FormattingEnabled = true;
            this.cBoxDataBit.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cBoxDataBit.Location = new System.Drawing.Point(74, 68);
            this.cBoxDataBit.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxDataBit.Name = "cBoxDataBit";
            this.cBoxDataBit.Size = new System.Drawing.Size(92, 21);
            this.cBoxDataBit.TabIndex = 1;
            this.cBoxDataBit.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Bit:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cBoxComPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cBoxBaudrate);
            this.groupBox1.Controls.Add(this.cBoxDataBit);
            this.groupBox1.Controls.Add(this.cBoxParity);
            this.groupBox1.Controls.Add(this.cBoxStopBit);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(177, 163);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btOpen);
            this.groupBox2.Controls.Add(this.btClose);
            this.groupBox2.Location = new System.Drawing.Point(10, 181);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(176, 44);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(13, 62);
            this.btSend.Margin = new System.Windows.Forms.Padding(2);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(56, 36);
            this.btSend.TabIndex = 5;
            this.btSend.Text = "SEND DATA";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelCountRx);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnClearRecv);
            this.groupBox3.Controls.Add(this.txtBoxReceive);
            this.groupBox3.Location = new System.Drawing.Point(190, 19);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(272, 206);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receive";
            // 
            // labelCountRx
            // 
            this.labelCountRx.AutoSize = true;
            this.labelCountRx.Location = new System.Drawing.Point(193, 184);
            this.labelCountRx.Name = "labelCountRx";
            this.labelCountRx.Size = new System.Drawing.Size(13, 13);
            this.labelCountRx.TabIndex = 3;
            this.labelCountRx.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Rx:";
            // 
            // btnClearRecv
            // 
            this.btnClearRecv.Location = new System.Drawing.Point(5, 169);
            this.btnClearRecv.Name = "btnClearRecv";
            this.btnClearRecv.Size = new System.Drawing.Size(75, 33);
            this.btnClearRecv.TabIndex = 1;
            this.btnClearRecv.Text = "CLEAR";
            this.btnClearRecv.UseVisualStyleBackColor = true;
            this.btnClearRecv.Click += new System.EventHandler(this.btnClearRecv_Click);
            // 
            // txtBoxReceive
            // 
            this.txtBoxReceive.Location = new System.Drawing.Point(5, 18);
            this.txtBoxReceive.Multiline = true;
            this.txtBoxReceive.Name = "txtBoxReceive";
            this.txtBoxReceive.ReadOnly = true;
            this.txtBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxReceive.Size = new System.Drawing.Size(262, 145);
            this.txtBoxReceive.TabIndex = 0;
            this.txtBoxReceive.TextChanged += new System.EventHandler(this.txtBoxReceive_TextChanged);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(108, 62);
            this.btClear.Margin = new System.Windows.Forms.Padding(2);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(56, 36);
            this.btClear.TabIndex = 7;
            this.btClear.Text = "CLEAR DATA";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // txtBoxSend
            // 
            this.txtBoxSend.Location = new System.Drawing.Point(0, 18);
            this.txtBoxSend.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxSend.Multiline = true;
            this.txtBoxSend.Name = "txtBoxSend";
            this.txtBoxSend.Size = new System.Drawing.Size(452, 40);
            this.txtBoxSend.TabIndex = 6;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btClear);
            this.groupBox4.Controls.Add(this.txtBoxSend);
            this.groupBox4.Controls.Add(this.btSend);
            this.groupBox4.Location = new System.Drawing.Point(10, 242);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(453, 103);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transmite";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Form1";
            this.Text = "Serial Communication";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox cBoxComPort;
        private System.Windows.Forms.ComboBox cBoxBaudrate;
        private System.Windows.Forms.ComboBox cBoxStopBit;
        private System.Windows.Forms.ComboBox cBoxParity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxDataBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBoxSend;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.TextBox txtBoxReceive;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClearRecv;
        private System.Windows.Forms.Label labelCountRx;
        private System.Windows.Forms.Label label6;
    }
}

