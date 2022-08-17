using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Input KeyCodes")]

    private KeyCode KeyCodeRun = KeyCode.LeftShift;
    private KeyCode KeyCodeJump = KeyCode.Space;

    [Header("Audio Clips")]

    [SerializeField]
    private AudioClip _audioClipWalk;


    [SerializeField]
    private AudioClip _audioClipRun;

    private PlayerCamera _playerCamera;
    private PlayerStatus _playerStatus;
   private PlayerMove _playerMove;
    private PlayerAnimatorController animator;
    private WeaponAssualtRifle weapon;
    
    
    private AudioSource _audioSource;
    


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerCamera = GetComponent<PlayerCamera>();
        _playerMove = GetComponent<PlayerMove>();
        _playerStatus = GetComponent<PlayerStatus>();
        animator = GetComponent<PlayerAnimatorController>();
        _audioSource = GetComponent<AudioSource>();
        weapon = GetComponentInChildren<WeaponAssualtRifle>();
        
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
        UpdateShot();
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

        if (MoveX != 0 || MoveZ != 0)
        {
            bool isRun = false;

            if (MoveZ > 0)
            {
                isRun = Input.GetKey(KeyCodeRun);
            }
            _playerMove.MoveSpeed = isRun == true ? _playerStatus.RunSpeed : _playerStatus.WalkSpeed;
            animator.MoveSpeed = isRun == true ? 1 : 0.5f;
            _audioSource.clip = isRun == true ? _audioClipWalk : _audioClipRun; 
        
            if(_audioSource.isPlaying == false)
            {
                _audioSource.loop = true;
                _audioSource.Play();
            }
        
        }
        else
        {
            _playerMove.MoveSpeed = 0;
            animator.MoveSpeed = 0f;
            if(_audioSource.isPlaying == true)
            {
                _audioSource.Stop();
            }
        }
        _playerMove.Moveto(new Vector3(MoveX, 0, MoveZ));
    }
    private void UpdateJump()
    {
        if(Input.GetKeyDown(KeyCodeJump))
        {
            _playerMove.Jump();
        }
    }

    private void UpdateShot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.StartWeaponAction();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            weapon.StopWeaponAction();
        }
    }

}
