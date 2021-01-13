using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbable : Grabbable
{
    public static bool IsGrabbed = false;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private GameObject _gameobject;
    Grabbable grabbed_object;


    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
       _gameobject = GetComponent<GameObject>();

    }

    public override void Grab(GameObject grabber)
    {

        IsGrabbed = true;
        Snapper.IsSnapped_static = false;
        _collider.enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        _rigidbody.isKinematic = true; //permette movimento libero
        
    }

    public override void Drop()
    {

        IsGrabbed = false;
        Snapper.IsSnapped_static = false;
        _collider.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        
    }
}
