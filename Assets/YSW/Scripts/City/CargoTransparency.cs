using UnityEngine;

public class CargoTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cargoSprite; // 짐칸 스프라이트 렌더러
    [SerializeField] private Transform player; // 플레이어 Transform
    [SerializeField] private float detectionRange = 3f; // 플레이어 감지 거리
    [SerializeField] private float fadeSpeed = 2f; // 투명도 변화 속도

    private float targetAlpha; // 목표 투명도
    private Color spriteColor; // 현재 스프라이트 색상

    void Start()
    {
        // 초기 설정
        if (cargoSprite == null)
        {
            cargoSprite = GetComponent<SpriteRenderer>();
        }
        spriteColor = cargoSprite.color;
        targetAlpha = 1f; // 기본은 불투명
    }

    void Update()
    {
        // 플레이어와 짐칸 간의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 감지 거리 내에 있으면 투명하게, 아니면 불투명하게
        targetAlpha = distanceToPlayer <= detectionRange ? 0.3f : 1f;

        // 현재 투명도 가져오기
        float currentAlpha = cargoSprite.color.a;

        // 부드럽게 투명도 변화
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);

        // 스프라이트 색상에 새로운 투명도 적용
        spriteColor.a = newAlpha;
        cargoSprite.color = spriteColor;
    }

    // 디버깅용: 감지 범위 시각화 (에디터에서만 보임)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}