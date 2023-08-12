using System.Net;

namespace PresentationLayer.Extensions
{
    public static class GetPublicIPAddress
    {
        public static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }
        
        #region LocalIp
        //public static string GetIPAddress()
        //{
            //IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            //string resultIp = "";
            //if (remoteIpAddress != null)
            //{
            //    // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
            //    // This usually only happens when the browser is on the same machine as the server.
            //    if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            //    {
            //        remoteIpAddress = Dns.GetHostEntry(remoteIpAddress).AddressList
            //            .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            //    }
            //    resultIp = remoteIpAddress.ToString();
            //    user.IpAddress = resultIp; 
            //    await _userManager.UpdateAsync(user);
            //}
        //}
        #endregion

    }
}
