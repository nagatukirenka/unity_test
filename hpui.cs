using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILIntern.Contents.PvEFPS
{
    public class hpui : MonoBehaviour
    {

        public Slider hpslider;

        void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        public void UpdateHP(int hp)
        {
            hpslider.value = hp;
        }
    }
}
