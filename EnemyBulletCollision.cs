using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class EnemyBulletCollision : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "field" || collision.gameObject.tag == "enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}
