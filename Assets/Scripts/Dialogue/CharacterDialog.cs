using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public int characterId;
    public Dialogue dialogueStart;
    [SerializeField]
    private List<Dialogue> dialogStartList;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Helo Player");
            DialogDisplay.Instance.dialogue = this.dialogueStart;
        }
    }

    private void Update()
    {
        Debug.Log(GlobalInformations.s_characters_dialog_index[characterId]);
        if (GlobalInformations.s_characters_dialog_index[characterId] == -1)
        {
            dialogueStart = null;
        }
        else { dialogueStart = dialogStartList[GlobalInformations.s_characters_dialog_index[characterId]]; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Helo Player");
            DialogDisplay.Instance.dialogue = null;
        }

    }
}
