using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public Transform toporStartPoint; //назначаем переменную, котора€ будет хранить начальную
                                      //позицию кидани€ топора (или какого либо другого оружи€),
                                      //в нашем случае от игрока идет стартова€ точка
    public float fireRate = 0.5f; //задаем переменную дл€ стартовой скорости объекта (оружи€)
    public GameObject toporPrefab; //переменна€ дл€ хранени€ ѕрефабов топора (или пуль, смотр€ какое оружие в руке)
    public float timeUntilFire;  //врем€ , которое будет между каждым броском топора
    Hero heroController; //ссылка на наш скрипт управлени€ персонажем
    public bool weaponsInHands; //переменна€ дл€ проверку “ру или ‘олс наличи€ оружи€ в руках (после подбора его на карте)

    public static WeaponsController Instance { get; set; } //можем обращатьс€ (с помощью этого паттерна —инглтон) ко всем публичным пол€м и методам класса Hero, не создава€ его эксземпл€ров

    private void Start()
    {
        heroController = gameObject.GetComponent<Hero>(); //предоставл€ем доступ к скрипту Hero
       
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
            timeUntilFire = Time.time + fireRate; // задаем врем€ между возможным выпусканием топора (грубо говор€ частота стрельбы топором)
        }
    }

    private void Fire()
    {
        float angle = heroController.isRight ? 0f : 180f; //задаем сторону полета топора в зависимости от стороны, куда смотрит игрок
        Instantiate(toporPrefab, toporStartPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))); //Instantiate отвечает за по€вление префаба в указанном месте
    }

    public void WeaponInHands ()
    {
        weaponsInHands = true;
    }

}
