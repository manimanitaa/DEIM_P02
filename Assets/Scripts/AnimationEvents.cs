using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void AttackEnded()
    {
        playerController.AttackEneded();
    }
}
