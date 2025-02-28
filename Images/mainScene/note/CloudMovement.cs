using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 2.0f;
    public float minTilt = -5f;
    public float maxTilt = 5f;
    private float speed;
    private Vector3 direction;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), 0).normalized;

        float tiltAngle = Mathf.Lerp(minTilt, maxTilt, Mathf.InverseLerp(-1f, 1f, direction.x));
        transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}