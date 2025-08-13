using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // 트럭 이동 속도
    [SerializeField] private float maxDistance = 10f; // 최대 이동 거리
    [SerializeField] private AudioClip moveSound; // 트럭 이동 효과음
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트
    private Vector2 startPosition; // 시작 위치
    private bool canMove = true; // 이동 가능 여부
    private AudioSource audioSource; // 사운드 재생용 컴포넌트

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
        // 물리 설정: 중력 영향 제거 및 회전 고정
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        // 시작 위치 저장
        startPosition = transform.position;

        // AudioSource 설정
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.loop = true; // 이동 소리 루프 설정
            audioSource.playOnAwake = false; // 시작 시 자동 재생 방지
        }

        // 이동 시작 시 소리 재생
        if (canMove && moveSound != null)
        {
            audioSource.Play();
        }

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // 오른쪽으로 일정한 속도 설정
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

            // 현재 위치와 시작 위치 간의 거리 계산
            float distanceTravelled = Mathf.Abs(transform.position.x - startPosition.x);

            // 최대 거리에 도달하면 이동 중지
            if (distanceTravelled >= maxDistance)
            {
                canMove = false;
                // 속도를 0으로 설정
                rb.linearVelocity = Vector2.zero;
                // 정확히 최대 거리 위치에 고정 (오차 방지)
                transform.position = new Vector2(startPosition.x + maxDistance, transform.position.y);

                // 이동 멈추면 소리 정지
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }

    // moveSpeed를 외부에서 가져올 수 있는 getter 메서드 추가
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public bool IsMoving()
    {
        return canMove;
    }
}