using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        Debug.Log("play");
        SoundManager.Instance.PlaySFX("ui/click");
        SceneManager.LoadScene("Game");
    }

    public void OnClickOptions()
    {
        Debug.Log("Options");
    }
    public void OnClickQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
