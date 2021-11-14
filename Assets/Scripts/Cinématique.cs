using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cinématique : MonoBehaviour
{
    [SerializeField]
    private Sprite[] listCinématics;
    [SerializeField]
    private Image target;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCinematic());
    }
    IEnumerator StartCinematic()
    {
        bool apprear = false;
        for(int i = 0; i < listCinématics.Length; i++)
        {
            if (listCinématics[i] != null)
            {
                target.sprite = listCinématics[i];
                CanvasGroup Imagecanvas = target.transform.GetComponent<CanvasGroup>();
                if (i == 0)
                {
                    Imagecanvas.alpha = 0.5f;
                }
                for (float ft = 4.0f; ft >= 0; ft -= 0.1f)
                {
                    Imagecanvas.alpha = Mathf.Max(Imagecanvas.alpha * 1.02f, 0);
                    yield return WaitForSeconds(0.05f);
                }
                for (float ft = 4.0f; ft >= 0; ft -= 0.1f)
                {
                    Imagecanvas.alpha = Mathf.Min(Imagecanvas.alpha * 0.98f,1);
                    yield return WaitForSeconds(0.05f);
                }
            }
        }
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitForSeconds(float f)
    {
        yield return new WaitForSeconds(f);
    }/*
        target.sprite = sprit;

        CanvasGroup Imagecanvas = target.transform.GetComponent<CanvasGroup>();
        Imagecanvas.alpha = 1;
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Imagecanvas.alpha = Imagecanvas.alpha * 0.8f;
        }

        Imagecanvas.alpha = 0;
        yield return null;
    }*/
}
