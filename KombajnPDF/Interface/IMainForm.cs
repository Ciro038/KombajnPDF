using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    interface IMainForm
    {
        event Action LoadFormData;
        event Action OpenSettings;
        event Action AddFiles;
        event Action MoveUpFiles;
        event Action MoveDownFiles;
        event Action RemoveFiles;
        event Action CombineFiles;

        void FillDataGridView();

    }
}
