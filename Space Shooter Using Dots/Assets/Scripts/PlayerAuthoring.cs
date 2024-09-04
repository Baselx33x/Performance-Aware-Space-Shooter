using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAuthoring : MonoBehaviour
{

    public float m_PlayerSpeed = 5f;
    public GameObject m_ProjectilePrefab;

    public  class PlayerBaker : Baker<PlayerAuthoring>
    {
    
        public override void Bake(PlayerAuthoring authoring)
        {

            Entity PlayerEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<PlayerTag>(PlayerEntity);
            AddComponent<ProjectileTag>(PlayerEntity);
            SetComponentEnabled<ProjectileTag>(PlayerEntity , false);


            AddComponent(PlayerEntity, new MovementSpeed
            {
                C_PlayerSpeed = authoring.m_PlayerSpeed
            });

            AddComponent(PlayerEntity, new PlayerInput
            {
                C_Input = float2.zero
            });


            AddComponent(PlayerEntity, new ProjectilePrefab
            {
                C_ProjectilePrefab = GetEntity(authoring.m_ProjectilePrefab, TransformUsageFlags.Dynamic)
            });

        }
    }

  
}

public struct PlayerTag : IComponentData { }
public struct MovementSpeed : IComponentData
{
    public float C_PlayerSpeed;
}

public struct PlayerInput : IComponentData
{
  public float2 C_Input;

}

public struct ProjectileSpeed: IComponentData
{
    public float C_ProjectileSpeed;
}

public struct ProjectilePrefab : IComponentData
{
    public Entity C_ProjectilePrefab;
}

public struct ProjectileTag : IComponentData, IEnableableComponent { }
