using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A self-contained target shooting mini game.
/// Drop this component into a scene and press Play. It creates targets, a crosshair,
/// score/time/ammo UI, and restart controls entirely at runtime.
/// </summary>
public class TargetShootingGame : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private int startingAmmo = 30;
    [SerializeField] private float gameSeconds = 45f;
    [SerializeField] private int visibleTargetCount = 5;
    [SerializeField] private float targetLifetime = 2.8f;
    [SerializeField] private Vector2 spawnXRange = new Vector2(-6f, 6f);
    [SerializeField] private Vector2 spawnYRange = new Vector2(0.8f, 4f);
    [SerializeField] private Vector2 spawnZRange = new Vector2(8f, 16f);

    [Header("Target Settings")]
    [SerializeField] private float minTargetRadius = 0.35f;
    [SerializeField] private float maxTargetRadius = 0.9f;
    [SerializeField] private int baseTargetScore = 10;

    private readonly List<TargetData> targets = new List<TargetData>();

    private Camera mainCamera;
    private Text scoreText;
    private Text ammoText;
    private Text timerText;
    private Text messageText;
    private AudioSource audioSource;

    private int score;
    private int ammo;
    private float remainingTime;
    private bool isPlaying;

    private void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            GameObject cameraObject = new GameObject("Main Camera");
            mainCamera = cameraObject.AddComponent<Camera>();
            cameraObject.tag = "MainCamera";
            cameraObject.transform.position = new Vector3(0f, 2.5f, -8f);
            cameraObject.transform.LookAt(new Vector3(0f, 2f, 10f));
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        ConfigureCamera();
        CreateEnvironment();
        CreateUi();
        StartGame();
    }

    private void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
            {
                StartGame();
            }

            return;
        }

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f || ammo <= 0)
        {
            EndGame();
            return;
        }

        MaintainTargets();
        TickTargets();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        UpdateUi();
    }

    private void StartGame()
    {
        ClearTargets();
        score = 0;
        ammo = startingAmmo;
        remainingTime = gameSeconds;
        isPlaying = true;
        messageText.text = string.Empty;
        MaintainTargets();
        UpdateUi();
    }

    private void EndGame()
    {
        isPlaying = false;
        ClearTargets();
        UpdateUi();
        messageText.text = "ゲーム終了！\nScore: " + score + "\nクリック または Rキーでリスタート";
    }

    private void Shoot()
    {
        ammo--;
        PlayClickSound(380f, 0.04f);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, 100f))
        {
            UpdateUi();
            return;
        }

        Target target = hit.collider.GetComponentInParent<Target>();
        if (target == null)
        {
            UpdateUi();
            return;
        }

        int earnedScore = Mathf.RoundToInt(baseTargetScore / target.Radius * 0.8f);
        score += Mathf.Max(baseTargetScore, earnedScore);
        PlayClickSound(780f, 0.08f);
        RemoveTarget(target.gameObject);
        UpdateUi();
    }

    private void MaintainTargets()
    {
        while (targets.Count < visibleTargetCount)
        {
            SpawnTarget();
        }
    }

    private void TickTargets()
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            TargetData data = targets[i];
            data.Age += Time.deltaTime;
            float pulse = 1f + Mathf.Sin(Time.time * 8f + data.Phase) * 0.08f;
            data.GameObject.transform.localScale = Vector3.one * data.Radius * 2f * pulse;

            if (data.Age >= targetLifetime)
            {
                RemoveTarget(data.GameObject);
            }
        }
    }

    private void SpawnTarget()
    {
        float radius = Random.Range(minTargetRadius, maxTargetRadius);
        Vector3 position = new Vector3(
            Random.Range(spawnXRange.x, spawnXRange.y),
            Random.Range(spawnYRange.x, spawnYRange.y),
            Random.Range(spawnZRange.x, spawnZRange.y));

        GameObject root = new GameObject("Target");
        root.transform.position = position;
        root.transform.LookAt(mainCamera.transform);
        root.transform.localScale = Vector3.one * radius * 2f;

        Target target = root.AddComponent<Target>();
        target.Radius = radius;

        CreateTargetRing(root.transform, "Outer Ring", 0.5f, new Color(1f, 0.1f, 0.1f));
        CreateTargetRing(root.transform, "Middle Ring", 0.34f, Color.white, -0.01f);
        CreateTargetRing(root.transform, "Bullseye", 0.16f, new Color(1f, 0.85f, 0f), -0.02f);

        SphereCollider collider = root.AddComponent<SphereCollider>();
        collider.radius = 0.5f;

        targets.Add(new TargetData(root, radius, Random.Range(0f, Mathf.PI * 2f)));
    }

    private void CreateTargetRing(Transform parent, string ringName, float scale, Color color, float localZ = 0f)
    {
        GameObject ring = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ring.name = ringName;
        ring.transform.SetParent(parent, false);
        ring.transform.localPosition = new Vector3(0f, 0f, localZ);
        ring.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        ring.transform.localScale = new Vector3(scale, 0.025f, scale);
        Destroy(ring.GetComponent<Collider>());

        Renderer renderer = ring.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = color;
    }

    private void RemoveTarget(GameObject targetObject)
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            if (targets[i].GameObject == targetObject)
            {
                targets.RemoveAt(i);
                Destroy(targetObject);
                return;
            }
        }
    }

    private void ClearTargets()
    {
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            Destroy(targets[i].GameObject);
        }

        targets.Clear();
    }

    private void ConfigureCamera()
    {
        mainCamera.clearFlags = CameraClearFlags.Skybox;
        mainCamera.fieldOfView = 60f;
        mainCamera.transform.position = new Vector3(0f, 2.6f, -8f);
        mainCamera.transform.LookAt(new Vector3(0f, 2.3f, 12f));
    }

    private void CreateEnvironment()
    {
        RenderSettings.ambientLight = new Color(0.55f, 0.58f, 0.65f);

        GameObject lightObject = new GameObject("Target Shooting Directional Light");
        Light light = lightObject.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.1f;
        lightObject.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "Target Shooting Floor";
        floor.transform.position = new Vector3(0f, -0.1f, 9f);
        floor.transform.localScale = new Vector3(18f, 0.2f, 22f);
        Renderer floorRenderer = floor.GetComponent<Renderer>();
        floorRenderer.material = new Material(Shader.Find("Standard"));
        floorRenderer.material.color = new Color(0.18f, 0.25f, 0.2f);
    }

    private void CreateUi()
    {
        Canvas canvas = new GameObject("Target Shooting UI").AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvas.gameObject.AddComponent<GraphicRaycaster>();

        Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        scoreText = CreateText(canvas.transform, "Score Text", font, new Vector2(20f, -20f), TextAnchor.UpperLeft, 30);
        ammoText = CreateText(canvas.transform, "Ammo Text", font, new Vector2(20f, -60f), TextAnchor.UpperLeft, 30);
        timerText = CreateText(canvas.transform, "Timer Text", font, new Vector2(-20f, -20f), TextAnchor.UpperRight, 30);
        messageText = CreateText(canvas.transform, "Message Text", font, Vector2.zero, TextAnchor.MiddleCenter, 36);
        messageText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        messageText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        messageText.rectTransform.sizeDelta = new Vector2(700f, 260f);

        CreateCrosshair(canvas.transform);
    }

    private Text CreateText(Transform parent, string textName, Font font, Vector2 anchoredPosition, TextAnchor alignment, int size)
    {
        Text text = new GameObject(textName).AddComponent<Text>();
        text.transform.SetParent(parent, false);
        text.font = font;
        text.fontSize = size;
        text.alignment = alignment;
        text.color = Color.white;
        text.rectTransform.anchorMin = alignment == TextAnchor.UpperRight ? new Vector2(1f, 1f) : new Vector2(0f, 1f);
        text.rectTransform.anchorMax = text.rectTransform.anchorMin;
        text.rectTransform.pivot = alignment == TextAnchor.UpperRight ? new Vector2(1f, 1f) : new Vector2(0f, 1f);
        text.rectTransform.anchoredPosition = anchoredPosition;
        text.rectTransform.sizeDelta = new Vector2(360f, 50f);
        return text;
    }

    private void CreateCrosshair(Transform parent)
    {
        CreateCrosshairLine(parent, "Crosshair Horizontal", new Vector2(38f, 3f));
        CreateCrosshairLine(parent, "Crosshair Vertical", new Vector2(3f, 38f));
    }

    private void CreateCrosshairLine(Transform parent, string lineName, Vector2 size)
    {
        Image line = new GameObject(lineName).AddComponent<Image>();
        line.transform.SetParent(parent, false);
        line.color = new Color(1f, 1f, 1f, 0.85f);
        line.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        line.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        line.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        line.rectTransform.sizeDelta = size;
    }

    private void UpdateUi()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo;
        timerText.text = "Time: " + Mathf.CeilToInt(Mathf.Max(remainingTime, 0f));
    }

    private void PlayClickSound(float frequency, float duration)
    {
        int sampleRate = 44100;
        int sampleCount = Mathf.CeilToInt(sampleRate * duration);
        AudioClip clip = AudioClip.Create("Shot", sampleCount, 1, sampleRate, false);
        float[] samples = new float[sampleCount];
        for (int i = 0; i < sampleCount; i++)
        {
            float fade = 1f - (float)i / sampleCount;
            samples[i] = Mathf.Sin(2f * Mathf.PI * frequency * i / sampleRate) * fade * 0.25f;
        }

        clip.SetData(samples, 0);
        audioSource.PlayOneShot(clip);
    }

    private sealed class TargetData
    {
        public TargetData(GameObject gameObject, float radius, float phase)
        {
            GameObject = gameObject;
            Radius = radius;
            Phase = phase;
        }

        public GameObject GameObject { get; private set; }
        public float Radius { get; private set; }
        public float Phase { get; private set; }
        public float Age { get; set; }
    }
}

public class Target : MonoBehaviour
{
    public float Radius { get; set; }
}
