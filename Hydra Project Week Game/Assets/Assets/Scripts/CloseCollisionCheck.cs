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
    private int listNumberLeft = 0;
    private int listNumberTop = 1;
    private int listNumberRight = 2;
    private int listNumberBottom = 3;
    private int listNumberNoTurn = 4;
    public string[] tags;
    private bool dontDoTwice = false;

    private void Start()
    {
        tags = new string[5] { "1", "2", "3", "4", "5" };
        forRight = transform.position;
        forLeft = transform.position;
        forTop = transform.position;
        forBottom = transform.position;
        farCollision = GetComponentInChildren<FarCollisionCheck>();
        tileHolder = FindObjectOfType<TileHolder>().GetComponent<TileHolder>();
        if (!dontDoTwice)
        {
            Debug.Log("Add numbers to list at: " + gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other) // I am truly sorry for the warcrimes you will witness below, I didnt want to steal someones code so I tried making my own
    {
        if (other.CompareTag("Left") && other.tag != tags[listNumberLeft] && other.tag != gameObject.tag)
        {
            tags[listNumberLeft] = other.tag;
        }
        else if (other.CompareTag("Top") && other.tag != tags[listNumberTop] && other.tag != gameObject.tag)
        {
            tags[listNumberTop] = other.tag;
        }
        else if (other.CompareTag("Right") && other.tag != tags[listNumberRight] && other.tag != gameObject.tag)
        {
            tags[listNumberRight] = other.tag;
        }
        else if (other.CompareTag("Bottom") && other.tag != tags[listNumberBottom] && other.tag != gameObject.tag)
        {
            tags[listNumberBottom] = other.tag;
        }
        else if (other.CompareTag("NoTurn") && other.tag != tags[listNumberNoTurn] && other.tag != gameObject.tag)
        {
            tags[listNumberNoTurn] = other.tag;
        }
        else if (other.CompareTag("Player") && !done)
        {
            GenerateTile(other);
        }
    }
    void GenerateTile(Collider other)
    {
        if (farCollision.occupied && !done)
        {
            if (gameObject.CompareTag("Top") && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndBottom, forTop, transform.rotation);
                done = true;
            }
            if (gameObject.CompareTag("Bottom") && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndTop, forBottom, transform.rotation);
                done = true;
            }
            if (gameObject.CompareTag("Left") && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndRight, forLeft, transform.rotation);
                done = true;
            }
            if (gameObject.CompareTag("Right") && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndLeft, forRight, transform.rotation);
                done = true;
            }
        }
        if (!done && tags[listNumberNoTurn] == "NoTurn" && gameObject.CompareTag("Top") || tags[listNumberNoTurn] == "NoTurn" && gameObject.CompareTag("Bottom") && !done)
        {
            Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
            done = true;
        }
        else if (!done && tags[listNumberNoTurn] == "NoTurn" && gameObject.CompareTag("Left") || tags[listNumberNoTurn] == "NoTurn" &&  gameObject.CompareTag("Right") && !done)
        {
            Instantiate(tileHolder.straightHorizontal, forTop, transform.rotation);
            done = true;
        }
        else if (gameObject.tag == "Top" && !done)
        {
            if (tags[listNumberBottom] == "Bottom" && tags[listNumberRight] == "Right" && tags[listNumberLeft] == "Left")
            {
                Instantiate(tileHolder.fourWay, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberRight] == "Right" && tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.tRight, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left" && tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.tLeft, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left" && tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.tTop, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.topTurnLeft, forTop, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left")
            {
                Instantiate(tileHolder.topTurnRight, forTop, transform.rotation);
                done = true;
            }
        }
        else if (gameObject.tag == "Bottom" && !done)
        {
            if (tags[listNumberTop] == "Top" && tags[listNumberRight] == "Right" && tags[listNumberLeft] == "Left")
            {
                Instantiate(tileHolder.fourWay, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top" && tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.tRight, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top" && tags[listNumberLeft] =="Left")
            {
                Instantiate(tileHolder.tLeft, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left" && tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.tBottom, forBottom, transform.rotation);
                done = true;
            }
            if (tags[listNumberRight] == "Top")
            {
                Instantiate(tileHolder.straightVertical, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.bottomTurnLeft, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left")
            {
                Instantiate(tileHolder.bottomTurnRight, forBottom, transform.rotation);
                done = true;
            }
        }
        else if (gameObject.tag == "Left" && !done)
        {
            if (tags[listNumberBottom] == "Bottom" && tags[listNumberRight] == "Right" && tags[listNumberTop] == "Top")
            {
                Instantiate(tileHolder.fourWay, forLeft, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top" && tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.tTop, forLeft, transform.rotation);
                done = true;
            }
            else if (tags[listNumberRight] == "Right" && tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.tBottom, forLeft, transform.rotation);
                done = true;
            }
            else if ((tags[listNumberTop] == "Top" && tags[listNumberBottom] == "Bottom"))
            {
                Instantiate(tileHolder.tLeft, forLeft, transform.rotation);
                done = true;
            }
            else if (tags[listNumberRight] == "Right")
            {
                Instantiate(tileHolder.straightHorizontal, forLeft, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top")
            {
                Instantiate(tileHolder.leftTurnBottom, forLeft, transform.rotation);
                done = true;
            }
            else if (tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.leftTurnTop, forLeft, transform.rotation);
                done = true;
            }
        }
        else if (gameObject.tag == "Right" && !done)
        {
            if (tags[listNumberBottom] == "Bottom" && tags[listNumberLeft] == "Left" && tags[listNumberTop] == "Top")
            {
                Instantiate(tileHolder.fourWay, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left" && tags[listNumberTop] == "Top")
            {
                Instantiate(tileHolder.tTop, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top" && tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.tLeft, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left" && tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.tBottom, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberLeft] == "Left")
            {
                Instantiate(tileHolder.straightHorizontal, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberTop] == "Top")
            {
                Instantiate(tileHolder.rightTurnBottom, forRight, transform.rotation);
                done = true;
            }
            else if (tags[listNumberBottom] == "Bottom")
            {
                Instantiate(tileHolder.rightTurnTop, forRight, transform.rotation);
                done = true;
            }
        }
        if (gameObject.CompareTag("Top") && !done)
        {
            Instantiate(tileHolder.tilesForTop[Random.Range(0, tileHolder.tilesForTop.Count)], forTop, transform.rotation);
            done = true;
        }
        else if (gameObject.CompareTag("Bottom") && !done)
        {
            Instantiate(tileHolder.tilesForBottom[Random.Range(0, tileHolder.tilesForBottom.Count)], forBottom, transform.rotation);
            done = true;
        }
        else if (gameObject.CompareTag("Right") && !done)
        {
            Instantiate(tileHolder.tilesForRight[Random.Range(0, tileHolder.tilesForRight.Count)], forRight, transform.rotation);
            done = true;
        }
        else if (gameObject.CompareTag("Left") && !done)
        {
            Instantiate(tileHolder.tilesForLeft[Random.Range(0, tileHolder.tilesForLeft.Count)], forLeft, transform.rotation);
            done = true;
        }
    }
}
