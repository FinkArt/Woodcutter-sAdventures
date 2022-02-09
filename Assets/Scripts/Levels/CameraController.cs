using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos; //переменна€ дл€ записи координат движений
    
    private void Awake() //в метоже Awake ищем игрока
    {
        if (!player) //проверка на то, что найден игррок или нет
            player = FindObjectOfType<Hero>().transform; //файнд обжект ищет геймобжект Hero и отслеживает его перемещение
    }

    private void Update()
    {
        pos = player.position;
        pos.z = -10f;
        //pos.y = 0f; //заморозить камеру в позиции ” , чтобы она не двигалась за игроком

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
        
}
