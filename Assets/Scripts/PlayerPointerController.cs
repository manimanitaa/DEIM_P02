using UnityEngine;

public class PlayerPointerController : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private float maxRaycasyDistance;
    [SerializeField] private LayerMask raycastMask;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, maxRaycasyDistance,raycastMask))
        {
            transform.position = hitInfo.point;
        }
    }
}
