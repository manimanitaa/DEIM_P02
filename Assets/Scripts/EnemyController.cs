using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Video;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;

    public int vidaPlayer;
    public Slider vidaVisual;

    void Update()
    {
        vidaVisual.GetComponent<Slider>().value = vidaPlayer;
        if (vidaPlayer <= 0)
        {
            Debug.Log("BossMuerto");
        }

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
