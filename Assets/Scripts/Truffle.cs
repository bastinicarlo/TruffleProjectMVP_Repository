using UnityEngine;

public class Truffle : MonoBehaviour
{
    public string truffleClass;      // e.g. "Rare", "Common"
    public string truffleType;       // e.g. "Black Truffle", "White Truffle"
    public float weight;             // grams
    public PickupMinigame pickupMinigame;  // Future system, placeholder for now

    public float interactRange = 2f; // Distance player must be within to pick up

    bool minigameRunning = false;

    public bool CanPlayerPickUp(Transform player)
    {
        return Vector3.Distance(player.position, transform.position) <= interactRange;
    }

    public void OnPickUp()
    {
        if (minigameRunning) return;
        minigameRunning = true;

        pickupMinigame.StartMinigame(
            () =>
            {
                Debug.Log("Truffle picked up with reflex success!");
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
