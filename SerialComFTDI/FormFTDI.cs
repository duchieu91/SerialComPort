using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;
using SerialComFTDI;
using System.Threading;

namespace SerialComFTDI
{

    public partial class FormFTDI : Form
    {
        #region bientoancuc
        string dataOut;
        string readData;
        UInt32 RxCount = 0;
        UInt32 TxCount = 0;
        UInt32 numBytesWritten = 0;
        UInt32 ftdiDeviceCount = 0;
        UInt32 numBytesAvailable = 0;
        UInt32 numBytesReaded = 0;
        FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
        // Create new instance of the FTDI device class
        FTDI myFtdiDevice = new FTDI();
        // Allocate storage for device info list
        FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList;
        #endregion
        public FormFTDI()
        {
            InitializeComponent();
            Task.Run(() => ReceiveLoop());
        }
        private void FormFTDI_Load(object sender, EventArgs e)
        {
            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                txtBoxLog.Text += ("Number of FTDI devices: " + ftdiDeviceCount.ToString() + "\r\n");
            }
            else
            {
                txtBoxLog.Text += ("Failed to get number of devices (error 1 " + ftStatus.ToString() + ")" + "\r\n");
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                txtBoxLog.Text += ("Failed to get number of devices (error 2 " + ftStatus.ToString() + ")" + "\r\n");
            }
            // Allocate storage for device info list
            ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            cBoxDevice.Text = "0"; //default with IndexDevice 0
            for (UInt32 i = 0; i < ftdiDeviceCount; i++)
            {
                cBoxDevice.Items.AddRange(new object[] { i.ToString() });
            }

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                {
                    txtBoxLog.Text += ("Device Index: " + i.ToString() + "\r\n");
                    txtBoxLog.Text += ("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags) + "\r\n");
                    txtBoxLog.Text += ("Type: " + ftdiDeviceList[i].Type.ToString() + "\r\n");
                    txtBoxLog.Text += ("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID) + "\r\n");
                    txtBoxLog.Text += ("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId) + "\r\n");
                    txtBoxLog.Text += ("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString() + "\r\n");
                    txtBoxLog.Text += ("Description: " + ftdiDeviceList[i].Description.ToString() + "\r\n");

                }
            }

        }
        public void ReceiveLoop()
        {
            var receivedDataEvent = new AutoResetEvent(false);
            myFtdiDevice.SetEventNotification(FTDI.FT_EVENTS.FT_EVENT_RXCHAR, receivedDataEvent);
            var cancellation = new CancellationTokenSource();  // should be declared in a broader scope
            while (!cancellation.IsCancellationRequested)
            {
                receivedDataEvent.WaitOne();
                Handler_DataReceived();
            }
        }
        private void btOpen_Click(object sender, EventArgs e)
        {
            byte stopBit;
            byte parity;
            try
            {
                byte IndexDevice = Convert.ToByte(cBoxDevice.Text);
                UInt32 BaudRate = Convert.ToUInt32(cBoxBaudrate.Text);
                byte dataBits = Convert.ToByte(cBoxDataBit.Text);
                switch (cBoxStopBit.Text)
                {
                    case "1":
                        stopBit = FTDI.FT_STOP_BITS.FT_STOP_BITS_1;
                        break;
                    case "2":
                        stopBit = FTDI.FT_STOP_BITS.FT_STOP_BITS_2;
                        break;
                    default:
                        stopBit = FTDI.FT_STOP_BITS.FT_STOP_BITS_1;
                        break;
                }
                switch (cBoxParity.Text)
                {
                    case "None":
                        parity = FTDI.FT_PARITY.FT_PARITY_NONE;
                        break;
                    case "Odd":
                        parity = FTDI.FT_PARITY.FT_PARITY_ODD;
                        break;
                    case "Even":
                        parity = FTDI.FT_PARITY.FT_PARITY_ODD;
                        break;
                    default:
                        parity = FTDI.FT_PARITY.FT_PARITY_NONE;
                        break;
                }
                // Open device with IndexDevice in our list by serial number
                ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[IndexDevice].SerialNumber);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to open device (error " + ftStatus.ToString() + ")" + "\r\n");
                    return;
                }
                ftStatus = myFtdiDevice.SetBaudRate(BaudRate);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to set Baurate (error " + ftStatus.ToString() + ")" + "\r\n");
                }

                // Set data characteristics - Data bits, Stop bits, Parity
                ftStatus = myFtdiDevice.SetDataCharacteristics(dataBits, stopBit, parity);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to set data characteristics (error " + ftStatus.ToString() + ")" + "\r\n");
                }




            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (myFtdiDevice.IsOpen)
                {
                    // Set read timeout to 5 seconds, write timeout to infinite
                    ftStatus = myFtdiDevice.SetTimeouts(5000, 0);
                    if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    {
                        // Wait for a key press
                        txtBoxLog.Text += ("Failed to set timeouts (error " + ftStatus.ToString() + ")" + "\r\n");
                    }
                    // Disable Open button
                    btOpen.Enabled = false;
                    // Enable Close button
                    btClose.Enabled = true;
                    // Enable Send button
                    btSend.Enabled = true;
                    // Disable properties page controls
                    cBoxDevice.Enabled = false;
                    cBoxBaudrate.Enabled = false;
                    cBoxDataBit.Enabled = false;
                    cBoxStopBit.Enabled = false;
                    cBoxParity.Enabled = false;
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (myFtdiDevice.IsOpen)
            {
                try
                {
                    myFtdiDevice.Close();
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
                cBoxDevice.Enabled = true;
                cBoxBaudrate.Enabled = true;
                cBoxDataBit.Enabled = true;
                cBoxStopBit.Enabled = true;
                cBoxParity.Enabled = true;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (myFtdiDevice.IsOpen)
            {
                dataOut = txtBoxSend.Text;
                myFtdiDevice.Write(dataOut, dataOut.Length, ref numBytesWritten);
                TxCount += numBytesWritten;
                labelTxCounnt.Text = TxCount.ToString();
            }
            else MessageBox.Show("Device is not open");

        }

        private void btClearTx_Click(object sender, EventArgs e)
        {
            if (txtBoxSend.Text != "")
            {
                txtBoxSend.Text = "";
                TxCount = 0;
            }

        }

        private void btnClearRecv_Click(object sender, EventArgs e)
        {
            if (txtBoxReceive.Text != "")
            {
                txtBoxReceive.Text = "";
                RxCount = 0;
            }

        }



        private void ShowTheReceivedText(string strText)
        {
            if (strText.EndsWith("\r"))
            {
                txtBoxReceive.Text += strText + "\r\n";
            }
            else txtBoxReceive.Text += strText;
        }

        /// <summary>
        /// First method for autoreceiving data from FTDI device
        /// using function SetEventNotification of FTD2XX_NET wrapper
        /// </summary>
        /// <param name="sender"></param> maybe dont need
        /// <param name="e"></param>
        private void Handler_DataReceived()
        {
            ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                txtBoxLog.Text += ("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")" + "\r\n");
            }
            else
            {
                // This event handler fires each time data is received by the serial port.
                ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesReaded);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to read data (error " + ftStatus.ToString() + ")" + "\r\n");
                }
                else
                {
                    ShowTheReceivedText(readData);
                }
                RxCount += numBytesReaded;
                labelRxCount.Text = RxCount.ToString();
            }

        }
        // Neu thay doi text trong box thi tu dong cuon toi dong cuoi
        private void txtBoxLog_TextChanged(object sender, EventArgs e)
        {
            txtBoxLog.SelectionStart = txtBoxLog.Text.Length;
            txtBoxLog.ScrollToCaret();
            txtBoxLog.Refresh();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                txtBoxLog.Text += ("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")" + "\r\n");
            }
            else
            {
                ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesReaded);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to read data (error " + ftStatus.ToString() + ")" + "\r\n");
                }
                else
                {
                    ShowTheReceivedText(readData);
                    RxCount += numBytesReaded;
                    labelRxCount.Text = RxCount.ToString();
                }
            }

        }

        /// <summary>
        /// Second method for autoreceiving data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handler_DataReceived(object sender, FTDI_DataReceivedEventArgs e)
        {
            ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                txtBoxLog.Text += ("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")" + "\r\n");
            }
            else
            {
                // This event handler fires each time data is received by the serial port.
                ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesReaded);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    txtBoxLog.Text += ("Failed to read data (error " + ftStatus.ToString() + ")" + "\r\n");
                }
                else
                {
                    ShowTheReceivedText(readData);
                }
                RxCount += numBytesReaded;
                labelRxCount.Text = RxCount.ToString();
            }

        }
        public class FTDI_ReceiveDataProcess
        {
            public UInt32 count;
            FTDI myFtdiDevice1 = new FTDI();
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            public bool IsRxAvailable()
            {
                ftStatus = myFtdiDevice1.GetRxBytesAvailable(ref count);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    FTDI_DataReceivedEventArgs args = new FTDI_DataReceivedEventArgs();
                    args.RxByteAvailable = count;
                    return true;
                }
                else return false;
            }

            protected virtual void OnDataReceived(FTDI_DataReceivedEventArgs e)
            {
                EventHandler< FTDI_DataReceivedEventArgs> handler = FTDI_DataReceived;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            public static event EventHandler<FTDI_DataReceivedEventArgs> FTDI_DataReceived;

        }
        public class FTDI_DataReceivedEventArgs : EventArgs
        {
            public UInt32 RxByteAvailable { get; set; }
        }
    }
}
