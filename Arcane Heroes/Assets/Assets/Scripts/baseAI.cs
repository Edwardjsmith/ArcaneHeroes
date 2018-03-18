using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;

public class baseAI : gameEntity {

    public AudioClip enemyRawr;
 
    public enum AIState
    {
        idle,
        chase,
        fire
    }
    public bool spotted;
    public int currentState;
    protected GameObject player;
    public GameObject lineOfSight;

    //public GameObject spawn;
    

    public AIStateMachine<baseAI> stateMachine { get; set; }

    public override void Start()
    {
        base.Start();
        stateMachine = new AIStateMachine<baseAI>(this);
        stateMachine.ChangeState(idleState.Instance);

        player = GameObject.FindGameObjectWithTag("Player");
        //spawn.transform.position = transform.position;
        spotted = false;

      

    }

	protected void moveLeft(float speed)
    {
        rigid.velocity = new Vector2(-speed * Time.deltaTime, rigid.velocity.y);
    }
    protected void moveRight(float speed)
    {
        rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
    }

   

    // Update is called once per frame
    public override void Update ()
    {
        base.Update();
        
        if (entityHealth <= 0)
        {
            Destroy(gameObject);
        }
        spotted = Physics2D.Linecast(gameObject.transform.position, lineOfSight.transform.position, 1 << LayerMask.NameToLayer("Player"));

        Debug.DrawLine(gameObject.transform.position, lineOfSight.transform.position, Color.green);
    }
    protected void waterFire(int spell)
    {
        GameObject waterSpell = Instantiate(Spells[spell], staff.transform);
        Vector3 targetVector = player.transform.position - waterSpell.transform.position;
        waterSpell.GetComponent<Rigidbody2D>().AddRelativeForce(targetVector.normalized * projectileSpeed);
    }
}
