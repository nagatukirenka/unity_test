using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILIntern.Contents.PvEFPS
{
    public class GameStatus : MonoBehaviour
    {
        public Text gameoverText;
        public GameObject gameover;
        public Text clearText;
        public GameObject clear;
        public GameObject switchresult;
        public GameObject switchnext;

        void Start()
        {
            gameoverText = GetComponent<Text>();
            clearText = GetComponent<Text>();
        }
        void Update()
        {

        }
        public void GameOver()
        {
            gameover.SetActive(true);
            switchresult.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void Clear()
        {
            clear.SetActive(true);
            switchresult.SetActive(true);
            switchnext.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
