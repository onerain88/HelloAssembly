using System;

namespace Friend {
    public class FriendClazz {
        public static Action<string> Log;

        public static void Init() {
            Log("Friend Init");
        }

        public static void Hello() {
            Log("Friend Hello");
        }
    }
}
