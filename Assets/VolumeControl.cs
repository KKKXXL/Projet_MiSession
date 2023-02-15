using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    private AudioSource bgm;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").transform.GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        Load();
    }
    private void Update()
    {
        VolumeController();
    }
    // Update is called once per frame

    void VolumeController()
    {
        bgm.volume = slider.value;
    }

 public   void save()
    {
           PlayerPrefs.SetFloat("bgm",bgm.volume);
           PlayerPrefs.SetFloat("slider", slider.value);
           PlayerPrefs.Save();
    }
    void Load()
    {
        bgm.volume=PlayerPrefs.GetFloat("bgm");
        slider.value=PlayerPrefs.GetFloat("slider");
    }

}
