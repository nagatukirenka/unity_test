using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILIntern.Contents.PvEFPS
{
    public class UNY : MonoBehaviour
    {
        private Text UNYText;
        public static int count;
        void Start()
        {
            UNYText = GetComponent<Text>();
        }
        void Update()
        {
            UNYText.text = "UNY" + ":" + count.ToString("0");
        }
        public void UNYCount()
        {
            count++;
        }
    }
}
