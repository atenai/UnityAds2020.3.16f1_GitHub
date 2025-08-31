using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class かしわばら家 : MonoBehaviour
{
	//シングルトンで作成（ゲーム中に１つのみにする）
	//publicの後にstaticとついています。これで最初からメモリに領域が確保された状態になります。
	//ゲームマネージャーは多くのスクリプトからアクセスされる事が想定されるため、staticにした方がいいのです。
	public static かしわばら家 singletonInstance = null;

	void Awake()
	{
		//staticな変数singletonInstanceはメモリ領域は確保されていますが、初回では中身が入っていないので、中身を入れます。
		if (singletonInstance == null)
		{
			singletonInstance = this;//thisというのは自分自身のインスタンスという意味になります。この場合、かしわばら家のインスタンスという意味になります。
			DontDestroyOnLoad(this.gameObject);//これは、シーンに切り替え時に破棄されない状態にする命令です。
		}
		else
		{
			Destroy(this.gameObject);//中身がすでに入っていた場合、自身のインスタンスがくっついているゲームオブジェクトを破棄します。
		}
	}

	//かしわばら家.singletonInstance.リビング();と言う風に書いて呼び出してあげれば良い
	public void リビング()
	{
		Debug.Log("<color=green> リビングで過ごす </color>");
	}

	//かしわばら家.singletonInstance.トイレ();と言う風に書いて呼び出してあげれば良い
	public void トイレ()
	{
		Debug.Log("<color=green> トイレで過ごす </color>");
	}
}
