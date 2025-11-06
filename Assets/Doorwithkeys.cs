using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorWithKey : MonoBehaviour
{
    [Header("References")]
    public Transform doorTransform;      // assign the door (the rotating part)
    public Collider keyCollider;         // optional: assign the key collider (to destroy on pickup)
    public Text uiText;                  // UI Text to show messages (optional)

    [Header("Door settings")]
    public float openAngle = 90f;        // how far the door opens
    public float openSpeed = 2f;         // rotation speed
    public Vector3 openAxis = Vector3.up;// axis to rotate around

    [Header("Audio (optional)")]
    public AudioSource audioSource;
    public AudioClip pickupSfx;
    public AudioClip openSfx;

    // internal state
    bool hasKey = false;
    bool playerNearDoor = false;
    bool doorOpening = false;
    Quaternion closedRotation;
    Quaternion openRotation;

    void Start()
    {
        if (doorTransform == null)
            doorTransform = this.transform; // fallback

        closedRotation = doorTransform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(openAxis * openAngle);

        if (uiText != null)
            uiText.text = ""; // clear at start
    }

    // Call this when player picks up the key.
    // Option A: make the key object call PickupKey() on trigger.
    public void PickupKey()
    {
        if (hasKey) return;
        hasKey = true;
        if (uiText != null) uiText.text = "Sleutel opgepakt!";
        if (audioSource != null && pickupSfx != null) audioSource.PlayOneShot(pickupSfx);
        // optional visual feedback: change color, update HUD, etc.
    }

    // If player is near the door, they can press E to interact
    void Update()
    {
        if (playerNearDoor && Input.GetKeyDown(KeyCode.E) && !doorOpening)
        {
            if (hasKey)
                StartCoroutine(OpenDoor());
            else
                StartCoroutine(ShowTemporaryMessage("De deur is op slot. Je hebt een sleutel nodig.", 2f));
        }
    }

    IEnumerator OpenDoor()
    {
        doorOpening = true;
        if (uiText != null) uiText.text = "De deur gaat open...";
        if (audioSource != null && openSfx != null) audioSource.PlayOneShot(openSfx);

        float t = 0f;
        Quaternion start = doorTransform.localRotation;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            doorTransform.localRotation = Quaternion.Slerp(start, openRotation, t);
            yield return null;
        }

        if (uiText != null) uiText.text = "De deur is open.";
        yield return new WaitForSeconds(2f);
        if (uiText != null) uiText.text = "";
        doorOpening = false;
        // you can optionally disable the collider so player walks through without blocking
    }

    IEnumerator ShowTemporaryMessage(string msg, float seconds)
    {
        if (uiText == null) yield break;
        uiText.text = msg;
        yield return new WaitForSeconds(seconds);
        uiText.text = "";
    }

    // --------- Trigger handlers for "near door" and "key pickup" ----------
    // Note: requires proper Tags/Colliders set in Unity scene.

    void OnTriggerEnter(Collider other)
    {
        // If player enters door area, allow interaction
        if (other.CompareTag("Player"))
        {
            playerNearDoor = true;
            if (uiText != null)
                uiText.text = hasKey ? "Druk op E om de deur te openen." : "Deur (op slot) — je hebt een sleutel nodig.";
        }

        // If the player collided with the key (key object should also have collider set as trigger)
        if (other.CompareTag("Key"))
        {
            // pick up key
            PickupKey();

            // destroy the key object (so it disappears)
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = false;
            if (uiText != null)
                uiText.text = "";
        }
    }
}
