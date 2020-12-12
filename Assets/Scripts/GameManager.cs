using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> AllCreatedEnemies;
    public List<Transform> enemypoints;
    public float timer = 1f;
    public float rate = 1f;
    public int maxdino;
   
    

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer<=0 && EnemyController.Allenemies.Count<maxdino)
        {
            CreateEnemy();
            timer = rate;
        }


    }



    public void CreateEnemy()
    {
        int randenemyindex = Random.Range(0, AllCreatedEnemies.Count);
        int randindexpoint = Random.Range(0, enemypoints.Count);
        GameObject createdenemy = Instantiate(AllCreatedEnemies[randenemyindex], enemypoints[randindexpoint].position, Quaternion.identity);
        
    }



}
