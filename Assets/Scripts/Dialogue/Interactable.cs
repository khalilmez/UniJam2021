using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hintText;
    [SerializeField]
    private CanvasGroup canvas;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && transform.parent.GetComponent<CharacterDialog>().dialogueStart !=null)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, Vector3.Normalize(other.transform.position - transform.position) * 3, out raycastHit))
            {
                canvas.alpha = 1- raycastHit.distance/4 +0.1f;
            }
            DialogDisplay.Instance.characterFace = this.transform.parent.gameObject.GetComponent<CharacterDialog>().characterFace;
            MainCharacterController.Instance.TargetDialog = this.transform.parent.gameObject.GetComponent<CharacterDialog>().dialogueStart;
        }
        if(transform.parent.GetComponent<CharacterDialog>().dialogueStart == null)
        {
            canvas.alpha = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canvas.alpha = 0;
            MainCharacterController.Instance.TargetDialog = null;
        }
    }
}
