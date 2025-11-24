using UnityEngine;

public class Truffle : MonoBehaviour
{
    public string truffleClass;      
    public string truffleType;       
    public float weight;             
    public PickupMinigame pickupMinigame;  

    public float interactRange = 2f; 

    public bool CanPlayerPickUp(Transform player)
    {
        return Vector3.Distance(player.position, transform.position) <= interactRange;
    }

    public void OnPickUp()
    {
        Debug.Log("Picked up truffle: " + truffleType);

        Inventory.Instance.AddTruffle(this);

        Destroy(gameObject);
    }

}
