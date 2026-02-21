using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    [SerializeField] private RadioSchedule schedule;
    [SerializeField] private RadioMessageEventChannel radioEvent;
    [SerializeField] private DialogueManager dialogueManager;

    public void PlayBroadcast()
    {
        int currentDay = DayManager.Instance.CurrentDay;

        RadioMessage message = schedule.GetMessageForDay(currentDay);
        Debug.Log("Message for day " + currentDay + ": " + (message != null ? message.speakerName : "None"));

        if (message != null) dialogueManager.BeginDialogue(message.message);
        else Debug.Log("No radio message left for day.");
    }
}
