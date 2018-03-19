using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEntity : MonoBehaviour
{
    protected float timer;

    private SpriteRenderer entityRenderer;

    protected float projectileSpeed;

    public float jumpForce = 550;
    public float movementSpeed;
    public GameObject[] Spells;
    public GameObject staff;

    protected float damageTimer;

  
    public int entityHealth;

    public static int spellSelect;
    public int showSpell;


    public bool grounded = false;

    protected GameObject groundCheck;
    protected float groundRadius = 0.2f;
    LayerMask whatIsGround;

    protected float animationTime = 0.4f;
    protected Rigidbody2D rigid;

    public bool facingRight;

    public Animator anim;

    protected float coolDown;

    public SpriteRenderer sprite;
    protected float rotateLeft;
    protected float rotateRight;

  
  
    protected Vector3 newScale;
    // Use this for initialization
    virtual public void Start()
    {
        timer = 0.0f;
        damageTimer = 0.0f;
        newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateLeft = -transform.localScale.x;
        rotateRight = transform.localScale.x;
        whatIsGround = LayerMask.GetMask("Default");


        
        groundCheck = GameObject.FindGameObjectWithTag("groundCheck");

        entityRenderer = gameObject.GetComponent<SpriteRenderer>();

       
    }

    // Update is called once per frame
    public virtual void Update()
    {
        damageTimer -= Time.deltaTime;
        timer -= Time.deltaTime;
      
    }

 
    protected void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
        
    }


    protected void jump()
    {
        rigid.velocity = (new Vector2(0, jumpForce * Time.deltaTime));
        
        if(rigid.velocity.y > jumpForce)
        {
            rigid.velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpForce));

            if (grounded)
            {
                rigid.velocity = (new Vector2(rigid.velocity.x, 0));
            }
        }
        

    }

    public void fire(GameObject spell, Transform pos, Quaternion rotation)
    {

        projectileSpeed = facingRight == false ? -500 : 500;

        GameObject bullet = Instantiate(spell, pos.position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(projectileSpeed, 0));



    }

    IEnumerator spriteFlash()
    {
      

        for (float i = 0; i < 9.0f; i++)
        {
            entityRenderer.color = new Color(entityRenderer.color.r, entityRenderer.color.g, entityRenderer.color.b, 0.3f);
            yield return new WaitForSeconds(.1f);
            entityRenderer.color = Color.white; 
            yield return new WaitForSeconds(.1f);
        }


    }


    public void damage()
    {
       

        if (damageTimer <= 0)
        {
            entityHealth--;
            damageTimer = 3.0f;
            StartCoroutine("spriteFlash");
        }
        
        

    }
    public void fire(GameObject spell, Transform pos)
    {
        projectileSpeed = facingRight == false ? -500 : 500;

        GameObject bullet = Instantiate(spell, pos.position, pos.rotation);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(projectileSpeed, 0));
    }

    protected void flip()
    {
        newScale.x = facingRight == false ? newScale.x = rotateLeft : newScale.x = rotateRight;

        transform.localScale = newScale;
    }


}

   


