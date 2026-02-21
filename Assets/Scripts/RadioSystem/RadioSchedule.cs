using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Radio/Schedule")]
public class RadioSchedule : ScriptableObject
{
    [System.Serializable]
    public struct DayMessage
    {
        public int day;
        public RadioMessage message;
    }

    public List<DayMessage> messages;

    public RadioMessage GetMessageForDay(int currentDay)
    {
        foreach (var entry in messages)
        {
            if (entry.day == currentDay) return entry.message;
        }
        return null;
    }
}
