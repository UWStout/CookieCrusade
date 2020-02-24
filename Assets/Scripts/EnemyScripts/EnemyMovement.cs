using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject mPlayer;
    [SerializeField]
    private float mSpeed = 5f;
    private Rigidbody2D mRigidBody;

   
    private Vector3 mDistance;

    private RaycastHit2D mRay;

    [SerializeField]
    private Vector2 mNetForce;
    [SerializeField]
    private Vector2 mWallForce;

    [SerializeField]
    private Animator anim;
  
    [SerializeField]
    private Vector3 mLastKnownPos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("BlendX", mRigidBody.velocity.x);
        anim.SetFloat("BlendY", mRigidBody.velocity.y);
        //Code for tracking and following the player
        mDistance = mPlayer.transform.position - transform.position;
        if (mDistance.sqrMagnitude < 225)
        {
            mRay = Physics2D.Raycast(transform.position + mDistance.normalized, mDistance);
            if (mRay.collider.gameObject.tag == "Player")
            {
                mLastKnownPos = mRay.transform.position;
            }
            else
            {
                // do nothing
            }
       
        }
        if (mLastKnownPos != new Vector3(0, 0, 0) && mPlayer.GetComponent<CookieHealth>().HitPoints > 0)
        {
            mNetForce = new Vector2(mLastKnownPos.x - transform.position.x, mLastKnownPos.y - transform.position.y).normalized * mSpeed;
            mRigidBody.AddForce(mNetForce + mWallForce);
        }
        if ((mLastKnownPos - transform.position).sqrMagnitude < 2)
        {
            mLastKnownPos = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            mWallForce = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized * mSpeed;
        }
        else
        {
            // do nothing
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        mWallForce = Vector2.zero;
    }
}
