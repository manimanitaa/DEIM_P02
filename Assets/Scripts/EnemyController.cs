using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;

    void Update()
    {
        agent.SetDestination(player.position);
        if (Input.GetKey(KeyCode.Y))
        {
            agent.speed = 3;
        }
        else
        {
            agent.speed = 1;
            //agent.isStopped = true;
        }

        if (agent.isOnOffMeshLink)
        {
            if (agent.velocity.y > 0)
            {
                Debug.Log("SUBIENDO");
            }
            else
            {
                Debug.Log("BAJANDO");
            }
         } 
        
    }
}
