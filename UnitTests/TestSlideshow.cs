using System;
using SSE554Project1;
using System.Collections.Generic;
using System.Linq;
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
    }
}
