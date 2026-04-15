using Entities;
using HustlersAB.Shared.Menus;

namespace HustlersAB.Admin.Menus;

public class SelectManufacturerMenu(IEnumerable<Manufacturer> manufacturers) : BaseMenu
{
    private readonly List<Manufacturer> _manufacturers = manufacturers.ToList();
    private int _page = 0;
    private const int PageSize = 20;
    public Manufacturer? SelectedManufacturer { get; set; }
    protected override string[] Options
    {
        get
        {
            var paged = _manufacturers
                .Skip(_page * PageSize)
                .Take(PageSize)
                .ToList();
            var options = paged
                .Select(m => m.Name)
                .ToList();

            if ((_page + 1) * PageSize < _manufacturers.Count)
                options.Add("Next →");

            if (_page > 0)
                options.Add("← Previous");

            options.Add("Go Back");

            return options.ToArray(); ;
        }
    }

    protected override string MenuTitle => "menu -> admin -> SELECT MANUFACTURER";

    protected override bool ExecuteChoice(int selectedIndex)
    {
        var paged = _manufacturers.Skip(_page * PageSize).Take(PageSize).ToList();
        int nextPage = paged.Count;
        int prevPage = paged.Count + ((_page + 1) * PageSize < _manufacturers.Count ? 1 : 0);
        int goBack = prevPage + (_page > 0 ? 1 : 0);

        if ((_page + 1) * PageSize < _manufacturers.Count && selectedIndex == nextPage)
        {
            _page++;
            SelectedIndex = 0;
            return false;
        }

        if (_page > 0 && selectedIndex == prevPage)
        {
            _page--;
            SelectedIndex = 0;
            return false;
        }

        if (selectedIndex == goBack)
            return true;

        SelectedManufacturer = paged[selectedIndex];
        return true;
    }
}
