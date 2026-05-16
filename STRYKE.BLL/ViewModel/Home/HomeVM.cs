using System;

namespace STRYKE.BLL.ViewModel.Home;

public class HomeVM
{
    public IEnumerable<CategoryVM> Categories { get; set; } = [];
}
