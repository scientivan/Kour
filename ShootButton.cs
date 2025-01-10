using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootButton : MonoBehaviour
{
    public Slider crossHairScalingSlider;
    public GameObject crossHair;

    float saveValue;
    public Slider fireButtonSlider;
    public GameObject FireButton;

    public Slider upDownFireButtonSlider;

    public Slider leftRightFireButtonSlider;
    private void Awake()
    {   //Fire Button  Scaling
        fireButtonSlider.value = PlayerPrefs.GetFloat("FireButtonValueSave", fireButtonSlider.value);
        FireButton.transform.localScale = new Vector3(fireButtonSlider.value, fireButtonSlider.value, fireButtonSlider.value);
        //Fire Button Translation Up And Down
        upDownFireButtonSlider.value =  PlayerPrefs.GetFloat("FireButtonUpDownValueSave", upDownFireButtonSlider.value * 10);
        FireButton.transform.position = new Vector3(FireButton.transform.position.x, upDownFireButtonSlider.value * 10, FireButton.transform.position.z);
       
        //Fire Button Translation Left And Right
        leftRightFireButtonSlider.value = PlayerPrefs.GetFloat("FireButtonLeftRightValueSave", leftRightFireButtonSlider.value * 10);
        FireButton.transform.position = new Vector3(leftRightFireButtonSlider.value * 10, FireButton.transform.position.y, FireButton.transform.position.z);
        
        //Crosshair Button Scaling
        crossHairScalingSlider.value = PlayerPrefs.GetFloat("CrossHairButtonValueSave", crossHairScalingSlider.value);
        crossHair.transform.localScale = new Vector3(crossHairScalingSlider.value, crossHairScalingSlider.value, crossHairScalingSlider.value);
    }
        public void OnFireButtonSizeChanged()
        {
            Vector3 _newButtonFireSize = new Vector3(fireButtonSlider.value, fireButtonSlider.value, fireButtonSlider.value);

            FireButton.transform.localScale = _newButtonFireSize;

            PlayerPrefs.SetFloat("FireButtonValueSave", fireButtonSlider.value);
        }

        public void OnFireButtonUpAndDownChanged()
        {
        
            Vector3 _newUpDownFireButtonValue = new Vector3(FireButton.transform.position.x, upDownFireButtonSlider.value * 10, FireButton.transform.position.z);

            FireButton.transform.position = _newUpDownFireButtonValue;

            PlayerPrefs.SetFloat("FireButtonUpDownValueSave", upDownFireButtonSlider.value);

        }
    public void OnFireButtonLeftAndRightChanged()
    {

        Vector3 _newLeftRightFireButtonValue = new Vector3(leftRightFireButtonSlider.value * 10,FireButton.transform.position.y,FireButton.transform.position.z);

        FireButton.transform.position = _newLeftRightFireButtonValue;

        PlayerPrefs.SetFloat("FireButtonLeftRightValueSave", leftRightFireButtonSlider.value);
    }

    public void OnCrosshairButtonSizeChanged()
    {
        Vector3 _newButtonCrosshairSize = new Vector3(crossHairScalingSlider.value, crossHairScalingSlider.value, crossHairScalingSlider.value);

        crossHair.transform.localScale = _newButtonCrosshairSize;

        PlayerPrefs.SetFloat("CrossHairButtonValueSave", crossHairScalingSlider.value);
    }


    }
