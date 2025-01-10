//using DitzeGames.MobileJoystick;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    
    
    
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
    
    public float gravity = -9.81f;
    public Animator playerAnim;
    public CharacterController controller;
    public float speed;
    public Animator walkAnim;
    Vector3 velocity;
    public Transform groundCheck;
    public float radius;
    public LayerMask groundMask;
    bool isLanding;
    public float jumpHeight = 5f;
    int jumpChance = 2;
    
    private PlayerScripts playerInput;

    int indexScene;
     void Awake()
    {
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
    }
    void Update()
    {
        PlayerPrefs.GetFloat("newSize");
        isLanding = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        Run();

        if (isLanding && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpChance = 2;
            
        }

        if (playerInput.PlayerMain.Jump.triggered && jumpChance > 0)
        {
            jumpChance -= 1;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            footstepAudio.mute = true;

        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
    
    void Run()
    {
      /*  float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        if (zMovement != 0f)
        {

            playerAnim.SetBool("isWalking", true);
        }
        else if (xMovement == 1f)
        {
            playerAnim.SetBool("rightWalking", true);
        }
        else if (xMovement == -1f)
        {
            playerAnim.SetBool("leftWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
            playerAnim.SetBool("leftWalking", false);
            playerAnim.SetBool("rightWalking", false);
        }*/
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();

        if (isLanding == true && movementInput.x != 0 || movementInput.y != 0 && isLanding == true)
        {
            footstepAudio.mute = false;
        }
        else if(movementInput.x ==  0 || movementInput.y == 0 )
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
        else if(movementInput.x != 0f)
        {
            playerAnim.SetBool("SideWalk", true);
            playerAnim.SetFloat("Direct", movementInput.x, 0.1f, Time.deltaTime);
        }
       
        else if(movementInput.x == 0f)
        {
            playerAnim.SetBool("SideWalk", false);
            
        }
       
        //Vector3 move = transform.right * xMovement + transform.forward * zMovement; old input unity system
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
        controller.Move(move * speed * Time.deltaTime);
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
        if(PlayerPrefs.GetInt("Double",0) == 0)
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