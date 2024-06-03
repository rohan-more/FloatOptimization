using System;

public static class Events
{
    // using events to trigger coordinate value changes
    public static Action<float> Set_X;
    public static Action<float> Set_Y;
    public static Action<float> Set_Z;
}
