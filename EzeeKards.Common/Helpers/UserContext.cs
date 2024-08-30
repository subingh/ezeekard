using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Common.Helpers
{
    public class UserContext
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }

    public static class UserContextAccessor
    {
        private static AsyncLocal<UserContext> _userContext = new();

        public static UserContext Current
        {
            get => _userContext.Value;
            set => _userContext.Value = value;
        }

        public static Guid Id => Current?.Id ?? Guid.Empty;

        public static string Name => Current?.Name;

        public static string Role => Current?.Role;

    }
}
