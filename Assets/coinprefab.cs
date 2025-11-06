using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public int points = 1;
    [SerializeField] private float respawnTime = 5f;

    private Renderer rend;
    private Collider coll;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.AddScore(points);

            // coin onzichtbaar + niet meer oppakbaar
            rend.enabled = false;
            coll.enabled = false;

            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        // coin weer zichtbaar + oppakbaar
        rend.enabled = true;
        coll.enabled = true;
    }
}
