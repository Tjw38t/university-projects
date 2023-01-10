using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static LBL.LayerByLayer;
using static ConsoleApp1.CompCFOP;
using System.Linq;

public class CubeInput : MonoBehaviour
{
    public Text cubeInput;
    public GameObject cube;
    public GameObject cubeMap;
    public List<GameObject> cubeletList;
    
    public Material greenMat;
    public Material redMat;
    public Material blueMat;
    public Material orangeMat;
    public Material yellowMat;
    public Material whiteMat;
    private GameObject cubelet;
    private GameObject face;
    private GameObject mapFace;
    private GameObject mapSide;
    
    private AutomateMoves automatemoves;
    private ReadCube readCube;
    public CubeState cubeState;
    private Solve solve;
    
    // Start is called before the first frame update
    void Start()
    {
        automatemoves = FindObjectOfType<AutomateMoves>();
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        solve = FindObjectOfType<Solve>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DoCubeInput()
    {
        string inputString = cubeInput.text;
        inputString = inputString.ToUpper();
        if (inputString.Length != 54)
        {
            print("This input string has invalid length. Must be 54.");
            Debug.Log(inputString.Length);
            return;
        }
        
        print(inputString);
        //Debug.Log(cube.transform.childCount);
        automatemoves.moveindex = 0;
        
        //loop through each cubelet
        for (int i=0; i<cubeletList.Count; i++)
        {
            cubelet = cubeletList[i];
            Debug.Log(cubelet);
            
            switch (cubelet.name)
            {
                case "D": 
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[49], face);

                    break;
                case "F": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[31], face);

                    break;
                case "L": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[4], face);

                    break;
                case "B": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[13], face);

                    break;
                case "R": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[22], face);

                    break;
                case "U": 
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[40], face);

                    break;
                case "LU": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[1], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[39], face);
                    
                    break;
                case "LB": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[3], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[14], face);
                    break;
                case "FLU": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[2], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[27], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[42], face);
                    break;
                case "FR": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[21], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[32], face);
                    break;
                case "FRU": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[18], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[29], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[44], face);
                    break;
                case "LD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[7], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[48], face);
                    break;
                case "FU": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[28], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[43], face);
                    break;
                case "RU": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[19], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[41], face);
                    break;
                case "BR": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[12], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[23], face);
                    break;
                case "BDR": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[15], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[26], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[53], face);
                    break;
                case "FD": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[34], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[46], face);
                    break;
                case "FLD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[8], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[33], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[45], face);
                    break;
                case "LBU":
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[0], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[11], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[36], face);
                    break;
                case "BU": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[10], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[37], face);
                    break;
                case "LBD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[6], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[17], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[51], face);
                    break;
                case "FL": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[5], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[30], face);
                    break;
                case "RD": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[25], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[50], face);
                    break;
                case "FRD": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[24], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[35], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[47], face);
                    break;
                case "BD": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[16], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[52], face);
                    break;
                case "BRU": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[9], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[20], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[38], face);
                    break;
                default:
                    Debug.Log("Not a cubelet.");
                    break;
            }
        }
        readCube.ReadState();
        if (!checkValidCube()) {
            Debug.Log("Invalid Input Cube!");
            for (int i=0; i<cubeletList.Count; i++)
            {
                cubelet = cubeletList[i];
                face = cubelet.transform.Find("Up").gameObject;
                ChangeFaceColor('W', face);
                face = cubelet.transform.Find("Down").gameObject;
                ChangeFaceColor('Y', face);
                face = cubelet.transform.Find("Left").gameObject;
                ChangeFaceColor('O', face);
                face = cubelet.transform.Find("Back").gameObject;
                ChangeFaceColor('B', face);
                face = cubelet.transform.Find("Right").gameObject;
                ChangeFaceColor('R', face);
                face = cubelet.transform.Find("Front").gameObject;
                ChangeFaceColor('G', face);
            }
        }
    }

    public void ResetCubeInput()
    {
        Debug.Log("Reset cube");
        string inputString = "OOOOOOOOOBBBBBBBBBRRRRRRRRRGGGGGGGGGWWWWWWWWWYYYYYYYYY";
        if (inputString.Length != 54)
        {
            print("This input string has invalid length. Must be 54.");
            Debug.Log(inputString.Length);
            return;
        }
        
        print(inputString);
        //Debug.Log(cube.transform.childCount);
        automatemoves.moveindex = 0;
        
        //loop through each cubelet
        for (int i=0; i<cubeletList.Count; i++)
        {
            cubelet = cubeletList[i];
            Debug.Log(cubelet);
            
            switch (cubelet.name)
            {
                case "D": 
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[49], face);

                    break;
                case "F": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[31], face);

                    break;
                case "L": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[4], face);

                    break;
                case "B": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[13], face);

                    break;
                case "R": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[22], face);

                    break;
                case "U": 
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[40], face);

                    break;
                case "LU": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[1], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[39], face);
                    
                    break;
                case "LB": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[3], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[14], face);
                    break;
                case "FLU": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[2], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[27], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[42], face);
                    break;
                case "FR": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[21], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[32], face);
                    break;
                case "FRU": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[18], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[29], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[44], face);
                    break;
                case "LD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[7], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[48], face);
                    break;
                case "FU": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[28], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[43], face);
                    break;
                case "RU": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[19], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[41], face);
                    break;
                case "BR": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[12], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[23], face);
                    break;
                case "BDR": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[15], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[26], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[53], face);
                    break;
                case "FD": 
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[34], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[46], face);
                    break;
                case "FLD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[8], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[33], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[45], face);
                    break;
                case "LBU":
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[0], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[11], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[36], face);
                    break;
                case "BU": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[10], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[37], face);
                    break;
                case "LBD": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[6], face);
                    
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[17], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[51], face);
                    break;
                case "FL": 
                    face = cubelet.transform.Find("Left").gameObject;
                    ChangeFaceColor(inputString[5], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[30], face);
                    break;
                case "RD": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[25], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[50], face);
                    break;
                case "FRD": 
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[24], face);
                    
                    face = cubelet.transform.Find("Front").gameObject;
                    ChangeFaceColor(inputString[35], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[47], face);
                    break;
                case "BD": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[16], face);
                    
                    face = cubelet.transform.Find("Down").gameObject;
                    ChangeFaceColor(inputString[52], face);
                    break;
                case "BRU": 
                    face = cubelet.transform.Find("Back").gameObject;
                    ChangeFaceColor(inputString[9], face);
                    
                    face = cubelet.transform.Find("Right").gameObject;
                    ChangeFaceColor(inputString[20], face);
                    
                    face = cubelet.transform.Find("Up").gameObject;
                    ChangeFaceColor(inputString[38], face);
                    break;
                default:
                    Debug.Log("Not a cubelet.");
                    break;
            }
        }
        readCube.ReadState();
        if (!checkValidCube()) {
            Debug.Log("Invalid Input Cube!");
            for (int i=0; i<cubeletList.Count; i++)
            {
                cubelet = cubeletList[i];
                face = cubelet.transform.Find("Up").gameObject;
                ChangeFaceColor('W', face);
                face = cubelet.transform.Find("Down").gameObject;
                ChangeFaceColor('Y', face);
                face = cubelet.transform.Find("Left").gameObject;
                ChangeFaceColor('O', face);
                face = cubelet.transform.Find("Back").gameObject;
                ChangeFaceColor('B', face);
                face = cubelet.transform.Find("Right").gameObject;
                ChangeFaceColor('R', face);
                face = cubelet.transform.Find("Front").gameObject;
                ChangeFaceColor('G', face);
            }
        }
    }
    
    private void ChangeFaceColor(char faceChar, GameObject faceObject)
    {
        switch (faceChar)
        {
            case 'G':
                faceObject.GetComponent<MeshRenderer>().material = greenMat;
                break;
            case 'B':
                faceObject.GetComponent<MeshRenderer>().material = blueMat;
                break;
            case 'R':
                faceObject.GetComponent<MeshRenderer>().material = redMat;
                break;
            case 'W':
                faceObject.GetComponent<MeshRenderer>().material = whiteMat;
                break;
            case 'Y':
                faceObject.GetComponent<MeshRenderer>().material = yellowMat;
                break;
            case 'O':
                faceObject.GetComponent<MeshRenderer>().material = orangeMat;
                break;
            default:
                print("Invalid character in Input Cube.");
                break;
        }
    }
    
    
    private bool checkValidCube() {
        readCube.ReadState();
        string moveString = cubeState.GetStateString();

        List<string> parsedString = new List<string>();

        for (var i = 0; i < moveString.Length; i += 9)
            parsedString.Add(moveString.Substring(i, Math.Min(9, moveString.Length - i)));

        List<string> coloredFaces = new List<string>();

        for (var i = 0; i < parsedString.Count - 1; i += 1)
            coloredFaces.Add(solve.SortString(parsedString[i]));

        coloredFaces.Add(solve.SortYellow(parsedString.Last()));


        List<char[]> charColoredFaces = new List<char[]>();
        foreach (var s in coloredFaces)
            charColoredFaces.Add(solve.GenerateMoveList(s));

        char[] g = charColoredFaces[3];
        char[] y = charColoredFaces[5];
        char[] b = charColoredFaces[1];
        char[] r = charColoredFaces[2];
        char[] w = charColoredFaces[4];
        char[] o = charColoredFaces[0];

        Cube inputCube = new Cube();
        inputCube.green = g;
        inputCube.yellow = y;
        inputCube.blue = b;
        inputCube.red = r;
        inputCube.white = w;
        inputCube.orange = o;
        
        return SpecificScramble.Scrambler.checkCube(inputCube);
    }
}

// valid inputs
// OOOOOOOOOBBBBBBBBBRRRRRRRRRGGGGGGGGGWWWWWWWWWYYYYYYYYY
// GWWYOBGOYOBWRBRYGWYBGRRGBGORWGRGWROORYYBWOBORBYWGYYOWB
// YWWBOBOYGWWORBYGGBGGOBRYYYRROORGORRBGRBBWOBWWYGROYGYWW picture
// OGBGOBOYYRRYOBOOWWGYGWRYBBYWYOOGBGWRBGWWWBRRWRRYGYRBOG
