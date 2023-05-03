using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageCalc : MonoBehaviour
{
    public static float score = 0, highscore ;
    public static float playerHp = 1000;
    public Image HealthImage;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        HealthImage.fillAmount = playerHp / 1000f;
        scoreText.text = score.ToString();
        if(score>highscore )
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }


  
}
