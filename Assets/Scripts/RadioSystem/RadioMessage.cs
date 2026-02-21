using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Radio/Message")]
public class RadioMessage : ScriptableObject
{
    public string speakerName;
    public Dialogue message;
    // TODO: Audio clip in future.
}
