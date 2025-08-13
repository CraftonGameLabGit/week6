using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        GetComponent<RectTransform>().position = new(transform.parent.GetComponentInChildren<Image>().transform.GetComponent<RectTransform>().sizeDelta.x + 20f, GetComponent<RectTransform>().position.y);
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RenewFishScore();
    }

    public void RenewFishScore()
    {
        scoreText.text = OceanManager.Instance.OceanInfo.Fish + " / " + OceanManager.Instance.OceanInfo.FishMax;
    }
}
