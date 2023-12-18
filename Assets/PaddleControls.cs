using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControls : MonoBehaviour
{
    
    [SerializeField] Vector2 MouseWorldPos;
    Transform TheT;
    // Start is called before the first frame update
    void Start()
    {
        TheT = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        MouseWorldPos.y = 0;
        if (MouseWorldPos.x > 3)
        {
            MouseWorldPos.x = 3;
        }
        if (MouseWorldPos.x < -3)
        {
            MouseWorldPos.x = -3;
        }
    }
    private void FixedUpdate()
    {
        TheT.position = MouseWorldPos;
    }
}
