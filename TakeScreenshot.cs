using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using UnityEngine.SceneManagement;

namespace ILIntern.Contents {

    public class TakeScreenshot : MonoBehaviour
    {

        private string SAVE_DIRECTORY;

        // Use this for initialization
        void Start()
        {
            Scene scene = SceneManager.GetActiveScene();
            SAVE_DIRECTORY = "C:\\Users\\" + Environment.UserName + "\\Pictures\\" + scene.name + "\\";
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.F12) == true)
            {
                StartCoroutine("CaptureScreenShot");
            }


        }

        IEnumerator CaptureScreenShot()
        {

            yield return new WaitForEndOfFrame();

            var texture = new Texture2D(Screen.width, Screen.height);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            SaveScreenShot(texture);


        }

        private void SaveScreenShot(Texture2D captureData)
        {

            //ファイル名の生成（年月日時間秒.png）
            DateTime dt = DateTime.Now;
            StringBuilder defaultFileName = new StringBuilder();
            defaultFileName.Append(dt.Year.ToString());
            defaultFileName.Append(dt.Month.ToString());
            defaultFileName.Append(dt.Day.ToString());
            defaultFileName.Append(dt.Hour.ToString());
            defaultFileName.Append(dt.Second.ToString());
            defaultFileName.Append(".png");

            //テクスチャデータの変換

            byte[] pngData = captureData.EncodeToPNG();

            string filePath = SAVE_DIRECTORY + defaultFileName;


            //ディレクトリの存在を確認し、存在しなければフォルダを作成
            if (Directory.Exists(SAVE_DIRECTORY) == false)
            {
                Directory.CreateDirectory(SAVE_DIRECTORY);
            }

            //スクショの書き込み
            File.WriteAllBytes(filePath, pngData);
        }

    }

}
