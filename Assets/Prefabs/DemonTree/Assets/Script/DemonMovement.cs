using UnityEngine;
using System.Collections;



public class DemonMovement : MonoBehaviour
{
    private Animator anim;
    int hIdles;
    int hAngry;
    int hAttack;
    int hGrabs;
    int hThumbsUp;

    public Transform player;        // Игрок
    public float speed = 5f;        // Скорость подлета привидения
    private bool isHit = false;     // Был ли удар по привидению
    private float timer = 0f;       // Таймер
    public float timeLimit = 10f;   // Время, через которое привидение исчезает
    private Vector3 originalPosition; // Исходная позиция привидения
    private Renderer ghostRenderer; // Рендерер привидения
    private Collider ghostCollider; // Коллайдер привидения
    private Vector3 targetPosition = new Vector3(-10f, 13f, -40f); // Целевая позиция для возвращения

    private AudioSource audioSource;
    public AudioClip moveSound; // Звук начала движения
    public AudioClip hitSound; // Звук столкновения с предметом

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Загрузка звуковых файлов из ресурсов
        // moveSound = Resources.Load<AudioClip>("Assets/Sounds/witch's laugh");
        // hitSound = Resources.Load<AudioClip>("Assets/Sounds/player hit");

        // Получение компонента Animator и установка хэшей
        anim = GetComponent<Animator>();
        hIdles = Animator.StringToHash("Idles");
        hAngry = Animator.StringToHash("Angry");
        hAttack = Animator.StringToHash("Attack");
        hGrabs = Animator.StringToHash("Grabs");
        hThumbsUp = Animator.StringToHash("ThumbsUp");

        // Получение исходной позиции, рендерера и коллайдера привидения
        originalPosition = transform.position;
        ghostRenderer = GetComponent<Renderer>();
        ghostCollider = GetComponent<Collider>();

        // Запуск корутины появления привидения
        StartCoroutine(GhostAppearanceRoutine());
        // Воспроизведение звука начала движения
        audioSource.PlayOneShot(moveSound);
    }

    void Update()
    {
        // Проверка условий, при которых прекращается обновление
        if (isHit || ghostRenderer == null || ghostCollider == null) return;

        // Подлет привидения к игроку
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Увеличение таймера
        timer += Time.deltaTime;

        // Логика анимации
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idles"))
            {
                anim.SetBool(hIdles, false);
                anim.SetBool(hAngry, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idles"))
            {
                anim.SetBool(hIdles, false);
                anim.SetBool(hAttack, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idles"))
            {
                anim.SetBool(hIdles, false);
                anim.SetBool(hGrabs, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idles"))
            {
                anim.SetBool(hIdles, false);
                anim.SetBool(hThumbsUp, true);
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idles"))
            {
                anim.SetBool(hIdles, true);
                anim.SetBool(hAngry, false);
                anim.SetBool(hAttack, false);
                anim.SetBool(hGrabs, false);
                anim.SetBool(hThumbsUp, false);
            }
        }
    }

    IEnumerator GhostAppearanceRoutine()
    {
        while (true)
        {
            // Ожидание случайного времени перед появлением привидения (30 секунд - 1 минута)
            float waitTime = Random.Range(30f, 60f);
            yield return new WaitForSeconds(waitTime);

            // Появление и начало подлета к игроку
            transform.position = originalPosition;
            ghostRenderer.enabled = true; // Делаем привидение видимым
            isHit = false;
            timer = 0f;

            // Воспроизведение звука начала движения
            audioSource.PlayOneShot(moveSound);

            // Пока привидение не исчезло
            while (!isHit)
            {
                // Если игрок достаточно близко для столкновения с привидением, останавливаем его движение
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);
                if (distanceToPlayer > 2f) // Расстояние 2 метра
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

                yield return null;
            }

            // Привидение исчезает, только если isHit становится true
            if (isHit)
            {
                isHit = false;
                Disappear();
            }
        }
    }

    // Функция исчезновения привидения
    void Disappear()
    {
        Debug.Log("Привидение исчезло");
        ghostRenderer.enabled = false; // Делаем привидение невидимым
        transform.position = targetPosition; // Перемещаем привидение в целевую позицию
    }

    // Обработка столкновений привидения с другими объектами
    void OnTriggerEnter(Collider other)
    {
        // Если привидение сталкивается с предметом, оно "исчезает"
        if (other.gameObject.tag == "row")
        {
            isHit = true;
            Debug.Log("Привидение соприкоснулось с предметом!");
            // Воспроизводим звук столкновения
            audioSource.PlayOneShot(hitSound);
            Disappear(); // Вызываем функцию исчезновения
        }
    }
}
