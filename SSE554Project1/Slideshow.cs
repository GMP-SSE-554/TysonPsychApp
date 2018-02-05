using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE554Project1
{
    public class Slideshow
    {
        ExcelReader excelReader;
        int currentSlideIndex = 0;
        bool slideshowFinished = false;
        List<Slide> slideList = new List<Slide>();

        public Slideshow(string excelSheetAddress)
        {
            excelReader = new ExcelReader(excelSheetAddress);
            GenerateSlides();
        }

        private void GenerateSlides()
        {
            List<String> slideTextList;
            List<int> slideTimeList;
            List<bool> userInteractionList;

            slideTextList = excelReader.ReadColumn(2);
            slideTimeList = excelReader.ReadColumn(3).Select(int.Parse).ToList();
            userInteractionList = excelReader.ReadColumn(4).Select(bool.Parse).ToList();

            //Generate slides based on data read from excel sheet
            for (int i = 0; i < slideTextList.Count; i++)
            {
                slideList.Add(new Slide(slideTextList[i], slideTimeList[i], userInteractionList[i]));
            }

            excelReader.Close();
        }

        public void BeginSlideshow()
        {

        }

        public void AdvanceSlide()
        {
            currentSlideIndex++;
        }

        public void ExportAnswers(string outputFilePath)
        {

        }

        public List<Slide> GetSlides()
        {
            return slideList;
        }

        public Slide GetCurrentSlide()
        {
            return slideList[currentSlideIndex];
        }

        public bool SlideshowFinished()
        {
            return slideshowFinished;
        }
    }
}
