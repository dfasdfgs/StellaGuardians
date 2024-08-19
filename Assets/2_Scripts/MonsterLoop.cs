using UnityEngine;

public class MonsterLoop : MonoBehaviour
{
    public float timeSpawnMin = 2.25f;
    public float timeSpawnMax = 3.25f;
    public float timeSpawn;

    public GameObject monsterSpawn;

    private void Update()
    {
        
    }

    private void monstSpawn()
    {
        Instantiate(monsterSpawn);
    }

}
