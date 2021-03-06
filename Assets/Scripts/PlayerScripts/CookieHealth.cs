﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookieHealth : MonoBehaviour
{
    [SerializeField]
    private int mHitPoints;

    [SerializeField]
    private HeartUI mHeartUI;

    [SerializeField]
    private int mRegenTime = 30;
    [SerializeField]
    private float mTimeLeft;

    public int HitPoints { get => mHitPoints; }

    // Start is called before the first frame update
    void Start()
    {
        mHeartUI = GameObject.Find("Health Panel").GetComponent<HeartUI>();

        if(mHitPoints == 0)
        {
            mHitPoints = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mHitPoints <= 0)
        {
            GetComponent<Animator>().SetBool("hasDied", true);
            SceneManager.LoadScene(0);
            //Extra Game Over Functionality
        }

        if(mHitPoints < 5)
        {
            mTimeLeft -= Time.deltaTime;
            if(mTimeLeft < 0)
            {
                DealDamage(-1);
            }
        }
        

        
    }

   public void DealDamage(int hitPoints)
    {
        mHitPoints -= hitPoints;
        mHeartUI.DealDamage(hitPoints);
        mTimeLeft = mRegenTime;
        
    }
}
