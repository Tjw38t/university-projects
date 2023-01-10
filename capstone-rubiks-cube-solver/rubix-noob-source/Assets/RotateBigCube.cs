using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 previousMousePosition;
    Vector3 mouseDelta;

    public GameObject target;
    float speed = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        Drag();
    }

    // Allow the user to drag the big cube
    void Drag() {
        if (Input.GetMouseButton(1)) {
            // User can hold the cube and move accordingly
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f;
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else {
            // Move to the target position
            if (transform.rotation != target.transform.rotation) {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }

    // Gets the swipe mechanic from the user
    void Swipe()
    {
        if (Input.GetMouseButtonDown(1)) {
            // Get the position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        
        if (Input.GetMouseButtonUp(1)) {
            // Get the position of the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // Create vector from first and second clicks
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            // Normalize the vector
            currentSwipe.Normalize();

            if (LeftSwipe(currentSwipe)) {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe)) {
                target.transform.Rotate(0,-90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe)) {
                target.transform.Rotate(90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe)) {
                target.transform.Rotate(0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe)) {
                target.transform.Rotate(0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe)) {
                target.transform.Rotate(-90, 0, 0, Space.World);
            }
        }
    }

    // Respective swipes and their orientations
    bool LeftSwipe(Vector2 swipe) {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe) {
        return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool UpLeftSwipe(Vector2 swipe) {
        return swipe.y > 0 && swipe.x < 0f;
    }

    bool UpRightSwipe(Vector2 swipe) {
        return swipe.y > 0 && swipe.x > 0f;
    }

    bool DownLeftSwipe(Vector2 swipe) {
        return swipe.y < 0 && swipe.x < 0f;
    }

    bool DownRightSwipe(Vector2 swipe) {
        return swipe.y < 0 && swipe.x > 0f;
    }

    public void SwipeRight() {
        target.transform.Rotate(0,-90, 0, Space.World);
    }

    public void SwipeLeft() {
        target.transform.Rotate(0, 90, 0, Space.World);
    }

    public void SwipeUp() {
        target.transform.Rotate(0, 0, -90, Space.World);
    }
}
