using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyingObstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f; // 장애물 이동 속도 (오른쪽 -> 왼쪽)
    private Rigidbody2D rb;
    private float leftBoundary = -90f; // 화면 밖으로 나가면 제거될 x 위치

    public Sprite[] birdFlying;
    public float animationSpeed = 0.1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimateFireball());
        // Rigidbody2D 설정
        rb = GetComponent<Rigidbody2D>();
        rb.useFullKinematicContacts = true; // 충돌 감지를 위해 활성화
        rb.gravityScale = 0f; // 중력 제거
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 회전 고정
    }

    void FixedUpdate()
    {
        // Kinematic 이동: 속도로 직접 제어
        rb.linearVelocity = new Vector2(-moveSpeed, 0f);

        // 화면 밖으로 나가면 제거
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AnimateFireball()
    {
        int index = 0;
        while (true)
        {
            spriteRenderer.sprite = birdFlying[index];
            index = (index + 1) % birdFlying.Length;
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}