using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform robotTransform;
    [SerializeField] float camSensVertical = 0.3f;
    [SerializeField] float camSensHorizontal = 1f;
   // [SerializeField] Transform temp;

    private Vector3 lastMouse = new Vector3(Screen.width / 2, Screen.height / 2, 255);
    //Transform directionFromRoboToCamera = new Transform();
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //  directionFromRoboToCamera.SetLocalPositionAndRotation(roboPos, roboRot);
        var prevRoboPos = robotTransform.position;
        var prevRoboRot = robotTransform.rotation; 
  //      robotTransform.GetLocalPositionAndRotation(out var , out var prevRoboRot);
        
        Vector3 offset = new Vector3(0, 1, -3);

        offset = Vector3.ClampMagnitude(offset, 1);

        cameraTransform.position = robotTransform.position + offset*6;

       

      //  temp.position = robotTransform.position + offset*2;
     //   temp.LookAt(robotTransform);
        cameraTransform.LookAt(robotTransform);
 //       robotTransform.LookAt(cameraTransform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        var prevRoboPos = robotTransform.position;
        var prevRoboRot = robotTransform.rotation;

        robotTransform.LookAt(cameraTransform);
        Vector3 curpos = Input.mousePosition - lastMouse;
   //     Debug.Log(curpos);
        curpos = new Vector3(-curpos.y * camSensVertical, curpos.x * camSensHorizontal, 0);

        
        robotTransform.eulerAngles = new Vector3(robotTransform.eulerAngles.x + curpos.x, robotTransform.eulerAngles.y + curpos.y, 0);
        Vector3 newTempDirectionFromRoboPerspective = robotTransform.forward;
        newTempDirectionFromRoboPerspective = Vector3.ClampMagnitude(newTempDirectionFromRoboPerspective, 1);

        cameraTransform.position = prevRoboPos + 2*newTempDirectionFromRoboPerspective;
        cameraTransform.LookAt(robotTransform);


        lastMouse = Input.mousePosition;
        robotTransform.position = prevRoboPos;
        robotTransform.rotation = prevRoboRot;
    }
}
