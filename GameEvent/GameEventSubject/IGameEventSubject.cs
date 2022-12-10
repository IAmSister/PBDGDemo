using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameEventSubject
{
    private List<IGameEventObserver> m_Observers = new List<IGameEventObserver>();//�۲���
    private System.Object m_Param = null; //�����¼�ʱ���ӵĲ���

    //����
    public void Attach(IGameEventObserver theObserver)
    {
        m_Observers.Add(theObserver);
    }

    //ȡ��
    public void Detach(IGameEventObserver theObserver)
    {
        m_Observers.Remove(theObserver);
    }

    //֪ͨ
    public void Notify()
    {
        foreach (IGameEventObserver theObserver in m_Observers)
        {
            theObserver.Update();
        }
    }

    public virtual void SetParam(System.Object Param)
    {
        m_Param = Param;
    }
}
