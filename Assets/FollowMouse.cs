using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //The vector that the player should be looking in
        targetVector = mousePos - transform.position;

        //the rotation step that will affect how fast the player rotates
        float step = 35f * Time.deltaTime;

        //The rotation towards the target vector
        Vector3 newDirection = Vector3.RotateTowards(transform.up, targetVector, step, 0.0f);

        //updating the rotation of the player
        transform.rotation = Quaternion.LookRotation(transform.forward, newDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        { 
            collision.GetComponent<EnemyHealth>().DealDamage(1);
            collision.GetComponent<Rigidbody2D>().AddForce(targetVector.normalized * 3000);
        }
        else if (collision.tag == "Player")
        {
            //Do Nothing
        }
    }
}
