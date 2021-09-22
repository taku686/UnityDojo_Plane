using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = targetPos.position - transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPos.position - offset;
    }
}
