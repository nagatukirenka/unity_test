using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class ItemStatus : MonoBehaviour
    {
        private UNY UNYText;
        private float TimeCount;

        void Start()
        {
            UNYText = GameObject.Find("UNY").GetComponent<UNY>();
        }
        void Updata()
        {
            TimeCount += Time.deltaTime;
            if (TimeCount >= 10)
            {
                Destroy(gameObject);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                UNYText.UNYCount();
                Destroy(gameObject);
            }
        }
    }
}
