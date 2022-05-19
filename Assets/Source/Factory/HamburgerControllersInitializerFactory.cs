using System.Collections.Generic;
using System;

public class HamburgerControllersInitializerFactory
{
    private HamburgerControllersData _data;

    public HamburgerControllersInitializerFactory(HamburgerControllersData data)
    {
        _data = data;
    }

    public HamburgerControllersInitializer Create(List<(HamburgerController, HamburgerControllerImage)> containers)
    {
        if (containers is null)
            throw new ArgumentNullException(containers + " is null");

        return new HamburgerControllersInitializer(_data, containers);
    }
}
