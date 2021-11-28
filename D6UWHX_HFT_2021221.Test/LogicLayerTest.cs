using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;
using D6UWHX_HFT_2021221.Repository;
using Moq;
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
        public class TrackTest
        {
            TrackLogic TLogic;

            [SetUp]
            public void Init()
            {
                var MockT = new Mock<ITrackRepository>();

                var tracks = new List<Track>()

            {
               new Track { TrackId = 1, NamePlace = "Alex", Length = 5},
                new Track { TrackId = 2, NamePlace = "Sam", Length = 10 },
                new Track { TrackId = 3, NamePlace = "Clover", Length = 23 }
            }.AsQueryable();

                MockT.Setup((t) => t.GetAll()).Returns(tracks);
                for (int i = 0; i < 3; i++)
                {
                    MockT.Setup((t) => t.Read(i + 1)).Returns(tracks.ToList()[i]);
                }



                TLogic = new TrackLogic(MockT.Object);

            }

            [Test]
            public void TestGetTrack()
            {

                var result = TLogic.GetTrackById(3);

                Assert.That(result.NamePlace, Is.EqualTo("Clover"));

            }

            [Test]
            public void TrackNameStartWithTest()
            {
                var resultP = TLogic.GetTrackById(1).NamePlace;
                Assert.That(resultP.StartsWith("A"), Is.EqualTo("Alexa"));

            }

            [Test]
            public void GetTrackExceptionTest()
            {
                Assert.Throws<Exception>(() => TLogic.GetTrackById(7));
            }

            [Test]
            public void RemoveTrackExceptionTest()
            {
                Assert.Throws<Exception>(() => TLogic.DeleteTrackById(7));
            }

            [Test]
            public void UpdateTrackExceptionTest()
            {
                Track Ttest = new Track { NamePlace = "something", Length = 15 };
                Assert.Throws<Exception>(() => TLogic.ChangeTrack(Ttest));
            }

        }
    }
}
