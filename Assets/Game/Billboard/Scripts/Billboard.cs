using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _camTransform;

    private void Start()
    {
        _camTransform = GameMainManager.Instance.CameraManager.transform;
    }

    private void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _camTransform.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
