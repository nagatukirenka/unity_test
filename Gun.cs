using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private int Capacity;
        [SerializeField]
        private GameObject bulletprefab;
        [SerializeField]
        private Transform Bullet;
        [SerializeField]
        private float bulletPower;
        private AudioSource ShotSE;
        private Light ShotLight;
        private LineRenderer bulletLine;
        private float Interval = 0.1f;
        private float timer;
        private float Count;

        void Start()
        {
            ShotSE = GetComponent<AudioSource>();
            ShotLight = GetComponent<Light>();
            bulletLine = GetComponent<LineRenderer>();
            Count = Capacity;
        }
        void Update()
        {
            timer += Time.deltaTime;
            if (Input.GetButton("Fire1") && timer >= Interval)
            {
                if (Count > 0)
                {
                    Shot();
                    guneffect();
                    timer = 0;
                    Count--;
                }
            }
            if (Input.GetButton("Fire2"))
            {
                Count = Capacity;
            }
            if (Input.GetKey(KeyCode.E))
            {
                SetTrueLine();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                SetFalseLine();
            }
        }
        void Shot()
        {
            var bullet = GameObject.Instantiate(bulletprefab, Bullet.position, Bullet.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletPower);
            Destroy(bullet, 2f);
        }
        private void guneffect()
        {
            ShotSE.Stop();
            ShotSE.Play();
            ShotLight.enabled = false;
            ShotLight.enabled = true;
            StartCoroutine(DisableLight());
        }
        IEnumerator DisableLight()
        {
            yield return new WaitForSeconds(0.2f);
            ShotLight.enabled = false;
        }
        private void SetTrueLine()
        {
            bulletLine.enabled = true;
        }
        private void SetFalseLine()
        {
            bulletLine.enabled = false;
        }
        IEnumerator Rapidsleep()
        {
            yield return new WaitForSeconds(0.5f);
        }
    }
}
