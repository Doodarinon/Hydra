using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gravity : MonoBehaviour
{
    Rigidbody rigidbody;

    public float gravity_multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(-transform.up * gravity_multiplier);
    }
}
