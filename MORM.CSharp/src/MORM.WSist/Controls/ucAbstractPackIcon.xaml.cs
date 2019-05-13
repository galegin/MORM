﻿using MaterialDesignThemes.Wpf;
using MORM.Apresentacao.Views;

namespace MORM.WSist.Controls
{
    public partial class ucAbstractPackIcon : AbstractView
    {
        public ucAbstractPackIcon(PackIconKind packIconKind) : base(null)
        {
            InitializeComponent();
            DataContext = new AbstractPackIconViewModel(packIconKind);
        }
    }
}
