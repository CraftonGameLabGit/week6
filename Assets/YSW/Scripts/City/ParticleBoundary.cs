using UnityEngine;

public class ParticleBoundary : MonoBehaviour
{
    public Vector3 boundaryMin; // 범위 최소값 (예: -10, -10, -10)
    public Vector3 boundaryMax; // 범위 최대값 (예: 10, 10, 10)

    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    void Update()
    {
        int numParticles = particleSystem.GetParticles(particles);

        for (int i = 0; i < numParticles; i++)
        {
            Vector3 pos = particles[i].position;
            // 범위를 벗어났는지 확인
            if (pos.x < boundaryMin.x || pos.x > boundaryMax.x ||
                pos.y < boundaryMin.y || pos.y > boundaryMax.y ||
                pos.z < boundaryMin.z || pos.z > boundaryMax.z)
            {
                particles[i].remainingLifetime = 0; // 파티클 제거
            }
        }

        particleSystem.SetParticles(particles, numParticles);
    }
}