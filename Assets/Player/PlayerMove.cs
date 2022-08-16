using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float gravity;

    private CharacterController _characterController;
    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if(!_characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }
        _characterController.Move(moveForce * Time.deltaTime);
    }

    // Update is called once per frame
    
    public void Moveto(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0f, direction.z);

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if(_characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }
}
