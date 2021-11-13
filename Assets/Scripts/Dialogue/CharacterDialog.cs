using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public int characterId;
    public Dialogue dialogueStart;
    [SerializeField]
    private List<Dialogue> dialogStartList;
    [SerializeField] public Sprite characterFace;

    private void Update()
    {
        
        if (GlobalInformations.s_characters_dialog_index[characterId] == -1)
        {
            dialogueStart = null;
        }
        else { dialogueStart = dialogStartList[GlobalInformations.s_characters_dialog_index[characterId]]; }
    }
}
