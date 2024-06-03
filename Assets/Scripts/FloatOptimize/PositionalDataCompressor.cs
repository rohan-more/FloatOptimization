using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionalDataCompressor 
{
    // Assume the previous position is stored as class variables
    private static float prevX = 0f;
    private static float prevY = 0f;
    private static float prevZ = 0f;

    // Method to compress and send data
    public static Vector3 CompressData(Vector3 position)
    {
        float x = position.x;
        float y = position.y;
        float z = position.z;
        // Calculate delta values
        float deltaX = x - prevX;
        float deltaY = y - prevY;
        float deltaZ = z - prevZ;

        // Quantize the delta values to reduce precision
        float quantizedX = Quantize(deltaX);
        float quantizedY = Quantize(deltaY);
        float quantizedZ = Quantize(deltaZ);

        // Update previous positions
        prevX = x;
        prevY = y;
        prevZ = z;
        //return new Vector3(deltaX, deltaY, deltaZ);
        return new Vector3(quantizedX, quantizedY, quantizedZ);
    }

    public static float Quantize(float value)
    {
        float max = 5f;
        float min = 0f;
        int numBits = 10;

        // Calculate the range of values within the quantization range
        float range = max - min;

        // Calculate the step size for each quantization level
        float stepSize = range / ((1 << numBits) - 1);

        // Quantize the value to the nearest quantization level
        float quantizedValue = min + (float)Math.Round((value - min) / stepSize) * stepSize;

        return quantizedValue;
    }

    public static float QuantizeGranular(float value)
    {
        return Mathf.Round(value / 0.1f) * 0.1f;
    }
}
