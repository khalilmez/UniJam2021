using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextArea : MonoBehaviour
{
    [SerializeField] private int nextAreaNumber;
    [SerializeField] private EnumDirection direction;
    BoxCollider areaCollider;
    // Start is called before the first frame update
    void Start()
    {
        areaCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalInformations.s_Direction = direction;
            SceneManager.LoadScene(nextAreaNumber);
        }
    }
}
