using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text materialsText;

    public BunkerScript bunkerScript;
    public EnemySpawner enemySpawner;

    FenceUpgrade fenceUpgrade;
    int enemyBaseAmmount = 100;
    int enemyMultiplier = 2;
    int waveNr = 1;

    private int materials;

    public int Materials
    {
        get { return materials; }
        set
        {
            materials = value;
            // Material text is set to current amount of materials.
            materialsText.GetComponent<TMP_Text>().text = materials.ToString();
        }
    }

    public bool startRound;
    bool gameover = false;

    // Start is called before the first frame update
    private void Start()
    {
        //bunkerScript = FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();
        //enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
        // Player begins with no materials.
        Materials = 0;
    }
    void Update()
    {


    }
    public void SpawnWaves()
    {
        if (enemySpawner.enemyCount <= 0)
        {
            enemySpawner.ChooseEnemyAmmount(enemyBaseAmmount, waveNr, enemyMultiplier);
            enemySpawner.Randomize();
            enemySpawner.SpawnEnemys();
        }
    }
}
