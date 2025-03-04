using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Libro"))
        {
            animator.enabled = true;
        }
    }
}
