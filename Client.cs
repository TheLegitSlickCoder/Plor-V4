using System.Net;

namespace Plor_V4
{
    class Client
    {
        WebClient wc = new WebClient();

        //Site exists:
        public bool siteExists(string URL)
        {
            try
            {
                wc.DownloadString(URL);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}