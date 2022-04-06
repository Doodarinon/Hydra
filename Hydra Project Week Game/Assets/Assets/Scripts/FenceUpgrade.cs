using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceUpgrade : MonoBehaviour
{    
    int counter;
    public int cost;
    public int fenceLvl = 0;

    public GameObject fences1;
    public GameObject fences2;
    public GameObject fences3;
    public GameObject[] enemies;

    private GameManager gameManager;

    private BunkerScript bunkerScript;

    public List<EnemyBaseScript> enemyBaseScripts = new List<EnemyBaseScript>();

    void Start()
    {
        GameObject bunker = GameObject.Find("Bunker");
        bunkerScript = bunker.GetComponent<BunkerScript>();

        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Upgrade()
    {
        if(cost <= gameManager.Materials)
        {
            fenceLvl++;
            if (fenceLvl == 1) // upgrade to lvl 1
            {
                    fences1.SetActive(true);
            }
            if (fenceLvl == 2) // upgrade to lvl 2
            {
                    fences1.SetActive(false);
                    fences2.SetActive(true);
            }
            if (fenceLvl == 3) // upgrade to lvl 3
            {
                    fences2.SetActive(false);
                    fences3.SetActive(true);
            }
        }

        counter = 0;
        enemyBaseScripts.Clear();
        foreach (GameObject temp in enemies)
        {
            enemyBaseScripts.Add(enemies[counter].GetComponent<EnemyBaseScript>());
            enemyBaseScripts[counter].FenceUpgradeChecker();
            counter++;

        }
    }
}
