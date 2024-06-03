using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class NetworkManager
{
    private static float playerXPosition;
    private static float playerYPosition;
    private static float playerZPosition;
    private static float prevXPosition;
    private static float prevYPosition;
    private static float prevZPosition;
    private static int numBits = 0;
    public static float PlayerXPosition { get => playerXPosition; set => playerXPosition = value; }
    public static float PlayerYPosition { get => playerYPosition; set => playerYPosition = value; }
    public static float PlayerZPosition { get => playerZPosition; set => playerZPosition = value; }
    public static int NumBits { get => numBits; set => numBits = value; }

    /// <summary>
    /// Setting coordinate values and only transmitting the ones that change w.r.t the previous value
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    public static void SetPositions(float X, float Y, float Z)
    {
         NumBits = 0;
        if (!IsEqual(PlayerXPosition + X, prevXPosition))
        {
            PlayerXPosition = prevXPosition + X;
            Events.Set_X?.Invoke(PlayerXPosition); // using Events to send coordinate values, ideally there would be a system in place to transit such data
            AddNumBits(PlayerXPosition);
        }

        if (!IsEqual(PlayerZPosition + Z, prevZPosition))
        {
            PlayerZPosition = prevZPosition + Z;
            Events.Set_Z?.Invoke(PlayerZPosition);
            AddNumBits(PlayerZPosition);
        }
 
        if (!IsEqual(PlayerYPosition + Y, prevYPosition))
        {
            PlayerYPosition = prevYPosition + Y;
            Events.Set_Y?.Invoke(PlayerYPosition);
            AddNumBits(PlayerYPosition);
        }
  
        prevXPosition = PlayerXPosition;
        prevYPosition = PlayerYPosition;
        prevZPosition = PlayerZPosition;
    }

    private static void AddNumBits(float value)
    {
        NumBits += Marshal.SizeOf(value) * 8;
    }

    #region Helper Functions

    private static bool AreAlmostEqual(float a, float b, float tolerance = float.Epsilon)
    {

        Debug.Log("values a: "+ a + " b: " +b);
        // Calculate the difference between a and b
        float difference = a - b;
 
        if (a >= 0 && b >= 0)
        {
            return difference < tolerance;
        }
        else if (a < 0 && b < 0)
        {
            return difference > -tolerance;
        }
        else
        {
            // If a and b have different signs, consider them not equal
            return false;
        }
    }

    private static bool NearlyEqual(float a, float b, float epsilon = float.MinValue)
    {
         float absA = Mathf.Abs(a);
         float absB = Mathf.Abs(b);
         float diff = Mathf.Abs(a - b);
        if (a == b)
        { // shortcut, handles infinities
            return true;
        }
        else if (a == 0 || b == 0 || absA + absB < float.MinValue)
        {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < (epsilon * float.MinValue);
        }
        else
        { // use relative error
            return diff / Math.Min((absA + absB), float.MaxValue) < epsilon;
        }
    }

    private static bool IsEqual(float a, float b, float epsilon = float.Epsilon)
    {
        if (a > b)
        {
            if ((a - b) < epsilon)
            {
                return true;
            }
        }
        else
        {

            if ((b - a) < epsilon)
            {
                return true;
            }
        }
        return false;
    }

    private static Vector3 GetPlayerPosition()
    {
        return new Vector3(PlayerXPosition, PlayerYPosition, PlayerZPosition);
    }

    #endregion

}
