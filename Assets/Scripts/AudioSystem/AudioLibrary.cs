using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : Singleton<AudioLibrary>
{
    [SerializeField] private List<SoundSO> sounds;

    public override void Awake()
    {
        base.Awake();
    }
    public SoundSO GetSound(string soundID)
    {
        foreach (SoundSO sound in sounds)
        {
            if (sound.soundID == soundID)
            {
                return sound;
            }
        }
        Debug.LogWarning($"Sound with ID {soundID} not found in AudioLibrary.");
        return null;
    }
}
