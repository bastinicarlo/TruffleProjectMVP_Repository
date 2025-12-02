using UnityEngine;
using UnityEngine.UI;

public class PickupReflexMiniggame : PickupMinigame
{
    public GameObject uiRoot;          // The whole minigame canvas panel
    public RectTransform greenZone;    // Moving zone
    public RectTransform bar;          // The bar the zone moves in

    public float speed = 250f;         // Speed of the green zone
    private bool movingRight = true;

    private System.Action onSuccess;
    private System.Action onFail;

    private bool running = false;

    void Start()
    {
        uiRoot.SetActive(false);
    }

    public override void StartMinigame(System.Action success, System.Action fail)
    {
        onSuccess = success;
        onFail = fail;

        greenZone.anchoredPosition = new Vector2(Random.Range(-200, 200), 0);

        uiRoot.SetActive(true);
        running = true;
    }


    void Update()
    {
        if (!running) return;

        MoveGreenZone();

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckResult();
        }
    }

    void MoveGreenZone()
    {
        float halfWidth = bar.rect.width / 2f;
        float zoneHalf = greenZone.rect.width / 2f;

        // Move left-right
        float x = greenZone.anchoredPosition.x;
        x += (movingRight ? speed : -speed) * Time.deltaTime;

        // Bounce on the edges
        if (x > halfWidth - zoneHalf)
        {
            movingRight = false;
            x = halfWidth - zoneHalf;
        }
        else if (x < -halfWidth + zoneHalf)
        {
            movingRight = true;
            x = -halfWidth + zoneHalf;
        }

        greenZone.anchoredPosition = new Vector2(x, 0);
    }

    void CheckResult()
    {
        // The cursor is at x = 0
        float zoneLeft = greenZone.anchoredPosition.x - (greenZone.rect.width / 2f);
        float zoneRight = greenZone.anchoredPosition.x + (greenZone.rect.width / 2f);

        bool hit = zoneLeft <= 0 && 0 <= zoneRight;

        uiRoot.SetActive(false);
        running = false;

        if (hit) onSuccess?.Invoke();
        else onFail?.Invoke();
    }
}
