using UnityEngine;

public class MonsterLoop : MonoBehaviour
{
    public float timeSpawnMin = 3.25f;
    public float timeSpawnMax = 6.25f;
    float timeSpawn11;

    public GameObject monster11Spawn;
    float randomspawn = 5;


    public Transform[] enemySpwans;
    public GameObject monster22Spawn;
    float mon22Time = 5;
    float timeSpawn22;
    int enemyCount;
    int randomCount;


    private void Update()
    {
        timeSpawn22 += Time.deltaTime;
        timeSpawn11 += Time.deltaTime;

        if (!GameManager.Instance.isGameClear)
        {
            if (timeSpawn11 > randomspawn)
            {
                monst1Spawn();
                Randome();
                timeSpawn11 = 0f;
            }

            if (timeSpawn22 > mon22Time)
            {
                RandomPos();

                GameObject tmp = GameObject.Instantiate(monster22Spawn);
                tmp.transform.position = enemySpwans[randomCount].position;

                timeSpawn22 = 0f;
            }
        }
    }

    private void monst1Spawn()
    {
        Instantiate(monster11Spawn);
    }

    private void Randome()
    {
        if (ScoreManager.instance.score >= 40)
        {
            randomspawn = Random.Range(1, 2.5f);
        }
        else
        {
            randomspawn = Random.Range(timeSpawnMin, timeSpawnMax);
        }
    }


    private void RandomPos()
    {
        randomCount = Random.Range(0, 5);
    }

}
