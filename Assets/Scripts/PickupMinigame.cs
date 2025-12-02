using UnityEngine;

public class PickupMinigame : MonoBehaviour
{
    public virtual void StartMinigame(System.Action success, System.Action fail)
    {
        Debug.Log("Starting pickup minigame...");
    }
}
