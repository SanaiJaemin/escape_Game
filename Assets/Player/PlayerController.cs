using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Input KeyCodes")]
    private KeyCode KeyCodeJump = KeyCode.Space;
    PlayerCamera _playerCamera;
    PlayerMove _playerMove;
    


    private void Awake()
    {
        _playerCamera = GetComponent<PlayerCamera>();
        _playerMove = GetComponent<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
    }

    private void UpdateRotate()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        _playerCamera.UpdateRotate(MouseX,MouseY);
    }
    private void UpdateMove()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");
        _playerMove.Moveto(new Vector3(MoveX, 0, MoveZ));
    }
    private void UpdateJump()
    {
        if(Input.GetKeyDown(KeyCodeJump))
        {
            _playerMove.Jump();
        }
    }

}
