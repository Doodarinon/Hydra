using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    List<GameObject> tempEnemies;
    int tempEnemiesCount;
    List<GameObject> enemies;
    public GameObject enemy1;
    public GameObject enemy2;
     public List<int> randoNumbers;
    bool randomizing;
    public int enemyCount;
    //test
    public void ChooseEnemyAmmount(int enemyBaseAmmount, int waveNr, int enemyMultiplier)
    {
        int enemy1MaxAmmount = enemyBaseAmmount * waveNr * enemyMultiplier;
        int enemy2MaxAmmount = enemyBaseAmmount * waveNr * enemyMultiplier;
        Debug.Log(enemy1MaxAmmount);
        for (int i = 0; i < enemy1MaxAmmount; i++)
        {
            tempEnemies.Add(enemy1);
            Debug.Log("Added enemy 1");
        }
        for (int i = enemy1MaxAmmount; i <= enemy1MaxAmmount + enemy2MaxAmmount; i++)
        {
            tempEnemies.Add(enemy2);
            Debug.Log("Added enemy 2");
        }
    }
    public void Randomize() // Please for the love of god dont look below here unless you want a stroke
    {
        tempEnemiesCount = 0;
        int enemyCounter;
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        int randomNumber;
        randomizing = true;
        bool sequenceComplete = false;
        foreach(GameObject gameObject in tempEnemies)
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
                break;
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
        int counter = 0;
        foreach (GameObject gameObject in enemies)
        {
            //enemyCount++;
            Instantiate(gameObject, spawnPoints[counter].transform.position, spawnPoints[counter].transform.rotation);
        }
    }
}
