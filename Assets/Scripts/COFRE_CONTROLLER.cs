using UnityEngine;

public class COFRE_CONTROLLER : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string parameterName = "AbrirCofre"; 
    
    private void OnTriggerStay(Collider other)
    {
        // Verificamos si la tecla F es presionada
        if (Input.GetKeyDown(KeyCode.F))
        {   
            bool isCofreAbierto = true; 
            animator.SetBool(parameterName, isCofreAbierto);

            
        }
    }
}

