using UnityEngine;

public class CargoTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cargoSprite; // ��ĭ ��������Ʈ ������
    [SerializeField] private Transform player; // �÷��̾� Transform
    [SerializeField] private float detectionRange = 3f; // �÷��̾� ���� �Ÿ�
    [SerializeField] private float fadeSpeed = 2f; // ���� ��ȭ �ӵ�

    private float targetAlpha; // ��ǥ ����
    private Color spriteColor; // ���� ��������Ʈ ����

    void Start()
    {
        // �ʱ� ����
        if (cargoSprite == null)
        {
            cargoSprite = GetComponent<SpriteRenderer>();
        }
        spriteColor = cargoSprite.color;
        targetAlpha = 1f; // �⺻�� ������
    }

    void Update()
    {
        // �÷��̾�� ��ĭ ���� �Ÿ� ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // ���� �Ÿ� ���� ������ �����ϰ�, �ƴϸ� �������ϰ�
        targetAlpha = distanceToPlayer <= detectionRange ? 0.3f : 1f;

        // ���� ���� ��������
        float currentAlpha = cargoSprite.color.a;

        // �ε巴�� ���� ��ȭ
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);

        // ��������Ʈ ���� ���ο� ���� ����
        spriteColor.a = newAlpha;
        cargoSprite.color = spriteColor;
    }

    // ������: ���� ���� �ð�ȭ (�����Ϳ����� ����)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}