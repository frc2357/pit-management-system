using System;
using System.Collections.Generic;
using InTheHand.Net;
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

namespace Bluetooth_Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DiscoverDevices();
        }
        public static readonly Guid FtpProtocol;
        public static BluetoothClient client;
        static void DiscoverDevices()
        {
            client = new BluetoothClient();
            
            
            string mac = "9C:5F:B0:17:18:2F";
            string Nmac = "4C:79:75:DA:83:42";
            string hex = mac.Replace(":", "");
            ulong arr = Convert.ToUInt64(hex, 16);
            BluetoothAddress address = new BluetoothAddress(arr);
            Console.WriteLine(address.ToString());
            BluetoothSecurity.PairRequest(address, "");
            Console.WriteLine("pair request sent");
            BluetoothEndPoint endPoint = new BluetoothEndPoint(address, BluetoothService.SerialPort, 30);
            for (int i = 1; i > 0; i--)
            {
                try
                {
                    Console.Write("connection attempted: ");
                    client.BeginConnect(endPoint,pretendFunction,client);
                }
                catch (Exception ex) { Console.Write("fail."); Console.WriteLine(ex); };
            }
            IReadOnlyCollection<BluetoothDeviceInfo> devices = client.DiscoverDevices();
            Console.WriteLine("Discovered Bluetooth Devices: " + devices.ToString());
            foreach (BluetoothDeviceInfo device in devices)
            {
                Console.WriteLine("Name: {0}, Address: {1}", device.DeviceName, device.DeviceAddress);
            }
            Console.WriteLine("all connections attempted");
            client.Close();
            Console.ReadLine();
        }
        static void pretendFunction(IAsyncResult result) {  
            if(result.IsCompleted)
            {
                Console.WriteLine("it finished");
            }
        }
    }
}
