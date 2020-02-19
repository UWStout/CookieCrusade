using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour
{
    [SerializeField]
    private int mLevelNumber;

    private Button mButton;


    // Start is called before the first frame update
    void Start()
    {
        mButton = this.GetComponent<Button>();
        mButton.onClick.AddListener(click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void click()
    {
        SceneManager.LoadScene(mLevelNumber);
    }
}
