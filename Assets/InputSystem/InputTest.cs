using UnityEngine;
using UnityEngine.InputSystem;//InputSystemを使用する際に必ず記述するやつ

public class InputTest : MonoBehaviour
{
    InputAction moveAction;//アクションマップからアクションを取得する為の変数の作成
    InputAction lookAction;//アクションマップからアクションを取得する為の変数の作成
    InputAction fireAction;//アクションマップからアクションを取得する為の変数の作成

    [SerializeField] Transform player;

    //移動速度
    float speed = 0.1f;

    void Start()
    {
        //ここで取得したいGetComponent<PlayerInput>();を使っているオブジェクトを指定してやればいい
        //現在のアクションマップを取得
        var pInput = GameObject.Find("InputManager").GetComponent<PlayerInput>();

        //初期状態はPlayerInputコンポーネントのinspectorのDefaultMap
        var actionMap = pInput.currentActionMap;

        //アクションマップからアクションを取得
        moveAction = actionMap["Move"];
        //lookAction = actionMap["Look"];
        fireAction = actionMap["Fire"];

        moveAction.performed += _ => Debug.Log("Fire");

    }

    void Update()
    {
        //アクションからコントローラの入力値を取得
        Vector2 move = moveAction.ReadValue<Vector2>();
        //Vector2 look = _lookAction.ReadValue<Vector2>();
        bool fire = fireAction.triggered;

        Debug.Log(string.Format("move:{0}", move));
        Debug.Log(string.Format("Fire:{0}", fire));

        //移動部分
        Vector3 pos = player.transform.position;

        pos.x = pos.x + move.x * (speed * Time.deltaTime);
        pos.y = pos.y + move.y * (speed * Time.deltaTime);

        player.transform.position = pos;


    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void OnDestroy()
    {
        moveAction.Dispose();
    }
}
