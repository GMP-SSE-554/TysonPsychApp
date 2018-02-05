using System;
using SSE554Project1;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestSlideshow
    {
        [TestMethod]
        public void SlidesAreGeneratedFromExcelDoc()
        {
            List<Slide> expectedSlides = new List<Slide>(new Slide[]
            {
                new Slide("Testing", 0, false),
                new Slide("1", 1, false),
                new Slide("2", 2, false),
                new Slide("3", 3, false)
            });

            Slideshow slideshow = new Slideshow(@"C:\Users\Tyson\documents\visual studio 2017\Projects\SSE554Project1\UnitTests\TestFile.xlsx");

            Assert.IsTrue(expectedSlides.SequenceEqual(slideshow.GetSlides()));
        }

        [TestMethod]
        public void SlideshowAdvancesThroughSlides()
        {
            Slide expectedSlide = new Slide("2", 2, false);

            Slideshow slideshow = new Slideshow(@"C:\Users\Tyson\documents\visual studio 2017\Projects\SSE554Project1\UnitTests\TestFile.xlsx");
            slideshow.AdvanceSlide();
            slideshow.AdvanceSlide();

            Assert.IsTrue(expectedSlide.Equals(slideshow.GetCurrentSlide()));
        }

        [TestMethod]
        public void SlideshowSavesAnswerUponAdvance()
        {
            Slideshow slideshow = new Slideshow(@"C:\Users\Tyson\documents\visual studio 2017\Projects\SSE554Project1\UnitTests\TestFile.xlsx");
            slideshow.SetAnswer("Testing1");
            slideshow.AdvanceSlide();
            slideshow.SetAnswer("Testing2");
            slideshow.AdvanceSlide();

            Assert.IsTrue(slideshow.GetSlides()[0].GetAnswer() == "Testing1");
            Assert.IsTrue(slideshow.GetSlides()[1].GetAnswer() == "Testing2");
        }

        [TestMethod]
        public void SlidesAutomaticallyAdvance()
        {
            Slide expectedSlide = new Slide("2", 2, false);

            Slideshow slideshow = new Slideshow(@"C:\Users\Tyson\documents\visual studio 2017\Projects\SSE554Project1\UnitTests\TestFile.xlsx");
            slideshow.AdvanceSlide();
            Thread.Sleep(1500);

            Assert.IsTrue(expectedSlide.Equals(slideshow.GetCurrentSlide()));
        }
    }
}
