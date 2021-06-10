using System;
using System.Reflection;

namespace Bootstrap {
    public class BootstrapClazz {
        public static Action<string> Log;

        public static void Init() {
            Log("Bootstrap Init");
            Assembly entryAssembly = Assembly.GetCallingAssembly();
            AssemblyName[] refNames = entryAssembly.GetReferencedAssemblies();
            foreach (AssemblyName refName in refNames) {
                Log(refName.ToString());
                // 好友模块
                if (refName.Name == "Friend") {
                    Assembly assembly = Assembly.Load(refName);
                    Type type = assembly.GetType("Friend.FriendClazz");
                    MethodInfo mi = type.GetMethod("Init");
                    mi.Invoke(null, null);
                }
                // TODO 其他模块

            }
        }
    }
}
