using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyingObstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f; // ��ֹ� �̵� �ӵ� (������ -> ����)
    private Rigidbody2D rb;
    private float leftBoundary = -90f; // ȭ�� ������ ������ ���ŵ� x ��ġ

    public Sprite[] birdFlying;
    public float animationSpeed = 0.1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimateFireball());
        // Rigidbody2D ����
        rb = GetComponent<Rigidbody2D>();
        rb.useFullKinematicContacts = true; // �浹 ������ ���� Ȱ��ȭ
        rb.gravityScale = 0f; // �߷� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ȸ�� ����
    }

    void FixedUpdate()
    {
        // Kinematic �̵�: �ӵ��� ���� ����
        rb.linearVelocity = new Vector2(-moveSpeed, 0f);

        // ȭ�� ������ ������ ����
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