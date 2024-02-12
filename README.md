# Network Configuration Tool

## Description
The Network Configuration Tool provides a quick overview of the network configuration for Windows PCs running a specific application. It enables technicians to easily identify network adapters, their status, and relevant IP configuration details.

## Functionality
- Displays network adapter information including name, status, IP address, and subnet mask (IPv4Mask).
- Provides real-time updates by refreshing information every 5 seconds.

## Implementation Details
- Developed in C# using Windows Presentation Foundation (WPF) for a user-friendly interface.
- Utilizes the System.Net.NetworkInformation namespace to retrieve network adapter information.
- Employs ObservableCollection to dynamically update the UI with changes in network adapter status.

## Usage
1. Run the application.
2. The main window displays a list of network adapters along with their status and IP configuration details.
3. Configure which adapters to display as needed.
4. Observe real-time updates as the status of network adapters changes.



