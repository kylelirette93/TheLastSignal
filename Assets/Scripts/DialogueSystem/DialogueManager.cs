using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UnityEvent dialogueStartedEvent;
    [SerializeField] private UnityEvent dialogueEndedEvent;
    [SerializeField] private PlayerStats stats;

    public void BeginDialogue(Dialogue dialogue)
    {
        /*if (dialogue.Choices.Count == 0)
        {
            dialoguePanel.SetActive(false);

            playerController.ToggleMovement(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            return;
        }*/

        ChoiceType choice = dialogue.choice;

        AdjustStatBasedOnDialogue(choice);

        playerController.ToggleMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialoguePanel.SetActive(true);
        dialogueStartedEvent.Invoke();

        ClearChoices();
        AnimateText(dialogue);
    }

    private void ClearChoices()
    {
        foreach (Transform child in buttonsParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void AnimateText(Dialogue dialogue)
    {
        IEnumerator TypeText(string text)
        {
            StringBuilder textToShow = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                textToShow.Append(text[i]);
                dialogueText.text = textToShow.ToString();

                if (!char.IsWhiteSpace(text[i]))
                {
                    SoundSO typewriterSound = AudioLibrary.Instance.GetSound("typewriter");
                    AudioManager.Instance.PlaySoundFromRadio(typewriterSound);
                }
                yield return new WaitForSeconds(1f / 35f);
            }
            ShowChoices(dialogue);
        }
        StartCoroutine(TypeText(dialogue.DialogueText));
    }

    private void ShowChoices(Dialogue dialogue)
    {
        if (dialogue.Choices.Count > 0)
        {
            foreach (Dialogue choice in dialogue.Choices)
            {
                GameObject newButton = Instantiate(buttonPrefab, buttonsParent);
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.OptionName;
                newButton.GetComponent<Button>().onClick.AddListener(() => BeginDialogue(choice));
            }
        }
        else if (dialogue.nextDialogue != null)
        {
            GameObject nextButton = Instantiate(buttonPrefab, buttonsParent);
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
            nextButton.GetComponent<Button>().onClick.AddListener(() => BeginDialogue(dialogue.nextDialogue));
        }
        else
        {
            GameObject exitButton = Instantiate(buttonPrefab, buttonsParent);
            exitButton.GetComponentInChildren<TextMeshProUGUI>().text = "End Signal";
            exitButton.GetComponent<Button>().onClick.AddListener(() => EndConversation());
        }
    }

    private void EndConversation()
    {
        dialoguePanel.SetActive(false);
        dialogueEndedEvent.Invoke();
        playerController.ToggleMovement(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void AdjustStatBasedOnDialogue(ChoiceType choice)
    {
        switch (choice)
        {
            case ChoiceType.Warm:
                stats.ChangeEmpathy(5f);
                stats.ChangeGuilt(2f);
                stats.ChangeSanity(-3f);
                break;
            case ChoiceType.Sensible:
                stats.ChangePragmatism(5f);
                stats.ChangeEmpathy(-2f);
                stats.ChangeSanity(3f);
                break;
            case ChoiceType.Cold:
                stats.ChangeDetatchment(5f);
                stats.ChangeGuilt(-3f);
                stats.ChangeEmpathy(-2f);
                break;
        }
    }
}
