using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestGoalLine : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;

    private float acornMax = 100;
    
    private void Start()
    {
        //text.text = "Score: " + score;
        text.text = score + "/" + acornMax;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("Goal!");
            score++;
            text.text = score + "/" + acornMax;

        }
    }
}
