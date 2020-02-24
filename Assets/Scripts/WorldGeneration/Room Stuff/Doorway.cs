using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public SpriteMask mask;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Enemy")
        {
            mask.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "Enemy")
        {
            mask.enabled = false;
        }
    }
}
