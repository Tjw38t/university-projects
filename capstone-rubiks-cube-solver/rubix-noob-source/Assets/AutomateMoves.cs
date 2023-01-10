using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AutomateMoves : MonoBehaviour
{
    public GameObject Cube;
    public static List<string> moveList = new List<string>() {};
    public static List<string> backwardMoveList = new List<string>() {};
    private readonly List<string> allMoves = new List<string>() 
    {
        "U", "D", "L", "R", "F", "B",
        "U'", "D'", "L'", "R'", "F'", "B'",
    };

    private CubeState cubeState;
    private ReadCube readCube;
    private Solve solve;
    public int moveindex;

    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();
        solve = FindObjectOfType<Solve>();
    }

    // Update is called once per frame
    void Update()
    {
        if(solve.useStepByStep) {
            if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started && Input.GetKeyDown(KeyCode.RightArrow)) {
                if (moveindex < moveList.Count) {
                    DoMove(moveList[moveindex]);
                    moveindex++;
                    print("Formward Move (Right Arrow)");
                    //print(moveindex);
                }
                else {
                    // cube should be solved, empty the moveList
                    moveindex = 0;
                    List<string> moves = new List<string>();
                    moveList = moves;
                    print("Solve Moveset Complete, emptied moveList");
                }
            }

            if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started && Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (moveindex > 0) {
                    moveindex--;
                    DoBackwardMove(moveList[moveindex]);
                    print("Backward Move (Left Arrow)");
                    //print(index);
                }
                else {
                    moveindex = 0;
                }

            }
        }
        else {
            if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started) {
                DoMove(moveList[0]);
                moveList.Remove(moveList[0]);
            }
        }
        
    }

    // Shuffle the moves with random moves 
    public void Shuffle() {
        solve.useStepByStep = false;
        moveindex = 0;
        List<string> moves = new List<string>();
        int shuffleLength = Random.Range(20,30);
        for (int i = 0; i < shuffleLength; i++) {
            int randomMove = Random.Range(0, allMoves.Count);
            moves.Add(allMoves[randomMove]);
        }
        moveList = moves;
    }

    // Move accordingly
    void DoMove(string move) {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if (move == "U") {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'") {
            RotateSide(cubeState.up, 90);
        }
        if (move == "D") {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'") {
            RotateSide(cubeState.down, 90);
        }
        if (move == "L") {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'") {
            RotateSide(cubeState.left, 90);
        }
        if (move == "R") {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'") {
            RotateSide(cubeState.right, 90);
        }
        if (move == "F") {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'") {
            RotateSide(cubeState.front, 90);
        }
        if (move == "B") {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'") {
            RotateSide(cubeState.back, 90);
        }
    }
    
    void DoBackwardMove(string move) {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if (move == "U") {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U'") {
            RotateSide(cubeState.up, -90);
        }
        if (move == "D") {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D'") {
            RotateSide(cubeState.down, -90);
        }
        if (move == "L") {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L'") {
            RotateSide(cubeState.left, -90);
        }
        if (move == "R") {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R'") {
            RotateSide(cubeState.right, -90);
        }
        if (move == "F") {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F'") {
            RotateSide(cubeState.front, -90);
        }
        if (move == "B") {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B'") {
            RotateSide(cubeState.back, -90);
        }
    }


    // Autorotate the side
    void RotateSide(List<GameObject> side, float angle) {
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }

    public void OriginalState() {
        Debug.Log(gameObject.transform.position);
    }
}
