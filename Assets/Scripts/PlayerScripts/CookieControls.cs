using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieControls : MonoBehaviour
{

    private float xInput;
    private float yInput;

    [SerializeField]
    private float mSpeed;

    private Rigidbody2D mRigidBody;

    [SerializeField]
    private Vector2 mMovement;

    [SerializeField]
    private int mSelectedCookie;

    [SerializeField]
    private GameObject mCookie0;
    [SerializeField]
    private GameObject mCookie1;
    [SerializeField]
    private GameObject mCookie2;


    [SerializeField]
    private GameObject mSugarProjectile;
    [SerializeField]
    private GameObject mChipProjectile;

   


    [SerializeField]
    private Vector3 mTrajectory;
    // Start is called before the first frame update
    void Start()
    {
        mSelectedCookie = 0;
        mRigidBody = GetComponent<Rigidbody2D>();
        if (mSpeed == 0)
        {
            mSpeed = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        mMovement = new Vector2(xInput * mSpeed, yInput * mSpeed);

        mRigidBody.AddForce(mMovement);

       




        //Mouse click functionality
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
         

            switch (mSelectedCookie)
            {
                case 0:

                    break;
                case 1:
                    Instantiate(mSugarProjectile, transform);
                    break;
                case 2:
                    Instantiate(mChipProjectile, transform);
                    break;
                default:
                    Debug.Log("mSelectedCookie Error");
                    break;
            }
        }

        //Cookie Switching functionality
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mSelectedCookie--;
            ValidateBounds();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mSelectedCookie++;
            ValidateBounds();
        }

        
    }

    private void ValidateBounds()
    {
        if(mSelectedCookie > 2)
        {
            mSelectedCookie = 0;
        }
        if(mSelectedCookie < 0)
        {
            mSelectedCookie = 2;
        }
    }
}
