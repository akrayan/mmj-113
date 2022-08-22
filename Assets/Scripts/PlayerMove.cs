using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour, IAttractable
{
    public float rotationSpeed = 3;
    public float speed = 5;

    Rigidbody _rb;
    Vector3 _attractionForce = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void UpdateAttraction(Vector3 force)
    {
        _attractionForce = force;
        Debug.Log("attraction = " + force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        //_rb.MovePosition(dir);
        _rb.velocity = (transform.forward * v * speed) + _attractionForce;
        _rb.angularVelocity = new Vector3(0, h * rotationSpeed, 0);
        //_rb.AddRelativeForce(dir, ForceMode.VelocityChange);
        //Debug.Log("Velocity : " + _rb.velocity);
    }
}
