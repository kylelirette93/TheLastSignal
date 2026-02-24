using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;

    private void OnEnable()
    {
        stats.OnEmpathyChanged += HandleEmpathyChanged;
        stats.OnPragmatismChanged += HandlePragmatismChanged;
        stats.OnDetatchmentChanged += HandleDetatchmentChanged;
        stats.OnSanityChanged += HandleSanityChanged;
        stats.OnGuiltChanged += HandleGuiltChanged;
    }

    private void OnDestroy()
    {
        stats.OnEmpathyChanged -= HandleEmpathyChanged;
        stats.OnPragmatismChanged -= HandlePragmatismChanged;
        stats.OnDetatchmentChanged -= HandleDetatchmentChanged;
        stats.OnSanityChanged -= HandleSanityChanged;
        stats.OnGuiltChanged -= HandleGuiltChanged;
    }

    private void HandleEmpathyChanged(float value)
    {
        // Higher empathy, more guilt
    }

    private void HandlePragmatismChanged(float value)
    {
        // Higher pragmatism, less empathy.
    }

    private void HandleDetatchmentChanged(float value)
    {
        // Higher detatchment, less guilt, but also less empathy.
    }

    private void HandleSanityChanged(float value)
    {
        // Lower sanity, more likely to have hallucinations.
    }

    private void HandleGuiltChanged(float value)
    {
        // Higher guilt, more likely to have nightmares.
    }
}
