using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThePlayer;
    public Animator NPCAnimator;
    private float TargetDistance;
    public float AllowedDistance;
    public GameObject TheNPC;
    private float Speed;
    public RaycastHit Shot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                NPCAnimator.SetBool("Idle", false);
                Speed = 0.065f;
                
                //animation  for follow
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, Speed);
            }
            else
            {
                Speed = 0f;
                NPCAnimator.SetBool("Idle", true);
                
            }
        }
    }
}
