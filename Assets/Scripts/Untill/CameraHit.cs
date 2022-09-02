using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnclickEnter()
    {
        SceneManager.LoadScene(1);
        Debug.Log("입장");
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("나가기");
    }
   
}
