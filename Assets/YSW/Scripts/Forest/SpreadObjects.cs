using UnityEngine;

public class SpreadObjects : MonoBehaviour
{
    public GameObject targetObject; // �л��ų ������Ʈ�� �θ� ������Ʈ
    public Vector2 spreadArea = new Vector2(10f, 10f); // �л�� ���� ũ�� (x, y)

    [ContextMenu("Spread Objects")]
    void Spread()
    {
        // �θ� ������Ʈ �Ʒ� ��� �ڽ� ������Ʈ ��������
        foreach (Transform child in targetObject.transform)
        {
            // ������ ��ġ�� �̵�
            float randomX = Random.Range(-85, -55);
            float randomY = Random.Range(-spreadArea.y / 2, spreadArea.y / 2);
            child.position = new Vector3(randomX, randomY, child.position.z);
        }
    }
}