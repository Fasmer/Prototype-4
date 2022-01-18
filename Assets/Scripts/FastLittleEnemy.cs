using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastLittleEnemy : Enemy // INHERITANCE
{
    [SerializeField] private float fastEnemySpeed = 12.0f;
    private Rigidbody fastEnemyRb;
    private GameObject player1;
    // Start is called before the first frame update
    void Awake()
    {
        fastEnemyRb = GetComponent<Rigidbody>();
        player1 = GameObject.Find("Player");
    }


    public override void AttackPlayer() // POLYMORPHISM
    {
        Vector3 lookDirection = (player1.transform.position - transform.position).normalized;
        fastEnemyRb.AddForce(lookDirection * fastEnemySpeed * Time.deltaTime, ForceMode.VelocityChange);
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
