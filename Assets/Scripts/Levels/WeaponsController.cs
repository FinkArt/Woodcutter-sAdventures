using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public Transform toporStartPoint; //��������� ����������, ������� ����� ������� ���������
                                      //������� ������� ������ (��� ������ ���� ������� ������),
                                      //� ����� ������ �� ������ ���� ��������� �����
    public float fireRate = 0.5f; //������ ���������� ��� ��������� �������� ������� (������)
    public GameObject toporPrefab; //���������� ��� �������� �������� ������ (��� ����, ������ ����� ������ � ����)
    public float timeUntilFire;  //����� , ������� ����� ����� ������ ������� ������
    Hero heroController; //������ �� ��� ������ ���������� ����������
    public bool weaponsInHands; //���������� ��� �������� ��� ��� ���� ������� ������ � ����� (����� ������� ��� �� �����)

    public static WeaponsController Instance { get; set; } //����� ���������� (� ������� ����� �������� ��������) �� ���� ��������� ����� � ������� ������ Hero, �� �������� ��� ������������

    private void Start()
    {
        heroController = gameObject.GetComponent<Hero>(); //������������� ������ � ������� Hero
       
    }

    private void Awake()
    {
        Instance = this;   
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time && weaponsInHands)
        {
            Fire();
            timeUntilFire = Time.time + fireRate; // ������ ����� ����� ��������� ����������� ������ (����� ������ ������� �������� �������)
        }
    }

    private void Fire()
    {
        float angle = heroController.isRight ? 0f : 180f; //������ ������� ������ ������ � ����������� �� �������, ���� ������� �����
        Instantiate(toporPrefab, toporStartPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))); //Instantiate �������� �� ��������� ������� � ��������� �����
    }

    public void WeaponInHands ()
    {
        weaponsInHands = true;
    }

}
