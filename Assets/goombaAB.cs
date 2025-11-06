using UnityEngine;

public class GoombaBody : MonoBehaviour
{
    public Transform pointA;   // startpositie
    public Transform pointB;   // eindpositie
    public float speed = 2f;   // loopsnelheid

    private Transform target;

    void Start()
    {
        target = pointB; // begin door naar B te lopen
    }

    void Update()
    {
        // Beweeg richting het doel
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Wissel doel als we dichtbij zijn
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
