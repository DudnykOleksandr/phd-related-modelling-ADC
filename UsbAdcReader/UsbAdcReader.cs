using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FTD2XX_NET;
using ZedGraph;

namespace UsbAdcReader
{
    public class ReaderEventArgs : EventArgs
    {
        public ReaderEventArgs(int persentage)
        {
            this.persentage = persentage;
        }
        public int persentage;
    }

    public class UsbAdcReader
    {
        public delegate void ReaderChangedEventHandler(object sender, ReaderEventArgs e);
        public event ReaderChangedEventHandler CalculatorChanged;

        public List<byte> ReadBytes { get; private set; }

        int numberOfBytesToRead;

        public UsbAdcReader(int numberOfBytesToRead)
        {
            ReadBytes = new List<byte>();
            this.numberOfBytesToRead = numberOfBytesToRead;
        }

        public void Read()
        {
            int numberOfBytesIsReadAlready = 0;
            FTDI myFtdiDevice = OpenAndPrepareDevice();
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            if (myFtdiDevice == null)
            {
                return;
            }

            UInt32 numBytesAvailable = 0;
            //Now that we have the amount of data we want available, read it
            UInt32 numBytesRead = 0;
            do
            {
                ftStatus = myFtdiDevice.GetRxBytesAvailable(ref numBytesAvailable);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    // Wait for a key press
                    Console.WriteLine("Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                    Console.ReadKey();
                    break;
                }
                byte[] readData = new byte[numBytesAvailable];
                ftStatus = myFtdiDevice.Read(readData, numBytesAvailable, ref numBytesRead);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    // Wait for a key press
                    Console.WriteLine("Failed to read data (error " + ftStatus.ToString() + ")");
                    Console.ReadKey();
                    break;
                }
                numberOfBytesIsReadAlready += (int)numBytesRead;
                numBytesRead = 0;
                ReadBytes.AddRange(readData);

                int persentage = 0;
                if (numberOfBytesIsReadAlready >= numberOfBytesToRead)
                {
                    persentage = 100;
                }
                else
                {
                    persentage = (int)(numberOfBytesIsReadAlready * 100 / numberOfBytesToRead);
                }
                //fire an event
                if (CalculatorChanged != null)
                    CalculatorChanged(this, new ReaderEventArgs(persentage));

                if (numberOfBytesIsReadAlready >= numberOfBytesToRead)
                {
                    break;
                }
            }
            while (true);

            // Close our device
            ftStatus = myFtdiDevice.Close();
            return;
        }
        FTDI OpenAndPrepareDevice()
        {
            UInt32 ftdiDeviceCount = 0;
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            // Create new instance of the FTDI device class
            FTDI myFtdiDevice = new FTDI();

            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                Console.WriteLine("Number of FTDI devices: " + ftdiDeviceCount.ToString());
                Console.WriteLine("");
            }
            else
            {
                // Wait for a key press
                Console.WriteLine("Failed to get number of devices (error " + ftStatus.ToString() + ")");
                Console.ReadKey();
                return null;
            }

            // If no devices available, return
            if (ftdiDeviceCount == 0)
            {
                // Wait for a key press
                Console.WriteLine("Failed to get number of devices (error " + ftStatus.ToString() + ")");
                Console.ReadKey();
                return null;
            }

            // Allocate storage for device info list
            FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

            // Populate our device list
            ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                {
                    Console.WriteLine("Device Index: " + i.ToString());
                    Console.WriteLine("Flags: " + String.Format("{0:x}", ftdiDeviceList[i].Flags));
                    Console.WriteLine("Type: " + ftdiDeviceList[i].Type.ToString());
                    Console.WriteLine("ID: " + String.Format("{0:x}", ftdiDeviceList[i].ID));
                    Console.WriteLine("Location ID: " + String.Format("{0:x}", ftdiDeviceList[i].LocId));
                    Console.WriteLine("Serial Number: " + ftdiDeviceList[i].SerialNumber.ToString());
                    Console.WriteLine("Description: " + ftdiDeviceList[i].Description.ToString());
                    Console.WriteLine("");
                }
            }


            // Open first device in our list by serial number
            ftStatus = myFtdiDevice.OpenBySerialNumber(ftdiDeviceList[0].SerialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                Console.WriteLine("Failed to open device (error " + ftStatus.ToString() + ")");
                Console.ReadKey();
                return null;
            }

            //Check the amount of data available to read
            //In this case we know how much data we are expecting, 
            //so wait until we have all of the bytes we have sent.
            ftStatus = myFtdiDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX | FTDI.FT_PURGE.FT_PURGE_TX);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                // Wait for a key press
                Console.WriteLine("Failed to purge (error " + ftStatus.ToString() + ")");
                Console.ReadKey();
                return null;
            }

            return myFtdiDevice;
        }

    }
}
