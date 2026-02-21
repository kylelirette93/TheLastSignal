using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private PlayerController playerController;

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

        playerController.ToggleMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        dialoguePanel.SetActive(true);

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

                yield return new WaitForSeconds(1f / 20f);
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
        else
        {
            GameObject nextButton = Instantiate(buttonPrefab, buttonsParent);
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
            nextButton.GetComponent<Button>().onClick.AddListener(() => BeginDialogue(dialogue.nextDialogue));
        }
    }
}
