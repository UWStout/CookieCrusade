using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateChipProjectile : MonoBehaviour
{
    [SerializeField]
    private Vector3 mTrajectory;
    private Vector3 mMousePosA;
    private Vector3 mMousePosB;

    private float mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mMousePosA = Input.mousePosition;
        mMousePosB = Camera.main.ScreenToViewportPoint(mMousePosA);
        mTrajectory = new Vector3(mMousePosB.x - transform.position.x, mMousePosB.y - transform.position.y).normalized;


        mSpeed = .05f;
        Destroy(gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += mTrajectory.normalized * mSpeed;  
    }
}
