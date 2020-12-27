using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : Interactable
{
    public GameObject _button;
    public Animator _animatorL;
    public Animator _animatorR;
    public AudioSource _button_sound;
    public AudioSource _doorL_sound;
    public AudioSource _doorR_sound;



    void Start()
    {
       
    }

    public override void Interact(GameObject caller)
    {
        if ((_animatorL.GetBool("Slider") && _animatorR.GetBool("Slider")) == false) //door is closed interaction will open
        {
            _animatorL.SetBool("Slider", true);
            _animatorR.SetBool("Slider", true);
            _button_sound.Play();
            _doorL_sound.Play();
            _doorR_sound.Play();
        }

        else //door is open interaction will close
        {
            _animatorL.SetBool("Slider", false);
            _animatorR.SetBool("Slider", false);
            _button_sound.Play();
            _doorL_sound.Play();
            _doorR_sound.Play();
        }

    }

 


}