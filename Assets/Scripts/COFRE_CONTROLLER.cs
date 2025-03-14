using TMPro;
using UnityEngine;
using UnityEngine.UI;  // Necesario para manejar el UI

public class COFRE_CONTROLLER : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string parameterName = "AbrirCofre";

    public GameObject moneda;
    public GameObject canvasUI;  // Referencia al Canvas que contiene el Text
    public TextMeshProUGUI textUI;  // Referencia al componente Text dentro del Canvas

    public float coin;

    public bool contando;

    private void Start()
    {
        // Asegurarnos de que el Canvas esté desactivado al inicio.
        if (canvasUI != null)
        {
            canvasUI.SetActive(false);  // Esto es crucial
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Verificamos si la tecla F es presionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            bool isCofreAbierto = true;
            animator.SetBool(parameterName, isCofreAbierto);

            contando = true;
        }
    }

    private void Update()
    {
        if (contando)
        {
            coin = coin + Time.deltaTime;
        }

        // Mostrar el Canvas después de 2 segundos
        if (coin > 0f && !canvasUI.activeSelf)  // Activamos el Canvas después de 2 segundos
        {
            print("la fucking moneda");
            if (canvasUI != null)
            {
                canvasUI.SetActive(true);  // Activa el Canvas
                textUI.text = "YOU GOT COINS!!!";  // Cambia el texto
            }
        }

        // Después de 4 segundos, eliminar la moneda y desactivar el Canvas
        if (coin > 2f)
        {
            // Eliminar la moneda
            Destroy(moneda);

            // Desactivar el Canvas
            if (canvasUI != null)
            {
                canvasUI.SetActive(false);
            }

            contando = false;
        }
    }
}
