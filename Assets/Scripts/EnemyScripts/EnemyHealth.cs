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
      if(mHitPoints < 1)
        {
            Destroy(gameObject);
        }   
    }

    public void DealDamage(int hitPoints)
    {
        mHitPoints -= hitPoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            int knockbackForce = 3000;
            collision.gameObject.GetComponent<CookieHealth>().DealDamage(1);
            Vector3 knockbackDirection = collision.transform.position - transform.position;
            Vector2 knockback = new Vector2(knockbackDirection.x, knockbackDirection.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockback * knockbackForce);


        }
        else if (collision.gameObject.tag == "Projectile")
        {
            // do nothing
            Debug.Log(gameObject.name + " is what hit the enemy");
        }
    }
}
