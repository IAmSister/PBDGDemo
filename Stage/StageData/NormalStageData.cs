using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//һ��ؿ���Ѷ
public class NormalStageData : IStageData
{
    private float m_CoolDown = 0;       // ������ɫ�ļ��ʱ��
    private float m_MaxCoolDown = 0;    // 
    private Vector3 m_SpawnPosition = Vector3.zero; // ������
    private Vector3 m_AttackPosition = Vector3.zero;// ����Ŀ��
    private bool m_AllEnemyBorn = false;

    //һ��ؿ�Ҫ�����ĵ��˵�λ
    class StageData
    {
        public ENUM_Enemy emEnemy = ENUM_Enemy.Null;
        public ENUM_Weapon emWeapon = ENUM_Weapon.Null;
        public bool bBorn = false;
        public StageData(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon)
        {
            this.emEnemy = emEnemy;
            this.emWeapon = emWeapon;
        }
    }
    // �ؿ���Ҫ�����ĵ��˵�λ
    private List<StageData> m_StageData = new List<StageData>();

    // �趨��ò���һ���з���λ
    public NormalStageData(float CoolDown, Vector3 SpawnPosition, Vector3 AttackPosition)
    {
        m_MaxCoolDown = CoolDown;
        m_CoolDown = m_MaxCoolDown;
        m_SpawnPosition = SpawnPosition;
        m_AttackPosition = AttackPosition;
    }

    // ���ӹؿ��ĵз���λ
    public void AddStageData(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, int Count)
    {
        for (int i = 0; i < Count; ++i)
            m_StageData.Add(new StageData(emEnemy, emWeapon));
    }

    // ����
    public override void Reset()
    {
        foreach (StageData pData in m_StageData)
            pData.bBorn = false;
        m_AllEnemyBorn = false;
    }

    // ����
    public override void Update()
    {
        if (m_StageData.Count == 0)
            return;

        // �Ƿ���Բ���
        m_CoolDown -= Time.deltaTime;
        if (m_CoolDown > 0)
            return;
        m_CoolDown = m_MaxCoolDown;

        // ȡ���ϳ��Ľ�ɫ
        StageData theNewEnemy = GetEnemy();
        if (theNewEnemy == null)
            return;

        // һ�β���һ����λ
        ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
        Factory.CreateEnemy(theNewEnemy.emEnemy, theNewEnemy.emWeapon, m_SpawnPosition, m_AttackPosition);
    }

    // ȡ�û�û����
    private StageData GetEnemy()
    {
        foreach (StageData pData in m_StageData)
        {
            if (pData.bBorn == false)
            {
                pData.bBorn = true;
                return pData;
            }
        }
        m_AllEnemyBorn = true;
        return null;
    }


    // �Ƿ����
    public override bool IsFinished()
    {
        return m_AllEnemyBorn;
    }
}
