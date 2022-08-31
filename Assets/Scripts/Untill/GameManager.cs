using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerController _playerController;
    public GameObject pause;
    public PlayerCatch _playerCatch;
    // Start is called before the first frame update
    void Start()
    {
       
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerController.isPause == true)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _playerCatch.UiObject = true;

        }
    }
}
