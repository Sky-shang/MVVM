using MVVMToolkit_Sample.Common;
using MVVMToolkit_Sample.Model;
using System.Windows.Input;

namespace MVVMToolkit_Sample.ViewModel
{
    public class LoginViewModel:ViewModelBase
    {
        #region 初始化
        public LoginViewModel()
        {
            //初始化数据 - 请不要这里做太多任务，如果有需要可以使用Task
            User.Name = "admin";
            User.Password = "admin";
        }
        #endregion

        #region 属性
        private User user;
        /// <summary>
        /// 当前用户
        /// </summary>
        public User User
        {
            get {
                if (user==null)
                {
                    user = new User();
                }
                return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        #endregion

        #region 命令
        /// <summary>
        /// 登录操作
        /// </summary>    
        public ICommand LoginCommand => new DelegateCommand(obj =>
        {
            if (User.Name == "admin" && User.Password == "admin")
            {
                Auth.Login = true;
                WindowHelper.ShowPageHome();
            }
        });
        #endregion
    }
}
