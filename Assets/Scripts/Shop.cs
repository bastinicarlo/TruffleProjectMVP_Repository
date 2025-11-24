using UnityEngine;

public class Shop : MonoBehaviour
{
    public float basePrice = 100f;   
    public float classMultiplier = 1f;
    public float typeMultiplier = 1f;
    public float weightMultiplier = 1f;

    public float interactDistance = 3f;

    public Transform player;

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SellAllTruffles();
            }
        }
    }

    void SellAllTruffles()
    {
        var items = Inventory.Instance.SellAll();

        float totalEarned = 0;

        foreach (var kv in items)
        {
            var truffle = kv.Value;

            float price =
                basePrice *
                classMultiplier *
                typeMultiplier *
                (truffle.weight * weightMultiplier);

            totalEarned += price * truffle.quantity;
        }

        Debug.Log($"SHOP: Hai venduto tutto per {totalEarned} euro.");
    }
}
