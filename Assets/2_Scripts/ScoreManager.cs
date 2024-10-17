using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float score;
    public float Records;

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
        if (!GameManager.Instance.isGameClear)
        {
            score += 1 * Time.deltaTime;
            Records -= 1 * Time.deltaTime;
            scoreText.text = score.ToString("F0") + "KM";
            RecordsText.text = "�������� : \n" + Records.ToString("F0") + "KM";
        }
    }
}
