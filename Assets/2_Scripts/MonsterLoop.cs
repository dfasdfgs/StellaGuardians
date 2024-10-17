using UnityEngine;

public class MonsterLoop : MonoBehaviour
{
    public float timeSpawnMin = 4.25f;
    public float timeSpawnMax = 7.25f;
    public float timeSpawn;

    public GameObject monster11Spawn;
    float randomspawn = 5;


    public Transform[] enemySpwans;
    public GameObject monster22Spawn;
    float mon22Time;
    int enemyCount;
    int[] randomCount;


    private void Update()
    {

        timeSpawn += Time.deltaTime;

        if (!GameManager.Instance.isGameClear)
        {
            if (timeSpawn > randomspawn)
            {
                monst1Spawn();
                Randome();
                timeSpawn = 0f;
            }
        }
    }

    private void monst1Spawn()
    {
        Instantiate(monster11Spawn);
    }

    private void monst2Spawn()
    {
        Instantiate(monster11Spawn);
    }

    private void Randome()
    {
        randomspawn = Random.Range(timeSpawnMin, timeSpawnMax);
    }    
    
    
    private void RandomPos()
    {
        for(int i = 0; i < enet)

        randomCount[i] = Random.Range(timeSpawnMin, timeSpawnMax);
    }

}
