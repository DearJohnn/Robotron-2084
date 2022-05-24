using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float dampTime = 0.4f;
    public BoxCollider2D mapBounds;
    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 1.68f;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = new Vector3(Player.position.x, Player.position.y, -10f);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
        camY = Mathf.Clamp(Player.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(Player.position.x, xMin + cameraRatio, xMax - cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
