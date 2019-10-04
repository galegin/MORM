using System;
using System.Net;
using System.Net.Sockets;

namespace MORM.CrossCutting
{
    public static class NetworkExtensions
    {
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                    return ipAddress;
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}