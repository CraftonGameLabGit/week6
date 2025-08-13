using UnityEngine;
using TMPro;

public class GoalLine_forest : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;

    private float acornMax = 30;
    [SerializeField] private AudioClip scoreUpSound; // 스코어 증가 효과음
    private AudioSource audioSource; // 사운드 재생용 컴포넌트


    private void Start()
    {
        score = 0;
        //text.text = "Score: " + score;
        text.text = score + "/" + acornMax;

        // AudioSource 설정
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("Goal!");
            score++;
            text.text = score + "/" + acornMax;
            if (scoreUpSound != null)
            {
                audioSource.PlayOneShot(scoreUpSound); // 효과음 재생
            }

        }
    }
}
