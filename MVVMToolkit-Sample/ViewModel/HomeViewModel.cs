using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMToolkit_Sample.Common;
using MVVMToolkit_Sample.Model;
using MVVMToolkit_Sample.View;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMToolkit_Sample.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        #region 初始化
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public HomeViewModel()
        {
            //初始化数据 - 请不要这里做太多任务，如果有需要可以使用Task
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        break;
                    }

                    Thread.Sleep(1000);

                    //虽然UI绑定了这个元素 但是不需要 使用UI调度器。
                    Progress = i;

                    //并不是所有对数据操作都需要UI调度器,只有UI创建了视图对象的时候才需要
                    //这里的DataGrid 根据Users创建了视图列表，所以资源属于UI层。
                    Execute.OnUIThread(() =>
                    {
                        Users.Add(new User() { Name = $"用户{i}", Vip = true });
                    });
                }
            });
        }
        #endregion

        #region 属性
        private double _progress;
        /// <summary>
        /// 进度
        /// </summary>
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        private ObservableCollection<User> _users;
        /// <summary>
        /// 用户列表
        /// </summary>
        public ObservableCollection<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new ObservableCollection<User>();
                }
                return _users;
            }

            set => SetProperty(ref _users, value);
        }

        #endregion

        #region 命令

        /// <summary>
        /// 停止
        /// </summary>    
        public ICommand StopCommand => new RelayCommand(() =>
        {
            cancellationTokenSource.Cancel();
        });


        /// <summary>
        /// 编辑用户
        /// </summary>    
        public ICommand EditCommand => new RelayCommand<User>(obj =>
        {
            EditWindow editWindow = new EditWindow(obj);
            editWindow.ShowDialog();
        });

        #endregion
    }
}
