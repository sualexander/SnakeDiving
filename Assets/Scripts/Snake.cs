using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    public GameObject hook;
    public GameObject bone1;
    public float gravity = 5;
    public float speed = 1;
    public float amplitude = 1;

    public Rigidbody2D rb;
    public float force = 1;

    public SnakeDiving inputControls;
    private InputAction movement;
    public float sensitivity = 1;
    public float factor = 4;
    public float leftBound = 0;
    public float rightBound = 1000;
    public float borderForce = 100;
    public float rotationRate = 2;

    public float threshold = -2000;
    public float diveSpeed = 6;

    public float degrees = 2;

    public GameObject mainCamera;
    private Camera cam;

    void Awake()
    {
        inputControls = new SnakeDiving();
    }

    void OnEnable()
    {
        movement = inputControls.Player.Move;
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    private Quaternion RVERTICAL;

    void Start()
    {
        RVERTICAL = hook.transform.rotation * Quaternion.Euler(0,0,180);
        cam = mainCamera.GetComponent<Camera>();
    }

    private bool hasBordered = false;
    private bool ending = false;
    private bool hasEnded = false;

    void Update()
    {
        if (!ending)
        {
            hook.transform.Translate(Vector2.down * gravity * Time.deltaTime, Space.World);
            hook.transform.Translate(Vector2.right * Mathf.Sin(Time.time * speed) * amplitude * Time.deltaTime, Space.World);

            Vector2 pos = hook.transform.TransformPoint(bone1.transform.position);
            Vector2 screenPos = bone1.transform.position;

            print(screenPos.x);

            if (screenPos.x > rightBound)
            {
                if (!hasBordered)
                {
                    hasBordered = true;
                    StartCoroutine(Deflect(Vector2.left));
                }
            }
            else if (screenPos.x < leftBound)
            {
                if (!hasBordered)
                {
                    hasBordered = true;
                    StartCoroutine(Deflect(Vector2.right));
                }
            }
            else
            {
                Vector2 moveVec = movement.ReadValue<Vector2>();
                if (moveVec.y > 0)
                {
                    moveVec = new Vector2(moveVec.x, 0);
                    print(Quaternion.Slerp(hook.transform.rotation, RVERTICAL, Time.deltaTime * rotationRate));
                    hook.transform.rotation = Quaternion.Slerp(hook.transform.rotation, RVERTICAL, Time.deltaTime * rotationRate);
                    //hook.transform.Rotate(new Vector3(0, 0, degrees), Space.World);
                }
                hook.transform.Translate(moveVec * Time.deltaTime * sensitivity, Space.World);
            } 
            if (mainCamera.transform.position.y <= threshold) 
            {
                ending = true;
            }
        }
        else
        {
            if (!hasEnded)
            {
                hasEnded = true;
                foreach (Transform child in transform)
                {
                    var rigidBody = child.GetComponent<Rigidbody2D>();
                    rigidBody.gravityScale = 0;
                }
            }
            hook.transform.Translate(Vector2.down * diveSpeed * Time.deltaTime, Space.World);
        }   
    }

    private IEnumerator Deflect(Vector2 dir)
    {
        float timer = 0;
        float length = 0.5f;

        while (timer < length)
        {
            timer += Time.deltaTime / length;
            hook.transform.Translate(dir * Time.deltaTime * borderForce, Space.World);
            yield return null;
        }

        hasBordered = false;
    }
}
