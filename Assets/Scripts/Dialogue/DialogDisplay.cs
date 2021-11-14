using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogDisplay : MonoBehaviour
{
    public static DialogDisplay Instance { get; private set; }
    [SerializeField]
    private CanvasGroup mainCanvas;
    [SerializeField]
    private CanvasGroup dialogCanvas;
    [SerializeField]
    private CanvasGroup choiceCanvas;

    public Sprite characterFace;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI description;
    public List<DialogueChoice> choicesList = new List<DialogueChoice>();
    public bool IsActive()
    {
        if (canvas == null)
        {
            canvas = this.gameObject.GetComponent<CanvasGroup>();
        }
        return canvas.alpha > 0;
    }
    public Dictionary<string, Choice> choicesDictionary;

    private List<Choice> choices;
    public Dialogue dialogue{ get; set; }

    public void Init() => Instance = this;

    private void Update()
    {
        Instance = this;
    }

    public void Show()
    {
        mainCanvas.transform.GetChild(0).GetComponent<Image>().sprite = characterFace;
        description.text = dialogue.description;
        if (dialogue.isKeyDialog)
        {
           
            GlobalInformations.s_characters_dialog_index[dialogue.characterIndex]=dialogue.id;
           
        }

        if (dialogue.isEndDialog)
        {
            GlobalInformations.s_characters_dialog_index[dialogue.characterIndex] = -1;
        }
        
        choices = new List<Choice>();

        choicesDictionary = new Dictionary<string, Choice>();
        foreach (Choice choice in dialogue.choices)
        {
            choices.Add(choice);
        }

        //reset choices
        choicesList.ForEach(x => x.gameObject.SetActive(false));
        choicesList.ForEach(x => x.init());
        int i = 0;
        foreach (DialogueChoice choice in choicesList)
        {

            if (i < choices.Count && choices[i] != null)
            {
                choice.Content = choices[i];
                choicesDictionary.Add(choice.name, choices[i]);
                choice.gameObject.SetActive(true);
            }
            else
            {
                choice.gameObject.SetActive(false);
            }

            i++;
        }
        mainCanvas.alpha = 1;
        mainCanvas.interactable = true;
        mainCanvas.blocksRaycasts = true;
        description.text = dialogue.description;
    }


    public void Submit(DialogueChoice choice)
    {
        if (choice.Content != null)
        {
            LevelOfSuspicien.Instance.AddLevelOfSuspencience(choice.Content.suspicion);
            if(choice.Content.hint != "")
            {
                GameObject gameObject = GameObject.Find(choice.Content.hint);
                if(gameObject != null)
                {
                    Debug.LogError("YEEEY");
                    gameObject.GetComponent<CanvasGroup>().alpha = 1;
                }

            }
            if (choice.Content.conclusion != null)
            {
                dialogue = choice.Content.conclusion;
                HideChoices();
                Show();
            }
            else
            {
                Close();
            }
        }
        else
        {
            Close();
        }
    }

    public void Close()
    {
        mainCanvas.interactable = false;
        mainCanvas.blocksRaycasts = false;
        StartCoroutine(CloseDialogue());
    }

    private IEnumerator CloseDialogue()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            mainCanvas.alpha = mainCanvas.alpha * 0.8f;
            yield return new WaitForSeconds(.05f);
        }

        mainCanvas.alpha = 0;
        yield return null;
    }

    public void ShowChoices()
    {
        dialogCanvas.alpha = 0;
        dialogCanvas.blocksRaycasts = false;
        dialogCanvas.interactable = false;

        choiceCanvas.alpha = 1;
        choiceCanvas.blocksRaycasts = true;
        choiceCanvas.interactable = true;
    }

    public void HideChoices()
    {
        dialogCanvas.alpha = 1;
        dialogCanvas.blocksRaycasts = true;
        dialogCanvas.interactable = true;

        choiceCanvas.alpha = 0;
        choiceCanvas.blocksRaycasts = false;
        choiceCanvas.interactable = false;
    }

}
