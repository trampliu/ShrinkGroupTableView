using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShrinkGroupTableView : MonoBehaviour {

    public GameObject Table; // table
    
    public List<int> CellNumberForSections; // the number of cells in section
    private int SectionNumber; // the number of sections in tableView

    private const string prefabPathForSection = "Section"; // the path of the section prefab
    private const string prefabPathForCell = "Cell"; // the path of the cell prefab


    private float sectionHeight = 0.0f;

    /// <summary>
    /// Add cells by index of section (将cell添加到特定的组)
    /// </summary>
    /// <param name="index">which section</param>
    /// <param name="grid">grid</param>
    /// <returns>cells for the spec section</returns>
    private void AddCellsForSectionAtIndex(int index,GameObject grid) {
        if (CellNumberForSections != null && CellNumberForSections.Count > 0 && (CellNumberForSections.Count - 1) >= index)
        {
            int number = CellNumberForSections[index];
            NGUITools.AddChild(grid, new GameObject()); // this gameobject for placeholder (当做占位使用)
            for (int i = 0; i < number; i++)
            {
                GameObject cell = NGUITools.AddChild(grid, Resources.Load(prefabPathForCell) as GameObject);

                // at here, you can init cell (bound events or add some data)
            }
        }
    }

    /// <summary>
    /// Get section (获取组)
    /// </summary>
    /// <returns>section for the tableView</returns>
    private GameObject SectionForTableView() {

        return NGUITools.AddChild(Table, Resources.Load(prefabPathForSection) as GameObject);
    }


    /// <summary>
    /// get grid for spec section
    /// </summary>
    /// <returns></returns>
    private GameObject GetGridForSection(GameObject section) {
        if(section!=null){
            GameObject grid = section.transform.GetComponentInChildren<UIGrid>().gameObject;
            return grid;
        }
        return null;
        
    }

    /// <summary>
    /// init tableView （初始化 tableView）
    /// </summary>
    private void InitTableView(){
        if(SectionNumber > 0){
            List<GameObject> popUpListTweens = new List<GameObject>();
            for (int i = 0; i < SectionNumber; i++)
            {
                GameObject section = SectionForTableView();
                GameObject grid = GetGridForSection(section);
                AddCellsForSectionAtIndex(i, grid);
            }
        }
    }


	// Use this for initialization
	void Start () {
        SectionNumber = CellNumberForSections.Count;
        InitTableView();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
