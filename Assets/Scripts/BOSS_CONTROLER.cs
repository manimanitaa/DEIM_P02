using UnityEngine;
using UnityEngine.AI;

public class BOSS_CONTROLER : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public float speed;

    public NavMeshAgent agent;
    public float distancia_ataque;
    public float radio_vision;

    Vector3 RandomTargetLoc;
    Vector2 RadiusTargetLoc;

    public int damage;
    public GameObject Player;

    public Collider collider;

    public float distancia_caminar = 10;
    private void Start()
    {
        ani= GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > radio_vision )
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >=2)
            {
                rutina = Random.Range(0, 2);
                SetRandomDestination();
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    agent.enabled = false;
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:


                    agent.enabled = true;

                    agent.SetDestination(RandomTargetLoc);
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    //transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agent.enabled = true;
            agent.SetDestination(target.transform.position);

            if(Vector3.Distance(transform.position,target.transform.position)> distancia_ataque && atacando)
            {
              ani.SetBool("walk", true);
              ani.SetBool("run", false);
            }
            else
            {
                if (!atacando)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }
            
        }

        if (atacando)
        {
            agent.enabled = false;
        }

    }

    public void Final_Ani()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > distancia_ataque + 0.2f)
        {
            ani.SetBool("attack", false);
        }
        atacando=false;
    }

    private void Update()
    {
        Comportamiento_Enemigo();
    }

    void SetRandomDestination()
    {
        RadiusTargetLoc = Random.insideUnitCircle.normalized * distancia_caminar;

        RandomTargetLoc = transform.position + new Vector3(RadiusTargetLoc.x, 0, RadiusTargetLoc.y);
    }

   
}
