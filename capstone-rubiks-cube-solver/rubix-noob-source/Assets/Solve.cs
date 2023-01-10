using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static LBL.LayerByLayer;
using static ConsoleApp1.CompCFOP;
using System.Linq;

public class Solve : MonoBehaviour
{
    public CubeState cubeState;
    public ReadCube readCube;
    public bool useStepByStep = false;
    public int method;
    private GameObject choiceArrowLBL;
    private GameObject choiceArrowCFOP;
    private GameObject choiceArrowTH;

    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        useStepByStep = false;
        choiceArrowLBL = GameObject.Find("GameCanvas/choiceLBL");
        choiceArrowCFOP = GameObject.Find("GameCanvas/choiceCFOP");
        choiceArrowTH = GameObject.Find("GameCanvas/choiceTH");

        choiceArrowCFOP.SetActive(false);
        choiceArrowTH.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Converts the cube into a backend representation
    public string SortString(string s) {
        // 0 1 2 3 4 5 6 7 8
        // 0 1 2 3 x 5 6 7 8
        // 0 1 2 5 8 7 6 3

        // 0 1 2
        // 3 4 5
        // 6 7 8

        // 0 1 2
        // 7 x 3
        // 6 5 4

        // Converts Unity cube representation to algos string representation
        string res = "";
        res += s[0];
        res += s[1];
        res += s[2];
        res += s[5];
        res += s[8];
        res += s[7];
        res += s[6];
        res += s[3];

        return res;
    }

    // Yellow face is represented differently so sort it respectively
    public string SortYellow(string s)
    {
        string res = "";
        res += s[6];
        res += s[7];
        res += s[8];
        res += s[5];
        res += s[2];
        res += s[1];
        res += s[0];
        res += s[3];

        return res;
    }

    // Ensure that the movelist is similar to the backend cube representation
    public char[] GenerateMoveList(string faceString) {
        // 0        1    2      3    4      5
        // Orange, Blue, Red, Green, White, Yellow
        faceString = faceString.ToLower();
        char[] faceChar = faceString.ToCharArray();
        return faceChar;
    }

    // Read a new state of the cube and ensure that color arrays are local and destroyed afterwards.
    // Will generate the LayerByLayer method
    public void GetLBLCubeMap()
    {
        readCube.ReadState();
        string moveString = cubeState.GetStateString();

        List<string> parsedString = new List<string>();

        for (var i = 0; i < moveString.Length; i += 9)
            parsedString.Add(moveString.Substring(i, Math.Min(9, moveString.Length - i)));

        List<string> coloredFaces = new List<string>();

        for (var i = 0; i < parsedString.Count - 1; i += 1)
            coloredFaces.Add(SortString(parsedString[i]));

        coloredFaces.Add(SortYellow(parsedString.Last()));


        List<char[]> charColoredFaces = new List<char[]>();
        foreach (var s in coloredFaces)
            charColoredFaces.Add(GenerateMoveList(s));

        char[] g = charColoredFaces[3];
        char[] y = charColoredFaces[5];
        char[] b = charColoredFaces[1];
        char[] r = charColoredFaces[2];
        char[] w = charColoredFaces[4];
        char[] o = charColoredFaces[0];

        Cube lblMapGenerator = new Cube();
        lblMapGenerator.green = g;
        lblMapGenerator.yellow = y;
        lblMapGenerator.blue = b;
        lblMapGenerator.red = r;
        lblMapGenerator.white = w;
        lblMapGenerator.orange = o;

        LBL.LayerByLayer.WhiteCross(lblMapGenerator);
        LBL.LayerByLayer.WhiteCorners(lblMapGenerator);
        SolveSecondLayer(lblMapGenerator);
        YellowCross(lblMapGenerator);
        OrientYellowEdges(lblMapGenerator);
        PositionYellowCorners(lblMapGenerator);
        LBL.LayerByLayer.OrientLastLayer(lblMapGenerator);
        print(string.Join(", ", lblMapGenerator.moveList));
        lblMapGenerator.cleanMoveList();
        print(string.Join(", ", lblMapGenerator.moveList));
        AutomateMoves.moveList = lblMapGenerator.moveList;
        //return lblMapGenerator.moveList;

        //return lblMapGenerator.moveList;

        //return lblMapGenerator.moveList;
    }

    // Read a new state of the cube and ensure that color arrays are local and destroyed afterwards.
    // Will generate the CFOP method
    public void GetCFOPCubeMap()
    {
        readCube.ReadState();
        string moveString = cubeState.GetStateString();

        List<string> parsedString = new List<string>();

        for (var i = 0; i < moveString.Length; i += 9)
            parsedString.Add(moveString.Substring(i, Math.Min(9, moveString.Length - i)));

        List<string> coloredFaces = new List<string>();

        for (var i = 0; i < parsedString.Count - 1; i += 1)
            coloredFaces.Add(SortString(parsedString[i]));

        coloredFaces.Add(SortYellow(parsedString.Last()));


        List<char[]> charColoredFaces = new List<char[]>();
        foreach (var s in coloredFaces)
            charColoredFaces.Add(GenerateMoveList(s));

        char[] g = charColoredFaces[3];
        char[] y = charColoredFaces[5];
        char[] b = charColoredFaces[1];
        char[] r = charColoredFaces[2];
        char[] w = charColoredFaces[4];
        char[] o = charColoredFaces[0];

        Cube cfopMapGenerator = new Cube();
        cfopMapGenerator.green = g;
        cfopMapGenerator.yellow = y;
        cfopMapGenerator.blue = b;
        cfopMapGenerator.red = r;
        cfopMapGenerator.white = w;
        cfopMapGenerator.orange = o;

        ConsoleApp1.CompCFOP.WhiteCross(cfopMapGenerator);
        FirstTwoLayers(cfopMapGenerator);
        ConsoleApp1.CompCFOP.OrientLastLayer(cfopMapGenerator);
        PermuteLastLayer(cfopMapGenerator);
        AutomateMoves.moveList = cfopMapGenerator.moveList;

        //return cfopMapGenerator.moveList;
    }

    // Read a new state of the cube and ensure that color arrays are local and destroyed afterwards.
    // Will generate the Thistlethwaite method
    public void GetTHCubeMap()
    {
    
    public void Solver() {

    public string SortString(string s) {
        // 0 1 2 3 4 5 6 7 8
        // 0 1 2 3 x 5 6 7 8
        // 0 1 2 5 8 7 6 3

        // 0 1 2
        // 3 4 5
        // 6 7 8

        // 0 1 2
        // 7 x 3
        // 6 5 4

        // Converts Unity cube representation to algos string representation
        string res = "";
        res += s[0];
        res += s[1];
        res += s[2];
        res += s[5];
        res += s[8];
        res += s[7];
        res += s[6];
        res += s[3];

        return res;
    }

    public string SortYellow(string s)
    {
        string res = "";
        res += s[6];
        res += s[7];
        res += s[8];
        res += s[5];
        res += s[2];
        res += s[1];
        res += s[0];
        res += s[3];

        return res;
    }

    public char[] GenerateMoveList(string faceString) {
        // 0        1    2      3    4      5
        // Orange, Blue, Red, Green, White, Yellow
        faceString = faceString.ToLower();
        char[] faceChar = faceString.ToCharArray();
        return faceChar;
    }
    
    public void Solver() {
        readCube.ReadState();
        string moveString = cubeState.GetStateString();

        List<string> parsedString = new List<string>();

        for (var i = 0; i < moveString.Length; i += 9)
            parsedString.Add(moveString.Substring(i, Math.Min(9, moveString.Length - i)));

        List<string> coloredFaces = new List<string>();

        for (var i = 0; i < parsedString.Count - 1; i += 1)
            coloredFaces.Add(SortString(parsedString[i]));

        coloredFaces.Add(SortYellow(parsedString.Last()));


        List<char[]> charColoredFaces = new List<char[]>();
        foreach (var s in coloredFaces)
            charColoredFaces.Add(GenerateMoveList(s));

        char[] g = charColoredFaces[3];
        char[] y = charColoredFaces[5];
        char[] b = charColoredFaces[1];
        char[] r = charColoredFaces[2];
        char[] w = charColoredFaces[4];
        char[] o = charColoredFaces[0];

        Cube thMapGenerator = new Cube();
        thMapGenerator.green = g;
        thMapGenerator.yellow = y;
        thMapGenerator.blue = b;
        thMapGenerator.red = r;
        thMapGenerator.white = w;
        thMapGenerator.orange = o;
        print(thMapGenerator.printCubeState());

        // Convert the cube representation to a goal state representation for Thistlethwaite
        Thistlethwaite th = new Thistlethwaite();
        th.currentState = thMapGenerator.getThistlethwaiteArray();
        List<string> thMoveList = th.Solve(thMapGenerator);
        AutomateMoves.moveList = thMoveList;
        //return thMoveList;
        string moveString = cubeState.GetStateString();
        print(moveString);
        string moveString = cubeState.GetStateString();

        //string firstHalf = moveString.Substring(0, moveString.Length / 2);
        List<string> parsedString = new List<string>();

        for (var i = 0; i < moveString.Length; i += 9)
           parsedString.Add(moveString.Substring(i, Math.Min(9, moveString.Length - i)));

        List<string> coloredFaces = new List<string>();
        //foreach (var s in parsedString)
        //    coloredFaces.Add(SortString(s));

        for (var i = 0; i < parsedString.Count-1; i += 1)
            coloredFaces.Add(SortString(parsedString[i]));

        coloredFaces.Add(SortYellow(parsedString.Last()));


        List<char[]> charColoredFaces = new List<char[]>();
        foreach (var s in coloredFaces)
            charColoredFaces.Add(GenerateMoveList(s));

        char[] green = charColoredFaces[3];
        char[] yellow = charColoredFaces[5];
        char[] blue = charColoredFaces[1];
        char[] red = charColoredFaces[2];
        char[] white = charColoredFaces[4];
        char[] orange = charColoredFaces[0];

        Cube cubeMapGenerator = new Cube();
        cubeMapGenerator.green = green;
        cubeMapGenerator.yellow = yellow;
        cubeMapGenerator.blue = blue;
        cubeMapGenerator.red = red;
        cubeMapGenerator.white = white;
        cubeMapGenerator.orange = orange;

        print("Cube State: " + cubeMapGenerator.printCubeState());

        LBL.LayerByLayer layerByLayer = new LBL.LayerByLayer();
        WhiteCross(cubeMapGenerator);
        print("Cube State: " + cubeMapGenerator.printCubeState());
        WhiteCorners(cubeMapGenerator);
        SolveSecondLayer(cubeMapGenerator);
        YellowCross(cubeMapGenerator);
        OrientYellowEdges(cubeMapGenerator);
        PositionYellowCorners(cubeMapGenerator);
        OrientLastLayer(cubeMapGenerator);
        print("Final Cube State: " + cubeMapGenerator.printCubeState());

        foreach (var move in cubeMapGenerator.moveList)
            print(move);

        AutomateMoves.moveList = cubeMapGenerator.moveList;

        //white : up, green: f, r: r, blue: back, o: l, y: bottom
        print(moveString);
    }

    public void SBS() {
        useStepByStep = !useStepByStep;
    }

    public void Solver() {
        
        //GetLBLCubeMap();
        //GetCFOPCubeMap();
        // Only call TH when the user clicks on solve. We need to see what we want to do with this
        if (method == 0) {
            GetLBLCubeMap();
            Debug.Log("LBL");
        }

        else if (method == 1) {
            GetCFOPCubeMap();
            Debug.Log("CFOP");
        }
        else {
            GetTHCubeMap();
            Debug.Log("TH");
        }

        //print(lblMoveString.Count);
        //print(cfopMoveString.Count);
        //print(thMoveString.Count);

        // Add if statement to see which one the user selects to solve
        //AutomateMoves.moveList = thMoveString;

        //white : up, green: f, r: r, blue: back, o: l, y: bottom
    }

    public void ChooseLBL() {
        if (method != 0) {
            method = 0;
            choiceArrowLBL.SetActive(true);
            choiceArrowCFOP.SetActive(false);
            choiceArrowTH.SetActive(false);
        }
    }

    public void ChooseCFOP() {
        if (method != 1) {
            method = 1;
            choiceArrowLBL.SetActive(false);
            choiceArrowCFOP.SetActive(true);
            choiceArrowTH.SetActive(false);
        }
    }

    public void ChooseTH() {
        if (method != 2) {
            method = 2;
            choiceArrowLBL.SetActive(false);
            choiceArrowCFOP.SetActive(false);
            choiceArrowTH.SetActive(true);
        }
    }
}
