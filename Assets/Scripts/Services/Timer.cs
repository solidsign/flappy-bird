using UnityEngine;

namespace Services
{
    public class Timer
    {
        private float levelLoadTime;
        public Timer()
        {
            levelLoadTime = Time.realtimeSinceStartup;
        }

        public float TimeSinceLevelStart => Time.realtimeSinceStartup - levelLoadTime;

        public void Reset()
        {
            levelLoadTime = Time.realtimeSinceStartup;
        }
    }
}