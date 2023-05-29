using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> weapons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // attach weapn
            AddFlyPanWeapon();
        }
    }

    void AddWeapon()
    {

    }

    void AddFlyPanWeapon()
    {
        GameObject _flyPan = weapons.Find(item => item.GetComponent<FlyPan>() != null);
        if (_flyPan != null) {
            _flyPan.GetComponent<FlyPan>().speed *= 0.20f;
            return;
        }

        GameObject flyPan = LoadPrefab("prefabs/FlyPan");

        GameObject flyPanObj = Instantiate(flyPan, transform);
        weapons.Add(flyPanObj);
    }

    GameObject LoadPrefab(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            Debug.LogError("load prefab error for " + path);
            return null;
        }
        return prefab;
    }
}
