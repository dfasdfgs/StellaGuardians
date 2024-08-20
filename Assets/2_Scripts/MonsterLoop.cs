using UnityEngine;

public class MonsterLoop : MonoBehaviour
{
    public float timeSpawnMin = 3.25f;
    public float timeSpawnMax = 5.25f;
    public float timeSpawn;

    public GameObject monsterSpawn;

    private void Update()
    {
        float randomspawn = 5;

        timeSpawn += Time.deltaTime;

        if(timeSpawn > randomspawn)
        {
            monstSpawn();
            timeSpawn = 0f;
        }
    }

    private void monstSpawn()
    {
        Instantiate(monsterSpawn);
    }

}
