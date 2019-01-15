using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ILIntern.Contents.PvEFPS
{
    public class Generation : MonoBehaviour
    {
        private Renderer render;
        [SerializeField]
        private GameObject[] enemy;
        [SerializeField]
        private float nextgenerationTime;
        private float wait;
        private int number;
        void Start()
        {
            render = GetComponent<Renderer>();
            wait = 0f;
        }
        void Update()
        {
            wait += Time.deltaTime;
            if (render.isVisible)
            {
                return;
            }
            if (nextgenerationTime < wait)
            {
                GenerationEnemy();
            }
        }
        void GenerationEnemy()
        {
            number = Random.Range(0, enemy.Length);
            if (number == 2)
            {
                Vector3 Ypos = new Vector3(0, 5, 0);
                GameObject.Instantiate(enemy[number], transform.position + Ypos, transform.rotation);
                wait = 0f;
            }
            else
            {
                GameObject.Instantiate(enemy[number], transform.position, transform.rotation);
                wait = 0f;
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                wait = 0f;
            }
        }
    }
}
