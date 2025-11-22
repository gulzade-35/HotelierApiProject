using HotelProject.WebUI.Dtos.DashboardDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/muni.indev"),
                Headers =
                {
                     { "x-rapidapi-key", "0d0bd8c37emsh5649996b48d478ep1df91ejsn533cd4ee9612" },
                     { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1 = resultInstagramFollowersDto.followers;
                ViewBag.v2 = resultInstagramFollowersDto.following;
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-followers.p.rapidapi.com/murattyucedag/profile"),
                Headers =
    {
        { "x-rapidapi-key", "6a2b944cc8msh1ad7aa54c8c2966p16276bjsn72129b884ded" },
        { "x-rapidapi-host", "twitter-followers.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.v3 = resultTwitterFollowersDto.followersCount;
                ViewBag.v4 = resultTwitterFollowersDto.friendsCount;
            }

            return View();
        }

    }
}
