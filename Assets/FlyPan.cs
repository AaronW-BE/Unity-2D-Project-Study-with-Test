using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlyPan : MonoBehaviour, IWeapon
{
    public GameObject FlyPanPrefab;

    public float speed;

    public int number;

    public float rangeDistance;

    public string Name => "FlyPan";

    public float Damage { get => Damage; set => Damage = value; }

    public void LevelUp()
    {
        Damage *= 1.2f;
        speed *= 1.2f;
    }

    void Start()
    {
        Vector3 originPos = transform.position;

        float angleDiff = 2 * Mathf.PI / number;
        float r = rangeDistance / (2 * Mathf.Sin(Mathf.PI / number));

        for (int i = 0; i < number; i++)
        {
            float angle = i * angleDiff;
            float x = originPos.x + r * Mathf.Cos(angle);
            float y = originPos.y + r * Mathf.Sin(angle);

            Vector3 pos = new Vector3(x, y, originPos.z);
            Instantiate(FlyPanPrefab, pos, transform.rotation, transform);
        }
    }

    void Update()
    {
        // transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
        transform.Rotate(transform.rotation.x, transform.rotation.y, speed * Time.deltaTime);
    }
}
