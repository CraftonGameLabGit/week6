using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class GoalLine_City : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;
    private float boxMax = 50;
    private List<GameObject> boxesInZone = new List<GameObject>(); // ���� �� �ڽ� ���

    [SerializeField] private AudioClip scoreUpSound; // ���ھ� ���� ȿ����
    private AudioSource audioSource; // ���� ����� ������Ʈ

    private void Start()
    {
        score = 0;
        text.text = score + "/" + boxMax;

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
            // �ڽ��� ������ ������ ��Ͽ� �߰�
            if (!boxesInZone.Contains(collision.gameObject))
            {
                boxesInZone.Add(collision.gameObject);
            }
            if (scoreUpSound != null)
            {
                audioSource.PlayOneShot(scoreUpSound); // ȿ���� ���
            }
            UpdateScore();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            // �ڽ��� ������ ������ ��Ͽ��� ����
            boxesInZone.Remove(collision.gameObject);
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // ���� �� �ڽ� ������ ���ھ�� ����
        score = boxesInZone.Count;
        text.text = score + "/" + boxMax;
    }

    // �ڽ��� �ı��ǰų� ��Ȱ��ȭ�� ��츦 ����� ����
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") && !collision.gameObject.activeInHierarchy)
        {
            boxesInZone.Remove(collision.gameObject);
            UpdateScore();
        }
    }
}