using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; 

public class InteractWithObject : MonoBehaviour
{
    public GameObject interactionText;  // Referencia al texto de la UI
    public float interactionDistance = 3f;  // Distancia en la que el jugador puede interactuar con el objeto
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
        interactionText.SetActive(false);  // Asegurar de que el texto está desactivado al inicio
    }

    void Update()
    {
        // Comprobar la distancia entre el jugador y el objeto
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        // Si el jugador está cerca y presiona "E"
        if (distanceToPlayer <= interactionDistance)
        {
            interactionText.SetActive(true);  // Mostrar el texto de interacción


        }
        else
        {
            interactionText.SetActive(false); ;  // Ocultar el texto si el jugador está lejos
        }
    }

   
}
