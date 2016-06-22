using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float speed = 3.0f;
        float rotateSpeed = 3.0f;

        //获取人称控制器组件
        CharacterController controller = (CharacterController)base.GetComponent(typeof(CharacterController));
        //水平方向旋转摄像头(方向键← → 或者 w s 键) ， 玩游戏的人都知道
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        // 翻译当前坐标到世界坐标方向，就是说现在人物的前后左右到底在那个轴上面
        // Vector3.forward 前
        // Vector3.back 后
        // Vector3.down 下
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        // 获取当前垂直方向的输入(方向键↑↓ 或者 a d 键)，玩游戏的人都知道
        float curSpeed = speed * Input.GetAxis("Vertical");
        // 移动,因为刚才翻译坐标的时候其他几个轴都设置成了0，所以只有有数值的那根轴会发生变化
        controller.SimpleMove(forward * curSpeed);
	}
}
