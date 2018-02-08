using System;
using System.Diagnostics;

namespace SSE554Project1
{
    public class Slide
    {
        private string Text { get; }
        private string Answer { get; set; }
        private float TimeLimit { get; }
        private bool UserInteractionEnabled { get; }
        private bool UserStartedTyping = false;
        public double TimeUntilTypingBegan { get; set; }
        public double TimeSpentTyping { get; set; }

        Stopwatch watch = new Stopwatch();

        public Slide(String text, float timeLimit, bool userInteractionEnabled)
        {
            this.Text = text;
            this.TimeLimit = timeLimit;
            this.UserInteractionEnabled = userInteractionEnabled;
        }

        public void Initiate()
        {
            watch.Start();
        }

        public void BeginTyping()
        {
            if (!UserStartedTyping)
            {
                watch.Stop();
                TimeUntilTypingBegan =  (double) watch.ElapsedMilliseconds / 1000;
                UserStartedTyping = true;
                watch.Reset();
                watch.Start();
            }
        }

        public void SubmitAnswer(string answer)
        {
            watch.Stop();
            Answer = answer;
            if (UserStartedTyping)
            {
                TimeSpentTyping = (double)watch.ElapsedMilliseconds / 1000;
            } else {
                TimeUntilTypingBegan = (double)watch.ElapsedMilliseconds / 1000;
            }
        }

        public string GetAnswer()
        {
            return Answer;
        }

        public string GetText()
        {
            return Text;
        }

        public float GetTimeLimit()
        {
            return TimeLimit;
        }

        public override bool Equals(object obj)
        {
            Slide otherSlide = (Slide)obj;

            if (otherSlide.Text.Equals(Text) && otherSlide.GetTimeLimit() == TimeLimit && otherSlide.UserInteractionEnabled == UserInteractionEnabled)
            {
                return true;
            } else {
                return false;
            }
        }

        public bool IsEnabled()
        {
            return UserInteractionEnabled;
        }
    }
}
