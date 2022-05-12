using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Data
{
    // Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\Database1.mdf";Integrated Security = True MultipleActiveResultSets=True

    [Route("[controller]")]
    [ApiController]
    public   class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;
        IHubContext<SignalRHub> hub;

        public ArtistController(IArtistLogic artistLogic, IHubContext<SignalRHub> hub)
        {
            this.artistLogic = artistLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return artistLogic.GetArtists();
        }

        [HttpGet("{Artistid}")]
        public Artist Get(int id)
        {
            return artistLogic.GetArtist(id);
        }

      

        [HttpPut]
        public void Put([FromBody] Artist artist)
        {
            artistLogic.UpdateArtist(artist);
            this.hub.Clients.All.SendAsync("ArtistUpdated", artist);
        }

        [HttpDelete("{Artistid}")]
        public void Delete(int id)
        {
            var artistToDelete = this.artistLogic.GetArtist(id);
            artistLogic.DeleteArtist(id);
            this.hub.Clients.All.SendAsync("artistDeleted", artistToDelete);
        }

    }
}
