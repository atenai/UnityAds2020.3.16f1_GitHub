using UnityEngine;
using UnityEngine.InputSystem;//InputSystem���g�p����ۂɕK���L�q������

public class InputTest : MonoBehaviour
{
    InputAction moveAction;//�A�N�V�����}�b�v����A�N�V�������擾����ׂ̕ϐ��̍쐬
    InputAction lookAction;//�A�N�V�����}�b�v����A�N�V�������擾����ׂ̕ϐ��̍쐬
    InputAction fireAction;//�A�N�V�����}�b�v����A�N�V�������擾����ׂ̕ϐ��̍쐬

    [SerializeField] Transform player;

    //�ړ����x
    float speed = 0.1f;

    void Start()
    {
        //�����Ŏ擾������GetComponent<PlayerInput>();���g���Ă���I�u�W�F�N�g���w�肵�Ă��΂���
        //���݂̃A�N�V�����}�b�v���擾
        var pInput = GameObject.Find("InputManager").GetComponent<PlayerInput>();

        //������Ԃ�PlayerInput�R���|�[�l���g��inspector��DefaultMap
        var actionMap = pInput.currentActionMap;

        //�A�N�V�����}�b�v����A�N�V�������擾
        moveAction = actionMap["Move"];
        //lookAction = actionMap["Look"];
        fireAction = actionMap["Fire"];

        moveAction.performed += _ => Debug.Log("Fire");

    }

    void Update()
    {
        //�A�N�V��������R���g���[���̓��͒l���擾
        Vector2 move = moveAction.ReadValue<Vector2>();
        //Vector2 look = _lookAction.ReadValue<Vector2>();
        bool fire = fireAction.triggered;

        Debug.Log(string.Format("move:{0}", move));
        Debug.Log(string.Format("Fire:{0}", fire));

        //�ړ�����
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
