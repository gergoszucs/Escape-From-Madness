using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon1;
    public Gun gun; 

    void Start()
    {
        weapon1.SetActive(true);
    }
}