using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            updateScoreText();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateScoreText()
    {
        scoreText.text = string.Format("{0:0000000}", score);
    }
}
