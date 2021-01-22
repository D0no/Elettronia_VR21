using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSnapper : MonoBehaviour

{
    public Rigidbody _rigidbody;
    public AudioSource _snap_sound;
    public static bool IsSnapped_static = false;
    public bool IsSnapped = false;
    GameObject snapparent; // the gameobject this transform will be snapped to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "lampconnector")
        {
            IsSnapped_static = true;
            IsSnapped = true;
            snapparent = col.gameObject; //the collision determines where the component is snapped          
            _rigidbody.isKinematic = false; //lo fa tornare soggetto alla gravità
        }

        if (IsSnapped_static == true && PhysicsGrabbable.IsGrabbed == false)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            if (snapparent.tag == "lampconnector") //snap the component to the wire with the transform pointing outwards
            {
                
                _snap_sound.Play(); //plays snap sound
                transform.position = new Vector3 (snapparent.transform.position.x, snapparent.transform.position.y + 0.2f, snapparent.transform.position.z);
                transform.rotation = Quaternion.Euler (0, 90, 0);
            }

        }

    }
}
