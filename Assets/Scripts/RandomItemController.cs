using UnityEngine;
using UnityEngine.InputSystem;

public class RandomItemController : MonoBehaviour
{
    [SerializeField]
    private string[] items = new string[10];

    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame) PrintRandomItem();
        if (Keyboard.current.escapeKey.wasPressedThisFrame) PrintAllItems();
    }

    private void PrintRandomItem()
    {
        int index = Random.Range(0, items.Length);
        Debug.Log(items[index]);
    }

    private void PrintAllItems()
    {
        foreach (string item in items)
        {
            Debug.Log(item);
        }
    }
}
