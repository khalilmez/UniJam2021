using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI contentText;
    [SerializeField] private Button button;
    private string text;
    private Choice choiceDialog;
    private bool interactible;

    public bool Interactible
    {
        get => interactible;
        set
        {
            interactible = value;
            button.interactable = interactible;
        }
    }
    public Choice Content
    {
        get => choiceDialog;
        set
        {
            choiceDialog = value;

            Text = choiceDialog.text;
        }
    }

    public string Text
    {
        get => text;
        set
        {
            text = value;
            contentText.text = text;
        }
    }
    public void Submit()
    {
        DialogDisplay.Instance.Submit(this);
    }

    public void init()
    {
        choiceDialog = null;
        Text = "";

    }
}
