using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarProjectile : MonoBehaviour
{
    [SerializeField]
    private Vector3 mTrajectory;
    private Vector3 mMousePos;

    private float mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mMousePos = Input.mousePosition;
        Vector3 startPos = Camera.main.WorldToScreenPoint(transform.position);
        mTrajectory = new Vector3(mMousePos.x - startPos.x, mMousePos.y - startPos.y).normalized;


        mSpeed = .3f;
        Destroy(gameObject, .1f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += mTrajectory.normalized * mSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyHealth>().DealDamage(1);
        }
        else if (collision.tag == "Player")
        {
            //Do Nothing
        }
    }
}
