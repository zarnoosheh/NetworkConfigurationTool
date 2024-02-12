using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkConfigurationTool.Models
{
	public class NetworkAdapterInfo : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; NotifyPropertyChanged("Name"); }
		}

		private string _status;
		public string Status
		{
			get { return _status; }
			set { _status = value; NotifyPropertyChanged("Status"); }
		}

		private string _ipAddress;
		public string IPAddress
		{
			get { return _ipAddress; }
			set { _ipAddress = value; NotifyPropertyChanged("IPAddress"); }
		}


		private string _subNetMask;
		public string SubNetMask
		{
			get { return _subNetMask; }
			set { _subNetMask = value; NotifyPropertyChanged("SubNetMask"); }
		}
		private void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
