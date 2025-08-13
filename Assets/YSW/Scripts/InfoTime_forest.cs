using TMPro;
using UnityEngine;
using System.Collections;

public class InfoTime_forest : MonoBehaviour
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
        
        while (GoalLine_forest.score < 30 )
        {
            timeText.text = (timer.ElapsedMilliseconds / 1000f).ToString("0.0");
            yield return null;
        }

        timer.Stop();

        yield break;
    }
}
