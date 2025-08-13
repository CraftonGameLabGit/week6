using UnityEngine;
using System.Collections;

public class WindZone : MonoBehaviour
{
    public Vector2 windDirection = Vector2.right; // 바람의 방향 (기본값: 오른쪽)
    public float windStrength = 5f; // 바람의 세기
    public bool isWindActive = true; // 바람 활성화 여부
    public ParticleSystem leafParticles; // 잎사귀 파티클 시스템 참조
    [SerializeField] private float windOnDuration = 5f; // 바람이 켜져 있는 시간
    [SerializeField] private float windOffDuration = 3f; // 바람이 꺼져 있는 시간

    private void Start()
    {
        // Particle System 초기화 및 재생
        if (leafParticles != null)
        {
            // 초기 바람 속도 설정
            var velocityModule = leafParticles.velocityOverLifetime;
            velocityModule.enabled = true;
            velocityModule.x = windStrength * windDirection.x * 1.5f; // 속도 증폭
            velocityModule.y = windStrength * windDirection.y * 0.5f; // 약간의 흔들림

            // 생성 속도 설정
            var emissionModule = leafParticles.emission;
            emissionModule.rateOverTime = windStrength * 0.5f; // 바람 세기에 비례

            // 초기 재생
            if (!leafParticles.isPlaying)
            {
                leafParticles.Play();
            }
        }
        else
        {
            Debug.LogWarning("LeafParticles가 할당되지 않았습니다!");
        }

        // 코루틴 시작: 바람과 파티클을 주기적으로 켜고 끔
        StartCoroutine(WindCycle());
    }

    private void Update()
    {
        // 바람이 활성화된 경우에만 파티클 업데이트
        if (leafParticles != null && isWindActive)
        {
            var velocityModule = leafParticles.velocityOverLifetime;
            velocityModule.x = windStrength * windDirection.x * 1.2f;
            velocityModule.y = windStrength * windDirection.y * 0.5f;

            var emissionModule = leafParticles.emission;
            emissionModule.rateOverTime = windStrength * 0.5f; // Start와 동일한 값으로 동기화
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isWindActive)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 바람의 힘을 드론에 적용
                rb.AddForce(windDirection.normalized * windStrength, ForceMode2D.Force);
            }
        }
    }

    // 바람 활성화/비활성화 함수
    public void SetWindActive(bool active)
    {
        isWindActive = active;
        if (leafParticles != null)
        {
            if (active)
            {
                // 파티클 시스템 초기화 및 즉시 재생
                leafParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); // 기존 파티클 제거
                leafParticles.Play();

                // Emission 즉시 설정
                var emissionModule = leafParticles.emission;
                emissionModule.rateOverTime = windStrength * 2f;

                // 디버깅 로그
                Debug.Log("Wind Active: Particle Playing");
            }
            else
            {
                // 파티클 멈춤
                leafParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Debug.Log("Wind Inactive: Particle Stopped");
            }
        }
    }

    // 바람과 파티클을 주기적으로 켜고 끄는 코루틴
    private IEnumerator WindCycle()
    {
        while (true)
        {
            // 바람 켜기
            SetWindActive(true);
            yield return new WaitForSeconds(windOnDuration);

            // 바람 끄기
            SetWindActive(false);
            yield return new WaitForSeconds(windOffDuration);
        }
    }
}