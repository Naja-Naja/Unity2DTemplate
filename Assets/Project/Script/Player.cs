using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float gravity; //重力　New
    public float jumpSpeed;
    public isGround bottomCollider;
    bool jumping;
    bool pushspace=false;
    //public GroundCheck ground; //接地判定

    //プライベート変数
    //private Animator anim = null;
    private Rigidbody2D rb = null;

    void Start()
    {
        //Time.timeScale = 0.1f;
        //コンポーネントのインスタンスを捕まえる
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            pushspace = true;
        }
    }
    void FixedUpdate()
    {
        //接地判定を得る
        //isGround = ground.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxisRaw("Horizontal");
        float xSpeed = 0.0f;


        if (horizontalKey > 0)
        {
            //transform.localScale = new Vector3(1, 1, 1);
            //anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            //anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            //anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        if (pushspace == true)
        {
            if (bottomCollider._isGround && jumping == false)
            {
                StartCoroutine("Jump");
            }
            pushspace = false;
        }
        //float verticalKey = Input.GetAxisRaw("Vertical");
        float ySpeed = rb.velocity.y; //New
        
        if (jumping == false)
        {
            ySpeed = -gravity;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed); //New
    }
    IEnumerator Jump()
    {
        jumping = true;
        float time=0.3f;
        //float time = 0.25f;
        //float ySpeed=0;
        //float verticalKey = Input.GetAxisRaw("Vertical");
        var verticalKey = Input.GetKey(KeyCode.Space);
        float inputTime = 0;
        while (verticalKey && inputTime < time)
        {
            inputTime = inputTime + Time.deltaTime;
            verticalKey = Input.GetKey(KeyCode.Space);
            //verticalKey = Input.GetAxisRaw("Vertical");
            //ySpeed = jumpSpeed;
            //Debug.Log("aaa");
            //rb.velocity = new Vector2(0, jumpSpeed*(time-inputTime)); 
            rb.velocity = new Vector2(0, jumpSpeed*Mathf.Cos(time*8*Mathf.PI*inputTime)); 
            yield return null;
        }
        while (bottomCollider._isGround==false)
        {

            rb.velocity = new Vector2(0, -jumpSpeed * Mathf.Cos(time * 8 * Mathf.PI * inputTime));
            yield return null;
        }

        jumping = false;
        yield return null;
    }
}
