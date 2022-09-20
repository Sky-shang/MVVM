using MVVMToolkit_Sample.Model;
using MVVMToolkit_Sample.ViewModel;

namespace MVVMToolkit_Sample.View
{
    public partial class EditWindow
    {
        /// <summary>
        /// 构造 传参
        /// </summary>
        /// <param name="user"></param>
        public EditWindow(User user)
        {
            InitializeComponent();
            DataContext = new EditViewModel(user);
        }
    }
}
