using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float forceAmount = 5;

    private Rigidbody dragObject;
    private Camera cam;

    private float selectionDistance;

    void Start()
    {
        cam = Camera.main != null ? Camera.main : GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                selectionDistance = hit.distance;
                dragObject = hit.rigidbody;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragObject = null;
        }

        if (dragObject != null)
        {
            selectionDistance += Input.mouseScrollDelta.y;
        }
    }

    private void FixedUpdate()
    {
        if (dragObject)
        {
            Vector3 cameraObjectDelta = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));

            Vector3 objectMouseDirection = cameraObjectDelta - dragObject.transform.position;

            dragObject.linearVelocity = objectMouseDirection * forceAmount;
        }
    }
}
