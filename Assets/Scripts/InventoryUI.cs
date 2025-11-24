using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    public GameObject panel; 
    public TextMeshProUGUI contentText;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Toggle()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            UpdateInventoryUI();
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateInventoryUI()
    {
        var items = Inventory.Instance.GetInventory();
        contentText.text = "";

        foreach (var kv in items)
        {
            var t = kv.Value;
            contentText.text += 
                $"{t.truffleType} ({t.truffleClass}) - {t.weight}g x {t.quantity}\n";
        }
    }
}
