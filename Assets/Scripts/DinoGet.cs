using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DinoGet : MonoBehaviour
{
    public Image WinText;
    bool won = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!won && collision.transform.tag == "Player")
        {
            won = true;
            StartCoroutine(win());
        }
    }

    IEnumerator win()
    {
        WinText = GameObject.Find("Win Text").GetComponent<Image>();
        WinText.enabled = true;
        WinText.transform.GetChild(0).gameObject.SetActive(true);
        Component.FindObjectOfType<CookieHealth>().DealDamage(-1000);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
