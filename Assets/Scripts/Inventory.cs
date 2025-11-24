using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [System.Serializable]
    public class TruffleData
    {
        public string truffleClass;
        public string truffleType;
        public float weight;
        public int quantity;
    }

    private Dictionary<string, TruffleData> truffles = new Dictionary<string, TruffleData>();

    void Awake()
    {
        Instance = this;
    }

    public void AddTruffle(Truffle truffle)
    {
        string key = truffle.truffleClass + "_" + truffle.truffleType;

        if (!truffles.ContainsKey(key))
        {
            truffles[key] = new TruffleData
            {
                truffleClass = truffle.truffleClass,
                truffleType = truffle.truffleType,
                weight = truffle.weight,
                quantity = 0
            };
        }

        truffles[key].quantity++;

        Debug.Log($"Added 1 {truffle.truffleType}. Total: {truffles[key].quantity}");
    }

    public Dictionary<string, TruffleData> GetInventory()
    {
        return truffles;
    }

    public Dictionary<string, TruffleData> SellAll()
    {
        var soldCopy = new Dictionary<string, TruffleData>(truffles);
        truffles.Clear();
        return soldCopy;
    }
}
