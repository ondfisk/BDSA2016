using BDSA2016.Lecture11.App.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Authentication.Web;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.Storage;
using Windows.UI.Popups;

namespace BDSA2016.Lecture11.App.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private readonly IAuth _auth;

        private string _label;
        public string Label { get { return _label; } set { if (_label != value) { _label = value; OnPropertyChanged(); } } }

        private string _button;
        public string Button { get { return _button; } set { if (_button != value) { _button = value; OnPropertyChanged(); } } }

        public ICommand SignInOrOutCommand { get; }

        public ICommand BackCommand { get; set; }

        public AuthViewModel(IAuth auth)
        {
            _auth = auth;

            Button = "Sign in/out";

            SignInOrOutCommand = new RelayCommand(async o => {
                // prepare a request with 'WebTokenRequestPromptType.ForceAuthentication', 
                // which guarantees that the user will be able to enter an account of their choosing
                // regardless of what accounts are already present on the system
                var wtr = new WebTokenRequest(_auth.AccountProvider, string.Empty, _auth.ClientId, WebTokenRequestPromptType.ForceAuthentication);
                wtr.Properties.Add("resource", _auth.Resource);
                var wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr);
                if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
                {
                    _auth.Account = wtrr.ResponseData[0].WebAccount;
                    SignedIn();
                }
                else
                {
                    SignedOut();
                    MessageDialog messageDialog = new MessageDialog("We could not sign you in. Please try again.");
                    await messageDialog.ShowAsync();
                }
            });
        }

        public async Task Initialize()
        {
            await _auth.Initialize();

            var wtr = new WebTokenRequest(_auth.AccountProvider, string.Empty, _auth.ClientId);
            wtr.Properties.Add("resource", _auth.Resource);

            // Check if there's a record of the last account used with the app
            var userId = _auth.AppSettings.Values["userId"];
            if (userId != null)
            {
                // Get an account object for the user
                _auth.Account = await WebAuthenticationCoreManager.FindAccountAsync(_auth.AccountProvider, (string)userId);
                if (_auth.Account != null)
                {
                    // Ensure that the saved account works for getting the token we need
                    var wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr, _auth.Account);
                    if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
                    {
                        _auth.Account = wtrr.ResponseData[0].WebAccount;
                    }
                    else
                    {
                        // The saved account could not be used for getitng a token
                        var messageDialog = new MessageDialog("We tried to sign you in with the last account you used with this app, but it didn't work out. Please sign in as a different user.");
                        await messageDialog.ShowAsync();
                        // Make sure that the UX is ready for a new sign in
                        SignedOut();
                    }
                }
                else
                {
                    // The WebAccount object is no longer available. Let's attempt a sign in with the saved username
                    wtr.Properties.Add("LoginHint", _auth.AppSettings.Values["login_hint"].ToString());
                    var wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr);
                    if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
                    {
                        _auth.Account = wtrr.ResponseData[0].WebAccount;
                    }
                }
            }
            else
            {
                // There is no recorded user. Let's start a sign in flow without imposing a specific account.                             
                var wtrr = await WebAuthenticationCoreManager.RequestTokenAsync(wtr);
                if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
                {
                    _auth.Account = wtrr.ResponseData[0].WebAccount;
                }
            }

            if (_auth.Account != null) // we succeeded in obtaining a valid user
            {
                // save user ID in local storage
                SignedIn();
            }
            else
            {
                // nothing we tried worked. Ensure that the UX reflects that there is no user currently signed in.
                SignedOut();
                var messageDialog = new MessageDialog("We could not sign you in. Please try again.");
                await messageDialog.ShowAsync();
            }
        }

        private void SignedIn()
        {
            _auth.AppSettings.Values["userId"] = _auth.Account.Id;
            _auth.AppSettings.Values["login_hint"] = _auth.Account.UserName;
            Label = $"you are signed in as {_auth.Account.UserName}";
            Button = "Sign in as a different user";
        }

        // update the UX and the app settings to show that no user is signed in at the moment
        private void SignedOut()
        {
            _auth.AppSettings.Values["userId"] = null;
            _auth.AppSettings.Values["login_hint"] = null;
            Label = "You are not signed in. ";
            Button = "Sign in";
        }
    }
}
