using System;
using Bootstrap;
using Friend;

namespace HelloAssembly {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            // Trick
            BootstrapClazz.Log = Console.WriteLine;
            FriendClazz.Log = Console.WriteLine;

            // SDK 初始化
            BootstrapClazz.Init();

            // 模拟游戏业务侧调用好友接口
            FriendClazz.Hello();

            Console.ReadKey();
        }
    }
}
