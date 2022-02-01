using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public float runSpeedMove;
    public float jumpForce;

    private Vector3 _move;
    private CharacterController _characterController;
    private Animator _animation;
    private float _gravityForce;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animation = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        GamingGravity();
    }

    // Перемещение персонажа по сцене и анимации
    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0)
            transform.Rotate(0, x * speedMove, 0);

        if (z != 0)
        {
            _animation.SetBool("Walk", true);
            Vector3 direct = transform.TransformDirection(new Vector3(0, 0, z * speedMove * Time.deltaTime));
            _characterController.Move(direct);
        }

        else
            _animation.SetBool("Walk", false);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            _animation.SetBool("Run", true);
            Vector3 direct = transform.TransformDirection(new Vector3(0, 0, z * runSpeedMove * Time.deltaTime));
            _characterController.Move(direct);
        }

        else
            _animation.SetBool("Run", false);

        _move.y = _gravityForce;
        _characterController.Move(_move * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded)
            _gravityForce -= 25f * Time.deltaTime;

        else
            _gravityForce = -1f;

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            _gravityForce = jumpForce;
    }
}