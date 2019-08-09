using UnityEngine;

public class CameraBounds2D : MonoBehaviour
{
    public float boundX;
    public float boundY;

    public Vector2 maxXlimit;
    public Vector2 maxYlimit;

    Camera _camera;

    public void Initialize(Camera temp_camera)
    {
        _camera = temp_camera;
        CalculateBounds();
    }

    public void CalculateBounds()
    {
        float cameraHalfWidth = _camera.aspect * _camera.orthographicSize;
        maxXlimit = new Vector2((transform.position.x - boundX) + cameraHalfWidth, (transform.position.x + boundX) - cameraHalfWidth);
        maxYlimit = new Vector2((transform.position.y - boundY) + _camera.orthographicSize, (transform.position.y + boundY) - _camera.orthographicSize);
    }
}
