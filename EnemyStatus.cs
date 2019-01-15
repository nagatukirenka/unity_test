using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField]
        private GameObject Explode;
        [SerializeField]
        private int maxhp;
        private int hp;
        private hpui hpstatus;
        private score score;
        [SerializeField]
        private GameObject UNYprefab;
        public static int Flag;
        void Start()
        {
            hp = maxhp;
            hpstatus = GetComponentInChildren<hpui>();
            score = GameObject.Find("score").GetComponent<score>();
            Flag = 0;
        }
        void Update()
        {
            if (hp <= 0)
            {
                Instantiate(Explode, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (Flag == 1)
            {
                Destroy(gameObject);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                hp = 0;
            }
            if (collision.gameObject.tag == "bullet")
            {
                hp -= 1;
                hpstatus.UpdateHP(hp);
                if (hp <= 0)
                {
                    score.ScoreCount();
                    Vector3 Ypos = new Vector3(0f, 1.5f, 0f);
                    var uny = GameObject.Instantiate(UNYprefab, transform.position + Ypos, Quaternion.identity);
                }
            }
        }
    }
}
