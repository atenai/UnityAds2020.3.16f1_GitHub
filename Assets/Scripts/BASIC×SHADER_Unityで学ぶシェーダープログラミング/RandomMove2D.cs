using UnityEngine;

/// <summary>
/// オブジェクトを縦横にランダム移動させるシンプルスクリプト
/// </summary>
public class RandomMove2D : MonoBehaviour
{
	[Header("移動設定")]
	[SerializeField] private float moveSpeed = 2.0f;          // 移動速度
	[SerializeField] private float changeInterval = 1.5f;     // 方向変更間隔（秒）

	private Vector3 moveDirection;
	private float timer;

	void Start()
	{
		ChangeDirection();
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= changeInterval)
		{
			timer = 0f;
			ChangeDirection();
		}

		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}

	/// <summary>
	/// ランダム方向を決定
	/// </summary>
	private void ChangeDirection()
	{
		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);

		moveDirection = new Vector3(x, y, 0f).normalized;
	}
}
