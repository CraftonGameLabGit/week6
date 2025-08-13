using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; // 장애물 프리팹
    [SerializeField] private float spawnInterval = 2f; // 스폰 간격 (초)
    [SerializeField] private float minHeight = 2f; // 최소 스폰 높이
    [SerializeField] private float maxHeight = 6f; // 최대 스폰 높이
    [SerializeField] private float spawnXPosition = 10f; // 스폰 x 위치 (화면 오른쪽 밖)

    private float timer = 0f;

    void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        // 설정된 간격마다 장애물 스폰
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // 타이머 리셋
        }
    }

    void SpawnObstacle()
    {
        // 랜덤 y 위치 계산
        float randomY = Random.Range(minHeight, maxHeight);

        // 스폰 위치 설정
        Vector2 spawnPosition = new Vector2(spawnXPosition, randomY);

        // 장애물 생성
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    // 디버깅용: 스폰 높이 범위 시각화
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            new Vector3(spawnXPosition, minHeight, 0),
            new Vector3(spawnXPosition, maxHeight, 0)
        );
    }
}