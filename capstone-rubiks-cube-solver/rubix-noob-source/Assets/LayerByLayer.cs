using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace LBL
{
    public class IncorrectCubeState : Exception { }
    public class LayerByLayer
    {
        /*Function for the first step of the Layer-By-Layer method: creating a white cross
               on the white side of the cube, using the "Daisy method"*/
        public static void WhiteCross(Cube cube)
        {
            if (cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o')
            {
                return;
            }
            //Get a list of edge pieces on the Yellow face of the cube qwhich are not white
            List<int> notWhite = new List<int>();
            if (cube.yellow[1] != 'w')
            {
                notWhite.Add(1);
            }
            if (cube.yellow[3] != 'w')
            {
                notWhite.Add(3);
            }
            if (cube.yellow[5] != 'w')
            {
                notWhite.Add(5);
            }
            if (cube.yellow[7] != 'w')
            {
                notWhite.Add(7);
            }

            //loop while some edge pieces on the yellow face of the cube are not white (this loop creates the "daisy" pattern)
            while (notWhite.Count > 0)
            {
                bool moved = false; //track if moves have been made this step of the loo[
                if (notWhite.Contains(1))   //if the edge piece toughing the blue face is not white
                {
                    if (cube.red[3] == 'w')
                    {
                        cube.rotateBlue(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }
                    else if (cube.orange[7] == 'w')
                    {
                        cube.rotateBlue(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.white[1] == 'w')
                    {
                        cube.rotateBlue(Direction.CLOCKWISE);
                        cube.rotateBlue(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.blue[1] == 'w')
                    {
                        cube.rotateBlue(Direction.COUNTERCLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateRed(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.blue[5] == 'w')
                    {
                        cube.rotateBlue(Direction.CLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateRed(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                if (notWhite.Contains(3) && !moved) //if the edge piece touching the red face is not white, and no moves have been made
                {
                    if (cube.green[3] == 'w')
                    {
                        cube.rotateRed(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }
                    else if (cube.blue[7] == 'w')
                    {
                        cube.rotateRed(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.white[3] == 'w')
                    {
                        cube.rotateRed(Direction.CLOCKWISE);
                        cube.rotateRed(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.red[1] == 'w')
                    {
                        cube.rotateRed(Direction.COUNTERCLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateGreen(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.red[5] == 'w')
                    {
                        cube.rotateRed(Direction.CLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateGreen(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                if (notWhite.Contains(5) && !moved) //if the edge piece touching the green face is not white, and no moves have been made
                {
                    if (cube.orange[3] == 'w')
                    {
                        cube.rotateGreen(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }
                    else if (cube.red[7] == 'w')
                    {
                        cube.rotateGreen(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.white[5] == 'w')
                    {
                        cube.rotateGreen(Direction.CLOCKWISE);
                        cube.rotateGreen(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.green[1] == 'w')
                    {
                        cube.rotateGreen(Direction.COUNTERCLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateOrange(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.green[5] == 'w')
                    {
                        cube.rotateGreen(Direction.CLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateOrange(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                if (notWhite.Contains(7) && !moved) //if the edge piece touching the orange face is not white, and no moves have been made
                {
                    if (cube.blue[3] == 'w')
                    {
                        cube.rotateOrange(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }
                    else if (cube.green[7] == 'w')
                    {
                        cube.rotateOrange(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.white[7] == 'w')
                    {
                        cube.rotateOrange(Direction.CLOCKWISE);
                        cube.rotateOrange(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.orange[1] == 'w')
                    {
                        cube.rotateOrange(Direction.COUNTERCLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateBlue(Direction.CLOCKWISE);
                        moved = true;
                    }
                    else if (cube.orange[5] == 'w')
                    {
                        cube.rotateOrange(Direction.CLOCKWISE);
                        cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                        cube.rotateBlue(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                if (!moved) //if the cube is in a state where no moves were made this step, rotate the yellow face
                {
                    cube.rotateYellow(Direction.CLOCKWISE);
                }

                notWhite.Clear();   //clear the now out-of-date list of non-white edge pieces

                if (cube.yellow[1] != 'w')  //update the list of edge pieces to be changed
                {
                    notWhite.Add(1);
                }
                if (cube.yellow[3] != 'w')
                {
                    notWhite.Add(3);
                }
                if (cube.yellow[5] != 'w')
                {
                    notWhite.Add(5);
                }
                if (cube.yellow[7] != 'w')
                {
                    notWhite.Add(7);
                }
            }


            /*Once the "Daisy" pattern hads been created, the white edge pieces must be moved to the proper space
             * on the white face of the cube*/
            List<int> stillWhite = new List<int>(); //create a list of white edge pieces to be moved
            if (cube.yellow[1] == 'w')
            {
                stillWhite.Add(1);
            }
            if (cube.yellow[3] == 'w')
            {
                stillWhite.Add(3);
            }
            if (cube.yellow[5] == 'w')
            {
                stillWhite.Add(5);
            }
            if (cube.yellow[7] == 'w')
            {
                stillWhite.Add(7);
            }

            while (stillWhite.Count > 0) //loop while edge pieces still need to be moved
            {
                if (stillWhite.Contains(1))
                {
                    if (cube.blue[5] == 'b')    //if the white/blue edge piece can be placed correctly
                    {
                        cube.rotateBlue(Direction.CLOCKWISE);
                        cube.rotateBlue(Direction.CLOCKWISE);
                        stillWhite.Remove(1);
                    }
                }
                if (stillWhite.Contains(3))
                {
                    if (cube.red[5] == 'r')     //if the white/red edge piece can be placed correctly
                    {
                        cube.rotateRed(Direction.CLOCKWISE);
                        cube.rotateRed(Direction.CLOCKWISE);
                        stillWhite.Remove(3);
                    }
                }
                if (stillWhite.Contains(5))
                {
                    if (cube.green[5] == 'g')   //if the white/green edge piece can be placed correctly
                    {
                        cube.rotateGreen(Direction.CLOCKWISE);
                        cube.rotateGreen(Direction.CLOCKWISE);
                        stillWhite.Remove(5);
                    }
                }
                if (stillWhite.Contains(7))
                {
                    if (cube.orange[5] == 'o')  //if the white/orange edge piece can be placed correctly
                    {
                        cube.rotateOrange(Direction.CLOCKWISE);
                        cube.rotateOrange(Direction.CLOCKWISE);
                        stillWhite.Remove(7);
                    }
                }

                if (stillWhite.Count > 0)    //if there are still edge pieces which need to be moved
                {
                    cube.rotateYellow(Direction.CLOCKWISE); //rotate the yellow face for a new orientation
                    stillWhite.Clear(); //clear the old list and create an updated list of white edge pieces to be moved
                    if (cube.yellow[1] == 'w')
                    {
                        stillWhite.Add(1);
                    }
                    if (cube.yellow[3] == 'w')
                    {
                        stillWhite.Add(3);
                    }
                    if (cube.yellow[5] == 'w')
                    {
                        stillWhite.Add(5);
                    }
                    if (cube.yellow[7] == 'w')
                    {
                        stillWhite.Add(7);
                    }
                }
            }
        }

        /*Function for the second step of the Layer-By-Layer method: solving to place the white corners
         * in the correct locations and orientations*/
        public static void WhiteCorners(Cube cube)
        {
            if (!(cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'))
            {
                throw new IncorrectCubeState();
            }

            cube.upFace = ColorEnum.WHITE;  //set the orientation such that the white side is on top
            bool whiteCornersSolved = WhiteCornersTest(cube);   //check if the white face and the first layer have been solved

            while (!whiteCornersSolved) //while the white face and the first layer have not been solved
            {
                if (cube.green[6] == 'w' || cube.red[6] == 'w' || cube.blue[6] == 'w' || cube.orange[6] == 'w') //if the lower left corner of the green, red, blue, or orange face is white
                {
                    //initialize two char variables to represent the other two colors on the discovered corner piece
                    char cornerColorA = 'z';
                    char cornerColorB = 'z';
                    if (cube.green[6] == 'w')   //if the white corner is on the green face
                    {
                        cube.frontFace = ColorEnum.GREEN;   //update the cube orientation for this case
                        cornerColorA = cube.orange[4];  //get the other colors of the corner piece
                        cornerColorB = cube.yellow[6];
                    }
                    else if (cube.red[6] == 'w')    //if the white corner is on the red face
                    {
                        cube.frontFace = ColorEnum.RED;     //update the cube orientation for this case
                        cornerColorA = cube.green[4];   //get the other colors of the corner piece
                        cornerColorB = cube.yellow[4];
                    }
                    else if (cube.blue[6] == 'w')   //if the white corner is on the blue face
                    {
                        cube.frontFace = ColorEnum.BLUE;    //update the cube orientation for this case
                        cornerColorA = cube.red[4];     //get the other colors of the corner piece
                        cornerColorB = cube.yellow[2];
                    }
                    else if (cube.orange[6] == 'w') //if the white corner is on the orange face
                    {
                        cube.frontFace = ColorEnum.ORANGE;  //update the cube orientation for this case
                        cornerColorA = cube.blue[4];    //get the other colors of the corner piece
                        cornerColorB = cube.yellow[0];
                    }

                    char[] orientation = cube.getOrientation(); //get current cube orientation as a char array

                    //loop to rotate the yellow face of the cube until the discovered corner piece is directly below its final position
                    while (!((orientation[0] == cornerColorA && orientation[3] == cornerColorB) || (orientation[0] == cornerColorB && orientation[3] == cornerColorA)))
                    {
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.changeOrientation('w', orientation[1]);
                        orientation = cube.getOrientation();
                    }

                    //place discovered corner piece in its correct place and orientation
                    cube.rotateFront(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateFront(Direction.CLOCKWISE);
                }

                else if (cube.green[4] == 'w' || cube.red[4] == 'w' || cube.blue[4] == 'w' || cube.orange[4] == 'w')    //if the lower left corner of the green, red, blue, or orange face is white
                {
                    //initialize two char variables to represent the other two colors on the discovered corner piece
                    char cornerColorA = 'z';
                    char cornerColorB = 'z';
                    if (cube.green[4] == 'w')   //if the white corner is on the green face
                    {
                        cube.frontFace = ColorEnum.GREEN;   //update the cube orientation for this case
                        cornerColorA = cube.red[6];     //get the other colors of the corner piece
                        cornerColorB = cube.yellow[4];
                    }
                    else if (cube.red[4] == 'w')    //if the white corner is on the red face
                    {
                        cube.frontFace = ColorEnum.RED;     //update the cube orientation for this case
                        cornerColorA = cube.blue[6];    //get the other colors of the corner piece
                        cornerColorB = cube.yellow[2];
                    }
                    else if (cube.blue[4] == 'w')   //if the white corner is on the blue face
                    {
                        cube.frontFace = ColorEnum.BLUE;    //update the cube orientation for this case
                        cornerColorA = cube.orange[6];  //get the other colors of the corner piece
                        cornerColorB = cube.yellow[0];
                    }
                    else if (cube.orange[4] == 'w')     //if the white corner is on the orange face
                    {
                        cube.frontFace = ColorEnum.ORANGE;  //update the cube orientation for this case
                        cornerColorA = cube.green[6];   //get the other colors of the corner piece
                        cornerColorB = cube.yellow[6];
                    }

                    char[] orientation = cube.getOrientation(); //get current cube orientation as a char array

                    //loop to rotate the yellow face of the cube until the discovered corner piece is directly below its final position
                    while (!((orientation[0] == cornerColorA && orientation[1] == cornerColorB) || (orientation[0] == cornerColorB && orientation[1] == cornerColorA)))
                    {
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.changeOrientation('w', orientation[1]);
                        orientation = cube.getOrientation();
                    }

                    //place discovered corner piece in its correct place and orientation
                    cube.rotateFront(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateFront(Direction.COUNTERCLOCKWISE);
                }

                //if any of the corners on the yellow face are white
                else if (cube.yellow[0] == 'w' || cube.yellow[2] == 'w' || cube.yellow[4] == 'w' || cube.yellow[6] == 'w')
                {
                    //initialize two char variables to represent the other two colors on the discovered corner piece
                    char cornerColorA = 'z';
                    char cornerColorB = 'z';

                    if (cube.yellow[0] == 'w')  //if the yellow[0] corner is white
                    {
                        cube.frontFace = ColorEnum.BLUE;    //update the cube orientation for this case
                        cornerColorA = cube.orange[6];  //get the other colors of the corner piece
                        cornerColorB = cube.blue[4];
                    }
                    else if (cube.yellow[2] == 'w') //if the yellow[2] corner is white
                    {
                        cube.frontFace = ColorEnum.RED;     //update the cube orientation for this case
                        cornerColorA = cube.blue[6];    //get the other colors of the corner piece
                        cornerColorB = cube.red[4];
                    }
                    else if (cube.yellow[4] == 'w') //if the yellow[4] corner is white
                    {
                        cube.frontFace = ColorEnum.GREEN;   //update the cube orientation for this case
                        cornerColorA = cube.red[6];     //get the other colors of the corner piece
                        cornerColorB = cube.green[4];
                    }
                    else if (cube.yellow[6] == 'w') //if the yellow[6] corner is white
                    {
                        cube.frontFace = ColorEnum.ORANGE;  //update the cube orientation for this case
                        cornerColorA = cube.green[6];   //get the other colors of the corner piece
                        cornerColorB = cube.orange[4];
                    }

                    char[] orientation = cube.getOrientation(); //get current cube orientation as a char array

                    //loop to rotate the yellow face of the cube until the discovered corner piece is directly below its final position
                    while (!((orientation[0] == cornerColorA && orientation[1] == cornerColorB) || (orientation[0] == cornerColorB && orientation[1] == cornerColorA)))
                    {
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.changeOrientation('w', orientation[1]);
                        orientation = cube.getOrientation();
                    }

                    //place discovered corner piece in its correct place and orientation
                    cube.rotateFront(Direction.CLOCKWISE);
                    cube.rotateLeft(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                    cube.rotateFront(Direction.COUNTERCLOCKWISE);
                }

                //The remaining else if statements cover any case where there is a white corner on the white face of the cube that is in the wrong place.
                //In this case, that corner is moved away from the white side so that one of the above cases can handle it.
                else if (cube.white[0] != 'w' || cube.orange[0] != 'o' || cube.blue[2] != 'b')
                {
                    cube.rotateBlue(Direction.CLOCKWISE);
                    cube.rotateYellow(Direction.CLOCKWISE);
                    cube.rotateBlue(Direction.COUNTERCLOCKWISE);
                }
                else if (cube.white[2] != 'w' || cube.blue[0] != 'b' || cube.red[2] != 'r')
                {
                    cube.rotateRed(Direction.CLOCKWISE);
                    cube.rotateYellow(Direction.CLOCKWISE);
                    cube.rotateRed(Direction.COUNTERCLOCKWISE);
                }
                else if (cube.white[4] != 'w' || cube.red[0] != 'r' || cube.green[2] != 'g')
                {
                    cube.rotateGreen(Direction.CLOCKWISE);
                    cube.rotateYellow(Direction.CLOCKWISE);
                    cube.rotateGreen(Direction.COUNTERCLOCKWISE);
                }
                else if (cube.white[6] != 'w' || cube.green[0] != 'g' || cube.orange[2] != 'o')
                {
                    cube.rotateOrange(Direction.CLOCKWISE);
                    cube.rotateYellow(Direction.CLOCKWISE);
                    cube.rotateOrange(Direction.COUNTERCLOCKWISE);
                }
                whiteCornersSolved = WhiteCornersTest(cube);    //check if the white face and the first layer have been solved
            }

        }

        //function to check whether the white face and first layer of the cube have been solved
        private static bool WhiteCornersTest(Cube cube)
        {
            bool whiteCornersSolved = true;

            if ((cube.white[0] != 'w') || (cube.white[2] != 'w') || (cube.white[4] != 'w') || (cube.white[6] != 'w'))
            {
                whiteCornersSolved = false;
            }
            else if ((cube.green[0] != 'g') || (cube.green[2] != 'g'))
            {
                whiteCornersSolved = false;
            }
            else if ((cube.red[0] != 'r') || (cube.red[2] != 'r'))
            {
                whiteCornersSolved = false;
            }
            else if ((cube.blue[0] != 'b') || (cube.blue[2] != 'b'))
            {
                whiteCornersSolved = false;
            }
            else if ((cube.orange[0] != 'o') || (cube.orange[2] != 'o'))
            {
                whiteCornersSolved = false;
            }

            return (whiteCornersSolved);

        }

        // Find the face given by 'basis' and 'face', and rotate that face by direction.
        private static void RotateRelativeSideFace(Cube cube, char basis, char face, Direction direction)
        {
            switch (face)
            {
                case 'r': // Right face
                    switch (basis)
                    {
                        case 'o': // Basis is orange.
                            cube.rotateBlue(direction); // Right Face
                            break;
                        case 'b': // Basis is blue.
                            cube.rotateRed(direction); // Right Face
                            break;
                        case 'r': // Basis is red.
                            cube.rotateGreen(direction); // Right Face
                            break;
                        case 'g': // Basis is green.
                            cube.rotateOrange(direction); // Right Face
                            break;
                    }
                    break;
                case 'l': // Left face
                    switch (basis)
                    {
                        case 'o': // Basis is orange.
                            cube.rotateGreen(direction); // Left Face
                            break;
                        case 'b': // Basis is blue.
                            cube.rotateOrange(direction); // Left Face
                            break;
                        case 'r': // Basis is red.
                            cube.rotateBlue(direction); // Left Face
                            break;
                        case 'g': // Basis is green.
                            cube.rotateRed(direction); // Left Face
                            break;
                    }
                    break;
                case 'f': // Front face
                    switch (basis)
                    {
                        case 'o': // Basis is orange.
                            cube.rotateOrange(direction); // Front Face
                            break;
                        case 'b': // Basis is blue.
                            cube.rotateBlue(direction); // Front Face
                            break;
                        case 'r': // Basis is red.
                            cube.rotateRed(direction); // Front Face
                            break;
                        case 'g': // Basis is green.
                            cube.rotateGreen(direction); // Front Face
                            break;
                    }
                    break;
            }
        }

        // Preform right algorithm on given face
        // https://ruwix.com/the-rubiks-cube/how-to-solve-the-rubiks-cube-beginners-method/step3-second-layer-f2l/
        private static void RightAlg(Cube cube, char basis)
        {
            cube.rotateYellow(Direction.CLOCKWISE); // U
            RotateRelativeSideFace(cube, basis, 'r', Direction.CLOCKWISE); // R
            cube.rotateYellow(Direction.COUNTERCLOCKWISE); // U'
            RotateRelativeSideFace(cube, basis, 'r', Direction.COUNTERCLOCKWISE); // R'
            cube.rotateYellow(Direction.COUNTERCLOCKWISE); // U'
            RotateRelativeSideFace(cube, basis, 'f', Direction.COUNTERCLOCKWISE); // F'
            cube.rotateYellow(Direction.CLOCKWISE); // U
            RotateRelativeSideFace(cube, basis, 'f', Direction.CLOCKWISE); // F
        }

        // Preform left algorithm on given face
        // https://ruwix.com/the-rubiks-cube/how-to-solve-the-rubiks-cube-beginners-method/step3-second-layer-f2l/
        private static void LeftAlg(Cube cube, char basis)
        {
            cube.rotateYellow(Direction.COUNTERCLOCKWISE); // U'
            RotateRelativeSideFace(cube, basis, 'l', Direction.COUNTERCLOCKWISE); // L'
            cube.rotateYellow(Direction.CLOCKWISE); // U
            RotateRelativeSideFace(cube, basis, 'l', Direction.CLOCKWISE); // L
            cube.rotateYellow(Direction.CLOCKWISE); // U
            RotateRelativeSideFace(cube, basis, 'f', Direction.CLOCKWISE); // F
            cube.rotateYellow(Direction.COUNTERCLOCKWISE); // U'
            RotateRelativeSideFace(cube, basis, 'f', Direction.COUNTERCLOCKWISE); // F'
        }

        // Checks if the second layer is solved.
        private static bool SecondLayerSolved(Cube cube)
        {
            return cube.orange[3] == 'o' && cube.orange[7] == 'o'
                && cube.green[3] == 'g' && cube.green[7] == 'g'
                && cube.red[3] == 'r' && cube.red[7] == 'r'
                && cube.blue[3] == 'b' && cube.blue[7] == 'b';
        }

        // Finds and corrects wrong orientations on the cube.
        // https://ruwix.com/the-rubiks-cube/how-to-solve-the-rubiks-cube-beginners-method/step3-second-layer-f2l/
        private static void TryFixWrongOrientation(Cube cube)
        {
            char[] side_faces = { 'o', 'g', 'r', 'b' };
            foreach (char face in side_faces)
            {
                if (FindWrongOrientation(cube, face)) // Wrong orientation found
                {
                    BringYellowToFace(cube, face, true);
                    RightAlg(cube, face);
                    cube.rotateYellow(Direction.CLOCKWISE); // U
                    cube.rotateYellow(Direction.CLOCKWISE); // U
                    RightAlg(cube, face);
                }
                else // Other orientations that can mess things up.
                {
                    if (cube.blue[7] != 'b')
                    {
                        BringYellowToFace(cube, 'b', true);
                        RightAlg(cube, 'b');
                    }
                    else if (cube.red[7] != 'r')
                    {
                        BringYellowToFace(cube, 'r', true);
                        RightAlg(cube, 'r');
                    }
                    else if (cube.green[7] != 'g')
                    {
                        BringYellowToFace(cube, 'g', true);
                        RightAlg(cube, 'g');
                    }
                    else if (cube.orange[7] != 'o')
                    {
                        BringYellowToFace(cube, 'o', true);
                        RightAlg(cube, 'o');
                    }
                }
            }
        }

        // Move yellow face until piece from originFace is on destFace
        private static void MoveFaceTopPieceToNewFace(Cube cube, char originFace, char destFace)
        {
            switch (originFace)
            {
                case 'g': // Origin is g
                    switch (destFace)
                    {
                        case 'r': // Destination is r
                            cube.rotateYellow(Direction.CLOCKWISE);
                            return;
                        case 'b': // Destination is b
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        case 'o': // Destination is o
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        default:
                            return;
                    }
                case 'r': // Origin is r
                    switch (destFace)
                    {
                        case 'g': // Destination is g
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        case 'b': // Destination is b
                            cube.rotateYellow(Direction.CLOCKWISE);
                            return;
                        case 'o': // Destination is o
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        default:
                            return;
                    }
                case 'b': // Origin is b
                    switch (destFace)
                    {
                        case 'g': // Destination is g
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        case 'r': // Destination is r
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        case 'o': // Destination is o
                            cube.rotateYellow(Direction.CLOCKWISE);
                            return;
                        default:
                            return;
                    }
                case 'o': // Origin is o
                    switch (destFace)
                    {
                        case 'g': // Destination is g
                            cube.rotateYellow(Direction.CLOCKWISE);
                            return;
                        case 'r': // Destination is r
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        case 'b': // Destination is b
                            cube.rotateYellow(Direction.COUNTERCLOCKWISE);
                            return;
                        default:
                            return;
                    }
            }
        }

        // Use the left or right algorithms on face, dependent on the topYellowFace
        private static void UseLeftRightAlgorithms(Cube cube, char face, char topYellowFace)
        {
            switch (face)
            {
                case 'g':
                    switch (topYellowFace)
                    {
                        case 'o':
                            RightAlg(cube, 'g');
                            return;
                        default:
                            LeftAlg(cube, 'g');
                            return;
                    }
                case 'r':
                    switch (topYellowFace)
                    {
                        case 'g':
                            RightAlg(cube, 'r');
                            return;
                        default:
                            LeftAlg(cube, 'r');
                            return;
                    }
                case 'b':
                    switch (topYellowFace)
                    {
                        case 'r':
                            RightAlg(cube, 'b');
                            return;
                        default:
                            LeftAlg(cube, 'b');
                            return;
                    }
                case 'o':
                    switch (topYellowFace)
                    {
                        case 'b':
                            RightAlg(cube, 'o');
                            return;
                        default:
                            LeftAlg(cube, 'o');
                            return;
                    }
            }
        }

        // Find eligible top piece for given face on any side face of the cube, move that piece to the given face.
        private static bool TryFindAndMovePieceForFace(Cube cube, char faceToCheck)
        {
            char[] side_faces = { 'o', 'g', 'r', 'b' };

            foreach (char side in side_faces)
            {
                if (cube.accessByFaceChar(side, 5) == faceToCheck && GetTopCenterYellowSquare(cube, side) != 'y') // Match for faceToCheck on side
                {
                    MoveFaceTopPieceToNewFace(cube, side, faceToCheck);
                    UseLeftRightAlgorithms(cube, faceToCheck, GetTopCenterYellowSquare(cube, faceToCheck));
                    return true;
                }
            }
            return false;
        }

        // Get the color on the yellow middle piece that is above the given side face
        private static char GetTopCenterYellowSquare(Cube cube, char face)
        {
            switch (face)
            {
                case 'o':
                    return cube.yellow[7];
                case 'g':
                    return cube.yellow[5];
                case 'r':
                    return cube.yellow[3];
                case 'b':
                    return cube.yellow[1];
                default:
                    return '\0';
            }
        }

        // Rotate yellow face until a piece containing yellow is on the top center of face.
        private static void BringYellowToFace(Cube cube, char face, bool includeTop)
        {
            if (includeTop) // Consider piece on yellow face.
            {
                while (cube.accessByFaceChar(face, 5) != 'y' && GetTopCenterYellowSquare(cube, face) != 'y')
                {
                    cube.rotateYellow(Direction.CLOCKWISE);
                }
            }
            else // Do not consider piece on yellow face.
            {
                while (cube.accessByFaceChar(face, 5) != 'y')
                {
                    cube.rotateYellow(Direction.CLOCKWISE);
                }
            }
        }

        // Detect an wrong orientation on a given face.
        private static bool FindWrongOrientation(Cube cube, char check)
        {
            return (check == 'o' && cube.orange[7] == 'b' && cube.blue[3] == 'o')
                || (check == 'b' && cube.blue[7] == 'r' && cube.red[3] == 'b')
                || (check == 'r' && cube.red[7] == 'g' && cube.green[3] == 'r')
                || (check == 'g' && cube.green[7] == 'o' && cube.orange[3] == 'g');
        }

        // Fix some initially wrong orientations that are incompatible with the Second Layer algorithm
        private static void SecondLayerInitialCubeCorrection(Cube cube)
        {
            if (cube.blue[7] == 'b' && cube.red[3] == 'o')
            {
                BringYellowToFace(cube, 'b', true);
                RightAlg(cube, 'b');
            }

            if (cube.blue[3] == 'b' && cube.orange[7] == 'r')
            {
                BringYellowToFace(cube, 'b', true);
                LeftAlg(cube, 'b');
            }

            if (cube.red[7] == 'r' && cube.green[3] == 'b')
            {
                BringYellowToFace(cube, 'r', true);
                RightAlg(cube, 'r');
            }

            if (cube.red[3] == 'r' && cube.blue[7] == 'g')
            {
                BringYellowToFace(cube, 'r', true);
                LeftAlg(cube, 'r');
            }

            if (cube.green[7] == 'g' && cube.orange[3] == 'r')
            {
                BringYellowToFace(cube, 'g', true);
                RightAlg(cube, 'g');
            }

            if (cube.green[3] == 'g' && cube.red[7] == 'o')
            {
                BringYellowToFace(cube, 'g', true);
                LeftAlg(cube, 'g');
            }

            if (cube.orange[7] == 'o' && cube.blue[3] == 'g')
            {
                BringYellowToFace(cube, 'o', true);
                RightAlg(cube, 'o');
            }

            if (cube.orange[3] == 'o' && cube.green[7] == 'b')
            {
                BringYellowToFace(cube, 'o', true);
                LeftAlg(cube, 'o');
            }
        }

        // Solve second layer.
        public static void SolveSecondLayer(Cube cube)
        {
            if (!(cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'))
            {
                throw new IncorrectCubeState();
            }
            if (cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o')
            {
                return;
            }
            SecondLayerInitialCubeCorrection(cube);

            char[] side_faces = { 'g', 'r', 'b', 'o' };

            while (!SecondLayerSolved(cube))
            {
                bool[] found = { false, false, false, false };

                for (int i = 0; i < side_faces.Length; ++i)
                {
                    found[i] = TryFindAndMovePieceForFace(cube, side_faces[i]);
                    if (SecondLayerSolved(cube))
                    {
                        return;
                    }
                }

                // Not sure why .Any throws an error
                if (!found.Any(x => x)) // If we didn't find any valid moves for the left or right algorithms, we have a wrong orentation we need to fix.
                {
                    TryFixWrongOrientation(cube);
                }
            }
        }

        public static void YellowCross(Cube cube)
        {
            if (!(cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'))
            {
                throw new IncorrectCubeState();
            }

            if (cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y')
            {
                return;
            }

            while (!(cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y'))  //loop function until yellow cross appears
            {
                cube.upFace = ColorEnum.YELLOW; //set uypface to yellow
                if (((cube.yellow[1] == 'y') && (cube.yellow[3] == 'y')) || ((cube.yellow[3] == 'y') && (cube.yellow[7] == 'y')))   //check for L or line pattern for Green face
                {
                    cube.frontFace = ColorEnum.GREEN;
                }
                else if ((cube.yellow[3] == 'y') && (cube.yellow[5] == 'y') || ((cube.yellow[1] == 'y') && (cube.yellow[5] == 'y')))    //check for L or line pattern for Orange face
                {
                    cube.frontFace = ColorEnum.ORANGE;
                }
                else if ((cube.yellow[5] == 'y') && (cube.yellow[7] == 'y'))    //check for L or line pattern for Orange face
                {
                    cube.frontFace = ColorEnum.BLUE;
                }
                else if ((cube.yellow[7] == 'y') && (cube.yellow[1] == 'y'))    //check for L or line pattern for Orange face
                {
                    cube.frontFace = ColorEnum.RED;
                }
                else    //case where only yellow dot is present
                {
                    cube.frontFace = ColorEnum.GREEN;
                }

                //Perform F, R, U, R', U', F' algorithm
                cube.rotateFront(Direction.CLOCKWISE);
                cube.rotateRight(Direction.CLOCKWISE);
                cube.rotateUp(Direction.CLOCKWISE);
                cube.rotateRight(Direction.COUNTERCLOCKWISE);
                cube.rotateUp(Direction.COUNTERCLOCKWISE);
                cube.rotateFront(Direction.COUNTERCLOCKWISE);
            }
        }

        public static void OrientYellowEdges(Cube cube)
        {
            if (!(cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y'))
            {
                throw new IncorrectCubeState();
            }

            if (cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y'
                && cube.green[5] == 'g' && cube.red[5] == 'r' && cube.blue[5] == 'b' && cube.orange[5] == 'o')
            {
                return;
            }
            cube.upFace = ColorEnum.YELLOW;
            while (!YellowEdgesTest(cube)) //Loop until yellow edges are in the correct position
            {
                if (cube.green[5] == 'o' && cube.orange[5] == 'g')
                {
                    cube.frontFace = ColorEnum.ORANGE;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.red[5] == 'g' && cube.green[5] == 'r')
                {
                    cube.frontFace = ColorEnum.GREEN;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.blue[5] == 'r' && cube.red[5] == 'b')
                {
                    cube.frontFace = ColorEnum.RED;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.orange[5] == 'b' && cube.blue[5] == 'o')
                {
                    cube.frontFace = ColorEnum.BLUE;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.green[5] == 'r' && cube.red[5] == 'o')
                {
                    cube.frontFace = ColorEnum.GREEN;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.green[5] == 'b' && cube.blue[5] == 'g')
                {
                    cube.frontFace = ColorEnum.RED;
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.frontFace = ColorEnum.ORANGE;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                if (cube.red[5] == 'o' && cube.orange[5] == 'r')
                {
                    cube.frontFace = ColorEnum.GREEN;
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.frontFace = ColorEnum.BLUE;
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                else
                {
                    cube.rotateUp(Direction.CLOCKWISE);
                }
            }
        }

        public static void PositionYellowCorners(Cube cube)
        {
            if (!(cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y'
                && cube.green[5] == 'g' && cube.red[5] == 'r' && cube.blue[5] == 'b' && cube.orange[5] == 'o'))
            {
                throw new LBL.IncorrectCubeState();
            }

            if (YellowCornersTest(cube))
            {
                return;
            }
            cube.upFace = ColorEnum.YELLOW;
            while (!YellowCornersTest(cube))
            {
                if (cube.getYellowCornerValue(0) == 330)
                {
                    cube.frontFace = ColorEnum.ORANGE;

                }
                else if (cube.getYellowCornerValue(2) == 333)
                {
                    cube.frontFace = ColorEnum.BLUE;
                }
                else if (cube.getYellowCornerValue(4) == 338)
                {
                    cube.frontFace = ColorEnum.RED;
                }
                else if (cube.getYellowCornerValue(6) == 335)
                {
                    cube.frontFace = ColorEnum.GREEN;
                }

                cube.rotateUp(Direction.CLOCKWISE);
                cube.rotateRight(Direction.CLOCKWISE);
                cube.rotateUp(Direction.COUNTERCLOCKWISE);
                cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                cube.rotateUp(Direction.CLOCKWISE);
                cube.rotateRight(Direction.COUNTERCLOCKWISE);
                cube.rotateUp(Direction.COUNTERCLOCKWISE);
                cube.rotateLeft(Direction.CLOCKWISE);
            }

        }

        public static void OrientLastLayer(Cube cube)
        {
            if (!(cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y'
                && cube.green[5] == 'g' && cube.red[5] == 'r' && cube.blue[5] == 'b' && cube.orange[5] == 'o'))
            {
                throw new IncorrectCubeState();
            }

            if (cube.white[0] == 'w' && cube.white[2] == 'w' && cube.white[4] == 'w' && cube.white[6] == 'w'
                && cube.white[1] == 'w' && cube.white[3] == 'w' && cube.white[5] == 'w' && cube.white[7] == 'w'
                && cube.green[0] == 'g' && cube.red[0] == 'r' && cube.blue[0] == 'b' && cube.orange[0] == 'o'
                && cube.green[1] == 'g' && cube.red[1] == 'r' && cube.blue[1] == 'b' && cube.orange[1] == 'o'
                && cube.green[2] == 'g' && cube.red[2] == 'r' && cube.blue[2] == 'b' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.red[3] == 'r' && cube.blue[3] == 'b' && cube.orange[3] == 'o'
                && cube.green[4] == 'g' && cube.red[4] == 'r' && cube.blue[4] == 'b' && cube.orange[4] == 'o'
                && cube.green[5] == 'g' && cube.red[5] == 'r' && cube.blue[5] == 'b' && cube.orange[5] == 'o'
                && cube.green[6] == 'g' && cube.red[6] == 'r' && cube.blue[6] == 'b' && cube.orange[6] == 'o'
                && cube.green[7] == 'g' && cube.red[7] == 'r' && cube.blue[7] == 'b' && cube.orange[7] == 'o'
                && cube.yellow[0] == 'y' && cube.yellow[2] == 'y' && cube.yellow[4] == 'y' && cube.yellow[6] == 'y'
                && cube.yellow[1] == 'y' && cube.yellow[3] == 'y' && cube.yellow[5] == 'y' && cube.yellow[7] == 'y')
            {
                return;
            }
            bool solved = false;
            cube.upFace = ColorEnum.YELLOW;
            cube.frontFace = ColorEnum.ORANGE;
            while (!solved)
            {
                if (!((cube.yellow[0] == 'y') && (cube.orange[6] == 'o') && (cube.blue[4] == 'b')))
                {
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    if (!((cube.yellow[0] == 'y') && (cube.orange[6] == 'o') && (cube.blue[4] == 'b')))
                    {
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                    }
                }
                else if (!((cube.yellow[2] == 'y') && (cube.red[4] == 'r') && (cube.blue[6] == 'b')))
                {
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    if (!((cube.yellow[2] == 'y') && (cube.red[4] == 'r') && (cube.blue[6] == 'b')))
                    {
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                    }
                    cube.rotateUp(Direction.COUNTERCLOCKWISE);
                }
                else if (!((cube.yellow[4] == 'y') && (cube.green[4] == 'g') && (cube.red[6] == 'r')))
                {
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateUp(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    if (!((cube.yellow[4] == 'y') && (cube.green[4] == 'g') && (cube.red[6] == 'r')))
                    {
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                    }
                    cube.rotateUp(Direction.COUNTERCLOCKWISE);
                    cube.rotateUp(Direction.COUNTERCLOCKWISE);
                }
                else if (!((cube.yellow[6] == 'y') && (cube.green[6] == 'g') && (cube.orange[4] == 'o')))
                {
                    cube.rotateUp(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    cube.rotateRight(Direction.COUNTERCLOCKWISE);
                    cube.rotateDown(Direction.COUNTERCLOCKWISE);
                    cube.rotateRight(Direction.CLOCKWISE);
                    cube.rotateDown(Direction.CLOCKWISE);
                    if (!((cube.yellow[6] == 'y') && (cube.green[6] == 'g') && (cube.orange[4] == 'o')))
                    {
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                    }
                    cube.rotateUp(Direction.CLOCKWISE);
                }
                else solved = true;
            }
        }


        private static bool YellowCrossTest(Cube cube)
        {
            return ((cube.yellow[1] == 'y') && (cube.yellow[3] == 'y') && (cube.yellow[5] == 'y') && (cube.yellow[7] == 'y'));
        }

        private static bool YellowEdgesTest(Cube cube)
        {
            return ((cube.green[5] == 'g') && (cube.orange[5] == 'o') && (cube.red[5] == 'r') && (cube.blue[5] == 'b'));
        }

        private static bool YellowCornersTest(Cube cube)
        {
            if (cube.getYellowCornerValue(2) == 333)
            {
                if (cube.getYellowCornerValue(4) == 338)
                {
                    if (cube.getYellowCornerValue(0) == 330)
                    {
                        if (cube.getYellowCornerValue(6) == 335)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

    }
}