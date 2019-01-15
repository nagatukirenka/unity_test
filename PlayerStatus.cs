using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace ILIntern.Contents.PvEFPS
{
    public class PlayerStatus : MonoBehaviour
    {
        public GameObject Player;
        public GameObject Camera;
        public float speed;
        private Transform PlayerTransform;
        private Transform CameraTransform;
        private Rigidbody PlayerRigid;
        public float Upspeed;
        private float ii;
        [SerializeField]
        private int maxhp;
        private int hp;
        private hpui hpstatus;
        private GameStatus gamestatus;
        private float StopCount;
        private PostProcessingBehaviour DamageEffect;
        private AudioSource GetCoin;

        // Use this for initialization
        void Start()
        {
            PlayerRigid = Player.GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerTransform = GetComponent<Transform>();
            CameraTransform = Camera.GetComponent<Transform>();
            hp = maxhp;
            hpstatus = GetComponentInChildren<hpui>();
            gamestatus = GetComponent<GameStatus>();
            GetCoin = GetComponent<AudioSource>();
            DamageEffect = GetComponentInChildren<PostProcessingBehaviour>();
        }
        // Update is called once per frame
        void Update()
        {
            StopCount += Time.deltaTime;
            float X_Rotation = Input.GetAxis("Mouse X");
            float Y_Rotation = Input.GetAxis("Mouse Y");
            PlayerTransform.transform.Rotate(0, X_Rotation, 0);
            ii = Camera.transform.localEulerAngles.x;
            if (ii > 290 && ii < 360 || ii > 0 && 79 > ii)
            {
                CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
            }
            else
            {
                if (ii > 280)
                {
                    if (Input.GetAxis("Mouse Y") < 0)
                    {
                        CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
                    }
                }
                else
                {
                    if (Input.GetAxis("Mouse Y") > 0)
                    {
                        CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
                    }
                }
            }
            float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
            Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
            Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));
            Vector3 position = PlayerTransform.position;
            if (Input.GetKey(KeyCode.W))
            {
                PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
            }
            if (hp <= 0)
            {
                gamestatus.GameOver();
                Time.timeScale = 0f;
            }
            if (position.y < -10)
            {
                PlayerTransform.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                gamestatus.GameOver();
                Time.timeScale = 0f;
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemybullet")
            {
                hp -= 1;
                hpstatus.UpdateHP(hp);
                DamageEffect.enabled = true;
                StartCoroutine(DisableEffect());
            }
            if (collision.gameObject.tag == "item")
            {
                GetCoin.Play();
            }
        }
        IEnumerator DisableEffect()
        {
            yield return new WaitForSeconds(0.3f);
            DamageEffect.enabled = false;
        }
        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRigid.AddForce(transform.up * Upspeed);
            }
        }
    }
}
