using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbAppByM.ViewModel
{
    /// <summary>
    /// Based on the works found @https://stackoverflow.com/questions/16172462/close-window-from-viewmodel
    /// </summary>
    interface IClosable
    {
        void CloseWindow();
    }
}
