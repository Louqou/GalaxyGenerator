using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EllipsePoints : MonoBehaviour
{
    [Tooltip("Width of the first ellipse")]
    public float ellipseStartXLength = 0.4f;
    [Tooltip("Height of the first ellipse")]
    public float ellipseStartYLength = 0.52f;
    [Tooltip("Size factor for each new ellipse")]
    public float ellipseGrowRate = 1.11f;
    [Tooltip("How much each new ellipse is rotated (degrees)")]
    public float ellipseRotateAmount = 29.4f;

    [Tooltip("How many particles in the first ellipse")]
    public int pointsPerEllipseStart = 3;
    [Tooltip("How many more particles in each new ellipse")]
    public int pointPerEllipseGrowRate = 11;
    [Tooltip("How many particles to spawn")]
    public int numberOfParticles = 1000;
    [Tooltip("How fast each particle orbits the ellipse")]
    public float rotationSpeed = 1f;

    // Stores a reference to the particle system
    private new ParticleSystem particleSystem;
    // Stores all the particles
    private ParticleSystem.Particle[] particles;
    // Current rotation of the particles in each ellipse
    private float currentPointRotation;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        if (numberOfParticles <= particleSystem.main.maxParticles)
        {
            particles = new ParticleSystem.Particle[numberOfParticles];
            particleSystem.Emit(numberOfParticles);
        }
        else
        {
            throw new System.Exception(
                "The number of particles supplied exceeds the maximum number of particles on the particle system's main module"
                );
        }

        GenerateGalaxy();
    }

    // Remove this if you just want a static galaxy
    private void Update()
    {
        currentPointRotation = (currentPointRotation + (rotationSpeed * Time.deltaTime)) % 360;
        GenerateGalaxy();
    }

    private void GenerateGalaxy()
    {
        particleSystem.GetParticles(particles);

        float currentEllipseXLength = ellipseStartXLength;
        float currentEllipseYLength = ellipseStartYLength;
        int currentParticlesInEllipse = pointsPerEllipseStart;

        float currentAngleOffset = 0;
        int currentNumParticlesGenerated = 0;

        // Keep generating particles up to the maximum
        while (currentNumParticlesGenerated < numberOfParticles)
        {
            // An array of positions that represents particles along one ellipse
            Vector2[] positions = GenerateElipsePoints(currentParticlesInEllipse, currentEllipseXLength, currentEllipseYLength, currentAngleOffset);

            // Loop through all positions in the ellipse and put a particle there
            for (int p = 0; p < currentParticlesInEllipse; p++)
            {
                particles[currentNumParticlesGenerated].position = new Vector3(positions[p].x, positions[p].y, 0);

                // If max number of particles is reached, exit early
                if (++currentNumParticlesGenerated == numberOfParticles)
                {
                    break;
                }
            }

            currentAngleOffset += ellipseRotateAmount;
            currentEllipseXLength *= ellipseGrowRate;
            currentEllipseYLength *= ellipseGrowRate;
            currentParticlesInEllipse += pointPerEllipseGrowRate;
        }

        particleSystem.SetParticles(particles, numberOfParticles);
    }

    /*
        Generates an array of evenly spaced positions along an ellipse

        numPoints - How many particles in the ellipse
        xLen - The width of the ellipse
        yLen - The height of the ellipse
        rotation - The rotation of the ellipse
     */
    private Vector2[] GenerateElipsePoints(int numPoints, float xLen, float yLen, float rotation)
    {
        Vector2[] points = new Vector2[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            // Angle of the particle in relation to the centre of the ellipse
            float angle = i / (float)numPoints * 360 * Mathf.Deg2Rad + currentPointRotation;

            // Position of the particle
            float x = Mathf.Sin(angle) * xLen;
            float y = Mathf.Cos(angle) * yLen;

            points[i] = new Vector2(x, y);

            // Rotate each point to rotate the whole ellipse
            Rotate(ref points[i], rotation);
        }

        return points;
    }

    // Math to rotate a 2D point about position (0,0)
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
