using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject target;
    public float springRatio;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        AddSpringforce(target.transform.position, springRatio);
    }

    private void AddVelocityForce()
    {
        var hori = Input.GetAxis("Horizontal");
        var kmph = 100f;
        var mps = kmph * (1000f / 3600f);
        var target_vlocity = mps * hori;
        var v = new Vector3(target_vlocity, 0f, 0f);      
        var force = (rb.mass * rb.drag * v) / (1f - rb.drag * Time.fixedDeltaTime);
        rb.AddForce(force);
        Debug.LogFormat("velocity={0}km/h", rb.velocity.magnitude * (3600f / 1000f));
    }

    private void AddSpringforce(Vector3 targetPosition,float r)
    {
        var diff = targetPosition - transform.position;
        var force = diff * r;
        rb.AddForce(force);
    }
    
}
