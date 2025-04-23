using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private bool isCollected = false; // Prevents multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return; // Ignore additional triggers
        if (other.CompareTag("Player"))
        {
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            if (inventory != null)
            {
                GetComponent<Collider>().enabled = false; // Disable collider to prevent further triggers
                inventory.AddItemByTag(gameObject.tag);
                // Debug.Log("Collected a " + gameObject.tag + "tagged object.");
            }
            isCollected = true; // Mark item as collected
            Destroy(gameObject); // Destroy object after short delay
        }
    }
}
