﻿using System.Reflection;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("HLFramework")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("西安屹辰智禾信息科技有限公司")]
[assembly: AssemblyProduct("HLFramework")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("42af9c02-c533-4c7f-ac02-bbae611e27b1")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
// 可以指定所有值，也可以使用以下所示的 "*" 预置版本号和修订号
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.6.0.2")]
[assembly: AssemblyFileVersion("1.6.0.2")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", ConfigFileExtension = "config", Watch = true)]
