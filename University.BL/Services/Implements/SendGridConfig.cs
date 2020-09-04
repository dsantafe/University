using SendGrid;
using System.Configuration;

namespace University.BL.Services.Implements
{
    public class SendGridConfig
    {
        private static SendGridClient client = null;
        private SendGridConfig() { }

        public static SendGridClient Instance()
        {
            if (client == null)
                client = new SendGridClient(ConfigurationManager.AppSettings["SendGridKey"].ToString());

            return client;
        }
    }
}
