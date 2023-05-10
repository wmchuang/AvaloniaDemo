using System.Threading.Tasks;
using Avalonia.Controls;

namespace YlBaseUI.MessageBox.Base;

public interface IMsBoxWindow<T>
{
    /// <summary>
    /// Open message box window as dialog window under owner
    /// </summary>
    /// <param name="ownerWindow"></param>
    /// <returns></returns>
    Task<T> ShowDialog (Window ownerWindow);
   
}