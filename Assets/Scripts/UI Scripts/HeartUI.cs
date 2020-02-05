using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField]
    private Image[] mHearts;

    [SerializeField]
    private Sprite mFullHeart;

    [SerializeField]
    private Sprite mEmptyHeart;

    private int mHealthPoints;

    [SerializeField]
    private GameObject mPlayer;


    // Start is called before the first frame update
    void Start()
    {
        mHealthPoints = mPlayer.GetComponent<CookieHealth>().HitPoints;
        for (int i = 0; i < mHearts.Length; i++)
        {
            if (i <= mHealthPoints)
            {
                mHearts[i].sprite = mFullHeart;
            }
                        
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Adjusts how 
    public void DealDamage(int health)
    {
        mHealthPoints -= health;

        if (mHealthPoints > 5)
        {
            mHealthPoints = 5;
        }

        for(int i = 0; i < mHearts.Length; i++)
        {
            if(i + 1 <= mHealthPoints)
            {
                mHearts[i].sprite = mFullHeart;
            }
            else
            {
                mHearts[i].sprite = mEmptyHeart;
            }
        }
    }

}

