using UnityEngine;

public class PlayerPointerController : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private float maxRaycasyDistance;
    [SerializeField] private LayerMask raycastMask;

    Vector3 target;

    [SerializeField] Transform playerTrf;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, maxRaycasyDistance, raycastMask))
        {

            target = hitInfo.point;

            while (Vector3.Distance(playerTrf.position, target) > 5)
            {
                target = Vector3.MoveTowards(target, playerTrf.position, 0.01f);
            }


            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f); ;
        }
    }
}
