using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float movement_speed = 5f;
    public float baseTimer = 5f;
    private float timer;
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

        if (timer > 0)
        {
            timer = -Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") || timer <= 0)
        {
            PlayerAttack();
        }
    }

    void PlayerAttack()
    {

        timer = baseTimer;
    }
}
