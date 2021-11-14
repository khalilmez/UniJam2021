using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : Singleton<LogManager>
{
    [SerializeField]
    private GameObject Log;
    [SerializeField]
    private List<GameObject> pages;
    [SerializeField]
    private int page = 0;
    [SerializeField]
    private CanvasGroup logCanvas;
    public static LogManager Instance
    {
        get => instance;
    }

    public override void Awake()
    {
        base.Awake();

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    public void DisplayLog()
    {
        Debug.Log("Test");
        if (Log == null)
        {
            Debug.Log("Test1");
            Log = GameObject.Find("Log");
            if(Log != null)
            {
                logCanvas = Log.GetComponent<CanvasGroup>();
                pages = new List<GameObject>(3);
                foreach (Transform child in Log.transform)
                {
                    if (child.name != "Suivant" && child.name != "Précédent")
                    {
                        pages.Add(child.gameObject);
                    }
                }
            }
        }
        if (logCanvas.alpha == 1)
        {
            logCanvas.alpha = 0;
            logCanvas.interactable = false;
            logCanvas.blocksRaycasts = false;
        }
        else
        {
            logCanvas.alpha = 1;
            logCanvas.interactable = true;
            logCanvas.blocksRaycasts = true;
        }
    }
    public void NextPage()
    {
        Debug.LogWarning("Hello world");
        if (page < pages.Count - 1)
        {
            pages[page].GetComponent<CanvasGroup>().alpha = 0;
            page++;
            pages[page].GetComponent<CanvasGroup>().alpha = 1;
        }
    }
    public void PreviousPage()
    {
        if (0 < page)
        {
            pages[page].GetComponent<CanvasGroup>().alpha = 0;
            page--;
            pages[page].GetComponent<CanvasGroup>().alpha = 1;
        }
    }

}
