using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Test
{
    public static class ChatMemory
    {
        
        public static Dictionary<string, Dictionary<string, ObservableCollection<ChatMessage>>> AllChats
            = new Dictionary<string, Dictionary<string, ObservableCollection<ChatMessage>>>();
    }
}
