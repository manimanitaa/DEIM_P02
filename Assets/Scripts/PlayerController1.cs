using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{

    [SerializeField] private float speed= 10;

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
        //Nuevo movimiento del personaje
        float horInput = Input.GetAxisRaw("Horizontal") * speed;
        float verInput = Input.GetAxisRaw("Vertical") * speed;

        rb.linearVelocity= new Vector3 (horInput,0,verInput);

        transform.forward= new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z);

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
        

        //Suve las escaleras
        //RaycastHit hit;
        //if (Physics.Raycast(raycastPos.position, Vector3.down, out hit, distance, raycastMask))
        //{
        //    transform.position = hit.point + Vector3.up * offset;

        //    if (rb.useGravity == true)
        //    {
        //        rb.useGravity = false;

        //        rb.linearVelocity = Vector3.zero;
        //    }
        //}
        //else 
        //{
        //    if (rb.useGravity == false)
        //    {
        //        rb.useGravity = true;
        //    }
        //}

        //if (!Input.anyKey)
        //{
        //    rb.angularVelocity = Vector3.zero;
        //    rb.linearVelocity = Vector3.zero;
        //}

        
    }

    public void AttackEneded()
    {
        canAttack = true;
    }

    

}
