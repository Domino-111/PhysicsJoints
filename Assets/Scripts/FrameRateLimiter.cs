using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int frameRate;

    void Start()
    {

    }

    public void SetFrameRate()
    {
        Application.targetFrameRate = frameRate;
    }
}
