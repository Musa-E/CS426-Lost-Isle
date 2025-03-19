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
                inventory.AddItemByTag(gameObject.tag);
            }

            isCollected = true; // Mark item as collected
            GetComponent<Collider>().enabled = false; // Disable collider to prevent further triggers
            Destroy(gameObject); // Destroy object after short delay
        }
    }
}
