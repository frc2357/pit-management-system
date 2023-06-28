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
        static void DiscoverDevices()
        {
            BluetoothClient client = new BluetoothClient();
            string mac = "9C:5F:B0:17:18:2F";
            string hex = mac.Replace(":", "");
            ulong arr = Convert.ToUInt64(hex, 16);
            BluetoothAddress address = new BluetoothAddress(arr);
            Console.WriteLine(address.ToString());
            Guid guid = Guid.Parse("11010000-0000-1000-8000-00805F9B34FB");
            BluetoothSecurity.PairRequest(address, "");
            Console.WriteLine("pair request sent");
            BluetoothEndPoint endPoint = new BluetoothEndPoint(address, guid, 30);
            for (int i = 3; i > 0; i--)
            {
                try
                {
                    Console.Write("connection attempted: ");
                    client.Connect(endPoint);
                    Console.Write("Success!--------*");
                    break;
                }
                catch (Exception ex) { Console.Write("fail."); Console.WriteLine(ex); };
            }
            Console.WriteLine("all connections attempted");
            IReadOnlyCollection<BluetoothDeviceInfo> devices = client.DiscoverDevices();
            Console.WriteLine("Discovered Bluetooth Devices: " + devices.ToString());
            foreach (BluetoothDeviceInfo device in devices)
            {
                Console.WriteLine("Name: {0}, Address: {1}", device.DeviceName, device.DeviceAddress);
            }
            client.Close();
            Console.ReadLine();
        }
        static void pretendFunction() { }
    }
}
