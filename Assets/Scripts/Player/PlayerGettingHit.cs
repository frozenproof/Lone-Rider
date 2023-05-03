using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class PlayerGettingHit : MonoBehaviour
{
    public GameObject playerDieText;
    // Start is called before the first frame update
    void Start()
    {
        playerDieText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<0)
        {
            playerDieText.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(backToMenu());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            if (DamageCalc.playerHp > 0)
                DamageCalc.playerHp -= 1;
            else
            {
                playerDieText.SetActive(true);
                Time.timeScale = 0;
                StartCoroutine(backToMenu());
            }
        }
    }

    public IEnumerator backToMenu()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("Menu");
    }
}
