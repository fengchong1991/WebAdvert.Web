using System.Threading.Tasks;
using WebAdvert.Web.Models.Advert.Requests;
using WebAdvert.Web.Models.Advert.Responses;

namespace WebAdvert.Web.ServiceClient
{
    public interface IAdvertApiClient
    {
        Task<AdvertResponse> Create(CreateAdvertModel model);
    }
}
