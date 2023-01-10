using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour
{
    private List<GameObject> activeSide;
    private Vector3 localForward;
    private Vector3 mouseRef;
    private bool dragging = false;
    private bool autoRotating = false;
    private float sensitivity = 0.4f;
    private float speed = 300f;
    private Vector3 rotation;

    private Quaternion targetQuaternion;

    private ReadCube readCube;
    private CubeState cubeState;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dragging) {
            SpinSide(activeSide);
            if (Input.GetMouseButtonUp(0)) {
                dragging = false;
                RotateToRightAngle();
            }
        }
        if (autoRotating) {
            AutoRotate();
        }
    }

    // Spin the side based on how fast the user moves the mouse
    private void SpinSide(List<GameObject> side) {
        rotation = Vector3.zero;

        Vector3 mouseOffset = (Input.mousePosition - mouseRef);
        if (side == cubeState.up) {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
        }
        if (side == cubeState.down) {
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }
        if (side == cubeState.left) {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
        }
        if (side == cubeState.right) {
            rotation.z = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }
        if (side == cubeState.front) {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity * -1;
        }
        if (side == cubeState.back) {
            rotation.x = (mouseOffset.x + mouseOffset.y) * sensitivity * 1;
        }

        transform.Rotate(rotation, Space.Self);
        mouseRef = Input.mousePosition;
    }

    // This will drag the side chosen by the user
    public void Rotate(List<GameObject> side) {
        activeSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;

        localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;

    }

    // This will autorotate the movelist 
    public void StartAutoRotate(List<GameObject> side, float angle) {
        cubeState.PickUp(side);
        Vector3 localForward = Vector3.zero - side[4].transform.parent.transform.localPosition;
        targetQuaternion = Quaternion.AngleAxis(angle, localForward) * transform.localRotation;
        activeSide = side;
        autoRotating = true;
    }

    // Rotate it so that it will snap into place
    public void RotateToRightAngle() {
        Vector3 vec = transform.localEulerAngles;
        vec.x = Mathf.Round(vec.x/90) * 90;
        vec.y = Mathf.Round(vec.y/90) * 90;
        vec.z = Mathf.Round(vec.z/90) * 90;

        targetQuaternion.eulerAngles = vec;
        autoRotating = true;
    }

    // Rotate until the movelist is completed
    private void AutoRotate() {
        dragging = false;
        var step = speed * Time.deltaTime;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetQuaternion, step);

        if (Quaternion.Angle(transform.localRotation, targetQuaternion) <= 1) {
            transform.localRotation = targetQuaternion;
            cubeState.PutDown(activeSide, transform.parent);
            readCube.ReadState();
            CubeState.autoRotating = false;
            autoRotating = false;
            dragging = false;
        }
    }
}
