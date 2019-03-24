using System.Threading.Tasks;
using WebAdvert.Api.Models;

namespace WebAdvert.Api.Services
{
    public interface IAdvertStorageService
    {
        Task<string> Add(AdvertModel advertModel);
        Task<bool> Confirm(ConfirmAdvertModel confirmAdvertModel);
    }
}
