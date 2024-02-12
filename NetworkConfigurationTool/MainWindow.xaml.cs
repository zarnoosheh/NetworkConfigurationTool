using NetworkConfigurationTool.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Threading;

namespace NetworkConfigurationTool
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<NetworkAdapterInfo> NetworkAdapters { get; set; }
        private DispatcherTimer timer;
        public MainWindow()
		{
			InitializeComponent();
			NetworkAdapters = new ObservableCollection<NetworkAdapterInfo>();
			DataContext = this;
			LoadNetworkAdapters();


            // Set up the timer to refresh every 5 seconds
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NetworkAdapters.Clear();
            LoadNetworkAdapters();
        }

        private void LoadNetworkAdapters()
		{
			var adapters = NetworkInterface.GetAllNetworkInterfaces();
			foreach (var adapter in adapters)
			{
				var iPAddressInformation = adapter.GetIPProperties().UnicastAddresses.
					FirstOrDefault(p => p.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

				NetworkAdapters.Add(new NetworkAdapterInfo
				{
					Name = adapter.Name,
					Status = adapter.OperationalStatus.ToString(),
					IPAddress = adapter.OperationalStatus == OperationalStatus.Up ? iPAddressInformation?.Address.ToString() : "",
					SubNetMask = adapter.OperationalStatus == OperationalStatus.Up ? iPAddressInformation?.IPv4Mask.ToString() : ""
				});
			}
		}
	}
}
