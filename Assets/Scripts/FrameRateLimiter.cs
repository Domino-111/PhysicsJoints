using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int frameRate;

    public void SetFrameRate()
    {
        Application.targetFrameRate = frameRate;
    }
}
