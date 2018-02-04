using SSE554Project1;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestSlide
    {
        [TestMethod]
        public void SlideRecordsTimeUntilTypingAfterInitating()
        {
            Stopwatch watch = new Stopwatch();
            Slide slide = new Slide("Test", 0, false);

            slide.Initiate();
            watch.Start();
            Thread.Sleep(2000);
            slide.BeginTyping();
            watch.Stop();
            double expectedTime = watch.ElapsedMilliseconds / 1000;

            Assert.AreEqual(expectedTime, slide.TimeUntilTypingBegan, .001);
        }

        [TestMethod]
        public void SlideRecordsTimeSpentTyping()
        {
            Stopwatch watch = new Stopwatch();
            Slide slide = new Slide("Test", 0, false);

            slide.Initiate();
            slide.BeginTyping();
            watch.Start();
            Thread.Sleep(2000);
            slide.SubmitAnswer("");
            watch.Stop();
            double expectedTime = watch.ElapsedMilliseconds / 1000;

            Assert.AreEqual(expectedTime, slide.TimeSpentTyping, .001);
        }
    }
}