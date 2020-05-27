﻿using Avalonia;
using Avalonia.Controls;
using SkyEditor.RomEditor.Rtdx.Avalonia.Infrastructure;
using SkyEditor.RomEditor.Rtdx.Avalonia.ViewModels.Rtdx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkyEditor.RomEditor.Rtdx.Avalonia.ViewModels.MenuItems
{
    public class SaveDirectoryAsMenuItem : MenuItem<RtdxRomViewModel>
    {
        public SaveDirectoryAsMenuItem(MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel)
        {
        }

        protected override async Task Execute(RtdxRomViewModel viewModel)
        {
            var dialog = new OpenFolderDialog();

            var path = await dialog.ShowAsync(Application.Current.GetMainWindowOrThrow());
            if (!string.IsNullOrEmpty(path))
            {
                viewModel.Save(path);
            }
        }
    }
}