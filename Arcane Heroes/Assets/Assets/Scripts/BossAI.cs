using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;





public class BossAI : baseAI
{
    private float jumpTimer;
    private float boulderTimer;
    private new int spellSelect;
    private static BossAI _instance;

    

    public GameObject lineOfSightBase;

    private GameObject[] boulderSpawn;
    public GameObject boulder;

    public GameObject projectileCheck;
    public GameObject projectileCheckTop;

    string bossType;

    float changeTypeTimer;
    bool incomingProjectile;
    
    public static BossAI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BossAI();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public override void Start()
    {
        base.Start();
        boulderSpawn = GameObject.FindGameObjectsWithTag("boulderSpawn");
        incomingProjectile = false;

        bossType = "Enemy";

        changeTypeTimer = 15.0f;
        jumpForce = 800;
        entityHealth = 5;

    }
    public override void Update()
    {

        if(entityHealth <= 0)
        {
            changeScene.staticChange(0);
        }
        base.Update();

        changeTypeTimer -= Time.deltaTime;
        if(changeTypeTimer <= 0)
        {
            int bossChangeType = Random.Range(0, 3);

            if(bossChangeType == 0)
            {
                bossType = "enemyAir";
            }
            else if(bossChangeType == 1)
            {
                bossType = "enemyFire";
            }
            else if(bossChangeType == 2)
            {
                bossType = "enemyWater";
            }
            
            Debug.Log("Changed to " + bossType);

            changeTypeTimer = 15.0f;
        }

        gameObject.tag = bossType;

        incomingProjectile = Physics2D.Linecast(projectileCheck.transform.position, projectileCheckTop.transform.position, 1 << LayerMask.NameToLayer("playerProjectile"));
        Debug.DrawLine(projectileCheck.transform.position, projectileCheckTop.transform.position, Color.green);
        spotted = Physics2D.CircleCast(lineOfSightBase.transform.position, 5.0f, lineOfSight.transform.position, 1 << LayerMask.NameToLayer("Player"));
        

        if (spotted)
        {
            currentState = (int)AIState.chase;


            if (currentState == (int)AIState.chase)
            {
                
                chase();
            }

                if (currentState == (int)AIState.fire)
                {
                
                    if (timer <= 0)
                    {
                    if (spellSelect == 0)
                    {
                        fire(Spells[spellSelect], staff.transform, transform.rotation * Quaternion.Euler(0, 0, 30));
                        fire(Spells[spellSelect], staff.transform, transform.rotation);
                        fire(Spells[spellSelect], staff.transform, transform.rotation * Quaternion.Euler(0, 0, -30));
                    }
                    else if (spellSelect == 1)
                    {
                        projectileSpeed = 500;
                        waterFire(spellSelect);
                    }
                        timer = 4.0f;
                    
                    }

                    if (entityHealth <= 5 && boulderTimer <= 0)
                    {
                        boulder.SetActive(true);
                        Instantiate(boulder, boulderSpawn[0].transform);
                        Instantiate(boulder, boulderSpawn[1].transform);
                        Instantiate(boulder, boulderSpawn[2].transform);
                        boulderTimer = 15.0f;
                    }
                }

                if (incomingProjectile && jumpTimer <= 0)
                {
                    jump();
                    jumpTimer = 10.0f;
                }


                stateMachine.Update();

            spellSelect = Random.Range(0, 2);
            Spells[spellSelect].SetActive(true);

            jumpTimer -= Time.deltaTime;
            boulderTimer -= Time.deltaTime;
            
        }
    }

    void chase()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) <= 20 && grounded == true)
        {
            if (transform.position.x < player.transform.position.x && Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) > 15)
            {
                facingRight = true;
                moveRight(movementSpeed);
            }
            else if (transform.position.x > player.transform.position.x && Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) > 15)
            {
                facingRight = false;
                moveLeft(movementSpeed);
            }
            else if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) <= 15)
            {
                currentState = (int)AIState.fire;
                moveLeft(0);
                moveRight(0);
            }

        }
        else
        {
            currentState = (int)AIState.idle;
        }
        
    }
    
}
