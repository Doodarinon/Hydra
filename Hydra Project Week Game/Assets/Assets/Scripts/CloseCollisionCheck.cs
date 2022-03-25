using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCollisionCheck : MonoBehaviour
{
    public bool occupied;
    public bool done = false;
    public FarCollisionCheck farCollision;
    public TileHolder tileHolder;
    private Vector3 forRight;
    private Vector3 forLeft;
    private Vector3 forTop;
    private Vector3 forBottom;
    private Vector3 rightAmmount;
    private Vector3 leftAmmount;
    private Vector3 topAmmount;
    private Vector3 bottomAmmount;
    private int counter = 0;

    private void Start()
    {
        forRight = transform.position;
        forLeft = transform.position;
        forTop = transform.position;
        forBottom = transform.position;
        farCollision = GetComponentInChildren<FarCollisionCheck>();
        tileHolder = FindObjectOfType<TileHolder>().GetComponent<TileHolder>();
    }
    private void OnTriggerStay(Collider other) // I am truly sorry for the warcrimes you will witness below, I didnt want to steal someones code so I tried making my own
    {
        if (other.CompareTag("Player") && !done)
        {
            GenerateTile(other);
        }
    }
    void GenerateTile(Collider other)
    {
        if (farCollision.occupied && !done)
        {
            if (gameObject.tag == "Top")
            {
                Instantiate(tileHolder.deadEndBottom, forTop, transform.rotation);
                done = true;
            }
            if (gameObject.tag == "Bottom")
            {
                Instantiate(tileHolder.deadEndTop, forBottom, transform.rotation);
                done = true;
            }
            if (gameObject.tag == "Left")
            {
                Instantiate(tileHolder.deadEndRight, forLeft, transform.rotation);
                done = true;
            }
            if (gameObject.tag == "Right")
            {
                Instantiate(tileHolder.deadEndLeft, forRight, transform.rotation);
                done = true;
            }
        }
        if (!done && other.tag == "NoTurn" && (gameObject.tag == "Top" || gameObject.tag ==  "Bottom"))
        {
            Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
            done = true;
            Debug.Log("Works");
        }
        else if (!done && other.tag == "NoTurn" && (gameObject.tag == "Left" || gameObject.tag == "Right"))
        {
            Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
            done = true;
            Debug.Log("Works");
        }
        else if (gameObject.tag == "Top" && !done)
        {
            if (other.tag == "Bottom" && other.tag == "Right" && other.tag == "Left")
            {
                Instantiate(tileHolder.fourWay, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Right" && other.tag == "Bottom")
            {
                Instantiate(tileHolder.tRight, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Left" && other.tag == "Bottom")
            {
                Instantiate(tileHolder.tLeft, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Left" && other.tag == "Right")
            {
                Instantiate(tileHolder.tTop, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Bottom")
            {
                Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Right")
            {
                Instantiate(tileHolder.topTurnRight, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Left")
            {
                Instantiate(tileHolder.topTurnLeft, forTop, transform.rotation);
                done = true;
            }
            else if (other.tag == "Top")
            {
                Debug.Log("Doesnt work");
            }
        }
        else if (gameObject.tag == "Bottom" && !done)
        {
            if (other.tag == "Top" && other.tag == "Right" && other.tag == "Left")
            {
                Instantiate(tileHolder.fourWay, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (other.tag == "Top" && other.tag == "Right")
            {
                Instantiate(tileHolder.tRight, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (other.tag == "Top" && other.tag =="Left")
            {
                Instantiate(tileHolder.tLeft, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (other.tag == "Left" && other.tag == "Right")
            {
                Instantiate(tileHolder.tBottom, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            if (other.tag == "Top")
            {
                Instantiate(tileHolder.straightVertical, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (other.tag == "Right")
            {
                Instantiate(tileHolder.bottomTurnRight, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (other.tag == "Left")
            {
                Instantiate(tileHolder.bottomTurnLeft, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
        }
        else if (gameObject.tag == "Left" && !done)
        {
            if (other.tag == "Bottom" && other.tag == "Right" && other.tag == "Top")
            {
                Instantiate(tileHolder.fourWay, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (other.tag == "Top" && other.tag == "Right")
            {
                Instantiate(tileHolder.tTop, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (other.tag == "Right" && other.tag == "Bottom")
            {
                Instantiate(tileHolder.tBottom, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if ((other.tag == "Top" && other.tag == "Bottom"))
            {
                Instantiate(tileHolder.tLeft, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (other.tag == "Right")
            {
                Instantiate(tileHolder.straightHorizontal, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (other.tag == "Top")
            {
                Instantiate(tileHolder.leftTurnTop, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (other.tag == "Bottom")
            {
                Instantiate(tileHolder.leftTurnBottom, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
        }
        else if (gameObject.tag == "Right" && !done)
        {
            if (other.CompareTag("Bottom") && other.CompareTag("Left") && other.CompareTag("Top"))
            {
                Instantiate(tileHolder.fourWay, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Top") && other.CompareTag("Left"))
            {
                Instantiate(tileHolder.tTop, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Top") && other.CompareTag("Bottom"))
            {
                Instantiate(tileHolder.tLeft, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Bottom") && other.CompareTag("Right"))
            {
                Instantiate(tileHolder.tBottom, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Left"))
            {
                Instantiate(tileHolder.straightHorizontal, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Top"))
            {
                Instantiate(tileHolder.rightTurnTop, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (other.CompareTag("Bottom"))
            {
                Instantiate(tileHolder.rightTurnBottom, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
        }
        if (gameObject.CompareTag("Top") && !done)
        {
            Instantiate(tileHolder.tilesForTop[Random.Range(0, tileHolder.tilesForTop.Count)], forTop, transform.rotation);
            done = true;
            Debug.Log("1");
        }
        else if (gameObject.CompareTag("Bottom") && !done)
        {
            Instantiate(tileHolder.tilesForBottom[Random.Range(0, tileHolder.tilesForBottom.Count)], forBottom, transform.rotation);
            done = true;
            Debug.Log("2");
        }
        else if (gameObject.CompareTag("Right") && !done)
        {
            Instantiate(tileHolder.tilesForRight[Random.Range(0, tileHolder.tilesForRight.Count)], forRight, transform.rotation);
            done = true;
            Debug.Log("3");
        }
        else if (gameObject.CompareTag("Left") && !done)
        {
            Instantiate(tileHolder.tilesForLeft[Random.Range(0, tileHolder.tilesForLeft.Count)], forLeft, transform.rotation);
            done = true;
            Debug.Log("4");
        }
        else
        {
            Debug.Log("Oh no");
        }
    }
}
