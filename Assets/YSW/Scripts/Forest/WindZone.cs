using UnityEngine;
using System.Collections;

public class WindZone : MonoBehaviour
{
    public Vector2 windDirection = Vector2.right; // �ٶ��� ���� (�⺻��: ������)
    public float windStrength = 5f; // �ٶ��� ����
    public bool isWindActive = true; // �ٶ� Ȱ��ȭ ����
    public ParticleSystem leafParticles; // �ٻ�� ��ƼŬ �ý��� ����
    [SerializeField] private float windOnDuration = 5f; // �ٶ��� ���� �ִ� �ð�
    [SerializeField] private float windOffDuration = 3f; // �ٶ��� ���� �ִ� �ð�

    private void Start()
    {
        // Particle System �ʱ�ȭ �� ���
        if (leafParticles != null)
        {
            // �ʱ� �ٶ� �ӵ� ����
            var velocityModule = leafParticles.velocityOverLifetime;
            velocityModule.enabled = true;
            velocityModule.x = windStrength * windDirection.x * 1.5f; // �ӵ� ����
            velocityModule.y = windStrength * windDirection.y * 0.5f; // �ణ�� ��鸲

            // ���� �ӵ� ����
            var emissionModule = leafParticles.emission;
            emissionModule.rateOverTime = windStrength * 0.5f; // �ٶ� ���⿡ ���

            // �ʱ� ���
            if (!leafParticles.isPlaying)
            {
                leafParticles.Play();
            }
        }
        else
        {
            Debug.LogWarning("LeafParticles�� �Ҵ���� �ʾҽ��ϴ�!");
        }

        // �ڷ�ƾ ����: �ٶ��� ��ƼŬ�� �ֱ������� �Ѱ� ��
        StartCoroutine(WindCycle());
    }

    private void Update()
    {
        // �ٶ��� Ȱ��ȭ�� ��쿡�� ��ƼŬ ������Ʈ
        if (leafParticles != null && isWindActive)
        {
            var velocityModule = leafParticles.velocityOverLifetime;
            velocityModule.x = windStrength * windDirection.x * 1.2f;
            velocityModule.y = windStrength * windDirection.y * 0.5f;

            var emissionModule = leafParticles.emission;
            emissionModule.rateOverTime = windStrength * 0.5f; // Start�� ������ ������ ����ȭ
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isWindActive)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // �ٶ��� ���� ��п� ����
                rb.AddForce(windDirection.normalized * windStrength, ForceMode2D.Force);
            }
        }
    }

    // �ٶ� Ȱ��ȭ/��Ȱ��ȭ �Լ�
    public void SetWindActive(bool active)
    {
        isWindActive = active;
        if (leafParticles != null)
        {
            if (active)
            {
                // ��ƼŬ �ý��� �ʱ�ȭ �� ��� ���
                leafParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); // ���� ��ƼŬ ����
                leafParticles.Play();

                // Emission ��� ����
                var emissionModule = leafParticles.emission;
                emissionModule.rateOverTime = windStrength * 2f;

                // ����� �α�
                Debug.Log("Wind Active: Particle Playing");
            }
            else
            {
                // ��ƼŬ ����
                leafParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Debug.Log("Wind Inactive: Particle Stopped");
            }
        }
    }

    // �ٶ��� ��ƼŬ�� �ֱ������� �Ѱ� ���� �ڷ�ƾ
    private IEnumerator WindCycle()
    {
        while (true)
        {
            // �ٶ� �ѱ�
            SetWindActive(true);
            yield return new WaitForSeconds(windOnDuration);

            // �ٶ� ����
            SetWindActive(false);
            yield return new WaitForSeconds(windOffDuration);
        }
    }
}