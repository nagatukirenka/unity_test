using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class EnemyGun : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private GameObject bulletprefab;
        [SerializeField]
        private Transform Bullet;
        [SerializeField]
        private float bulletPower;
        private LineRenderer bulletLine;
        private float count;
        private float Speed;
        // Use this for initialization
        void Start()
        {
            bulletLine = GetComponentInChildren<LineRenderer>();
            count = 0;
        }
        // Update is called once per frame
        void Update()
        {
            transform.LookAt(target);
        }
        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                bulletLine.enabled = true;
                count += Time.deltaTime;
                if (count >= 5)
                {
                    var bullet = GameObject.Instantiate(bulletprefab, Bullet.position, Bullet.rotation) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletPower);
                    Destroy(bullet, 5f);
                    count = 0;
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            bulletLine.enabled = false;
        }
    }
}
