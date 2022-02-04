using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public float runSpeedMove;

    //public float jumpForce;

    public GameController game;
    private AudioSource _soundOpenDoor;

    private Vector3 _move;
    private CharacterController _characterController;
    private Animator _animation;

    private float _gravityForce;
    private bool _inTrigger;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animation = GetComponent<Animator>();
        _soundOpenDoor = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Movement();
        //GamingGravity();
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

        //_move.y = _gravityForce;
        _characterController.Move(_move * Time.deltaTime);
    }

    /*private void GamingGravity()
    {
        if (!_characterController.isGrounded)
            _gravityForce -= 25f * Time.deltaTime;

        else
            _gravityForce = -1f;

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            _gravityForce = jumpForce;
    }*/

    public void PlayerFinish()
    {
        game.ThePlayerWon();
        game.ShowWonScreen();
        _characterController.enabled = false;
    }

    public void PlayerLoss()
    {
        game.ThePlayerLoss();
        game.ShowLossScreen();
        _characterController.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _inTrigger = true;

        if(other.gameObject.tag == "Key")
        {
            other.gameObject.SetActive(false);
            _soundOpenDoor.Play();
        }

        if(other.gameObject.tag == "Finish")
        {
            PlayerFinish();
        }

        if (other.gameObject.tag == "Enemy")
        {
            PlayerLoss();
        }
    }
}