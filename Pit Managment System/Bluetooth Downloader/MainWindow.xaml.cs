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
        public  readonly Guid FtpProtocol;
        public  BluetoothClient client;
        public  BluetoothListener listener;
         void DiscoverDevices()
        {
            client = new BluetoothClient();
            listener = new BluetoothListener(BluetoothService.SerialPort);
            
            string phonemac = "9C:5F:B0:17:18:2F";
            Debug.WriteLine("made it 1");
            string mac = "b8:5f:98:f0:56:57";
            string Nmac = "4C:79:75:DA:83:42";
            string hex = mac.Replace(":", "");
            ulong arr = Convert.ToUInt64(hex, 16);
            Debug.WriteLine("made it 2");
            listener.Start();
            Debug.WriteLine("made it 3");
            BluetoothAddress address = new BluetoothAddress(arr);
            Debug.WriteLine(address.ToString()+" ---made it 4");
            Debug.WriteLine("serial port service: "+BluetoothService.SerialPort.ToString());
            BluetoothEndPoint endPoint = new BluetoothEndPoint(address, BluetoothService.SerialPort, 21);
                    Debug.WriteLine("looking for connection...");
                    workingClient = listener.AcceptBluetoothClient();
                    Debug.WriteLine("listener has connected to the device");
           
        }
         void pretendFunction(IAsyncResult result) {  
            if(result.IsCompleted)
            {
                Debug.WriteLine("it finished, is connected: "+client.Connected.ToString());
            }
        }
        void writeToStream(object sender, RoutedEventArgs asdjkaFJKEF)
        {
            try
            {
                var stream = workingClient.GetStream();
                StreamWriter sw = new StreamWriter(stream, System.Text.Encoding.ASCII);
                sw.WriteLine("Hello world!");
                Debug.WriteLine("button pushed, should have wrote");
            }
            catch(Exception e) {Debug.WriteLine(e.ToString());}
        }
    }
}
