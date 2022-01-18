using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBigEnemy : Enemy // INHERITANCE
{
    [SerializeField] private float slowEnemySpeed = 3.0f;
    private Rigidbody slowEnemyRb;
    private GameObject player1;
    // Start is called before the first frame update
    void Awake()
    {
        slowEnemyRb = GetComponent<Rigidbody>();
        player1 = GameObject.Find("Player");
    }


    public override void AttackPlayer() // POLYMORPHISM
    {
        Vector3 lookDirection = (player1.transform.position - transform.position).normalized;
        slowEnemyRb.AddForce(lookDirection * slowEnemySpeed * Time.deltaTime, ForceMode.VelocityChange);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    public override void SetScale() // POLYMORPHISM
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        base.SetScale();
    }
}
