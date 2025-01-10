using UnityEngine.UI;
using UnityEngine;

public class ClickSoundFx : MonoBehaviour
{
     Button button;
    public AudioSource source;
    public AudioClip clipFx;

    private void Awake()
    {
       
    }
    void Start()
    {
       
        button = GetComponent<Button>();
        source.clip = clipFx;
        source.playOnAwake = false;

        button.onClick.AddListener(()=> PlaySoundFx());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void PlaySoundFx()
    {
        source.PlayOneShot(clipFx);
    }
}
