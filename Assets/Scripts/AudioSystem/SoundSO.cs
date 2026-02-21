using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio System/Sound")]
public class SoundSO : ScriptableObject
{
    public string soundID;
    public AudioClip AudioClip;
}
