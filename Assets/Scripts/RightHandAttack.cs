using UnityEngine;

public class RightHandAttack : MonoBehaviour
{

    [SerializeField] PlayerController1 pc;

    int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider collider)
    {
        print("test");
        if (collider.gameObject.tag == "Player")
        {
            
            pc.vidaPlayer -= damage;
        }
    }
}
