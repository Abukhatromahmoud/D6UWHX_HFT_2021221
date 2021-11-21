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
                Track s = new Track() { NamePlace = "ballads", TrackId = 1 };
                Assert.AreEqual("ballads", s.NamePlace);
            }

            [Test]
            public void ArtistNameTest()
            {
                Artist s = new Artist() { Name = "David", Age = 40 };
                Assert.AreEqual("David", s.Name);
            }

            [Test]
            public void TrackFirstCharacterTest()
            {
                Track s = new Track() { NamePlace = "ballads" };
                Assert.That(s.NamePlace.StartsWith('b'), Is.EqualTo('L'));
            }

            [Test]
            public void AlbumObjectThrowsTest()
            {
                Album s = new Album();
                Assert.That(() => s.CreateInstanceFromString("#SOOLKING%2012"),
                    Throws.TypeOf<FormatException>());
            }

            [Test]
            public void BrandObjectNotThrowsTest()
            {
                Album s = new Album();
                Assert.That(() => s.CreateInstanceFromString("SOOLKING%2012"),
                    !Throws.TypeOf<FormatException>());
            }
        }
    }
}
