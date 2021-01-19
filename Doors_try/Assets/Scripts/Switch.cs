using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool isClosed;
    public Animator _switch_animator;
    public AudioSource _switch_sound;
    // Start is called before the first frame update

    public override void Interact(GameObject caller)
    {
       if (_switch_animator.GetBool("Close") == false)
        {
            _switch_animator.SetBool("Close", true);
            isClosed = true;
        }

       else
        {

            _switch_animator.SetBool("Close", false);
            isClosed = false;
        }
    }
    void Start()
    {
        _switch_animator.SetBool("Close", false);
        isClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
