using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{
    [SerializeField] private Camera _componentCamera;
    [SerializeField] private Vector2 _aspectRatio;

    private Vector2 _resolution;
    private float _scalerMatch;
    private float _initialSize;
    private float _targetAspect;
    private float _initialFov;
    private float _horizontalFov = 120f;

    private void Start()
    {
        _initialSize = _componentCamera.orthographicSize;
        _initialFov = _componentCamera.fieldOfView;
        IdentifyNewResolution();
        _horizontalFov = CalcVerticalFov(_initialFov, 1 / _targetAspect);
    }

    private void Update()
    {
        IdentifyNewResolution();

        if (_componentCamera.orthographic)
        {
            float constantWidthSize = _initialSize * (_targetAspect / _componentCamera.aspect);
            _componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, _scalerMatch);
        }
        else
        {
            float constantWidthFov = CalcVerticalFov(_horizontalFov, _componentCamera.aspect);
            _componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, _initialFov, _scalerMatch);
        }
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }

    private void IdentifyNewResolution()
    {
        if (Screen.width / (float)Screen.height * _aspectRatio.x <= _aspectRatio.y)
            SetNewResolution(1080, 1920, 0);
        else
            SetNewResolution(1920, 1080, 1);
    }

    private void CalculateHorizontalFov(int resolutionWidth, int resolutionHeight)
    {
        _resolution = new Vector2(resolutionWidth, resolutionHeight);
        _targetAspect = _resolution.x / _resolution.y;
        _horizontalFov = CalcVerticalFov(_initialFov, 1 / _targetAspect);
    }

    private void SetNewResolution(int width, int height, int scalerMatch)
    {
        CalculateHorizontalFov(width, height);
        _scalerMatch = scalerMatch;
    }
}