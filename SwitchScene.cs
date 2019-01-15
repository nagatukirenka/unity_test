using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ILIntern.Contents.PvEFPS
{
    public class SwitchScene : MonoBehaviour
    {
        private string CurrentScene;

        void Start()
        {
            CurrentScene = SceneManager.GetActiveScene().name;
        }
        public void GameStart()
        {
            SceneManager.LoadScene("ShootingScene");
        }
        public void GameExit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        public void GameResult()
        {
            SceneManager.LoadScene("Result");
        }
        public void NextScene()
        {
            if (CurrentScene == "Stage1")
            {
                SceneManager.LoadScene("Stage2");
            }
            else if (CurrentScene == "Stage2")
            {
                SceneManager.LoadScene("Stage3");
            }
            else if (CurrentScene == "Stage3")
            {
                SceneManager.LoadScene("Result");
            }
        }
    }
}
