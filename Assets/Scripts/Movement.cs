using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 input;
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.AddForce(input * speed);
    }
}
