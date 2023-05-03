using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StartTheGame : MonoBehaviour
{
    public TMP_Text highscore_text;
    private void Start()
    {
        try
        {
            //bug ki la :v?
            string temp = PlayerPrefs.GetFloat("highscore", 0).ToString();
            highscore_text.text = temp;
        }
       catch
        {

        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
