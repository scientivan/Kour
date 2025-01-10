//using DitzeGames.MobileJoystick;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class RigidBodyPlayerMovement : MonoBehaviour
{
     GrapplingHook grappleHook;
    public bool isJumping = true;
    public bool isGrappling;
    //Pendeklarasian object Double Speed 2x

    public GameObject gameObjectDoubleButton;


    //Fire Button
    // public Slider fireButtonSlider;
    // public GameObject FireButton;

    // 1x 2x Button
    public Slider doubleSlider;
    public GameObject DoubleButton;

    // jumpbutton 
    public Slider buttonSlider;
    public GameObject jumpButton;

    //Analog
    public Slider slider;
    public GameObject analog;
    float size;

    RunSpeed run;
    AudioSource footstepAudio;

    public Button doubleButton;
    public Sprite off2X;
    public Sprite on2X;


    public Animator playerAnim;

    public float speed;
    public Animator walkAnim;


    private PlayerScripts playerInput;
    int indexScene;

    Rigidbody rb;

    public int jumpChance = 2;
    public float jumpHeight;
    public float gravity;
    public bool isLanding;
    public Transform groundCheck;
    public float radius;
    public LayerMask groundMask;
    void Awake()
    {
        grappleHook = FindObjectOfType<GrapplingHook>();
        footstepAudio = GetComponent<AudioSource>();
        playerInput = new PlayerScripts();
        //controller = GetComponent<CharacterController>();
        footstepAudio.mute = true;

        slider.value = PlayerPrefs.GetFloat("Saving", slider.value);
        buttonSlider.value = PlayerPrefs.GetFloat("JumpValueSave", buttonSlider.value);
        doubleSlider.value = PlayerPrefs.GetFloat("DoubleValueSave", doubleSlider.value);


        analog.transform.localScale = new Vector3(slider.value, slider.value, slider.value);
        jumpButton.transform.localScale = new Vector3(buttonSlider.value, buttonSlider.value, buttonSlider.value);
        DoubleButton.transform.localScale = new Vector3(doubleSlider.value, doubleSlider.value, doubleSlider.value);
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Start()
    {
        
        run = FindObjectOfType<RunSpeed>();
        indexScene = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
        PlayerPrefs.GetFloat("newSize");
        isLanding = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        Run();

        if (isLanding && rb.velocity.y < 0 || isGrappling == true)
        {
            
            rb.velocity = new Vector3(rb.velocity.x, -2f, rb.velocity.z);
            jumpChance = 2;
            isJumping = false;
        }

        if (playerInput.PlayerMain.Jump.triggered && jumpChance > 0)
        {
            Debug.Log("Jumping");
            isJumping = true;
            jumpChance -= 1;


            if(transform.position.x <= -105f)
            {
                float jumpForce = Mathf.Sqrt(4 * jumpHeight * -2f * gravity);
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                Debug.Log("JumpForce" + jumpForce);
            }
            else
            {
                float jumpForce = Mathf.Sqrt(jumpHeight * -2f * gravity);
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                Debug.Log("JumpForce" + jumpForce);
            }

            footstepAudio.mute = true;
            
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    void Run()
    {

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        /*if (isLanding == true && movementInput.x != 0 || movementInput.y != 0 && isLanding == true)
        {
            footstepAudio.mute = false;
        }
        else if (movementInput.x == 0 || movementInput.y == 0)
        {
            footstepAudio.mute = true;
        }
        if (movementInput.y != 0f) // kanan kiri = x, depan belakang = y
        {
            playerAnim.SetBool("isWalking", true);
        }
        else if (movementInput.y == 0f)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else if (movementInput.x != 0f)
        {
            playerAnim.SetBool("SideWalk", true);
            playerAnim.SetFloat("Direct", movementInput.x, 0.1f, Time.deltaTime);
        }

        else if (movementInput.x == 0f)
        {
            playerAnim.SetBool("SideWalk", false);

        }
        */
        Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.y) * speed * 0.025f;
        Vector3 newPos = rb.position + movement;
        rb.MovePosition(newPos);
        
        /* Vector3 movement = (transform.right * horizontalMovement + transform.forward * verticalMovement) * speed * 0.025f;
         Vector3 newPos = rb.position + movement;
         rb.MovePosition(newPos);*/
         if ( movementInput.x != 0 && isLanding|| movementInput.y!= 0 && isLanding)
         {
             footstepAudio.mute = false; // Jika kita gerak, setel runfx nya
         }
         else if (movementInput.x == 0 || movementInput.y == 0)
         {
             footstepAudio.mute = true; // kalokkita diem, matiin runfxnya
         }
         if (movementInput.y!= 0f || movementInput.x != 0f) // kanan kiri = x, depan belakang = y
         {
             playerAnim.SetBool("isWalking", true);
         }
         else if (movementInput.y == 0f || movementInput.x == 0f)
         {
             playerAnim.SetBool("isWalking", false);
         }

    }
    public void ButtonPressed()
    {

        run.ToggleSpeed();
        UpdateRunIcon();
        if (speed >= 10)
        {
            speed = speed / 2;
        }

    }
    void UpdateRunIcon()
    {
        if (PlayerPrefs.GetInt("Double", 0) == 0)
        {
            speed = speed * 4;
            doubleButton.GetComponent<Image>().sprite = on2X;
        }
        else
        {

            doubleButton.GetComponent<Image>().sprite = off2X;

            //SPRITEON2X
        }

    }
    public void OnSizeChanged()
    {
        Vector3 newsize = new Vector3(slider.value, slider.value, slider.value);
        //Debug.Log(newsize);
        size = slider.value;
        analog.transform.localScale = newsize;

        PlayerPrefs.SetFloat("Saving", slider.value);

    }

    public void OnJumpButtonSizeChanged()
    {
        Vector3 _newButtonJumpSize = new Vector3(buttonSlider.value, buttonSlider.value, buttonSlider.value);

        jumpButton.transform.localScale = _newButtonJumpSize;

        PlayerPrefs.SetFloat("JumpValueSave", buttonSlider.value);
    }

    public void OnDoubleButtonSizeChanged()
    {
        Vector3 _newButtonDoubleSize = new Vector3(doubleSlider.value, doubleSlider.value, doubleSlider.value);

        DoubleButton.transform.localScale = _newButtonDoubleSize;

        PlayerPrefs.SetFloat("DoubleValueSave", doubleSlider.value);
    }

    // public void OnFireButtonSizeChanged()
    //{
    //Vector3 _newButtonFireSize = new Vector3(fireButtonSlider.value, fireButtonSlider.value, fireButtonSlider.value);

    //FireButton.transform.localScale = _newButtonFireSize;

    //  PlayerPrefs.SetFloat("FireButtonValueSave", fireButtonSlider.value);
    // }


}