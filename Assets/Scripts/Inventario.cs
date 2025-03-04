using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   
    [SerializeField] private Transform objectTarget;

    private GameObject objectInHand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))    //suelta el objeto
        {
            objectInHand.transform.SetParent(null);
             objectInHand.GetComponent<Collider>().enabled = true;
            objectInHand.GetComponent<Rigidbody>().useGravity = true;

            foreach (Collider c in objectInHand.GetComponents<Collider>())   //activa todos los collider
            {
                c.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectInHand != null)
            {
                objectInHand.transform.SetParent(null);
                objectInHand.transform.SetPositionAndRotation(other.gameObject.transform.position, other.gameObject.transform.rotation); //intercambia
                //objectInHand.GetComponent<Collider>().enabled = true;
                objectInHand.GetComponent<Rigidbody>().useGravity = true; //activa la gravedad del collider para cuando agarre el objeto

                foreach (Collider c in objectInHand.GetComponents<Collider>())   //activa todos los collider
                {
                    c.enabled = true;
                }
            }

            other.gameObject.transform.SetParent(objectTarget);

            other.gameObject.GetComponent<ObjectController>().SetPositionLocation();

            objectInHand = other.gameObject;
            //objectInHand.GetComponent<Collider>().enabled = false;
            objectInHand.GetComponent<Rigidbody>().useGravity = false;


            foreach(Collider c in objectInHand.GetComponents<Collider>())   //desactiva todos los collider
            {
                c.enabled = false;
            }
            
        }
       
    }

}
