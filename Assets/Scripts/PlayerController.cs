using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private Transform playerPointer;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource attackAS;

    private bool moving;

    private bool canAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento del personaje

        moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            moving = true;
            transform.Translate(Vector3.left* speed * Time.deltaTime, Space.World);
        }

        //Ataque del personaje
        if (canAttack &&(Input.GetMouseButtonDown(0)))
        {
            animator.SetTrigger("Attack");  // el jugador ataca
            attackAS.Play();   // reproduce el sonido
            canAttack = false;  // solo puede atacar una vez hasta que no termione la acción
        }
        
        //Rotacion del personaje hasta el puntero
        transform.LookAt(playerPointer.position);
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.x = 0;
        transform.rotation = Quaternion.Euler(rotation);

        //Animación del personaje
        animator.SetBool("moving", moving);
        
    }

    public void AttackEneded()
    {
        canAttack = true;
    }

}
