using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int mHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int hitPoints)
    {
        mHitPoints -= hitPoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Hit");
            int knockbackForce = 5000;
            collision.GetComponent<CookieHealth>().DealDamage(1);
            Vector3 knockbackDirection = collision.transform.position - transform.position;
            Vector2 knockback = new Vector2(knockbackDirection.x , knockbackDirection.y);
            collision.GetComponent<Rigidbody2D>().AddForce(knockback * knockbackForce);


        }
    }
}
