using System;

namespace RoguelikeCards
{
    public class AnimationQueue
    {
        private int _animationRunning;
        public event Action QueueEmptied;

        public bool HasActiveAnimations => _animationRunning > 0;


        public void Enqueue()
        {
            _animationRunning++;
        }

        public void Dequeue()
        {
            if (_animationRunning == 0)
            {
                throw new ArgumentException();
            }

            _animationRunning--;
            if (_animationRunning == 0)
            {
                QueueEmptied?.Invoke();
            }
        }
    }
}