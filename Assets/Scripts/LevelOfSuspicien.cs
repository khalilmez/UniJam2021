using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelOfSuspicien : Singleton<LevelOfSuspicien>
{
    public static LevelOfSuspicien Instance
    {
        get => instance;
    }
    [SerializeField]
    private static int levelOfSuspicion = 0;

    public static bool lost = false;
    public bool Lost
    {
        get => lost; set
        {
            lost = value;
        }
    }

    public static bool win = false;
    public bool Win
    {
        get => win; set
        {
            win = value;
        }
    }
    public static int Level { get => levelOfSuspicion; set {
            levelOfSuspicion = value;
        } }
    
    [SerializeField]
    private Scrollbar scrollBar;

    public override void Awake()
    {
        base.Awake();

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scrollBar != null)
        {
            scrollBar.size = (float)levelOfSuspicion / 15.0f;
        }
        else
        {
            scrollBar = GameObject.FindObjectOfType<Scrollbar>();
            scrollBar.size = (float)levelOfSuspicion / 15.0f;
        }
    }
    public void AddLevelOfSuspencience(int points)
    {
        Debug.Log("Adding " + points);
        levelOfSuspicion += points;
        if (levelOfSuspicion > 15)
        {
            Lost = true;
        }
    }
}
