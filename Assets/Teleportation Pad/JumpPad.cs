using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float padCD = 2;
    private bool padCooling;
    private float padTimer;
    public bool padisUsing = false;
    public bool padisActive = true;
    public float walkSpeed = 5;
    public float RunSpeed = 10;
    public float jumpSpeed = 8;
    private CollisionFlags m_CollisionFlags;
    private CharacterController m_CharacterController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(padCooling)
        {
            if(padTimer < padCD)
            {
                padTimer += Time.deltaTime;
            }
            else
            {
                Debug.Log("Pad Charged!");
                padTimer = 0;
                padCooling = false;
            }
        }
    }

     public void checkJump()
    {
        if(!padCooling)
        {

        }
    }

    public void goJump()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("´þµ½ÄãÁË");
            GameObject player = other.gameObject;
            Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 Vector3myVector3 = player.transform.position;
            body.AddForce(body.transform.up*10f,  ForceMode.Impulse);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        m_CharacterController = hit.gameObject.GetComponent<CharacterController>();
        //dont move the rigidbody if the character is on top of it
        if (m_CollisionFlags == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(m_CharacterController.velocity * 1.5f, hit.point, ForceMode.Impulse);
        print("Ah ha");
    }
}
