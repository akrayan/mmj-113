using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    public float rotationSpeed = 3;
    public float Speed = 2;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        //_rb.MovePosition(dir);
        _rb.velocity = transform.forward * v * Speed;
        _rb.angularVelocity = new Vector3(0, h * rotationSpeed, 0);
        //_rb.AddRelativeForce(dir, ForceMode.VelocityChange);
        //Debug.Log("Velocity : " + _rb.velocity);
    }
}
