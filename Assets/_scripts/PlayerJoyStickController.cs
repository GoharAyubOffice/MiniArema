using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    private Touch touch;
    private Quaternion rotationY;
    private float rotatespeedModifier = 0.1f;

    public FixedJoystick moveJoystick;
    [SerializeField] float moveSpeed = 5f;


    private void Start()
    {
        Application.targetFrameRate = 60;

        moveJoystick = FindObjectOfType<FixedJoystick>();
    }
    void Update()
    {
        Application.targetFrameRate = 60;
        UpdateMoveJoystick();
    }
    void UpdateMoveJoystick()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(
                0f,
                touch.deltaPosition.x * rotatespeedModifier,
                0f);
                transform.rotation = rotationY * transform.rotation;
            }
        }
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(-hoz, 0, -ver);
        transform.Translate(direction * moveSpeed);
    }
}
