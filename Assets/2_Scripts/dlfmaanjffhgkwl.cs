using UnityEngine;

public class dlfmaanjffhgkwl : MonoBehaviour
{
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 12f);

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 4) == 0)
            {
                obstacles[i].gameObject.SetActive(false);
            }
            else
            {
                obstacles[i].SetActive(true);
            }
        }
    }
}
