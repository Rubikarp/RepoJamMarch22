using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public static class KarpHelper
{
    //Camera Baking
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }

    //World to UI
    public static Vector3 GetWorldPosOfCanvasElement(RectTransform element)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(element, element.position, Camera, out var result);
        return result;
    }

    //Mouse OverUI ?
    private static PointerEventData _eventDataCurrentPos;
    private static List<RaycastResult> _results;
    public static bool IsOverUI()
    {
        _eventDataCurrentPos = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_eventDataCurrentPos, _results);
        return _results.Count > 0;
    }

    public static void DeleteChildrens(this Transform t)
    {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }

    public static bool Contain<T>(this T[] array, T toFind)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i].Equals(toFind)) { return true; }
        }
        return false;
    }
    public static T Last<T>(this T[] array)
    {
        return array[array.Length-1];
    }
    public static T Random<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0,array.Length-1)];
    }
    public static T Last<T>(this List<T> array)
    {
        return array[array.Count - 1];
    }

    public static Vector3 ToPlaneXZ(this Vector2 pos)
    {
        return new Vector3(pos.x, 0,pos.y);
    }
    public static Vector2 ToPlaneXZ(this Vector3 pos)
    {
        return new Vector2(pos.x, pos.z);
    }
    public static Vector3 To3D(this Vector2 pos)
    {
        return new Vector3(pos.x, pos.y, 0);
    }
}
