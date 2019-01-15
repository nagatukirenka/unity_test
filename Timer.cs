using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILIntern.Contents.PvEFPS
{
    public class Timer : MonoBehaviour
    {
        public static int minute;
        public static float newsecond;
        private float oldsecond;
        private Text timerText;
        // Use this for initialization
        void Start()
        {
            minute = 0;
            newsecond = 0f;
            oldsecond = 0f;
            timerText = GetComponent<Text>();
        }
        void Update()
        {
            newsecond += Time.deltaTime;
            if (newsecond >= 60)
            {
                minute++;
                newsecond = newsecond - 60;
            }
            if ((int)newsecond != (int)oldsecond)
            {
                timerText.text = minute.ToString("0") + ":" + ((int)newsecond).ToString("00");
            }
            oldsecond = newsecond;
        }
    }
}
