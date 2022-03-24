using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerScript : MonoBehaviour
{
    public int cost;
    public float timer;
    public float hp = 1000;

    private int level;
    private int defaultTimer = 5;

    private GameManager gameManager;

    public GameObject[] levels;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Upgrade()
    {
        if(cost <= gameManager.Materials)
        {
            level++;
            levels[level].SetActive(true);
            levels[level-1].SetActive(false);
        }
    }

    public void TakeDamage()
    {
        timer = defaultTimer;
        hp -= 5;
    }
}
