using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���˵�λ����
public class EnemyKilledSubject : IGameEventSubject
{
    private int m_KilledCount = 0;
    private IEnemy m_Enemy = null;

    public EnemyKilledSubject()
    {
        
    }

    //ȡ�ö���
    public IEnemy GetEnemy()
    {
        return m_Enemy;
    }

    //Ŀǰ���˵�λ������
    public int GetKilledCount()
    {
        return m_KilledCount;
    }

    //֪ͨ���˵�λ����
    public override void SetParam(object Param)
    {
        base.SetParam(Param);
        m_Enemy = Param as IEnemy;
        m_KilledCount++;

        //֪ͨ
        Notify();
    }
}