using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker_Script : MonoBehaviour
{
    private int defaultTimer = 5;
    public float timer;
    public float hp = 1000;
    public GameObject[] levels;
    private int level;
    // Start is called before the first frame update

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
        level++;
        levels[level].SetActive(true);
        levels[level-1].SetActive(false);
    }

    public void TakeDamage()
    {
        timer = defaultTimer;
        hp -= 5;
    }
}
