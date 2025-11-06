using UnityEngine;

public class BooOrbitAlt : MonoBehaviour
{
    public Transform centerPoint;
    public float orbitSpeed = 0.33f;   // snelheid (hoeveel rondjes per seconde)
    public float radius = 3f;       // straal

    private float angle = 0f;

    void Update()
    {
        if (centerPoint == null) return;

        angle += orbitSpeed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position = centerPoint.position + new Vector3(x, 0, z);
    }
}
