using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Monsters_3 : MonoBehaviour
{
    public Bulletmonster bull;
    void Start()
    {
        StartCoroutine(Bullet_());
    }

    IEnumerator Bullet_()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bull);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield break;
    }
}
