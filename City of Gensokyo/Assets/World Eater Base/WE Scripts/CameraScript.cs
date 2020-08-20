using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform blackhole;
    [SerializeField]
    Transform player;
    Camera cam;
    Transform camt;

    float initialz; //for movement purposes

    [SerializeField]
    float minPlayerBlackholeDist;
    [SerializeField]
    float zoomAdjustSpeed;
    [SerializeField]
    float zoomStrength;
    [SerializeField]
    float camMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (blackhole == null) blackhole = GameObject.Find("BlackHole").GetComponent<Transform>();
        if (player == null) player = GameObject.Find("Player").GetComponent<Transform>();
        cam = GetComponent<Camera>();
        camt = GetComponent<Transform>();
        initialz = camt.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camMoveDir = (player.position - blackhole.position).normalized;
        float screenWidthHeightRatio = (float)Screen.width / Screen.height;
        float cameraDirRatio = Vector2.Dot(new Vector2(Mathf.Abs(camMoveDir.x), Mathf.Abs(camMoveDir.y)), new Vector2(1, screenWidthHeightRatio).normalized);
        //Debug.Log(cameraDirRatio);

        Vector3 targetPos;
        targetPos = (player.position + blackhole.position) / 2;
        float targetSize = Mathf.Max(Vector3.Distance(blackhole.position, player.position), minPlayerBlackholeDist / cameraDirRatio) / zoomStrength * 20;

        Vector3 velPos = Vector3.zero;
        float velSize = 0;

        float fpsAdjustRate = (Time.fixedDeltaTime * 2500);

        camt.position = Vector3.SmoothDamp(camt.position, targetPos, ref velPos, 1 / camMoveSpeed / cameraDirRatio / fpsAdjustRate);
        camt.position = Vector3.Scale(camt.position, new Vector3(1, 1, 0)) + new Vector3(0, 0, initialz);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetSize * cameraDirRatio, ref velSize, 1 / zoomAdjustSpeed / fpsAdjustRate);
    }
}
