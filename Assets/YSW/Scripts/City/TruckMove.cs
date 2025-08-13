using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Ʈ�� �̵� �ӵ�
    [SerializeField] private float maxDistance = 10f; // �ִ� �̵� �Ÿ�
    [SerializeField] private AudioClip moveSound; // Ʈ�� �̵� ȿ����
    private Rigidbody2D rb; // Rigidbody2D ������Ʈ
    private Vector2 startPosition; // ���� ��ġ
    private bool canMove = true; // �̵� ���� ����
    private AudioSource audioSource; // ���� ����� ������Ʈ

    void Start()
    {
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
        // ���� ����: �߷� ���� ���� �� ȸ�� ����
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        // ���� ��ġ ����
        startPosition = transform.position;

        // AudioSource ����
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.loop = true; // �̵� �Ҹ� ���� ����
            audioSource.playOnAwake = false; // ���� �� �ڵ� ��� ����
        }

        // �̵� ���� �� �Ҹ� ���
        if (canMove && moveSound != null)
        {
            audioSource.Play();
        }

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // ���������� ������ �ӵ� ����
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

            // ���� ��ġ�� ���� ��ġ ���� �Ÿ� ���
            float distanceTravelled = Mathf.Abs(transform.position.x - startPosition.x);

            // �ִ� �Ÿ��� �����ϸ� �̵� ����
            if (distanceTravelled >= maxDistance)
            {
                canMove = false;
                // �ӵ��� 0���� ����
                rb.linearVelocity = Vector2.zero;
                // ��Ȯ�� �ִ� �Ÿ� ��ġ�� ���� (���� ����)
                transform.position = new Vector2(startPosition.x + maxDistance, transform.position.y);

                // �̵� ���߸� �Ҹ� ����
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }

    // moveSpeed�� �ܺο��� ������ �� �ִ� getter �޼��� �߰�
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public bool IsMoving()
    {
        return canMove;
    }
}