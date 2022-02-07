using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float movement_speed = 5f;
    // public GameObject player;

    // private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        // Sets "pos" as the players position
        // pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);

    }
}
