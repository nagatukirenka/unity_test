using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ILIntern.Contents.PvEFPS
{
    public class score : MonoBehaviour
    {
        private Text countText;
        private GameStatus gamestatus;
        public static int count;
        private string CurrentScene;
        void Start()
        {
            countText = GetComponent<Text>();
            gamestatus = GameObject.Find("Player").GetComponent<GameStatus>();
            CurrentScene = SceneManager.GetActiveScene().name;
        }
        void Update()
        {
            countText.text = "Score" + ":" + count.ToString("0");
            if (CurrentScene == "Stage1")
            {
                if (count >= 20)
                {
                    gamestatus.Clear();
                    EnemyStatus.Flag = 1;
                }
            }
            else if (CurrentScene == "Stage2")
            {
                if (count >= 50)
                {
                    gamestatus.Clear();
                    EnemyStatus.Flag = 1;
                }
            }
            else if (CurrentScene == "Stage3")
            {
                if (count >= 80)
                {
                    gamestatus.Clear();
                    EnemyStatus.Flag = 1;
                }
            }
        }
        public void ScoreCount()
        {
            count++;
        }
        public void GamaExit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        public void GameResult()
        {
            SceneManager.LoadScene("Result");
        }
        public void LoadStage1()
        {
            SceneManager.LoadScene("Stage1");
        }
        public void LoadStage2()
        {
            SceneManager.LoadScene("Stage2");
        }
        public void LoadStage3()
        {
            SceneManager.LoadScene("Stage3");
        }
    }
}
