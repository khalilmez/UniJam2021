using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private AudioClip WinMusic;

    [SerializeField]
    private CanvasGroup WinMenu;
    [SerializeField]
    private CanvasGroup LoseMenu;
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
    void Start()
    {
        WinMenu.alpha = 0;
        LoseMenu.alpha = 0;
    }
    void Update()
    {
        if (LevelOfSuspicien.Instance.Lost)
        {
            if (LoseMenu == null)
            {
                LoseMenu = GameObject.Find("LoseMenu").GetComponent<CanvasGroup>();
                LoseMenu.alpha = 1;
                LoseMenu.interactable = true;
                LoseMenu.blocksRaycasts = true;
            }
            else
            {
                LoseMenu.alpha = 1;
                LoseMenu.interactable = true;
                LoseMenu.blocksRaycasts = true;
            }
            LevelOfSuspicien.Instance.Lost = false;
            LevelOfSuspicien.Instance.LevelOfSuspicion = 0;
        }

        if (LevelOfSuspicien.Instance.Win)
        {
            LevelOfSuspicien.Instance.GetComponent<AudioSource>().clip = WinMusic;
            if (WinMenu == null)
            {
                WinMenu = GameObject.Find("LoseMenu").GetComponent<CanvasGroup>();
                WinMenu.alpha = 1;
                WinMenu.interactable = true;
                WinMenu.blocksRaycasts = true;
            }
            else
            {
                WinMenu.alpha = 1;
                WinMenu.interactable = true;
                WinMenu.blocksRaycasts = true;
            }
            LevelOfSuspicien.Instance.Win = false;
            LevelOfSuspicien.Instance.LevelOfSuspicion = 0;
        }
    }

   public void Rejouer()
    {
        Destroy(LevelOfSuspicien.Instance.gameObject);
        LoseMenu.alpha = 0;
        LoseMenu.interactable = false;
        LoseMenu.blocksRaycasts = false;
        WinMenu.alpha = 0;
        WinMenu.interactable = false;
        WinMenu.blocksRaycasts = false;
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void DisplayLog()
    {
        if (Log == null)
        {
            Log = GameObject.Find("Log");
            if(Log != null)
            {
                logCanvas = Log.GetComponent<CanvasGroup>();
                pages = new List<GameObject>(3);
                foreach (Transform child in Log.transform)
                {
                    if (child.name != "Suivant" && child.name != "Pr?c?dent")
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
