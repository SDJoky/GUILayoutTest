using UnityEngine;
using System.Collections;

public class GUILayoutTest : MonoBehaviour {
	private float sliderValue = 1.0f;
	private float maxSliderValue = 10.0f;

	void OnGUI () {
		//固定布局 - 群组
		FixedLayout_Group ();
		//自动布局 - 区域
		AutomaticLayout_Area ();
		//实现区域内水平布局和垂直布局
		AutoHoriztontalAndVertical ();
		//使用 GUILayoutOptions 定义某些控件
		overridden ();
	}

	//固定布局 - 群组
	void FixedLayout_Group()
	{
		/* 使用群组 (Groups) 将多个控件 (Controls) 放置在屏幕中心 *///也可以嵌套群组
		
		// 在屏幕中心创建群组
		GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
		// 所有矩形经调整以适应于群组。(0,0) 是群组的左上角。
		
		// 我们将创建框以便于您知道群组在屏幕上的位置。
		GUI.Box (new Rect (0,0,100,100), " 固定布局_群组");
		
		// Fixed Layout
		GUI.Button (new Rect (10,50,80,20), " 固定布局");
		
		// Automatic Layout
		GUILayout.Button ("I am an Automatic Layout Button");
		// 结束前面开始的群组。这很重要，请记住！
		GUI.EndGroup ();
	}

	//自动布局 - 区域
	void AutomaticLayout_Area()
	{
		/* 一个按钮未放置在区域中，以及一个按钮放置在横跨半个屏幕的区域中。 */
		GUILayout.Button ("不在区域内");
		GUILayout.BeginArea (new Rect (Screen.width/4, Screen.height/4, 300, 300));
		GUILayout.Button ("I am completely inside an Area");
		GUILayout.EndArea ();
	}

	//实现区域内水平布局和垂直布局
	void AutoHoriztontalAndVertical()
	{
		// 将所有内容纳入指定 GUI 区域
		GUILayout.BeginArea (new Rect (10,500,200,60));
		
		// 开始单个水平群组 (Horizontal Group)
		GUILayout.BeginHorizontal();
		
		// 按常规放置按钮 (Button)
		if (GUILayout.RepeatButton ("Increase max\nSlider Value"))
		{
			maxSliderValue += 3.0f * Time.deltaTime;
		}
		
		// 将另外两个控件垂直地放在按钮 (Controls) 旁边
		GUILayout.BeginVertical();
		GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
		sliderValue = GUILayout.HorizontalSlider (sliderValue, 0.0f, maxSliderValue);
		
		// 结束群组 (Groups) 和 区域 (Area)
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	//使用 GUILayoutOptions 定义某些控件
	void overridden()
	{
		GUILayout.BeginArea (new Rect (10, 200, Screen.width-200, Screen.height-100));
		GUILayout.Button ("I am a regular Automatic Layout Button");
		GUILayout.Button ("My width has been overridden", GUILayout.Width (95));
		GUILayout.EndArea ();
	}
}
