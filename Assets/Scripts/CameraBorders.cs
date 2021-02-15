using UnityEngine;

public class CameraBorders : MonoBehaviour
{
    // ���������� ������� ������ ������� ������
    private static Vector2 borders;

    private void Awake()
    {
        var camera = Camera.main;
        borders.x = camera.aspect * camera.orthographicSize;
        borders.y = camera.orthographicSize;
    }

    public static Vector2 Borders
    {
        get
        {
            return borders;
        }
    }
}
