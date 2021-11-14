using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    public void NextPage()
    {
        LogManager.Instance.NextPage();
    }
    public void PreviousPage()
    {
        LogManager.Instance.PreviousPage();
    }
}
