using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager._instance._playerController.isPause == false)
        {
            gameObject.SetActive(false);
        }
    }
    private void Continue()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager._instance._playerController.isPause = false;
       
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(GameManager._instance.gameObject);
    }
}
