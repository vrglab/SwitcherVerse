using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCreature : Creature
{
    Rigidbody2D rg_body;

    public float speed;

    [Serializable]
    struct SerializedVector2
    {
        public float x, y;
    }

    public void Start()
    {
        rg_body = GetComponent<Rigidbody2D>();
        SerializedVector2 pos = RunManager.Instance.CurrentSettings.GetSetting<SerializedVector2>("pl_pos");
        transform.position = new Vector2(pos.x, pos.y);
    }

    public void OnApplicationQuit()
    {
        RunManager.Instance.CurrentSettings.SetSetting<SerializedVector2>("pl_pos", new SerializedVector2()
        {
           x =  transform.position.x, 
           y = transform.position.y
        });
    }

    protected override void Movement()
    {
        DimensionalState dimensionalState = RunManager.Instance.CurrentSettings.GetSetting<DimensionalState>("dm_state");

        float y_movement = InputManager.Instance.GetValueData<float>("pl_mv_y");
        float x_movement = InputManager.Instance.GetValueData<float>("pl_mv_x");
        switch (dimensionalState)
        {
            case DimensionalState.ThreeD:
                transform.position = new Vector2(
                    transform.position.x - speed * x_movement * Time.deltaTime,
                    transform.position.y + speed * y_movement * Time.deltaTime
                    );
                break;
        }
    }

    public void Update()
    {
        base.Update();
        DimensionalState dimensionalState = RunManager.Instance.CurrentSettings.GetSetting<DimensionalState>("dm_state");

        switch (dimensionalState)
        {
            case DimensionalState.TwoD:
                rg_body.bodyType = RigidbodyType2D.Dynamic;
                break;
            case DimensionalState.ThreeD:
                rg_body.bodyType = RigidbodyType2D.Static;
                break;
        }


        if (InputManager.Instance.GetKeyDown("pla_act_dim_chang"))
        {
            switch (dimensionalState)
            {
                case DimensionalState.TwoD:
                    RunManager.Instance.CurrentSettings.SetSetting("dm_state", DimensionalState.ThreeD);
                    break;
                case DimensionalState.ThreeD:
                    RunManager.Instance.CurrentSettings.SetSetting("dm_state", DimensionalState.TwoD);
                    break;
            }
        }
    }
}

public enum DimensionalState
{
    TwoD = 0,
    ThreeD = 1
}
