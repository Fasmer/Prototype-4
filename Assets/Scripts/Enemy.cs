using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start() 
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
    }

    public virtual void AttackPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.VelocityChange);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public virtual void SetScale()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }



}
