using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

    private bool mPlayerAttacks = false;
    [SerializeField]
    private Animator mAnim;

    [SerializeField]
    private GameObject mSugarProjectile;
    [SerializeField]
    private GameObject mChipProjectile;

   


    [SerializeField]
    private Vector3 mTrajectory;
    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();
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
        mAnim.SetFloat("BlendX", xInput);
        mAnim.SetFloat("BlendY", yInput);
        

        mRigidBody.AddForce(mMovement);

      
        //Mouse click functionality
        if (Input.GetMouseButtonDown(0))
        {
           
         

            switch (mSelectedCookie)
            {
                //Monster Cookie
                case 0:
                    mAnim.SetBool("PlayerAttacks", true);
                    break;
                //Sugar Cookie
                case 1:
                    mAnim.SetBool("PlayerAttacks", true);
                    Instantiate(mSugarProjectile, transform);
                    break;
                //Chocolate Chip Cookie
                case 2:
                    mAnim.SetBool("PlayerAttacks", true);
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
            mAnim.SetInteger("SelectedCookie", mSelectedCookie);
            ValidateBounds();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mSelectedCookie++;
            mAnim.SetInteger("SelectedCookie", mSelectedCookie);
            ValidateBounds();
        }

        switch (mSelectedCookie)
        {
            case 0:
                mCookie0.SetActive(true);
                mCookie1.SetActive(false);
                mCookie2.SetActive(false);
                break;
            case 1:
                mCookie0.SetActive(false);
                mCookie1.SetActive(true);
                mCookie2.SetActive(false);
                break;
            case 2:
                mCookie0.SetActive(false);
                mCookie1.SetActive(false);
                mCookie2.SetActive(true);
                break;
            default:
                Debug.Log("mSelectedCookie is incorrect");
                break;
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
