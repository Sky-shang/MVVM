using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMToolkit_Sample.Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : ObservableObject
    {
        private string _name;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _vip;
        /// <summary>
        /// 是否VIP
        /// </summary>
        public bool Vip
        {
            get => _vip;
            set => SetProperty(ref _vip, value);
        }
    }
}
