using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ILIntern.Contents.PvEFPS
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class EnemyController : MonoBehaviour {
        [SerializeField]
        private Transform[] target;
        private NavMeshAgent navAgent;
        private int number;

        void Start() {
            navAgent = GetComponent<NavMeshAgent>();
            number = Random.Range(0, target.Length);
            navAgent.destination = target[number].position;
        }
        void Update()
        {
            if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f)
            {
                NextTarget();
            }
        }
        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                navAgent.destination = target[0].position;
            }
        }
        public void NextTarget()
        {
            number = Random.Range(0, target.Length);
            navAgent.destination = target[number].position;
        }
    }
}
