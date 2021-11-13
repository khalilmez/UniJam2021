using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogDisplay : MonoBehaviour
{
    public static DialogDisplay Instance { get; private set; }

    public TextMeshProUGUI Title;
    public TextMeshProUGUI description;
    public List<DialogueChoice> choicesList = new List<DialogueChoice>();
    public Dictionary<string, Choice> choicesDictionary;
    [SerializeField]
    private CanvasGroup canvas;

    private List<Choice> choices;
    public Dialogue dialogue{ get; set; }

    public void Init() => Instance = this;

    private void Awake()
    {
        Init();
    }

    public void Show()
    {
        
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
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;

    }


    public void Submit(DialogueChoice choice)
    {
        if (choice.Content != null)
        {
            if (choice.Content.conclusion != null)
            {
                dialogue = choice.Content.conclusion;
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
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
        canvas.alpha = 0;
        //StartCoroutine(CloseDialogue());
    }

    private IEnumerator CloseDialogue()
    {
        float Timer = Time.time;
        float Duration = 2;
        while ((Timer + Duration) > Time.time)
        {
            canvas.alpha = Mathf.Max(canvas.alpha * 0.8f, 0);
        }
        canvas.alpha = 0;
        yield return null;
    }
}
