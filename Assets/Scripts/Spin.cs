using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
