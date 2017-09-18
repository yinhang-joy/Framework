using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
 * @des:滚动列表优化 
 * @注:
 * 1.基于UGUI  布局排列
 * 2.UIWarpContent的ScrollRect内的item进行优化
*/
[DisallowMultipleComponent]
public class UIWarpContent : MonoBehaviour {

	public delegate void OnInitializeItem(GameObject go,int dataIndex);

	public OnInitializeItem onInitializeItem;

	public enum Arrangement
	{
		Horizontal,
		Vertical,
	}

	/// <summary>
	/// 排列类型
	/// </summary>

	public Arrangement arrangement = Arrangement.Horizontal;

	/// <summary>
	/// 每行最多数据
	/// </summary>
	[Range(1,50)]
	public int maxPerLine = 1;

	/// <summary>
	/// 格子宽度
	/// </summary>

	public float cellWidth = 200f;

	/// <summary>
	/// 格子高度
	/// </summary>

	public float cellHeight = 200f;

	/// <summary>
	/// 格子之间的左右间距
	/// </summary>
	[Range(0, 50)]
	public float cellWidthSpace = 0f;

    /// <summary>
    /// 格子之间的上下间距
    /// </summary>
    [Range(0, 50)]
	public float cellHeightSpace = 0f;

    /// <summary>
    /// 显示的行数
    /// </summary>
	[Range(0,30)]
	public int viewCount = 5;

	public ScrollRect scrollRect;

	public RectTransform content;

	public GameObject goItemPrefab;

    /// <summary>
    /// Item数据总量
    /// </summary>
	private int dataCount;
    /// <summary>
    /// 当前行数
    /// </summary>
	private int curScrollPerLineIndex = -1;
    /// <summary>
    /// 显示item集合
    /// </summary>
	private List<UIWarpContentItem> listItem;
    /// <summary>
    /// 没有被使用的item集合，相当于缓存池
    /// </summary>
	private Queue<UIWarpContentItem> unUseItem;


	void Awake(){
		listItem = new List<UIWarpContentItem> ();
		unUseItem = new Queue<UIWarpContentItem> ();
	}
    //初始化
	public void Init(int dataCount)
	{
		if (scrollRect == null || content == null || goItemPrefab == null) {
			Debug.LogError ("异常:请检测<"+gameObject.name+">对象上UIWarpContent对应ScrollRect、Content、GoItemPrefab 是否存在值...."+scrollRect+" _"+content+"_"+goItemPrefab);
			return;
		}
		if (dataCount <= 0)//没有物品
		{
			return;
		}
		setDataCount (dataCount);
        
		scrollRect.onValueChanged.RemoveAllListeners();//先移除所有滑动监听
		scrollRect.onValueChanged.AddListener (onValueChanged);//添加滑动监听

		unUseItem.Clear ();
		listItem.Clear ();
                
		setUpdateRectItem (0);
	}
    /// <summary>
    /// 设置Item数据总量
    /// </summary>
    /// <param name="count"></param>
	private void setDataCount(int count)
	{
		if (dataCount == count) 
		{
			return;
		}
		dataCount = count;
		setUpdateContentSize();
	}

	private void onValueChanged(Vector2 vt2){
		switch (arrangement) {
		case Arrangement.Vertical:
			float y = vt2.y;
			if (y >= 1.0f || y <= 0.0f) {
				return;
			}
			break;
		case Arrangement.Horizontal:
			float x = vt2.x;
			if (x <= 0.0f || x >= 1.0f) {
				return;
			}
			break;
		}
		int _curScrollPerLineIndex = getCurScrollPerLineIndex ();
		if (_curScrollPerLineIndex == curScrollPerLineIndex){
			return;
		}
		setUpdateRectItem (_curScrollPerLineIndex);
    }
     
	/// <summary>
    /// 设置更新区域内item 功能:1.隐藏区域之外对象 2.更新区域内数据
    /// </summary>
    /// <param name="scrollPerLineIndex"></param>
	private void setUpdateRectItem(int scrollPerLineIndex)
	{
		if (scrollPerLineIndex < 0) 
		{
			return;
		}
		curScrollPerLineIndex = scrollPerLineIndex;
		int startDataIndex = curScrollPerLineIndex * maxPerLine;//要显示区域的开始数据坐标
		int endDataIndex = (curScrollPerLineIndex + viewCount) * maxPerLine;//要显示区域的结束数据坐标
		//移除
		for (int i = listItem.Count - 1; i >= 0; i--)  
		{
			UIWarpContentItem item = listItem[i];
			int index = item.Index;
			if (index < startDataIndex || index >= endDataIndex) 
			{
				item.Index = -1;
				listItem.Remove (item);//从显示集合移除
				unUseItem.Enqueue (item);//入没有使用队列
			}
		}

		//显示
		for(int dataIndex = startDataIndex;dataIndex<endDataIndex;dataIndex++)
		{
			if (dataIndex >= dataCount) 
			{
				continue;
			}
			if (isExistDataByDataIndex (dataIndex)) //要显示的数据已经在显示列表中就跳过循环
			{
				continue;
			}
			createItem (dataIndex);

        }
	}
    /// <summary>
    /// 添加当前数据索引数据
    /// </summary>
    /// <param name="dataIndex"></param>
    public void AddItem(int dataIndex)
	{
        print("dataIndex" + dataIndex + "datacount" + dataCount);

        if (dataIndex<0 || dataIndex > dataCount)
		{
			return;
		}
		//检测是否需添加gameObject
		bool isNeedAdd = false;
		for (int i = listItem.Count-1; i>=0 ; i--) {
			UIWarpContentItem item = listItem [i];
			if (item.Index >= (dataCount - 1)) {//已经显示的下标是最后一个数据或倒数第二个数据，就需要添加
				isNeedAdd = true;
				break;
			}
		}
		setDataCount (dataCount+1);//重新设置item总量
                                                        
		if (isNeedAdd) {
			for (int i = 0; i < listItem.Count; i++) {
				UIWarpContentItem item = listItem [i];
				int oldIndex = item.Index;
				if (oldIndex>=dataIndex) {//如果已显示的item索引大于等于添加的索引就增加一个index
					item.Index = oldIndex+1;
				}
				item = null;
			}
			setUpdateRectItem (getCurScrollPerLineIndex());//设置显示
		} else {
			//重新刷新数据
			for (int i = 0; i < listItem.Count; i++) {
				UIWarpContentItem item = listItem [i];
				int oldIndex = item.Index;
				if (oldIndex>=dataIndex) {
					item.Index = oldIndex;
                    Debug.Log(item.gameObject.name + item.Index);
				}
				item = null;
			}
		}

	}

    /// <summary>
    /// 删除当前数据索引下数据
    /// </summary>
    /// <param name="dataIndex"></param>
    public void DelItem(int dataIndex){
		if (dataIndex < 0 || dataIndex >= dataCount) {
			return;
		}
		//删除item逻辑三种情况
		//1.只更新数据，不销毁gameObject,也不移除gameobject
		//2.更新数据，且移除gameObject,不销毁gameObject
		//3.更新数据，销毁gameObject

		bool isNeedDestroyGameObject = (listItem.Count >= dataCount);
		setDataCount (dataCount-1);

		for (int i = listItem.Count-1; i>=0 ; i--) {
			UIWarpContentItem item = listItem [i];
			int oldIndex = item.Index;
			if (oldIndex == dataIndex) {
				listItem.Remove (item);
				if (isNeedDestroyGameObject) {
                    Destroy(item.gameObject);
				} else {
					item.Index = -1;
					unUseItem.Enqueue (item);			
				}
			}
			if (oldIndex > dataIndex) {
				item.Index = oldIndex - 1;
			}
		}
		setUpdateRectItem(getCurScrollPerLineIndex());
	}


    /// <summary>
    /// 获取当前index下对应Content下的本地坐标
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 getLocalPositionByIndex(int index){
		float x = 0f;
		float y = 0f;
		float z = 0f;
		switch (arrangement) {
		case Arrangement.Horizontal: //水平方向
			x = (index / maxPerLine) * (cellWidth + cellWidthSpace);
			y = -(index % maxPerLine) * (cellHeight + cellHeightSpace);
			break;
		case  Arrangement.Vertical://垂着方向
			x =  (index % maxPerLine) * (cellWidth + cellWidthSpace);
			y = -(index / maxPerLine) * (cellHeight + cellHeightSpace);
			break;
		}
		return new Vector3(x,y,z);
	}

	/// <summary>
    /// 创建元素
    /// </summary>
    /// <param name="dataIndex"></param>
	private void createItem(int dataIndex){
		UIWarpContentItem item;
		if (unUseItem.Count > 0) {//没有使用队列中有数据就从队列中取一个出来
			item = unUseItem.Dequeue();
            print("从队列中取出"+dataIndex);
		} else {
			item = addChild (goItemPrefab, content).AddComponent<UIWarpContentItem>();//队列中没有数据就直接创建一个
		}
		item.WarpContent = this;
		item.Index = dataIndex;
		listItem.Add(item);
	}

    /// <summary>
    /// 当前数据是否存在List中
    /// </summary>
    /// <param name="dataIndex"></param>
    /// <returns></returns>
    private bool isExistDataByDataIndex(int dataIndex){
		if (listItem == null || listItem.Count <= 0) {
			return false;
		}
		for (int i = 0; i < listItem.Count; i++) {
			if (listItem [i].Index == dataIndex) {
				return true;
			}
		}
		return false;
	}


    /// <summary>
    /// 根据Content偏移,计算当前开始显示所在数据列表中的行或列
    /// </summary>
    /// <returns></returns>
    private int getCurScrollPerLineIndex()
	{
		switch (arrangement) 
		{
		case Arrangement.Horizontal: //水平方向
			return Mathf.FloorToInt(Mathf.Abs(content.anchoredPosition.x)/(cellWidth+cellWidthSpace));
		case  Arrangement.Vertical://垂着方向
			return Mathf.FloorToInt(Mathf.Abs(content.anchoredPosition.y)/(cellHeight+cellHeightSpace));
		}
		return 0;
	}

    /// <summary>
    /// 更新Content SizeDelta
    /// </summary>
    private void setUpdateContentSize()
	{
		int lineCount = Mathf.CeilToInt((float)dataCount/maxPerLine);//计算出这些item一共占用多少行
		switch (arrangement)
		{
		 case Arrangement.Horizontal:
			content.sizeDelta = new Vector2(cellWidth * lineCount + cellWidthSpace * (lineCount - 1), content.sizeDelta.y);//根据Item数量修改sizeDelta的大小
                break;
		 case Arrangement.Vertical:
			content.sizeDelta = new Vector2(content.sizeDelta.x, cellHeight * lineCount + cellHeightSpace * (lineCount - 1));
			break;
		}
    }

   /// <summary>
   /// 实例化预设对象 、添加实例化对象到指定的父对象下
   /// </summary>
   /// <param name="预制体"></param>
   /// <param name="父节点"></param>
   /// <returns></returns>
    private GameObject addChild(GameObject goPrefab,Transform parent)
	{
		if (goPrefab == null || parent == null) {
			Debug.LogError("异常。UIWarpContent.cs addChild(goPrefab = null  || parent = null)");
			return null;
		}
		GameObject goChild = GameObject.Instantiate (goPrefab) as GameObject;
		goChild.layer = parent.gameObject.layer;
		goChild.transform.SetParent (parent,false);

		return goChild;
	}

	void OnDestroy(){
		
		scrollRect = null;
		content = null;
		goItemPrefab = null;
		onInitializeItem = null;

		listItem.Clear ();
		unUseItem.Clear ();

		listItem = null;
		unUseItem = null;

	}
}
