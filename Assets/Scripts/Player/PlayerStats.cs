using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float Empathy = 25f;
    public float Pragmatism = 25f;
    public float Detatchment = 25f;
    public float Guilt = 25f;

    public float MaxSanity = 100f;
    public float CurrentSanity = 100f;

    public event Action<float> OnEmpathyChanged;
    public event Action<float> OnPragmatismChanged;
    public event Action<float> OnDetatchmentChanged;
    public event Action<float> OnGuiltChanged;
    public event Action<float> OnSanityChanged;

    public void ChangeEmpathy(float amount)
    {
        Empathy = Mathf.Clamp(Empathy + amount, 0f, 100f);
        OnEmpathyChanged?.Invoke(Empathy);
    }

    public void ChangePragmatism(float amount)
    {
        Pragmatism = Mathf.Clamp(Pragmatism + amount, 0f, 100f);
        OnPragmatismChanged?.Invoke(Pragmatism);
    }

    public void ChangeDetatchment(float amount)
    {
        Detatchment = Mathf.Clamp(Detatchment + amount, 0f, 100f);
        OnDetatchmentChanged?.Invoke(Detatchment);
    }

    public void ChangeGuilt(float amount)
    {
        Guilt = Mathf.Clamp(Guilt + amount, 0f, 100f);
        OnGuiltChanged?.Invoke(Guilt);
    }
    public void ChangeSanity(float amount)
    {
        CurrentSanity += amount;
        CurrentSanity = Mathf.Clamp(CurrentSanity, 0f, MaxSanity);
        OnSanityChanged?.Invoke(CurrentSanity);
    }
}
