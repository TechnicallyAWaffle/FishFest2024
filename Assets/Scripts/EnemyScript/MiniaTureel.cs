using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaiaTureel : EnemyScript
{

    private float currentTime = 5;
    private float targetTime = 5;

    private SpriteRenderer m_Renderer;

    private Color tmp;

    private void Awake()
    {
        m_Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void ChasingBehaviour()
    {
        tmp = m_Renderer.color;
        if (tmp.a < 100)
        {
            tmp.a += 1f;
        }
        m_Renderer.color = tmp;
        base.ChasingBehaviour();
    }

    public override void FleeingBehaviour()
    {
        tmp = m_Renderer.color;
        if (tmp.a > 0)
        {
            tmp.a -= 1f;
        }
        m_Renderer.color = tmp;
        base.FleeingBehaviour();
    }

    public override void NeutralBehaviour()
    {
        tmp = m_Renderer.color;
        if (tmp.a < 100)
        {
            tmp.a += 1f;
        }
        m_Renderer.color = tmp;
        base.NeutralBehaviour();
    }

    public override void PheromoneBehaviour()
    {
        tmp = m_Renderer.color;
        if (tmp.a < 100)
        {
            tmp.a += 1f;
        }
        m_Renderer.color = tmp;
        base.PheromoneBehaviour();
    }

}
