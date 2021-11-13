using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject _player;
    private Camera _camera;
    [SerializeField] Vector3 _cameraOffset;
    [SerializeField] List<Vector2> bounds;
    //private _cameraArea;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = _player.transform.position + _cameraOffset;
        _camera.transform.position = new Vector3(Mathf.Clamp(target.x,bounds[0].x,bounds[0].y), Mathf.Clamp(target.y, bounds[1].x, bounds[1].y), Mathf.Clamp(target.z, bounds[2].x, bounds[2].y));
    }
}
