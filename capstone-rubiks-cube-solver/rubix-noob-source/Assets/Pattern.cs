using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pattern
{
    // Pattern variables
    public ColorEnum[] center = new ColorEnum[8];
    public ColorEnum[] top = new ColorEnum[3];
    public ColorEnum[] bottom = new ColorEnum[3];
    public ColorEnum[] left = new ColorEnum[3];
    public ColorEnum[] right = new ColorEnum[3];

    // Valid assignments for this pattern
    public ColorEnum[] validAssignments = new ColorEnum[4];

    // Swap two integers given their address
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Generate all permutations of array
    public static IList<IList<int>> DoPermute(int[] arr, int start, int end, IList<IList<int>> list)
    {
        if (start == end)
        {
            list.Add(new List<int>(arr));
        }
        else
        {
            for (int i = start; i <= end; ++i)
            {
                Swap(ref arr[start], ref arr[i]);
                DoPermute(arr, start + 1, end, list);
                Swap(ref arr[start], ref arr[i]);
            }
        }
        return list;
    }

    // Assign colors to potential color values in array
    public static ColorEnum[] assignColors(ColorEnum[] colorArray, ColorEnum caOne, ColorEnum caTwo, ColorEnum caThree, ColorEnum caFour)
    {
        ColorEnum[] output = new ColorEnum[colorArray.Length];
        for (int i = 0; i < colorArray.Length; ++i)
        {
            switch (colorArray[i])
            {
                case ColorEnum.PC_1:
                    output[i] = caOne;
                    break;
                case ColorEnum.PC_2:
                    output[i] = caTwo;
                    break;
                case ColorEnum.PC_3:
                    output[i] = caThree;
                    break;
                case ColorEnum.PC_4:
                    output[i] = caFour;
                    break;
                default:
                    output[i] = colorArray[i];
                    break;
            }
        }
        return output;
    }

    // Function to check for a match between two side arrays
    public static bool checkSideMatch(ColorEnum[] pattern, char[] side)
    {
        // For each value inside the pattern
        for (int patternColorIndex = 0; patternColorIndex < 3; ++patternColorIndex)
        {
            // If pattern value isn't unknown
            if (pattern[patternColorIndex] != ColorEnum.UNKNOWN)
            {
                // If values don't match, return failure.
                if (side[patternColorIndex + 4] != Cube.getCharFromColor(pattern[patternColorIndex]))
                {
                    return false;
                }
            }

        }
        // Success
        return true;
    }

    // Function to find a pattern match on a cube.
    public static ColorEnum? findPatternMatch(Cube cube, Pattern pattern)
    {
        // Iterate over all assignments
        // Then iterate over all orientations
        // And check for match.

        int[] validIndices = new int[4] { 0, 1, 2, 3 };
        ColorEnum[] validFrontFaces = new ColorEnum[4] { ColorEnum.BLUE, ColorEnum.RED, ColorEnum.GREEN, ColorEnum.ORANGE };
        foreach (IList<int> assignment in DoPermute(validIndices, 0, 3, new List<IList<int>>()))
        {
            // ColorEnum assignments this iteration
            ColorEnum caOne = pattern.validAssignments[assignment[0]];
            ColorEnum caTwo = pattern.validAssignments[assignment[1]];
            ColorEnum caThree = pattern.validAssignments[assignment[2]];
            ColorEnum caFour = pattern.validAssignments[assignment[3]];

            // We have all valid assignments. Now we have to iterate over all orientations and check for matches
            for (int frontFaceIndex = 0; frontFaceIndex < validFrontFaces.Length; ++frontFaceIndex)
            {
                // Faces from cube to check
                char[]? cubeBottom = cube.getFaceArrayFromColor(validFrontFaces[frontFaceIndex]);
                char[]? cubeRight = cube.getFaceArrayFromColor(validFrontFaces[(frontFaceIndex + 1) % validFrontFaces.Length]);
                char[]? cubeTop = cube.getFaceArrayFromColor(validFrontFaces[(frontFaceIndex + 2) % validFrontFaces.Length]);
                char[]? cubeLeft = cube.getFaceArrayFromColor(validFrontFaces[(frontFaceIndex + 3) % validFrontFaces.Length]);

                // Assign pattern values
                ColorEnum[] patternBottom = assignColors(pattern.bottom, caOne, caTwo, caThree, caFour);
                ColorEnum[] patternRight = assignColors(pattern.right, caOne, caTwo, caThree, caFour);
                ColorEnum[] patternTop = assignColors(pattern.top, caOne, caTwo, caThree, caFour);
                ColorEnum[] patternLeft = assignColors(pattern.left, caOne, caTwo, caThree, caFour);

                // If we have a match
                if (checkSideMatch(patternBottom, cubeBottom)
                    && checkSideMatch(patternRight, cubeRight)
                    && checkSideMatch(patternTop, cubeTop)
                    && checkSideMatch(patternLeft, cubeLeft))
                {
                    // Success, we have found a full match. Return valid front face for algorithm.
                    return validFrontFaces[frontFaceIndex];
                }
            }
        }
        // No match found.
        return null;
    }
}
