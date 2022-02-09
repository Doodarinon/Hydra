using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gravity : MonoBehaviour
{
    new Rigidbody rigidbody;

    public float gravityMultiplier = 1;

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
        rigidbody.AddForce(-transform.up * gravityMultiplier);
    }
}
