using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private Vector3 positionHand;

    [SerializeField] private Vector3 rotationHand;

    public void SetPositionLocation()
    {
        transform.localPosition = positionHand;
        transform.localEulerAngles = rotationHand;
    }

}
