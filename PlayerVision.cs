using UnityEngine;
using UnityEngine.UI;

public class PlayerVision : MonoBehaviour
{

    public Text sensiText;
    public Slider slider;
    public bool LockCursor;

    
    

   
    public Transform cameraReal;
    int leftFingerID;
    int rightFingerID;
    float halfScreenWidth;
    Vector2 lookInput;
    float CameraPitch;
    public float sensitivity;
  

    

     void Awake()
    {
        slider.value = PlayerPrefs.GetFloat("save", sensitivity);

    }
    public void Start()
    {
        
      
        if (LockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        leftFingerID = -1;
        rightFingerID = -1;
        halfScreenWidth = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //sensitivity = sensiObject.GetComponent<SliderSlides>().sensi;
        //Debug.Log(sensitivity);

        GetTouchInput();

        if (rightFingerID != -1)
        {
            LookAround();
        }

    }


    void GetTouchInput()
    {
        
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (t.position.x < halfScreenWidth && leftFingerID == -1)
                    {
                        leftFingerID = t.fingerId;
                        //  Debug.Log("LeftFinger");
                    }
                    if (t.position.x > halfScreenWidth && rightFingerID == -1)
                    {
                        rightFingerID = t.fingerId;
                        // Debug.Log("RightFinger");
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == leftFingerID)
                    {
                        leftFingerID = -1;
                        // Debug.Log("Stopped tracking left finger");
                    }
                    else if (t.fingerId == rightFingerID)
                    {
                        rightFingerID = -1;
                        //Debug.Log("Stopped tracking right finger");
                    }
                    break;

                case TouchPhase.Moved:
                    if (t.fingerId == rightFingerID)
                    {
                        lookInput = t.deltaPosition * sensitivity * Time.deltaTime;
                        
                    }
                    break;

                case TouchPhase.Stationary:
                    if (t.fingerId == rightFingerID)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
    }
    void LookAround()
    {
        CameraPitch = Mathf.Clamp(CameraPitch - lookInput.y, -90f, 90f);
        cameraReal.localRotation = Quaternion.Euler(CameraPitch, 0f, 0f);

        transform.Rotate(transform.up, lookInput.x);

    }

    public void OnValueChanged(float _newSensi)
    {
        sensitivity = slider.value;
        sensiText.text = "SENSITIVITY      " + sensitivity.ToString("0");
        sensitivity = sensitivity;
        

        PlayerPrefs.SetFloat("save", sensitivity);

    }



}
    

