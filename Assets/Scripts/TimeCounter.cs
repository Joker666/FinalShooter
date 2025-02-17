using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float startTime;
    public float elapsedTime;
    bool startCounter;

    int minutes;
    int seconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startCounter = false;

        timeText = GetComponent<TextMeshProUGUI>();
    }

    public void StartCounter()
    {
        startCounter = true;
        startTime = Time.time;
    }

    public void StopCounter()
    {
        startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            elapsedTime = Time.time - startTime;

            minutes = (int)elapsedTime / 60;
            seconds = (int)elapsedTime % 60;

            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
