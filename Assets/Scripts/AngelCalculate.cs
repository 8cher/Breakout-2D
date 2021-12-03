using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class AngelCalculate
{
    public static Vector2 GetRandomAngle2D()
    {
        Vector2 result = new Vector2(0, 0);
        return result;
    }

    public static Vector3 GetRandomAngle()
    {
        Vector3 result = new Vector3(0, 0, 0);
        return result;
    }

    public static Vector2 GetRotatePosition2D(Vector2 targetPosition, Vector2 pivotPosition, float radians)
    {
        Vector2 result;
        result.x = (targetPosition.x - pivotPosition.x) * Cos(radians) - (targetPosition.y - pivotPosition.y) * Sin(radians) + pivotPosition.x;
        result.y = (targetPosition.x - pivotPosition.x) * Sin(radians) + (targetPosition.y - pivotPosition.y) * Cos(radians) + pivotPosition.x;
        return result;
    }

    public static Vector2 GetRotatePosition2D(Vector2 targetPosition, float radians)
    {
        Vector2 result;
        result.x = targetPosition.x * Cos(radians) - targetPosition.y * Sin(radians);
        result.y = targetPosition.x * Sin(radians) + targetPosition.y * Cos(radians);
        return result;
    }


    public static Vector2 GetRandomLaunchAngle()
    {
        float horizontal = 1f;
        do
        {
            horizontal = Random.Range(-1.0f, 1.0f);
        } while (horizontal > -0.5f && horizontal < 0.5f);
        float angle = Random.Range(30, 60);
        Vector2 random = new Vector2(horizontal, Mathf.Tan(angle * Mathf.Deg2Rad)).normalized;
        Debug.Log("Get Random Angle:" + random);
        return random;
    }
}




