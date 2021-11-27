using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Test
{
    
    public class LogicLayerTest
    {
        [TestFixture]
        public class Tests
        {
            //private AlbumLogic AlbumLogic { get; set; }
            //public ArtistLogic ArtistLogic { get; set; }
            //public TrackLogic TrackLogic { get; set; }
            [Test]
            public void TrackNameTest()
            {
                Track t = new Track() { NamePlace = "ballads", TrackId = 1 };
                Assert.AreEqual("ballads", t.NamePlace);
            }
            [Test]
            public void TrackFirstCharacterTest()
            {
                Track t = new Track() { NamePlace = "ballads" };
                Assert.That(t.NamePlace.StartsWith('b'), Is.EqualTo('L'));
            }
            [Test]
            public void TrackAlbumTest()
            {
                Track t = new Track() { NamePlace="ballads", Length=15};
                Assert.That(t.Albums.Count(), Is.EqualTo(12));
            }

            [Test]
            public void TrackObjectThrowsTest()
            {
                Track t = new Track();
                Assert.That(() => t.CreateInstanceFromString("#EMINEM%2012"),
                    Throws.TypeOf<FormatException>());
            }

            [Test]
            public void TrackObjectNotThrowsTest()
            {
                Track t = new Track();
                Assert.That(() => t.CreateInstanceFromString("EMINEM%2012"),
                    !Throws.TypeOf<FormatException>());
            }
        }
    }
}
