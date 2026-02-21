using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : Singleton<DayManager>
{
    public int CurrentDay { get; private set; } = 1;
    public override void Awake()
    {
        base.Awake();
    }
}
