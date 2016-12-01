using System;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;

namespace BDSA2016.Lecture11.App.Model
{
    public class Auth : IAuth
    {
        public ApplicationDataContainer AppSettings { get; private set; }

        // The client ID is used by the application to uniquely identify itself to Azure AD.
        public string ClientId => "b09ef53a-c4a7-4751-bd12-a17435b41d7f";

        public string Tenant => "ondfisk.onmicrosoft.com";
        public string Authority => "https://login.microsoftonline.com/" + Tenant;

        // API URL:
        public string Resource => "https://ondfisk.onmicrosoft.com/BDSA2016.Lecture11.Web";

        // Windows10 universal apps require redirect URI in the format below
        public string Url => $"ms-appx-web://Microsoft.AAD.BrokerPlugIn/{WebAuthenticationBroker.GetCurrentApplicationCallbackUri().Host.ToUpper()}";

        public WebAccountProvider AccountProvider { get; private set; }

        public WebAccount Account { get; set; }

        public async Task Initialize()
        {
            if (AccountProvider == null)
            {
                AccountProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", Authority);
            }
            if (AppSettings == null)
            {
                AppSettings = ApplicationData.Current.RoamingSettings;
            }
        }
    }
}
