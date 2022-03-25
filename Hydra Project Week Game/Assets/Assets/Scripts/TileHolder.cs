using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour
{
    // This script is literally just made to hold game objects so we don't have to search for them in another script
    public GameObject deadEndRight; // Dead ends have the entrance where the described point is
    public GameObject deadEndLeft;
    public GameObject deadEndTop;
    public GameObject deadEndBottom;
    public GameObject fourWay;
    public GameObject tRight; // T sections have the center beginning from the given point
    public GameObject tLeft;
    public GameObject tTop;
    public GameObject tBottom;
    public GameObject straightVertical;
    public GameObject straightHorizontal;
    public GameObject topTurnRight; // All turns below should be read as startingpoint turn towards different point
    public GameObject topTurnLeft;
    public GameObject bottomTurnRight;
    public GameObject bottomTurnLeft;
    public GameObject rightTurnTop;
    public GameObject rightTurnBottom;
    public GameObject leftTurnTop;
    public GameObject leftTurnBottom;
    public List<GameObject> tilesForRight = new List<GameObject>();
    public List<GameObject> tilesForLeft = new List<GameObject>();
    public List<GameObject> tilesForBottom = new List<GameObject>();
    public List<GameObject> tilesForTop = new List<GameObject>();

    private void Start() // I had to make different list because not all tiles were compatible
    {
        tilesForRight.Add(rightTurnTop);
        tilesForRight.Add(rightTurnBottom);
        tilesForRight.Add(tRight);
        tilesForRight.Add(tTop);
        tilesForRight.Add(tBottom);
        tilesForRight.Add(fourWay);
        tilesForRight.Add(straightHorizontal); 
        tilesForLeft.Add(leftTurnTop);
        tilesForLeft.Add(leftTurnBottom);
        tilesForLeft.Add(tLeft);
        tilesForLeft.Add(tTop);
        tilesForLeft.Add(tBottom);
        tilesForLeft.Add(fourWay);
        tilesForLeft.Add(straightHorizontal);
        tilesForTop.Add(topTurnRight);
        tilesForTop.Add(topTurnLeft);
        tilesForTop.Add(tTop);
        tilesForTop.Add(tRight);
        tilesForTop.Add(tLeft);
        tilesForTop.Add(fourWay);
        tilesForTop.Add(straightVertical);
        tilesForBottom.Add(bottomTurnRight);
        tilesForBottom.Add(bottomTurnLeft);
        tilesForBottom.Add(tBottom);
        tilesForBottom.Add(tRight);
        tilesForBottom.Add(tLeft);
        tilesForBottom.Add(fourWay);
        tilesForBottom.Add(straightVertical);
    }
}

