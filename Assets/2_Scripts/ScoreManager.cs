using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float score = 0;
    public float Records = 120;
    public float total = 120;

    public Text scoreText;
    public Text RecordsText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameBoss)
        {
            score += 1 * Time.deltaTime;
            Records -= 1 * Time.deltaTime;
            scoreText.text = score.ToString("F0") + "KM";
            RecordsText.text = "구조까지\n: " + Records.ToString("F0") + "KM";
        }
    }
}
