using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{

    public List<GameObject> up = new List<GameObject>();
    public List<GameObject> down = new List<GameObject>();
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();

    Dictionary<string, string> pieceToColor = new Dictionary<string, string>() {
        {"U", "W"},
        {"D", "Y"},
        {"F", "G"},
        {"B", "B"},
        {"L", "O"},
        {"R", "R"}
    };

    public static bool autoRotating = false;
    public static bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Let the user pick the side
    public void PickUp(List<GameObject> cubeSide) {
        foreach (GameObject face in cubeSide) {
            if (face != cubeSide[4]) {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;
            }
        }
    }

    // Let the user let go of the chosen side
    public void PutDown(List<GameObject> littleCubes, Transform pivot) {
        foreach (GameObject littleCube in littleCubes) {
            if (littleCube != littleCubes[4]) {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

    // Get the side string of a specific face
    string GetSideString(List<GameObject> side) {
        string sideString = "";
        foreach (GameObject face in side) {
            string color = face.GetComponent<MeshRenderer>().material.name[0].ToString().ToUpper();
            sideString += color;
        }
        return sideString;
    }

    // Get the state string
    public string GetStateString() {
        string stateString = "";
        stateString += GetSideString(left);
        stateString += GetSideString(back);
        stateString += GetSideString(right);
        stateString += GetSideString(front);
        stateString += GetSideString(up);
        stateString += GetSideString(down);

        return stateString;
    }
}
