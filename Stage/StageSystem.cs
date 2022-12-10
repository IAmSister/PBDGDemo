using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ؿ�����ϵͳ
public class StageSystem : IGameSystem
{
    public const int MAX_HEART = 3;
    private int m_NowHeart = MAX_HEART;         // Ŀǰ�����ش���r
    private int m_EnemyKilledCount = 0;         // Ŀǰ�ط���λ������

    private int m_NowStageLv = 1;   // Ŀǰ�Ĺؿ�
    private IStageHandler m_NowStageHandler = null;
    private IStageHandler m_RootStageHandler = null;
    private List<Vector3> m_SpawnPosition = null;       // ������
    private Vector3 m_AttackPos = Vector3.zero; // ������
    //private bool m_bCreateStage = false;		// �Ƿ���Ҫ�����ؿ�
    public StageSystem(PBaseDefenseGame pBDGame) : base(pBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        // �趨�ؿ�
        InitializeStageData();
        // ָ����һ���ؿ�
        m_NowStageHandler = m_RootStageHandler;
        m_NowStageLv = 1;
        //ע����Ϸ�¼�
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverStageScore(this));
    }

    public override void Release()
    {
        base.Release();
        m_SpawnPosition.Clear();
        m_SpawnPosition = null;
        m_NowHeart = MAX_HEART;
        m_EnemyKilledCount = 0;
        m_AttackPos = Vector3.zero;
    }
    // ����
    public override void Update()
    {
        // ����Ŀǰ�Ĺؿ�
        m_NowStageHandler.Update();

        // �Ƿ�Ҫ�л���һ���ؿ�
        if (m_PBDGame.GetEnemyCount() == 0)
        {
            // �Ƿ����
            if (m_NowStageHandler.IsFinished() == false)
                return;

            // ȡ����һ��
            IStageHandler NewStageData = m_NowStageHandler.CheckStage();

            // �Ƿ�Ϊ�ɵĹؿ�
            if (m_NowStageHandler == NewStageData)
                m_NowStageHandler.Reset();
            else
                m_NowStageHandler = NewStageData;

            // ֪ͨ������һ��
            NotiyfNewStage();
        }
    }

    // ֪ͨ��ʧ
    public void LoseHeart()
    {
        m_NowHeart -= m_NowStageHandler.LoseHeart();
        m_PBDGame.ShowHeart(m_NowHeart);
    }

    // ����Ŀǰ��ɱ��(��͸��GameEventSystem����)
    public void AddEnemyKilledCount()
    {
        m_EnemyKilledCount++;
    }

    // �趨Ŀǰ��ɱ��(͸��GameEventSystem����)
    public void SetEnemyKilledCount(int KilledCount)
    {
        //Debug.Log("StageSysem.SetEnemyKilledCount:"+KilledCount);
        m_EnemyKilledCount = KilledCount;
    }

    // ȡ��Ŀǰ��ɱ��
    public int GetEnemyKilledCount()
    {
        return m_EnemyKilledCount;
    }

    // ֪ͨ�µĹؿ�
    private void NotiyfNewStage()
    {
        m_PBDGame.ShowGameMsg("�µ��P��");
        m_NowStageLv++;

        //  ��ʾ
        m_PBDGame.ShowNowStageLv(m_NowStageLv);

        // �¼�
        m_PBDGame.NotifyGameEvent(ENUM_GameEvent.NewStage, m_NowStageLv);

    }

    // ��ʼ���йؿ�
    private void InitializeStageData()
    {
        if (m_RootStageHandler != null)
            return;

        // �ο���
        Vector3 AttackPosition = GetAttackPosition();

        NormalStageData StageData = null; // �ؿ�Ҫ������Enemy
        IStageScore StageScore = null; // �ؿ�������Ѷ
        IStageHandler NewStage = null;

        // ��1��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Gun, 3);
        StageScore = new StageScoreEnemyKilledCount(3, this);
        NewStage = new NormalStageHandler(StageScore, StageData);

        // �趨Ϊ��ʼ�ؿ�
        m_RootStageHandler = NewStage;

        // ��2��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Rifle, 3);
        StageScore = new StageScoreEnemyKilledCount(6, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��3��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Rocket, 3);
        StageScore = new StageScoreEnemyKilledCount(9, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��4��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Troll, ENUM_Weapon.Gun, 3);
        StageScore = new StageScoreEnemyKilledCount(12, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��5��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Troll, ENUM_Weapon.Rifle, 3);
        StageScore = new StageScoreEnemyKilledCount(15, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��5��:Boss�ؿ�
        /*StageData 	= new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
		StageData.AddStageData( ENUM_Enemy.Ogre, ENUM_Weapon.Rocket,3); 
		StageScore 	= new StageScoreEnemyKilledCount(13, this);
		NewStage = NewStage.SetNextHandler( new BossStageHandler( StageScore, StageData) );*/

        // ��6��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Troll, ENUM_Weapon.Rocket, 3);
        StageScore = new StageScoreEnemyKilledCount(18, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��7��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Ogre, ENUM_Weapon.Gun, 3);
        StageScore = new StageScoreEnemyKilledCount(21, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��8��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Ogre, ENUM_Weapon.Rifle, 3);
        StageScore = new StageScoreEnemyKilledCount(24, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��9��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Ogre, ENUM_Weapon.Rocket, 3);
        StageScore = new StageScoreEnemyKilledCount(27, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));

        // ��10��
        StageData = new NormalStageData(3f, GetSpawnPosition(), AttackPosition);
        StageData.AddStageData(ENUM_Enemy.Elf, ENUM_Weapon.Rocket, 3);
        StageData.AddStageData(ENUM_Enemy.Troll, ENUM_Weapon.Rocket, 3);
        StageData.AddStageData(ENUM_Enemy.Ogre, ENUM_Weapon.Rocket, 3);
        StageScore = new StageScoreEnemyKilledCount(30, this);
        NewStage = NewStage.SetNextHandler(new NormalStageHandler(StageScore, StageData));
    }

    // ȡ�ó�����
    private Vector3 GetSpawnPosition()
    {
        if (m_SpawnPosition == null)
        {
            m_SpawnPosition = new List<Vector3>();

            for (int i = 1; i <= 3; ++i)
            {
                string name = string.Format("EnemySpawnPosition{0}", i);
                GameObject tempObj = UnityTool.FindGameObject(name);
                if (tempObj == null)
                    continue;
                tempObj.SetActive(false);
                m_SpawnPosition.Add(tempObj.transform.position);
            }
        }

        // �������
        int index = UnityEngine.Random.Range(0, m_SpawnPosition.Count - 1);
        return m_SpawnPosition[index];
    }

    // ȡ�ù�����
    private Vector3 GetAttackPosition()
    {
        if (m_AttackPos == Vector3.zero)
        {
            GameObject tempObj = UnityTool.FindGameObject("EnemyAttackPosition");
            if (tempObj == null)
                return Vector3.zero;
            tempObj.SetActive(false);
            m_AttackPos = tempObj.transform.position;
        }
        return m_AttackPos;
    }
}
