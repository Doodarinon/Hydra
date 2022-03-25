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
    private int tempName = 0;
    private int tempName1 = 1;
    private int tempName2 = 2;
    private int tempName3 = 3;
    private int tempName4 = 4;
    public new List<string> tags = new List<string>();

    private void Start()
    {
        forRight = transform.position;
        forLeft = transform.position;
        forTop = transform.position;
        forBottom = transform.position;
        farCollision = GetComponentInChildren<FarCollisionCheck>();
        tileHolder = FindObjectOfType<TileHolder>().GetComponent<TileHolder>();
        tags.Add("1");
        tags.Add("2");
        tags.Add("3");
        tags.Add("4");
        tags.Add("5");
    }
    private void OnTriggerStay(Collider other) // I am truly sorry for the warcrimes you will witness below, I didnt want to steal someones code so I tried making my own
    {
        if (other.CompareTag("Left") && other.tag != tags[tempName])
        {
            tags[tempName] = other.tag;
        }
        else if (other.CompareTag("Top"))
        {
            tags[tempName1] = other.tag;
        }
        else if (other.CompareTag("Right"))
        {
            tags[tempName2] = other.tag;
        }
        else if (other.CompareTag("Bottom"))
        {
            tags[tempName3] = other.tag;
        }
        else if (other.CompareTag("NoTurn"))
        {
            tags[tempName4] = other.tag;
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
            if (tags[tempName1] == "Top" && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndBottom, forTop, transform.rotation);
                done = true;
            }
            if (tags[tempName3] == "Bottom" && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndTop, forBottom, transform.rotation);
                done = true;
            }
            if (tags[tempName] == "Left" && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndRight, forLeft, transform.rotation);
                done = true;
            }
            if (tags[tempName2] == "Right" && farCollision.occupied)
            {
                Instantiate(tileHolder.deadEndLeft, forRight, transform.rotation);
                done = true;
            }
        }
        if (!done && tags[tempName4] == "NoTurn" && gameObject.CompareTag("Top") || tags[tempName4] == "NoTurn" && gameObject.CompareTag("Bottom") && !done)
        {
            Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
            done = true;
            Debug.Log("Works");
        }
        else if (!done && tags[tempName4] == "NoTurn" && gameObject.CompareTag("Left") || tags[tempName4] == "NoTurn" &&  gameObject.CompareTag("Right") && !done)
        {
            Instantiate(tileHolder.straightHorizontal, forTop, transform.rotation);
            done = true;
            Debug.Log("Works");
        }
        else if (gameObject.tag == "Top" && !done)
        {
            if (tags[tempName3] == "Bottom" && tags[tempName2] == "Right" && tags[tempName] == "Left")
            {
                Instantiate(tileHolder.fourWay, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName2] == "Right" && tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.tRight, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName] == "Left" && tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.tLeft, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName] == "Left" && tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.tTop, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.straightVertical, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.topTurnRight, forTop, transform.rotation);
                done = true;
            }
            else if (tags[tempName] == "Left")
            {
                Instantiate(tileHolder.topTurnLeft, forTop, transform.rotation);
                done = true;
            }
        }
        else if (gameObject.tag == "Bottom" && !done)
        {
            if (tags[tempName1] == "Top" && tags[tempName2] == "Right" && tags[tempName] == "Left")
            {
                Instantiate(tileHolder.fourWay, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (tags[tempName1] == "Top" && tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.tRight, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (tags[tempName1] == "Top" && tags[tempName] =="Left")
            {
                Instantiate(tileHolder.tLeft, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (tags[tempName] == "Left" && tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.tBottom, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            if (tags[tempName2] == "Top")
            {
                Instantiate(tileHolder.straightVertical, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
            else if (tags[tempName2] == "Right")
            {
                Debug.Log("Works2");
                Instantiate(tileHolder.bottomTurnRight, forBottom, transform.rotation);
                done = true;
            }
            else if (tags[tempName] == "Left")
            {
                Instantiate(tileHolder.bottomTurnLeft, forBottom, transform.rotation);
                done = true;
                Debug.Log("Works2");
            }
        }
        else if (gameObject.tag == "Left" && !done)
        {
            if (tags[tempName3] == "Bottom" && tags[tempName2] == "Right" && tags[tempName1] == "Top")
            {
                Instantiate(tileHolder.fourWay, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (tags[tempName1] == "Top" && tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.tTop, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (tags[tempName2] == "Right" && tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.tBottom, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if ((tags[tempName1] == "Top" && tags[tempName3] == "Bottom"))
            {
                Instantiate(tileHolder.tLeft, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (tags[tempName2] == "Right")
            {
                Instantiate(tileHolder.straightHorizontal, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (tags[tempName1] == "Top")
            {
                Instantiate(tileHolder.leftTurnBottom, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
            else if (tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.leftTurnTop, forLeft, transform.rotation);
                done = true;
                Debug.Log("Works3");
            }
        }
        else if (gameObject.tag == "Right" && !done)
        {
            if (tags[tempName3] == "Bottom" && tags[tempName] == "Left" && tags[tempName1] == "Top")
            {
                Instantiate(tileHolder.fourWay, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName] == "Left" && tags[tempName1] == "Top")
            {
                Instantiate(tileHolder.tTop, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName1] == "Top" && tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.tLeft, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName] == "Left" && tags[tempName3] == "Bottom")
            {
                Instantiate(tileHolder.tBottom, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName] == "Left")
            {
                Instantiate(tileHolder.straightHorizontal, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName1] == "Top")
            {
                Instantiate(tileHolder.rightTurnTop, forRight, transform.rotation);
                done = true;
                Debug.Log("Works4");
            }
            else if (tags[tempName3] == "Bottom")
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
            Debug.Log(done);
        }
    }
}
