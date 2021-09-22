using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlane : MonoBehaviour
{
    Rigidbody rb;
    public float target_kmph = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        AddTorque();
    }

    private void AddTorque()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        rb.AddRelativeTorque(new Vector3(0, hori, -hori));
        rb.AddRelativeTorque(new Vector3(vert, 0, 0));

        var left = transform.TransformVector(Vector3.left);
        var horizontalLeft = new Vector3(left.x, 0f, left.z).normalized;
        rb.AddTorque(Vector3.Cross(left, horizontalLeft) * 4f);
        var forward = transform.TransformVector(Vector3.forward);
        var horizontalForward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontalForward) * 2f);
        var force = (rb.mass * rb.drag * target_kmph / 3.6f) / (1f - rb.drag + Time.fixedDeltaTime);
        rb.AddRelativeForce(new Vector3(0f, 0f, force));
    }
}
