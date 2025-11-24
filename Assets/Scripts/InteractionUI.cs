using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;

    public TextMeshProUGUI interactionText;

    void Awake()
    {
        Instance = this;
        interactionText.enabled = false;
    }

    public void ShowText(string msg)
    {
        interactionText.text = msg;
        interactionText.enabled = true;
    }

    public void HideText()
    {
        interactionText.enabled = false;
    }
}
