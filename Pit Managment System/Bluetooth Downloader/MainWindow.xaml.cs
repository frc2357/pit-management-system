using System;
using System.Collections.Generic;
using InTheHand.Net;
using System.IO;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;

namespace Bluetooth_Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BluetoothClient workingClient;
        public MainWindow()
        {
            InitializeComponent();
            DiscoverDevices();
        }
        public readonly Guid FtpProtocol;
        public BluetoothClient client;
        public BluetoothListener listener;
        public StreamReader sr;
        public StreamWriter sw;
        void DiscoverDevices()
        {
            client = new BluetoothClient();
            listener = new BluetoothListener(BluetoothService.SerialPort);

            Debug.WriteLine("made it 1");
            string mac = "b8:5f:98:f0:56:57";
            string hex = mac.Replace(":", "");
            ulong arr = Convert.ToUInt64(hex, 16);
            Debug.WriteLine("made it 2");
            listener.Start();
            Debug.WriteLine("made it 3");
            BluetoothAddress address = new BluetoothAddress(arr);
            Debug.WriteLine(address.ToString() + " ---made it 4");
            Debug.WriteLine("serial port service: " + BluetoothService.SerialPort.ToString());
            BluetoothEndPoint endPoint = new BluetoothEndPoint(address, BluetoothService.SerialPort, 21);
            Debug.WriteLine("looking for connection...");
            workingClient = listener.AcceptBluetoothClient();
            Debug.WriteLine("listener has connected to the device");
            Stream stream = workingClient.GetStream();
            Debug.WriteLine("Device name: " + workingClient.RemoteMachineName.ToString());
            Debug.WriteLine("Stream: " + stream.CanWrite + "\n" + stream.WriteTimeout);
            stream.WriteTimeout = 500;
            /*sr = new StreamReader(stream, System.Text.Encoding.ASCII);
            sr.InitializeLifetimeService();*/
            sw = new StreamWriter(stream, System.Text.Encoding.ASCII);
            Debug.WriteLine(sw.ToString());
            String thingToWrite = "hello";
            workingClient.GetStream().Write(System.Text.Encoding.ASCII.GetBytes("hello\n"), 0, 6);
            workingClient.GetStream().Flush();
            sw.Flush();
            Debug.WriteLine("stream writer was made");

        }
        void readFromBuffer(object sender, RoutedEventArgs aakjshfkjh)
        {
            char[] buffer = new char[2048];
            Debug.WriteLine("Reading...");
            Debug.Write("Stream Buffer that was read: ");
            string line;line = sr.ReadLine(); Debug.WriteLine(line );
            //do {  }  while (line != -1);
        }
        void writeToStream(object sender, RoutedEventArgs asdjkaFJKEF)
        {
            try
            {
                Debug.WriteLine("Device name: "+workingClient.RemoteMachineName.ToString());
                sw.Write("hello\n");
                workingClient.GetStream().Write(System.Text.Encoding.ASCII.GetBytes("hello\n"), 0, 6);
                Debug.WriteLine("button pushed, should have wrote");
            }
            catch (Exception e) { Debug.WriteLine(e.ToString()); }
        }
    }
}