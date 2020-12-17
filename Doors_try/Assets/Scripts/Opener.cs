using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : Interactable
{
    public GameObject _button;
    public Animator _animatorL;
    public Animator _animatorR;
    //private Collider _interactableCollider;

    void Start()
    {
        //_interactableCollider = GetComponent<Collider>();
    }

    public override void Interact(GameObject caller)
    {
        //_interactableCollider.enabled = false;
        _animatorL.SetBool("Slider", true);
        _animatorR.SetBool("Slider", true);

        //the result of the dot product returns > 0 if relative position 
        /*float dotResult = Vector3.Dot(othersPositionRelativeToDoor, transform.forward);

        float doorRotation = dotResult > 0 ? 90f : -90f;

        if (_door != null)
            _door.OpenDoor(doorRotation);*/
    }

    /*private void ButtonInt()
    {
        _interactableCollider.enabled = true;
    }*/


}