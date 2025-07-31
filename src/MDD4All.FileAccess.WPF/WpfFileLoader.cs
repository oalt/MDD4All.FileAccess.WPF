using MDD4All.FileAccess.Contracts;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace MDD4All.FileAccess.WPF
{
    public class WpfFileLoader : IFileLoader
    {
        public byte[] ReadDataFromFile(string filename)
        {
            byte[] result = null;

            try
            {
                result = File.ReadAllBytes(filename);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return result;
        }

        public bool ShowOpenFileDialog(out string selectedFilename, 
                                       string defaultFielname = "", 
                                       string defaultFileExtension = "", 
                                       string filter = "All Files (*.*)|*.*",
                                       string title = "Open file...")
        {
            bool result = false;
            selectedFilename = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = title;

            if (!string.IsNullOrEmpty(filter))
            {
                openFileDialog.Filter = filter;
            }
            if (!string.IsNullOrEmpty(defaultFielname))
            {
                openFileDialog.FileName = defaultFielname;
            }
            if (string.IsNullOrEmpty(defaultFileExtension))
            {
                openFileDialog.DefaultExt = defaultFileExtension;
            }

            bool? dialogResult = openFileDialog.ShowDialog();

            if (dialogResult.HasValue)
            {
                if (dialogResult.Value == true)
                {
                    selectedFilename = openFileDialog.FileName;
                    result = true;
                }
            }

            return result;
        }
    }
}
