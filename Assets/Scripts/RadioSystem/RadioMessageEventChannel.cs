using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/Radio Message Event")]
public class RadioMessageEventChannel : ScriptableObject
{
    public Action<RadioMessage> OnRaised;

    public void Raise(RadioMessage message)
    {
        OnRaised?.Invoke(message);
    }
}
