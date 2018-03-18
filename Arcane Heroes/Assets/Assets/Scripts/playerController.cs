using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : gameEntity
{
  

    public GameObject[] life;
    //Everything concerning movement and jumping
    public GameObject openDoor;
    GameObject hasKey;
    GameObject hasAir;
    GameObject hasFire;
    GameObject hasWater;

    public int waterOrb;
    public int fireOrb;
    public int airOrb;
    public int key;

    public GameObject walkingSound;

    float knockBackHazard;
    float knockBackLength;
    float knockBackCount;
    bool knockFromRight;

    bool hasSplitFire;

    float switchDelay;

    float powerUpTimer;

    public Image gameOver;
    public Image pauseMenu;

    public bool pause;

    // int numberOfSpells;

    private static playerController _instance;

    public static playerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new playerController();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }



   
   
    public Slider mana;
    public Slider powerUpTimerBar;

    public override void Start ()
    {
        pause = false;
        base.Start();
        facingRight = true;
        //numberOfSpells = Spells.Length;
        spellSelect = 0;
        changeSpell(spellSelect);

        entityHealth = 5;

        switchDelay = 0;
        

        key = 0;

        hasKey = GameObject.FindGameObjectWithTag("hasKey");
        hasAir = GameObject.FindGameObjectWithTag("hasAir");
        hasWater = GameObject.FindGameObjectWithTag("hasWater");
        hasFire = GameObject.FindGameObjectWithTag("hasFire");


        hasKey.SetActive(false);
        hasAir.SetActive(false);
        hasWater.SetActive(false);
        hasFire.SetActive(false);

        knockBackCount = 0;
        knockBackLength = 0.2f;
        knockBackHazard = 10.0f;

        hasSplitFire = false;
        powerUpTimer = 0;
        powerUpTimerBar.gameObject.SetActive(false);

        gameOver.gameObject.SetActive(false);

        walkingSound.SetActive(false);
    }



    private void HorizontalMovement(float moveSpeed)

    {

        Animator anim = GetComponent<Animator>();
        
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0 && grounded)
        {
            facingRight = false;
            anim.speed = 0.5f;
        }
        else if (horizontal > 0 && grounded)
        {
            facingRight = true;
            anim.speed = 0.5f;

        }
        else
        {
            anim.speed = 0;
            walkingSound.SetActive(false);
        }
        //anim.speed = 0;

        if(grounded == true)
        {
            walkingSound.SetActive(true);
        }
        else
        {
            walkingSound.SetActive(false);
        }

        rigid.velocity = (new Vector2(moveSpeed * horizontal * Time.deltaTime, rigid.velocity.y));
    }


    //Change spell

    void changeSpell(int num)
    {
        int choice = num;
        for(int i = 0; i < Spells.Length; i++)
        {
            if(i == choice)
            {
                Spells[i].gameObject.SetActive(true);
            }
            else
            {
                Spells[i].gameObject.SetActive(false);
            }
        }
    }

    void cycleSpellsUp()
    {
        spellSelect++;

        if (spellSelect > Spells.Length - 1)
        {
            spellSelect = 0;
        }

       changeSpell(spellSelect);
    }
    void cycleSpellsDown()
    {
        spellSelect--;

        if (spellSelect < 0)
        {
            spellSelect = 2;
        }

        changeSpell(spellSelect);
    }






    // Update is called once per frame
    public override void Update ()
    {
        base.Update();


        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }
      
        if(pause)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(!pause)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }


        flip();
        showSpell = spellSelect;
        powerUpTimer -= Time.deltaTime;
        coolDown -= Time.deltaTime;
        mana.value = coolDown;
        powerUpTimerBar.value = powerUpTimer;

        manageHealth();

        //Movement, jumping and attacking
        if (!pause || gameOver.gameObject.activeSelf != true)
        {
            if (knockBackCount <= 0)
            {
                HorizontalMovement(movementSpeed);

                if (Input.GetButtonDown("Fire1") && timer <= 0)
                {
                    if (!hasSplitFire)
                    {
                        fire(Spells[spellSelect], staff.transform);
                    }
                    else if (hasSplitFire)
                    {
                        splitFire();
                    }
                    timer = 1.0f;
                    coolDown = timer;
                }

                if (Input.GetButtonDown("Jump") && grounded == true)
                {
                    jump();
                }
            }
            else
            {
                rigid.velocity = (new Vector2(knockFromRight ? -knockBackHazard : knockBackHazard, knockBackHazard - 9));
                knockBackCount -= Time.deltaTime;
            }
            //End movement
        }

        
            float cycleDirection = Input.GetAxis("DPad");

            if (cycleDirection < 0 && switchDelay <= 0)
            {
                cycleSpellsDown();
                switchDelay = 0.5f;
            }
            else if (cycleDirection > 0 && switchDelay <= 0)
            {
                cycleSpellsUp();
                switchDelay = 0.5f;
            }

        switchDelay -= Time.deltaTime;

        if (Input.GetKeyDown("down"))
        {
            cycleSpellsDown();
        }
        else if (Input.GetKeyDown("up"))
        {
            cycleSpellsUp();
        }




        if (entityHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game over");
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


       if(powerUpTimer <= 0)
        {
            hasSplitFire = false;
            powerUpTimerBar.gameObject.SetActive(false);
        }
        
    }

    void splitFire()
    {
        fire(Spells[spellSelect], staff.transform, transform.rotation * Quaternion.Euler(0, 0, 30));
        fire(Spells[spellSelect], staff.transform, transform.rotation);
        fire(Spells[spellSelect], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -30));
    }

    void manageHealth()
    {
        if (entityHealth <= 4)
        {
            life[4].SetActive(false);
        }
        if (entityHealth <= 3)
        {
            life[3].SetActive(false);
        }
        if (entityHealth <= 2)
        {
            life[2].SetActive(false);
        }
        if (entityHealth <= 1)
        {
            life[1].SetActive(false);
        }
        if (entityHealth <= 0)
        {
            life[0].SetActive(false);
        }

        
    }

   

    
    

    public IEnumerator knockBackSpike(float knockBackDuration, float knockBackPower, Vector2 knockBackDirection)
    {
        
        rigid.velocity = (new Vector2(0, 0));
      
       
       rigid.AddForce(new Vector2(knockBackDirection.x - knockBackPower * 10, knockBackDirection.y + knockBackPower));
       
      

        yield return 0;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Exit" && airOrb == 1 && fireOrb == 1 && waterOrb == 1 )
        {
            changeScene.staticChange(gameManager.scene += 2);
        }
        if (collision.transform.tag == "ExitTut")
        {
            changeScene.staticChange(gameManager.scene += 2);
        }
        if (collision.transform.tag == "Hazard" || collision.transform.tag == "Enemy" || collision.transform.tag == "enemyProjectile")
        {
            damage();
            knockBackCount = knockBackLength;

            knockFromRight = transform.position.x < collision.transform.position.x ? true : false;

           
        }
        if (collision.transform.tag == "Spike")
        {
            damage();

            StartCoroutine(knockBackSpike(0.02f, 300, transform.position));
        }
        if (collision.transform.tag == "Key")
        {
            Destroy(collision.gameObject);
            key = 1;
            hasKey.SetActive(true);

        }

        if (collision.transform.tag == "Door" && key == 1)
        {
            Instantiate(openDoor, collision.gameObject.transform);
            Destroy(collision.gameObject);
            key--;
            hasKey.SetActive(false);

        }
        if (collision.transform.tag == "OrbOfWater")
        {
            Destroy(collision.gameObject);
            waterOrb = 1;
            hasWater.SetActive(true);

        }
        if (collision.transform.tag == "OrbOfFire")
        {
            Destroy(collision.gameObject);
            fireOrb = 1;
            hasFire.SetActive(true);

        }
        if (collision.transform.tag == "OrbOfAir")
        {
            Destroy(collision.gameObject);
            airOrb = 1;
            hasAir.SetActive(true);
        }
        if (collision.transform.tag == "splitFire")
        {
            Destroy(collision.gameObject);
            powerUpTimer = 10.0f;
            powerUpTimerBar.gameObject.SetActive(true);
            hasSplitFire = true;
        }
        if (collision.transform.tag == "Health")
        {
            Destroy(collision.gameObject);
            entityHealth++;

            if (entityHealth > 5)
            {
                entityHealth = 5;
            }

            if (life[entityHealth - 1].activeSelf == false)
            {
                life[entityHealth - 1].SetActive(true);
            }
            else
            {
                Debug.Log("max health!");
            }
        }
        if (collision.transform.tag == "jumpWall")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "jumpWall")
        {
            grounded = false; 
        }
    }


}
