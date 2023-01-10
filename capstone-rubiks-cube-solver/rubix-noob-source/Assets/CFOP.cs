using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Xml;
using System.Linq;

namespace ConsoleApp1
{
    class CompCFOP
    {
        /*Function for the first step of the CFOP method: creating a white cross
            on the white side of the cube, using the "Daisy method"*/
        public static void WhiteCross(Cube cube)
        {
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

        /*Function describing the First Two Layers step of the method. This function looks for 77 possible patterns which each corrilate to a
         * hardcoded set of moves. When the function cannot find any of these established patterns, it rotates the Y face of the cube once. If
         * still no patterns can be recognised after three Y rotations, the function calls the SolveSecondLayer function to finish off this step
         * of the cube. */
        public static void FirstTwoLayers(Cube cube)
        {
            cube.changeOrientation('y', 'g');   //initialize orientation
            int sinceLastMove = 0;  //track number of sides searched since last pattern was found
            int resetRotations = 0; //track number of Y rotations made to find patterns
            bool loopcase1 = false; //bool to detect when a function has been run which could lead to a loop with another function
            bool loopcase2 = false; //bool to detect when a function has been run which could lead to a loop with another function

            while (!SecondLayerSolved(cube))
            {
                char[] orientation = cube.getOrientation(); //get cube orientation in order[front, right, back, left, up, down]
                bool moved = false; //bool to track whether a pattern was found this iteration

                //nested if statements to efficiently recognize desired cube states
                if (getRelativeFront(cube, 6) == orientation[0] && getRelativeRight(cube, 4) == 'w' && getRelativeYellow(cube, 4) == orientation[1])
                {
                    if (getRelativeYellow(cube, 1) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[1])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[0] && getRelativeRight(cube, 3) == orientation[1])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[1] && getRelativeRight(cube, 3) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.changeOrientation('y', orientation[1]);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[0] && getRelativeYellow(cube, 3) == orientation[1])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);


                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 1) == orientation[1])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 7) == orientation[1])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 7) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[1] && getRelativeYellow(cube, 5) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 7) == orientation[1])
                    {//Advanced Case
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                        loopcase2 = true;   //loopcase2 set to true to prevent other statements which would cause a loop
                    }

                    else if (getRelativeRight(cube, 7) == orientation[0])
                    {//Advanced Case
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateDown(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 3) == orientation[0])
                    {//Advanced Case
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 3) == orientation[1])
                    {//Advanced Case
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }
                }

                else if (getRelativeFront(cube, 6) == 'w' && getRelativeRight(cube, 4) == orientation[1] && getRelativeYellow(cube, 4) == orientation[0])
                {
                    if (getRelativeYellow(cube, 7) == orientation[1])
                    {
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 3) == orientation[1] && getRelativeFront(cube, 7) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 3) == orientation[0] && getRelativeFront(cube, 7) == orientation[1])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 5) == orientation[0] && getRelativeFront(cube, 5) == orientation[1])
                    {
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.changeOrientation('y', orientation[1]);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 7) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 1) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 5) == orientation[1] && getRelativeFront(cube, 5) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 1) == orientation[1])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 3) == orientation[1] && getRelativeRight(cube, 5) == orientation[0])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 3) == orientation[0])
                    {//Advanced Case
                        cube.changeOrientation('y', orientation[1]);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                        loopcase1 = true;   //loopcase2 set to true to prevent other statements which would cause a loop
                    }

                    else if (getRelativeFront(cube, 3) == orientation[1])
                    {//Advanced Case
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 7) == orientation[1])
                    {//Advanced Case
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 7) == orientation[0])
                    {//Advanced Case
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                else if (getRelativeFront(cube, 6) == orientation[1] && getRelativeRight(cube, 4) == orientation[0] && getRelativeYellow(cube, 4) == 'w')
                {
                    if (getRelativeFront(cube, 7) == orientation[0] && getRelativeRight(cube, 3) == orientation[1])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[1] && getRelativeRight(cube, 3) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[1] && getRelativeYellow(cube, 5) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);

                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[0] && getRelativeYellow(cube, 3) == orientation[1])
                    {
                        cube.changeOrientation('y', orientation[3]);

                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);

                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 7) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 1) == orientation[1])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 1) == orientation[0])
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeYellow(cube, 7) == orientation[1])
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[1])
                    {
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 7) == orientation[1] && !loopcase1)
                    {//Advanced Case
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 3) == orientation[0] && !loopcase2)
                    {//Advanced Case
                        cube.changeOrientation('y', orientation[1]);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 7) == orientation[0])
                    {//Advanced Case
                        cube.changeOrientation('y', orientation[1]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 3) == orientation[1])
                    {//Advanced Case
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateLeft(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }
                }

                else
                {
                    if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[1]
                        && getRelativeFront(cube, 0) == orientation[0] && getRelativeRight(cube, 2) == orientation[1]
                        && !loopcase2)
                    {
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[1]
                        && getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == 'w')
                    {
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[1]
                        && getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[0])
                    {
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == orientation[0] && getRelativeRight(cube, 2) == orientation[1]
                        && !loopcase1)
                    {
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateFront(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateFront(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == 'w')
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[1] && getRelativeRight(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == orientation[0] && getRelativeRight(cube, 2) == orientation[1])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[1] && getRelativeRight(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == 'w')
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[1] && getRelativeRight(cube, 3) == orientation[0]
                        && getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[3]);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.changeOrientation('y', orientation[0]);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[0] && getRelativeRight(cube, 3) == orientation[1]
                        && getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == 'w')
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 7) == orientation[0] && getRelativeRight(cube, 3) == orientation[1]
                        && getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[0])
                    {
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);

                        cube.rotateUp(Direction.COUNTERCLOCKWISE);
                        cube.rotateRight(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateUp(Direction.CLOCKWISE);
                        cube.rotateRight(Direction.COUNTERCLOCKWISE);
                        moved = true;
                    }

                    else if (getRelativeFront(cube, 6) == orientation[3] && getRelativeYellow(cube, 4) == 'w' && getRelativeRight(cube, 4) == orientation[2])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 7) == orientation[2] && getRelativeRight(cube, 3) == orientation[3])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateDown(Direction.CLOCKWISE);
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateDown(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 7) == orientation[3] && getRelativeRight(cube, 3) == orientation[2])
                        {//Advanced Case
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeFront(cube, 6) == orientation[2] && getRelativeYellow(cube, 4) == orientation[3] && getRelativeRight(cube, 4) == 'w')
                    {//Advanced Cases
                        if (getRelativeFront(cube, 7) == orientation[2] && getRelativeRight(cube, 3) == orientation[3])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 7) == orientation[3] && getRelativeRight(cube, 3) == orientation[2])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeFront(cube, 6) == 'w' && getRelativeYellow(cube, 4) == orientation[2] && getRelativeRight(cube, 4) == orientation[3])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 7) == orientation[2] && getRelativeRight(cube, 3) == orientation[3])
                        {//Advanced Case
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 7) == orientation[3] && getRelativeRight(cube, 3) == orientation[2])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }
                    }

                    else if (getRelativeFront(cube, 5) == orientation[3] && getRelativeYellow(cube, 5) == orientation[0])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[3] && getRelativeRight(cube, 2) == orientation[0])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[3])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[0] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeFront(cube, 5) == orientation[0] && getRelativeYellow(cube, 5) == orientation[3])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[3] && getRelativeRight(cube, 2) == orientation[0])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[3])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[0] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeRight(cube, 5) == orientation[2] && getRelativeYellow(cube, 3) == orientation[1])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == orientation[2])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[2] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE); ;
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[1])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }
                    }

                    else if (getRelativeRight(cube, 5) == orientation[1] && getRelativeYellow(cube, 3) == orientation[2])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[1] && getRelativeRight(cube, 2) == orientation[2])
                        {//Advanced Case
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[2] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[1])
                        {//Advanced Case
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeRight(cube, 5) == orientation[3] && getRelativeYellow(cube, 3) == orientation[2])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[2] && getRelativeRight(cube, 2) == orientation[3])
                        {//Advanced Case
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[2])
                        {//Advanced Case
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[3] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            moved = true;
                        }
                    }

                    else if (getRelativeFront(cube, 5) == orientation[2] && getRelativeYellow(cube, 5) == orientation[3])
                    {//Advanced Cases
                        if (getRelativeFront(cube, 0) == orientation[2] && getRelativeRight(cube, 2) == orientation[3])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateFront(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateFront(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == orientation[3] && getRelativeRight(cube, 2) == 'w')
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.CLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }

                        else if (getRelativeFront(cube, 0) == 'w' && getRelativeRight(cube, 2) == orientation[2])
                        {//Advanced Case
                            cube.changeOrientation('y', orientation[1]);
                            cube.rotateLeft(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateLeft(Direction.CLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.COUNTERCLOCKWISE);
                            cube.rotateUp(Direction.COUNTERCLOCKWISE);
                            cube.rotateRight(Direction.CLOCKWISE);
                            cube.changeOrientation('y', orientation[0]);
                            moved = true;
                        }
                    }
                }
                if (moved)  //if a patern was found this iteration
                {
                    sinceLastMove = 0;  //reset tracking variables
                    resetRotations = 0;
                }
                else    //if no move was made this iteration
                {
                    ++sinceLastMove;    //increment counter
                    if (sinceLastMove == 4) //if all sides of the cube have been searched
                    {
                        sinceLastMove = 0;  //reset counter
                        if (resetRotations == 4)    //if all Y face configurations have been tried
                        {
                            WhiteCorners(cube); //call whitecorners function to finish solving the white corners of the cube
                            while (cube.green[1] != 'g')    //ensure W face is oriented correctly
                            {
                                cube.rotateWhite(Direction.COUNTERCLOCKWISE);
                            }
                            SolveSecondLayer(cube); //call solve second layer to finish the first two layers of the cube
                            cube.changeOrientation('y', orientation[0]);
                            break;
                        }
                        else    //if not all Y face configurations have been tried
                        {
                            cube.rotateUp(Direction.CLOCKWISE); //rotate Y face
                            resetRotations++;   //increment reset rotations counter
                        }
                    }
                }
                cube.changeOrientation('y', orientation[1]);    //change orientation to check the next face of the cube
            }
        }

        /*This function takes the cube and an int, checks the cube orientation, and imposed a new indexing system (as if all faces were the green face) for the yellow
         * face of the cube depending on what the front face of the cube currently is. It then returns the value at index i in that new system. */
        private static char getRelativeYellow(Cube cube, int i)
        {
            switch (cube.frontFace)
            {
                case ColorEnum.GREEN:
                    switch (i)
                    {
                        case 0:
                            return cube.yellow[2];
                        case 1:
                            return cube.yellow[1];
                        case 2:
                            return cube.yellow[0];
                        case 3:
                            return cube.yellow[7];
                        case 4:
                            return cube.yellow[6];
                        case 5:
                            return cube.yellow[5];
                        case 6:
                            return cube.yellow[4];
                        case 7:
                            return cube.yellow[3];
                    }
                    break;
                case ColorEnum.RED:
                    switch (i)
                    {
                        case 0:
                            return cube.yellow[0];
                        case 1:
                            return cube.yellow[7];
                        case 2:
                            return cube.yellow[6];
                        case 3:
                            return cube.yellow[5];
                        case 4:
                            return cube.yellow[4];
                        case 5:
                            return cube.yellow[3];
                        case 6:
                            return cube.yellow[2];
                        case 7:
                            return cube.yellow[1];
                    }
                    break;
                case ColorEnum.BLUE:
                    switch (i)
                    {
                        case 0:
                            return cube.yellow[6];
                        case 1:
                            return cube.yellow[5];
                        case 2:
                            return cube.yellow[4];
                        case 3:
                            return cube.yellow[3];
                        case 4:
                            return cube.yellow[2];
                        case 5:
                            return cube.yellow[1];
                        case 6:
                            return cube.yellow[0];
                        case 7:
                            return cube.yellow[7];
                    }
                    break;
                case ColorEnum.ORANGE:
                    switch (i)
                    {
                        case 0:
                            return cube.yellow[4];
                        case 1:
                            return cube.yellow[3];
                        case 2:
                            return cube.yellow[2];
                        case 3:
                            return cube.yellow[1];
                        case 4:
                            return cube.yellow[0];
                        case 5:
                            return cube.yellow[7];
                        case 6:
                            return cube.yellow[6];
                        case 7:
                            return cube.yellow[5];
                    }
                    break;
            }
            return ('E');
        }

        //This funcion returns the value at index i of the front face of the cube
        private static char getRelativeFront(Cube cube, int i)
        {
            switch (cube.frontFace)
            {
                case ColorEnum.GREEN:
                    return cube.green[i];
                case ColorEnum.RED:
                    return cube.red[i];
                case ColorEnum.BLUE:
                    return cube.blue[i];
                case ColorEnum.ORANGE:
                    return cube.orange[i];
            }
            return ('E');
        }

        //This funcion returns the value at index i of the right face of the cube
        private static char getRelativeRight(Cube cube, int i)
        {
            char[] orientation = cube.getOrientation();
            cube.changeOrientation('y', orientation[1]);
            char result = 'E';
            switch (cube.frontFace)
            {
                case ColorEnum.GREEN:
                    result = cube.green[i];
                    break;
                case ColorEnum.RED:
                    result = cube.red[i];
                    break;
                case ColorEnum.BLUE:
                    result = cube.blue[i];
                    break;
                case ColorEnum.ORANGE:
                    result = cube.orange[i];
                    break;
            }
            cube.changeOrientation('y', orientation[0]);
            return result;
        }

        //SecondLayersolved from LBL implementation, used to check whether the cube is in a state where the first two layers have been solved
        private static bool SecondLayerSolved(Cube cube)
        {
            return cube.orange[3] == 'o' && cube.orange[7] == 'o'
                && cube.orange[0] == 'o' && cube.orange[2] == 'o'
                && cube.green[3] == 'g' && cube.green[7] == 'g'
                && cube.green[0] == 'g' && cube.green[2] == 'g'
                && cube.red[3] == 'r' && cube.red[7] == 'r'
                && cube.red[0] == 'r' && cube.red[2] == 'r'
                && cube.blue[3] == 'b' && cube.blue[7] == 'b'
                && cube.blue[0] == 'b' && cube.blue[2] == 'b';
        }

        //WhiteCorners from LBL implementation, called if F2L step cannot continue
        public static void WhiteCorners(Cube cube)
        {
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

        //SolveSecondLayer from LBL implementation, called if F2L step cannot continue
        private static void SolveSecondLayer(Cube cube)
        {
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

                if (!found.Any(x => x)) // If we didn't find any valid moves for the left or right algorithms, we have a wrong orentation we need to fix.
                {
                    TryFixWrongOrientation(cube);
                }
            }
        }

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
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

        //Helper function for SolveSecondLayer from LBL implementation
        private static bool FindWrongOrientation(Cube cube, char check)
        {
            return (check == 'o' && cube.orange[7] == 'b' && cube.blue[3] == 'o')
                || (check == 'b' && cube.blue[7] == 'r' && cube.red[3] == 'b')
                || (check == 'r' && cube.red[7] == 'g' && cube.green[3] == 'r')
                || (check == 'g' && cube.green[7] == 'o' && cube.orange[3] == 'g');
        }

        //Function to test whether the white corners of the cube have been solved
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

        // OLL
        // 2-Look OLL for CFOP
        public static void OrientLastLayer(Cube cube)
        {
            if (!OrientLastLayerStepTwo(cube)) // If we aren't able to solve directly,
            {
                OrientLastLayerStepOne(cube); // Run 2-Look OLL first step
                OrientLastLayerStepTwo(cube); // Run 2-Look OLL second step
            }
        }

        // Do first step of 2-Look OLL
        public static bool OrientLastLayerStepOne(Cube cube)
        {
            if (detectDotAndOrientCube(cube))
            {
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                cube.rotateFrontWide(Direction.CLOCKWISE); // f
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateFrontWide(Direction.COUNTERCLOCKWISE); // f'
                return true;
            }
            else if (detectIAndOrientCube(cube))
            {
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                return true;
            }
            else if (detectLAndOrientCube(cube))
            {
                cube.rotateFrontWide(Direction.CLOCKWISE); // f
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateFrontWide(Direction.COUNTERCLOCKWISE); // f'
                return true;
            }
            return false;
        }

        // Do second step of 2-Look OLL
        public static bool OrientLastLayerStepTwo(Cube cube)
        {
            if (detectAntisuneAndOrientCube(cube))
            {
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                return true;
            }
            else if (detectHAndOrientCube(cube))
            {
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                return true;
            }
            else if (detectL2AndOrientCube(cube))
            {
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                cube.rotateRightWide(Direction.CLOCKWISE); // r
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRightWide(Direction.COUNTERCLOCKWISE); // r'
                return true;
            }
            else if (detectPiAndOrientCube(cube))
            {
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                return true;
            }
            else if (detectSuneAndOrientCube(cube))
            {
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                return true;
            }
            else if (detectTAndOrientCube(cube))
            {
                cube.rotateRightWide(Direction.CLOCKWISE); // r
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRightWide(Direction.COUNTERCLOCKWISE); // r'
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                return true;
            }
            else if (detectUAndOrientCube(cube))
            {
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateDown(Direction.CLOCKWISE); // D
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateDown(Direction.COUNTERCLOCKWISE); // D'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                return true;
            }
            return false;
        }

        // Detect dot pattern and orient cube for algorithm
        public static bool detectDotAndOrientCube(Cube cube)
        {
            if (cube.green[5] == 'y'
                && cube.red[5] == 'y'
                && cube.blue[5] == 'y'
                && cube.orange[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            return false;
        }

        // Detect I pattern and orient cube for algorithm
        public static bool detectIAndOrientCube(Cube cube)
        {
            if (cube.yellow[3] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[5] == 'y'
                && cube.blue[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[1] == 'y'
                && cube.yellow[5] == 'y'
                && cube.red[5] == 'y'
                && cube.orange[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            return false;
        }

        // Detect L pattern and orient cube for algorithm
        public static bool detectLAndOrientCube(Cube cube)
        {
            if (cube.yellow[3] == 'y'
                && cube.yellow[5] == 'y'
                && cube.blue[5] == 'y'
                && cube.orange[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[1] == 'y'
                && cube.yellow[3] == 'y'
                && cube.green[5] == 'y'
                && cube.orange[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[1] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[5] == 'y'
                && cube.red[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            else if (cube.yellow[5] == 'y'
                && cube.yellow[7] == 'y'
                && cube.red[5] == 'y'
                && cube.blue[5] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            return false;
        }

        // Detect Antisune pattern and orient cube for algorithm
        public static bool detectAntisuneAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // Detect H pattern and orient cube for algorithm
        public static bool detectHAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            return false;
        }

        // Detect second L pattern and orient cube for algorithm
        public static bool detectL2AndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // Detect Pi pattern and orient cube for algorithm
        public static bool detectPiAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // Detect Sune pattern and orient cube for algorithm
        public static bool detectSuneAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // Detect T pattern and orient cube for algorithm
        public static bool detectTAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // Detect U pattern and orient cube for algorithm
        public static bool detectUAndOrientCube(Cube cube)
        {
            if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] == 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] == 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.BLUE;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] != 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] == 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] == 'y'
                && cube.red[5] != 'y'
                && cube.red[6] == 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.RED;
                return true;
            }
            else if (cube.yellow[0] == 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] != 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] == 'y'
                && cube.green[5] != 'y'
                && cube.green[6] == 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] != 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] != 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.GREEN;
                return true;
            }
            else if (cube.yellow[0] != 'y'
                && cube.yellow[1] == 'y'
                && cube.yellow[2] == 'y'
                && cube.yellow[3] == 'y'
                && cube.yellow[4] == 'y'
                && cube.yellow[5] == 'y'
                && cube.yellow[6] != 'y'
                && cube.yellow[7] == 'y'
                && cube.green[4] != 'y'
                && cube.green[5] != 'y'
                && cube.green[6] != 'y'
                && cube.red[4] != 'y'
                && cube.red[5] != 'y'
                && cube.red[6] != 'y'
                && cube.blue[4] != 'y'
                && cube.blue[5] != 'y'
                && cube.blue[6] != 'y'
                && cube.orange[4] == 'y'
                && cube.orange[5] != 'y'
                && cube.orange[6] == 'y')
            {
                cube.upFace = ColorEnum.YELLOW;
                cube.frontFace = ColorEnum.ORANGE;
                return true;
            }
            return false;
        }

        // PLL
        public static Pattern getPLLInitialPattern()
        {
            Pattern pattern = new Pattern();
            pattern.validAssignments[0] = ColorEnum.BLUE;
            pattern.validAssignments[1] = ColorEnum.ORANGE;
            pattern.validAssignments[2] = ColorEnum.GREEN;
            pattern.validAssignments[3] = ColorEnum.RED;
            return pattern;
        }

        // PLL step one
        public static bool PLLStepOne(Cube cube)
        {
            Pattern diagonalPattern = getPLLInitialPattern();
            diagonalPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.UNKNOWN, ColorEnum.PC_2 };
            diagonalPattern.bottom = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.UNKNOWN, ColorEnum.PC_4 };
            diagonalPattern.right = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.UNKNOWN, ColorEnum.PC_1 };
            diagonalPattern.top = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.UNKNOWN, ColorEnum.PC_3 };

            ColorEnum? diagonalResult = Pattern.findPatternMatch(cube, diagonalPattern);
            if (diagonalResult.HasValue)
            {
                cube.frontFace = diagonalResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                return true;
            }

            Pattern headlightsPattern = getPLLInitialPattern();
            headlightsPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.UNKNOWN, ColorEnum.PC_1 };
            headlightsPattern.bottom = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.UNKNOWN, ColorEnum.PC_3 };
            headlightsPattern.right = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.UNKNOWN, ColorEnum.PC_2 };
            headlightsPattern.top = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.UNKNOWN, ColorEnum.PC_4 };

            ColorEnum? headlightsResult = Pattern.findPatternMatch(cube, headlightsPattern);
            if (headlightsResult.HasValue)
            {
                cube.frontFace = headlightsResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateFront(Direction.CLOCKWISE); // F
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateFront(Direction.COUNTERCLOCKWISE); // F'
                return true;
            }

            return false;
        }

        // PLL step two
        public static bool PLLStepTwo(Cube cube)
        {
            Pattern pllhPattern = getPLLInitialPattern();
            pllhPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.PC_2, ColorEnum.PC_1 };
            pllhPattern.bottom = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.PC_4, ColorEnum.PC_3 };
            pllhPattern.right = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.PC_1, ColorEnum.PC_2 };
            pllhPattern.top = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.PC_3, ColorEnum.PC_4 };

            ColorEnum? pllhResult = Pattern.findPatternMatch(cube, pllhPattern);
            if (pllhResult.HasValue)
            {
                cube.frontFace = pllhResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M

                return true;
            }

            Pattern plluaPattern = getPLLInitialPattern();
            plluaPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.PC_2, ColorEnum.PC_1 };
            plluaPattern.bottom = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.PC_3, ColorEnum.PC_2 };
            plluaPattern.right = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.PC_1, ColorEnum.PC_3 };
            plluaPattern.top = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.PC_4, ColorEnum.PC_4 };

            ColorEnum? plluaResult = Pattern.findPatternMatch(cube, plluaPattern);
            if (plluaResult.HasValue)
            {
                cube.frontFace = plluaResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R

                return true;
            }

            Pattern pllubPattern = getPLLInitialPattern();
            pllubPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.PC_2, ColorEnum.PC_1 };
            pllubPattern.bottom = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.PC_1, ColorEnum.PC_3 };
            pllubPattern.right = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.PC_3, ColorEnum.PC_2 };
            pllubPattern.top = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.PC_4, ColorEnum.PC_4 };

            ColorEnum? pllubResult = Pattern.findPatternMatch(cube, pllubPattern);
            if (pllubResult.HasValue)
            {
                cube.frontFace = pllubResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.CLOCKWISE); // R
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.COUNTERCLOCKWISE); // U'
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateRight(Direction.COUNTERCLOCKWISE); // R'

                return true;
            }

            Pattern pllzPattern = getPLLInitialPattern();
            pllzPattern.left = new ColorEnum[] { ColorEnum.PC_1, ColorEnum.PC_2, ColorEnum.PC_1 };
            pllzPattern.bottom = new ColorEnum[] { ColorEnum.PC_2, ColorEnum.PC_1, ColorEnum.PC_2 };
            pllzPattern.right = new ColorEnum[] { ColorEnum.PC_3, ColorEnum.PC_4, ColorEnum.PC_3 };
            pllzPattern.top = new ColorEnum[] { ColorEnum.PC_4, ColorEnum.PC_3, ColorEnum.PC_4 };

            ColorEnum? pllzResult = Pattern.findPatternMatch(cube, pllzPattern);
            if (pllzResult.HasValue)
            {
                cube.frontFace = pllzResult.Value;
                cube.upFace = ColorEnum.YELLOW;
                cube.rotateMiddle(Direction.COUNTERCLOCKWISE); // M'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.COUNTERCLOCKWISE); // M'
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateUp(Direction.CLOCKWISE); // U
                cube.rotateMiddle(Direction.CLOCKWISE); // M
                cube.rotateMiddle(Direction.CLOCKWISE); // M

                return true;
            }
            return false;
        }

        // PLL Algorithm
        public static void PermuteLastLayer(Cube cube)
        {
            // Try step two, if that doesnt work do step one and two
            if (!PLLStepTwo(cube))
            {
                PLLStepOne(cube);
                PLLStepTwo(cube);
            }

            // Rotate yellow face until cube is solved
            while (cube.green[5] != 'g')
            {
                cube.rotateYellow(Direction.CLOCKWISE);
            }
        }

        public static List<String> Solve(Cube cube)
        {
            WhiteCross(cube);
            FirstTwoLayers(cube);
            OrientLastLayer(cube);
            PermuteLastLayer(cube);
            cube.cleanMoveList();
            return cube.moveList;
        }

        static void Main(string[] args)
        {
            Cube cube = new Cube(); //instantiate new cube object
            cube.scramble();    //scramble the cube

            Console.WriteLine("Initial scramble:");
            cube.cubePrint();

            WhiteCross(cube);   //solve white cross

            Console.WriteLine("White Cross:");
            cube.cubePrint();

            FirstTwoLayers(cube);   //solve first two layers

            Console.WriteLine("F2L:");
            cube.cubePrint();

            OrientLastLayer(cube); // orient last layer

            Console.WriteLine("Orient Last Layer:");
            cube.cubePrint();

            PermuteLastLayer(cube); // permute last layer

            Console.WriteLine("Permute Last Layer:");
            cube.cubePrint();

            cube.cleanMoveList();
            Console.WriteLine("Move count: " + cube.moveList.Count.ToString());
            Console.WriteLine("Move List:");
            cube.moveListPrint();
        }
    }
}