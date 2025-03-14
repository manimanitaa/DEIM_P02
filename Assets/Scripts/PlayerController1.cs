using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
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

    [SerializeField] Transform cam;

    float verInput;
    float horInput;

    public GameObject gameover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moving = false;
        
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
           gameObject.SetActive(true);
        }
        //Nuevo movimiento del personaje

        PlayerMovement();

        //Vector3 CamForward = cam.forward;
        //Vector3 camRight = cam.right;

        //CamForward.y = 0;
        //camRight.y = 0;


        //float horInput = Input.GetAxisRaw("Horizontal") * speed;
        //float verInput = Input.GetAxisRaw("Vertical") * speed;

        //Vector3 forwardRelative = verInput * CamForward;
        //Vector3 rightRelative = horInput * camRight;

        //Vector3 moverDir = forwardRelative + rightRelative;

        //rb.linearVelocity= new Vector3 (horInput,0,verInput);

        //transform.forward= new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z);

        //if(moverDir.magnitude > 0)
        //{
        //    Vector3 direction = new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z).normalized;
        //    if (direction.magnitude > 0)
        //    {
        //        transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(direction).eulerAngles.y, 0);
        //    }
        //}

        //Ataque del personaje
        if (canAttack &&(Input.GetMouseButtonDown(0)))
        {
            animator.SetTrigger("Attack");  // el jugador ataca
            attackAS.Play();   // reproduce el sonido
            canAttack = false;  // solo puede atacar una vez hasta que no termione la acción
        }
        
        //Rotacion del personaje hasta el puntero
        //transform.LookAt(playerPointer.position);
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

    public void AttackEnded()
    {
        print("canattack");
        canAttack = true;
    }

    private void PlayerMovement()
    {

        horInput = Input.GetAxisRaw("Horizontal")*speed;
        verInput= Input.GetAxisRaw("Vertical") * speed;

        if (horInput != 0 || verInput != 0)
        {
            moving = true;
            animator.SetBool("moving", moving);
        }
        else
        {
            moving = false;
            animator.SetBool("moving", moving);
        }

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        rb.linearVelocity = new Vector3(moveDir.x, rb.linearVelocity.y, moveDir.z)*Time.deltaTime;

        if (moveDir.magnitude > 0)
        {
            Vector3 direction = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).normalized;
            if (direction.magnitude > 0)
            {
                transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(direction).eulerAngles.y, 0);
            }
        }
    }
}
