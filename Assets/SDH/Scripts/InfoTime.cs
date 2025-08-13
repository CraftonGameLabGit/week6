using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InfoTime : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private readonly System.Diagnostics.Stopwatch timer = new();

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(WorkTimer());
    }

    public IEnumerator WorkTimer()
    {
        timer.Start();

        while (!OceanManager.Instance.OceanClear)
        {
            timeText.text = (timer.ElapsedMilliseconds / 1000f).ToString("0.0");
            yield return null;
        }

        timer.Stop();

        yield break;
    }
}
