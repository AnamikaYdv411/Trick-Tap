// Billboard.cs — put on the coin prefab
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera cam;
    void Start() => cam = Camera.main;
    void LateUpdate() => transform.forward = cam.transform.forward;
}