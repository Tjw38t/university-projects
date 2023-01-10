using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{
    //Enum utilized by rotation functions
    COUNTERCLOCKWISE, CLOCKWISE
}

public enum ColorEnum
{
    //Enum of ColorEnums on the cube used to help determine current cube orientation. Also contains potential and unknown ColorEnums for pattern matching
    WHITE, YELLOW, GREEN, RED, BLUE, ORANGE, PC_1, PC_2, PC_3, PC_4, UNKNOWN
}

public class Cube
{
    //Arrays of characters representing the layout of each face of the cube
    public char[] white = new char[8];
    public char[] green = new char[8];
    public char[] orange = new char[8];
    public char[] red = new char[8];
    public char[] blue = new char[8];
    public char[] yellow = new char[8];

    public List<string> moveList = new List<string>();  //list of moves where the initial of the face's ColorEnum is given, and a quotation mark indicates a counterclockwise move of that face
    public ColorEnum upFace = ColorEnum.WHITE;  //variable for relative rotation functions to determine which side of the cube is the front, back, left, etc.
    public ColorEnum frontFace = ColorEnum.GREEN;   //variable for relative rotation functions to determine which side of the cube is the front, back, left, etc.

    //Constructor method for a desired cube state
    public Cube(char[] g, char[] y, char[] b, char[] r, char[] w, char[] o)
    {
        white = w;
        green = g;
        orange = o;
        red = r;
        blue = b;
        yellow = y;
    }

    //Constructor method for an unscrambled Rubik's Cube
    public Cube()
    {
        for (int i = 0; i < 8; i++)
        {
            white[i] = 'w';
            green[i] = 'g';
            orange[i] = 'o';
            red[i] = 'r';
            blue[i] = 'b';
            yellow[i] = 'y';
        }

    }

    //Takes two char variables by reference and swaps their values
    private void swap(ref char a, ref char b)
    {
        char hold = a;
        a = b;
        b = hold;
    }

    public void clearCubeState()
    {
        white = null;
        green = null;
        orange = null;
        red = null;
        blue = null;
        yellow = null;
    }

    //Function to randomly scramble the cube for testing
    public void scramble()
    {
        System.Random rand = new System.Random();
        int count = rand.Next(20, 30);
        while (count > 0)
        {
            int face = rand.Next(1, 6);
            switch (face)
            {
                case 1:
                    rotateWhite(Direction.CLOCKWISE);
                    break;
                case 2:
                    rotateGreen(Direction.CLOCKWISE);
                    break;
                case 3:
                    rotateOrange(Direction.CLOCKWISE);
                    break;
                case 4:
                    rotateRed(Direction.CLOCKWISE);
                    break;
                case 5:
                    rotateBlue(Direction.CLOCKWISE);
                    break;
                case 6:
                    rotateYellow(Direction.CLOCKWISE);
                    break;
            }
            count--;
        }
        moveList.Clear();
    }

    //function to rotate the white side of the cube in a direction according to the passed Direction
    public void rotateWhite(Direction dir)
    {
        if (dir == Direction.CLOCKWISE)
        {
            swap(ref white[0], ref white[2]);
            swap(ref white[1], ref white[3]);
            swap(ref white[0], ref white[4]);
            swap(ref white[1], ref white[5]);
            swap(ref white[0], ref white[6]);
            swap(ref white[1], ref white[7]);

            swap(ref green[0], ref orange[0]);
            swap(ref green[1], ref orange[1]);
            swap(ref green[2], ref orange[2]);
            swap(ref green[0], ref blue[0]);
            swap(ref green[1], ref blue[1]);
            swap(ref green[2], ref blue[2]);
            swap(ref green[0], ref red[0]);
            swap(ref green[1], ref red[1]);
            swap(ref green[2], ref red[2]);

            moveList.Add("U");
        }
        else if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref white[0], ref white[6]);
            swap(ref white[1], ref white[7]);
            swap(ref white[0], ref white[4]);
            swap(ref white[1], ref white[5]);
            swap(ref white[0], ref white[2]);
            swap(ref white[1], ref white[3]);


            swap(ref green[0], ref red[0]);
            swap(ref green[1], ref red[1]);
            swap(ref green[2], ref red[2]);
            swap(ref green[0], ref blue[0]);
            swap(ref green[1], ref blue[1]);
            swap(ref green[2], ref blue[2]);
            swap(ref green[0], ref orange[0]);
            swap(ref green[1], ref orange[1]);
            swap(ref green[2], ref orange[2]);

            moveList.Add("U'");
        }
    }

    //function to rotate the green side of the cube in a direction according to the passed Direction
    public void rotateGreen(Direction dir)
    {
        if (dir == Direction.CLOCKWISE)
        {
            swap(ref green[0], ref green[2]);
            swap(ref green[1], ref green[3]);
            swap(ref green[0], ref green[4]);
            swap(ref green[1], ref green[5]);
            swap(ref green[0], ref green[6]);
            swap(ref green[1], ref green[7]);

            swap(ref white[6], ref red[0]);
            swap(ref white[5], ref red[7]);
            swap(ref white[4], ref red[6]);
            swap(ref white[6], ref yellow[4]);
            swap(ref white[5], ref yellow[5]);
            swap(ref white[4], ref yellow[6]);
            swap(ref white[6], ref orange[4]);
            swap(ref white[5], ref orange[3]);
            swap(ref white[4], ref orange[2]);

            moveList.Add("F");
        }
        else if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref green[0], ref green[6]);
            swap(ref green[1], ref green[7]);
            swap(ref green[0], ref green[4]);
            swap(ref green[1], ref green[5]);
            swap(ref green[0], ref green[2]);
            swap(ref green[1], ref green[3]);


            swap(ref yellow[4], ref red[0]);
            swap(ref yellow[5], ref red[7]);
            swap(ref yellow[6], ref red[6]);
            swap(ref yellow[4], ref white[6]);
            swap(ref yellow[5], ref white[5]);
            swap(ref yellow[6], ref white[4]);
            swap(ref yellow[4], ref orange[4]);
            swap(ref yellow[5], ref orange[3]);
            swap(ref yellow[6], ref orange[2]);

            moveList.Add("F'");
        }
    }

    //function to rotate the orange side of the cube in a direction according to the passed Direction
    public void rotateOrange(Direction dir)
    {
        if (dir == Direction.CLOCKWISE)
        {
            swap(ref orange[0], ref orange[2]);
            swap(ref orange[1], ref orange[3]);
            swap(ref orange[0], ref orange[4]);
            swap(ref orange[1], ref orange[5]);
            swap(ref orange[0], ref orange[6]);
            swap(ref orange[1], ref orange[7]);

            swap(ref white[0], ref green[0]);
            swap(ref white[7], ref green[7]);
            swap(ref white[6], ref green[6]);
            swap(ref white[0], ref yellow[6]);
            swap(ref white[7], ref yellow[7]);
            swap(ref white[6], ref yellow[0]);
            swap(ref white[0], ref blue[4]);
            swap(ref white[7], ref blue[3]);
            swap(ref white[6], ref blue[2]);

            moveList.Add("L");
        }
        else if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref orange[0], ref orange[6]);
            swap(ref orange[1], ref orange[7]);
            swap(ref orange[0], ref orange[4]);
            swap(ref orange[1], ref orange[5]);
            swap(ref orange[0], ref orange[2]);
            swap(ref orange[1], ref orange[3]);


            swap(ref yellow[6], ref green[0]);
            swap(ref yellow[7], ref green[7]);
            swap(ref yellow[0], ref green[6]);
            swap(ref yellow[6], ref white[0]);
            swap(ref yellow[7], ref white[7]);
            swap(ref yellow[0], ref white[6]);
            swap(ref yellow[6], ref blue[4]);
            swap(ref yellow[7], ref blue[3]);
            swap(ref yellow[0], ref blue[2]);

            moveList.Add("L'");
        }
    }

    //function to rotate the red side of the cube in a direction according to the passed Direction
    public void rotateRed(Direction dir)
    {
        if (dir == Direction.CLOCKWISE)
        {
            swap(ref red[0], ref red[2]);
            swap(ref red[1], ref red[3]);
            swap(ref red[0], ref red[4]);
            swap(ref red[1], ref red[5]);
            swap(ref red[0], ref red[6]);
            swap(ref red[1], ref red[7]);

            swap(ref white[2], ref blue[6]);
            swap(ref white[3], ref blue[7]);
            swap(ref white[4], ref blue[0]);
            swap(ref white[2], ref yellow[4]);
            swap(ref white[3], ref yellow[3]);
            swap(ref white[4], ref yellow[2]);
            swap(ref white[2], ref green[2]);
            swap(ref white[3], ref green[3]);
            swap(ref white[4], ref green[4]);

            moveList.Add("R");
        }
        else if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref red[0], ref red[6]);
            swap(ref red[1], ref red[7]);
            swap(ref red[0], ref red[4]);
            swap(ref red[1], ref red[5]);
            swap(ref red[0], ref red[2]);
            swap(ref red[1], ref red[3]);


            swap(ref yellow[2], ref blue[0]);
            swap(ref yellow[3], ref blue[7]);
            swap(ref yellow[4], ref blue[6]);
            swap(ref yellow[2], ref white[4]);
            swap(ref yellow[3], ref white[3]);
            swap(ref yellow[4], ref white[2]);
            swap(ref yellow[2], ref green[4]);
            swap(ref yellow[3], ref green[3]);
            swap(ref yellow[4], ref green[2]);

            moveList.Add("R'");
        }
    }

    //function to rotate the blue side of the cube in a direction according to the passed Direction
    public void rotateBlue(Direction dir)
    {
        if (dir == Direction.CLOCKWISE)
        {
            swap(ref blue[0], ref blue[2]);
            swap(ref blue[1], ref blue[3]);
            swap(ref blue[0], ref blue[4]);
            swap(ref blue[1], ref blue[5]);
            swap(ref blue[0], ref blue[6]);
            swap(ref blue[1], ref blue[7]);

            swap(ref white[0], ref orange[6]);
            swap(ref white[1], ref orange[7]);
            swap(ref white[2], ref orange[0]);
            swap(ref white[0], ref yellow[2]);
            swap(ref white[1], ref yellow[1]);
            swap(ref white[2], ref yellow[0]);
            swap(ref white[0], ref red[2]);
            swap(ref white[1], ref red[3]);
            swap(ref white[2], ref red[4]);

            moveList.Add("B");
        }
        else if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref blue[0], ref blue[6]);
            swap(ref blue[1], ref blue[7]);
            swap(ref blue[0], ref blue[4]);
            swap(ref blue[1], ref blue[5]);
            swap(ref blue[0], ref blue[2]);
            swap(ref blue[1], ref blue[3]);


            swap(ref yellow[2], ref orange[6]);
            swap(ref yellow[1], ref orange[7]);
            swap(ref yellow[0], ref orange[0]);
            swap(ref yellow[2], ref white[0]);
            swap(ref yellow[1], ref white[1]);
            swap(ref yellow[0], ref white[2]);
            swap(ref yellow[2], ref red[2]);
            swap(ref yellow[1], ref red[3]);
            swap(ref yellow[0], ref red[4]);

            moveList.Add("B'");
        }
    }

    //function to rotate the yellow side of the cube in a direction according to the passed Direction
    public void rotateYellow(Direction dir)
    {
        if (dir == Direction.COUNTERCLOCKWISE)
        {
            swap(ref yellow[0], ref yellow[2]);
            swap(ref yellow[1], ref yellow[3]);
            swap(ref yellow[0], ref yellow[4]);
            swap(ref yellow[1], ref yellow[5]);
            swap(ref yellow[0], ref yellow[6]);
            swap(ref yellow[1], ref yellow[7]);

            swap(ref green[6], ref orange[6]);
            swap(ref green[5], ref orange[5]);
            swap(ref green[4], ref orange[4]);
            swap(ref green[6], ref blue[6]);
            swap(ref green[5], ref blue[5]);
            swap(ref green[4], ref blue[4]);
            swap(ref green[6], ref red[6]);
            swap(ref green[5], ref red[5]);
            swap(ref green[4], ref red[4]);

            moveList.Add("D'");
        }
        else if (dir == Direction.CLOCKWISE)
        {
            swap(ref yellow[0], ref yellow[6]);
            swap(ref yellow[1], ref yellow[7]);
            swap(ref yellow[0], ref yellow[4]);
            swap(ref yellow[1], ref yellow[5]);
            swap(ref yellow[0], ref yellow[2]);
            swap(ref yellow[1], ref yellow[3]);


            swap(ref green[4], ref red[4]);
            swap(ref green[5], ref red[5]);
            swap(ref green[6], ref red[6]);
            swap(ref green[4], ref blue[4]);
            swap(ref green[5], ref blue[5]);
            swap(ref green[6], ref blue[6]);
            swap(ref green[4], ref orange[4]);
            swap(ref green[5], ref orange[5]);
            swap(ref green[6], ref orange[6]);

            moveList.Add("D");
        }
    }

    // Rotate face by is char
    public void rotateByFaceChar(char face, Direction dir)
    {
        if (face == 'y')
            rotateYellow(dir);
        else if (face == 'w')
            rotateWhite(dir);
        else if (face == 'g')
            rotateGreen(dir);
        else if (face == 'o')
            rotateOrange(dir);
        else if (face == 'r')
            rotateRed(dir);
        else
            rotateBlue(dir);
    }

    // Access face values based on face char
    public char accessByFaceChar(char face, int index)
    {
        if (face == 'y')
            return yellow[index];
        else if (face == 'w')
            return white[index];
        else if (face == 'g')
            return green[index];
        else if (face == 'o')
            return orange[index];
        else if (face == 'r')
            return red[index];
        else
            return blue[index];
    }

    // Get char from ColorEnum
    public static char getCharFromColor(ColorEnum ColorEnum)
    {
        switch (ColorEnum)
        {
            case ColorEnum.WHITE:
                return 'w';
            case ColorEnum.YELLOW:
                return 'y';
            case ColorEnum.BLUE:
                return 'b';
            case ColorEnum.RED:
                return 'r';
            case ColorEnum.ORANGE:
                return 'o';
            case ColorEnum.GREEN:
                return 'g';
            default:
                return '\0';
        }
    }

    // Get ColorEnum from char
    public static ColorEnum getColorEnumFromChar(char color)
    {
        switch (color)
        {
            case 'w':
                return ColorEnum.WHITE;
            case 'y':
                return ColorEnum.YELLOW;
            case 'b':
                return ColorEnum.BLUE;
            case 'r':
                return ColorEnum.RED;
            case 'o':
                return ColorEnum.ORANGE;
            case 'g':
                return ColorEnum.GREEN;
            default:
                return (ColorEnum)(-1);
        }
    }

    // Get face array from ColorEnum
    public char[]? getFaceArrayFromColor(ColorEnum ColorEnum)
    {
        switch (ColorEnum)
        {
            case ColorEnum.WHITE:
                return white;
            case ColorEnum.YELLOW:
                return yellow;
            case ColorEnum.BLUE:
                return blue;
            case ColorEnum.RED:
                return red;
            case ColorEnum.ORANGE:
                return orange;
            case ColorEnum.GREEN:
                return green;
            default:
                return null;
        }
    }

    //function to rotate the current orientation's "left" side of the cube, determined by current frontFace and upFace value
    public void rotateLeft(Direction dir)
    {
        if (upFace == ColorEnum.WHITE)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    rotateOrange(dir);
                    break;
                case ColorEnum.RED:
                    rotateGreen(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateRed(dir);
                    break;
                case ColorEnum.ORANGE:
                    rotateBlue(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.YELLOW)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    rotateRed(dir);
                    break;
                case ColorEnum.RED:
                    rotateBlue(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateOrange(dir);
                    break;
                case ColorEnum.ORANGE:
                    rotateGreen(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.GREEN)
        {
            switch (frontFace)
            {
                case ColorEnum.ORANGE:
                    rotateWhite(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateOrange(dir);
                    break;
                case ColorEnum.RED:
                    rotateYellow(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateRed(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.RED)
        {
            switch (frontFace)
            {
                case ColorEnum.YELLOW:
                    rotateGreen(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateYellow(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateBlue(dir);
                    break;
                case ColorEnum.GREEN:
                    rotateWhite(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.BLUE)
        {
            switch (frontFace)
            {
                case ColorEnum.ORANGE:
                    rotateYellow(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateOrange(dir);
                    break;
                case ColorEnum.RED:
                    rotateWhite(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateRed(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.ORANGE)
        {
            switch (frontFace)
            {
                case ColorEnum.WHITE:
                    rotateGreen(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateWhite(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateBlue(dir);
                    break;
                case ColorEnum.GREEN:
                    rotateYellow(dir);
                    break;
            }
        }
    }


    //function to rotate the current orientation's "right" side of the cube, determined by current frontFace and upFace value
    public void rotateRight(Direction dir)
    {
        if (upFace == ColorEnum.YELLOW)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    rotateOrange(dir);
                    break;
                case ColorEnum.RED:
                    rotateGreen(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateRed(dir);
                    break;
                case ColorEnum.ORANGE:
                    rotateBlue(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.WHITE)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    rotateRed(dir);
                    break;
                case ColorEnum.RED:
                    rotateBlue(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateOrange(dir);
                    break;
                case ColorEnum.ORANGE:
                    rotateGreen(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.GREEN)
        {
            switch (frontFace)
            {
                case ColorEnum.ORANGE:
                    rotateYellow(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateRed(dir);
                    break;
                case ColorEnum.RED:
                    rotateWhite(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateOrange(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.RED)
        {
            switch (frontFace)
            {
                case ColorEnum.YELLOW:
                    rotateBlue(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateWhite(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateGreen(dir);
                    break;
                case ColorEnum.GREEN:
                    rotateYellow(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.BLUE)
        {
            switch (frontFace)
            {
                case ColorEnum.ORANGE:
                    rotateWhite(dir);
                    break;
                case ColorEnum.WHITE:
                    rotateRed(dir);
                    break;
                case ColorEnum.RED:
                    rotateYellow(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateOrange(dir);
                    break;
            }
        }
        else if (upFace == ColorEnum.ORANGE)
        {
            switch (frontFace)
            {
                case ColorEnum.WHITE:
                    rotateBlue(dir);
                    break;
                case ColorEnum.BLUE:
                    rotateYellow(dir);
                    break;
                case ColorEnum.YELLOW:
                    rotateGreen(dir);
                    break;
                case ColorEnum.GREEN:
                    rotateWhite(dir);
                    break;
            }
        }
    }

    //function to rotate the current orientation's "up" side of the cube, determined by current frontFace and upFace value
    public void rotateUp(Direction dir)
    {
        switch (upFace)
        {
            case ColorEnum.WHITE:
                rotateWhite(dir);
                break;
            case ColorEnum.YELLOW:
                rotateYellow(dir);
                break;
            case ColorEnum.GREEN:
                rotateGreen(dir);
                break;
            case ColorEnum.RED:
                rotateRed(dir);
                break;
            case ColorEnum.BLUE:
                rotateBlue(dir);
                break;
            case ColorEnum.ORANGE:
                rotateOrange(dir);
                break;
        }
    }

    //function to rotate the current orientation's "down" side of the cube, determined by current frontFace and upFace value
    public void rotateDown(Direction dir)
    {
        switch (upFace)
        {
            case ColorEnum.WHITE:
                rotateYellow(dir);
                break;
            case ColorEnum.YELLOW:
                rotateWhite(dir);
                break;
            case ColorEnum.GREEN:
                rotateBlue(dir);
                break;
            case ColorEnum.RED:
                rotateOrange(dir);
                break;
            case ColorEnum.BLUE:
                rotateGreen(dir);
                break;
            case ColorEnum.ORANGE:
                rotateRed(dir);
                break;
        }
    }

    //function to rotate the current orientation's "front" side of the cube, determined by current frontFace and upFace value
    public void rotateFront(Direction dir)
    {
        switch (frontFace)
        {
            case ColorEnum.WHITE:
                rotateWhite(dir);
                break;
            case ColorEnum.YELLOW:
                rotateYellow(dir);
                break;
            case ColorEnum.GREEN:
                rotateGreen(dir);
                break;
            case ColorEnum.RED:
                rotateRed(dir);
                break;
            case ColorEnum.BLUE:
                rotateBlue(dir);
                break;
            case ColorEnum.ORANGE:
                rotateOrange(dir);
                break;
        }
    }

    //function to rotate the current orientation's "back" side of the cube, determined by current frontFace and upFace value
    public void rotateBack(Direction dir)
    {
        switch (frontFace)
        {
            case ColorEnum.WHITE:
                rotateYellow(dir);
                break;
            case ColorEnum.YELLOW:
                rotateWhite(dir);
                break;
            case ColorEnum.GREEN:
                rotateBlue(dir);
                break;
            case ColorEnum.RED:
                rotateOrange(dir);
                break;
            case ColorEnum.BLUE:
                rotateGreen(dir);
                break;
            case ColorEnum.ORANGE:
                rotateRed(dir);
                break;
        }
    }

    public void rotateUpWide(Direction dir)
    {
        Direction oppDir = dir == Direction.CLOCKWISE ? Direction.COUNTERCLOCKWISE : Direction.CLOCKWISE;
        rotateDown(dir);
        frontFace = getAdjacentFace(upFace, frontFace, oppDir);
    }

    public void rotateDownWide(Direction dir)
    {
        Direction oppDir = dir == Direction.CLOCKWISE ? Direction.COUNTERCLOCKWISE : Direction.CLOCKWISE;
        rotateUp(oppDir);
        frontFace = getAdjacentFace(upFace, frontFace, oppDir);
    }

    public void rotateRightWide(Direction dir)
    {
        rotateLeft(dir);
        ColorEnum newFrontFace = dir == Direction.CLOCKWISE ? getOppositeFace(upFace) : upFace;
        ColorEnum newUpFace = dir == Direction.CLOCKWISE ? frontFace : getOppositeFace(frontFace);
        frontFace = newFrontFace;
        upFace = newUpFace;
    }

    public void rotateLeftWide(Direction dir)
    {
        rotateRight(dir);
        ColorEnum newFrontFace = dir == Direction.CLOCKWISE ? upFace : getOppositeFace(upFace);
        ColorEnum newUpFace = dir == Direction.CLOCKWISE ? getOppositeFace(frontFace) : frontFace;
        frontFace = newFrontFace;
        upFace = newUpFace;
    }

    public void rotateFrontWide(Direction dir)
    {
        ColorEnum newUpFace = getAdjacentFace(upFace, frontFace, dir);
        rotateBack(dir);
        upFace = newUpFace;
    }

    public void rotateBackWide(Direction dir)
    {
        ColorEnum newUpFace = getAdjacentFace(upFace, frontFace, dir == Direction.CLOCKWISE ? Direction.COUNTERCLOCKWISE : Direction.CLOCKWISE);
        rotateFront(dir);
        upFace = newUpFace;
    }

    public void rotateMiddle(Direction dir)
    {
        rotateRight(dir);
        rotateLeft(dir == Direction.CLOCKWISE ? Direction.COUNTERCLOCKWISE : Direction.CLOCKWISE);
        ColorEnum newUpFace = dir == Direction.CLOCKWISE ? getOppositeFace(frontFace) : frontFace;
        ColorEnum newFrontFace = dir == Direction.CLOCKWISE ? upFace : getOppositeFace(upFace);
        upFace = newUpFace;
        frontFace = newFrontFace;
    }

    // Function to get the face adjacent to another given up face, front face, and direction
    public static ColorEnum getAdjacentFace(ColorEnum up, ColorEnum front, Direction dir)
    {
        switch (up)
        {
            case ColorEnum.WHITE:
                switch (front)
                {
                    case ColorEnum.GREEN:
                        return dir == Direction.CLOCKWISE ? ColorEnum.ORANGE : ColorEnum.RED;
                    case ColorEnum.RED:
                        return dir == Direction.CLOCKWISE ? ColorEnum.GREEN : ColorEnum.BLUE;
                    case ColorEnum.BLUE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.RED : ColorEnum.ORANGE;
                    case ColorEnum.ORANGE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.BLUE : ColorEnum.GREEN;
                }
                break;
            case ColorEnum.YELLOW:
                switch (front)
                {
                    case ColorEnum.ORANGE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.GREEN : ColorEnum.BLUE;
                    case ColorEnum.BLUE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.ORANGE : ColorEnum.RED;
                    case ColorEnum.RED:
                        return dir == Direction.CLOCKWISE ? ColorEnum.BLUE : ColorEnum.GREEN;
                    case ColorEnum.GREEN:
                        return dir == Direction.CLOCKWISE ? ColorEnum.RED : ColorEnum.ORANGE;
                }
                break;
            case ColorEnum.RED:
                switch (front)
                {
                    case ColorEnum.YELLOW:
                        return dir == Direction.CLOCKWISE ? ColorEnum.GREEN : ColorEnum.BLUE;
                    case ColorEnum.BLUE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.YELLOW : ColorEnum.WHITE;
                    case ColorEnum.WHITE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.BLUE : ColorEnum.GREEN;
                    case ColorEnum.GREEN:
                        return dir == Direction.CLOCKWISE ? ColorEnum.WHITE : ColorEnum.YELLOW;
                }
                break;
            case ColorEnum.BLUE:
                switch (front)
                {
                    case ColorEnum.ORANGE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.YELLOW : ColorEnum.WHITE;
                    case ColorEnum.WHITE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.ORANGE : ColorEnum.RED;
                    case ColorEnum.RED:
                        return dir == Direction.CLOCKWISE ? ColorEnum.WHITE : ColorEnum.YELLOW;
                    case ColorEnum.YELLOW:
                        return dir == Direction.CLOCKWISE ? ColorEnum.RED : ColorEnum.ORANGE;
                }
                break;
            case ColorEnum.ORANGE:
                switch (front)
                {
                    case ColorEnum.WHITE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.GREEN : ColorEnum.BLUE;
                    case ColorEnum.BLUE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.WHITE : ColorEnum.YELLOW;
                    case ColorEnum.YELLOW:
                        return dir == Direction.CLOCKWISE ? ColorEnum.BLUE : ColorEnum.GREEN;
                    case ColorEnum.GREEN:
                        return dir == Direction.CLOCKWISE ? ColorEnum.YELLOW : ColorEnum.WHITE;
                }
                break;
            case ColorEnum.GREEN:
                switch (front)
                {
                    case ColorEnum.ORANGE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.WHITE : ColorEnum.YELLOW;
                    case ColorEnum.YELLOW:
                        return dir == Direction.CLOCKWISE ? ColorEnum.ORANGE : ColorEnum.RED;
                    case ColorEnum.RED:
                        return dir == Direction.CLOCKWISE ? ColorEnum.YELLOW : ColorEnum.WHITE;
                    case ColorEnum.WHITE:
                        return dir == Direction.CLOCKWISE ? ColorEnum.RED : ColorEnum.ORANGE;
                }
                break;
        }

        return (ColorEnum)(-1);
    }

    // Function to get the face opposite of the passed face
    public static ColorEnum getOppositeFace(ColorEnum face)
    {
        switch (face)
        {
            case ColorEnum.WHITE:
                return ColorEnum.YELLOW;
            case ColorEnum.YELLOW:
                return ColorEnum.WHITE;
            case ColorEnum.GREEN:
                return ColorEnum.BLUE;
            case ColorEnum.BLUE:
                return ColorEnum.GREEN;
            case ColorEnum.RED:
                return ColorEnum.ORANGE;
            case ColorEnum.ORANGE:
                return ColorEnum.RED;
        }
        return (ColorEnum)(-1);
    }

    /*this function returns the current orientation of the cube determined by the upFace and frontFace values
     the current orientation is returned as a char array where the ColorEnums are returned in order of [front, right, back, left, up, down]*/
    public char[] getOrientation()
    {
        char[] result = new char[6];
        if (upFace == ColorEnum.WHITE)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    result = new char[] { 'g', 'r', 'b', 'o', 'w', 'y' };
                    break;
                case ColorEnum.RED:
                    result = new char[] { 'r', 'b', 'o', 'g', 'w', 'y' };
                    break;
                case ColorEnum.BLUE:
                    result = new char[] { 'b', 'o', 'g', 'r', 'w', 'y' };
                    break;
                case ColorEnum.ORANGE:
                    result = new char[] { 'o', 'g', 'r', 'b', 'w', 'y' };
                    break;
            }
        }
        else if (upFace == ColorEnum.YELLOW)
        {
            switch (frontFace)
            {
                case ColorEnum.GREEN:
                    result = new char[] { 'g', 'o', 'b', 'r', 'y', 'w' };
                    break;
                case ColorEnum.RED:
                    result = new char[] { 'r', 'g', 'o', 'b', 'y', 'w' };
                    break;
                case ColorEnum.BLUE:
                    result = new char[] { 'b', 'r', 'g', 'o', 'y', 'w' };
                    break;
                case ColorEnum.ORANGE:
                    result = new char[] { 'o', 'b', 'r', 'g', 'y', 'w' };
                    break;
            }
        }
        return (result);
    }

    //this function takes two char variables representing the desired upFace and frontFace values, and updates those values accordingly
    public void changeOrientation(char up, char front)
    {
        switch (up)
        {
            case 'w':
                upFace = ColorEnum.WHITE;
                break;
            case 'y':
                upFace = ColorEnum.YELLOW;
                break;
        }
        switch (front)
        {
            case 'g':
                frontFace = ColorEnum.GREEN;
                break;
            case 'r':
                frontFace = ColorEnum.RED;
                break;
            case 'b':
                frontFace = ColorEnum.BLUE;
                break;
            case 'o':
                frontFace = ColorEnum.ORANGE;
                break;
        }
    }
    public string printCubeState()
    {
        string orangeString = new string(orange);
        string blueString = new string(blue);
        string redString = new string(red);
        string greenString = new string(green);
        string whiteString = new string(white);
        string yellowString = new string(yellow);

        return orangeString + blueString + redString + greenString + whiteString + yellowString;
    }

    public void cubePrint()
    {
        Console.WriteLine($"      {white[0]} {white[1]} {white[2]}");
        Console.WriteLine($"      {white[7]} w {white[3]}");
        Console.WriteLine($"      {white[6]} {white[5]} {white[4]}");
        Console.WriteLine("      --------");
        Console.WriteLine($"{orange[0]} {orange[1]} {orange[2]} | {green[0]} {green[1]} {green[2]} | {red[0]} {red[1]} {red[2]} | {blue[0]} {blue[1]} {blue[2]}");
        Console.WriteLine($"{orange[7]} o {orange[3]} | {green[7]} g {green[3]} | {red[7]} r {red[3]} | {blue[7]} b {blue[3]}");
        Console.WriteLine($"{orange[6]} {orange[5]} {orange[4]} | {green[6]} {green[5]} {green[4]} | {red[6]} {red[5]} {red[4]} | {blue[6]} {blue[5]} {blue[4]}");
        Console.WriteLine("      --------");
        Console.WriteLine($"      {yellow[6]} {yellow[5]} {yellow[4]}");
        Console.WriteLine($"      {yellow[7]} y {yellow[3]}");
        Console.WriteLine($"      {yellow[0]} {yellow[1]} {yellow[2]}\n\n");

    }

    //This function recursively cleans the movelist by removing/replacing inefficient patterns that are a result of the computational solving approach
    public void cleanMoveList()
    {
        int i = 0;
        bool correction = false;
        while (i < moveList.Count - 2)
        {
            if (moveList[i] == moveList[i + 1] && moveList[i] == moveList[i + 2])
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);

                switch (moveList[i])
                {
                    case "U":
                        moveList[i] = "U'";
                        break;
                    case "U'":
                        moveList[i] = "U";
                        break;
                    case "F":
                        moveList[i] = "F'";
                        break;
                    case "F'":
                        moveList[i] = "F";
                        break;
                    case "R":
                        moveList[i] = "R'";
                        break;
                    case "R'":
                        moveList[i] = "R";
                        break;
                    case "B":
                        moveList[i] = "B'";
                        break;
                    case "B'":
                        moveList[i] = "B";
                        break;
                    case "L":
                        moveList[i] = "L'";
                        break;
                    case "L'":
                        moveList[i] = "L";
                        break;
                    case "D":
                        moveList[i] = "D'";
                        break;
                    case "D'":
                        moveList[i] = "D";
                        break;
                }
                correction = true;
            }

            else if (moveList[i] == "U" && moveList[i + 1] == "U'" || moveList[i + 1] == "U" && moveList[i] == "U'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }
            else if (moveList[i] == "F" && moveList[i + 1] == "F'" || moveList[i + 1] == "F" && moveList[i] == "F'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }
            else if (moveList[i] == "R" && moveList[i + 1] == "R'" || moveList[i + 1] == "R" && moveList[i] == "R'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }
            else if (moveList[i] == "B" && moveList[i + 1] == "B'" || moveList[i + 1] == "B" && moveList[i] == "B'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }
            else if (moveList[i] == "L" && moveList[i + 1] == "L'" || moveList[i + 1] == "L" && moveList[i] == "L'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }
            else if (moveList[i] == "D" && moveList[i + 1] == "D'" || moveList[i + 1] == "D" && moveList[i] == "D'")
            {
                moveList.RemoveAt(i);
                moveList.RemoveAt(i);
                correction = true;
            }

            i++;
        }
        if (correction)
        {
            cleanMoveList();
        }
    }

    //This function prints the current moveList
    public void moveListPrint()
    {
        foreach (var x in moveList)
        {
            Console.Write(x + ", ");
        }
        Console.Write("Done!\n");
    }

    public int getYellowCornerValue(int corner) //Returns the value of the corner pieces for use with PositionYellowCorners
    {                                           //Each of the four possible corners has a unique value
        int sum = 0;
        if (corner == 0)
        {
            sum += ((int)this.yellow[0]);
            sum += ((int)this.orange[6]);
            sum += ((int)this.blue[4]);
            return sum;
        }
        if (corner == 2)
        {
            sum += ((int)this.yellow[2]);
            sum += ((int)this.red[4]);
            sum += ((int)this.blue[6]);
            return sum;
        }
        if (corner == 4)
        {
            sum += ((int)this.yellow[4]);
            sum += ((int)this.green[4]);
            sum += ((int)this.red[6]);
            return sum;
        }
        if (corner == 6)
        {
            sum += ((int)this.yellow[6]);
            sum += ((int)this.green[6]);
            sum += ((int)this.orange[4]);
            return sum;
        }
        else return 0;
    }

    public int[] getThistlethwaiteArray()
    {
        int[] array = new int[40];
        Dictionary<int, int> solvedValues = new Dictionary<int, int>();
        solvedValues.Add(222, 0);
        solvedValues.Add(233, 1);
        solvedValues.Add(217, 2); //Repeat
        solvedValues.Add(230, 3);
        solvedValues.Add(224, 4);
        solvedValues.Add(235, 5);
        solvedValues.Add(219, 6);
        solvedValues.Add(232, 7);
        solvedValues.Add(0, 8); //Repeat
        solvedValues.Add(214, 9);
        solvedValues.Add(212, 10);
        solvedValues.Add(209, 11);
        solvedValues.Add(336, 12);
        solvedValues.Add(331, 13);
        solvedValues.Add(328, 14);
        solvedValues.Add(333, 15); //Repeat
        solvedValues.Add(338, 16);
        solvedValues.Add(335, 17);
        solvedValues.Add(330, 18);
        solvedValues.Add(1, 19); //Repeat

        int val;
        val = (((int)this.white[5]) + (int)this.green[1]);
        if (val == 217)
        {
            if ((white[5] == 119) || (green[1] == 119))
            {
                array[0] = 2;
            }
            else
            {
                array[0] = 8;
            }
        }
        else
        {
            array[0] = solvedValues[val];
        }
        val = (((int)this.white[3]) + (int)this.red[1]);
        if (val == 217)
        {
            if ((white[3] == 119) || (red[1] == 119))
            {
                array[1] = 2;
            }
            else
            {
                array[1] = 8;
            }
        }
        else
        {
            array[1] = solvedValues[val];
        }
        val = (((int)this.white[1]) + (int)this.blue[1]);
        if (val == 217)
        {
            if ((white[1] == 119) || (blue[1] == 119))
            {
                array[2] = 2;
            }
            else
            {
                array[2] = 8;
            }
        }
        else
        {
            array[2] = solvedValues[val];
        }
        val = (((int)this.white[7]) + (int)this.orange[1]);
        if (val == 217)
        {
            if ((white[7] == 119) || (orange[1] == 119))
            {
                array[3] = 2;
            }
            else
            {
                array[3] = 8;
            }
        }
        else
        {
            array[3] = solvedValues[val];
        }
        val = (((int)this.yellow[5]) + (int)this.green[5]);
        if (val == 217)
        {
            if ((yellow[5] == 119) || (green[5] == 119))
            {
                array[4] = 2;
            }
            else
            {
                array[4] = 8;
            }
        }
        else
        {
            array[4] = solvedValues[val];
        }
        val = (((int)this.yellow[3]) + (int)this.red[5]);
        if (val == 217)
        {
            if ((yellow[3] == 119) || (red[5] == 119))
            {
                array[5] = 2;
            }
            else
            {
                array[5] = 8;
            }
        }
        else
        {
            array[5] = solvedValues[val];
        }
        val = (((int)this.yellow[1]) + (int)this.blue[5]);
        if (val == 217)
        {
            if ((yellow[1] == 119) || (blue[5] == 119))
            {
                array[6] = 2;
            }
            else
            {
                array[6] = 8;
            }
        }
        else
        {
            array[6] = solvedValues[val];
        }
        val = (((int)this.yellow[7]) + (int)this.orange[5]);
        if (val == 217)
        {
            if ((yellow[7] == 119) || (orange[5] == 119))
            {
                array[7] = 2;
            }
            else
            {
                array[7] = 8;
            }
        }
        else
        {
            array[7] = solvedValues[val];
        }
        val = (((int)this.green[3]) + (int)this.red[7]);
        if (val == 217)
        {
            if ((green[3] == 119) || (red[7] == 119))
            {
                array[8] = 2;
            }
            else
            {
                array[8] = 8;
            }
        }
        else
        {
            array[8] = solvedValues[val];
        }
        val = (((int)this.green[7]) + (int)this.orange[3]);
        if (val == 217)
        {
            if ((green[7] == 119) || (orange[3] == 119))
            {
                array[9] = 2;
            }
            else
            {
                array[9] = 8;
            }
        }
        else
        {
            array[9] = solvedValues[val];
        }
        val = (((int)this.blue[7]) + (int)this.red[3]);
        if (val == 217)
        {
            if ((blue[7] == 119) || (red[3] == 119))
            {
                array[10] = 2;
            }
            else
            {
                array[10] = 8;
            }
        }
        else
        {
            array[10] = solvedValues[val];
        }
        val = (((int)this.blue[3]) + (int)this.orange[7]);
        if (val == 217)
        {
            if ((blue[3] == 119) || (orange[7] == 119))
            {
                array[11] = 2;
            }
            else
            {
                array[11] = 8;
            }
        }
        else
        {
            array[11] = solvedValues[val];
        }

        val = (((int)this.white[4]) + (int)this.green[2] + (int)this.red[0]);
        if (val == 333)
        {
            if ((white[4] == 119) || (green[2] == 119) || (red[0] == 119))
            {
                array[12] = 15;
            }
            else
            {
                array[12] = 19;
            }
        }
        else
        {
            array[12] = solvedValues[val];
        }
        val = (((int)this.white[2]) + (int)this.red[2] + (int)this.blue[0]);
        if (val == 333)
        {
            if ((white[2] == 119) || (blue[0] == 119) || (red[2] == 119))
            {
                array[13] = 15;
            }
            else
            {
                array[13] = 19;
            }
        }
        else
        {
            array[13] = solvedValues[val];
        }
        val = (((int)this.white[0]) + (int)this.orange[0] + (int)this.blue[2]);
        if (val == 333)
        {
            if ((white[0] == 119) || (orange[0] == 119) || (blue[2] == 119))
            {
                array[14] = 15;
            }
            else
            {
                array[14] = 19;
            }
        }
        else
        {
            array[14] = solvedValues[val];
        }
        val = (((int)this.white[6]) + (int)this.green[0] + (int)this.orange[2]);
        if (val == 333)
        {
            if ((white[6] == 119) || (green[0] == 119) || (orange[2] == 119))
            {
                array[15] = 15;
            }
            else
            {
                array[15] = 19;
            }
        }
        else
        {
            array[15] = solvedValues[val];
        }
        val = (((int)this.yellow[4]) + (int)this.green[4] + (int)this.red[6]);
        if (val == 333)
        {
            if ((yellow[4] == 119) || (green[4] == 119) || (red[6] == 119))
            {
                array[16] = 15;
            }
            else
            {
                array[16] = 19;
            }
        }
        else
        {
            array[16] = solvedValues[val];
        }
        val = (((int)this.yellow[6]) + (int)this.green[6] + (int)this.orange[4]);
        if (val == 333)
        {
            if ((yellow[6] == 119) || (green[6] == 119) || (orange[4] == 119))
            {
                array[17] = 15;
            }
            else
            {
                array[17] = 19;
            }
        }
        else
        {
            array[17] = solvedValues[val];
        }
        val = (((int)this.yellow[0]) + (int)this.orange[6] + (int)this.blue[4]);
        if (val == 333)
        {
            if ((yellow[0] == 119) || (orange[6] == 119) || (blue[4] == 119))
            {
                array[18] = 15;
            }
            else
            {
                array[18] = 19;
            }
        }
        else
        {
            array[18] = solvedValues[val];
        }
        val = (((int)this.yellow[2]) + (int)this.blue[6] + (int)this.red[4]);
        if (val == 333)
        {
            if ((yellow[2] == 119) || (blue[6] == 119) || (red[4] == 119))
            {
                array[19] = 15;
            }
            else
            {
                array[19] = 19;
            }
        }
        else
        {
            array[19] = solvedValues[val];
        }

        for (int i = 0; i < 12; i++)
        {
            switch (i)
            {
                case 0:
                    if (white[5] == 'o' || white[5] == 'r') array[i + 20] = 1;
                    else if (white[5] == 'g' || white[5] == 'b')
                    {
                        if (green[1] == 'w' || green[1] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 1:
                    if (white[3] == 'o' || white[3] == 'r') array[i + 20] = 1;
                    else if (white[3] == 'g' || white[3] == 'b')
                    {
                        if (red[1] == 'w' || red[1] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 2:
                    if (white[1] == 'o' || white[1] == 'r') array[i + 20] = 1;
                    else if (white[1] == 'g' || white[1] == 'b')
                    {
                        if (blue[1] == 'w' || blue[1] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 3:
                    if (white[7] == 'o' || white[7] == 'r') array[i + 20] = 1;
                    else if (white[7] == 'g' || white[7] == 'b')
                    {
                        if (orange[1] == 'w' || orange[1] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 4:
                    if (yellow[5] == 'o' || yellow[5] == 'r') array[i + 20] = 1;
                    else if (yellow[5] == 'g' || yellow[5] == 'b')
                    {
                        if (green[5] == 'w' || green[5] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 5:
                    if (yellow[3] == 'o' || yellow[3] == 'r') array[i + 20] = 1;
                    else if (yellow[3] == 'g' || yellow[3] == 'b')
                    {
                        if (red[5] == 'w' || red[5] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 6:
                    if (yellow[1] == 'o' || yellow[1] == 'r') array[i + 20] = 1;
                    else if (yellow[1] == 'g' || yellow[1] == 'b')
                    {
                        if (blue[5] == 'w' || blue[5] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 7:
                    if (yellow[7] == 'o' || yellow[7] == 'r') array[i + 20] = 1;
                    else if (yellow[7] == 'g' || yellow[7] == 'b')
                    {
                        if (orange[5] == 'w' || orange[5] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 8:
                    if (green[3] == 'o' || green[3] == 'r') array[i + 20] = 1;
                    else if (green[3] == 'g' || green[3] == 'b')
                    {
                        if (red[7] == 'w' || red[7] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 9:
                    if (green[7] == 'o' || green[7] == 'r') array[i + 20] = 1;
                    else if (green[7] == 'g' || green[7] == 'b')
                    {
                        if (orange[3] == 'w' || orange[3] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 10:
                    if (blue[7] == 'o' || blue[7] == 'r') array[i + 20] = 1;
                    else if (blue[7] == 'g' || blue[7] == 'b')
                    {
                        if (red[3] == 'w' || red[3] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
                case 11:
                    if (blue[3] == 'o' || blue[3] == 'r') array[i + 20] = 1;
                    else if (blue[3] == 'g' || blue[3] == 'b')
                    {
                        if (orange[7] == 'w' || orange[7] == 'y') array[i + 20] = 1;
                        else array[i + 20] = 0;
                    }
                    else array[i + 20] = 0;
                    break;
            }
        }


        for (int i = 12; i < 20; i++)
        {
            switch (i)
            {
                case 12:
                    if (white[4] == 'w' || white[4] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (red[0] == 'w' || red[0] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 13:
                    if (white[2] == 'w' || white[2] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (blue[0] == 'w' || blue[0] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 14:
                    if (white[0] == 'w' || white[0] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (orange[0] == 'w' || orange[0] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 15:
                    if (white[6] == 'w' || white[6] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (green[0] == 'w' || green[0] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 16:
                    if (yellow[4] == 'w' || yellow[4] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (green[4] == 'w' || green[4] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 17:
                    if (yellow[6] == 'w' || yellow[6] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (orange[4] == 'w' || orange[4] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 18:
                    if (yellow[0] == 'w' || yellow[0] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (blue[4] == 'w' || blue[4] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
                case 19:
                    if (yellow[2] == 'w' || yellow[2] == 'y')
                    {
                        array[i + 20] = 0;
                    }
                    else if (red[4] == 'w' || red[4] == 'y')
                    {
                        array[i + 20] = 2;
                    }
                    else array[i + 20] = 1;
                    break;
            }
        }
        return array;
    }
}
