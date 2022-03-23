using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceUpgrade : MonoBehaviour
{
    public GameObject fences1;
    public GameObject fences2;
    public GameObject fences3;
    public int fenceLvl = 0;
    public GameObject[] enemys;
    public BunkerScript bunkerScript;
    public List<EnemyBaseScript> enemyBaseScripts = new List<EnemyBaseScript>();
    int counter;
    void Start()
    {
        bunkerScript = FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Upgrade()
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
        counter = 0;
        enemyBaseScripts.Clear();
        foreach (GameObject temp in enemys)
        {
            enemyBaseScripts.Add(enemys[counter].GetComponent<EnemyBaseScript>());
            //enemyBaseScripts[counter].FenceUpgradeChecker();
            counter++;

        }
    }
}