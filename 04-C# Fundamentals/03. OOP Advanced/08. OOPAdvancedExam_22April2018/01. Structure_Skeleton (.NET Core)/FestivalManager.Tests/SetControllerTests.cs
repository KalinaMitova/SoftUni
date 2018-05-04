// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private Stage stage;
        private SetController setController;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }
        
		[Test]
	    public void SetIsSuccessfulTest()
        {
            ISet set = new Short("Set1");
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            IPerformer performer = new Performer("Gosho", 15);
            IInstrument instrument = new Drums();

            performer.AddInstrument(instrument);

            stage.AddSet(set);
            stage.AddSong(song);

            set.AddSong(song);
            set.AddPerformer(performer);

            string result = setController.PerformSets();
            string expected = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SetDidNotPerformTest()
        {
            stage.AddSet(new Short("Set1"));
            string result = setController.PerformSets();
            string expected = "1. Set1:\r\n-- Did not perform";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SetOrderTest()
        {
            ISet set1 = new Short("Set1");
            ISet set2 = new Long("Set2");
            ISet set3 = new Medium("Set3");

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddSet(set3);

            ISong song1 = new Song("Song1", new TimeSpan(0, 1, 2));
            ISong song2 = new Song("Song2", new TimeSpan(0, 2, 5));
            ISong song3 = new Song("Song3", new TimeSpan(0, 3, 6));
            ISong song4 = new Song("Song4", new TimeSpan(0, 4, 3));
            ISong song5 = new Song("Song5", new TimeSpan(0, 3, 5));
            ISong song6 = new Song("Song6", new TimeSpan(0, 2, 1));

            set1.AddSong(song4);
            set1.AddSong(song5);
            set2.AddSong(song1);
            set2.AddSong(song2);
            set3.AddSong(song3);
            set3.AddSong(song6);

            IPerformer performer = new Performer("Gosho", 23);
            IPerformer performer2 = new Performer("Pesho", 28);
            IPerformer performer3 = new Performer("Ivan", 26);
            IPerformer performer4 = new Performer("Traqn", 28);
            IPerformer performer5 = new Performer("Mitko", 12);
            IPerformer performer6 = new Performer("Misho", 16);


            IInstrument drums = new Drums();
            IInstrument guitar = new Guitar();
            IInstrument mic = new Microphone();

            performer.AddInstrument(drums);
            performer.AddInstrument(guitar);
            performer.AddInstrument(mic);

            performer2.AddInstrument(drums);

            performer3.AddInstrument(guitar);
            performer3.AddInstrument(mic);

            performer4.AddInstrument(guitar);

            performer5.AddInstrument(drums);

            performer6.AddInstrument(mic);

            set3.AddPerformer(performer);
            set3.AddPerformer(performer2);
            set3.AddPerformer(performer3);
            set3.AddPerformer(performer4);

            set2.AddPerformer(performer);
            set2.AddPerformer(performer5);
            

            string result = setController.PerformSets();
            string expected = "1. Set1:\r\n-- Did not perform\r\n2. Set3:\r\n-- 1. Song3 (03:06)\r\n-- 2. Song6 (02:01)\r\n-- Set Successful\r\n3. Set2:\r\n-- 1. Song1 (01:02)\r\n-- 2. Song2 (02:05)\r\n-- Set Successful";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void InstrumentWearDown()
        {
            ISet set1 = new Short("Set1");
            stage.AddSet(set1);
            ISong song1 = new Song("Song1", new TimeSpan(0, 1, 2));
            set1.AddSong(song1);
            IPerformer performer = new Performer("Gosho", 23);
            performer.AddInstrument(new Microphone());
            set1.AddPerformer(performer);

            string result = setController.PerformSets();
            string result2 = setController.PerformSets();
            string result3 = setController.PerformSets();
            string expected = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            Assert.That(result, Is.EqualTo(expected));
            string expected2 = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";
            Assert.That(result2, Is.EqualTo(expected2));
            string expected3 = "1. Set1:\r\n-- Did not perform";
            Assert.That(result3, Is.EqualTo(expected3));

        }
    }
}