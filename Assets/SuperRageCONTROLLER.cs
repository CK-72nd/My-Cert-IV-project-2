using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRageCONTROLLER : MonoBehaviour
{

    Rigidbody rigi;
    Vector3 mySpeed;
    bool spinny = false;
    public float gravity = 20f;

    // Use this for initialization
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            spinny = !spinny;
        }

        mySpeed = Vector3.zero;
        mySpeed += transform.forward * 10 * Input.GetAxis("Vertical");
        mySpeed += transform.right * 10 * Input.GetAxis("Horizontal");
        mySpeed.y -= gravity * Time.deltaTime;
        rigi.velocity = mySpeed;

        if (Input.GetKey(KeyCode.W))
        {
            rigi.AddRelativeForce(0f, 0f, 2000f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigi.AddRelativeForce(0f, 0f, -1500f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigi.AddTorque(0f, -1000f * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigi.AddTorque(0f, 1000f * Time.deltaTime, 0f);
        }

        rigi.velocity = (transform.forward * 20 * Input.GetAxis("Vertical")) + (Vector3.down * 9.81f);
        transform.Rotate(0f, 200f * Input.GetAxis("Horizontal") * (Time.deltaTime), 0f);
        if (spinny)
        {
            rigi.AddRelativeForce((Vector3.up + Vector3.forward / 2) * 900);
        }
    }
}

