using TMPro;
using UnityEngine;
using System.Collections;

public class InfoTime_City : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private readonly System.Diagnostics.Stopwatch timer = new();

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timer.Reset();
    }

    private void Start()
    {
        StartCoroutine(WorkTimer());

    }

    public IEnumerator WorkTimer()
    {
        timer.Start();

        while (GoalLine_City.score < 50)
        {
            timeText.text = (timer.ElapsedMilliseconds / 1000f).ToString("0.0");
            yield return null;
        }

        timer.Stop();

        yield break;
    }
}
