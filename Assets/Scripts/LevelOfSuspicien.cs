using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelOfSuspicien : MonoBehaviour
{
    public static LevelOfSuspicien Instance { get; private set; }

    private static int levelOfSuspicion = 0;
    public static int Level { get => levelOfSuspicion; set {
            levelOfSuspicion = value;
        } }

    [SerializeField]
    private Scrollbar scrollBar;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

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
        levelOfSuspicion += points;
    }
}
