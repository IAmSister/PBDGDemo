using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����Builder�������������
public class CharacterBuilderSystem : IGameSystem
{
    private int m_GameObjectID = 0;

    public CharacterBuilderSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    { }

    public override void Initialize()
    { }

    public override void Update()
    { }


    // ���� 
    public void Construct(ICharacterBuilder theBuilder)
    {
        // ����Builder���������ݼ���Product��
        theBuilder.LoadAsset(++m_GameObjectID);
        theBuilder.AddOnClickScript();
        theBuilder.AddWeapon();
        theBuilder.SetCharacterAttr();
        theBuilder.AddAI();

        // �����������
        theBuilder.AddCharacterSystem(m_PBDGame);
    }
}
