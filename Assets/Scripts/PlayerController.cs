using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private Transform playerPointer;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource attackAS;

    private bool moving;

    private bool canAttack;

     public float distance;
    public Transform raycastPos;
    public LayerMask raycastMask;
    public float offset;
    Rigidbody rb;

    public int vidaPlayer;
    public Slider vidaVisual;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //vida del personaje

        vidaVisual.GetComponent<Slider>().value = vidaPlayer;
        if (vidaPlayer <= 0)
        {
            Debug.Log("GameOver");
        }
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
        
        RaycastHit hit;
        if (Physics.Raycast(raycastPos.position, Vector3.down, out hit, distance, raycastMask))
        {
            transform.position = hit.point + Vector3.up * offset;

            if (rb.useGravity == true)
            {
                rb.useGravity = false;

                rb.linearVelocity = Vector3.zero;
            }
        }
        else 
        {
            if (rb.useGravity == false)
            {
                rb.useGravity = true;
            }
        }

        
    }

    public void AttackEneded()
    {
        canAttack = true;
    }

    

}
