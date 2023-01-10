using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpecificScramble
{
    public class Scrambler
    {
        /*This cunction takes a scrambled cube and returns a set of moves to scramble a solved cube into that scambled state;
        public static List<string> getScrambleMoves(Cube scrambledCube)
        {
            CFOP.CFOP.SolveCube(scrambledCube);
            List<string> moves = new List<string>();
            int i = scrambledCube.moveList.Count - 1;
            while (i >= 0)
            {
                switch (scrambledCube.moveList[i])
                {
                    case "Y":
                        moves.Add("Y'");
                        break;
                    case "Y'":
                        moves.Add("Y");
                        break;
                    case "G":
                        moves.Add("G'");
                        break;
                    case "G'":
                        moves.Add("G");
                        break;
                    case "R":
                        moves.Add("R'");
                        break;
                    case "R'":
                        moves.Add("R");
                        break;
                    case "B":
                        moves.Add("B'");
                        break;
                    case "B'":
                        moves.Add("B");
                        break;
                    case "O":
                        moves.Add("O'");
                        break;
                    case "O'":
                        moves.Add("O");
                        break;
                    case "W":
                        moves.Add("W'");
                        break;
                    case "W'":
                        moves.Add("W");
                        break;
                }
                i -= 1;
            }
            return moves;
        }
        */
        //This function takes a cube object and returns a bool for if the cube is a valid, solvable configuration (true = solvable, false = unsolvable)
        public static bool checkCube(Cube cube)
        {
            bool YG_Edge = false;
            bool YR_Edge = false;
            bool YB_Edge = false;
            bool YO_Edge = false;
            bool GR_Edge = false;
            bool RB_Edge = false;
            bool BO_Edge = false;
            bool OG_Edge = false;
            bool WG_Edge = false;
            bool WR_Edge = false;
            bool WB_Edge = false;
            bool WO_Edge = false;

            bool YGR_Corner = false;
            bool YRB_Corner = false;
            bool YBO_Corner = false;
            bool YOG_Corner = false;
            bool WGR_Corner = false;
            bool WRB_Corner = false;
            bool WBO_Corner = false;
            bool WOG_Corner = false;

            char a = 'e';
            char b = 'e';
            char c = 'e';
            int tracker = 0;

            while (tracker < 12)
            {
                tracker += 1;
                switch (tracker)
                {
                    case 1:
                        a = cube.white[5];
                        b = cube.green[1];
                        break;
                    case 2:
                        a = cube.white[3];
                        b = cube.red[1];
                        break;
                    case 3:
                        a = cube.white[1];
                        b = cube.blue[1];
                        break;
                    case 4:
                        a = cube.white[7];
                        b = cube.orange[1];
                        break;
                    case 5:
                        a = cube.green[3];
                        b = cube.red[7];
                        break;
                    case 6:
                        a = cube.red[3];
                        b = cube.blue[7];
                        break;
                    case 7:
                        a = cube.blue[3];
                        b = cube.orange[7];
                        break;
                    case 8:
                        a = cube.orange[3];
                        b = cube.green[7];
                        break;
                    case 9:
                        a = cube.yellow[5];
                        b = cube.green[5];
                        break;
                    case 10:
                        a = cube.yellow[3];
                        b = cube.red[5];
                        break;
                    case 11:
                        a = cube.yellow[1];
                        b = cube.blue[5];
                        break;
                    case 12:
                        a = cube.yellow[7];
                        b = cube.orange[5];
                        break;
                }
                string check = checkEdge(a, b);
                switch (check)
                {
                    case "YG":
                        if (YG_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            YG_Edge = true;
                        }
                        break;
                    case "YR":
                        if (YR_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            YR_Edge = true;
                        }
                        break;
                    case "YB":
                        if (YB_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            YB_Edge = true;
                        }
                        break;
                    case "YO":
                        if (YO_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            YO_Edge = true;
                        }
                        break;
                    case "GR":
                        if (GR_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            GR_Edge = true;
                        }
                        break;
                    case "RB":
                        if (RB_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            RB_Edge = true;
                        }
                        break;
                    case "BO":
                        if (BO_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            BO_Edge = true;
                        }
                        break;
                    case "OG":
                        if (OG_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            OG_Edge = true;
                        }
                        break;
                    case "WG":
                        if (WG_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            WG_Edge = true;
                        }
                        break;
                    case "WR":
                        if (WR_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            WR_Edge = true;
                        }
                        break;
                    case "WB":
                        if (WB_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            WB_Edge = true;
                        }
                        break;
                    case "WO":
                        if (WO_Edge)
                        {
                            return false;
                        }
                        else
                        {
                            WO_Edge = true;
                        }
                        break;
                    default:
                        return false;
                }
            }
            tracker = 0;

            while (tracker < 8)
            {
                tracker += 1;
                switch (tracker)
                {
                    case 1:
                        a = cube.white[6];
                        b = cube.green[0];
                        c = cube.orange[2];
                        break;
                    case 2:
                        a = cube.white[4];
                        b = cube.green[2];
                        c = cube.red[0];
                        break;
                    case 3:
                        a = cube.white[2];
                        b = cube.red[2];
                        c = cube.blue[0];
                        break;
                    case 4:
                        a = cube.white[0];
                        b = cube.blue[2];
                        c = cube.orange[0];
                        break;
                    case 5:
                        a = cube.yellow[6];
                        b = cube.green[6];
                        c = cube.orange[4];
                        break;
                    case 6:
                        a = cube.yellow[4];
                        b = cube.green[4];
                        c = cube.red[6];
                        break;
                    case 7:
                        a = cube.yellow[2];
                        b = cube.red[4];
                        c = cube.blue[6];
                        break;
                    case 8:
                        a = cube.yellow[0];
                        b = cube.blue[4];
                        c = cube.orange[6];
                        break;
                }
                string check = checkCorner(a, b, c);
                switch (check)
                {
                    case "YGR":
                        if (YGR_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            YGR_Corner = true;
                        }
                        break;
                    case "YRB":
                        if (YRB_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            YRB_Corner = true;
                        }
                        break;
                    case "YBO":
                        if (YBO_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            YBO_Corner = true;
                        }
                        break;
                    case "YOG":
                        if (YOG_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            YOG_Corner = true;
                        }
                        break;
                    case "WGR":
                        if (WGR_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            WGR_Corner = true;
                        }
                        break;
                    case "WRB":
                        if (WRB_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            WRB_Corner = true;
                        }
                        break;
                    case "WBO":
                        if (WBO_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            WBO_Corner = true;
                        }
                        break;
                    case "WOG":
                        if (WOG_Corner)
                        {
                            return false;
                        }
                        else
                        {
                            WOG_Corner = true;
                        }
                        break;
                    default:
                        return false;
                }
            }

            if(WG_Edge && WR_Edge && WB_Edge && WO_Edge
                && GR_Edge && RB_Edge && BO_Edge && OG_Edge
                && WG_Edge && WR_Edge && WB_Edge && WO_Edge
                && WGR_Corner && WRB_Corner && WBO_Corner && WOG_Corner
                && YGR_Corner && YRB_Corner && YBO_Corner && YOG_Corner)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper function for checkCube(), this function is used to check edge piece validity
        public static string checkEdge(char a, char b)
        {
            switch (a)
            {
                case 'y':
                    switch (b)
                    {
                        case 'g':
                            return "YG";
                        case 'r':
                            return "YR";
                        case 'b':
                            return "YB";
                        case 'o':
                            return "YO";
                        default:
                            return "ERROR";
                    }
                case 'g':
                    switch (b)
                    {
                        case 'y':
                            return "YG";
                        case 'r':
                            return "GR";
                        case 'w':
                            return "WG";
                        case 'o':
                            return "OG";
                        default:
                            return "ERROR";
                    }
                case 'r':
                    switch (b)
                    {
                        case 'g':
                            return "GR";
                        case 'y':
                            return "YR";
                        case 'b':
                            return "RB";
                        case 'w':
                            return "WR";
                        default:
                            return "ERROR";
                    }
                case 'b':
                    switch (b)
                    {
                        case 'y':
                            return "YB";
                        case 'r':
                            return "RB";
                        case 'w':
                            return "WB";
                        case 'o':
                            return "BO";
                        default:
                            return "ERROR";
                    }
                case 'o':
                    switch (b)
                    {
                        case 'g':
                            return "OG";
                        case 'y':
                            return "YO";
                        case 'b':
                            return "BO";
                        case 'w':
                            return "WO";
                        default:
                            return "ERROR";
                    }
                case 'w':
                    switch (b)
                    {
                        case 'g':
                            return "WG";
                        case 'r':
                            return "WR";
                        case 'b':
                            return "WB";
                        case 'o':
                            return "WO";
                        default:
                            return "ERROR";
                    }
                default:
                    return "ERROR";
            }
        }
        //helper function for checkCube(), this function is used to check corner piece validity
        public static string checkCorner(char a, char b, char c)
        {
            switch (a)
            {
                case 'y':
                    switch (b)
                    {
                        case 'g':
                            switch (c)
                            {
                                case 'r':
                                    return "YGR";
                                case 'o':
                                    return "YOG";
                                default:
                                    return "ERROR";
                            }
                        case 'r':
                            switch (c)
                            {
                                case 'g':
                                    return "YGR";
                                case 'b':
                                    return "YRB";
                                default:
                                    return "ERROR";
                            }
                        case 'b':
                            switch (c)
                            {
                                case 'r':
                                    return "YRB";
                                case 'o':
                                    return "YBO";
                                default:
                                    return "ERROR";
                            }
                        case 'o':
                            switch (c)
                            {
                                case 'b':
                                    return "YBO";
                                case 'g':
                                    return "YOG";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                case 'g':
                    switch (b)
                    {
                        case 'y':
                            switch (c)
                            {
                                case 'r':
                                    return "YGR";
                                case 'o':
                                    return "YOG";
                                default:
                                    return "ERROR";
                            }
                        case 'r':
                            switch (c)
                            {
                                case 'y':
                                    return "YGR";
                                case 'w':
                                    return "WGR";
                                default:
                                    return "ERROR";
                            }
                        case 'w':
                            switch (c)
                            {
                                case 'r':
                                    return "WGR";
                                case 'o':
                                    return "WOG";
                                default:
                                    return "ERROR";
                            }
                        case 'o':
                            switch (c)
                            {
                                case 'y':
                                    return "YOG";
                                case 'w':
                                    return "WOG";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                case 'r':
                    switch (b)
                    {
                        case 'g':
                            switch (c)
                            {
                                case 'y':
                                    return "YGR";
                                case 'w':
                                    return "WGR";
                                default:
                                    return "ERROR";
                            }
                        case 'y':
                            switch (c)
                            {
                                case 'g':
                                    return "YGR";
                                case 'b':
                                    return "YRB";
                                default:
                                    return "ERROR";
                            }
                        case 'b':
                            switch (c)
                            {
                                case 'y':
                                    return "YRB";
                                case 'w':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        case 'w':
                            switch (c)
                            {
                                case 'g':
                                    return "WGR";
                                case 'b':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                case 'b':
                    switch (b)
                    {
                        case 'y':
                            switch (c)
                            {
                                case 'r':
                                    return "YRB";
                                case 'o':
                                    return "YBO";
                                default:
                                    return "ERROR";
                            }
                        case 'r':
                            switch (c)
                            {
                                case 'y':
                                    return "YRB";
                                case 'w':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        case 'w':
                            switch (c)
                            {
                                case 'o':
                                    return "WBO";
                                case 'r':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        case 'o':
                            switch (c)
                            {
                                case 'w':
                                    return "WBO";
                                case 'y':
                                    return "YBO";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                case 'o':
                    switch (b)
                    {
                        case 'g':
                            switch (c)
                            {
                                case 'y':
                                    return "YOG";
                                case 'w':
                                    return "WOG";
                                default:
                                    return "ERROR";
                            }
                        case 'y':
                            switch (c)
                            {
                                case 'g':
                                    return "YOG";
                                case 'b':
                                    return "YBO";
                                default:
                                    return "ERROR";
                            }
                        case 'b':
                            switch (c)
                            {
                                case 'y':
                                    return "YBO";
                                case 'w':
                                    return "WBO";
                                default:
                                    return "ERROR";
                            }
                        case 'w':
                            switch (c)
                            {
                                case 'g':
                                    return "WOG";
                                case 'b':
                                    return "WBO";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                case 'w':
                    switch (b)
                    {
                        case 'g':
                            switch (c)
                            {
                                case 'r':
                                    return "WGR";
                                case 'o':
                                    return "WOG";
                                default:
                                    return "ERROR";
                            }
                        case 'r':
                            switch (c)
                            {
                                case 'g':
                                    return "WGR";
                                case 'b':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        case 'b':
                            switch (c)
                            {
                                case 'o':
                                    return "WBO";
                                case 'r':
                                    return "WRB";
                                default:
                                    return "ERROR";
                            }
                        case 'o':
                            switch (c)
                            {
                                case 'g':
                                    return "WOG";
                                case 'b':
                                    return "WBO";
                                default:
                                    return "ERROR";
                            }
                        default:
                            return "ERROR";
                    }
                default:
                    return "ERROR";
            }
        }

        static void Main()
        {
            Cube cube = new Cube();
            cube.scramble();

            Console.WriteLine("good cube result: " + checkCube(cube));

            Random rand = new Random();
            char[] array1 = {'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y'};
            char[] array2 = { 'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y' };
            char[] array3 = { 'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y' };
            char[] array4 = { 'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y' };
            char[] array5 = { 'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y' };
            char[] array6 = { 'g', 'y', 'b', 'r', 'w', 'o', 'g', 'y' };
            for (int i = 0; i < array1.Length; i++)
            {
                int x = rand.Next(1, 7);
                switch (x)
                {
                    case 1:
                        array1[i] = 'g';
                        array2[i] = 'y';
                        array3[i] = 'b';
                        array4[i] = 'r';
                        array5[i] = 'w';
                        array6[i] = 'o';
                        break;
                    case 2:
                        array2[i] = 'g';
                        array3[i] = 'y';
                        array4[i] = 'b';
                        array5[i] = 'r';
                        array6[i] = 'w';
                        array1[i] = 'o';
                        break;
                    case 3:
                        array3[i] = 'g';
                        array4[i] = 'y';
                        array5[i] = 'b';
                        array6[i] = 'r';
                        array1[i] = 'w';
                        array2[i] = 'o';
                        break;
                    case 4:
                        array4[i] = 'g';
                        array5[i] = 'y';
                        array6[i] = 'b';
                        array1[i] = 'r';
                        array2[i] = 'w';
                        array3[i] = 'o';
                        break;
                    case 5:
                        array5[i] = 'g';
                        array6[i] = 'y';
                        array1[i] = 'b';
                        array2[i] = 'r';
                        array3[i] = 'w';
                        array4[i] = 'o';
                        break;
                    case 6:
                        array6[i] = 'g';
                        array1[i] = 'y';
                        array2[i] = 'b';
                        array3[i] = 'r';
                        array4[i] = 'w';
                        array5[i] = 'o';
                        break;

                }
            }

            Cube badCube = new Cube(array1, array2, array3, array4, array5, array6);
            badCube.scramble();

            Console.WriteLine("bad cube result: " + checkCube(badCube));
        }
    }
}