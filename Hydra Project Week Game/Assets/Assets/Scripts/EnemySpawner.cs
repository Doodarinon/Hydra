using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> tempEnemies = new List<GameObject>();
    public GameObject[] spawnPoints;
    public List<int> randoNumbers = new List<int>();
    public GameObject enemy1;
    public GameObject enemy2;
    public int enemyCount;
    int tempEnemiesCount;
    bool randomizing;

    // Please for the love of god dont look below here unless you want a stroke

    public void ChooseEnemyAmmount(int enemyBaseAmmount, int waveNr, int enemyMultiplier)
    {
        tempEnemies.Clear();
        int enemy1MaxAmmount = enemyBaseAmmount * waveNr * enemyMultiplier;
        int enemy2MaxAmmount = enemyBaseAmmount * waveNr * enemyMultiplier;

        for (int i = 0; i < enemy1MaxAmmount; i++)
        {
            tempEnemies.Add(enemy1);
        }
        for (int i = 0; i < enemy2MaxAmmount; i++)
        {
            tempEnemies.Add(enemy2);
        }
    }
    public void Randomize()
    {
        tempEnemiesCount = 0;
        int enemyCounter;
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        int randomNumber;
        randomizing = true;
        bool sequenceComplete = false;
        if(enemyCount <= 0)
        {
            enemies.Clear();
            randoNumbers.Clear();
        }
        foreach (GameObject gameObject in tempEnemies)
        {
            tempEnemiesCount++;
        }
        randomNumber = Random.Range(0, tempEnemiesCount);
        while (randomizing)
        {
            while (counter2 < randoNumbers.Count)
            {

                if (randomNumber == randoNumbers[counter2])
                {

                    randomNumber = Random.Range(0, tempEnemiesCount);
                }
                counter2++;
            }
            counter2 = 0;
            enemyCounter = tempEnemiesCount;
            if (sequenceComplete)
            {
                enemies.Add(tempEnemies[randomNumber]);
                randoNumbers.Add(randomNumber);
                sequenceComplete = false;
            }
            else if (randoNumbers.Count == tempEnemiesCount)
            {
                randomizing = false;
                break;
            }
            else if (counter3 == tempEnemiesCount)
            {
                sequenceComplete = true;
            }
            else
            {
                counter++;
                counter3++;
            }
        }
    }
    public void SpawnEnemys()
    {
        int i = 0;
        int counter = 0;
        for (i = 0; i < enemies.Count; i++)
        {
            Debug.Log(i);
            if (counter == spawnPoints.Length)
            {
                counter = 0;
            }
            StartCoroutine(SlowDown(2, counter, i));
            enemyCount++;
            counter++;
        }

    }
    private IEnumerator<WaitForSeconds> SlowDown(float slowDownTimer, int counter, int i)
    {
        Instantiate(enemies[i], spawnPoints[counter].transform.position, spawnPoints[counter].transform.rotation);
        yield return new WaitForSeconds(slowDownTimer);
    }
}
