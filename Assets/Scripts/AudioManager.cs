using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioList;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            audioList[0].Play();
        }
        else
        {
            audioList[1].Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
