using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp
{
    public interface ILocalFileHandler
    {
        string GetLocalFilePath(string FilePath);
    }
}
