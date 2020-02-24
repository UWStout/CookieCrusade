using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieCornerUI : MonoBehaviour
{

    [SerializeField]
    private Sprite monsterCookie;
    [SerializeField]
    private Sprite sugarCookie;
    [SerializeField]
    private Sprite chocolateChipCookie;

    [SerializeField]
    private Image prev;
    [SerializeField]
    private Image next;

    private int selectedCookie = 0;
    // Start is called before the first frame update
    void Start()
    {
        prev = GameObject.Find("Previous Cookie").GetComponent<Image>();
        next = GameObject.Find("Next Cookie").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (selectedCookie)
        {
            case 0:
                prev.sprite = chocolateChipCookie;
                next.sprite = sugarCookie;
                break;
            case 1:
                prev.sprite = monsterCookie;
                next.sprite = chocolateChipCookie;
                break;
            case 2:
                prev.sprite = sugarCookie;
                next.sprite = monsterCookie;
                break;
            default:
                Debug.Log("Corner UI went wrong");
                break;
        }
    }

    public void SwitchCookie(int cookie)
    {
        selectedCookie = cookie;
    }
}