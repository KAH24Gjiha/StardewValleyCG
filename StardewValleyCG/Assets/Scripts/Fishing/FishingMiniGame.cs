using UnityEngine;
using UnityEngine.UI;

public class FishingMiniGame : MonoBehaviour
{
    public RectTransform playerBar;
    public RectTransform fishZone;
    public RectTransform playArea;

    public Slider progressBar;

    public float playerSpeed = 200f;
    public float fishSpeed = 100f;
    public float progress = 0f;
    public float fillSpeed = 0.3f;
    public float decaySpeed = 0.2f;
    
    private float playerVelocity = 0f;
    public float playerAccel = 500f;   // 가속도
    public float playerDrag = 5f;      // 마찰 (감속)   

    private float fishDirection = 1f;

    private bool isPressing;

    void Update()
    {
        HandlePlayerInput();
        MoveFish();
        UpdateProgress();
    }

    void HandlePlayerInput()
    {
        float input = 0f;

        if (Input.GetMouseButtonDown(0)) isPressing = true;
        else if (Input.GetMouseButtonUp(0)) isPressing = false;

        input = isPressing ? 1f : -1f;

        // 물리 기반 가속/감속 적용
        playerVelocity += input * playerAccel * Time.deltaTime;
        playerVelocity = Mathf.Lerp(playerVelocity, 0, playerDrag * Time.deltaTime); // 마찰

        playerBar.anchoredPosition += new Vector2(0, playerVelocity * Time.deltaTime);
        ClampToArea(playerBar);
    }

    void MoveFish()
    {
        fishZone.anchoredPosition += new Vector2(0, fishDirection * fishSpeed * Time.deltaTime);

        float halfHeight = fishZone.rect.height / 2f;
        float areaHalfHeight = playArea.rect.height / 2f;

        float top = fishZone.anchoredPosition.y + halfHeight;
        float bottom = fishZone.anchoredPosition.y - halfHeight;

        // 충돌 감지 시 방향 반전
        if (top >= areaHalfHeight || bottom <= -areaHalfHeight)
        {
            fishDirection *= -1f;
        }

        ClampToArea(fishZone);
    }

    void UpdateProgress()
    {
        bool isTouching = IsOverlapping(playerBar, fishZone);
        if (isTouching)
        {
            progress += fillSpeed * Time.deltaTime;
        }
        else
        {
            progress -= decaySpeed * Time.deltaTime;
        }

        progress = Mathf.Clamp01(progress);
        progressBar.value = progress;

        if (progress >= 1f)
        {
            Debug.Log("성공!");
            //this.enabled = false;
        }
    }

    bool IsOverlapping(RectTransform a, RectTransform b)
    {
        Rect ra = GetWorldRect(a);
        Rect rb = GetWorldRect(b);
        return ra.Overlaps(rb);
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        return new Rect(corners[0], corners[2] - corners[0]);
    }

    void ClampToArea(RectTransform rt)
    {
        Vector2 pos = rt.anchoredPosition;
        float halfHeight = rt.rect.height / 2f;
        float areaHalfHeight = playArea.rect.height / 2f;

        pos.y = Mathf.Clamp(pos.y, -areaHalfHeight + halfHeight, areaHalfHeight - halfHeight);
        rt.anchoredPosition = pos;
    }
}
