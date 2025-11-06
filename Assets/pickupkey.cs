using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public DoorWithKey doorScript; // sleep hier je DoorPivot script in

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorScript.PickupKey();
            Destroy(gameObject);
        }
    }
}
