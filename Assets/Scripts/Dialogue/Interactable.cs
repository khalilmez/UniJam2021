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
        if (other.gameObject.tag == "Player")
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, Vector3.Normalize(other.transform.position - transform.position) * 3, out raycastHit))
            {
                canvas.alpha = 1- raycastHit.distance/4 +0.1f;
            }
            MainCharacterController.Instance.TargetDialog = this.transform.parent.gameObject.GetComponent<CharacterDialog>().dialogueStart;
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
