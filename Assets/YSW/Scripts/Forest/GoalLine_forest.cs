using UnityEngine;
using TMPro;

public class GoalLine_forest : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;

    private float acornMax = 30;
    [SerializeField] private AudioClip scoreUpSound; // ���ھ� ���� ȿ����
    private AudioSource audioSource; // ���� ����� ������Ʈ


    private void Start()
    {
        score = 0;
        //text.text = "Score: " + score;
        text.text = score + "/" + acornMax;

        // AudioSource ����
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
                audioSource.PlayOneShot(scoreUpSound); // ȿ���� ���
            }

        }
    }
}
