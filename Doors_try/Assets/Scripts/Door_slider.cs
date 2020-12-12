using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Door_slider : MonoBehaviour
{
    private Animator _animatorL, _animatorR;
    // Start is called before the first frame update
    void Start()
    {
        _animatorL = GetComponent<Animator>();
        _animatorR = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Slider();
    }
    public void Slider()
    {
        if (_animatorL == null || _animatorR == null)
            return;
        _animatorL.SetBool("Slide", true);
        _animatorR.SetBool("Slide", true);
       
    }

}
