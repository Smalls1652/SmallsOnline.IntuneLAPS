using System;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace SmallsOnline.IntuneLAPS.Client.Core
{
    public class LocalAdminAccount
    {
        public LocalAdminAccount(string user)
        {
            _localAdminUser = GetLocalAdminUserAccount(user);
        }

        public string UserName
        {
            get => _localAdminUser.SamAccountName;
        }

        public SecurityIdentifier UserSID
        {
            get => _localAdminUser.Sid;
        }

        private protected readonly UserPrincipal _localAdminUser;

        private readonly PrincipalContext _principalContext = new(ContextType.Machine);

        public void UpdateAccountPassword(string newPassword)
        {
            _localAdminUser.SetPassword(newPassword);
        }

        public bool IsPasswordExpired(int maxPasswordAge)
        {
            DateTime passwordExpirationTime = _localAdminUser.LastPasswordSet.Value.AddDays(maxPasswordAge);

            return DateTime.Now >= passwordExpirationTime;
        }

        private UserPrincipal GetLocalAdminUserAccount(string user)
        {
            UserPrincipal userItem = UserPrincipal.FindByIdentity(_principalContext, IdentityType.SamAccountName, user);

            if (userItem == null)
            {
                throw new Exception($"No account was found with the username of '{user}'.");
            }

            return userItem;
        }
    }
}