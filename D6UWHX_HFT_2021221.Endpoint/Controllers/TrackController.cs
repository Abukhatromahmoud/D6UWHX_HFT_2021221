using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;

namespace D6UWHX_HFT_2021221.Controllers
{
	public class TrackController : Controller
	{
		ITrackLogic t1;
		public TrackController(ITrackLogic t1)
		{
			this.t1 = t1;

		}
        [HttpGet]
        public IEnumerable<Track> Get()
        {
            return t1.GetAllTracks();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Track Get(int TrackId)
        {
            return t1.GetTrackById(TrackId);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Track value)
        {
            t1.CreateNewTrack(value);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Track value)
        {
            t1.ChangeTrack(value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            t1.DeleteTrackById(id);
        }
    }
}
