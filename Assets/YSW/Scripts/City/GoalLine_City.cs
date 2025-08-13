using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class GoalLine_City : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;
    private float boxMax = 50;
    private List<GameObject> boxesInZone = new List<GameObject>(); // 영역 내 박스 목록

    [SerializeField] private AudioClip scoreUpSound; // 스코어 증가 효과음
    private AudioSource audioSource; // 사운드 재생용 컴포넌트

    private void Start()
    {
        score = 0;
        text.text = score + "/" + boxMax;

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
            // 박스가 영역에 들어오면 목록에 추가
            if (!boxesInZone.Contains(collision.gameObject))
            {
                boxesInZone.Add(collision.gameObject);
            }
            if (scoreUpSound != null)
            {
                audioSource.PlayOneShot(scoreUpSound); // 효과음 재생
            }
            UpdateScore();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            // 박스가 영역을 나가면 목록에서 제거
            boxesInZone.Remove(collision.gameObject);
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // 영역 내 박스 개수를 스코어로 설정
        score = boxesInZone.Count;
        text.text = score + "/" + boxMax;
    }

    // 박스가 파괴되거나 비활성화될 경우를 대비해 정리
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") && !collision.gameObject.activeInHierarchy)
        {
            boxesInZone.Remove(collision.gameObject);
            UpdateScore();
        }
    }
}