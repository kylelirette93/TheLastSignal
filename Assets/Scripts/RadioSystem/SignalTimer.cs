using UnityEngine;

public class SignalTimer : MonoBehaviour
{
    bool isSignalling = false;
    float broadcastTime = 100f;
    float maxBroadcastTime = 100f;  
    float lastCheckedSignalTime = 0f;
    float drainRate = 2f;
    bool isDirty = false;

    public void StartSignal()
    {
        if (IsDepleted()) return;
        isSignalling = true;
    }

    public void EndSignal()
    {
        isSignalling = false;
    }
    public void Update()
    {
        if (!isSignalling || IsDepleted()) return;

        lastCheckedSignalTime = broadcastTime;


        broadcastTime -= drainRate * Time.deltaTime;
        broadcastTime = Mathf.Clamp(broadcastTime, 0f, maxBroadcastTime);

        if (broadcastTime != lastCheckedSignalTime)
        {
            isDirty = true;
        }
    }

    public float GetMaxBroadcastTime()
    {
        return maxBroadcastTime;
    }
    public float GetBroadcastTime()
    {
        isDirty = false;
        return broadcastTime;
    }

    public bool IsDirty()
    {
        return isDirty;
    }

    public void RestoreSignal(float amount)
    {
        broadcastTime += amount;
        broadcastTime = Mathf.Clamp(broadcastTime, 0f, maxBroadcastTime);
    }

    public bool IsDepleted()
    {
        return broadcastTime <= 0f;
    }
}
