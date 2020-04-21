using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraController : MonoBehaviour
{
    [SerializeField]
    Transform _cameraTarget;
    Vector3 _cameraOffset;
    [SerializeField]
    float _cameraSpeed = 10f;

    private void Start()
    {
        transform.position = new Vector3(_cameraTarget.transform.position.x, _cameraTarget.transform.position.y, transform.position.z);
        _cameraOffset = _cameraTarget.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _cameraTarget.transform.position + _cameraOffset;
        Vector3 nextPos = Vector3.Lerp(transform.position, targetPosition, _cameraSpeed * Time.deltaTime);

        transform.position = new Vector3(nextPos.x,nextPos.y, -5f);
    }

}
