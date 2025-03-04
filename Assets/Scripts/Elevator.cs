using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void MoveElevator()
    {
        animator.enabled = true;
    }
}
