using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieHealth : MonoBehaviour
{
    [SerializeField]
    private int mHitPoints;

    [SerializeField]
    private HeartUI mHeartUI;

    public int HitPoints { get => mHitPoints; }

    // Start is called before the first frame update
    void Start()
    {
        if(mHitPoints == 0)
        {
            mHitPoints = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DealDamage(int hitPoints)
    {
        mHitPoints -= hitPoints;
        mHeartUI.DealDamage(hitPoints);
    }
}
