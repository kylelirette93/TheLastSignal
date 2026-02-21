using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Transform radio;
    [SerializeField] private AudioSource sfxSource;
    public override void Awake()
    {
        base.Awake();
    }

    public void PlaySoundFromRadio(SoundSO soundSO)
    {
        if (soundSO == null) return;

        AudioSource.PlayClipAtPoint(soundSO.AudioClip, radio.position);
    }
}
