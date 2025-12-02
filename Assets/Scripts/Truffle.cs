using UnityEngine;

public class Truffle : MonoBehaviour
{
    public string truffleClass;      
    public string truffleType;       
    public float weight;             
    public PickupMinigame pickupMinigame;  

    public float interactRange = 2f; 

    bool minigameRunning = false;

    public bool CanPlayerPickUp(Transform player)
    {
        return Vector3.Distance(player.position, transform.position) <= interactRange;
    }

    public void OnPickUp()
    {
        Debug.Log("Trying to pickup Truffle: " + truffleType);

        if (minigameRunning) return;
        minigameRunning = true;

        pickupMinigame.StartMinigame(
            () =>
            {
                Debug.Log("Truffle picked up with reflex success!");
                Inventory.Instance.AddTruffle(this);
                Destroy(gameObject);
            },
            () =>
            {
                Debug.Log("Failed reflex. Try again.");
                minigameRunning = false;
            }
        );
    }

}
