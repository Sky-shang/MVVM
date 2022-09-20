using MVVMToolkit_Sample.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMToolkit_Sample.Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : ViewModelBase
    {
        private string _name;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _vip;
        /// <summary>
        /// 是否VIP
        /// </summary>
        public bool Vip
        {
            get { return _vip; }
            set
            {
                _vip = value;
                OnPropertyChanged(nameof(Vip));
            }
        }
    }
}
