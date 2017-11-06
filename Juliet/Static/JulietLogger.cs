using System;
using UnityEngine;

public static class JulietLogger
{
    public static DebugMode DebugMode = DebugMode.Enable;

    public static void Info(string tag, object data)
    {
        if (DebugMode == DebugMode.Disable)
            return;

        Debug.Log("[" + tag + "] => " + data);
    }

    public static void Warning(string tag, object data)
    {
        if (DebugMode == DebugMode.Disable)
            return;

        Debug.LogWarning("[" + tag + "] => " + data);
    }

    public static void Error(string tag, object data)
    {
        if (DebugMode == DebugMode.Disable)
            return;

        Debug.LogError("[" + tag + "] => " + data);
    }

    public static void ErrorFormat(string tag, object data)
    {
        if (DebugMode == DebugMode.Disable)
            return;

        Debug.LogErrorFormat("[" + tag + "] => " + data);
    }

    public static void Exception(Exception ex, UnityEngine.Object context = null)
    {
        if (DebugMode == DebugMode.Disable)
            return;

        Debug.LogException(ex, context);
    }
}