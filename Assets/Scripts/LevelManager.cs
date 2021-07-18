using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioManager audioManagerRef;
    public Image knifeCursorRef; 

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        knifeCursorRef.transform.position = new Vector2(Input.mousePosition.x + 80, Input.mousePosition.y - 90);
    }

    public void ChangeScene()
    {
        audioManagerRef.audioList[2].Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void MenuScene()
    {
        audioManagerRef.audioList[2].Play();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        audioManagerRef.audioList[2].Play();
        Application.Quit();
    }
}
