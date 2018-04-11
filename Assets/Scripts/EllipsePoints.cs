using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EllipsePoints : MonoBehaviour
{
    public float ellipseStartXLength = 0.4f;
    public float ellipseStartYLength = 0.52f;
    public float ellipseGrowRate = 1.11f;
    public float ellipseRotateAmount = 29.4f;
    public int pointsPerEllipseStart = 3;
    public int pointPerEllipseGrowRate = 11;
    public int numberOfParticles = 1000;

    private new ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        if (numberOfParticles <= particleSystem.main.maxParticles) {
            particles = new ParticleSystem.Particle[numberOfParticles];
            particleSystem.Emit(numberOfParticles);
        }
        else {
            throw new System.Exception(
                "The number of particles supplied exceeds the maximum number of particles on the particle system's main module"
                );
        }
    }

    private void Update()
    {
        GenerateGalaxy();
    }

    private void GenerateGalaxy()
    {
        particleSystem.GetParticles(particles);

        float startX = ellipseStartXLength;
        float startY = ellipseStartYLength;
        int pointsPerEllipse = pointsPerEllipseStart;
   
        float angleOffSet = 0;
        int particlesGenerated = 0;

        while (particlesGenerated < numberOfParticles) {
            Vector2[] positions = GenerateElipsePoints(pointsPerEllipse, startX, startY, angleOffSet);

            for (int p = 0; p < pointsPerEllipse; p++) {
                particles[particlesGenerated].position = new Vector3(positions[p].x, positions[p].y, 0);
                if (++particlesGenerated == numberOfParticles) {
                    break;
                }
            }
            angleOffSet += ellipseRotateAmount;
            startX *= ellipseGrowRate;
            startY *= ellipseGrowRate;
            pointsPerEllipse += pointPerEllipseGrowRate;
        }

        particleSystem.SetParticles(particles, numberOfParticles);
    }

    private Vector2[] GenerateElipsePoints(int numPoints, float xLen, float yLen, float rotation)
    {
        Vector2[] points = new Vector2[numPoints];

        for (int i = 0; i < numPoints; i++) {
            float angle = i / (float)numPoints * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * xLen;
            float y = Mathf.Cos(angle) * yLen;

            Vector2 point = new Vector2(x, y);
            Rotate(ref point, rotation);
            points[i] = point;
        }

        return points;
    }

    private void Rotate(ref Vector2 point, float rotation)
    {
        float sin = Mathf.Sin(rotation * Mathf.Deg2Rad);
        float cos = Mathf.Cos(rotation * Mathf.Deg2Rad);

        float tx = point.x;
        float ty = point.y;

        point.x = (cos * tx) - (sin * ty);
        point.y = (sin * tx) + (cos * ty);
    }
}
