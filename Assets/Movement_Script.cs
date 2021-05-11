using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement_Script : MonoBehaviour
{
    public float speed_; //movement speed

    public Transform vrCamera; //Used to control the transform methods of the Camera
    public float toggleAngle = 30.0f; //Angle border, can play around with this further to adjust it to your scene
    public bool moveForward; //boolean to determine whether to move forward or not

    private CharacterController cc;
    private int count;
    public GUIText countText;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //don't know what this is really for but I assume it enables gyroscopic controls on devices
        speed_ = 10; //Movement speed, 10 is decent speed, 20 is like moving on a bike
	count=0;
	CountText();
    }

    void OnTriggerEnter(Collider other)
    {
	if (other.gameObject.tag == "item")
	{
	    other.gameObject.SetActive(false);
	    count=count+1;
	    CountText();
	}
    }

    void CountText()
    { 
	countText.text = "Count: " + count.ToString();
    }
    void Update()
    {
        //if camera tilt downard is betwen 10 and 30 degrees, move forward
        if (vrCamera.eulerAngles.x < toggleAngle && vrCamera.eulerAngles.x > 10)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        //Code that actually moves the player/Camera forward
        if(moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed_);
        }
    }
}
