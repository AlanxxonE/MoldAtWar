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

    public int GetTomatoHP()
    {
        return tomatoHP;
    }

    public void SetTomatoHP(int n)
    {
        tomatoHP = n;

        if(tomatoHP == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        for(int i = 0; i < n; i++)
        {
            Color temp = tomatoList[i].GetComponent<Image>().color;
            temp.a = 255;
            tomatoList[i].GetComponent<Image>().color = temp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetTomatoHP(GetTomatoHP());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
