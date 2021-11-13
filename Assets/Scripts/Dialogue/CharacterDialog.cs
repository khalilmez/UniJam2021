using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Helo Player");
            DialogDisplay.Instance.dialogue = this.dialogue;
            DialogDisplay.Instance.Show();
        }
    }
}
