using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerController1 playerController;

    public void AttackEnded()
    {
        playerController.AttackEnded();
    }
}
