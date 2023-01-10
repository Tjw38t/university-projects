using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCube : MonoBehaviour
{
    public Transform tUp;
    public Transform tDown;
    public Transform tFront;
    public Transform tBack;
    public Transform tLeft;
    public Transform tRight;

    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();

    // Created new layerMask that will be hit and read by the raycast
    private int layerMask = 1 << 6;
    CubeState cubeState;
    CubeMap cubeMap;
    public GameObject emptyGo;

    // Start is called before the first frame update
    void Start()
    {
        SetRayTransforms();

        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();
        ReadState();
        CubeState.started = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Read the state based off the raycasts
    public void ReadState() {
        cubeState = FindObjectOfType<CubeState>();
        cubeMap = FindObjectOfType<CubeMap>();

        cubeState.up = ReadFace(upRays, tUp);
        cubeState.down = ReadFace(downRays, tDown);
        cubeState.front = ReadFace(frontRays, tFront);
        cubeState.back = ReadFace(backRays, tBack);
        cubeState.left = ReadFace(leftRays, tLeft);
        cubeState.right = ReadFace(rightRays, tRight);

        cubeMap.Set();
    }

    // Create the raycasts from all directions for the cube
    void SetRayTransforms() {
        upRays = BuildRays(tUp, new Vector3(90, 90, 0));
        downRays = BuildRays(tDown, new Vector3(270, 90, 0));
        frontRays = BuildRays(tFront, new Vector3(0, 90, 0));
        backRays = BuildRays(tBack, new Vector3(0, 270, 0));
        leftRays = BuildRays(tLeft, new Vector3(0, 180, 0));
        rightRays = BuildRays(tRight, new Vector3(0, 0, 0));
    }

    // Build the rays starting from the center origin ray
    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction) {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();

        for (int i = 1; i > -2; i--) {
            for (int j = -1; j < 2; j++) {
                Vector3 startPos = new Vector3(rayTransform.localPosition.x + j, rayTransform.localPosition.y + i, rayTransform.localPosition.z);
                GameObject rayStart = Instantiate(emptyGo, startPos, Quaternion.identity, rayTransform);
                rayStart.name = rayCount.ToString();
                rays.Add(rayStart);
                rayCount++;
            }
        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    // Let the raycast hit the cube and see if it hits a material
    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform) {
        List<GameObject> facesHit = new List<GameObject>();

        foreach (GameObject rayStart in rayStarts) {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, layerMask)) {
                Debug.DrawRay(ray, rayTransform.forward * hit.distance, Color.yellow);
                facesHit.Add(hit.collider.gameObject);
                //print(hit.collider.gameObject.name);
            }
            else {
                Debug.DrawRay(ray, rayTransform.forward * 1000, Color.green);
            }
        }

        return facesHit;
    }
}
