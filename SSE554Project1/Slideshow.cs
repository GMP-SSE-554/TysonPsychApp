using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace SSE554Project1
{
    public class Slideshow
    {
        ExcelReader excelReader;
        Timer timer = new Timer();
        string currentAnswer;
        int currentSlideIndex = 0;
        bool slideshowFinished = false;
        List<Slide> slideList = new List<Slide>();

        public Slideshow(string excelSheetAddress)
        {
            excelReader = new ExcelReader(excelSheetAddress);
            GenerateSlides();
            timer.Elapsed += AdvanceSlide;
            currentAnswer = "";
            UpdateTimers();
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
            slideList[currentSlideIndex].SubmitAnswer(currentAnswer);
            currentSlideIndex++;

            UpdateTimers();
        }

        public async void AdvanceSlide(Object source, ElapsedEventArgs e)
        {
            timer.Stop();
            AdvanceSlide();
        }

        public void ExportAnswers(string outputFilePath)
        {
            
        }

        public void SetAnswer(string answer)
        {
            currentAnswer = answer;
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

        private void UpdateTimers()
        {
            //Set up timer based on current slide's time limit
            if (slideList[currentSlideIndex].GetTimeLimit() > 0)
            {
                timer.Interval = slideList[currentSlideIndex].GetTimeLimit() * 1000;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

            slideList[currentSlideIndex].Initiate();
        }
    }
}
