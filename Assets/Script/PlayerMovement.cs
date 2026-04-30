using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float startSpeed;

    private CharacterController cc;
    private float gravity = -9.81f;
    [SerializeField]private float jumpHeight = 1.5f;

    private bool isGrounded;
    private float veticalVelocity;
    void Start()
    {
      
        cc = GetComponent<CharacterController>();
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            MoveAndJump();
            
        
        }
        if(Gamepad.current != null)
        {
            MoveAndJump();
        }

    }

    private void MoveAndJump()
    {
        Vector3 moveDir = Vector3.forward * speed;

        isGrounded = cc.isGrounded;

        if (isGrounded == true)
        {
            veticalVelocity = 2f;
        }

        if (isGrounded == true && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            veticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        moveDir.y = veticalVelocity;
        veticalVelocity += gravity * Time.deltaTime;
        cc.Move(moveDir * Time.deltaTime);
    }
}
