using UnityEngine;

public class SpreadObjects : MonoBehaviour
{
    public GameObject targetObject; // 분산시킬 오브젝트의 부모 오브젝트
    public Vector2 spreadArea = new Vector2(10f, 10f); // 분산될 영역 크기 (x, y)

    [ContextMenu("Spread Objects")]
    void Spread()
    {
        // 부모 오브젝트 아래 모든 자식 오브젝트 가져오기
        foreach (Transform child in targetObject.transform)
        {
            // 랜덤한 위치로 이동
            float randomX = Random.Range(-85, -55);
            float randomY = Random.Range(-spreadArea.y / 2, spreadArea.y / 2);
            child.position = new Vector3(randomX, randomY, child.position.z);
        }
    }
}