using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState; 

    public Transform up;
    public Transform down;
    public Transform front;
    public Transform back;
    public Transform left;
    public Transform right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the cube state's map
    public void Set() {
        cubeState = FindObjectOfType<CubeState>();

        UpdateMap(cubeState.up, up);
        UpdateMap(cubeState.down, down);
        UpdateMap(cubeState.front, front);
        UpdateMap(cubeState.back, back);
        UpdateMap(cubeState.left, left);
        UpdateMap(cubeState.right, right);
    }

    // Read the map and update it based on gameobject
    void UpdateMap(List<GameObject> face, Transform side) {
        int i = 0;
        foreach (Transform map in side) {
            if (face[i].GetComponent<MeshRenderer>().material.name == "white (Instance)") {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].GetComponent<MeshRenderer>().material.name == "yellow (Instance)") {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].GetComponent<MeshRenderer>().material.name == "green (Instance)") {
                map.GetComponent<Image>().color = Color.green;
            }
            if (face[i].GetComponent<MeshRenderer>().material.name == "blue (Instance)") {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].GetComponent<MeshRenderer>().material.name == "orange (Instance)") {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if (face[i].GetComponent<MeshRenderer>().material.name == "red (Instance)") {
                map.GetComponent<Image>().color = Color.red;
            }
            i++;
        }
    }
}
