using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private GatherInput m_gatherInput;
    private Transform m_transform;
    [SerializeField] private float speed;
    int direcction = 1;

    private Vector2 vel_act;
    [SerializeField] private GameObject pies;
    void Start()
    {
        m_gatherInput = GetComponent<GatherInput>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Gravity();
    }

    void Move()
    {
        Flip();
        m_rigidbody2D.velocity = new Vector2(speed * m_gatherInput.ValueX, m_rigidbody2D.velocityY);
    }

    private void Flip()
    {
        if(m_gatherInput.ValueX * direcction < 0)
        {
            m_transform.localScale = new Vector3(-m_transform.localScale.x, 1,1);
            direcction *= -1;
        }
    }

    private void Gravity()
    {
        vel_act.y += Physics2D.gravity.y * Time.deltaTime;

        RaycastHit2D col = Physics2D.Raycast(new Vector2(pies.transform.position.x, pies.transform.position.y), new Vector2(0,-1), 0.025f);
        if(col != null && col.collider != null)
        {
            if (col.transform.CompareTag("Suelo"))
            {
                vel_act.y = 0;
            }
        }

        m_rigidbody2D.velocity = vel_act;
    }
}
