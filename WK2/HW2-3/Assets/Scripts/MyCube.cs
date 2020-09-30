using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class MyCube : MonoBehaviour
{
    LuaEnv luaenv = new LuaEnv();
    public GameObject Cube;
    public float timer = 0;
    public float interval = 3;

    [LuaCallCSharp]
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Quaternion quater = new Quaternion(0, 0, 0, 1);
            Instantiate(Cube, position, quater);
            timer = 0;
        }
        Debug.Log("------[original] interval = 3------");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(500, 10, 100, 60), "Hotfix"))
        {
            luaenv.DoString(@"
                xlua.hotfix(CS.MyCube, 'Update', function(self)
                    self.interval = 1
                    CS.UnityEngine.Debug.Log('------[hotfix] interval = 1------')
                    self.timer = self.timer + CS.UnityEngine.Time.deltaTime;
                    if self.timer >= self.interval then
                        CS.UnityEngine.GameObject.Instantiate(self.Cube, CS.UnityEngine.Vector3(0, 0, 0), CS.UnityEngine.Quaternion(0, 0, 0, 1))
                        self.timer = 0;
                    end
                end)
            ");
        }
        string enHint = @"Press Hotfix Button to SPEED UP the cube generation! Try it!";
        GUIStyle style = GUI.skin.textArea;
        style.normal.textColor = Color.white;
        style.fontSize = 16;
        GUI.TextArea(new Rect(300, 100, 500, 60), enHint, style);
    }
}
