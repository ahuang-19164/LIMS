﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.HotKey
{
    //Handle为当前窗口的句柄,继续自Control.Handle,Control为定义控件的基类
    //RegisterHotKey(Handle, 100, 0, Keys.A); //注册快捷键,热键为A
    //RegisterHotKey(Handle, 100, KeyModifiers.Alt | KeyModifiers.Control, Keys.B);//这时热键为Alt+CTRL+B
    //RegisterHotKey(Handle, 100, 1, Keys.B); //1为Alt键，热键为Alt+B
    public class HotKeys
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")] //申明API函数
        public static extern bool RegisterHotKey(
         IntPtr hWnd, // 窗把句柄
         int id, // 热键标识符
         uint fsModifiers, // 关键点修改器选项
         Keys vk // 虚拟密钥代码
        );

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern bool RegisterHotKeys(
        //  IntPtr hWnd,        //要定义热键的窗口的句柄
        //  int id,           //定义热键ID（不能与其它ID重复）      
        //  KeyModifiers fsModifiers,  //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
        //  Keys vk           //定义热键的内容
        //  );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
          IntPtr hWnd,        //要取消热键的窗口的句柄
          int id           //要取消热键的ID
          );
        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        public static Dictionary<int, string> HotKey = new Dictionary<int, string>()
        {
            {48,"0"},
            {49,"1"},
            {50,"2"},
            {51,"3"},
            {52,"4"},
            {53,"5"},
            {54,"6"},
            {55,"7"},
            {56,"8"},
            {57,"9"},
            {65,"A"},
            {66,"B"},
            {67,"C"},
            {68,"D"},
            {69,"E"},
            {70,"F"},
            {71,"G"},
            {72,"H"},
            {73,"I"},
            {74,"J"},
            {75,"K"},
            {76,"L"},
            {77,"M"},
            {78,"N"},
            {79,"O"},
            {80,"P"},
            {81,"Q"},
            {82,"R"},
            {83,"S"},
            {84,"T"},
            {85,"U"},
            {86,"V"},
            {87,"W"},
            {88,"X"},
            {89,"Y"},
            {90,"Z"},
            {112,"F1"},
            {113,"F2"},
            {114,"F3"},
            {115,"F4"},
            {116,"F5"},
            {117,"F6"},
            {118,"F7"},
            {119,"F8"},
            {120,"F9"},
            {121,"F10"},
            {122,"F11"},
            {123,"F12"},
            {33,"PageUp"},
            {34,"PageDown"},
            {35,"End"},
            {36,"Home"},
            {37,"←"},
            {38,"↑"},
            {39,"→"},
            {40,"↓"},
            {45,"Insert"},
            {46,"Delete"},
            {186,";"},
            {187,"="},
            {188,","},
            {189,"-"},
            {190,"."},
            {191,"/"},
            {192,"`"},
            {219,"["},
            {220,"\\"},
            {221,"]"}
        };
    }
}
