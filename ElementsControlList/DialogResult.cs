using System;
using System.Windows;

namespace ElementsControlList
{
    internal class DialogResult
    {
        public static implicit operator DialogResult(MessageBoxResult v)
        {
            throw new NotImplementedException();
        }
    }
}