using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyMovement : MonoBehaviour
{
    //[SerializedField]
    public Transform dest;

    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.LogError("NavMesh agent component not attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dest != null)
        {
            Vector3 target = dest.transform.position;
            navMeshAgent.SetDestination(target);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Enemy hit the player");
            dest = this.GetComponent<Transform>();
        }
    }
}
