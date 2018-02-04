﻿using System;
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
            watch.Stop();
            TimeUntilTypingBegan = watch.ElapsedMilliseconds / 1000;
            UserStartedTyping = true;
            watch.Reset();
            watch.Start();
        }

        public void SubmitAnswer(string answer)
        {
            watch.Stop();
            Answer = answer;
            TimeSpentTyping = watch.ElapsedMilliseconds / 1000;
        }

        public string GetAnswer()
        {
            return Answer;
        }
    }
}