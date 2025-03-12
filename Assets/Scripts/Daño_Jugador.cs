using UnityEngine;

public class Daño_Jugador : MonoBehaviour
{

    [SerializeField] BOSS_CONTROLER  pc;

     [SerializeField]int damage = 35;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider collider)
    {
        print("test");
        if (collider.gameObject.tag == "Enemigo")
        {

            pc.vidaPlayer -= damage;
        }
    }
}