using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Camera2DMotionController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform robotTransform;
    [SerializeField] float camSensVertical = 4f;
    [SerializeField] float camSensHorizontal = 4f;
    [SerializeField] float cameraDistance = 10f;
  //  [SerializeField] float lookSpeed = 1f;

    Vector3 offset = new Vector3(0, 1, -10);
    [SerializeField] float maxCameraOffsetX = 0.75f;
    [SerializeField] float maxCameraOffsetY = 0.5f;
    // [SerializeField] Transform temp;

    private Vector3 lastMouse = new Vector3(Screen.width / 2, Screen.height / 2, 255);
    //Transform directionFromRoboToCamera = new Transform();
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
   //     Cursor.visible = false;

        
        

        offset = Vector3.ClampMagnitude(offset, 1);

        cameraTransform.position = robotTransform.position + offset*cameraDistance;

    //    cameraTransform.LookAt(robotTransform);
    }

    // Update is called once per frame
    void Update()
    {
        float cameraYoffxsetChange = Input.GetAxis("Mouse Y") * camSensVertical * Time.deltaTime;
        float cameraXoffxsetChange = Input.GetAxis("Mouse X") * camSensHorizontal * Time.deltaTime;
        if (cameraXoffxsetChange != 0 || cameraYoffxsetChange != 0){
            Vector2 tmp = new Vector2(offset.x, offset.y);
            tmp.x += cameraXoffxsetChange;
            tmp.y += cameraYoffxsetChange;
            if (Mathf.Abs(tmp.x) < maxCameraOffsetX && Mathf.Abs(tmp.y) < maxCameraOffsetY)
            {
                offset.x = tmp.x;
                offset.y = tmp.y;
            }
        }
        UnityEngine.Debug.Log(offset);
        cameraTransform.position = robotTransform.position + offset * cameraDistance;

       // robotTransform.eulerAngles = new Vector3(robotTransform.eulerAngles.x + curpos.x, robotTransform.eulerAngles.y + curpos.y, 0);
      //  Vector3 newTempDirectionFromRoboPerspective = robotTransform.forward;
     //   newTempDirectionFromRoboPerspective = Vector3.ClampMagnitude(newTempDirectionFromRoboPerspective, 1);

    //    cameraTransform.position = prevRoboPos + 2*newTempDirectionFromRoboPerspective;
    //    cameraTransform.LookAt(robotTransform);


    //    lastMouse = Input.mousePosition;
   //     robotTransform.position = prevRoboPos;
   //     robotTransform.rotation = prevRoboRot;
    }
}
