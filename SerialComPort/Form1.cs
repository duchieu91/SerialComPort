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

namespace SerialComPort
{
    public partial class Form1 : Form
    {
        #region bientoancuc
        string dataOut;
        #endregion
        public Form1()
        {
            InitializeComponent();


        }
        //double click on window of applocation
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxComPort.Items.AddRange(ports);
            serialPort1.DataReceived += new
                 SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }
        private void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxComPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudrate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBit.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParity.Text);
                switch (cBoxStopBit.Text)
                {
                    case "1":
                        serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                        break;
                    case "2":
                        serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "Two");
                        break;
                    default:
                        serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                        break;
                }
                //serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBit.Text);
                serialPort1.Open();
                //btOpen.BackColor = Color.Green;
                //btOpen.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (serialPort1.IsOpen)
                {
                    // Set write timeout
                    serialPort1.WriteTimeout = 5000;
                    // Disable Open button
                    btOpen.Enabled = false;
                    // Enable Close button
                    btClose.Enabled = true;
                    // Enable Send button
                    btSend.Enabled = true;
                    // Disable properties page controls
                    cBoxComPort.Enabled = false;
                    cBoxBaudrate.Enabled = false;
                    cBoxDataBit.Enabled = false;
                    cBoxStopBit.Enabled = false;
                    cBoxParity.Enabled = false;

                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Failed to close port.");
                }
                // Enable Open button
                btOpen.Enabled = true;
                // Disable Close button
                btClose.Enabled = false;
                // Disable Send button
                btSend.Enabled = false;
                // Enable properties page controls
                cBoxComPort.Enabled = true;
                cBoxBaudrate.Enabled = true;
                cBoxDataBit.Enabled = true;
                cBoxStopBit.Enabled = true;
                cBoxParity.Enabled = true;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOut = txtBoxSend.Text;
                serialPort1.WriteLine(dataOut);
                //serialPort1.Write(dataOut);
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if (txtBoxSend.Text !="")
            {
                txtBoxSend.Text = "";
            }
        }

        private void btnClearRecv_Click(object sender, EventArgs e)
        {
            if (txtBoxReceive.Text != "")
            {
                txtBoxReceive.Text = "";
            }
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // This event handler fires each time data is received by the serial port.
            // Read available data from the serial port and display it on the form.
            // This event does not run in the UI thread, so need to 
            // use delegate function

            string strErg = serialPort1.ReadExisting();
            this.BeginInvoke(new EventHandler(delegate
            {
                SetTheText(strErg);
            }));
            Application.DoEvents();
        }


        private void SetTheText(string strText)
        {
            if (strText.EndsWith("\r"))
            {
                txtBoxReceive.Text += strText + "\r\n";
            }
            else txtBoxReceive.Text += strText;
        }


    }
}
