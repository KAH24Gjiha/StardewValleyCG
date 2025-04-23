using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerSpeed;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(horizontal, vertical) * playerSpeed;

        //Shift ½Ã ´À·ÁÁü
        if (Input.GetKey(KeyCode.LeftShift)) { rigid.velocity /= 2; }

        Camera.main.transform.position = this.transform.position - Vector3.forward;

    }


}
