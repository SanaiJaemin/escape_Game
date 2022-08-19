using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Input KeyCodes")]
 
    private KeyCode KeyCodeJump = KeyCode.Space;

    [Header("Audio Clips")]

    [SerializeField]
    private AudioClip _audioClipWalk;


    [SerializeField]
    private AudioClip _audioClipRun;

    private PlayerCamera _playerCamera;
   private PlayerMove _playerMove;
    private PlayerCatch _playerCatch;
    public bool isCatch = false;

 
    
    
    private AudioSource _audioSource;
    


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerCamera = GetComponent<PlayerCamera>();
        _playerMove = GetComponent<PlayerMove>();
        _audioSource = GetComponent<AudioSource>();
        _playerCatch = GetComponent<PlayerCatch>();



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
        UpdateCatch();


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

    private void UpdateCatch()
    {
        isCatch = Input.GetKeyDown(KeyCode.E);
        
            
        
    }

 

}
