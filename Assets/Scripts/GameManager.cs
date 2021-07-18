using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] tomatoList;
    private int tomatoHP = 1;
    public Image breadImageRef;
    public Image knifeImageRef;

    public int GetTomatoHP()
    {
        return tomatoHP;
    }

    public void SetTomatoHP(int n)
    {
        tomatoHP = n;

        if(tomatoHP <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }

        for(int i = 0; i < n; i++)
        {
            Color temp = tomatoList[i].color;
            temp.a = 255;
            tomatoList[i].color = temp;
        }
    }

    public void SetBreadAplha(float a)
    {
        Color temp = breadImageRef.color;
        temp.a = a;
        breadImageRef.color = temp;
    }

    public float GetKnifeAlpha()
    {
        return knifeImageRef.color.a;
    }

    public void SetKnifeAplha(float a)
    {
        Color temp = knifeImageRef.color;
        temp.a = a;
        knifeImageRef.color = temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTomatoHP(GetTomatoHP());
        SetBreadAplha(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
