using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSE554Project1
{
    class Slide
    {
        private string text { get; }

        private float timeLimit { get; }

        private bool userInteractionEnabled { get; }

        private bool userStartedTyping = false;

        private float timeUntilTypingBegan { get; }

        private float timeSpentTyping { get; }

        public Slide(String text, float timeLimit, bool userInteractionEnabled)
        {
            this.text = text;
            this.timeLimit = timeLimit;
            this.userInteractionEnabled = userInteractionEnabled;
        }

        public void Initiate()
        {

        }

        public void 
    }
}
