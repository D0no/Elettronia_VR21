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

    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

    }

    public override void Grab(GameObject grabber)
    {
            IsGrabbed = true;
            Snapper.IsSnapped = false;
            _collider.enabled = false;
            _rigidbody.isKinematic = true; //permette movimento libero
        
    }

    public override void Drop()
    {

             IsGrabbed = false;
            _collider.enabled = true;
            _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        
    }
}
