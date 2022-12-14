using System;
using System.IO;
using MDD4All.FileAccess.Contracts;
using Microsoft.Win32;

namespace MDD4All.FileAccess.WPF
{
    public class WpfFileSaver : IFileSaver
    {
        public bool ShowFileSaveDialog(out string selectedFilename, string defaultFielname = "", string defaultFileExtension = "", string filter = "All Files (*.*)|*.*")
        {
            bool result = false;
            selectedFilename = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (!string.IsNullOrEmpty(filter))
            {
                saveFileDialog.Filter = filter;
            }
            if (!string.IsNullOrEmpty(defaultFielname))
            {
                saveFileDialog.FileName = defaultFielname;
            }
            if(string.IsNullOrEmpty(defaultFileExtension))
            {
                saveFileDialog.DefaultExt = defaultFileExtension;
            }

            bool? dialogResult = saveFileDialog.ShowDialog();

            if(dialogResult.HasValue)
            {
                if(dialogResult.Value == true)
                {
                    selectedFilename = saveFileDialog.FileName;
                    result = true;
                }
            }

            return result;
        }

        public void WriteDataToFile(string filename, byte[] data)
        {
            try
            {
                File.WriteAllBytes(filename, data);
            }
            catch (Exception exception)
            { }
        }
    }
}
