//**********************************************************************************************************************************
//LICENSING
// Copyright(C) 2021, 2025  TG Team,Key Laboratory of Jiangsu province High-Tech design of wind turbine,WTG,WL,赵子祯
//
//    This file is part of OpenWECD.Openhast
//
// Licensed under the Boost Software License - Version 1.0 - August 17th, 2003
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.HawtC.cn/licenses.txt
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT. IN NO EVENT
// SHALL THE COPYRIGHT HOLDERS OR ANYONE DISTRIBUTING THE SOFTWARE BE LIABLE
// FOR ANY DAMAGES OR OTHER LIABILITY, WHETHER IN CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//
//**********************************************************************************************************************************

using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using OpenWECD.PreComp;
using NumpyDotNet;
using OpenWECD.IO.IO;
using OpenWECD.IO.Log;
using OpenWECD.IO.Log;

namespace OpenWECD.HawtC2
{
    /// <summary>
    /// 这个版本的主要目的是
    /// </summary>
    public class PreComp_Pro
    {
        static void Main(string[] args)
        {
            np.tuning.EnableTryCatchOnCalculations = false;
            LogHelper.DisplayInformation(false,false);
            INI_IO.INIProgram();

            string path = "";
            //# 31m叶片测试案例
            path = @"G:\2026\HawtC2\demo\PreComp\test01_composite_blade.pci";


            //TimesHelper.Tic();
            //var a2 = Matrix<double>.Build.Random(40, 40);
            //var b2 = a2 + a2;
            //for (int i = 0; i < 100000; i++)
            //{
            //    b2 = b2 * b2 + b2;
            //}
            //Console.WriteLine(b2.ToString());
            //TimesHelper.Toc();

            //var test = np.array(b2);
            //Console.WriteLine(test.shape);


            //TimesHelper.Tic();
            //var rand = new np.random();
            //rand.seed(100);
            //var a = rand.rand(new shape(10000, 3, 40, 40));
            //var b =(ndarray)a[1, 1, ":", ":"] ;
            //for (int i = 0; i < 100000; i++)
            //{
            //    b = (ndarray)a[1, 1, ":", ":"];
            //    b = b * b + b;
            //}

            //Console.WriteLine(b.ToString());
            //TimesHelper.Toc();

            //TimesHelper.Tic();
            //var a1 = new Vector3(0.1f, 0.2f, 0.3f);
            //var b1 = a1 + a1;
            //for (int i = 0; i < 1000000; i++)
            //{
            //    b1 = Vector3.Dot(a1, b1) * b1;
            //}
            //Console.WriteLine(b1.ToString());
            //TimesHelper.Toc();



#if RELEASE
            //# 不经过CLi系统只能允许文件

            if (args.Length == 1)
            {
                path = args[0];
                goto Label;
            }
            else if (args.Contains("cli") | args.Contains("CLI"))
            {
                path = Path.Combine(path.GetDirectoryName(), path.GetFileNameWithoutExtension()) + ".yml";
                var pci = OpenWECD.PreComp.PciL_IO_Subs.ReadPreCompL_MainFile(args[1]);
                path = path + "pci";
                var yaml13 = new OpenWECD.IO.IO.YML(path);
                new OpenWECD.PreComp.PciL_IO_Subs().ConvertToYML(ref yaml13, pci);
                yaml13.save();
                LogHelper.EndProgram(keepstay: true);
            }
            Console.Write(" > ");
            path = Console.ReadLine();
            if (path is null)
            {
                LogHelper.ErrorLog("The file path is null!", FunctionName: "Main");
                path = " ";
            }
#endif
#if DEBUG


#endif
        Label:
            CheckError.Filexists(path);
            var temp1 = File.ReadAllLines(path);
            string inf = temp1[0];
            LogHelper.WriteLog("------------------------------------------------------------------------------------", color: ConsoleColor.Blue, show_title: false, leval: 1);
            LogHelper.WriteLog("! The PreComp Analysis:" + temp1[1], color: ConsoleColor.Blue, show_title: false, leval: 1);
            LogHelper.WriteLog("------------------------------------------------------------------------------------", color: ConsoleColor.Blue, show_title: false, leval: 1);


            //# 先读取文件
            var pre = OpenWECD.PreComp.PciL_IO_Subs.ReadPreCompL_MainFile(path);
            var pe = new PciL_Subs(pre);
            pe.run();
            LogHelper.EndProgram(keepstay: true);
            Console.WriteLine();


        }

    }
}