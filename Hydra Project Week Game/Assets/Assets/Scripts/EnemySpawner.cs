using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    List<GameObject> tempEnemies;
    List<GameObject> enemies;
    public GameObject enemy1;
    public GameObject enemy2;
    List<int> randoNumbers;
    bool randomizing;

    public void ChooseEnemyAmmount(int enemyBaseAmmount, int waveNr, int enemyMultiplier)
    {
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
    public void Randomize() // Please for the love of god dont look below here unless you want a stroke
    {
        int enemyCounter;
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        int randomNumber;
        randomizing = true;
        bool sequenceComplete = false;
        System.Random random = new System.Random();
        randomNumber = random.Next(0, tempEnemies.Count);
        while (randomizing)
        {
            while (counter2 < randoNumbers.Count)
            {

                if (randomNumber == randoNumbers[counter2])
                {

                    randomNumber = random.Next(0, tempEnemies.Count);
                }
                counter2++;
            }
            counter2 = 0;
            enemyCounter = tempEnemies.Count;
            if (sequenceComplete)
            {
                enemies.Add(tempEnemies[randomNumber]);
                randoNumbers.Add(randomNumber);
                sequenceComplete = false;
                break;
            }
            else if (randoNumbers.Count == tempEnemies.Count)
            {
                randomizing = false;
                break;
            }
            else if (counter3 == tempEnemies.Count)
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
        foreach (var gameObject in enemies)
        {
            Instantiate(enemies[counter], spawnPoints[counter].transform.position, spawnPoints[counter].transform.rotation);
        }
    }
}
