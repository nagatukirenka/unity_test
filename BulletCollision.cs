using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILIntern.Contents.PvEFPS
{
    public class BulletCollision : MonoBehaviour
    {

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}