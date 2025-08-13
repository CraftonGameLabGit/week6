using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; // ��ֹ� ������
    [SerializeField] private float spawnInterval = 2f; // ���� ���� (��)
    [SerializeField] private float minHeight = 2f; // �ּ� ���� ����
    [SerializeField] private float maxHeight = 6f; // �ִ� ���� ����
    [SerializeField] private float spawnXPosition = 10f; // ���� x ��ġ (ȭ�� ������ ��)

    private float timer = 0f;

    void Update()
    {
        // Ÿ�̸� ����
        timer += Time.deltaTime;

        // ������ ���ݸ��� ��ֹ� ����
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // Ÿ�̸� ����
        }
    }

    void SpawnObstacle()
    {
        // ���� y ��ġ ���
        float randomY = Random.Range(minHeight, maxHeight);

        // ���� ��ġ ����
        Vector2 spawnPosition = new Vector2(spawnXPosition, randomY);

        // ��ֹ� ����
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    // ������: ���� ���� ���� �ð�ȭ
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            new Vector3(spawnXPosition, minHeight, 0),
            new Vector3(spawnXPosition, maxHeight, 0)
        );
    }
}