using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Storage;

namespace BDSA2016.Lecture11.App.Model
{
    public interface IAuth
    {
        ApplicationDataContainer AppSettings { get; }
        string Authority { get; }
        string ClientId { get; }
        string Resource { get; }
        string Tenant { get; }
        string Url { get; }
        WebAccountProvider AccountProvider { get; }
        WebAccount Account { get; set; }

        Task Initialize();
    }
}