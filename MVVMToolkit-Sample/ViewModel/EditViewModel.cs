using CommunityToolkit.Mvvm.ComponentModel;
using MVVMToolkit_Sample.Common;
using MVVMToolkit_Sample.Model;

namespace MVVMToolkit_Sample.ViewModel
{
    /// <summary>
    /// 编辑用户
    /// </summary>
    public class EditViewModel : ObservableObject
    {
        #region 初始化
        public EditViewModel(User user)
        {
            User = user;
        }
        #endregion

        #region 属性
        private User _user;
        /// <summary>
        /// 编辑用户
        /// </summary>
        public User User
        {
            get
            {
                if (_user == null)
                {
                    _user = new User();
                }
                return _user;
            }
            set => SetProperty(ref _user, value);
        }
        #endregion
    }
}
