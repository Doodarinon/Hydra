using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker_Script : MonoBehaviour
{
    public float defaultTimer = 1f;
    public float timer;
    public float hp;
    public GameObject[] levels;
    private int level;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
          
        
    }

    public void Upgrade()
    {
        level++;
        levels[level].SetActive(true);
        levels[level-1].SetActive(false);
    }
    public void TakeDamage()
    {
        hp -= 5;
    }
}
